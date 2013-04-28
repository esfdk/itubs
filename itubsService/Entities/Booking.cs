namespace ITubsService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using ITubsService.Enums;

    /// <summary>
    /// The booking.
    /// </summary>
    [DataContract(IsReference = true)]
    [KnownType(typeof(CateringChoice))]
    [KnownType(typeof(EquipmentChoice))]
    [KnownType(typeof(Person))]
    [KnownType(typeof(Room))]
    public class Booking
    {
        public Booking()
        {
            CateringChoices = new List<CateringChoice>();
            EquipmentChoices = new List<EquipmentChoice>();
        }

        private static IEnumerable<Booking> All
        {
            get
            {
                return ItubsContext.Db.Bookings.Include("CateringChoices").Include("EquipmentChoices").ToList();
            }
        }

        public static Booking GetBookingByID(int id)
        {
            return All.FirstOrDefault(b => b.ID == id);
        }

        public static IEnumerable<Booking> GetAllBookings(Person person)
        {
            if (person != null)
            {
                return All.Where(b => b.PersonID == person.ID);
            }

            return All;
        }

        public static IEnumerable<Booking> GetBookingsByDate(DateTime date)
        {
            return All.Where(b => b.StartTime.Date.Equals(date.Date));
        }

        public static Booking CreateNewBooking(Booking booking)
        {
            var room = Room.GetRoomByID(booking.RoomID);

            if (!IsBookingTimeValid(booking)
                && !OverlappingBookings(booking).Any()
                && (booking.NumberOfParticipants > room.MaxParticipants)
                && !IsAStatus(booking.Status)
                && (booking.PersonID <= 0 || booking.RoomID <= 0))
            {
                return null;
            }

            ItubsContext.Db.Bookings.Add(
                new Booking
                    {
                        PersonID = booking.PersonID,
                        RoomID = booking.RoomID,
                        StartTime = booking.StartTime,
                        EndTime = booking.EndTime,
                        Comments = booking.Comments,
                        NumberOfParticipants = booking.NumberOfParticipants,
                        Status = booking.Status,
                    });

            ItubsContext.Db.SaveChanges();

            return
                All.FirstOrDefault(
                    b =>
                    b.NumberOfParticipants == booking.NumberOfParticipants && b.PersonID == booking.PersonID
                    && b.RoomID == booking.RoomID && b.Status.Equals(booking.Status)
                    && b.Comments.Equals(booking.Comments) && b.StartTime.Equals(booking.StartTime)
                    && b.EndTime.Equals(booking.EndTime));
        }

        public RequestStatus ChangeTime(Booking changedBooking)
        {
            if (this.ID == changedBooking.ID
                && this.RoomID == changedBooking.RoomID
                && this.PersonID == changedBooking.PersonID
                && IsBookingTimeValid(changedBooking))
            {
                var overlapping = OverlappingBookings(changedBooking);
                if (overlapping.Count > 0 && overlapping.All(b => b.PersonID != changedBooking.PersonID))
                {
                    var updatedBooking = overlapping.First();
                    updatedBooking.StartTime = changedBooking.StartTime;
                    updatedBooking.EndTime = changedBooking.EndTime;
                    foreach (var b in overlapping)
                    {
                        foreach (var ec in b.EquipmentChoices)
                        {
                            if (TimeInsideBooking(updatedBooking, ec.StartTime, ec.EndTime))
                            {
                                ec.BookingID = changedBooking.ID;
                            }
                            else
                            {
                                ItubsContext.Db.EquipmentChoices.Remove(ec);
                            }
                        }

                        foreach (var cc in b.CateringChoices)
                        {
                            if (updatedBooking.StartTime <= cc.Time && updatedBooking.EndTime >= cc.Time)
                            {
                                cc.BookingID = changedBooking.ID;
                            }
                            else
                            {
                                ItubsContext.Db.CateringChoices.Remove(cc);
                            }
                        }
                    }

                    ItubsContext.Db.SaveChanges();
                    return RequestStatus.Success;
                }

                if (overlapping.Count == 0)
                {
                    this.StartTime = changedBooking.StartTime;
                    this.EndTime = changedBooking.EndTime;

                    foreach (var ec in this.EquipmentChoices)
                    {
                        ItubsContext.Db.EquipmentChoices.Remove(ec);
                    }

                    foreach (var cc in this.CateringChoices)
                    {
                        ItubsContext.Db.CateringChoices.Remove(cc);
                    }

                    ItubsContext.Db.SaveChanges();
                    return RequestStatus.Success;
                }

                return RequestStatus.InvalidInput;
            }

            return RequestStatus.InvalidInput;
        }

        public int ID { get; set; }
        public string Status { get; set; }
        public int NumberOfParticipants { get; set; }
        public string Comments { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PersonID { get; set; }
        public int RoomID { get; set; }
        public virtual ICollection<CateringChoice> CateringChoices { get; set; }
        public virtual ICollection<EquipmentChoice> EquipmentChoices { get; set; }
        public virtual Person Person { get; set; }
        public virtual Room Room { get; set; }

        private static bool IsAStatus(string status)
        {
            return !string.IsNullOrWhiteSpace(status) && (status.Equals("Accepted") || status.Equals("Pending"));
        }

        private static bool IsBookingTimeValid(Booking booking)
        {
            return booking.StartTime < booking.EndTime
                   && booking.StartTime.Hour >= Configuration.EarliestBooking.Hour
                   && booking.EndTime.Hour <= Configuration.LatestBooking.Hour
                   && booking.StartTime.Date.Equals(booking.EndTime.Date);
        }

        private static List<Booking> OverlappingBookings(Booking booking)
        {
            return All.Where(
                        b =>
                        b.RoomID == booking.RoomID
                        &&
                        ((b.StartTime <= booking.StartTime && b.EndTime > booking.StartTime)        /* Any starting before or same time as booking &
                                                                                                    * ends after start time of booking. */
                         || (b.StartTime >= booking.StartTime && b.EndTime <= booking.EndTime)      /* Any starting after or same time as booking & 
                                                                                                    * ends after or same time as booking. */
                         || (b.StartTime <= booking.StartTime && b.EndTime >= booking.EndTime)      /* Any starting before or same time as booking &
                                                                                                    * ends same time or after booking. */
                         || (b.StartTime >= booking.StartTime && b.StartTime < booking.EndTime)))   /* Any starting after or same time as booking &
                                                                                                    * starting before end time of booking. */
                .ToList();
        }

        private static bool TimeInsideBooking(Booking booking, DateTime start, DateTime end)
        {
            return booking.StartTime <= start && booking.EndTime >= end && start < end;
        }
    }
}





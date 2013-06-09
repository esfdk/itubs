namespace BookITService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using BookITService.Enums;

    /// <summary>
    /// Booking entity (Entity Framework POCO class)
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
            this.CateringChoices = new List<CateringChoice>();
            this.EquipmentChoices = new List<EquipmentChoice>();
        }

        /// <summary>
        /// Gets all bookings in the database.
        /// </summary>
        private static IEnumerable<Booking> All
        {
            get
            {
                return BookITContext.Db.Bookings.Include("CateringChoices").Include("EquipmentChoices").Include("Room").Include("Person").ToList();
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

        public static IEnumerable<Booking> GetPendingBookings()
        {
            return All.Where(b => b.StartTime > DateTime.Now && b.Status.Equals("Pending"));
        }

        public static IEnumerable<Booking> GetBookingsByDate(DateTime date)
        {
            return All.Where(b => b.StartTime.Date.Equals(date.Date));
        }

        /// <summary>Creates a new booking in the database.</summary>
        /// <param name="booking">The booking to create.</param>
        /// <returns>The newly created booking object.</returns>
        public static Booking CreateNewBooking(Booking booking)
        {
            // Gets the room that the booking is for.
            var room = Room.GetRoomByID(booking.RoomID);

            // Checks if input is valid
            if (!IsBookingTimeValid(booking) || OverlappingBookings(booking).Any()
                || (booking.NumberOfParticipants > room.MaxParticipants)
                || !IsAStatus(booking.Status)
                || booking.PersonID <= 0
                || booking.RoomID <= 0)
            {
                return null;
            }

            // Adds a new booking object (with the input parameters) to the Bookings collection
            BookITContext.Db.Bookings.Add(
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

            // Saves the change to the database
            BookITContext.Db.SaveChanges();

            // Finds the booking that was just created (to make sure the object is fully updated).
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
                if (overlapping.Count > 0 && overlapping.All(b => b.PersonID == changedBooking.PersonID))
                {
                    var updatedBooking = overlapping.First();
                    updatedBooking.StartTime = changedBooking.StartTime;
                    updatedBooking.EndTime = changedBooking.EndTime;
                    foreach (var b in overlapping)
                    {
                        foreach (var ec in b.EquipmentChoices)
                        {
                            ec.BookingID = updatedBooking.ID;
                        }

                        foreach (var cc in b.CateringChoices)
                        {
                            cc.BookingID = updatedBooking.ID;
                        }
                    }

                    foreach (var b in overlapping.Where(b => b.ID != updatedBooking.ID))
                    {
                        BookITContext.Db.Bookings.Remove(b);
                    }

                    BookITContext.Db.SaveChanges();
                    return RequestStatus.Success;
                }

                if (overlapping.Count == 0)
                {
                    this.StartTime = changedBooking.StartTime;
                    this.EndTime = changedBooking.EndTime;

                    foreach (var ec in this.EquipmentChoices)
                    {
                        BookITContext.Db.EquipmentChoices.Remove(ec);
                    }

                    foreach (var cc in this.CateringChoices)
                    {
                        BookITContext.Db.CateringChoices.Remove(cc);
                    }

                    BookITContext.Db.SaveChanges();
                    return RequestStatus.Success;
                }

                return RequestStatus.InvalidInput;
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeStatus(Booking changedBooking)
        {
            if (!string.IsNullOrWhiteSpace(changedBooking.Status))
            {
                if (changedBooking.Status.Equals("Approved"))
                {
                    this.Status = "Approved";
                    BookITContext.Db.SaveChanges();
                    return RequestStatus.Success;
                }

                return changedBooking.Status.Equals("Rejected") ? this.Remove() : RequestStatus.InvalidInput;
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus Remove()
        {
            BookITContext.Db.Bookings.Remove(this);
            BookITContext.Db.SaveChanges();

            return RequestStatus.Success;
        }

        public RequestStatus AddCatering(CateringChoice choice)
        {
            if (choice.Time > this.StartTime && choice.Time < this.EndTime && Catering.IsAvailable(choice.CateringID, choice.Time) && choice.Amount >= 1)
            {
                if ((choice.Amount >= Configuration.CateringLimit && choice.Time.AddDays(-Configuration.DaysToPrepareBigCatering) < DateTime.Now)
                    || (choice.Time.AddDays(-Configuration.DaysToPrepareSmallCatering) < DateTime.Now))
                {
                    BookITContext.Db.CateringChoices.Add(
                        new CateringChoice
                            {
                                Amount = choice.Amount,
                                BookingID = this.ID,
                                Time = choice.Time,
                                Status = choice.Status,
                                CateringID = choice.CateringID,
                            });
                    BookITContext.Db.SaveChanges();
                    return RequestStatus.Success;
                }

                return RequestStatus.InvalidInput;
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus AddEquipment(EquipmentChoice choice)
        {
            var overlapping = EquipmentChoice.OverlappingBookings(choice);
            if (EquipmentChoice.IsBookingTimeValid(choice) && overlapping.Count == 0
                && choice.StartTime >= this.StartTime && choice.EndTime <= this.EndTime)
            {
                BookITContext.Db.EquipmentChoices.Add(
                    new EquipmentChoice
                        {
                            BookingID = choice.BookingID,
                            EndTime = choice.EndTime,
                            StartTime = choice.StartTime,
                            EquipmentID = choice.EquipmentID
                        });
                BookITContext.Db.SaveChanges();
                return RequestStatus.Success;
            }

            return RequestStatus.InvalidInput;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int NumberOfParticipants { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
        [DataMember]
        public int PersonID { get; set; }
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public virtual ICollection<CateringChoice> CateringChoices { get; set; }
        [DataMember]
        public virtual ICollection<EquipmentChoice> EquipmentChoices { get; set; }
        [DataMember]
        public virtual Person Person { get; set; }
        [DataMember]
        public virtual Room Room { get; set; }

        /// <summary>
        /// Checks if input string is not null, not empty and is either equal to "Accepted" or "Pending".
        /// </summary>
        /// <param name="status">The status to check.</param>
        /// <returns>True if input string is a status, false if not.</returns>
        private static bool IsAStatus(string status)
        {
            return !string.IsNullOrWhiteSpace(status) && (status.Equals("Accepted") || status.Equals("Pending"));
        }

        /// <summary>
        /// Checks if time of a booking is within acceptable time.
        /// </summary>
        /// <param name="booking">Booking to check.</param>
        /// <returns>True if time of booking is valid, false if not.</returns>
        private static bool IsBookingTimeValid(Booking booking)
        {
            return booking.StartTime < booking.EndTime
                   && booking.StartTime.Hour >= Configuration.EarliestBooking.Hour
                   && booking.EndTime.Hour <= Configuration.LatestBooking.Hour
                   && booking.StartTime.Date.Equals(booking.EndTime.Date);
        }

        /// <summary>
        /// Finds all the bookings that overlap with a specific booking.
        /// </summary>
        /// <param name="booking">The booking to check.</param>
        /// <returns>The list of bookings that over with input booking. If empty, no bookings overlap.</returns>
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
    }
}
namespace BookITService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using BookITService.Enums;

    [DataContract(IsReference = true)]
    [KnownType(typeof(Booking))]
    [KnownType(typeof(Equipment))]
    public class EquipmentChoice
    {
        public static IEnumerable<EquipmentChoice> All
        {
            get
            {
                return BookITContext.Db.EquipmentChoices.Include("Booking").Include("Equipment").ToList();
            }
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
        [DataMember]
        public int BookingID { get; set; }
        [DataMember]
        public int EquipmentID { get; set; }
        [DataMember]
        public virtual Booking Booking { get; set; }
        [DataMember]
        public virtual Equipment Equipment { get; set; }

        public static EquipmentChoice GetEquipmentChoiceByID(int id)
        {
            return All.FirstOrDefault(ec => ec.ID == id);
        }

        public RequestStatus Remove()
        {
            BookITContext.Db.EquipmentChoices.Remove(this);
            BookITContext.Db.SaveChanges();
            return RequestStatus.Success;
        }

        public RequestStatus ChangeTime(EquipmentChoice updatedChoice)
        {
            var overlapping = OverlappingBookings(updatedChoice);
            if (overlapping.All(ec => ec.BookingID == this.BookingID)
                && this.Booking.StartTime <= updatedChoice.StartTime
                && this.Booking.EndTime >= updatedChoice.EndTime)
            {
                if (overlapping.Count == 0
                    || (overlapping.Count == 1 && overlapping.First().ID == this.ID))
                {
                    this.StartTime = updatedChoice.StartTime;
                    this.EndTime = updatedChoice.EndTime;
                    BookITContext.Db.SaveChanges();
                    return RequestStatus.Success;
                }

                if (overlapping.All(choice => choice.Booking.PersonID == this.Booking.PersonID))
                {
                    var first = overlapping.First();
                    first.EndTime = updatedChoice.EndTime;
                    first.StartTime = updatedChoice.StartTime;
                    foreach (var a in overlapping.Where(o => o.ID != first.ID))
                    {
                        BookITContext.Db.EquipmentChoices.Remove(a);
                    }

                    BookITContext.Db.SaveChanges();
                }
            }

            return RequestStatus.InvalidInput;
        }

        public static bool IsBookingTimeValid(EquipmentChoice ec)
        {
            return ec.StartTime < ec.EndTime
                               && ec.StartTime.Hour >= Configuration.EarliestBooking.Hour
                               && ec.EndTime.Hour <= Configuration.LatestBooking.Hour
                               && ec.StartTime.Date.Equals(ec.EndTime.Date);
        }

        public static List<EquipmentChoice> OverlappingBookings(EquipmentChoice ec)
        {
            return
                All.Where(
                    e =>
                    e.EquipmentID == ec.EquipmentID
                    &&
                    ((e.StartTime <= ec.StartTime && e.EndTime > ec.StartTime)      /* Any starting before or same time as booking &
                                                                                     * ends after start time of booking. */
                     || (e.StartTime >= ec.StartTime && e.EndTime <= ec.EndTime)    /* Any starting after or same time as booking & 
                                                                                     * ends after or same time as booking. */
                     || (e.StartTime <= ec.StartTime && e.EndTime >= ec.EndTime)    /* Any starting before or same time as booking &
                                                                                     * ends same time or after booking. */
                     || (e.StartTime >= ec.StartTime && e.StartTime < ec.EndTime))) /* Any starting after or same time as booking &
                                                                                     * starting before end time of booking. */
                    .ToList();
        }
    }
}

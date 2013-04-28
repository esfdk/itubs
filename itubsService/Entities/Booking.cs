namespace ITubsService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

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

        public int ID { get; set; }
        public string Status { get; set; }
        public int NumberOfParticipants { get; set; }
        public string Comments { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int PersonID { get; set; }
        public int RoomID { get; set; }
        public virtual ICollection<CateringChoice> CateringChoices { get; set; }
        public virtual ICollection<EquipmentChoice> EquipmentChoices { get; set; }
        public virtual Person Person { get; set; }
        public virtual Room Room { get; set; }
    }
}

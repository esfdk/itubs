namespace ITubsService.Entities
{
    using System.Collections.Generic;

    public class Room
    {
        public Room()
        {
            this.Bookings = new List<Booking>();
            this.Inventories = new List<Inventory>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxParticipants { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}

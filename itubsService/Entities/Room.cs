namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Room
    {
        public Room()
        {
            this.Bookings = new List<Booking>();
            this.Inventories = new List<Inventory>();
        }

        public static IEnumerable<Room> All
        {
            get
            {
                return ItubsContext.Db.Rooms.Include("Bookings").Include("Inventories").ToList();
            }
        }

        public static Room GetRoomByID(int id)
        {
            return All.FirstOrDefault(r => r.ID == id);
        }

        public static Room AddInventory(Room r, int inventoryID)
        {
            if (r.Inventories.All(i => i.ID != inventoryID))
            {
                return null;
            }

            return r;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxParticipants { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}

namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Room
    {
        public Room()
        {
            Bookings = new List<Booking>();
            Inventories = new List<Inventory>();
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
            var room = All.FirstOrDefault(a => a.ID == r.ID);
            if (room != null && room.Inventories.All(i => i.ID != inventoryID))
            {
                var inventory = Inventory.All.FirstOrDefault(i => i.ID == inventoryID);
                if (inventory != null)
                {
                    room.Inventories.Add(inventory);
                    ItubsContext.Db.SaveChanges();
                }
                else
                {
                    return new Room{ID = -1};
                }
            }

            return r;
        }

        public static Room RemoveInventory(Room r, int inventoryId)
        {
            var room = All.FirstOrDefault(a => a.ID == r.ID);
            if (room != null)
            {
                var inventory = room.Inventories.FirstOrDefault(i => i.ID == inventoryId);

                if (inventory != null)
                {
                    inventory.RoomID = -1;
                    room.Inventories.Remove(inventory);
                    ItubsContext.Db.SaveChanges();
                }
                else
                {
                    return new Room { ID = -1 };
                }
            }

            return r;
        }

        public static Room AddRoom(Room newRoom)
        {
            if (newRoom.MaxParticipants > 0 && newRoom.Name.Length > 1)
            {
                ItubsContext.Db.Rooms.Add(new Room{})
            }
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxParticipants { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}

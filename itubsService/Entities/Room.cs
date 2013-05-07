namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using ITubsService.Enums;

    [DataContract(IsReference = true)]
    [KnownType(typeof(Booking))]
    [KnownType(typeof(Inventory))]
    public class Room
    {
        public Room()
        {
            Bookings = new List<Booking>();
            Inventories = new List<Inventory>();
        }

        /// <summary>
        /// Gets all the rooms from the database.
        /// </summary>
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

        public RequestStatus AddInventory(int inventoryID)
        {
            var inventory = Inventory.All.FirstOrDefault(i => i.ID == inventoryID);
            if (inventory != null && !this.Inventories.Contains(inventory))
            {
                this.Inventories.Add(inventory);
                ItubsContext.Db.SaveChanges();
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus RemoveInventory(int inventoryID)
        {
            var inventory = Inventory.All.FirstOrDefault(i => i.ID == inventoryID);
            if (inventory != null && inventory.RoomID == this.ID)
            {
                this.Inventories.Remove(inventory);
                ItubsContext.Db.SaveChanges();
                return RequestStatus.Success;
            }

            return RequestStatus.InvalidInput;
        }

        public static Room AddRoom(Room newRoom)
        {
            if (newRoom.MaxParticipants > 0 && newRoom.Name.Length > 1)
            {
                ItubsContext.Db.Rooms.Add(new Room { MaxParticipants = newRoom.MaxParticipants, Name = newRoom.Name });
                ItubsContext.Db.SaveChanges();
            }
            else
            {
                return null;
            }

            return
                All.FirstOrDefault(
                    r =>
                    r.MaxParticipants == newRoom.MaxParticipants && r.Name.Equals(newRoom.Name) && r.Bookings.Count == 0
                    && r.Inventories.Count == 0);
        }

        public void Remove()
        {
            ItubsContext.Db.Rooms.Remove(this);
            ItubsContext.Db.SaveChanges();
        }

        public RequestStatus Edit(Room updatedRoom)
        {
            if (updatedRoom == null)
            {
                return RequestStatus.InvalidInput;
            }

            this.MaxParticipants = updatedRoom.MaxParticipants >= 0 ? updatedRoom.MaxParticipants : this.MaxParticipants;
            this.Name = !string.IsNullOrWhiteSpace(updatedRoom.Name) ? updatedRoom.Name : this.Name;

            ItubsContext.Db.SaveChanges();

            return RequestStatus.Success;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int MaxParticipants { get; set; }
        [DataMember]
        public virtual ICollection<Booking> Bookings { get; set; }
        [DataMember]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}

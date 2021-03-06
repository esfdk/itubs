namespace BookITService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using BookITService.Enums;

    [DataContract(IsReference = true)]
    [KnownType(typeof(Room))]
    [KnownType(typeof(InventoryType))]
    public class Inventory
    {
        public static IEnumerable<Inventory> All
        {
            get { return BookITContext.Db.Inventories.Include("Room").Include("InventoryType").ToList(); }
        }

        public static Inventory GetInventoryByID(int id)
        {
            return All.FirstOrDefault(i => i.ID == id);
        }

        public static Inventory NewInventory(Inventory newInventory)
        {
            Inventory inventory = null;

            if (newInventory != null && Configuration.IsAStatus(newInventory.Status) && !string.IsNullOrWhiteSpace(newInventory.ProductName) && newInventory.InventoryTypeID >= 0)
            {
                inventory = new Inventory
                    {
                        ProductName = newInventory.ProductName,
                        Status = newInventory.Status,
                        InventoryTypeID = newInventory.InventoryTypeID,
                        InventoryType = InventoryType.All.FirstOrDefault(it => it.ID == newInventory.InventoryTypeID),
                        RoomID = null
                    };
                BookITContext.Db.Inventories.Add(inventory);
                BookITContext.Db.SaveChanges();
            }

            return inventory;
        }

        public RequestStatus Edit(Inventory updatedInventory)
        {
            if (updatedInventory == null)
            {
                return RequestStatus.InvalidInput;
            }

            this.ProductName = !string.IsNullOrWhiteSpace(updatedInventory.ProductName)
                                   ? updatedInventory.ProductName
                                   : this.ProductName;
            this.Status = Configuration.IsAStatus(updatedInventory.Status)
                              ? updatedInventory.Status
                              : this.Status;
            this.InventoryTypeID = updatedInventory.InventoryTypeID > 0
                                       ? updatedInventory.InventoryTypeID
                                       : this.InventoryTypeID;
            this.RoomID = updatedInventory.RoomID >= 0
                              ? updatedInventory.RoomID
                              : this.RoomID;

            BookITContext.Db.SaveChanges();

            return RequestStatus.Success;

        }

        public void Remove()
        {
            BookITContext.Db.Inventories.Remove(this);
            BookITContext.Db.SaveChanges();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int InventoryTypeID { get; set; }
        [DataMember]
        public Nullable<int> RoomID { get; set; }
        [DataMember]
        public virtual InventoryType InventoryType { get; set; }
        [DataMember]
        public virtual Room Room { get; set; }
    }
}
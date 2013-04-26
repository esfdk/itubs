using System;

namespace ITubsService.Entities
{
    using System.Collections.Generic;

    public class Inventory
    {
        public static IEnumerable<Inventory> All
        {
            get { return ItubsContext.Db.Inventories.ToList(); }
        }

        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public int InventoryTypeID { get; set; }
        public Nullable<int> RoomID { get; set; }
        public virtual InventoryType InventoryType { get; set; }
        public virtual Room Room { get; set; }}
    }
}

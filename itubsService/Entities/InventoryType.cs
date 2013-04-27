namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class InventoryType
    {
        public InventoryType()
        {
            Inventories = new List<Inventory>();
        }

        public static IEnumerable<InventoryType> All
        {
            get
            {
                return ItubsContext.Db.InventoryTypes.Include("Inventories").ToList();
            }
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}

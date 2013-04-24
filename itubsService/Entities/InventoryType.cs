namespace ITubsService.Entities
{
    using System.Collections.Generic;

    public partial class InventoryType
    {
        public InventoryType()
        {
            this.Inventories = new List<Inventory>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}

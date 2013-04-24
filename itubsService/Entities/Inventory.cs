namespace ITubsService.Entities
{

    public partial class Inventory
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public int RoomID { get; set; }
        public int InventoryTypeID { get; set; }
        public virtual InventoryType InventoryType { get; set; }
        public virtual Room Room { get; set; }
    }
}

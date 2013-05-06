namespace Client.Model
{
    using Client.BookItService;

    public class ServiceClients
    {
        public static readonly CateringManagementClient CateringManager = new CateringManagementClient();
        public static readonly BookingManagementClient BookingManager = new BookingManagementClient();
        public static readonly PersonManagementClient PersonManager = new PersonManagementClient();
        public static readonly EquipmentManagementClient EquipmentManager = new EquipmentManagementClient();
        public static readonly InventoryManagementClient InventoryManager = new InventoryManagementClient();
        public static readonly RoomManagementClient RoomManager = new RoomManagementClient();
    }
}
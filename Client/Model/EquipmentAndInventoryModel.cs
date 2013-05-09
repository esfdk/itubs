namespace Client.Model
{
    using System.Collections.Generic;

    using Client.BookItService;

    public static class EquipmentAndInventoryModel
    {
        public static IEnumerable<Equipment> GetAllEquipment(string type)
        {
            Equipment[] equipments;
            return ServiceClients.EquipmentManager.GetAllEquipment(out equipments, type) == RequestStatus.Success ? equipments : null;
        }

        public static IEnumerable<EquipmentType> GetEquipmentTypes()
        {
            EquipmentType[] eTypes;
            return ServiceClients.EquipmentManager.GetEquipmentTypes(out eTypes) == RequestStatus.Success ? eTypes : null;
        }

        public static IEnumerable<Inventory> GetAllInventory(string type, bool includeAssigned)
        {
            Inventory[] inventories;
            return ServiceClients.InventoryManager.GetAllInventory(out inventories, type, includeAssigned) == RequestStatus.Success ? inventories : null;
        }
    }
}

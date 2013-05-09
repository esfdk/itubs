namespace Client.Model.Types
{
    using System.Collections.Generic;

    using Client.BookItService;

    public static class EquipmentModel
    {
        public static IEnumerable<Equipment> GetAllEquipment(string type)
        {
            Equipment[] equipments;
            return ServiceClients.EquipmentManager.GetAllEquipment(out equipments, type) == RequestStatus.Success ? equipments : null;
        }
    }
}
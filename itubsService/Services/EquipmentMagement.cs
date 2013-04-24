using ITubsService.Entities;

namespace ITubsService.Services
{
    using System.Collections.Generic;
    using Enums;
    using Interfaces;

    public partial class Service : IEquipmentManagement
    {
        public RequestStatus CreateNewEquipmentItem(string token, ref Equipment newEquipment)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus ChangeEquipmentItem(string token, ref Equipment equipment)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus DeleteEquipmentItem(string token, int equipmentId)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetEquipmentChoice(ref EquipmentChoice equipmentChoice)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetEquipmentItem(ref Equipment equipmentItem)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetEquipmentTypes(out IEnumerable<string> types)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetAllEquipmentItems(string type, IEnumerable<Equipment> items)
        {
            throw new System.NotImplementedException();
        }
    }
}
namespace ITubsService.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using ITubsService.Entities;
    using ITubsService.Enums;
    using ITubsService.Interfaces;

    public partial class Service : IEquipmentManagement
    {
        public RequestStatus CreateNewEquipmentItem(string token, ref Equipment newEquipment)
        {
            newEquipment = Equipment.NewEquipment(newEquipment);
            return newEquipment != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeEquipmentItem(string token, ref Equipment equipment)
        {
            var id = equipment.ID;
            var eq = Equipment.All.FirstOrDefault(e => e.ID == id);
            if (eq != null)
            {
                var rs = eq.Edit(equipment);
                equipment = eq;
                return rs;
            }
            return RequestStatus.InvalidInput;
        }

        public RequestStatus DeleteEquipmentItem(string token, Equipment equipment)
        {
            equipment = Equipment.All.FirstOrDefault(r => r.ID == equipment.ID);
            if (equipment != null)
            {
                equipment.Remove();
                return RequestStatus.Success;
            }

            return RequestStatus.InvalidInput;

        }

        public RequestStatus GetEquipmentChoice(ref EquipmentChoice equipmentChoice)
        {
            equipmentChoice = EquipmentChoice.GetEquipmentChoiceByID(equipmentChoice.ID);

            return equipmentChoice != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetEquipmentItem(ref Equipment equipmentItem)
        {
            equipmentItem = Equipment.GetEquipmentByID(equipmentItem.ID);
            return equipmentItem != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetEquipmentTypes(out IEnumerable<EquipmentType> types)
        {
            types = EquipmentType.All;

            return types != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus GetAllEquipmentItems(string type, IEnumerable<Equipment> items)
        {
            items = string.IsNullOrWhiteSpace(type) ? Equipment.All.Where(e => e.EquipmentType.Type.Equals(type)) : Equipment.All;

            return items != null ? RequestStatus.Success : RequestStatus.Error;
        }
    }
}
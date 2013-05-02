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
            if (string.IsNullOrWhiteSpace(token) || newEquipment == null || string.IsNullOrWhiteSpace(newEquipment.ProductName) || newEquipment.EquipmentTypeID <= 0)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (p == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (!p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)))
            {
                return RequestStatus.AccessDenied;
            }

            newEquipment = Equipment.NewEquipment(newEquipment);
            return newEquipment != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeEquipmentItem(string token, ref Equipment equipment)
        {
            if (string.IsNullOrWhiteSpace(token) || equipment == null || equipment.ID <= 0)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var eq = Equipment.GetEquipmentByID(equipment.ID);
            if (p == null || eq == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (!p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)))
            {
                return RequestStatus.AccessDenied;
            }

            var rs = eq.Edit(equipment);
            equipment = eq;
            return rs;
        }

        public RequestStatus DeleteEquipmentItem(string token, Equipment equipment)
        {
            if (string.IsNullOrWhiteSpace(token) || equipment == null || equipment.ID <= 0)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var eq = Equipment.GetEquipmentByID(equipment.ID);
            if (p == null || eq == null)
            {
                return RequestStatus.InvalidInput;
            }

            return p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)) ? equipment.Remove() : RequestStatus.AccessDenied;
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
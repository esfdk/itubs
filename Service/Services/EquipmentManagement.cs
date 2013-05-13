namespace BookITService.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using BookITService.Entities;
    using BookITService.Enums;
    using BookITService.Interfaces;


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

            if (!p.IsAdmin())
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

            if (!p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            var rs = eq.Edit(equipment);
            equipment = eq;
            return rs;
        }

        public RequestStatus DeleteEquipment(string token, Equipment equipment)
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

            return p.IsAdmin() ? equipment.Remove() : RequestStatus.AccessDenied;
        }

        public RequestStatus GetEquipmentChoice(ref EquipmentChoice equipmentChoice)
        {
            if (equipmentChoice == null)
            {
                return RequestStatus.InvalidInput;
            }

            equipmentChoice = EquipmentChoice.GetEquipmentChoiceByID(equipmentChoice.ID);

            return equipmentChoice != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetEquipment(ref Equipment equipment)
        {
            if (equipment == null)
            {
                return RequestStatus.InvalidInput;
            }

            equipment = Equipment.GetEquipmentByID(equipment.ID);
            return equipment != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetEquipmentTypes(out IEnumerable<EquipmentType> types)
        {
            types = EquipmentType.All;

            return types != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus GetAllEquipment(string type, out IEnumerable<Equipment> items)
        {
            items = !string.IsNullOrWhiteSpace(type) ? Equipment.All.Where(e => e.EquipmentType.Type.Equals(type)) : Equipment.All;

            return items != null ? RequestStatus.Success : RequestStatus.Error;
        }
    }
}
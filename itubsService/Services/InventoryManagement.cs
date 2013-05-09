namespace ITubsService.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Enums;
    using Interfaces;
    using ITubsService.Entities;

    public partial class Service : IInventoryManagement
    {
        public RequestStatus CreateNewInventory(string token, ref Inventory newInventory)
        {
            if (string.IsNullOrWhiteSpace(token) || newInventory == null || string.IsNullOrWhiteSpace(newInventory.ProductName)
                || newInventory.InventoryTypeID < 1 || string.IsNullOrWhiteSpace(newInventory.Status))
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (p == null || !p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            newInventory = Inventory.NewInventory(newInventory);
            return newInventory != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeInventory(string token, ref Inventory inventory)
        {
            if (string.IsNullOrWhiteSpace(token) || inventory == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (p == null || !p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            var inv = Inventory.GetInventoryByID(inventory.ID);
            if (inv == null)
            {
                return RequestStatus.InvalidInput;
            }

            var rs = inventory.Edit(inventory);
            inventory = inv;
            return rs;
        }

        public RequestStatus DeleteInventory(string token, Inventory inventory)
        {
            if (string.IsNullOrWhiteSpace(token) || inventory == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (p == null || !p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            inventory = Inventory.GetInventoryByID(inventory.ID);
            if (inventory == null)
            {
                return RequestStatus.InvalidInput;
            }

            inventory.Remove();
            return RequestStatus.Success;
        }

        public RequestStatus GetInventoryByID(ref Inventory inventory)
        {
            if (inventory == null)
            {
                return RequestStatus.InvalidInput;
            }

            inventory = Inventory.GetInventoryByID(inventory.ID);
            return inventory != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetInventoryTypes(out IEnumerable<InventoryType> types)
        {
            types = InventoryType.All;

            return types != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus GetAllInventory(string type, bool includeAssigned, out IEnumerable<Inventory> items)
        {
            if (!string.IsNullOrWhiteSpace(type))
            {
                items = includeAssigned ?
                    Inventory.All.Where(i => i.InventoryType.Type.Equals(type)) :
                    Inventory.All.Where(i => i.InventoryType.Type.Equals(type) && i.RoomID == null);
            }
            else
            {
                items = includeAssigned ? Inventory.All : Inventory.All.Where(i => i.RoomID == null);
            }

            return items != null ? RequestStatus.Success : RequestStatus.Error;
        }
    }
}
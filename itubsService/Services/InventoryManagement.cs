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
            newInventory = Inventory.NewInventory(newInventory);

            return newInventory != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeInventory(string token, ref Inventory inventory)
        {
            return inventory.Edit(inventory);
        }

        public RequestStatus DeleteInventory(string token, Inventory inventory)
        {
            inventory.Remove();
            return RequestStatus.Success;
        }

        public RequestStatus GetInventoryByID(ref Inventory item)
        {
            item = Inventory.GetInventoryByID(item.ID);
            return item != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetInventoryTypes(out IEnumerable<InventoryType> types)
        {
            types = InventoryType.All;

            return types != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus GetInventoryItems(string type, bool includeAssigned, out IEnumerable<Inventory> items)
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
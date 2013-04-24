namespace ITubsService.Services
{
    using System.Collections.Generic;
    using Enums;
    using Interfaces;
    using ITubsService.Entities;

    public partial class Service : IInventoryManagement
    {
        public RequestStatus CreateNewInventoryItem(string token, ref Inventory newInventory)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus ChangeInventoryItem(string token, ref Inventory inventory)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus DeleteInventoryItem(string token, int inventoryId)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetInventoryItem(ref Inventory item)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetInventoryTypes(out IEnumerable<string> types)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetAllInventoryItems(string type, bool includeAssigned, out IEnumerable<Inventory> items)
        {
            throw new System.NotImplementedException();
        }
    }
}
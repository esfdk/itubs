namespace ITubsService.Interfaces
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Enums;

    using ITubsService.Entities;


    [ServiceContract]
    interface IInventoryManagement
    {
        [OperationContract]
        RequestStatus CreateNewInventoryItem(string token, ref Inventory newInventory);

        [OperationContract]
        RequestStatus ChangeInventoryItem(string token, ref Inventory inventory);

        [OperationContract]
        RequestStatus DeleteInventoryItem(string token, int inventoryId);

        [OperationContract]
        RequestStatus GetInventoryItem(ref Inventory item);

        [OperationContract]
        RequestStatus GetInventoryTypes(out IEnumerable<string> types);

        [OperationContract]
        RequestStatus GetAllInventoryItems(string type, bool includeAssigned, out IEnumerable<Inventory> items);
    }
}

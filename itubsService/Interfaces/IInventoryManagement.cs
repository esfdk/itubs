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
        RequestStatus CreateNewInventory(string token, ref Inventory newInventory);

        [OperationContract]
        RequestStatus ChangeInventory(string token, ref Inventory inventory);

        [OperationContract]
        RequestStatus DeleteInventory(string token, Inventory inventory);

        [OperationContract]
        RequestStatus GetInventoryByID(ref Inventory inventory);

        [OperationContract]
        RequestStatus GetInventoryTypes(out IEnumerable<InventoryType> types);

        [OperationContract]
        RequestStatus GetAllInventory(string type, bool includeAssigned, out IEnumerable<Inventory> items);
    }
}

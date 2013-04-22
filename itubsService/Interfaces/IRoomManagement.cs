namespace ITubsService.Interfaces
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Enums;

    using ITubsService.Entities;


    [ServiceContract]
    interface IRoomManagement
    {
        [OperationContract]
        RequestStatus AddRoom(string token, ref Room newRoom);

        [OperationContract]
        RequestStatus EditRoom(string token, ref Room editedRoom);

        [OperationContract]
        RequestStatus RemoveRoom(string token, int roomId);

        [OperationContract]
        RequestStatus GetRoom(string token, ref Room room);

        [OperationContract]
        RequestStatus GetAllRooms(out IEnumerable<Room> rooms);

        [OperationContract]
        RequestStatus AddInventoryItemToRoom(string token, int inventoryId, int roomId);

        [OperationContract]
        RequestStatus RemoveInventoryItemFromRoom(string token, int inventoryId);
    }
}

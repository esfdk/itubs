namespace ITubsService.Services
{
    using System.Collections.Generic;
    using Enums;
    using Interfaces;
    using ITubsService.Entities;

    public partial class Service : IRoomManagement
    {
        public RequestStatus AddRoom(string token, ref Room newRoom)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus EditRoom(string token, ref Room editedRoom)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus RemoveRoom(string token, int roomId)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetRoom(string token, ref Room room)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetAllRooms(out IEnumerable<Room> rooms)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus AddInventoryItemToRoom(string token, int inventoryId, int roomId)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus RemoveInventoryItemFromRoom(string token, int inventoryId)
        {
            throw new System.NotImplementedException();
        }
    }

}
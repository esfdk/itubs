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

        public RequestStatus GetRoom(ref Room room)
        {
            room = Room.GetRoomByID(room.ID);

            if (room != null)
            {
                return RequestStatus.Success;
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus GetAllRooms(out IEnumerable<Room> rooms)
        {
            rooms = Room.All;
            return RequestStatus.Success;
        }

        public RequestStatus AddInventoryItemToRoom(string token, int inventoryId, ref Room updatedRoom)
        {
            updatedRoom = Room.AddInventory(updatedRoom, inventoryId);

            if (updatedRoom != null)
            {
                return RequestStatus.Success;
            }
            return RequestStatus.AccessDenied;
        }

        public RequestStatus RemoveInventoryItemFromRoom(string token, int inventoryId, ref Room updatedRoom)
        {
            throw new System.NotImplementedException();
        }
    }

}
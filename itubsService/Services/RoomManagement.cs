namespace ITubsService.Services
{
    using System.Collections.Generic;
    using Entities;
    using Enums;
    using Interfaces;

    public partial class Service : IRoomManagement
    {
        public RequestStatus AddRoom(string token, ref Room newRoom)
        {
            newRoom = Room.AddRoom(newRoom);
            return newRoom != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus EditRoom(string token, ref Room editedRoom)
        {
            editedRoom = Room.Edit(editedRoom);

            return editedRoom != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus RemoveRoom(string token, int roomId)
        {
            return Room.RemoveRoom(roomId);
        }

        public RequestStatus GetRoom(ref Room room)
        {
            room = Room.GetRoomByID(room.ID);

            return room != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetAllRooms(out IEnumerable<Room> rooms)
        {
            rooms = Room.All;
            return rooms != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus AddInventoryItemToRoom(string token, int inventoryId, ref Room updatedRoom)
        {
            updatedRoom = Room.AddInventory(updatedRoom, inventoryId);

            if (updatedRoom != null && updatedRoom.ID != -1)
            {
                return RequestStatus.Success;
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus RemoveInventoryItemFromRoom(string token, int inventoryId, ref Room updatedRoom)
        {
            updatedRoom = Room.RemoveInventory(updatedRoom, inventoryId);

            if (updatedRoom != null && updatedRoom.ID != -1)
            {
                return RequestStatus.Success;
            }

            return RequestStatus.InvalidInput;
        }
    }

}
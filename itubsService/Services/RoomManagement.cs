namespace ITubsService.Services
{
    using System.Collections.Generic;
    using System.Linq;

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
            var id = editedRoom.ID;
            var room = Room.All.FirstOrDefault(r => r.ID == id);
            if (room != null)
            {
                var rs = room.Edit(editedRoom);
                editedRoom = room;
                return rs;
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus RemoveRoom(string token, Room room)
        {
            room = Room.All.FirstOrDefault(r => r.ID == room.ID);
            if (room != null)
            {
                room.Remove();
                return RequestStatus.Success;
            }

            return RequestStatus.InvalidInput;
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
            var id = updatedRoom.ID;
            updatedRoom = Room.All.FirstOrDefault(r => r.ID == id);
            return updatedRoom != null ? updatedRoom.AddInventory(inventoryId) : RequestStatus.InvalidInput;
        }

        public RequestStatus RemoveInventoryItemFromRoom(string token, int inventoryId, ref Room updatedRoom)
        {
            var id = updatedRoom.ID;
            updatedRoom = Room.All.FirstOrDefault(r => r.ID == id);
            return updatedRoom != null ? updatedRoom.RemoveInventory(inventoryId) : RequestStatus.InvalidInput;
        }
    }

}
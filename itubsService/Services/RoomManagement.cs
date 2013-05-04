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
            if (string.IsNullOrWhiteSpace(token) || newRoom == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (!p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            newRoom = Room.AddRoom(newRoom);
            return newRoom != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus EditRoom(string token, ref Room editedRoom)
        {
            if (string.IsNullOrWhiteSpace(token) || editedRoom == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (!p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            var room = Room.GetRoomByID(editedRoom.ID);
            if (room == null)
            {
                return RequestStatus.InvalidInput;
            }

            var rs = room.Edit(editedRoom);
            editedRoom = room;
            return rs;
        }

        public RequestStatus RemoveRoom(string token, Room room)
        {
            if (string.IsNullOrWhiteSpace(token) || room == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (!p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            room = Room.GetRoomByID(room.ID);
            if (room == null)
            {
                return RequestStatus.InvalidInput;
            }

            room.Remove();
            return RequestStatus.Success;
        }

        public RequestStatus GetRoom(ref Room room)
        {
            if (room == null)
            {
                return RequestStatus.InvalidInput;
            }

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
            if (string.IsNullOrWhiteSpace(token) || updatedRoom == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (!p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            updatedRoom = Room.GetRoomByID(updatedRoom.ID);
            return updatedRoom != null ? updatedRoom.AddInventory(inventoryId) : RequestStatus.InvalidInput;
        }

        public RequestStatus RemoveInventoryItemFromRoom(string token, int inventoryId, ref Room updatedRoom)
        {
            if (string.IsNullOrWhiteSpace(token) || updatedRoom == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (!p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            updatedRoom = Room.GetRoomByID(updatedRoom.ID);
            return updatedRoom != null ? updatedRoom.RemoveInventory(inventoryId) : RequestStatus.InvalidInput;
        }
    }

}
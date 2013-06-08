namespace Client.Model
{
    using Client.BookItService;
    using Client.Types;

    public static class RoomModel
    {
        public static Room[] GetRooms()
        {
            Room[] rooms;
            return ServiceClients.RoomManager.GetAllRooms(out rooms) == RequestStatus.Success ? rooms : null;
        }

        public static Room GetRoomByID(int roomID)
        {
            Room r = new Room { ID = roomID };
            return ServiceClients.RoomManager.GetRoom(ref r) == RequestStatus.Success ? r : null;
        }

        public static RequestResult AddRoom(Room r)
        {
            RequestStatus rs;
            rs = ServiceClients.RoomManager.AddRoom(PersonModel.loggedInUser.Token, ref r);

            switch (rs)
            {
                case RequestStatus.Success:
                    return RequestResult.Success;
                case RequestStatus.AccessDenied:
                    return RequestResult.AccessDenied;
                case RequestStatus.Error:
                    return RequestResult.Error;
                case RequestStatus.InvalidInput:
                    return RequestResult.InvalidInput;
                default:
                    return RequestResult.Error;
            }
        }

        public static bool DeleteRoom(Room r)
        {
            return ServiceClients.RoomManager.RemoveRoom(PersonModel.loggedInUser.Token, r) == RequestStatus.Success;
        }
    }
}
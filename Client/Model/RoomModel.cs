namespace Client.Model
{
    using Client.BookItService;

    public static class RoomModel
    {
        public static Room[] GetRooms()
        {
            Room[] rooms;
            return ServiceClients.RoomManager.GetAllRooms(out rooms) == RequestStatus.Success ? rooms : null;
        }

        public static bool DeleteRoom(Room r)
        {
            return ServiceClients.RoomManager.RemoveRoom(PersonModel.loggedInUser.Token, r) == RequestStatus.Success;
        }
    }
}
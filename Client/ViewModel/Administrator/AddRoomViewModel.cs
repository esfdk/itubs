namespace Client.ViewModel.Administrator
{
    using Client.BookItService;
    using Client.Model;
    using Client.Types;

    public static class AddRoomViewModel
    {
        public static RequestResult AddRoom(string name, int capacity)
        {
            if (MasterViewModel.LoggedInUserIsAdmin())
            {
                var r = new Room { MaxParticipants = capacity, Name = name };
                return RoomModel.AddRoom(r);
            }

            return RequestResult.AccessDenied;
        }
    }
}
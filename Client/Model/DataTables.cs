namespace Client.Model
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;

    public static class DataTables
    {
        private static List<CateringChoice> cateringChoicesList;

        private static List<Catering> cateringList;

        private static List<Room> roomList;

        private static List<Room> superRoomList;

        private static List<Booking> yourBookingList;

        private static List<Booking> superBookingList;

        private static List<Booking> personBookingList;

        private static List<Booking> bookingList;

        private static List<Equipment> equipmentList;

        private static List<Inventory> inventoryList;

        public static DataTable GetCaterings(int bookingID)
        {
            var dt = new DataTable();

            cateringChoicesList = BookingModel.GetBooking(bookingID).CateringChoices.ToList();
            cateringList = CateringModel.GetAllCaterings().ToList();

            for (var i = 0; i < (cateringList.Count + cateringChoicesList.Count); i++)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static void UpdateCateringGrid(GridView gv)
        {

        }

        public static void UpdateInventoryGrid(GridView gv)
        {

        }

        public static void UpdateRoomGrid(GridView gv)
        {

        }

        public static void UpdateSuperRoomGrid(GridView gv)
        {

        }
    }
}
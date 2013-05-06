namespace Client.Model
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;

    public static class DataTables
    {
        static List<CateringChoice> ccList;

        public static DataTable GetCaterings(int bookingID)
        {
            var dt = new DataTable();

            ccList = BookingModel.GetBooking(bookingID).CateringChoices.ToList();

            var bookedCaterings = ccList.Count;
            var numberOfCaterings = CateringModel.;
            
            for (var i = 0; i < (numberOfCaterings + bookedCaterings); i++)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static void UpdateCateringGrid(GridView gv)
        {

        }

        public static void FillSuperRoomList(GridView gv)
        {

        }
    }
}

namespace Client.ViewModel.User
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;
    using Client.Types;

    public static class YourBookingsViewModel
    {

        private static List<Booking> yourBookingList;

        public static DataTable GetYourBookings()
        {
            var dt = new DataTable();
            yourBookingList = BookingModel.GetYourBookings().ToList();

            if (yourBookingList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var b in yourBookingList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static void UpdateYourBookingsGrid(GridView gv)
        {
            if (yourBookingList.Count == 0)
            {
                return;
            }

            if (yourBookingList.Count != gv.Rows.Count)
            {
                return;
            }

            for (var i = 0; i < yourBookingList.Count; i++)
            {
                var b = yourBookingList[i];
                gv.Rows[i].Cells[0].Text = b.Room.Name;
                gv.Rows[i].Cells[1].Text = b.NumberOfParticipants.ToString();
                gv.Rows[i].Cells[2].Text = b.StartTime.Date.ToShortDateString() + " " + b.StartTime.Hour + "-" + b.EndTime.Hour;
                gv.Rows[i].Cells[3].Text = b.Status;
            }
        }

        public static int GetBookingIDFromRow(int rowID)
        {
            if (rowID > 0 && rowID < yourBookingList.Count)
            {
                return yourBookingList[rowID].ID;
            }

            return -1;
        }

        public static bool DeleteBooking(int bookingID)
        {
            switch (BookingModel.DeleteBooking(bookingID))
            {
                case RequestResult.Success:
                    return true;
                default:
                    return false;
            }
        }
    }
}

namespace Client.ViewModel.Administrator
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;

    public static class BookingListViewModel
    {
        private static List<Booking> pendingBookingList;

        public static DataTable GetPendingBookings()
        {
            var dt = new DataTable();

            pendingBookingList = BookingModel.GetPendingBookings().ToList();

            // Use empty data table to fill grid if no elements exist
            if (pendingBookingList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var b in pendingBookingList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static void UpdatePendingGrid(GridView gv)
        {
            if (pendingBookingList.Count == 0)
            {
                return;
            }

            if (gv.Rows.Count != pendingBookingList.Count)
            {
                return;
            }

            for (var i = 0; i < pendingBookingList.Count; i++)
            {
                var b = pendingBookingList[i];
                gv.Rows[i].Cells[0].Text = b.Room.Name;
                gv.Rows[i].Cells[1].Text = b.Room.MaxParticipants.ToString();
                gv.Rows[i].Cells[2].Text = b.Person.Email;
                gv.Rows[i].Cells[3].Text = b.StartTime.Date.ToString();
                gv.Rows[i].Cells[4].Text = b.NumberOfParticipants.ToString();
            }
        }
    }
}
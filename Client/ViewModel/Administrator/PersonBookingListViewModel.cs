
namespace Client.ViewModel.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;
    using Client.Types;

    public static class PersonBookingListViewModel
    {
        private static List<Booking> pendingBookingList;

        public static DataTable GetUserPendingBookings(int bookingID)
        {
            var dt = new DataTable();

            pendingBookingList = new List<Booking>();

            pendingBookingList = BookingModel.GetPersonBookings(bookingID).Where(b => b.EndTime > DateTime.Now).OrderByDescending(b => b.StartTime).ToList();

            if (pendingBookingList.Count < 1)
            {
                dt.Rows.Add(dt.NewRow());
                return dt;
            }

            foreach (var b in pendingBookingList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static DataTable GetAllPendingBookings()
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

        public static void UpdatePendingBookingsGrid(GridView gv)
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
                gv.Rows[i].Cells[3].Text = b.StartTime.Date.ToShortDateString() + " " + b.StartTime.Hour + "-" + b.EndTime.Hour;
                gv.Rows[i].Cells[4].Text = b.NumberOfParticipants.ToString();
                gv.Rows[i].Cells[5].Text = b.Status;
            }
        }

        public static Person GetPersonByMail(string mail)
        {
            return PersonModel.GetPersonByMail(mail);
        }

        public static RequestResult ApproveBooking(int gridID)
        {
            var b = pendingBookingList[gridID];
            b.Status = "Approved";
            return BookingModel.ChangeStatus(b);
        }

        public static RequestResult RejectBooking(int gridID)
        {
            var b = pendingBookingList[gridID];
            b.Status = "Rejected";
            return BookingModel.ChangeStatus(b);
        }
    }
}
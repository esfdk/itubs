
namespace Client.ViewModel.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;

    public static class PersonBookingListViewModel
    {
        private static List<Booking> findBookingList;

        public static DataTable GetFindBookings(int bookingID)
        {
            var dt = new DataTable();

            findBookingList = new List<Booking>();

            if (bookingID < 1)
            {
                dt.Rows.Add(dt.NewRow());
                return dt;
            }

            findBookingList = BookingModel.GetPersonBookings(bookingID).Where(b => b.EndTime > DateTime.Now).ToList();

            foreach (var b in findBookingList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static void UpdateFindBookingsGrid(GridView gv)
        {
            if (findBookingList.Count == 0)
            {
                return;
            }

            if (gv.Rows.Count != findBookingList.Count)
            {
                return;
            }

            for (var i = 0; i < findBookingList.Count; i++)
            {
                var b = findBookingList[i];
                gv.Rows[i].Cells[0].Text = b.Room.Name;
                gv.Rows[i].Cells[1].Text = b.Room.MaxParticipants.ToString();
                gv.Rows[i].Cells[2].Text = b.Person.Email;
                gv.Rows[i].Cells[3].Text = b.StartTime.Date + " " + b.StartTime.Hour.ToString() + "-" + b.EndTime.Hour;
                gv.Rows[i].Cells[4].Text = b.NumberOfParticipants.ToString();
            }
        }

        public static Person GetPersonByMail(string mail)
        {
            return PersonModel.GetPersonByMail(mail);
        }
    }
}
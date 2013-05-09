namespace Client.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;

    public static class RoomListViewModel
    {
        private static List<Room> roomList;

        public static DataTable GetBookRooms()
        {
            var dt = new DataTable();

            roomList = RoomModel.GetRooms().ToList();

            if (roomList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                return dt;
            }

            foreach (var r in roomList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static void UpdateRoomGrid(GridView gv, DateTime date)
        {
            if (roomList == null || roomList.Count == 0 || gv.Rows.Count != roomList.Count)
            {
                return;
            }

            for (var i = 0; i < roomList.Count; i++)
            {
                var r = roomList[i];
                var row = gv.Rows[i];

                row.Cells[0].Text = r.Name;
                row.Cells[1].Text = r.MaxParticipants.ToString();

                var s = string.Empty;
                int j;
                for (j = 0; j < r.Inventories.Count() - 1; j++)
                {
                    s += r.Inventories[j].ProductName + ", ";
                }

                if (r.Inventories.Count() != 0)
                {
                    s += r.Inventories[0].ProductName;
                }

                row.Cells[2].Text = s;

                foreach (var booking in r.Bookings.Where(b => b.StartTime.Date == date.Date))
                {
                    for (var h = booking.StartTime.Hour; h < booking.EndTime.Hour; h++)
                    {
                        var cb = row.FindControl("CheckBox" + h) as CheckBox;
                        if (cb != null)
                        {
                            var tc = cb.Parent as TableCell;
                            if (tc != null)
                            {
                                if (PersonModel.loggedInUser != null && booking.PersonID == PersonModel.loggedInUser.ID)
                                {
                                    tc.BackColor = Color.Blue;
                                    cb.Checked = true;
                                }
                                else
                                {
                                    tc.BackColor = Color.Red;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static bool RowChanged(GridViewRow gvr)
        {
            for (var i = 3; i < gvr.Cells.Count; i++)
            {
                var cb = gvr.FindControl("CheckBox" + (i + 6)) as CheckBox;
                if (cb == null)
                {
                    continue;
                }

                if (gvr.Cells[i].BackColor == Color.Blue && !cb.Checked)
                {
                    return true;
                }

                if (cb.Checked)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CreateAndUpdateBookings(GridViewRow gvr, int rowID, DateTime date, out bool BookingWasUpdated)
        {
            BookingWasUpdated = false;
            for (var i = 3; i < gvr.Cells.Count; i++)
            {
                var cb = gvr.FindControl("CheckBox" + (i + 6)) as CheckBox;
                if (cb != null)
                {
                    if (cb.Checked && gvr.Cells[i].BackColor == Color.Red)
                    {
                        return false;
                        //roomList[rowID].Bookings.Any(b => b.StartTime.Date == date.Date &&)
                    }
                }
            }
        }
    }
}
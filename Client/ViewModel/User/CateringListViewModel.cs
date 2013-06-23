
namespace Client.ViewModel.User
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;
    using Client.Types;

    public static class CateringListViewModel
    {
        private static List<CateringChoice> cateringChoicesList;

        private static List<Catering> cateringList;

        private static Booking booking;

        public static DataTable GetCaterings(int bookingID)
        {
            var dt = new DataTable();

            booking = BookingModel.GetBooking(bookingID);

            cateringChoicesList = booking.CateringChoices.ToList();
            cateringList = CateringModel.GetAllCaterings().ToList();

            // Use empty data table to fill grid if no elements exist
            if (cateringChoicesList.Count + cateringList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }

            for (var i = 0; i < (cateringList.Count + cateringChoicesList.Count); i++)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static void UpdateCateringGrid(GridView gv, int bookingID)
        {
            if (cateringList.Count + cateringChoicesList.Count == 0)
            {
                return;
            }

            if (gv.Rows.Count != cateringList.Count + cateringChoicesList.Count)
            {
                return;
            }
            var booking = BookingModel.GetBooking(bookingID);
            int i;

            // Fill in catering choices
            for (i = 0; i < cateringChoicesList.Count; i++)
            {
                var cc = cateringChoicesList[i];
                var row = gv.Rows[i];
                row.Cells[0].Text = cc.Catering.ProductName;
                row.BackColor = Color.LightGray;
                row.Cells[13].Text = cc.Amount.ToString();
                row.Cells[14].Text = cc.Catering.Price + " DKK";

                var checkBox = row.FindControl("CheckBox" + cc.Time.Hour) as CheckBox;
                if (checkBox != null)
                {
                    checkBox.Checked = true;
                }

                for (var a = 1; a < row.Cells.Count - 2; a++)
                {
                    if ((a + 8) < cc.Catering.AvailableFrom.Hours || (a + 8) > cc.Catering.AvailableTo.Hours || (a + 8) < booking.StartTime.Hour || (a + 8) > booking.EndTime.Hour)
                    {
                        row.Cells[a].BackColor = Color.Red;
                    }
                }

                row.Cells[cc.Time.Hour - 8].BackColor = Color.Blue;
            }

            // Insert thick line below catering choices
            if (i > 0)
            {
                gv.Rows[i - 1].CssClass = "BorderRow";
            }

            // Fill in caterings
            for (var j = i; j < gv.Rows.Count; j++)
            {
                var c = cateringList[j - i];
                var row = gv.Rows[j];
                row.Cells[0].Text = c.ProductName;
                row.Cells[14].Text = c.Price.ToString() + " DKK";
                for (var a = 1; a < row.Cells.Count - 2; a++)
                {
                    if ((a + 8) < c.AvailableFrom.Hours || (a + 8) > c.AvailableTo.Hours || (a + 8) < booking.StartTime.Hour || (a + 8) > booking.EndTime.Hour)
                    {
                        row.Cells[a].BackColor = Color.Red;
                    }
                }
            }
        }

        public static bool RowChanged(GridViewRow gvr)
        {
            for (var i = 1; i < gvr.Cells.Count - 2; i++)
            {
                var cb = gvr.FindControl("CheckBox" + (i + 8)) as CheckBox;
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

        public static int NumberOfCheckedElementInRow(GridViewRow gvr)
        {
            var numberOfChecked = 0;

            for (var i = 1; i < gvr.Cells.Count - 2; i++)
            {
                var cb = gvr.FindControl("CheckBox" + (i + 8)) as CheckBox;
                if (cb == null)
                {
                    continue;
                }

                if (gvr.Cells[i].BackColor == Color.Blue && !cb.Checked)
                {
                    numberOfChecked++;
                }

                if (gvr.Cells[i].BackColor != Color.Blue && cb.Checked)
                {
                    numberOfChecked++;
                }
            }

            return numberOfChecked;
        }

        public static bool DeleteCateringChoice(int rowID)
        {
            if (rowID >= 0 && rowID < cateringChoicesList.Count)
            {
                if (BookingModel.DeleteCateringChoice(cateringChoicesList[rowID].ID) == RequestResult.Success)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public static bool CreateOrUpdateCateringChoice(GridViewRow gvr, int bookingID, int rowID, int amount)
        {
            if (rowID >= 0 && rowID < cateringChoicesList.Count)
            {
                var time = 0;

                for (var i = 1; i < gvr.Cells.Count; i++)
                {
                    var cb = gvr.FindControl("CheckBox" + (i + 8)) as CheckBox;
                    if (cb == null)
                    {
                        continue;
                    }

                    if (cb.Checked)
                    {
                        time = i + 8;
                    }
                }

                if (time == 0)
                {
                    return false;
                }

                if (gvr.Cells[time - 8].BackColor == Color.Red)
                {
                    return false;
                }

                var cc = cateringChoicesList[rowID];
                var newTime = new DateTime(cc.Time.Year, cc.Time.Month, cc.Time.Minute, time, 0, 0);

                if (BookingModel.UpdateTimeOfCateringChoice(cc.ID, newTime) == RequestResult.Success)
                {
                    return true;
                }
            }
            else if (rowID >= 0 && rowID - cateringChoicesList.Count < cateringList.Count)
            {
                var time = 0;

                for (var i = 1; i < gvr.Cells.Count; i++)
                {
                    var cb = gvr.FindControl("CheckBox" + (i + 8)) as CheckBox;
                    if (cb == null)
                    {
                        continue;
                    }

                    if (cb.Checked)
                    {
                        time = i + 8;
                    }
                }

                if (time == 0)
                {
                    return false;
                }

                if (gvr.Cells[time - 8].BackColor == Color.Red)
                {
                    return false;
                }

                var c = cateringList[rowID - cateringChoicesList.Count];
                var b = BookingModel.GetBooking(bookingID);
                var newTime = new DateTime(b.StartTime.Year, b.StartTime.Month, b.StartTime.Day, time, 0, 0);

                switch (BookingModel.CreateCateringChoice(b.ID, c.ID, amount, newTime))
                {
                    case RequestResult.Success:
                        return true;
                    case RequestResult.AccessDenied:
                        return false;
                    case RequestResult.Error:
                        return false;
                    case RequestResult.InvalidInput:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public static string GetDate()
        {
            return booking.StartTime.Day + "-" + booking.StartTime.Month + "-" + booking.StartTime.Year;
        }

        public static string GetRoomName()
        {
            return booking.Room.Name;
        }
    }
}
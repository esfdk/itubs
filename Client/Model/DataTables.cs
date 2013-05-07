namespace Client.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;

    public static class DataTables
    {
        #region Lists For different grids

        private static List<CateringChoice> cateringChoicesList;

        private static List<Catering> cateringList;

        private static List<Room> roomList;

        private static List<Room> superRoomList;

        private static List<Booking> yourBookingList;

        private static List<Booking> pendingBookingList;

        private static List<Booking> personBookingList;

        private static List<Booking> bookingList;

        private static List<Equipment> equipmentList;

        private static List<Equipment> bookEquipmentList;

        private static List<Equipment> changeRoomEquipmentList;

        private static List<Inventory> inventoryList;

        #endregion

        #region Static Methods
        #region Get Different DataTables

        public static DataTable GetYourBookings()
        {
            var dt = new DataTable();
            yourBookingList = BookingModel.GetYourBookings().Where(b => b.EndTime > DateTime.Now).ToList();

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

        public static DataTable GetCaterings(int bookingID)
        {
            var dt = new DataTable();

            cateringChoicesList = BookingModel.GetBooking(bookingID).CateringChoices.ToList();
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

        public static DataTable GetSuperRooms()
        {
            var dt = new DataTable();

            superRoomList = RoomModel.GetRooms().ToList();

            if (superRoomList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var r in superRoomList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        #endregion

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
                gv.Rows[i].Cells[2].Text = b.StartTime.Date + " " + b.StartTime.Hour.ToString() + "-" + b.EndTime.Hour;
                gv.Rows[i].Cells[3].Text = b.Status;
            }
        }

        public static void UpdateCateringGrid(GridView gv)
        {
            if (cateringList.Count + cateringChoicesList.Count == 0)
            {
                return;
            }

            if (gv.Rows.Count != cateringList.Count + cateringChoicesList.Count)
            {
                return;
            }

            int i;

            // Fill in catering choices
            for (i = 0; i < cateringChoicesList.Count; i++)
            {
                var cc = cateringChoicesList[i];
                gv.Rows[i].Cells[0].Text = cc.Catering.ProductName;
                gv.Rows[i].Cells[13].Text = cc.Amount.ToString();
                gv.Rows[i].Cells[14].Text = cc.Catering.Price.ToString() + " DKK";

                var checkBox = gv.Rows[i].FindControl("CheckBox" + cc.Time.Hour) as CheckBox;
                if (checkBox != null)
                {
                    checkBox.Checked = true;
                }

                gv.Rows[i].Cells[cc.Time.Hour - 8].BackColor = Color.Blue;
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
                gv.Rows[j].Cells[0].Text = c.ProductName;
                gv.Rows[j].Cells[14].Text = c.Price.ToString() + " DKK";
            }
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

        public static void UpdateInventoryGrid(GridView gv)
        {

        }

        public static void UpdateRoomGrid(GridView gv)
        {

        }

        public static void UpdateSuperRoomGrid(GridView gv)
        {
            if (superRoomList.Count == 0)
            {
                return;
            }

            if (gv.Rows.Count != superRoomList.Count)
            {
                return;
            }

            for (var i = 0; i < superRoomList.Count; i++)
            {
                var r = superRoomList[i];
                gv.Rows[i].Cells[0].Text = r.Name;
                gv.Rows[i].Cells[1].Text = r.MaxParticipants.ToString();

                var s = string.Empty;
                int j;
                for (j = 0; j < r.Inventories.Count() - 1; j++)
                {
                    s += (r.Inventories[j].ProductName + ", ");
                }

                if (r.Inventories.Count() != 0)
                {
                    s += r.Inventories[0].ProductName;
                }

                gv.Rows[i].Cells[2].Text = s;
            }
        }

        public static bool DeleteRoom(int id)
        {
            if (id > -1 && id < superRoomList.Count)
            {
                return RoomModel.DeleteRoom(superRoomList[id]);
            }

            return false;
        }

        #endregion
    }
}
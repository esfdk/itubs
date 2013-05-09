namespace Client.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model.Types;

    public static class DataTables
    {
        #region Lists For different grids

        private static List<CateringChoice> cateringChoicesList;

        private static List<Catering> cateringList;

        private static List<Room> roomList;

        private static List<Room> superRoomList;

        private static List<Booking> yourBookingList;

        private static List<Booking> pendingBookingList;

        private static List<Booking> findBookingList;

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
                return dt;
            }

            foreach (var r in superRoomList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static DataTable GetBookEquipmentList(string type)
        {
            var dt = new DataTable();

            bookEquipmentList = EquipmentModel.GetAllEquipment(type).ToList();

            if (bookEquipmentList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                return dt;
            }

            foreach (var r in bookEquipmentList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

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

        #endregion

        #region Update Grid Methods

        public static void UpdateBookEquipmentGrid(GridView gv, int bookingID)
        {
            if (bookEquipmentList == null || bookEquipmentList.Count == 0 || gv.Rows.Count != bookEquipmentList.Count)
            {
                return;
            }

            gv.Rows[0].Cells[0].Text = "ohhhh yeee";

            var b = BookingModel.GetBooking(bookingID);

            for (var i = 0; i < bookEquipmentList.Count; i++)
            {
                var e = bookEquipmentList[i];
                gv.Rows[i].Cells[0].Text = e.ProductName;
                gv.Rows[i].Cells[1].Text = e.EquipmentType.Type;

                foreach (var ec in e.EquipmentChoices.Where(d => d.StartTime.Date == b.StartTime.Date).Where(ec => ec.StartTime.Hour < ec.EndTime.Hour))
                {
                    for (var j = ec.StartTime.Hour; j < ec.EndTime.Hour; j++)
                    {
                        var cb = gv.Rows[i].FindControl("CheckBox" + j) as CheckBox;
                        if (cb != null)
                        {
                            var tc = cb.Parent as TableCell;
                            if (tc != null)
                            {
                                if (ec.Booking.PersonID == b.PersonID)
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
                    s += r.Inventories[j].ProductName + ", ";
                }

                if (r.Inventories.Count() != 0)
                {
                    s += r.Inventories[0].ProductName;
                }

                gv.Rows[i].Cells[2].Text = s;
            }
        }

        #endregion

        #region Other Methods

        public static Person GetPersonByMail(string mail)
        {
            return PersonModel.GetPersonByMail(mail);
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

        #endregion
    }
}
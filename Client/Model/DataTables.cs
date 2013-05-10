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

        private static List<Room> superRoomList;

        private static List<Booking> pendingBookingList;

        private static List<Booking> findBookingList;

        private static List<Equipment> bookEquipmentList;

        private static List<Inventory> roomInventoryList;

        private static List<Equipment> equipmentList;

        private static List<Inventory> inventoryList;

        private static Room changeRoom;

        #endregion

        #region Static Methods
        #region Get Different DataTables

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

        public static DataTable GetBookEquipment(string type)
        {
            var dt = new DataTable();

            bookEquipmentList = EquipmentAndInventoryModel.GetAllEquipment(type).ToList();

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

        public static DataTable GetSuperEquipment()
        {
            var dt = new DataTable();

            equipmentList = EquipmentAndInventoryModel.GetAllEquipment(null).ToList();
            inventoryList = EquipmentAndInventoryModel.GetAllInventory(null, true).ToList();

            if (equipmentList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var e in equipmentList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var i in inventoryList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static DataTable GetRoomInventory(int roomID)
        {
            var dt = new DataTable();

            changeRoom = RoomModel.GetRoomByID(roomID);
            roomInventoryList = EquipmentAndInventoryModel.GetAllInventory(null, false).ToList();

            if (changeRoom.Inventories.Count() + roomInventoryList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var i in changeRoom.Inventories)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var i in roomInventoryList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }
        #endregion Get Different DataTables

        #region Update Grid Methods

        public static void UpdateRoomInventoryGrid(GridView gv)
        {
            if (roomInventoryList.Count + changeRoom.Inventories.Count() == 0 || roomInventoryList.Count + changeRoom.Inventories.Count() != gv.Rows.Count)
            {
                return;
            }

            int i;
            for (i = 0; i < changeRoom.Inventories.Count(); i++)
            {
                var row = gv.Rows[i];
                var inventory = changeRoom.Inventories[i];
                row.BackColor = Color.LightGray;
                row.Cells[0].Text = inventory.ProductName;
                row.Cells[1].Text = inventory.InventoryType.Type;
                row.Cells[2].Text = inventory.Status;
            }

            for (var j = i; j - i < roomInventoryList.Count; j++)
            {
                var row = gv.Rows[j];
                var inventory = roomInventoryList[j - i];
                row.Cells[0].Text = inventory.ProductName;
                row.Cells[1].Text = inventory.InventoryType.Type;
                row.Cells[2].Text = inventory.Status;
            }
        }

        public static void UpdateSuperEquipment(GridView gv)
        {
            if (inventoryList.Count + equipmentList.Count == 0)
            {
                return;
            }

            if (inventoryList.Count + equipmentList.Count != gv.Rows.Count)
            {
                return;
            }

            int i;

            for (i = 0; i < inventoryList.Count; i++)
            {
                var row = gv.Rows[i];
                var inventory = inventoryList[i];
                row.Cells[0].Text = inventory.ProductName;
                row.Cells[1].Text = inventory.InventoryType.Type;
                row.Cells[2].Text = inventory.Status;
            }

            // Insert thick line after inventory already selected
            if (i > 0)
            {
                gv.Rows[i - 1].CssClass = "BorderRow";
            }

            for (var j = i; j - i < equipmentList.Count; j++)
            {
                var row = gv.Rows[j];
                var equipment = equipmentList[j - i];
                row.Cells[0].Text = equipment.ProductName;
                row.Cells[1].Text = equipment.EquipmentType.Type;
                row.Cells[2].Text = equipment.Status;
            }

        }

        public static void UpdateBookEquipmentGrid(GridView gv, int bookingID)
        {
            if (bookEquipmentList == null || bookEquipmentList.Count == 0 || gv.Rows.Count != bookEquipmentList.Count)
            {
                return;
            }

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
                                var ecpID = ec.Booking.PersonID;
                                if (PersonModel.loggedInUser != null && ecpID == PersonModel.loggedInUser.ID)
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

        #endregion Update Grid Methods

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

        public static List<String> GetEquipmentTypes()
        {
            var etList = new List<string> { "Alle" };

            var eTypes = EquipmentAndInventoryModel.GetEquipmentTypes();

            etList.AddRange(eTypes.Select(et => et.Type));

            return etList;
        }

        #endregion Other Methods

        #endregion
    }
}
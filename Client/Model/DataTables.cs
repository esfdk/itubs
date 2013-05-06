namespace Client.Model
{
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

        private static List<Booking> superBookingList;

        private static List<Booking> personBookingList;

        private static List<Booking> bookingList;

        private static List<Equipment> equipmentList;

        private static List<Equipment> bookEquipmentList;

        private static List<Equipment> changeRoomEquipmentList;

        private static List<Inventory> inventoryList;

        #endregion

        #region Static Methods
        #region Get Different DataTables

        public static DataTable GetCaterings(int bookingID)
        {
            var dt = new DataTable();

            cateringChoicesList = BookingModel.GetBooking(bookingID).CateringChoices.ToList();
            cateringList = CateringModel.GetAllCaterings().ToList();

            for (var i = 0; i < (cateringList.Count + cateringChoicesList.Count); i++)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        #endregion

        public static void UpdateCateringGrid(GridView gv)
        {
            if (gv.Rows.Count != cateringList.Count + cateringChoicesList.Count)
            {
                return;
            }

            var i = 0;

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

        public static void UpdateInventoryGrid(GridView gv)
        {

        }

        public static void UpdateRoomGrid(GridView gv)
        {

        }

        public static void UpdateSuperRoomGrid(GridView gv)
        {


        }

        #endregion
    }
}
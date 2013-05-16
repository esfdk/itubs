
namespace Client.ViewModel.User
{
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;

    public static class BookEquipmentViewModel
    {
        private static List<Equipment> bookEquipmentList;

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

        public static List<string> GetEquipmentTypes()
        {
            var etList = new List<string> { "Alle" };

            var eTypes = EquipmentAndInventoryModel.GetEquipmentTypes();

            etList.AddRange(eTypes.Select(et => et.Type));

            return etList;
        }
    }
}
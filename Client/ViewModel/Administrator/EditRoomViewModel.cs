
namespace Client.ViewModel.Administrator
{
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;

    public static class EditRoomViewModel
    {
        private static List<Inventory> roomInventoryList;

        private static Room editRoom;

        public static DataTable GetRoomInventory(int roomID)
        {
            var dt = new DataTable();

            editRoom = RoomModel.GetRoomByID(roomID);
            roomInventoryList = EquipmentAndInventoryModel.GetAllInventory(null, false).ToList();

            if (editRoom.Inventories.Count() + roomInventoryList.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var i in editRoom.Inventories)
            {
                dt.Rows.Add(dt.NewRow());
            }

            foreach (var i in roomInventoryList)
            {
                dt.Rows.Add(dt.NewRow());
            }

            return dt;
        }

        public static void UpdateRoomInventoryGrid(GridView gv)
        {
            if (roomInventoryList.Count + editRoom.Inventories.Count() == 0 || roomInventoryList.Count + editRoom.Inventories.Count() != gv.Rows.Count)
            {
                return;
            }

            int i;
            for (i = 0; i < editRoom.Inventories.Count(); i++)
            {
                var row = gv.Rows[i];
                var inventory = editRoom.Inventories[i];
                row.BackColor = Color.LightGray;
                row.Cells[0].Text = inventory.ProductName;
                row.Cells[1].Text = inventory.InventoryType.Type;
                row.Cells[2].Text = inventory.Status;
            }

            if (i > 0)
            {
                gv.Rows[i - 1].CssClass = "BorderRow";
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
    }
}
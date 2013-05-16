
namespace Client.ViewModel.Administrator
{
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;

    public static class EquipmentListViewModel
    {
        private static List<Equipment> equipmentList;

        private static List<Inventory> inventoryList;

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
                row.BackColor = Color.LightGray;
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
    }
}
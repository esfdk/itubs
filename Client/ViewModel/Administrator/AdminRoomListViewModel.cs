
namespace Client.ViewModel.Administrator
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Client.BookItService;
    using Client.Model;

    public static class AdminRoomListViewModel
    {
        private static List<Room> superRoomList;

        public static DataTable GetAdminRooms()
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

        public static void UpdateAdminRoomGrid(GridView gv)
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
                    s += r.Inventories[j].ProductName;
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
    }
}
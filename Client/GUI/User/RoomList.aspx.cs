namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.ViewModel;

    public partial class RoomList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                DateTime d;
                if (DateTime.TryParse(Request.QueryString["date"], out d))
                {
                    this.DateTextBox.Text = d.Date.ToShortDateString();
                }
                else
                {
                    this.DateTextBox.Text = DateTime.Today.Date.ToShortDateString();
                }
            }

            this.RoomGridView.DataSource = RoomListViewModel.GetBookRooms();
            this.RoomGridView.DataBind();

        }

        protected void DateChanged(object sender, EventArgs e)
        {
            DateTime newDate;
            if (DateTime.TryParse(DateTextBox.Text, out newDate))
            {
                this.Response.Redirect("~/GUI/User/RoomList.aspx?date=" + newDate.Date.ToShortDateString());
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(DateTextBox.Text, out date))
            {
                RoomListViewModel.UpdateRoomGrid(this.RoomGridView, date.Date);
            }
            else
            {
                RoomListViewModel.UpdateRoomGrid(this.RoomGridView, DateTime.Today.Date);
            }
        }

        protected void BookLokaleButton_Click(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                this.Response.Redirect("~/GUI/Account/Login.apsx");
                return;
            }

            var remindUser = false;

            DateTime date;
            if (!DateTime.TryParse(DateTextBox.Text, out date))
            {
                this.Response.Write(String.Format("<script>alert('Forkert dato format.');</script>"));
                return;
            }

            for (var i = 0; i < RoomGridView.Rows.Count; i++)
            {
                if (RoomListViewModel.RowChanged(RoomGridView.Rows[i]))
                {
                    var temp = false;
                    RoomListViewModel.CreateAndUpdateBookings(RoomGridView.Rows[i], i, date, out temp);
                    if (temp)
                    {
                        remindUser = true;
                    }
                }
            }

            //If booking is changed and have a equipment and/or catering choices then throw a popup alert 
            if (0 < 1)
            {
                string popUpText1 = "Husk også at ændre dine bookinger af forplejning og udstyr.";
                this.Response.Write(String.Format("<script>alert('{0}');</script>", popUpText1));
            }
            this.Response.Redirect("~/GUI/User/DineBookinger.aspx");
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.RoomGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}

namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Types;
    using Client.ViewModel;
    using Client.ViewModel.User;

    public partial class RoomList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                DateTime d;
                this.DateTextBox.Text = DateTime.TryParse(this.Request.QueryString["date"], out d) ? d.Date.ToShortDateString() : DateTime.Today.Date.ToShortDateString();

                this.RoomGridView.DataSource = RoomListViewModel.GetBookRooms();
                this.RoomGridView.DataBind();
            }

            RoomGridView.PageIndexChanging += this.PageIndexChanging;
        }

        protected void DateChanged(object sender, EventArgs e)
        {
            DateTime newDate;
            if (DateTime.TryParse(DateTextBox.Text, out newDate))
            {
                this.Response.Redirect("~/GUI/User/RoomList.aspx?date=" + newDate.Date.ToShortDateString());
            }
        }

        protected void PageIndexChanged(object sender, EventArgs e)
        {
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RoomGridView.PageIndex = e.NewPageIndex;

            RoomGridView.EditIndex = -1;
            RoomGridView.SelectedIndex = -1;
            this.RoomGridView.DataSource = RoomListViewModel.GetBookRooms();
            RoomGridView.DataBind();
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(this.DateTextBox.Text, out date))
            {
                RoomListViewModel.UpdateRoomGrid(this.RoomGridView, date.Date, RoomGridView.PageIndex);
            }
            else
            {
                RoomListViewModel.UpdateRoomGrid(this.RoomGridView, DateTime.Today.Date, RoomGridView.PageIndex);

            }
        }

        /// <summary>Event raised when "Book lokale" is clicked</summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        protected void BookLokaleButton_Click(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                this.Response.Redirect("~/GUI/Account/Login.aspx");
                return;
            }

            DateTime date;
            if (!DateTime.TryParse(DateTextBox.Text, out date))
            {
                this.Response.Write(String.Format("<script>alert('Forkert dato format.');</script>"));
                this.Response.Flush();
                return;
            }

            var bookingUpdated = false;

            for (var i = 0; i < RoomGridView.Rows.Count; i++)
            {
                if (RoomListViewModel.RowChanged(RoomGridView.Rows[i]))
                {
                    var rr = RoomListViewModel.CreateOrUpdateBooking(
                        RoomGridView.Rows[i], i, date, out bookingUpdated);
                    if (rr == RequestResult.Success)
                    {
                        if (bookingUpdated)
                        {
                            Response.Write("<script></script>");
                            this.Response.Write("<script>alert('Husk også at ændre dine bookinger af forplejning og udstyr.');location.href = ~/GUI/User/YourBookings.aspx';</script>");
                            this.Response.Flush();
                        }
                        else
                        {
                            this.Response.Redirect("~/GUI/User/YourBookings.aspx");
                        }
                    }
                    else
                    {
                        this.Response.Write("<script>alert('Kunne ikke udføre handlingen.');</script>");
                        this.Response.Flush();
                    }
                }
            }
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

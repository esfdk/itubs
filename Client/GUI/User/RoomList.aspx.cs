namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Types;
    using Client.ViewModel;
    using Client.ViewModel.User;

    public partial class RoomList : System.Web.UI.Page
    {
        private DateTime parse(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return DateTime.Today;
            }

            int dayint;
            int monthint;
            int yearint;

            int firstDashIndex = s.IndexOf("-");
            int secondDashIndex = s.LastIndexOf("-");

            string day = s.Substring(0, firstDashIndex);
            string month = s.Substring(firstDashIndex + 1, secondDashIndex - firstDashIndex - 1);
            string year = s.Substring(secondDashIndex + 1);
            try
            {
                dayint = int.Parse(day);
                monthint = int.Parse(month);
                yearint = int.Parse(year);
            }
            catch(Exception)
            {
                return DateTime.Today;
            }

            return new DateTime(yearint, monthint, dayint);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                DateTime d = parse(this.Request.QueryString["date"]);
                this.DateTextBox.Text = d.Day + "-" + d.Month + "-" + d.Year;

                this.RoomGridView.DataSource = RoomListViewModel.GetBookRooms();
                this.RoomGridView.DataBind();
            }

            RoomGridView.PageIndexChanging += this.PageIndexChanging;
        }

        protected void DateChanged(object sender, EventArgs e)
        {
            DateTime newDate = this.parse(DateTextBox.Text);
            this.Response.Redirect("~/GUI/User/RoomList.aspx?date=" + newDate.Day + "-" + newDate.Month + "-" + newDate.Year);
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
            DateTime date = parse(DateTextBox.Text);
                RoomListViewModel.UpdateRoomGrid(this.RoomGridView, date.Date, RoomGridView.PageIndex);
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

            DateTime date = this.parse(DateTextBox.Text);
            /*if (!DateTime.TryParse(DateTextBox.Text, out date))
            {
                this.Response.Write("<script type='text/javascript'>");
                this.Response.Write("alert('Forkert dato format.');");
                this.Response.Write("window.location.href='RoomList.aspx';");
                this.Response.Write("</script>");
                this.Response.Flush();
                return;
            }*/
             

            var bookingUpdated = false;

            for (var i = 0; i < RoomGridView.Rows.Count; i++)
            {
                if (!RoomListViewModel.RowChanged(this.RoomGridView.Rows[i]))
                {
                    continue;
                }

                var rr = RoomListViewModel.CreateOrUpdateBooking(this.RoomGridView.Rows[i], i, date, out bookingUpdated);
                if (rr == RequestResult.Success)
                {
                    if (bookingUpdated)
                    {
                        this.Response.Write("<script>alert('Husk også at ændre dine bookinger af forplejning og udstyr.');location.href = ~/GUI/User/YourBookings.aspx';</script>");
                        this.Response.Flush();
                    }
                    else
                    {
                        this.Response.Redirect("~/GUI/User/YourBookings.aspx");
                    }
                }
                else if (rr == RequestResult.Error)
                {
                    this.Response.Write("<script type='text/javascript'>");
                    this.Response.Write("alert('Det er ikke muligt at booke på det valgte tidspunkt.');");
                    this.Response.Write("window.location.href='RoomList.aspx';");
                    this.Response.Write("</script>");
                    this.Response.Flush();
                }
                else
                {
                    this.Response.Write("<script type='text/javascript'>");
                    this.Response.Write("alert('Kunne ikke udføre handlingen.'" + rr.ToString() +"');");
                    this.Response.Write("window.location.href='RoomList.aspx';");
                    this.Response.Write("</script>");
                    this.Response.Flush();
                }
            }

            this.Response.Write("<script type='text/javascript'>");
            this.Response.Write("alert('Du skal ændre en booking eller tilføje en ny.');");
            this.Response.Write("window.location.href='RoomList.aspx';");
            this.Response.Write("</script>");
            this.Response.Flush();
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            /*if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.RoomGridView, "Select$" + e.Row.RowIndex);
            }*/
        }
    }
}

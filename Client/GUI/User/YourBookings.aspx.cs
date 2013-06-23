namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.ViewModel;
    using Client.ViewModel.User;

    public partial class YourBookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                this.Response.Redirect("~/GUI/Account/Login.aspx");
            }

            DeleteBookingButton.OnClientClick = "return confirmBookingDeletion()";

            YourBookingsGridView.DataSource = YourBookingsViewModel.GetYourBookings();
            YourBookingsGridView.DataBind();
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            YourBookingsViewModel.UpdateYourBookingsGrid(this.YourBookingsGridView);
        }

        protected void ChangeBookingButton_Click(object sender, EventArgs e)
        {
            var id = YourBookingsViewModel.GetBookingIDFromRow(this.YourBookingsGridView.SelectedIndex);
            if (id == -1)
            {
                this.Response.Write("<script type='text/javascript'>");
                this.Response.Write("alert('Du skal vælge en booking.');");
                this.Response.Write("window.location.href='RoomList.aspx';");
                this.Response.Write("</script>");
                this.Response.Flush();
                return;
            }

            this.Response.Redirect("~/GUI/User/RoomList.aspx");
        }

        protected void DeleteBookingButton_Click(object sender, EventArgs e)
        {
            var id = YourBookingsViewModel.GetBookingIDFromRow(this.YourBookingsGridView.SelectedIndex);
            if (id == -1)
            {
                this.Response.Write("<script type='text/javascript'>");
                this.Response.Write("alert('Du skal vælge en booking.');");
                this.Response.Write("window.location.href='YourBookings.aspx';");
                this.Response.Write("</script>");
                this.Response.Flush();
                return;
            }

            if (!YourBookingsViewModel.DeleteBooking(id))
            {
                this.Response.Write("<script type='text/javascript'>");
                this.Response.Write("alert('Handlingen kunne ikke udføres.');");
                this.Response.Write("window.location.href='YourBookings.aspx';");
                this.Response.Write("</script>");
                this.Response.Flush();
                return;
            }

            this.Response.Redirect("~/GUI/User/YourBookings.aspx");
        }

        protected void EquipmentButton_Click(object sender, EventArgs e)
        {
            var id = YourBookingsViewModel.GetBookingIDFromRow(this.YourBookingsGridView.SelectedIndex);
            if (id == -1)
            {
                this.Response.Write("<script type='text/javascript'>");
                this.Response.Write("alert('Du skal vælge en booking.');");
                this.Response.Write("window.location.href='YourBookings.aspx';");
                this.Response.Write("</script>");
                this.Response.Flush();
                return;
            }

            this.Response.Redirect("~/GUI/User/BookEquipment.aspx?bookingID=" + id);
        }

        protected void CateringButton_Click(object sender, EventArgs e)
        {
            var id = YourBookingsViewModel.GetBookingIDFromRow(this.YourBookingsGridView.SelectedIndex);
            if (id == -1)
            {
                this.Response.Write("<script type='text/javascript'>");
                this.Response.Write("alert('Du skal vælge en booking.');");
                this.Response.Write("window.location.href='YourBookings.aspx';");
                this.Response.Write("</script>");
                this.Response.Flush();
                return;
            }

            this.Response.Redirect("~/GUI/User/CateringList.aspx?bookingID=" + id);
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.YourBookingsGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
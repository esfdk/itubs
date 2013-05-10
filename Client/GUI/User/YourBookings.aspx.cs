namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;
    using Client.ViewModel;

    public partial class YourBookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PersonModel.loggedInUser == null)
            {
                this.Response.Redirect("~/GUI/User/RoomList.aspx");
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
            this.Response.Redirect("~/GUI/User/RoomList.aspx");
        }

        protected void DeleteBookingButton_Click(object sender, EventArgs e)
        {
            var id = YourBookingsViewModel.GetBookingIDFromRow(this.YourBookingsGridView.SelectedIndex);
            if (id == -1)
            {
                this.Response.Write("<script>alert('Du skal vælge en booking.');</script>");
                this.Response.Flush();
                return;
            }

            if (!YourBookingsViewModel.DeleteBooking(id))
            {
                this.Response.Write("<script>alert('Handlingen kunne ikke udføres.');</script>");
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
                this.Response.Write("<script>alert('Du skal vælge en booking.');</script>");
            }

            this.Response.Redirect("~/GUI/User/BookUdstyr.aspx?bookingID=" + id);
        }

        protected void CateringButton_Click(object sender, EventArgs e)
        {
            var id = YourBookingsViewModel.GetBookingIDFromRow(this.YourBookingsGridView.SelectedIndex);
            if (id == -1)
            {
                this.Response.Write("<script>alert('Du skal vælge en booking.');</script>");
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
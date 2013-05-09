namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class DineBookinger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PersonModel.loggedInUser == null)
            {
                this.Response.Redirect("~/GUI/User/Lokaleliste.aspx");
            }

            if (!this.Page.IsPostBack)
            {
                this.GridView1.DataSource = DataTables.GetYourBookings();
                this.GridView1.DataBind();
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DataTables.UpdateYourBookingsGrid(GridView1);
        }

        protected void UdstyrButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("BookUdstyr.aspx");
        }

        protected void ÆndreBookButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("RoomList.aspx");
        }

        protected void SletBookingButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
        }

        protected void ForplejningButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Forplejning.aspx");
        }

        protected void SendGodkendButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
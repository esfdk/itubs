namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class DineBookinger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.GridView1.DataSource = DataTables.GetYourBookings();
                this.GridView1.DataBind();
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {


        }

        protected void UdstyrButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("BookUdstyr.aspx");
        }

        protected void ÆndreBookButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("LokaleListe.aspx");
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

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
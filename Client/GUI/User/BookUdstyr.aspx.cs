namespace Client.GUI.User
{
    using System;

    using Client.Model;

    public partial class BookUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
                var bookingIDstring = Request.QueryString["bookingID"];
                var bookingID = int.Parse(bookingIDstring);*/
            this.GridView1.DataSource = DataTables.GetBookEquipmentList(null);
            this.GridView1.DataBind();
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DataTables.UpdateBookEquipmentGrid(GridView1, 2);
        }

        protected void FortrydButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
        }

        protected void ÆndringerButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
        }
    }
}
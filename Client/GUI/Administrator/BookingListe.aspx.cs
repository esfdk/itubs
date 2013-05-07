namespace Client.GUI.Administrator
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class BookingListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.GridView1.DataSource = DataTables.GetPendingBookings();
                this.GridView1.DataBind();
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DataTables.UpdatePendingGrid(GridView1);
        }

        protected void Godkend_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("BookingListe.aspx");
        }

        protected void Afvis_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("BookingListe.aspx");
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
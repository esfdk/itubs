namespace Client.GUI.Administrator
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class SuperLokaleListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SletLokaleButton.OnClientClick = "return confirmRoomDeletion('" + GridView1.SelectedIndex + "')";
            if (!IsPostBack)
            {
                GridView1.DataSource = DataTables.GetSuperRooms();
                GridView1.DataBind();
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DataTables.UpdateSuperRoomGrid(GridView1);
        }

        protected void ÆndreLokale_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("ÆndreLokale.aspx");
        }

        protected void TilføjLokale_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("TilføjLokale.aspx");
        }

        protected void SletLokale_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1)
            {
                Response.Write("<script type='text/javascript'>alert('Du har ikke valgt et lokale.')</script>");
                Response.Flush();
                return;
            }

            if (!DataTables.DeleteRoom(GridView1.SelectedIndex))
            {
                Response.Write("<script type='text/javascript'>alert('Kunne ikke udføre handlingen')</script>");
                Response.Flush();
                return;
            }

            this.Response.Redirect("SuperLokaleListe.aspx");
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
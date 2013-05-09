namespace Client.GUI.Administrator
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = DataTables.GetSuperEquipment();
            GridView1.DataBind();
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DataTables.UpdateSuperEquipment(GridView1);
        }

        protected void ÆndreUdstyrButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("ÆndreUdstyr.aspx");
        }

        protected void TilføjUdstyrButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UdstyrsListe.aspx");
        }

        protected void SletUdstyrButton_Click(object sender, EventArgs e)
        {
            if (0 < 1)
            {
                string popUpText = "Er du sikker på du ville slet 'udstyr X' fra udstyrslisten?.";
                //The line below will launch a Javascript alert that says "The Value is Testing Value"
                this.Response.Write(String.Format("<script>alert('{0}');</script>", popUpText));
            }
            this.Response.Redirect("UdstyrsListe.aspx");
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

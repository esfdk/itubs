namespace Client.GUI.Administrator
{
    using System;

    public partial class TilføjUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TilføjUdstyr_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("ÆndreLokale.aspx");
        }
    }
}
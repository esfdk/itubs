namespace Client.GUI.Administrator
{
    using System;

    public partial class TilføjLokale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TilføjLokale_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("SuperLokaleListe.aspx");
        }
    }
}
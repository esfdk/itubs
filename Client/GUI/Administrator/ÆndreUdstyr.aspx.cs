namespace Client.GUI.Administrator
{
    using System;

    public partial class ÆndreUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ÆndreUdstyr_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UdstyrsListe.aspx");
        }
    }
}
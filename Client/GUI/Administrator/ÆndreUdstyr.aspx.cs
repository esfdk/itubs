namespace Client.GUI.Administrator
{
    using System;

    public partial class �ndreUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void �ndreUdstyr_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UdstyrsListe.aspx");
        }
    }
}
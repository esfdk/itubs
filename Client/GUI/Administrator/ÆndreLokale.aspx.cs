namespace Client.GUI.Administrator
{
    using System;

    public partial class �ndreLokale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FjernUdstyr_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("�ndreLokale.aspx");
        }

        protected void Tilf�jUdstyr_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("�ndre.aspx");
        }

        protected void Afslut_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("SuperLokaleListe.aspx");
        }

    }
}
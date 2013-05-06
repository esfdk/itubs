namespace Client.GUI.Administrator
{
    using System;

    public partial class ÆndreLokale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FjernUdstyr_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("ÆndreLokale.aspx");
        }

        protected void TilføjUdstyr_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Ændre.aspx");
        }

        protected void Afslut_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("SuperLokaleListe.aspx");
        }

    }
}
namespace Client.GUI.Administrator
{
    using System;

    public partial class SuperLokaleListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            if (0 < 1)
            {
                string popUpText = "Er du sikker på du vil slette 'lokale X' fra lokalelisten?";
                //The line below will launch a Javascript alert that says "The Value is Testing Value"
                this.Response.Write(String.Format("<script>alert('{0}');</script>", popUpText));
            }
            this.Response.Redirect("SuperLokaleListe.aspx");
        }
    }
}
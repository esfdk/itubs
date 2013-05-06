namespace Client.GUI.Administrator
{
    using System;

    public partial class BookingListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Godkend_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("BookingListe.aspx");
        }

        protected void Afvis_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("BookingListe.aspx");
        }
    }
}
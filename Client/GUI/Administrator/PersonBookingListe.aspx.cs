namespace Client.GUI.Administrator
{
    using System;

    public partial class PersonBookingListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FindBookinger_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("PersonBookingListe.aspx");
        }

        protected void GodkendBooking_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("PersonBookingListe.aspx");
        }

        protected void AfvisBooking_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("PersonBookingListe.aspx");
        }
    }
}
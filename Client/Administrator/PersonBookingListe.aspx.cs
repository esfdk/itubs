using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookIT
{
    public partial class PersonBookingListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FindBookinger_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonBookingListe.aspx");
        }

        protected void GodkendBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonBookingListe.aspx");
        }

        protected void AfvisBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonBookingListe.aspx");
        }
    }
}
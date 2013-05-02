using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Client.User;

namespace BookIT
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
        }

        protected void MenuButton_LokaleListe_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/User/LokaleListe.aspx");
        }

        protected void MenuButton_DineBookinger_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/User/DineBookinger.aspx");
        }

        protected void MenuButton_UdstyrsListe_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/UdstyrsListe.aspx");
        }

        protected void MenuButton_BookingListe_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/BookingListe.aspx");
        }

        protected void MenuButton_KonfigLokale_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/SuperLokaleListe.aspx");
        }

        protected void MenuButton_FindBookinger_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/PersonBookingListe.aspx");
        }
    }
}

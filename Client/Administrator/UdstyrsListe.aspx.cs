using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookIT
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ÆndreUdstyrButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ÆndreUdstyr.aspx");
        }

        protected void TilføjUdstyrButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UdstyrsListe.aspx");
        }

        protected void SletUdstyrButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UdstyrsListe.aspx");
        }
    }
}

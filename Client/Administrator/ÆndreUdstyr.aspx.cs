using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookIT
{
    public partial class ÆndreUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ÆndreUdstyr_Click(object sender, EventArgs e)
        {
            Response.Redirect("UdstyrsListe.aspx");
        }
    }
}
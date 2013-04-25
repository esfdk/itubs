using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookIT
{
    public partial class SuperLokaleListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ÆndreLokale_Click(object sender, EventArgs e)
        {
            Response.Redirect("ÆndreLokale.aspx");
        }

        protected void TilføjLokale_Click(object sender, EventArgs e)
        {
            Response.Redirect("TilføjLokale.aspx");
        }

        protected void SletLokale_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperLokaleListe.aspx");
        }
    }
}
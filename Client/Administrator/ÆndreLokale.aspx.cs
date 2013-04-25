using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookIT
{
    public partial class ÆndreLokale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FjernUdstyr_Click(object sender, EventArgs e)
        {
            Response.Redirect("ÆndreLokale.aspx");
        }

        protected void TilføjUdstyr_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ændre.aspx");
        }

        protected void Afslut_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuperLokaleListe.aspx");
        }

    }
}
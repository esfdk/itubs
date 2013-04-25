using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookIT
{
    public partial class TilføjUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TilføjUdstyr_Click(object sender, EventArgs e)
        {
            Response.Redirect("ÆndreLokale.aspx");
        }
    }
}
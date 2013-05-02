using System;

namespace Client.Administrator
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
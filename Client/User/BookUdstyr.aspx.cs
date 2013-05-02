using System;

namespace Client.User
{
    public partial class BookUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FortrydButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DineBookinger.aspx");
        }

        protected void ÆndringerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DineBookinger.aspx");
        }
    }
}
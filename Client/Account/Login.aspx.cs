using System;

namespace Client.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LokaleListe.aspx");
        }
    }
}

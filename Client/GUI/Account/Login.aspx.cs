namespace Client.GUI.Account
{
    using System;

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("LokaleListe.aspx");
        }
    }
}

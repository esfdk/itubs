namespace Client.GUI.Account
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var un = LoginUser.FindControl("UserName") as TextBox;
            var pw = LoginUser.FindControl("Password") as TextBox;

            if (un == null || pw == null)
            {
                return;
            }

            var failure = LoginUser.FindControl("FailureText") as Literal;

            switch (PersonModel.Login(un.Text, pw.Text))
            {
                case RequestResult.WrongUserNameOrPassword:
                    if (failure != null)
                    {
                        failure.Text = "Wrong Username and/or Password";
                    }

                    return;

                case RequestResult.Success:
                    this.Response.Redirect("~/GUI/User/RoomList.aspx");
                    break;

                case RequestResult.CommunicationFailure:
                    if (failure != null)
                    {
                        failure.Text = "Der skete en kommunikationsfejl. Prøv igen.";
                    }

                    return;

                case RequestResult.InvalidInput:
                    if (failure != null)
                    {
                        failure.Text = "Der skete en kommunikationsfejl. Prøv igen.";
                    }

                    return;
            }


        }
    }
}

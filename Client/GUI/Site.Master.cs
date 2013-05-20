namespace Client.GUI
{
    using System;

    using Client.ViewModel;

    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                LogInButton.Click += LoginClick;
                MenuButton_BookingListe.CssClass = "UnavailableButton";
                MenuButton_UdstyrsListe.CssClass = "UnavailableButton";
                MenuButton_KonfigLokale.CssClass = "UnavailableButton";
                MenuButton_FindBookinger.CssClass = "UnavailableButton";
            }
            else
            {
                LogInButton.Click += LogoutClick;
                LogInButton.Text = "Log Out";
                UserNameLabel.Text = MasterViewModel.LoggedInUserName();
                if (!MasterViewModel.LoggedInUserIsAdmin())
                {
                    MenuButton_BookingListe.CssClass = "UnavailableButton";
                    MenuButton_UdstyrsListe.CssClass = "UnavailableButton";
                    MenuButton_KonfigLokale.CssClass = "UnavailableButton";
                    MenuButton_FindBookinger.CssClass = "UnavailableButton";
                }
            }
        }

        protected void LoginClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/GUI/Account/Login.aspx");
        }

        protected void LogoutClick(object sender, EventArgs e)
        {
            MasterViewModel.Logout();
            this.Response.Redirect("~/GUI/User/RoomList.aspx");
        }

        protected void MenuButton_LokaleListe_OnClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/GUI/User/RoomList.aspx");
        }

        protected void MenuButton_DineBookinger_OnClick(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                this.Response.Redirect("~/GUI/Account/Login.aspx");
            }

            this.Response.Redirect("~/GUI/User/YourBookings.aspx");
        }

        protected void MenuButton_UdstyrsListe_OnClick(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                this.Response.Redirect("~/GUI/Account/Login.aspx");
            }
            else if (!MasterViewModel.LoggedInUserIsAdmin())
            {
                this.Response.Write("<script>alert('Du har ikke de nødvendige rettigheder.');</script>");
                return;
            }

            this.Response.Redirect("~/GUI/Administrator/EquipmentList.aspx");
        }

        protected void MenuButton_BookingListe_OnClick(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                this.Response.Redirect("~/GUI/Account/Login.aspx");
            }
            else if (!MasterViewModel.LoggedInUserIsAdmin())
            {
                this.Response.Write("<script>alert('Du har ikke de nødvendige rettigheder.');</script>");
                return;
            }

            this.Response.Redirect("~/GUI/Administrator/BookingList.aspx");
        }

        protected void MenuButton_KonfigLokale_OnClick(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                this.Response.Redirect("~/GUI/Account/Login.aspx");
            }
            else if (!MasterViewModel.LoggedInUserIsAdmin())
            {
                this.Response.Write("<script>alert('Du har ikke de nødvendige rettigheder.');</script>");
                return;
            }

            this.Response.Redirect("~/GUI/Administrator/AdminRoomList.aspx");
        }

        protected void MenuButton_FindBookinger_OnClick(object sender, EventArgs e)
        {
            if (MasterViewModel.LoggedInUserID() == -1)
            {
                this.Response.Redirect("~/GUI/Account/Login.aspx");
            }
            else if (!MasterViewModel.LoggedInUserIsAdmin())
            {
                this.Response.Write("<script>alert('Du har ikke de nødvendige rettigheder.');</script>");
                return;
            }

            this.Response.Redirect("~/GUI/Administrator/PersonBookingList.aspx");
        }
    }
}

namespace Client.GUI.Administrator
{
    using System;

    public partial class AddRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddRoomButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("AdminRoomList.aspx");
        }
    }
}
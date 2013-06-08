namespace Client.GUI.Administrator
{
    using System;

    using Client.Types;
    using Client.ViewModel.Administrator;

    public partial class AddRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void AddRoomButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CapacityTextBox.Text) || string.IsNullOrWhiteSpace(RoomNameTextBox.Text))
            {
                this.Response.Write("<script type='text/javascript'>");
                this.Response.Write("alert('Du skal udfylde både navn og kapacitet.');");
                this.Response.Write("window.location.href='AddRoom.aspx';");
                this.Response.Write("</script>");
                this.Response.Flush();
            }

            int capacity;
            if (int.TryParse(CapacityTextBox.Text, out capacity))
            {
                RequestResult rr;
                rr = AddRoomViewModel.AddRoom(RoomNameTextBox.Text, capacity);

                switch (rr)
                {
                    case RequestResult.Success:
                        this.Response.Redirect("AdminRoomList.aspx");
                        return;
                    case RequestResult.AccessDenied:
                        this.Response.Write("<script type='text/javascript'>");
                        this.Response.Write("alert('Du har ikke rettighed til at gøre dette.');");
                        this.Response.Write("window.location.href='AddRoom.aspx';");
                        this.Response.Write("</script>");
                        this.Response.Flush();
                        return;
                    default:
                        this.Response.Write("<script type='text/javascript'>");
                        this.Response.Write("alert('Der skete en fejl.');");
                        this.Response.Write("window.location.href='AddRoom.aspx';");
                        this.Response.Write("</script>");
                        this.Response.Flush();
                        return;
                }
            }

            this.Response.Write("<script type='text/javascript'>");
            this.Response.Write("alert('Kapacitet skal være et tal.');");
            this.Response.Write("window.location.href='AddRoom.aspx';");
            this.Response.Write("</script>");
            this.Response.Flush();
        }
    }
}
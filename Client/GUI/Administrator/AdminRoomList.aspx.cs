namespace Client.GUI.Administrator
{
    using System;
    using System.Web.UI.WebControls;

    using Client.ViewModel;
    using Client.ViewModel.Administrator;

    public partial class AdminRoomList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DeleteRoomButton.OnClientClick = "return confirmRoomDeletion()";
            if (!IsPostBack)
            {
                this.AdminRoomGridView.DataSource = AdminRoomListViewModel.GetAdminRooms();
                this.AdminRoomGridView.DataBind();
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            AdminRoomListViewModel.UpdateAdminRoomGrid(this.AdminRoomGridView);
        }

        protected void ChangeRoomButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EditRoom.aspx");
        }

        protected void AddRoomButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("AddRoom.aspx");
        }

        protected void DeleteRoomButton_Click(object sender, EventArgs e)
        {
            if (this.AdminRoomGridView.SelectedIndex == -1)
            {
                Response.Write("<script type='text/javascript'>alert('Du har ikke valgt et lokale.')</script>");
                Response.Flush();
                return;
            }

            if (!AdminRoomListViewModel.DeleteRoom(this.AdminRoomGridView.SelectedIndex))
            {
                Response.Write("<script type='text/javascript'>alert('Kunne ikke udføre handlingen')</script>");
                Response.Flush();
                return;
            }

            this.Response.Redirect("AdminRoomList.aspx");
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.AdminRoomGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
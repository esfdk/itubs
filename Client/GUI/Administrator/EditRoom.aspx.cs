namespace Client.GUI.Administrator
{
    using System;
    using System.Drawing;
    using System.Web.UI.WebControls;

    using Client.ViewModel.Administrator;

    public partial class EditRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var roomID = 1;
                this.RoomNameTextBox.Text = "2A12";
                this.CapacityTextBox.Text = "30";

                this.EditRoomGridView.DataSource = EditRoomViewModel.GetRoomInventory(roomID);
                this.EditRoomGridView.DataBind();
                //EditRoomGridView.SelectedIndex = 0;
            }

            if (this.EditRoomGridView.SelectedIndex > -1)
            {
                AddRemoveButton.Text = this.EditRoomGridView.Rows[this.EditRoomGridView.SelectedIndex].BackColor == Color.LightGray ? "Fjern Udstyr" : "Tilføj Udstyr";
            }
            else
            {
                AddRemoveButton.Text = "Tilføj Udstyr";
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            EditRoomViewModel.UpdateRoomInventoryGrid(this.EditRoomGridView);
        }

        protected void AddRemoveButton_Click(object sender, EventArgs e)
        {

        }

        protected void FinishButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("AdminRoomList.aspx");
        }

        protected void KapacitetTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.EditRoomGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
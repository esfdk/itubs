namespace Client.GUI.Administrator
{
    using System;
    using System.Drawing;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class ÆndreLokale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var roomID = 1;
                LokaleNavnTextBox.Text = "2A12";
                KapacitetTextBox.Text = "30";

                GridView1.DataSource = DataTables.GetRoomInventory(roomID);
                GridView1.DataBind();
                //GridView1.SelectedIndex = 0;
            }

            if (GridView1.SelectedIndex > -1)
            {
                AddRemoveButton.Text = GridView1.Rows[GridView1.SelectedIndex].BackColor == Color.LightGray ? "Fjern Udstyr" : "Tilføj Udstyr";
            }
            else
            {
                AddRemoveButton.Text = "Tilføj Udstyr";
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DataTables.UpdateRoomInventoryGrid(GridView1);
        }

        protected void AddRemove_Click(object sender, EventArgs e)
        {

        }

        protected void Afslut_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("SuperLokaleListe.aspx");
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
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
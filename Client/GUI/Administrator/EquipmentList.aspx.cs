namespace Client.GUI.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    using Client.ViewModel;
    using Client.ViewModel.Administrator;

    public partial class EquipmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var temporaryList = new List<string> { "Alle" };
            EquipmentListTypeDropDown.DataSource = temporaryList;
            EquipmentListTypeDropDown.DataBind();
            this.EquipmentListGridView.DataSource = EquipmentListViewModel.GetSuperEquipment();
            this.EquipmentListGridView.DataBind();
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            EquipmentListViewModel.UpdateSuperEquipment(this.EquipmentListGridView);
        }

        protected void ChangeEquipmentButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EditEquipment.aspx");
        }

        protected void AddEquipmentButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EquipmentList.aspx");
        }

        protected void DeleteEquipmentButton_Click(object sender, EventArgs e)
        {
            if (0 < 1)
            {
                string popUpText = "Er du sikker på du ville slet 'udstyr X' fra udstyrslisten?.";
                this.Response.Write(String.Format("<script>alert('{0}');</script>", popUpText));
            }
            this.Response.Redirect("EquipmentList.aspx");
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.EquipmentListGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}

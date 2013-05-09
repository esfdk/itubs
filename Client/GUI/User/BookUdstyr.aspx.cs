namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class BookUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UdstyrsTypeDropDown.DataSource = DataTables.GetEquipmentTypes();
            UdstyrsTypeDropDown.DataBind();
            if (Request.QueryString["typeIndex"] != null)
            {
                int index;
                this.UdstyrsTypeDropDown.SelectedIndex = int.TryParse(this.Request.QueryString["typeIndex"], out index) ? index : 0;
            }
            else
            {
                UdstyrsTypeDropDown.SelectedIndex = 0;
            }

            if (Request.QueryString["bookingID"] != null)
            {
                if (UdstyrsTypeDropDown.SelectedValue.Equals("Alle"))
                {
                    this.GridView1.DataSource = DataTables.GetBookEquipment(null);
                }
                else
                {
                    DataTables.GetBookEquipment(UdstyrsTypeDropDown.SelectedValue);
                }

                this.GridView1.DataBind();
            }
            else
            {
                this.Response.Redirect("DineBookinger.aspx");
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            int bookingID;
            if (int.TryParse(Request.QueryString["bookingID"], out bookingID))
            {
                DataTables.UpdateBookEquipmentGrid(GridView1, bookingID);
            }
            else
            {
                this.Response.Redirect("DineBookinger.aspx");
            }
        }

        protected void SelectedTypeChanged(object sender, EventArgs e)
        {
        }

        protected void FortrydButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
        }

        protected void ÆndringerButton_Click(object sender, EventArgs e)
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
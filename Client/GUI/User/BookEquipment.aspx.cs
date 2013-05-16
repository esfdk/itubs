namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.ViewModel;
    using Client.ViewModel.User;

    public partial class BookEquipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EquipmentTypeDropDown.DataSource = BookEquipmentViewModel.GetEquipmentTypes();
            this.EquipmentTypeDropDown.DataBind();
            if (Request.QueryString["typeIndex"] != null)
            {
                int index;
                this.EquipmentTypeDropDown.SelectedIndex = int.TryParse(this.Request.QueryString["typeIndex"], out index) ? index : 0;
            }
            else
            {
                this.EquipmentTypeDropDown.SelectedIndex = 0;
            }

            if (Request.QueryString["bookingID"] != null)
            {
                if (this.EquipmentTypeDropDown.SelectedValue.Equals("Alle"))
                {
                    this.BookEquipmentGridView.DataSource = BookEquipmentViewModel.GetBookEquipment(null);
                }
                else
                {
                    BookEquipmentViewModel.GetBookEquipment(this.EquipmentTypeDropDown.SelectedValue);
                }

                this.BookEquipmentGridView.DataBind();
            }
            else
            {
                this.Response.Redirect("YourBookings.aspx");
            }
        }

        protected void BookEquipmentGridView_OnDataBound(object sender, EventArgs e)
        {
            int bookingID;
            if (int.TryParse(Request.QueryString["bookingID"], out bookingID))
            {
                BookEquipmentViewModel.UpdateBookEquipmentGrid(this.BookEquipmentGridView, bookingID);
            }
            else
            {
                this.Response.Redirect("YourBookings.aspx");
            }
        }

        protected void SelectedTypeChanged(object sender, EventArgs e)
        {
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("YourBookings.aspx");
        }

        protected void SaveChangesButton_Click(object sender, EventArgs e)
        {

        }

        protected void BookEquipmentGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.BookEquipmentGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
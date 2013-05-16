namespace Client.GUI.Administrator
{
    using System;
    using System.Web.UI.WebControls;

    using Client.ViewModel;
    using Client.ViewModel.Administrator;

    public partial class BookingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.BookingListGridView.DataSource = BookingListViewModel.GetPendingBookings();
                this.BookingListGridView.DataBind();
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            BookingListViewModel.UpdatePendingGrid(this.BookingListGridView);
        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("BookingList.aspx");
        }

        protected void RejectButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("BookingList.aspx");
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.BookingListGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
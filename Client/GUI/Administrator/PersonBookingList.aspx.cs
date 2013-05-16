namespace Client.GUI.Administrator
{
    using System;
    using System.Web.UI.WebControls;

    using Client.ViewModel.Administrator;

    public partial class PersonBookingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pIDstring = Request.QueryString["personID"];
            if (pIDstring != null)
            {
                var personID = int.Parse(pIDstring);
                this.PersonBookingListGridView.DataSource = PersonBookingListViewModel.GetFindBookings(personID);
            }
            else
            {
                this.PersonBookingListGridView.DataSource = PersonBookingListViewModel.GetFindBookings(0);
            }

            this.PersonBookingListGridView.DataBind();
        }

        protected void FindBookingsButton_Click(object sender, EventArgs e)
        {
            var person = PersonBookingListViewModel.GetPersonByMail(EmailTextBox.Text);

            if (person != null)
            {
                this.Response.Redirect("PersonBookingList.aspx?personID=" + person.ID);
                return;
            }

            Response.Write("<script type='text/javascript'>alert('Personen kunne ikke findes.')</script>");
            Response.Flush();

        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            PersonBookingListViewModel.UpdateFindBookingsGrid(this.PersonBookingListGridView);
        }

        protected void ApproveBookingButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("PersonBookingList.aspx");
        }

        protected void RejectBookingButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("PersonBookingList.aspx");
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.PersonBookingListGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
namespace Client.GUI.Administrator
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Types;
    using Client.ViewModel.Administrator;

    public partial class PersonBookingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pIDstring = Request.QueryString["personID"];
            if (pIDstring != null)
            {
                int personID;
                if (int.TryParse(pIDstring, out personID))
                {
                    this.PersonBookingListGridView.DataSource = PersonBookingListViewModel.GetUserPendingBookings(personID);
                }
                else
                {
                    this.Response.Redirect("PersonBookingList.aspx");
                }
            }
            else
            {
                this.PersonBookingListGridView.DataSource = PersonBookingListViewModel.GetAllPendingBookings();
            }

            this.PersonBookingListGridView.DataBind();
        }

        protected void FindBookingsButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                this.Response.Redirect("PersonBookingList.aspx?personID=" + -1);
                return;
            }

            var person = PersonBookingListViewModel.GetPersonByMail(EmailTextBox.Text);

            if (person != null)
            {
                this.Response.Redirect("PersonBookingList.aspx?personID=" + person.ID);
                return;
            }

            this.Response.Write("<script type='text/javascript'>");
            this.Response.Write("alert('Personen kunne ikke findes.');");
            this.Response.Write("window.location.href='PersonBookingList.aspx';");
            this.Response.Write("</script>");
            this.Response.Flush();
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            PersonBookingListViewModel.UpdatePendingBookingsGrid(this.PersonBookingListGridView);
        }

        protected void ApproveBookingButton_Click(object sender, EventArgs e)
        {
            var rs = PersonBookingListViewModel.ApproveBooking(PersonBookingListGridView.SelectedIndex);
            switch (rs)
            {
                case RequestResult.Success:
                    this.Response.Redirect("PersonBookingList.aspx");
                    return;
                case RequestResult.AccessDenied:
                    this.Response.Write("<script type='text/javascript'>");
                    this.Response.Write("alert('Du har ikke rettighed til at gøre dette.');");
                    this.Response.Write("window.location.href='PersonBookingList.aspx';");
                    this.Response.Write("</script>");
                    this.Response.Flush();
                    return;
                case RequestResult.InvalidInput:
                    this.Response.Write("<script type='text/javascript'>");
                    this.Response.Write("alert('Systemet sendte forkert input til serveren.');");
                    this.Response.Write("window.location.href='PersonBookingList.aspx';");
                    this.Response.Write("</script>");
                    this.Response.Flush();
                    return;
                default:
                    this.Response.Write("<script type='text/javascript'>");
                    this.Response.Write("alert('Der skete en fejl.');");
                    this.Response.Write("window.location.href='PersonBookingList.aspx';");
                    this.Response.Write("</script>");
                    this.Response.Flush();
                    return;
            }
        }

        protected void RejectBookingButton_Click(object sender, EventArgs e)
        {
            var rs = PersonBookingListViewModel.RejectBooking(PersonBookingListGridView.SelectedIndex);
            switch (rs)
            {
                case RequestResult.Success:
                    this.Response.Redirect("PersonBookingList.aspx");
                    return;
                case RequestResult.AccessDenied:
                    this.Response.Write("<script type='text/javascript'>");
                    this.Response.Write("alert('Du har ikke rettighed til at gøre dette.');");
                    this.Response.Write("window.location.href='PersonBookingList.aspx';");
                    this.Response.Write("</script>");
                    this.Response.Flush();
                    return;
                default:
                    this.Response.Write("<script type='text/javascript'>");
                    this.Response.Write("alert('Der skete en fejl.');");
                    this.Response.Write("window.location.href='PersonBookingList.aspx';");
                    this.Response.Write("</script>");
                    this.Response.Flush();
                    return;
            }
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
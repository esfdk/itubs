namespace Client.GUI.Administrator
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class PersonBookingListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pIDstring = Request.QueryString["personID"];
            if (pIDstring != null)
            {
                var personID = int.Parse(pIDstring);
                GridView1.DataSource = DataTables.GetFindBookings(personID);
            }
            else
            {
                GridView1.DataSource = DataTables.GetFindBookings(0);
            }

            GridView1.DataBind();
        }

        protected void FindBookinger_Click(object sender, EventArgs e)
        {
            var person = DataTables.GetPersonByMail(EmailTextBox.Text);

            if (person != null)
            {
                this.Response.Redirect("PersonBookingListe.aspx?personID=" + person.ID);
                return;
            }

            Response.Write("<script type='text/javascript'>alert('Personen kunne ikke findes.')</script>");
            Response.Flush();

        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DataTables.UpdateFindBookingsGrid(this.GridView1);
        }

        protected void GodkendBooking_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("PersonBookingListe.aspx");
        }

        protected void AfvisBooking_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("PersonBookingListe.aspx");
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
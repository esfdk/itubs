namespace Client.GUI.User
{
    using System;
    using System.Drawing;
    using System.Web.UI.WebControls;

    using Client.ViewModel;
    using Client.ViewModel.User;

    public partial class CateringList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                int bookingID;
                if (int.TryParse(Request.QueryString["bookingID"], out bookingID))
                {
                    this.CateringListGridView.DataSource = CateringListViewModel.GetCaterings(bookingID);
                    this.CateringListGridView.DataBind();
                }
                else
                {
                    this.Response.Redirect("~/GUI/User/YourBookings.aspx");
                }
            }
        }

        protected void AddCateringButton_Click(object sender, EventArgs e)
        {
            var checkedMoreThanOne = false;
            var naN = false;

            for (var i = 0; i < CateringListGridView.Rows.Count; i++)
            {
                var row = CateringListGridView.Rows[i];

                if (CateringListViewModel.RowChanged(row))
                {
                    if (CateringListViewModel.NumberOfCheckedElementInRow(row) == 0 && row.BackColor == Color.LightGray)
                    {
                        if (!CateringListViewModel.DeleteCateringChoice(i))
                        {
                            this.Response.Write("<script>alert('Dit forplejningsvalg kunne ikke slettes.');</script>");
                            this.Response.Flush();
                        }
                    }
                    else if (CateringListViewModel.NumberOfCheckedElementInRow(row) > 1)
                    {
                        checkedMoreThanOne = true;
                    }
                    else if (CateringListViewModel.NumberOfCheckedElementInRow(row) == 1)
                    {
                        int amount;
                        if (int.TryParse(row.Cells[13].Text, out amount))
                        {
                            naN = true;
                        }
                        else
                        {
                            if (!CateringListViewModel.CreateOrUpdateCateringChoice(row, int.Parse(Request.QueryString["bookingID"]), i, amount))
                            {
                                this.Response.Write("<script>alert('Dit forplejningsvalg kunne oprettes/ændres.');</script>");
                                this.Response.Flush();
                            }
                        }
                    }
                }
            }

            if (naN)
            {
                this.Response.Write("<script>alert('Et af dine ønsker kunne ikke imødekommes, da antal ikke kunne læses som et tal.');</script>");
                this.Response.Flush();
            }

            if (checkedMoreThanOne)
            {
                this.Response.Write("<script>alert('Et af dine ønsker kunne ikke imødekommes, da du har valgt flere tidspunkter på dagen."
                                            + "\n Lav seperate valg for forskellige tidspunkter.');</script>");
                this.Response.Flush();
            }

            /*
            // If number of items are over 10 check if Date is atleast a week from now, else throw alert popup

            if (0 < 1)
            {
                this.Response.Write("<script>alert('Dine ønsker kunne ikke imødekommes, da der skal bestilles mindst en uge i forvejen til forplejning til mere end 10 personer.');</script>");
                this.Response.Flush();
                return;
            }*/

            this.Response.Redirect("~/GUI/User/CateringList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/GUI/User/YourBookings.aspx");
        }

        protected void DeleteCateringButton_Click(object sender, EventArgs e)
        {

        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            CateringListViewModel.UpdateCateringGrid(this.CateringListGridView);
        }

        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.CateringListGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
namespace Client.GUI.User
{
    using System;
    using System.Web.UI.WebControls;

    using Client.Model;

    public partial class Forplejning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                int bookingID;
                if (int.TryParse(Request.QueryString["bookingID"], out bookingID))
                {
                    this.GridView1.DataSource = DataTables.GetCaterings(bookingID);
                    this.GridView1.DataBind();
                }
                else
                {
                    this.Response.Write("<script>alert('{Der skete en fejl.}');</script>");
                    this.Response.Redirect("DineBookinger.aspx");
                }
            }
        }

        protected void ForplejningButton_Click(object sender, EventArgs e)
        {
            // If number of items are over 10 check if Date is atleast a week from now, else throw alert popup
            if (0 < 1)
            {
                string popUpText = "Dine ønsker kunne ikke imøde kommes da der skal bestilles mindst en uge i forvejen til forplejning til mere end 10 personer.";
                this.Response.Write(String.Format("<script>alert('{0}');</script>", popUpText));
            }
            this.Response.Redirect("DineBookinger.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            DataTables.UpdateCateringGrid(GridView1);
        }

        protected void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
        }

        protected void Fortryd_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
        }

        protected void SletForplejningButton_Click(object sender, EventArgs e)
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
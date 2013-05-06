namespace Client.GUI.User
{
    using System;

    using Client.Model;

    public partial class Forplejning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                var bookingIDstring = Request.QueryString["bookingID"];
                var bookingID = int.Parse(bookingIDstring);
                this.GridView1.DataSource = DataTables.GetCaterings(bookingID);
                this.GridView1.DataBind();
            }
        }

        protected void ForplejningButton_Click(object sender, EventArgs e)
        {
            // If number of items are over 10 check if Date is atleast a week from now, else throw alert popup
            if (0 < 1)
            {
                string popUpText = "Dine ønsker kunne ikke imøde kommes da der skal bestilles mindst en uge i forvejen til forplejning til mere end 10 personer.";
                //The line below will launch a Javascript alert that says "The Value is Testing Value"
                this.Response.Write(String.Format("<script>alert('{0}');</script>", popUpText));
            }
            this.Response.Redirect("DineBookinger.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
        }

        protected void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
            Response.Redirect()
        }

        protected void Fortryd_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("DineBookinger.aspx");
        }
    }
}
using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace Client.User
{
    public partial class Forplejning : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DataTable originalDataTable = new DataTable();
                DataRow newDataRow = originalDataTable.NewRow();
                originalDataTable.Rows.Add(newDataRow);

                GridView1.DataSource = originalDataTable;
                GridView1.DataBind();
            }
        }

        protected void ForplejningButton_Click(object sender, EventArgs e)
        {
            // If number of items are over 10 check if Date is atleast a week from now, else throw alert popup
          if (0 < 1)
            {
                string popUpText = "Dine ønsker kunne ikke imøde kommes da der skal bestilles mindst en uge i forvejen til forplejning til mere end 10 personer.";
                //The line below will launch a Javascript alert that says "The Value is Testing Value"
                Response.Write(String.Format("<script>alert('{0}');</script>", popUpText));
            }
            Response.Redirect("DineBookinger.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
            GridView1.Rows[0].Cells[0].Text = "Frederik jeg hader dig";
            
            /*CheckBox cb = GridView1.Rows[0].Cells[2].FindControl("checkBox9") as CheckBox;
            cb.CheckedChanged += CheckBox_CheckChanged;
            cb.Checked = true;*/
        }

        protected void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            Response.Redirect("DineBookinger.aspx");
        }

        protected void Fortryd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DineBookinger.aspx");
        }
    }
}
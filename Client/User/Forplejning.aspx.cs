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
            if(Page.IsValid){
                CheckBox cb = GridView1.Rows[0].FindControl("checkBox9") as CheckBox;
                if (cb.Checked)
                {
                 GridView1.Rows[0].Cells[2].BackColor = Color.Black;
                }
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

        protected void FjernForplejning_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                CheckBox cb = GridView1.Rows[0].FindControl("checkBox9") as CheckBox;
                if (cb.Checked)
                {
                    string popUpText = "";
                    //The line below will launch a Javascript alert that says "The Value is Testing Value"
                    Response.Write(String.Format("<script>alert('{0}');</script>", popUpText));
                }
            }
        }
    }
}
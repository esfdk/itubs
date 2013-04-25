using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace BookIT
{
    public partial class Forplejning : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DataTable originalDataTable = new DataTable();
                DataTable newDataTable = originalDataTable.Clone();
                DataRow newDataRow = newDataTable.NewRow();
                newDataTable.Rows.Add(newDataRow);

                GridView1.DataSource = newDataTable;
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
                    string yourValue = "Klokken 9 er nu booket";
                    //The line below will launch a Javascript alert that says "The Value is Testing Value"
                    Response.Write(String.Format("<script>alert('{0}');</script>", yourValue));
                }
            }
        }
    }
}
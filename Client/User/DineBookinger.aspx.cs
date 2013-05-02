using System;
using System.Web.UI.WebControls;
using System.Data;

namespace Client.User
{
    public partial class DineBookinger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable originalDataTable = new DataTable();
                DataTable newDataTable = originalDataTable.Clone();
                DataRow newDataRow = newDataTable.NewRow();
                DataRow newDataRow1 = newDataTable.NewRow();
                DataRow newDataRow2 = newDataTable.NewRow();
                newDataTable.Rows.Add(newDataRow);
                newDataTable.Rows.Add(newDataRow1);
                newDataTable.Rows.Add(newDataRow2);

                GridView1.DataSource = newDataTable;
                GridView1.DataBind();
            }
        }

        protected void GridView_OnDataBound(object sender, EventArgs e)
        {
          
            GridView1.Rows[0].Cells[0].Text = "2A12";
            GridView1.Rows[0].Cells[1].Text = "30";
            GridView1.Rows[0].Cells[2].Text = "09:00-12:00";
            GridView1.Rows[0].Cells[3].Text = "Godkendt";
            GridView1.Rows[0].Cells[5].Text = "Projektor";
            GridView1.Rows[1].Cells[0].Text = "3A14";
            GridView1.Rows[1].Cells[1].Text = "30";
            GridView1.Rows[1].Cells[2].Text = "09:00-12:00";
            GridView1.Rows[1].Cells[3].Text = "Godkendt";
            GridView1.Rows[1].Cells[5].Text = "Projektor";
            GridView1.Rows[2].Cells[0].Text = "Audi2";
            GridView1.Rows[2].Cells[1].Text = "30";
            GridView1.Rows[2].Cells[2].Text = "09:00-12:00";
            GridView1.Rows[2].Cells[3].Text = "Godkendt";
            GridView1.Rows[2].Cells[5].Text = "Projektor";


        }

        protected void UdstyrButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookUdstyr.aspx");
        }

        protected void ÆndreBookButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LokaleListe.aspx");
        }

        protected void SletBookingButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DineBookinger.aspx");
        }

        protected void ForplejningButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forplejning.aspx");
        }

        protected void SendGodkendButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DineBookinger.aspx");
        }

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("style", "cursor:pointer;");
                e.Row.Attributes.Add("onclick", "location='Forplejning.aspx?id=" + e.Row.Cells[0].Text + "'");
                    /*Page.ClientScript.GetPostBackEventReference(this,
                              "Select$" + e.Row.RowIndex.ToString()));*/
            }
        }
    }
}
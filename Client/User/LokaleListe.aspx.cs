using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client.User
{
    public partial class LokaleListe : System.Web.UI.Page
    {
        [Serializable()]
        private class Row
        {
            public string Lokale { get; set; }
            public string Kapacitet { get; set; }
            public string Udstyr { get; set; }
            public CheckBoxTemplate tf1 { get; set; }
        }

        private class CheckBoxTemplate : ITemplate
        {
            private string ID = "testID";
            private string Text = "testText";

            public CheckBoxTemplate(string ID, string Text)
            {
                this.ID = ID;
                this.Text = Text;
            }

            public void InstantiateIn(System.Web.UI.Control container)
            {
                CheckBox cb = new CheckBox();
                cb.ID = ID;
                cb.Text = Text;
                container.Controls.Add(cb);
            }
        }


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

        protected void BookLokaleButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/DineBookinger.aspx");
        }
        protected void gvSummary_PreRender(object sender, EventArgs e)
        {
        }


    }
}

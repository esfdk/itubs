using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookIT
{
    public partial class _Default : System.Web.UI.Page
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


            List<Row> l = new List<Row>();

            l.Add(new Row
            {
                tf1 = new CheckBoxTemplate("ID:1", "")

            });      
            
            GridView1.DataSource = l;
            var tf = new TemplateField();
            tf.ItemTemplate = new CheckBoxTemplate("ID:1", "");
            GridView1.Columns.Add(tf);
            GridView1.DataBind();

            

            
            
            /*GridView1.HeaderRow.Cells[3].Text = "09:00";
            GridView1.HeaderRow.Cells[4].Text = "10:00";
            GridView1.HeaderRow.Cells[5].Text = "11:00";
            GridView1.HeaderRow.Cells[6].Text = "12:00";
            GridView1.HeaderRow.Cells[7].Text = "13:00";
            GridView1.HeaderRow.Cells[8].Text = "14:00";
            GridView1.HeaderRow.Cells[9].Text = "15:00";
            GridView1.HeaderRow.Cells[10].Text = "16:00";
            GridView1.HeaderRow.Cells[11].Text = "17:00";
            GridView1.HeaderRow.Cells[12].Text = "18:00";
            GridView1.HeaderRow.Cells[13].Text = "19:00";
            GridView1.HeaderRow.Cells[14].Text = "20:00";
            //GridView1.HeaderRow.Cells[15].Text = "21:00";*/

           
            
            
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

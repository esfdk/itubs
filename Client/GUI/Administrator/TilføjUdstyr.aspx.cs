namespace Client.GUI.Administrator
{
    using System;

    public partial class Tilf�jUdstyr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Tilf�jUdstyr_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("�ndreLokale.aspx");
        }
    }
}
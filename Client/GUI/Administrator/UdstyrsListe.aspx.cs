namespace Client.GUI.Administrator
{
    using System;

    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void �ndreUdstyrButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("�ndreUdstyr.aspx");
        }

        protected void Tilf�jUdstyrButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UdstyrsListe.aspx");
        }

        protected void SletUdstyrButton_Click(object sender, EventArgs e)
        {
            if (0 < 1)
            {
                string popUpText = "Er du sikker p� du ville slet 'udstyr X' fra udstyrslisten?.";
                //The line below will launch a Javascript alert that says "The Value is Testing Value"
                this.Response.Write(String.Format("<script>alert('{0}');</script>", popUpText));
            }
            this.Response.Redirect("UdstyrsListe.aspx");
        }

        protected void Udl�nCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

namespace Client.GUI.Administrator
{
    using System;

    public partial class EditEquipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveChangesButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EquipmentList.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EquipmentList.aspx");
        }
    }
}
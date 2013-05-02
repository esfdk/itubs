using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookIT
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["me"] = "lol";
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            LoginName loginName = HeadLoginView.FindControl("HeadLoginName") as LoginName;

            if (loginName != null)
            {
                loginName.FormatString = "Jakob Melnyk";
            }
        }
    }
}

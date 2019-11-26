using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonLogout_Click(object sender, EventArgs e)
        {
            Session["EMAILADDRESS"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}
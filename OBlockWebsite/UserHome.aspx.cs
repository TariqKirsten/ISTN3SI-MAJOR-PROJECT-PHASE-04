using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["EMAILADDRESS"] !=null )
            {
                buttonLogout.Visible = true;
            }
            else
            {
                buttonLogout.Visible = false;
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void buttonLogout_Click(object sender, EventArgs e)
        {
            Session["EMAILADDRESS"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}
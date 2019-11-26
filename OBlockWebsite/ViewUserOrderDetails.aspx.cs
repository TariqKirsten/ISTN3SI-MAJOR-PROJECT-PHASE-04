using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite
{
    public partial class ViewUserOrderDetails : System.Web.UI.Page
    {
        string saleID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SaleID"] == null)
            {
                Response.Redirect("ManageOrders.aspx");
            }
            saleID = Session["SaleID"].ToString();

            if (!IsPostBack)
            {
                bindDetailsRepeaters();
            }

        }

        private void bindDetailsRepeaters()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            repeaterOrders.DataSource = repeaterOrderDS;
            repeaterOrders.DataBind();
            



        }

       
    }
}
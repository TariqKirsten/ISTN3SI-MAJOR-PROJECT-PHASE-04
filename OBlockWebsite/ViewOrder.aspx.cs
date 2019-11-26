using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        string saleID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["SaleID"]==null)
            {
                Response.Redirect("ManageOrders.aspx");
            }
            saleID = Session["SaleID"].ToString();

            if(!IsPostBack)
            {
                bindDetailsRepeaters();
            }
            
        }

        private void bindDetailsRepeaters()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                            
                        repeaterOrders.DataSource = repeaterOrderDS;
                        repeaterOrders.DataBind();
            repeaterCustomerInfo.DataSource = repeaterCustomerInfoDS;
            repeaterCustomerInfo.DataBind();
                
    
            
        }

        protected void buttonMarkOrderComplete_Click(object sender, EventArgs e)
        {
            SqlDSOrderComplete.Update();
            orderCompleteStatus.Text = "Order Marked As Complete!";
        }
    }

  
}
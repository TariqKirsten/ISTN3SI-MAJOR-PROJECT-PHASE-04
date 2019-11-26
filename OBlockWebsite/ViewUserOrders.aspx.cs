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
    public partial class ViewUserOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["EMAILADDRESS"]==null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindOrdersRepeater();
            }
        }

        private void BindOrdersRepeater()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from SALE where isCompleted=0 and cust_ID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Session["UserIDNumber"]);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        repeaterOrders.DataSource = dt;
                        repeaterOrders.DataBind();
                    }
                }

            }
        }

        protected void linkButtonViewDetails_Click(object sender, EventArgs e)
        {
            Session["SaleID"] = (sender as LinkButton).CommandArgument;
            Response.Redirect("ViewUserOrderDetails.aspx");
        }
    }
}

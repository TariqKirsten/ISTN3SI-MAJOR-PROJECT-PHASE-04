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
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                BindProductsRepeater();
            }
        }

        private void BindProductsRepeater()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from PRODUCT", conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        repeaterProducts.DataSource = dt;
                        repeaterProducts.DataBind();
                    }
                }

            }

        }

        protected void linkButtonEdit_Click(object sender, EventArgs e)
        {
            string ID = (sender as LinkButton).CommandArgument;
            Session["ProductID"] = ID;
            Response.Redirect("EditProduct.aspx");
        }

        protected void linkButtonAddStock_Click(object sender, EventArgs e)
        {
            string ID = (sender as LinkButton).CommandArgument;
            Session["ProductID"] = ID;
            
            Response.Redirect("AddStock.aspx");
        }
    }
}
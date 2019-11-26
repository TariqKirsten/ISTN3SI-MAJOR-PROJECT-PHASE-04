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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductRepeater();
                populateDDL();

            }
        }

        private void populateDDL()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select distinct product_category from PRODUCT", conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownListCategory.Items.Add(new ListItem((string)dt.Rows[i]["product_category"]));
                }

                DropDownListCategory.Items.Add(new ListItem("All Products"));
                DropDownListCategory.SelectedIndex = DropDownListCategory.Items.Count - 1; //last item "None"

            }
        }

        private void BindProductRepeater()
        {

            repeaterProducts.DataSource = SqlDSProductInfo;
            repeaterProducts.DataBind();

        }

        protected void productThumbnailClick(object sender, EventArgs e)
        {
            Session["ProductID"] = (sender as LinkButton).CommandArgument;
            Response.Redirect("ViewProduct.aspx");

        }

        protected void DropDownListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //  SqlDSProductInfo.SelectCommand = "SELECT product_name, product_description, product_price, product_image_path, product_ID  FROM PRODUCT  where product_quantity != -1 and product_category=@cat ";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT product_name, product_description, product_price, product_image_path, product_ID  FROM PRODUCT  where product_quantity != -1 and product_category=@cat ", conn);

                if (DropDownListCategory.SelectedValue=="All Products")
                {
                     cmd = new SqlCommand("SELECT product_name, product_description, product_price, product_image_path, product_ID  FROM PRODUCT  where product_quantity != -1", conn);

                }
                else
                {
                   cmd = new SqlCommand("SELECT product_name, product_description, product_price, product_image_path, product_ID  FROM PRODUCT  where product_quantity != -1 and product_category=@cat ", conn);
                   cmd.Parameters.AddWithValue("@cat", DropDownListCategory.SelectedValue);
                }
                
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                repeaterProducts.DataSource = dt;
                repeaterProducts.DataBind();
                
            }
        }
    }
}
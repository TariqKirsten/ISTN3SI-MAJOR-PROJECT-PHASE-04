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
    public partial class AddStock : System.Web.UI.Page
    {
        int supplierID;
        int productID; 
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["EMAILADDRESS"]==null)
            {
                Response.Redirect("Login.aspx");
            }

            productID = Int32.Parse(Session["ProductID"].ToString());
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT PRODUCT.product_ID, SUPPLIER.supplier_name, SUPPLIER.supplier_ID, PRODUCT_SUPPLIER.date_supplied FROM   PRODUCT INNER JOIN PRODUCT_SUPPLIER ON PRODUCT.product_ID = PRODUCT_SUPPLIER.product_ID INNER JOIN SUPPLIER ON PRODUCT_SUPPLIER.supplier_ID = SUPPLIER.supplier_ID WHERE(PRODUCT.product_ID = @Product_ID)ORDER BY PRODUCT_SUPPLIER.date_supplied DESC", conn);
                cmd.Parameters.AddWithValue("@Product_ID", Int32.Parse(Session["ProductID"].ToString()));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);

                supplierID = (int)dt.Rows[0]["supplier_ID"];
                
                string supplierName = (string)dt.Rows[0]["supplier_name"];

                textboxSupplier.Text = supplierName;
                
            }
        }

        protected void buttonAddStock_Click(object sender, EventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Update Product set product_quantity+=@quantity ,cost_price_per_unit=@cppu", conn);
                cmd.Parameters.AddWithValue("@quantity", Int32.Parse(textboxStockToAdd.Text));
                cmd.Parameters.AddWithValue("@cppu", Decimal.Parse(textboxCPPU.Text));
                conn.Open();
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into PRODUCT_SUPPLIER(product_ID,supplier_ID,date_supplied,quantity_supplied,cost_price) Values (@pID,@sID,@date,@quantity,@cppu)", conn);
                cmd.Parameters.AddWithValue("@pID", productID);
                cmd.Parameters.AddWithValue("@sID", supplierID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@quantity", Int32.Parse(textboxStockToAdd.Text));
                cmd.Parameters.AddWithValue("@cppu", Decimal.Parse(textboxCPPU.Text));

                cmd.ExecuteNonQuery();

                stockUpdateStatus.Text = "Stock Added Successfully!";

            }
        }
    }
}
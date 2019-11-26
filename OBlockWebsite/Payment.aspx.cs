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
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EMAILADDRESS"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack)
            {
                if (checkboxPickup.Checked)
                {
                    textboxContactNumber.Text = "Not Applicable";
                    textboxName.Text = "Not Applicable";
                    textboxPhysicalAddr.Text = "Not Applicable";

                    textboxContactNumber.ReadOnly = true;
                    textboxName.ReadOnly = true;
                    textboxPhysicalAddr.ReadOnly = true;
                }
            }
            else if (!IsPostBack)
            {
                labelCartTotal.Text = Session["CartTotal"].ToString();
                String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("Select cust_name,cust_surname, cust_address, cust_city,cust_suburb,cust_province, cust_number FROM CUSTOMER where cust_email=@email", conn))
                    {
                        cmd.Parameters.AddWithValue("@email", Session["EMAILADDRESS"].ToString());
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        textboxName.Text = (string)dt.Rows[0]["cust_name"] + " " + (string)dt.Rows[0]["cust_surname"];
                        textboxPhysicalAddr.Text = (string)dt.Rows[0]["cust_address"] + "," + (string)dt.Rows[0]["cust_suburb"] + "," + (string)dt.Rows[0]["cust_city"] + "," + (string)dt.Rows[0]["cust_province"];
                        textboxContactNumber.Text = (string)dt.Rows[0]["cust_number"];
                    }
                }
            }

        }

        protected void buttonSubmitOrder_Click(object sender, EventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select customer_ID FROM CUSTOMER where cust_email=@email", conn);

                cmd.Parameters.AddWithValue("@email", Session["EMAILADDRESS"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);

                Int32 custID = ((Int32)dt.Rows[0]["customer_ID"]);
                cmd = new SqlCommand("Insert into SALE(sale_date,total_amount,isOnlineSale,isDelivery,emp_ID,cust_ID,isCompleted) Values (@saledate,@total,@ios,@delivery,@emp,@cust,@completed)", conn);
                cmd.Parameters.AddWithValue("@saledate", DateTime.Today);
                cmd.Parameters.AddWithValue("@total", (decimal)Session["CartTotal"]);
                cmd.Parameters.AddWithValue("@ios", 1);
                if (checkboxPickup.Checked)
                {
                    cmd.Parameters.AddWithValue("@delivery", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@delivery", 1);

                }
                cmd.Parameters.AddWithValue("@emp", 100);
                cmd.Parameters.AddWithValue("@cust", custID);
                cmd.Parameters.AddWithValue("@completed", 0);

                cmd.ExecuteNonQuery();

                DataTable cart = (DataTable)Session["CartItems"];
                //get the saleID
                cmd = new SqlCommand("SELECT TOP 1 * FROM SALE ORDER BY sale_ID DESC", conn);
                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Int32 saleID = (Int32)dt.Rows[0]["sale_ID"];
                cmd = new SqlCommand("Insert into SALE_ITEM(product_ID,sale_ID,item_price,item_quantity,subtotal,cost_price_per_unit) Values(@produID,@saleID,@ip,@iq,@sub,@cppu)",conn);

                for (int i = 0;i<cart.Rows.Count;i++)
                {
                    cmd = new SqlCommand("Insert into SALE_ITEM(product_ID,sale_ID,item_price,item_quantity,subtotal,cost_price_per_unit) Values(@prodID,@saleID,@ip,@iq,@sub,@cppu)", conn);
                    cmd.Parameters.AddWithValue("@prodID", (Int32)cart.Rows[i]["product_ID"]);
                    cmd.Parameters.AddWithValue("@saleID", saleID);
                    cmd.Parameters.AddWithValue("@ip", (Decimal)cart.Rows[i]["product_price"]);
                    cmd.Parameters.AddWithValue("@iq", cart.Rows[i]["quantity"]);
                    cmd.Parameters.AddWithValue("@sub", Decimal.Parse((string)cart.Rows[i]["total"]));
                    cmd.Parameters.AddWithValue("@cppu", (Decimal)cart.Rows[i]["cost_price_per_unit"]);


                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Update PRODUCT set product_quantity -= @quant", conn);
                    cmd.Parameters.AddWithValue("@quant", cart.Rows[i]["quantity"]);
                    cmd.ExecuteNonQuery();

                }
               


                orderStatus.Text = "Order Submitted Successfully!";
                buttonSubmitOrder.Enabled = false;
                buttonSubmitOrder.Visible = false;

                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = null;
                CartProducts.Value = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);

            }
        }
    }
}
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
    public partial class Cart : System.Web.UI.Page
    {
        static DataTable productInfo;
        static decimal cartTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["EMAILADDRESS"]==null)
            {
                Response.Redirect("Login.aspx");
            }

            if(!IsPostBack)
            {
                BindCartProducts(); 
            }
        }

        private void BindCartProducts()
        {
            cartTotal = 0;
            labelCartTotal.Text = cartTotal.ToString();
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
             productInfo = new DataTable();
            productInfo.Columns.Add("quantity");
            productInfo.Columns.Add("total");


            if (Request.Cookies["CartPID"]!=null)
            {
                string cookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] cookieDataArray = cookieData.Split(',');
                if(cookieDataArray.Length>0)
                {
                    for(int i = 0;i< cookieDataArray.Length;i++)
                    {
                        string PID = cookieDataArray[i].ToString().Split('-')[0];

                        string QuantityID = cookieDataArray[i].ToString().Split('-')[1];

                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            using (SqlCommand cmd = new SqlCommand("Select product_ID, cost_price_per_unit, product_name, product_price, product_image_path from PRODUCT where product_ID=@id", conn))
                            {
                                cmd.Parameters.AddWithValue("@id", PID);
                                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                {

                                    da.Fill(productInfo);
                                    productInfo.Rows[i]["quantity"] = Int32.Parse(QuantityID);
                                    productInfo.Rows[i]["total"] = Int32.Parse(QuantityID) *(Decimal) productInfo.Rows[i]["product_price"];

                                }
                            }

                        }
                    }

                    productInfo.Columns[0].ColumnMapping = MappingType.Hidden;
                    productInfo.Columns[1].ColumnMapping = MappingType.Hidden;

                    repeaterCartItems.DataSource = productInfo;
                    repeaterCartItems.DataBind();


                    for(int i= 0;i<productInfo.Rows.Count;i++)
                    {
                        cartTotal = cartTotal + Decimal.Parse((string)productInfo.Rows[i]["total"]);
                    }
                    labelCartTotal.Text = cartTotal.ToString();
                }
            }
        }

        protected void buttonRemoveFromCart_Click(object sender, EventArgs e)
        {
            string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
            Button btn = (Button)(sender);
            string productIDQuantity = btn.CommandArgument;

            List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            CookiePIDList.Remove(productIDQuantity);
            string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
            if (CookiePIDUpdated == "")
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);

            }
            else
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = CookiePIDUpdated;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);

            }
           
            Response.Redirect("~/Cart.aspx");
        }

        protected void buttonBuyNow_Click(object sender, EventArgs e)
        {
            if(Session["EMAILADDRESS"]!=null)
            {
                Session["CartItems"] = productInfo;
                Session["CartTotal"] = cartTotal;
                Response.Redirect("Payment.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            

        }
    }
}
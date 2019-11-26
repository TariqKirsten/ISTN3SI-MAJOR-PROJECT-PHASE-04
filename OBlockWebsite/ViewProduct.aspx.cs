using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        string productID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ProductID"] == null)
            {
                Response.Redirect("Products.aspx");
            }
            productID = Session["ProductID"].ToString();

            if(!IsPostBack)
            {
                BindProductRepeater();
            }
          
        }

        private void BindProductRepeater()
        {
            repeaterProduct.DataSource = SqlDSProductInfo;
            repeaterProduct.DataBind();
        }

        protected void buttonAddToCart_Click(object sender, EventArgs e)
        {
            Label l = null;
            foreach (RepeaterItem item in repeaterProduct.Items)
            {
                 l = (Label)item.FindControl("labelQuantityAvailable");
                if (l !=null)
                {
                    break;
                }
            }
           
            if(Int32.Parse(textboxQuantity.Text)<1 || Int32.Parse(textboxQuantity.Text)>Int32.Parse(l.Text))
            {
                quantityStatus.CssClass = "text-danger";

                textboxQuantity.Text = "1";
                quantityStatus.Text = "Invalid Quantity";
            }
            else
            {
                quantityStatus.CssClass = "text-success";
                quantityStatus.Text = "Added To Cart";


                if(Request.Cookies["CartPID"] !=null)
                {
                    string cookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                    cookiePID = cookiePID + "," + productID;

                    HttpCookie cartProducts = new HttpCookie("CartPID");
                    cartProducts.Values["CartPID"] = cookiePID + "-" + textboxQuantity.Text;
                    cartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cartProducts);
                }
                else
                {
                  HttpCookie cartProducts = new HttpCookie("CartPID");
                    cartProducts.Values["CartPID"] = productID.ToString()+"-"+textboxQuantity.Text;
                    cartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cartProducts);

                }
            }
        }

        protected void textboxQuantity_TextChanged(object sender, EventArgs e)
        {
            quantityStatus.Text = "";
        }
    }
}
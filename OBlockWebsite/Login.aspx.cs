using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace OBlockWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.Cookies["EMAILADDR"] != null && Request.Cookies["PASSWORD"] != null)
                {
                    textboxEmailAddress.Text = Request.Cookies["EMAILADDR"].Value;
                    textboxPassword.Attributes["value"] = Request.Cookies["PASSWORD"].Value;
                    checkboxRememberMe.Checked = true;

                }
            }
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            bool adminLogin = false;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                
                SqlCommand cmd = new SqlCommand("Select * from CUSTOMER where cust_email=@email and cust_password=@password", conn);
                cmd.Parameters.AddWithValue("@email", textboxEmailAddress.Text);
                cmd.Parameters.AddWithValue("@password", textboxPassword.Text);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //checking if we get a filled data table if so then the email address and password combo was right
                if(dt.Rows.Count!=0)
                {
                    adminLogin = false;
                    if (checkboxRememberMe.Checked)
                    {
                        Response.Cookies["EMAILADDR"].Value=textboxEmailAddress.Text;
                        Response.Cookies["PASSWORD"].Value = textboxPassword.Text;

                        Response.Cookies["EMAILADDR"].Expires = DateTime.Now.AddDays(10);
                        Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(10);

                       
                    }
                    else
                    {
                        Response.Cookies["EMAILADDR"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(-1);

                    }
                    Session["EMAILADDRESS"] = textboxEmailAddress.Text;
                    Session["UserIDNumber"] = (int)dt.Rows[0]["customer_ID"];
                    Response.Redirect("Products.aspx");
                }
                else if(dt.Rows.Count==0 && !adminLogin)
                {
                    adminLogin = true;
                    cmd = new SqlCommand("Select * from EMPLOYEE where emp_email=@email and emp_password=@password and emp_type='Manager'", conn);
                    cmd.Parameters.AddWithValue("@email", textboxEmailAddress.Text);
                    cmd.Parameters.AddWithValue("@password", textboxPassword.Text);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count != 0)
                    {
                        
                        if (checkboxRememberMe.Checked)
                        {
                            Response.Cookies["EMAILADDR"].Value = textboxEmailAddress.Text;
                            Response.Cookies["PASSWORD"].Value = textboxPassword.Text;

                            Response.Cookies["EMAILADDR"].Expires = DateTime.Now.AddDays(10);
                            Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(10);


                        }
                        else
                        {
                            Response.Cookies["EMAILADDR"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(-1);

                        }
                        Session["EMAILADDRESS"] = textboxEmailAddress.Text;
                        Response.Redirect("AdminHome.aspx");
                    }
                    else
                    {
                        labelLoginStatus.ForeColor = System.Drawing.Color.Red;
                        labelLoginStatus.Text = "Incorrect Email Address or Password!";
                    }
                }
                else
                {
                    labelLoginStatus.ForeColor = System.Drawing.Color.Red;
                    labelLoginStatus.Text = "Incorrect Email Address or Password!";
                }


            }

        }
    }
}
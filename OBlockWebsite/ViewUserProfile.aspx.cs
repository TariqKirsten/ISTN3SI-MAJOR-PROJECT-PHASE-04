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
    public partial class ViewUserProfile : System.Web.UI.Page
    {
        string userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EMAILADDRESS"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            userID = Session["EMAILADDRESS"].ToString();
            if (!IsPostBack)
            {

                loadUserData();
            }

        }

        private void loadUserData()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select * from CUSTOMER where cust_email=@id", conn);
                cmd.Parameters.AddWithValue("@id", userID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    textboxFName.Text = (string)dt.Rows[0]["cust_name"];
                    textboxLName.Text = (string)dt.Rows[0]["cust_surname"];
                    textboxEmailAddr.Text = (string)dt.Rows[0]["cust_email"];
                    textboxPhysicalAddr.Text = (string)dt.Rows[0]["cust_address"];
                    textboxSuburb.Text = (string)dt.Rows[0]["cust_suburb"];
                    textboxCity.Text = (string)dt.Rows[0]["cust_city"];
                    textboxProvince.Text = (string)dt.Rows[0]["cust_province"];
                    textboxPostalCode.Text = (string)dt.Rows[0]["cust_postal_code"];

                }
            }
        }

        protected void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Update CUSTOMER set cust_name=@fname,cust_surname=@lname, cust_password=@pass,cust_email=@email,cust_address=@address,cust_suburb=@suburb,cust_city=@city,cust_province=@province,cust_postal_code=@pcode where cust_email=@id", conn);
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.Parameters.AddWithValue("@fname", textboxFName.Text);
                cmd.Parameters.AddWithValue("@lname", textboxLName.Text);
                cmd.Parameters.AddWithValue("@email", textboxEmailAddr.Text);
                cmd.Parameters.AddWithValue("@address", textboxPhysicalAddr.Text);
                cmd.Parameters.AddWithValue("@suburb", textboxSuburb.Text);
                cmd.Parameters.AddWithValue("@city", textboxCity.Text);
                cmd.Parameters.AddWithValue("@province", textboxProvince.Text);
                cmd.Parameters.AddWithValue("@pcode", textboxPostalCode.Text);
                if(textboxPassword.Text == textboxConfirmPassword.Text)
                {
                    cmd.Parameters.AddWithValue("@pass", textboxPassword.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    userInformationUpdateStatus.CssClass = "text-success";
                    userInformationUpdateStatus.Text = "User Information Updated Successfully";
                }
                else if(textboxPassword.Text != textboxConfirmPassword.Text)
                {
                    userInformationUpdateStatus.CssClass = "text-danger";
                    userInformationUpdateStatus.Text = "Passwords Do Not Match!";
                }
                else if(textboxPassword.Text.Length==0)
                {
                    SqlCommand cmd2 = new SqlCommand("Update CUSTOMER set cust_name=@fname,cust_surname=@lname,cust_email=@email,cust_address=@address,cust_suburb=@suburb,cust_city=@city,cust_province=@province,cust_postal_code=@pcode where cust_email=@id", conn);
                    cmd.Parameters.AddWithValue("@id", userID);
                    cmd.Parameters.AddWithValue("@fname", textboxFName.Text);
                    cmd.Parameters.AddWithValue("@lname", textboxLName.Text);
                    cmd.Parameters.AddWithValue("@email", textboxEmailAddr.Text);
                    cmd.Parameters.AddWithValue("@address", textboxPhysicalAddr.Text);
                    cmd.Parameters.AddWithValue("@suburb", textboxSuburb.Text);
                    cmd.Parameters.AddWithValue("@city", textboxCity.Text);
                    cmd.Parameters.AddWithValue("@province", textboxProvince.Text);
                    cmd.Parameters.AddWithValue("@pcode", textboxPostalCode.Text); conn.Open();
                    cmd.ExecuteNonQuery();
                    userInformationUpdateStatus.CssClass = "text-success";
                    userInformationUpdateStatus.Text = "User Information Updated Successfully";
                }
                

            }
        }
    }
}

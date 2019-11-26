using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OBlockWebsite
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textboxFname.Text != "" && textboxLname.Text != "" && textboxCellphoneNumber.Text != "" && textboxEmailAddress.Text != "" && textboxHomeAddress.Text != "" && textboxSuburb.Text != "" && textboxCity.Text != "" && textboxPostalCode.Text != "" && textboxPassword.Text != "" && textboxConfirmPassword.Text != "")
            {
                if(textboxPassword.Text==textboxConfirmPassword.Text)
                {

                    String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connString)) //Will prevent errors such as not closing the connection by mistake
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[CUSTOMER] ([cust_name],[cust_surname] ,[cust_number],[cust_email],[cust_address] ,[cust_suburb]  ,[cust_city],[cust_province]  ,[cust_postal_code] ,[cust_password]) VALUES (@firstname,@lastname,@number,@email,@address,@suburb,@city,@province,@postalcode,@password);", conn);

                        cmd.Parameters.AddWithValue("@firstname", textboxFname.Text);
                        cmd.Parameters.AddWithValue("@lastname", textboxLname.Text);
                        cmd.Parameters.AddWithValue("@number", textboxCellphoneNumber.Text);
                        cmd.Parameters.AddWithValue("@email", textboxEmailAddress.Text);
                        cmd.Parameters.AddWithValue("@address", textboxHomeAddress.Text);
                        cmd.Parameters.AddWithValue("@suburb", textboxSuburb.Text);
                        cmd.Parameters.AddWithValue("@city", textboxCity.Text);
                        cmd.Parameters.AddWithValue("@province", textboxProvince.Text);
                        cmd.Parameters.AddWithValue("@postalcode", textboxPostalCode.Text);
                        cmd.Parameters.AddWithValue("@password", textboxPassword.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        labelRegistrationMessage.ForeColor = System.Drawing.Color.Green;
                        labelRegistrationMessage.Text = "Registration Successful!";
                        Response.Redirect("Login.aspx");
                    }

                }
                else
                {
                    labelRegistrationMessage.ForeColor = System.Drawing.Color.Red;
                    labelRegistrationMessage.Text = "Passwords Do Not Match!";
                }


            }
            else
            {
                labelRegistrationMessage.ForeColor = System.Drawing.Color.Red;
                labelRegistrationMessage.Text = "Please fill in all details!";
            }

          
        }
    }
}
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
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindUserRepeater();
            }
        }

        private void BindUserRepeater()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from CUSTOMER", conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        repeaterUsers.DataSource = dt;
                        repeaterUsers.DataBind();
                    }
                }

            }
        }

        protected void linkButtonEdit_Click(object sender, EventArgs e)
        {
            Session["UserID"] = (sender as LinkButton).CommandArgument;
            Response.Redirect("EditUser.aspx");
        }
    }
}
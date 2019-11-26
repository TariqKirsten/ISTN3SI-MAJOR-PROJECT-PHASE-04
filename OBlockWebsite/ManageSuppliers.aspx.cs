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
    public partial class ManageSuppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSupplierRepeater();
            }
        }

        private void BindSupplierRepeater()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from SUPPLIER", conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        repeaterSupplier.DataSource = dt;
                        repeaterSupplier.DataBind();
                    }
                }

            }
        }

        protected void linkButtonEdit_Click(object sender,EventArgs e)
        {
            string ID = (sender as LinkButton).CommandArgument;
            Session["SupplierID"] = ID;
            Response.Redirect("EditSupplier.aspx");
        }
    }
}
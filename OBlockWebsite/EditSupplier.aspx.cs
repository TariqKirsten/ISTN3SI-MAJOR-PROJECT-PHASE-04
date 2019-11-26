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
    public partial class EditSupplier : System.Web.UI.Page
    {
        string supplierID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["SupplierID"] == null)
            {
                Response.Redirect("ManageSuppliers.aspx");
            }
            supplierID = Session["SupplierID"].ToString();

            if(!IsPostBack)
            {
                String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from SUPPLIER where supplier_ID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", supplierID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        textboxSupplierName.Text = (string)dt.Rows[0]["supplier_name"];
                        textboxSupplierEmailAddress.Text = (string)dt.Rows[0]["supplier_email"];
                        textboxPhysAddr.Text = (string)dt.Rows[0]["supplier_address"];
                        textboxContactNumber.Text = (string)dt.Rows[0]["supplier_number"];
                        textboxSuburb.Text = (string)dt.Rows[0]["supplier_suburb"];
                        textboxCity.Text = (string)dt.Rows[0]["supplier_city"];
                        textboxProvince.Text = (string)dt.Rows[0]["supplier_province"];
                        textboxPostalCode.Text = (string)dt.Rows[0]["supplier_postal_code"];
                    }
                }
            }
         
        }

        protected void buttonUpdateSupplier_Click(object sender, EventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE SUPPLIER SET supplier_name=@name,supplier_number=@num,supplier_email=@email,supplier_address=@addr,supplier_suburb=@suburb,supplier_city=@city,supplier_province=@province,supplier_postal_code=@pcode WHERE supplier_ID=@id", conn);
               
                cmd.Parameters.AddWithValue("@name", textboxSupplierName.Text);
                cmd.Parameters.AddWithValue("@email", textboxSupplierEmailAddress.Text);
                cmd.Parameters.AddWithValue("@addr", textboxPhysAddr.Text);
                cmd.Parameters.AddWithValue("@num", textboxContactNumber.Text);
                cmd.Parameters.AddWithValue("@suburb", textboxSuburb.Text);
                cmd.Parameters.AddWithValue("@city", textboxCity.Text);
                cmd.Parameters.AddWithValue("@province", textboxProvince.Text);
                cmd.Parameters.AddWithValue("@pcode", textboxPostalCode.Text);
                cmd.Parameters.AddWithValue("@id", supplierID);
                conn.Open();
              cmd.ExecuteNonQuery();
                supplierUpdatedStatus.Text = "Supplier Information Updated!";
            }
        }
    }
}
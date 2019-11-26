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
    public partial class EditProduct : System.Web.UI.Page
    {
        string productID,productImagePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            textboxCostPricePerUnit.ReadOnly = true;
            textboxProductQuantity.ReadOnly = true;


            if (Session["ProductID"] == null)
            {
                Response.Redirect("ManageProducts.aspx");
            }
            productID = Session["ProductID"].ToString();

            if (!IsPostBack)
            {
                String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                populateDDL();
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from PRODUCT where product_ID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", productID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        string catgeory;
                        textboxProductName.Text = (string)dt.Rows[0]["product_name"];
                        textboxProductPrice.Text = ((Decimal)dt.Rows[0]["product_price"]).ToString();
                        textboxProductQuantity.Text = ((int)dt.Rows[0]["product_quantity"]).ToString();
                        textboxProductDescription.Text = (string)dt.Rows[0]["product_description"];
                        catgeory = (string)dt.Rows[0]["product_category"];
                        if (DropDownListCategory.Items.FindByText(catgeory) !=null)
                        {
                            DropDownListCategory.SelectedIndex = DropDownListCategory.Items.IndexOf(DropDownListCategory.Items.FindByText(catgeory));
                            textboxProductCategory.ReadOnly = true;
                            textboxProductCategory.Text = "Selecting From Existing Categories";
                        }
                        else
                        {

                        }
                        textboxCostPricePerUnit.Text = ((decimal)dt.Rows[0]["cost_price_per_unit"]).ToString();
                        textboxMarkupPercentage.Text = ((decimal)dt.Rows[0]["product_markup_percentage"]).ToString();
                        textboxReorderThreshold.Text = ((int)dt.Rows[0]["reorder_threshold"]).ToString();
                        //productImagePath = (string)dt.Rows[0]["product_image_path"];
                        
                    }
                }
            }
        }

        private void populateDDL()
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select distinct product_category from PRODUCT", conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownListCategory.Items.Add(new ListItem((string)dt.Rows[i]["product_category"]));
                }

                DropDownListCategory.Items.Add(new ListItem("New Category"));
                DropDownListCategory.SelectedIndex = DropDownListCategory.Items.Count - 1; //last item "None"

            }
        }

        protected void DropDownListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCategory.SelectedItem.Text == "New Category")
            {
                textboxProductCategory.ReadOnly = false;
                textboxProductCategory.Text = "";
            }
            else
            {
                textboxProductCategory.ReadOnly = true;
                textboxProductCategory.Text = "Selecting From Existing Categories";
            }
        }

        protected void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string category;
                if(DropDownListCategory.SelectedItem.Text != "New Category")
                {
                    category = DropDownListCategory.SelectedItem.Text;
                }
                else
                {
                    category = textboxProductCategory.Text;
                }
                SqlCommand cmd = new SqlCommand("UPDATE PRODUCT SET product_name=@name,product_price=@price,product_quantity=@pQuantity,product_description=@desc,cost_price_per_unit=@cppu,product_markup_percentage=@markupPercentage,reorder_threshold=@reorderThreshold,product_category=@category WHERE product_ID=@id", conn);

                cmd.Parameters.AddWithValue("@name", textboxProductName.Text);
                cmd.Parameters.AddWithValue("@price", textboxProductPrice.Text);
                cmd.Parameters.AddWithValue("@pQuantity", textboxProductQuantity.Text);
                cmd.Parameters.AddWithValue("@desc", textboxProductDescription.Text);
                cmd.Parameters.AddWithValue("@cppu", textboxCostPricePerUnit.Text);
                cmd.Parameters.AddWithValue("@markupPercentage", textboxMarkupPercentage.Text);
                cmd.Parameters.AddWithValue("@reorderThreshold", textboxReorderThreshold.Text);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@id", productID);
                conn.Open();
                cmd.ExecuteNonQuery();
                productUpdatedStatus.Text = "Product Information Updated!";
            }
        }

    }
}
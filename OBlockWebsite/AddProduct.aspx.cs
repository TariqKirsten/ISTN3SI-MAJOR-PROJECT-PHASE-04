using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBlockWebsite
{
    public partial class AddProduct : System.Web.UI.Page
    {
        String connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
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
          
        }

        protected void buttonAddProduct_Click(object sender, EventArgs e)
        {
          
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string fileName = Path.Combine(Server.MapPath("~/Images"), FileUploadImage.FileName);

                FileUploadImage.SaveAs(fileName);

                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[PRODUCT] ([product_name] ,[product_price] ,[product_quantity] ,[product_description] ,[product_category] ,[cost_price_per_unit] ,[product_markup_percentage] ,[reorder_threshold] ,[product_image_path]) VALUES (@productName ,@productPrice,@productQuantity,@productDesc,@productCategory ,@costPricePerUnit,@markUpPercentage,@reorderThreshold,@imagePath)", conn);
                cmd.Parameters.AddWithValue("@productName", textboxProductName.Text);
                cmd.Parameters.AddWithValue("@productPrice", textboxProductPrice.Text);
                cmd.Parameters.AddWithValue("@productQuantity", textboxProductQuantity.Text);
                cmd.Parameters.AddWithValue("@productDesc", textboxProductDescription.Text);
                if(DropDownListCategory.SelectedItem.Text=="New Category")
                {
                    cmd.Parameters.AddWithValue("@productCategory", textboxProductCategory.Text);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@productCategory", DropDownListCategory.SelectedItem.Text);

                }
                cmd.Parameters.AddWithValue("@costPricePerUnit", textboxCostPricePerUnit.Text);
                cmd.Parameters.AddWithValue("@productMarkupPercentage", textboxMarkupPercentage.Text);
                cmd.Parameters.AddWithValue("@reorderThreshold", textboxReorderThreshold.Text);
                cmd.Parameters.AddWithValue("@imagePath", fileName);
                conn.Open();
                cmd.ExecuteNonQuery();
                productAddedStatus.Text = "Product Added Successfully!";
            }
        }

        protected void DropDownListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCategory.SelectedItem.Text=="New Category")
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
    }
}
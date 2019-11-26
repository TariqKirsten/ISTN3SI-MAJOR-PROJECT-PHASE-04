<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="OBlockWebsite.ViewProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-top:50px;">
         <asp:Repeater ID="repeaterProduct" runat="server">
            <ItemTemplate>
        <div class="col-md-5">
              <div class="thumbnail" style="max-width:480px">

                <img src="<%# Eval("product_image_path")%>" onerror="this.src='Images/ProductImages/No-Product-Image.jpg'" />
              </div>
        </div>
       
      <div class="col-md-7">
          <div class="dividerBorder">
                <h1 class="productNameView"><%# Eval("product_name")%></h1>
                <p class="productPrice">R<%# Eval("product_price") %></p>
              <p class="proDesc"><%# Eval("product_description") %></p>
          </div> 
          
        <div class="form-horizontal">
           
            <div class="form-group">
                <div class="col-md-2">
                    <p style="font-weight:600">Quantity Available: <asp:Label CssClass="pricegray" ID="labelQuantityAvailable" runat="server" Text='<%#Eval("product_quantity") %>'></asp:Label> </p>
                    </div>
                </div>

                </ItemTemplate>
          </asp:Repeater>
            </div>
            <div class="form-group">
               <div class="col-xs-2">
                                   <asp:Label style="margin-top:5px" ID="labelQuantity" CssClass="col-md-1 control-label" runat="server" Text="Quantity" ></asp:Label>

                  </div>
               
                    <div class="col-xs-2">
                
                  <asp:TextBox ID="textboxQuantity" CssClass="form-control" runat="server" TextMode="Number" AutoPostBack="True" OnTextChanged="textboxQuantity_TextChanged">1</asp:TextBox>
                  <asp:Button ID="buttonAddToCart" style="margin-top:10px" CssClass="btn btn-danger" runat="server" Text="Add To Cart" OnClick="buttonAddToCart_Click" />
            </div>
          
            </div>
            
            <div class="form-group">
                <div class="col-xs-">
                 <asp:Label ID="quantityStatus" CssClass="text-danger" runat="server" Text="" ></asp:Label>

                </div>

            </div>
           
             <asp:SqlDataSource ID="SqlDSProductInfo" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT product_ID, product_name, product_price, product_description, product_image_path, product_quantity FROM PRODUCT WHERE (product_ID = @id)">
                 <SelectParameters>
                     <asp:SessionParameter Name="id" SessionField="ProductID" />
                 </SelectParameters>
             </asp:SqlDataSource>
        </div>
      </div>
    </div>
</asp:Content>

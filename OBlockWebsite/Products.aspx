<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="OBlockWebsite.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 class="center">Products</h2> 
    <div class="col-md-3">

        <asp:DropDownList ID="DropDownListCategory" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCategory_SelectedIndexChanged"></asp:DropDownList>
    </div>
    
<div class="row" style="padding-top:50px">
  <asp:Repeater ID="repeaterProducts" runat="server">
      <ItemTemplate>
          <div class="col-sm-2 col-md-2">
    <div class="thumbnail" style="height:300px;width:300px">
      <img class="proImg" src="<%# Eval("product_image_path")%>" onerror="this.src='Images/ProductImages/No-Product-Image.jpg'" onclick="productThumbnailClick"/>
      <div class="caption">
        <div class="proName center">
            <asp:LinkButton ID="linkButtonProductTitle" CommandArgument='<%# Eval("product_ID") %>' runat="server" onclick="productThumbnailClick"><%# Eval("product_name") %></asp:LinkButton>
        </div>
          <div class="proPrice center">R<%# Eval("product_price") %></div>
      </div>
    </div>
  </div>
  </ItemTemplate>
  
  </asp:Repeater>
</div>
    <asp:SqlDataSource ID="SqlDSProductInfo" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT product_name, product_description, product_price, product_image_path, product_ID  FROM PRODUCT  where product_quantity != -1"></asp:SqlDataSource>
</asp:Content>

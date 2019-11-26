<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="OBlockWebsite.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-top:20px;">
        <div class="col-md-9">
            <h5 class="productNameView">My Shopping Cart</h5>
            <asp:Repeater ID="repeaterCartItems" runat="server">
                <ItemTemplate>
            <div class="media" style="border:1px solid #eaeaec">
                <div class="media-left">
                        <a href="#">
                                 <img width="150px"  class="media-object" src='<%# Eval("product_image_path") %>' alt="...">
                        </a>
            </div>
  <div class="media-body">
    <h5 class="media-heading productNameViewCart"><%#Eval("product_name") %></h5>
    <p style="font-weight:600">Quantity: <asp:Label CssClass="pricegray" ID="labelQuantity" runat="server" Text='<%#Eval("quantity") %>'></asp:Label> </p>
    <p style="font-weight:600">Price: <asp:Label CssClass="pricegray" ID="priceLabel" runat="server" Text="R"></asp:Label><asp:Label CssClass="pricegray" ID="labelTotals" runat="server" Text='<%#Eval("total") %>'></asp:Label></p>
      <p>
        <asp:Button ID="buttonRemoveFromCart" CommandArgument='<%#Eval("product_ID")+"-"+Eval("quantity") %>' style="margin-top:10px;width:150px;" CssClass="buttonRemoveFromCart" runat="server" Text="Remove From Cart" OnClick="buttonRemoveFromCart_Click" />

      </p>
  </div>
</div>

                </ItemTemplate>
                </asp:Repeater>
        </div>
        <div class="col-md-3">
            <div style="border-bottom:1px solid #eaeaec">
                <h5 class="productNameViewCart">PRICE DETAILS</h5>
                <div>
                    <label>Cart Total</label>
                    <span class="pull-right pricegray">R<asp:Label CssClass="pricegray" ID="labelCartTotal" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
            <div>
                <asp:SqlDataSource ID="SqlDSProductInfo" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT  [product_name], [product_price] FROM [PRODUCT] where product_id=@id">
                    <SelectParameters>
                        <asp:Parameter Name="id" />
                    </SelectParameters>
                </asp:SqlDataSource>
               <asp:Button ID="buttonBuyNow" style="margin-top:10px" CssClass="buttonBuyNow" runat="server" Text="Buy Now" OnClick="buttonBuyNow_Click" />

            </div>
        </div>
    </div>
</asp:Content>

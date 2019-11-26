<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewUserOrderDetails.aspx.cs" Inherits="OBlockWebsite.ViewUserOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			<div class="container center">
		<div class="form-horizontal">
		<div class="form-group">
			<h1>View Order Details</h1>
		
		</div>
		
<div class="form-group">
	<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">Order Details</div>
  <asp:Repeater ID="repeaterOrders" runat="server">
	  <HeaderTemplate>
	<table class="table">
	  <thead>
		<tr>
			<td>Product ID</td>
			<td>Product Name</td>
			<td>Quantity</td>
			<td>Price</td>
			<td>Subtotal</td>
			
			
			 
		</tr>
	</thead>
	<tbody>
	  </HeaderTemplate>
	  <ItemTemplate>
			  <tr>
			  <td><%# Eval("product_ID") %></td>
			  <td><%# Eval("product_name") %></td>
			  <td><%# Eval("item_quantity") %></td>
			  <td>R<%# Eval("item_price") %></td>
			   <td><%# Eval("subtotal") %></td>
			
			 
			
			   

			  </tr>
		 
	  </ItemTemplate>
	  <FooterTemplate>
	   </tbody>
			</table>
	  </FooterTemplate>
  </asp:Repeater>

</div>
  <!-- Table -->
	   

	

</div>
	<asp:SqlDataSource ID="repeaterOrderDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT        SALE_ITEM.product_ID, PRODUCT.product_name, SALE_ITEM.item_price, SALE_ITEM.item_quantity, SALE_ITEM.subtotal, SALE_ITEM.cost_price_per_unit
FROM            SALE INNER JOIN
						 SALE_ITEM ON SALE.sale_ID = SALE_ITEM.sale_ID INNER JOIN
						 PRODUCT ON SALE_ITEM.product_ID = PRODUCT.product_ID
WHERE        (SALE_ITEM.sale_ID = @saleID)">
		<SelectParameters>
			<asp:SessionParameter Name="saleID" SessionField="SaleID" />
		</SelectParameters>
	</asp:SqlDataSource>
	<asp:SqlDataSource ID="repeaterCustomerInfoDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT DISTINCT CUSTOMER.cust_name, CUSTOMER.cust_surname, CUSTOMER.cust_number, CUSTOMER.cust_email, CUSTOMER.cust_address, CUSTOMER.cust_suburb, CUSTOMER.cust_city, CUSTOMER.cust_province, CUSTOMER.cust_postal_code FROM CUSTOMER INNER JOIN SALE ON CUSTOMER.customer_ID = SALE.cust_ID INNER JOIN SALE_ITEM ON SALE.sale_ID = SALE_ITEM.sale_ID WHERE (SALE_ITEM.sale_ID = @saleID)">
		<SelectParameters>
			<asp:SessionParameter Name="saleID" SessionField="SaleID" />
		</SelectParameters>
	</asp:SqlDataSource>
</div>
</asp:Content>

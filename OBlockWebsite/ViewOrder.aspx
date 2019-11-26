<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="OBlockWebsite.ViewOrder" %>
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
	<hr />
<div class="form-group">
	<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">Customer Details</div>
  <asp:Repeater ID="repeaterCustomerInfo" runat="server">
	  <HeaderTemplate>
	<table class="table">
	  <thead>
		<tr>
			<td>First Name</td>
			<td>Last Name</td>
			<td>Email Address</td>
			<td>Contact Number</td>
			<td>Physical Address</td>
			<td>Suburb</td>
			<td>City</td>
			<td>Province</td>
			<td>Postal Code</td>
			
			
			 
		</tr>
	</thead>
	<tbody>
	  </HeaderTemplate>
	  <ItemTemplate>
			  <tr>
			  <td><%# Eval("cust_name") %></td>
			  <td><%# Eval("cust_surname") %></td>
			  <td>R<%# Eval("cust_email") %></td>
			  <td><%# Eval("cust_number") %></td>
			   <td><%# Eval("cust_address") %></td>
				  <td><%# Eval("cust_suburb") %></td>
				  <td><%# Eval("cust_city") %></td>
				  <td><%# Eval("cust_province") %></td>
				  <td><%# Eval("cust_postal_code") %></td>
			
			 
			
			   

			  </tr>
		 
	  </ItemTemplate>
	  <FooterTemplate>
	   </tbody>
			</table>
	  </FooterTemplate>
  </asp:Repeater>
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
	 <div class="form-group">
		   <div class="col-md-11"></div>
			   <div>
					<asp:Button ID="buttonMarkOrderComplete"  runat="server" Text="Mark Order Complete" CssClass="btn btn-default" OnClick="buttonMarkOrderComplete_Click"  />
					<asp:SqlDataSource ID="SqlDSOrderComplete" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [SALE]" UpdateCommand="UPDATE SALE SET isCompleted = 1 WHERE (sale_ID = @saleID)">
						<UpdateParameters>
							<asp:SessionParameter Name="saleID" SessionField="SaleID" />
						</UpdateParameters>
					</asp:SqlDataSource>
			   </div>
	   </div>
	 <div class="form-group">
			
			<div class ="col-md-11">
			  <asp:Label ID="orderCompleteStatus" runat="server" Text="" CssClass="text-success"></asp:Label>

			</div>
   </div>
	</div>
</asp:Content>

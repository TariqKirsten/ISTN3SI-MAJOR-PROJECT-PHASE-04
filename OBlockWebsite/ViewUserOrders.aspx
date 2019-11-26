<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewUserOrders.aspx.cs" Inherits="OBlockWebsite.ViewUserOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			<div class="container center">
		<div class="form-horizontal">
		<div class="form-group">
			<h1>Manage Orders</h1>
		
		</div>
		
<div class="form-group">
	<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">Orders</div>
  <asp:Repeater ID="repeaterOrders" runat="server">
	  <HeaderTemplate>
	<table class="table">
	  <thead>
		<tr>
			<td>#</td>
			<td>Date</td>
			<td>Total</td>
			<td>Delivery Required</td>
			<td>Customer ID</td>
			<td>Completed</td>
			<td>Manage</td>
			
			 
		</tr>
	</thead>
	<tbody>
	  </HeaderTemplate>
	  <ItemTemplate>
			  <tr>
			  <th><%# Eval("sale_ID") %></th>
			  <td><%# Eval("sale_date") %></td>
			  <td>R<%# Eval("total_amount") %></td>
			   <td><%# Eval("isDelivery") %></td>
			   <td><%# Eval("cust_ID") %></td>
			   <td><%# Eval("isCompleted") %></td>
			 
			   <td><a href="#">
				   <asp:LinkButton ID="linkButtonViewDetails" CommandArgument='<%# Eval("sale_ID")  %>' OnClick="linkButtonViewDetails_Click" runat="server">View Details</asp:LinkButton></a></td>
			   
			   

			  </tr>
		 
	  </ItemTemplate>
	  <FooterTemplate>
	   </tbody>
			</table>
	  </FooterTemplate>
  </asp:Repeater>

  <!-- Table -->
	   

	

</div>
</div>

   </div>
	</div>
	
</asp:Content>

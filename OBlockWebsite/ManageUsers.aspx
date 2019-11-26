<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="OBlockWebsite.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<div class="container center">
		<div class="form-horizontal">
		<div class="form-group">
			<h1>Manage Users</h1>
		</div>
		
<div class="form-group">
	<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">Users</div>
  <asp:Repeater ID="repeaterUsers" runat="server">
	  <HeaderTemplate>
	<table class="table">
	  <thead>
		<tr>
			<td>#</td>
			<td>First Name</td>
			<td>Last Name</td>
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
			  <th><%# Eval("customer_ID") %></th>
			  <td><%# Eval("cust_name") %></td>
			  <td><%# Eval("cust_surname") %></td>
			  <td><%# Eval("cust_email") %></td>
			   <td><%# Eval("cust_address") %></td>
			   <td><%# Eval("cust_suburb") %></td>
			   <td><%# Eval("cust_city") %></td>
			   <td><%# Eval("cust_province") %></td>
			   <td><%# Eval("cust_postal_code") %></td>
			   <td><a href="#">
				   <asp:LinkButton ID="linkButtonEdit" CommandArgument='<%# Eval("customer_ID")  %>' OnClick="linkButtonEdit_Click" runat="server">Edit</asp:LinkButton></a></td>
			  
			   

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

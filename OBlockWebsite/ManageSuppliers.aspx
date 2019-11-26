<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageSuppliers.aspx.cs" Inherits="OBlockWebsite.ManageSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<div class="container center">
		<div class="form-horizontal">
		<div class="form-group">
			<h1>Manage Suppliers</h1>
		<div class="col-lg-12">
		  <p>
			<a href="AddSupplier.aspx" class="btn btn-sq-lg btn-primary">
				<i class="fa fa-user fa-5x"></i><br/>
				Add  <br />Supplier
			</a>
			  </p>
	</div>
		</div>
		
<div class="form-group">
	<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">Suppliers</div>
  <asp:Repeater ID="repeaterSupplier" runat="server">
	  <HeaderTemplate>
	<table class="table">
	  <thead>
		<tr>
			<td>#</td>
			<td>Name</td>
			<td>Email Addreess</td>
			<td>Contact Number</td>
			<td>Physical Address</td>
			<td>Suburb</td>
			<td>City</td>
			<td>Province</td>
			<td>Postal Code</td>
			<td>Manage</td>
			 
		</tr>
	</thead>
	<tbody>
	  </HeaderTemplate>
	  <ItemTemplate>
			  <tr>
			  <td><%# Eval("supplier_id") %></td>
			  <td><%# Eval("supplier_name") %></td>
			  <td><%# Eval("supplier_email") %></td>
			  <td><%# Eval("supplier_number") %></td>
			   <td><%# Eval("supplier_address") %></td>
			   <td><%# Eval("supplier_suburb") %></td>
			   <td><%# Eval("supplier_city") %></td>
			   <td><%# Eval("supplier_province") %></td>
			   <td><%# Eval("supplier_postal_code") %></td>
			   <td><a href="#">
                   <asp:LinkButton ID="linkButtonEdit" CommandArgument='<%# Eval("supplier_id")  %>' OnClick="linkButtonEdit_Click" runat="server">Edit</asp:LinkButton></a></td>
			   

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

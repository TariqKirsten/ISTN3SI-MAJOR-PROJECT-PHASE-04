<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="OBlockWebsite.ViewReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container center">
	<h1>Welcome Administrator!</h1>
		<div class="col-lg-12">
		  <p>
			<a href="Reports/chartDateVsAccProfit.aspx" class="btn btn-sq-lg btn-primary">
				<i class="fa fa-user fa-5x"></i><br/>
				Date <br />Vs <br />Accumulated Profits
			</a>
			<a href="ManageSuppliers.aspx" class="btn btn-sq-lg btn-success">
			  <i class="fa fa-user fa-5x"></i><br/>
			  Manage <br>Suppliers
			</a>
			<a href="ManageUsers.aspx" class="btn btn-sq-lg btn-info">
			  <i class="fa fa-user fa-5x"></i><br/>
			  Manage <br> Users
			</a>
			<a href="ManageOrders.aspx" class="btn btn-sq-lg btn-warning">
			  <i class="fa fa-user fa-5x"></i><br/>
			  View <br>Orders
			</a>
			<a href="#" class="btn btn-sq-lg btn-danger">
			  <i class="fa fa-user fa-5x"></i><br/>
			  View <br>Reports
			</a>
		  </p>
		</div>
	</div>
</asp:Content>

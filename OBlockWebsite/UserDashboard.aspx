<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="OBlockWebsite.UserDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container center">
	<h1>Welcome User!</h1>
		<div class="col-lg-12">
		  <p>
			<a href="ViewUserProfile.aspx" class="btn btn-sq-lg btn-primary">
				<i class="fa fa-user fa-5x"></i><br/>
				View My <br />Profile
			</a>
			<a href="ViewUserOrders.aspx" class="btn btn-sq-lg btn-success">
			  <i class="fa fa-user fa-5x"></i><br/>
			  View My <br>Orders
			</a>
		  </p>
		</div>
	</div>
</asp:Content>

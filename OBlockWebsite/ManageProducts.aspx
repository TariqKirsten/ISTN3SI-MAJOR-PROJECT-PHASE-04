<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="OBlockWebsite.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container center">
        <div class="form-horizontal">
        <div class="form-group">
            <h1>Manage Products</h1>
		<div class="col-lg-12">
		  <p>
			<a href="AddProduct.aspx" class="btn btn-sq-lg btn-primary">
				<i class="fa fa-user fa-5x"></i><br/>
				Add  <br />Product
			</a>
			  </p>
	</div>
        </div>
		
<div class="form-group">
    <div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">Products</div>
  <asp:Repeater ID="repeaterProducts" runat="server">
      <HeaderTemplate>
    <table class="table">
      <thead>
        <tr>
            <td>#</td>
            <td>Name</td>
            <td>Price</td>
            <td>Product Quantity</td>
            <td>Description</td>
            <td>Category</td>
            <td>Cost Price Per unit</td>
            <td>Markup Percentage</td>
            <td>Reorder Threshold</td>
            <td>Manage</td>
             
        </tr>
	</thead>
    <tbody>
      </HeaderTemplate>
      <ItemTemplate>
              <tr>
              <th><%# Eval("product_id") %></th>
              <td><%# Eval("product_name") %></td>
              <td><%# Eval("product_price") %></td>
              <td><%# Eval("product_quantity") %></td>
               <td><%# Eval("product_description") %></td>
               <td><%# Eval("product_category") %></td>
               <td><%# Eval("cost_price_per_unit") %></td>
               <td><%# Eval("product_markup_percentage") %></td>
               <td><%# Eval("reorder_threshold") %></td>
               <td><a href="#">
                   <asp:LinkButton ID="linkButtonEdit" CommandArgument='<%# Eval("product_id")  %>' OnClick="linkButtonEdit_Click" runat="server">Edit</asp:LinkButton></a></td>
                  <td><a href="#">
                   <asp:LinkButton ID="linkButtonAddStock" CommandArgument='<%# Eval("product_id")  %>' OnClick="linkButtonAddStock_Click" runat="server">Add Stock</asp:LinkButton></a></td>
               <td>Deactivate</td>
               

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

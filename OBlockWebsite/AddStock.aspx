<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddStock.aspx.cs" Inherits="OBlockWebsite.AddStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="form-horizontal">
        <h2>Add Stock</h2>
        <hr />

           <div class="form-group">
            <asp:Label ID="label1" CssClass="col-md-2 control-label" runat="server" Text="Supplier"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxSupplier" CssClass="form-control"  runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="labelFName" CssClass="col-md-2 control-label" runat="server" Text="Quantity To Add"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxStockToAdd" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelLName" CssClass="col-md-2 control-label" runat="server" Text="Cost Price Per Unit"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxCPPU" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelEmailAddr" CssClass="col-md-2 control-label" runat="server" Text="Date"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxDate" ReadOnly="true" CssClass="form-control"  runat="server" ></asp:TextBox>
            </div>
        </div>

         <div class="form-group">
           <div class="col-md-2"></div>
               <div class="col-md-6">
                    <asp:Button ID="buttonAddStock"  runat="server" Text="Add Stock" CssClass="btn btn-default" OnClick="buttonAddStock_Click" />
               </div>
         </div>

          <div class="form-group">
            <div class="col-md-2"></div>
            <div class ="col-md-6">
              <asp:Label ID="stockUpdateStatus" runat="server" Text="" CssClass="text-success"></asp:Label>

            </div>
        </div>
    </div>
</asp:Content>

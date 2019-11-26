<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs" Inherits="OBlockWebsite.AddSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <h2>Add Supplier</h2>
        <hr />
        <div class="form-group">
              <asp:Label ID="labelSupplierName" CssClass="col-md-2 control-label" runat="server" Text="Name"></asp:Label>
            <div class="col-md-3">
            <asp:TextBox ID="textboxSupplierName" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
             <asp:Label ID="labelSupplierEmailAddress" CssClass="col-md-2 control-label" runat="server" Text="Email Address"></asp:Label> 
            <div class="col-md-3">
          <asp:TextBox ID="textboxSupplierEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="number" runat="server" CssClass="col-md-2 control-label" Text="Contact Number"></asp:Label>
                <div class="col-md-3">
            <asp:TextBox ID="textboxContactNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
        </div>

        <div class="form-group">
            <asp:Label ID="address" CssClass="col-md-2 control-label" runat="server" Text="Physical Address"></asp:Label>
            <div class="col-md-3">
            <asp:TextBox ID="textboxPhysAddr" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
        </div>

        <div class="form-group">
              <asp:Label ID="suburb" CssClass="col-md-2 control-label" runat="server" Text="Suburb"></asp:Label>
                <div class="col-md-3">
            <asp:TextBox ID="textboxSuburb" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
        </div>

        <div class="form-group">
             <asp:Label ID="city" CssClass="col-md-2 control-label" runat="server" Text="City"></asp:Label>
                <div class="col-md-3">
            <asp:TextBox ID="textboxCity" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
        </div>

        <div class="form-group">
               <asp:Label ID="province"  CssClass="col-md-2 control-label" runat="server" Text="Province"></asp:Label>
            <div class="col-md-3">
            <asp:TextBox ID="textboxProvince" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
            </div>
        <div class="form-group">
            <asp:Label ID="postalCode" CssClass="col-md-2 control-label" runat="server" Text="Postal Code"></asp:Label>
            <div class="col-md-3">
            <asp:TextBox ID="textboxPostalCode" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        </div>
          <div class="form-group">
           <div class="col-md-2"></div>
               <div class="col-md-6">
                    <asp:Button ID="buttonAddSupplier" runat="server" Text="Add Supplier" CssClass="btn btn-default"/>
               </div>
       </div>

           <div class="form-group">
              
        </div>
        </div>


</asp:Content>

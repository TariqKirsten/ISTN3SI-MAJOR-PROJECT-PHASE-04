<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditSupplier.aspx.cs" Inherits="OBlockWebsite.EditSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form-horizontal">
        <h2>Edit Supplier</h2>
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
                    <asp:Button ID="buttonUpdateSupplier"  runat="server" Text="Update Supplier" CssClass="btn btn-default" OnClick="buttonUpdateSupplier_Click"  />
               </div>
       </div>

            <div class="form-group">
            <div class="col-md-2"></div>
            <div class ="col-md-6">
              <asp:Label ID="supplierUpdatedStatus" runat="server" Text="" CssClass="text-success"></asp:Label>

            </div>
        </div>
        </div>
</asp:Content>

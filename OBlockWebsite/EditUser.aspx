<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="OBlockWebsite.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <h2>Edit User</h2>
        <hr />

        <div class="form-group">
            <asp:Label ID="labelFName" CssClass="col-md-2 control-label" runat="server" Text="First Name"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxFName" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelLName" CssClass="col-md-2 control-label" runat="server" Text="Last Name"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxLName" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelEmailAddr" CssClass="col-md-2 control-label" runat="server" Text="Email Address"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxEmailAddr" CssClass="form-control"  runat="server" TextMode="Email"></asp:TextBox>
            </div>
        </div>

   

        <div class="form-group">
            <asp:Label ID="labelPhysicalAddr" CssClass="col-md-2 control-label" runat="server" Text="Physical Address"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxPhysicalAddr" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelSuburb" CssClass="col-md-2 control-label" runat="server" Text="Suburb"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxSuburb" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelCity" CssClass="col-md-2 control-label" runat="server" Text="City"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxCity" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelProvince" CssClass="col-md-2 control-label" runat="server" Text="Province"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxProvince" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelPostalCode" CssClass="col-md-2 control-label" runat="server" Text="Postal Code"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="textboxPostalCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

         <div class="form-group">
           <div class="col-md-2"></div>
               <div class="col-md-6">
                    <asp:Button ID="buttonUpdateUser"  runat="server" Text="Update User" CssClass="btn btn-default" OnClick="buttonUpdateUser_Click" />
               </div>
         </div>

          <div class="form-group">
            <div class="col-md-2"></div>
            <div class ="col-md-6">
              <asp:Label ID="userInformationUpdateStatus" runat="server" Text="" CssClass="text-success"></asp:Label>

            </div>
        </div>
    </div>
</asp:Content>

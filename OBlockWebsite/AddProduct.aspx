<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="OBlockWebsite.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
       <h2>Add Product</h2>
       <hr />
        <div class="form-group">
                    <asp:Label ID="labelProductName" runat="server" CssClass="col-md-2 control-label" Text="Name"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxProductName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" CssClass="text-danger" runat="server" ErrorMessage="Name is Required!" ControlToValidate="textboxProductName"></asp:RequiredFieldValidator>
                    </div>
        </div>
       <div class="form-group">
                    <asp:Label ID="labelProductPrice" runat="server" CssClass="col-md-2 control-label" Text="Price"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxProductPrice" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Price is Required!" ControlToValidate="textboxProductPrice"></asp:RequiredFieldValidator>
                    </div>
        </div>
       <div class="form-group">
                    <asp:Label ID="labelProductQuantity" runat="server" CssClass="col-md-2 control-label" Text="Product Quantity"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxProductQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Quantity is Required!" ControlToValidate="textboxProductQuantity"></asp:RequiredFieldValidator>
                    </div>
        </div>
       <div class="form-group">
                    <asp:Label ID="labelProductDescription" runat="server" CssClass="col-md-2 control-label" Text="Description"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxProductDescription" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Description is Required!" ControlToValidate="textboxProductDescription"></asp:RequiredFieldValidator>
                    </div>
        </div>
       <div class="form-group">
                    <asp:Label ID="labelProductCategoryDDL" runat="server" CssClass="col-md-2 control-label" Text="Existing Category"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="DropDownListCategory" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCategory_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="Category is Required!" ControlToValidate="DropDownListCategory"></asp:RequiredFieldValidator>
                    </div>
        </div>

            <div class="form-group">
                    <asp:Label ID="labelProductCategoryTB" runat="server" CssClass="col-md-2 control-label" Text="New Category"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxProductCategory" runat="server" CssClass="form-control"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="text-danger" runat="server" ErrorMessage="Category is Required!" ControlToValidate="DropDownListCategory"></asp:RequiredFieldValidator>
                    </div>
        </div>

       <div class="form-group">
                    <asp:Label ID="labelCostPricePerUnit" runat="server" CssClass="col-md-2 control-label" Text="Cost Price Per unit"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxCostPricePerUnit" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="Cost Price Per Unit is Required!" ControlToValidate="textboxCostPricePerUnit"></asp:RequiredFieldValidator>
                    </div>
        </div>

         <div class="form-group">
                    <asp:Label ID="labelMarkupPercentage" runat="server" CssClass="col-md-2 control-label" Text="Markup Percentage"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxMarkupPercentage" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="Markup Percentage is Required!" ControlToValidate="textboxMarkupPercentage"></asp:RequiredFieldValidator>
                    </div>
        </div>

       <div class="form-group">
                    <asp:Label ID="labelReorderThreshold" runat="server" CssClass="col-md-2 control-label" Text="Reorder Threshold"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxReorderThreshold" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" runat="server" ErrorMessage="Reorder Threshold is Required!" ControlToValidate="textboxReorderThreshold"></asp:RequiredFieldValidator>
                    </div>
        </div>
       <div class="form-group">
                    <asp:Label ID="labelImage" runat="server" CssClass="col-md-2 control-label" Text="Image"></asp:Label>
                    <div class="col-md-3">
                        <asp:FileUpload ID="FileUploadImage" runat="server" CssClass="form-control" accept=".png,.jpg,.jpeg,.gif" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="text-danger" runat="server" ErrorMessage="Image File is Required!" ControlToValidate="FileUploadImage"></asp:RequiredFieldValidator>
                    </div>
        </div>
       <div class="form-group">
           <div class="col-md-2"></div>
               <div class="col-md-6">
                    <asp:Button ID="buttonAddProduct" runat="server" Text="Add Product" CssClass="btn btn-default" OnClick="buttonAddProduct_Click"/>
               </div>
       </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class ="col-md-6">
              <asp:Label ID="productAddedStatus" runat="server" Text="" CssClass="text-success"></asp:Label>

            </div>
        </div>
      

   </div>
</asp:Content>

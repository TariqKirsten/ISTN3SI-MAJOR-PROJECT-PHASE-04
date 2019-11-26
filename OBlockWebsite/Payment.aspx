<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="OBlockWebsite.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField ID="hdCartAmount" runat="server" />
    <asp:HiddenField ID="hdCartDiscount" runat="server" />
    <asp:HiddenField ID="hdTotalPayed" runat="server" />
    <asp:HiddenField ID="hdPidSizeID" runat="server" />


    <div style="padding-top: 20px;">
        <div class="col-md-9">
            <div class="form-horizontal">
                <h3>Delivery Address</h3>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Name"></asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox ID="textboxName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="textboxName"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Physical Address"></asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox ID="textboxPhysicalAddr"  CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="textboxPhysicalAddr"></asp:RequiredFieldValidator>
                    </div>
                </div>
              
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Contact Number"></asp:Label>
                    <div class="col-md-7">
                        <asp:TextBox ID="textboxContactNumber" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="textboxContactNumber"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                     <asp:Label ID="labelDelivery" runat="server" CssClass="col-md-2 control-label" Text="Pick Up"></asp:Label>

                    <div class="col-md-7">
                        <asp:CheckBox ID="checkboxPickup"  runat="server" AutoPostBack="True" />
                        
                    </div>
                <div class="form-group">
                    <div class="col-md-7">
                        <asp:Button ID="buttonSubmitOrder" CssClass="buttonBuyNow" runat="server" Text="Submit Order" OnClick="buttonSubmitOrder_Click" />
                        
                    </div>
                </div>
                    <div class="form-group">
                    <div class="col-md-7">
                        
                        <asp:Label ID="orderStatus" runat="server" CssClass="productNameViewCart" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>  

        </div>
         <div class="col-md-3" id="divPriceDetails">
            <div style="border-bottom:1px solid #eaeaec">
                <h5 class="productNameViewCart">PRICE DETAILS</h5>
                <div>
                    <label>Cart Total</label>
                    <span class="pull-right pricegray">R<asp:Label CssClass="pricegray" ID="labelCartTotal" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
      
    </div>
      </div>
</asp:Content>

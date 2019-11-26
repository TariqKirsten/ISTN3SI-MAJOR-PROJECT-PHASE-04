<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OBlockWebsite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Login</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/CustomStylesheet.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="Default.aspx">  <span><img alt="Logo" src="Images/oblocklogo.png" height="30"/></span>O Block Shop</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="Default.aspx">Home</a></li>
                    <li><a href="#">About</a></li>
                    <li><a href="#">Contact</a></li>
                    <li class="">
                        <a href="Products.aspx">Products</a>
                       
                    </li>
                  <li><a href="Register.aspx">Register</a></li>
                  <li class="active"><a href="Login.aspx">Login</a></li>
                </ul>
            </div>
        </div>
    </div>
    
        <!--Login page -->

        <div class="container">
            <div class="form-horizontal">
                <h2>Login</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="labelEmailAddress" runat="server" CssClass="col-md-2 control-label" Text="Email Address"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" CssClass="text-danger" runat="server" ErrorMessage="Email Address is Required!" ControlToValidate="textboxEmailAddress"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="labelPassword" runat="server" CssClass="col-md-2 control-label" Text="Password"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="textboxPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" CssClass="text-danger" runat="server" ErrorMessage="Password is Required!" ControlToValidate="textboxPassword"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-2"></div>
                   <div class="col-md-6">
                         <asp:CheckBox ID="checkboxRememberMe" runat="server" />
                        <asp:Label ID="labelRememberMe" runat="server" CssClass="control-label" Text="Remember Me"></asp:Label>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-2"></div>
                   <div class="col-md-6">
                       <asp:Button ID="buttonLogin" runat="server" CssClass="btn btn-default" Text="Login" OnClick="buttonLogin_Click"  />
                       <asp:LinkButton ID="linkButtonRegister" runat="server" CausesValidation="False" PostBackUrl="~/Register.aspx">Register</asp:LinkButton>
                    </div>
                </div>

                 <div class="form-group">
                    <div class="col-md-2"></div>
                     <asp:Label ID="labelLoginStatus" runat="server" Text=""></asp:Label>
                    </div>
                </div>

            </div>
        </div>

        <!--Login Page end -->

    </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

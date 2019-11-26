<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OBlockWebsite.Register" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Register</title>

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
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b> </a>
                        <ul class="dropdown-menu">
                            <li class="dropdown-header">Kitchen</li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#">Cooking</a></li>
                            <li><a href="#">Cooking utensils</a></li>
                            <li><a href="#">Frozen foods</a></li>
                            <li><a href="#">Grains</a></li>
                            <li><a href="#">Pasta</a></li>
                            <li><a href="#">Spices</a></li>
                             <li role="separator" class="divider"></li>
                             <li class="dropdown-header">Prayer</li>
                             <li role="separator" class="divider"></li>
                            <li><a href="#">General Prayer Goods</a></li>
                            <li><a href="#">Murtis - Idols</a></li>
                        </ul>
                    </li>
                  <li class="active"><a href="Register.aspx">Register</a></li>
                     <li><a href="Login.aspx">Login</a></li>
                </ul>
            </div>
        </div>
    </div>

        <!--Register controls start -->

        <div class="center-page">
           <br />
            <h2>Register</h2>

              <label class="col-xs-11">First Name</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxFname" class="form-control" placeholder="First Name" runat="server"></asp:TextBox>
            </div>
        <label class="col-xs-11">Last Name</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxLname" class="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
            </div>

              <label class="col-xs-11">Cellphone Number</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxCellphoneNumber" class="form-control" placeholder="Cellphone Number" runat="server"></asp:TextBox>
            </div>
       

            <label class="col-xs-11">Email Address</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxEmailAddress" class="form-control" placeholder="Emal Address" runat="server" TextMode="Email"></asp:TextBox>
            </div>

            <label class="col-xs-11">Password</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxPassword" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
            </div>

        <label class="col-xs-11">Confirm Password</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxConfirmPassword" class="form-control" placeholder="Confirm Password" runat="server" TextMode="Password"></asp:TextBox>
            </div>

      

            <label class="col-xs-11">Home Address</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxHomeAddress" class="form-control" placeholder="Home Address" runat="server"></asp:TextBox>
            </div>

            <label class="col-xs-11">Suburb</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxSuburb" class="form-control" placeholder="Suburb" runat="server"></asp:TextBox>
            </div>

            <label class="col-xs-11">City</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxCity" class="form-control" placeholder="City" runat="server"></asp:TextBox>
            </div>

            <label class="col-xs-11">Province</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxProvince" class="form-control" placeholder="Province" runat="server"></asp:TextBox>
            </div>

            <label class="col-xs-11">Postal Code</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textboxPostalCode" class="form-control" placeholder="Postal Code" runat="server"></asp:TextBox>
            </div>
            






            <div class="col-xs-11 space-vert">
            <asp:Button ID="buttonRegister" runat="server" CssClass="btn btn-success" Text="Register" OnClick="buttonRegister_Click" />
                <asp:Label ID="labelRegistrationMessage" runat="server"></asp:Label>
            </div>
        </div>
        </div>
        
     
      
        <!--Register controls end -->
         </form>
          
   

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

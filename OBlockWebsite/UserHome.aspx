﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="OBlockWebsite.UserHome" %>

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
                    <li class="active"><a href="Default.aspx">Home</a></li>
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
                    <li>
                         <asp:Button ID="buttonLogout" runat="server" Text="Logout" CssClass="btn btn-default navbar-btn" OnClick="buttonLogout_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
       
    </form>
       <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

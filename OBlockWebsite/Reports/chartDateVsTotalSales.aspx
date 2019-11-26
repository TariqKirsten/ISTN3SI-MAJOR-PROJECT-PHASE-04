<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chartDateVsTotalSales.aspx.cs" Inherits="OBlockWebsite.Reports.chartDateVsTotalSales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="ChartJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Literal ID="ltChart1" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>

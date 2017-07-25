<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="Chart1" runat="server" DataSourceID="dsStuff">
            <Series>
                <asp:Series Name="Series1" ChartType="Doughnut" XValueMember="StoreName" YValueMembers="KrogerStoreID"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="dsStuff" runat="server" ConnectionString="<%$ ConnectionStrings:PopTartsConnectionString %>" SelectCommand="SELECT * FROM [vAllStoresAndThePoptartsTheySell]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

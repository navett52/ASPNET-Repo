<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scrHousesPerState" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updHousesPerState" runat="server">
            <ContentTemplate>
            <asp:Chart ID="chHousesPerState" runat="server" DataSourceID="dsAddressesPerState">
                <Series>
                    <asp:Series Name="serHousesPerState" ChartType="Doughnut" XValueMember="Abbreviation" YValueMembers="Number Of Houses Per State"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="chaHousesPerSate"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="dsAddressesPerState" runat="server" ConnectionString="<%$ ConnectionStrings:tellepetDB %>" SelectCommand="SELECT COUNT(tStreetNum.StreetNumID) AS [Number Of Houses Per State], tState.StateID, tState.Abbreviation FROM tStreetNum INNER JOIN tStreet ON tStreetNum.StreetID = tStreet.StreetID INNER JOIN tCity ON tStreet.CityID = tCity.CityID INNER JOIN tState ON tCity.StateID = tState.StateID GROUP BY tState.StateID, tState.Abbreviation"></asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

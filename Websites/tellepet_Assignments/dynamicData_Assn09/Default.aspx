<%--
    Evan Tellep
    Prof. Bill Nicholson
    Assignment 09
    4/5/2017
    Desc: A chart hooked to a chart control that auto update severy 3 seconds to dispay real time data
    Ref: Stack Overflow, MSDN
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/EvansSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="dynamicData_Assn09_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/assn09.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <asp:ScriptManager ID="scrHousesPerState" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updHousesPerState" runat="server">
        <ContentTemplate>
            <asp:Timer ID="timUpdateChart" runat="server" Interval="3000"></asp:Timer>
            <asp:Chart ID="chHousesPerState" runat="server" DataSourceID="dsAddressesPerState">
            <Series>
                <asp:Series Name="serHousesPerState" XValueMember="Abbreviation" YValueMembers="numOfHouses" YValuesPerPoint="2"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="chaHousesPerSate"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="dsAddressesPerState" runat="server" ConnectionString="<%$ ConnectionStrings:tellepetDB %>" SelectCommand="SELECT COUNT(tStreetNum.StreetNumID) AS [numOfHouses], tState.StateID, tState.Abbreviation FROM tStreetNum INNER JOIN tStreet ON tStreetNum.StreetID = tStreet.StreetID INNER JOIN tCity ON tStreet.CityID = tCity.CityID INNER JOIN tState ON tCity.StateID = tState.StateID GROUP BY tState.StateID, tState.Abbreviation"></asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
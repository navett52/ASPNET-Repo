<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/1/2017
    Assignment02
    Making a page to display the loyalty number
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Rewards/RewardsMaster.master" AutoEventWireup="true" CodeFile="DisplayLoyaltyNum.aspx.cs" Inherits="Rewards_DisplayLoyaltyNum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Rewards.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RewardsBody" Runat="Server">
    <div class="container">
        <!-- A jumbotron to display the loyalty number -->
        <div class="jumbotron">
            <asp:Label ID="lblLoyaltyNum" runat="server" Text="Loaylety Num = "></asp:Label>
        </div>
    </div>
</asp:Content>


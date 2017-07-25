<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/22/2017
    Assignment05
    Display the selected enchantments on a summary page.
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/EvansSite.master" AutoEventWireup="true" CodeFile="Display.aspx.cs" Inherits="Databasing_Assn05_Display" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Databsing.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container">
        <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
        <asp:BulletedList ID="blSelectedEnchants" runat="server"></asp:BulletedList>
    </div>
</asp:Content>


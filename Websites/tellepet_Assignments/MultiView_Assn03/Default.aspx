<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/8/2017
    Assignment03
    The page where viewing the views from within the multiview control takes place
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/EvansSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MultiView_Assn03_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Assn03Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="content">
                <asp:TextBox ID="txtListAmount" runat="server"></asp:TextBox>
                <asp:Button ID="btnGo" runat="server" Text="Button" OnClick="btnGo_Click" />
                <asp:DropDownList ID="ddViews" runat="server" OnSelectedIndexChanged="ddViews_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="content">
                <asp:MultiView ID="mvDisplay" runat="server"></asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
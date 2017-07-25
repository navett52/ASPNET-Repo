<%--
    Evan Tellep
    Prof. Bill Nicholson
    ASP.NET
    Mevtric (Final)
    4/26/2017
    Ref: A lot of MSDN, Stack Overflow, and some Code Project
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/tellepet_Final/FinalMaster.master" AutoEventWireup="true" CodeFile="Construct.aspx.cs" Inherits="tellepet_Final_Construct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/Construct.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ConstructContent" ContentPlaceHolderID="body" Runat="Server">
    <div class="element">
        <asp:CheckBoxList ID="chblDBTables" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chblDBTables_SelectedIndexChanged"></asp:CheckBoxList>
    </div>
    <div class="element">
        <asp:CheckBoxList ID="chblColumns" runat="server"></asp:CheckBoxList>
    </div>
    <asp:TextBox ID="txtTopRecords" runat="server"></asp:TextBox>
    <asp:Button ID="btnConstruct" runat="server" Text="Construct Mevtric" OnClick="btnConstruct_Click" />
</asp:Content>


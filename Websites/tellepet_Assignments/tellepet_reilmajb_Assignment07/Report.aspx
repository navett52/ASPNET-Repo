<%--
    Evan Tellep and Jake Reilman
    Prof. Bill Nicholson
    ASP.NET
    Assignment 07
    3/22/17
    Assn Desc: Creating web form to generate reports
    Ref:  
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/tellepet_reilmajb_Assignment07/Assn07Master.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Theme/Report.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
    <div id="wrapper">
    <asp:Literal ID="litReport" runat="server"></asp:Literal>
    </div>
</asp:Content>


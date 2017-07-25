<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    1/25/2017
    Assignment01
    Create a page that solves a project euler problem of our choice
    Ref: http://stackoverflow.com/questions/4808612/how-to-split-a-number-into-individual-digits-in-c
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/EvansSite.master" AutoEventWireup="true" CodeFile="Assignment01.aspx.cs" Inherits="Assignment01" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/Assignment01.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="body" Runat="Server">
    <div class="container">
    <!-- The problem description -->
    <div class="row">
        <div class="col-lg-12 text-center" id="mainColumn">
            <p>2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.<br />
            What is the sum of the digits of the number 2^1000?</p>
        </div>
    </div>
    <!-- The answer to problem 16 -->
    <div class="row">
        <div class="col-lg-12 text-center" id="mainColumn">
            <div class="jumbotron text-center">
                <asp:Label ID="lblAnswer" runat="server" Text="Label">Answer = </asp:Label>
            </div>
        </div>
    </div>
    <!-- Link to go to the problem page -->
    <div class="row">
        <div class="col-lg-12 text-center" id="mainColumn">
            <a class="btn btn-secondary assn-btn" href="https://projecteuler.net/problem=16" role="button">https://projecteuler.net/problem=16</a>
        </div>
    </div>
</div>
</asp:Content>


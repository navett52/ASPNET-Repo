<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    1/25/2017
    Assignment01
    Create a page to hold our assignments
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/EvansSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<div class="container">
    <div class="row" id="mainContent">
        <!-- Start the main column where the content is visible -->
        <div class="col-lg-12 text-center" id="mainColumn">
            <h3>Assignments</h3>
            <ul class="ev-nav">
                <li><a class="btn btn-secondary assn-btn" href="Assignment01.aspx" role="button">Assignment01</a></li>
                <li><a class="btn btn-secondary assn-btn" href="Rewards/" role="button">Assignment02</a></li>
                <li><a class="btn btn-secondary assn-btn" href="MultiView_Assn03/" role="button">Assignment03</a></li>
                <li><a class="btn btn-secondary assn-btn" href="WebScraping_Assn04" role="button">Assignment04</a></li>
                <li><a class="btn btn-secondary assn-btn" href="Databasing_Assn05" role="button">Assignment05</a></li>
                <li><a class="btn btn-secondary assn-btn" href="tellepet_midterm" role="button">Midterm</a></li>
                <li><a class="btn btn-secondary assn-btn" href="tellepet_reilmajb_Assignment07" role="button">Assignment 07</a></li>
            </ul>
        </div> <!-- End the main column -->
    </div>
</div>
</asp:Content>


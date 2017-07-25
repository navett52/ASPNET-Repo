<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    3/7/2017
    Midterm
    Create a page to help decide if someone should get Linux or Windows
    src: http://www.computerhope.com/issues/ch000575.htm
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/EvansSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tellepet_midterm_Default" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Midterm.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <asp:ScriptManager ID="smnQuestions" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updQuestions" runat="server">
        <ContentTemplate>
            <div id="content">
                <div id="question1" class="question" runat="server" visible="false">
                    <h1>What is your price range?</h1>
                    <asp:DropDownList ID="ddQuestion01" runat="server"></asp:DropDownList>
                </div>

                <div id="question2" class="question" runat="server" visible="false">
                    <h1>Do you want your o/s easy to use?</h1>
                    <asp:DropDownList ID="ddQuestion02" runat="server"></asp:DropDownList>
                </div>

                <div id="question3" class="question" runat="server" visible="false">
                    <h1>Is reliability very important?</h1>
                    <asp:DropDownList ID="ddQuestion03" runat="server"></asp:DropDownList>
                </div>

                <div id="question4" class="question" runat="server" visible="false">
                    <h1>Do you want a lot of commercial software?</h1>
                    <asp:DropDownList ID="ddQuestion04" runat="server"></asp:DropDownList>
                </div>

                <div id="question5" class="question" runat="server" visible="false">
                    <h1>Do you want a majority of free software?</h1>
                    <asp:DropDownList ID="ddQuestion05" runat="server"></asp:DropDownList>
                </div>

                <div id="question6" class="question" runat="server" visible="false">
                    <h1>Is new hardware support important?</h1>
                    <asp:DropDownList ID="ddQuestion06" runat="server"></asp:DropDownList>
                </div>

                <div id="question7" class="question" runat="server" visible="false">
                    <h1>Is security important to you?</h1>
                    <asp:DropDownList ID="ddQuestion07" runat="server"></asp:DropDownList>
                </div>

                <div id="question8" class="question" runat="server" visible="false">
                    <h1>Is company support important to you?</h1>
                    <asp:DropDownList ID="ddQuestion08" runat="server"></asp:DropDownList>
                </div>

                <div id="question9" class="question" runat="server" visible="false">
                    <h1>Do you want a variety of uses?</h1>
                    <asp:DropDownList ID="ddQuestion09" runat="server"></asp:DropDownList>
                </div>

                <div id="result" runat="server">
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit Answer" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnRedo" runat="server" Text="Redo" OnClick="btnRedo_Click" visible="false"/>
</asp:Content>
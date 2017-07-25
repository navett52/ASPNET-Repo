<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/15/2017
    Assignment04
    Create a page to display something interesting done with web scraping
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/EvansSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WebScraping_Assn04_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container text-center">
        <asp:ScriptManager ID="scrmanManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updFirst" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblSiteScrapings" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnScrape1" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:TextBox ID="txtSite1" runat="server">http://homepages.uc.edu/~tellepet/forum/mc_map.php</asp:TextBox>
        <asp:TextBox ID="txtSite2" runat="server">http://stackoverflow.com/questions/238002/replace-line-breaks-in-a-string-c-sharp</asp:TextBox>
        <asp:Button ID="btnScrape1" runat="server" Text="Frankensite!" OnClick="btnScrape1_Click" />
        <asp:Label ID="lblInfo" runat="server" Text="Label">Hit the button to test, or change the urls!</asp:Label>
    </div>
</asp:Content>


<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/22/2017
    Assignment05
    Create an interface to choose a tool and add enchantments to it
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/EvansSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Databasing_Assn05_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Databsing.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddTool" runat="server" OnSelectedIndexChanged="ddTool_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox CssClass="list" ID="lbAvailableEnchantments" SelectionMode="Multiple" runat="server"></asp:ListBox>
                        </td>
                        <td>
                            <asp:ListBox CssClass="list" ID="lbSelectedEnchantments" SelectionMode="Multiple" runat="server"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAddAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRemoveAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAddSelected" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRemoveSelected" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
            </Triggers>
         </asp:UpdatePanel>
        <div id="buttons">
            <asp:Button ID="btnAddAll" runat="server" Text="Add All" OnClick="btnAddAll_Click" />
            <asp:Button ID="btnRemoveAll" runat="server" Text="Remove All" OnClick="btnRemoveAll_Click" />
            <asp:Button ID="btnAddSelected" runat="server" Text="Add Selected" OnClick="btnAddSelected_Click" />
            <asp:Button ID="btnRemoveSelected" runat="server" Text="Remove Selected" OnClick="btnRemoveSelected_Click" />
        </div>
        <div id="submit">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </div>

</asp:Content>


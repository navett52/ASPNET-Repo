<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/1/2017
    Assignment02
    Creating a page that has a keypad on it
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Rewards/RewardsMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Rewards_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Rewards.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RewardsBody" Runat="Server">

        <div class="container">
        <div class="row">
            <!-- The table holding all keys that can be pressed as well as the display of what is being typed -->
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblLoyaltyNum" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="rewardBtn">
                        <asp:Button ID="btn1" CssClass="rewardBtnCSharp" runat="server" Text="1" />
                    </td>
                    <td class="rewardBtn">
                        <asp:Button ID="btn2" CssClass="rewardBtnCSharp" runat="server" Text="2" />
                    </td>
                    <td class="rewardBtn">
                        <asp:Button ID="btn3" CssClass="rewardBtnCSharp" runat="server" Text="3" />
                    </td>
                </tr>
                <tr>
                    <td class="rewardBtn">
                        <asp:Button ID="btn4" CssClass="rewardBtnCSharp" runat="server" Text="4" />
                    </td>
                    <td class="rewardBtn">
                        <asp:Button ID="btn5" CssClass="rewardBtnCSharp" runat="server" Text="5" />
                    </td>
                    <td class="rewardBtn">
                        <asp:Button ID="btn6" CssClass="rewardBtnCSharp" runat="server" Text="6" />
                    </td>
                </tr>
                <tr>
                    <td class="rewardBtn">
                        <asp:Button ID="btn7" CssClass="rewardBtnCSharp" runat="server" Text="7" />
                    </td>
                    <td class="rewardBtn">
                        <asp:Button ID="btn8" CssClass="rewardBtnCSharp" runat="server" Text="8" />
                    </td>
                    <td class="rewardBtn">
                        <asp:Button ID="btn9" CssClass="rewardBtnCSharp" runat="server" Text="9" />
                    </td>
                </tr>
                <tr>
                    <td class="rewardBtn">
                        <asp:Button ID="btnClear" CssClass="rewardBtnCSharp" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                    <td class="rewardBtn">
                        <asp:Button ID="btn0" CssClass="rewardBtnCSharp" runat="server" Text="0" />
                    </td>
                    <td class="rewardBtn">
                        <asp:Button ID="btnBackspace" CssClass="rewardBtnCSharp" runat="server" Text="Backspace" OnClick="btnBackspace_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="rewardBtn" id="enter">
                        <asp:Button ID="btnEnter" CssClass="rewardBtnCSharp" runat="server" Text="Enter" OnClick="btnEnter_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>


<%--
    Evan Tellep and Jake Reilman
    Prof. Bill Nicholson
    ASP.NET
    Assignment 07
    3/22/17
    Assn Desc: Creating web form to generate reports
    Ref:  
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Assn07Master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tellepet_reilmajb_Assignment07_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="Server">
        <asp:Table ID="tContent" runat="server" Height="500px" Width="700px" HorizontalAlign="Center">
            <asp:TableRow runat="server">

                <asp:TableCell runat="server">
                        <asp:Calendar ID="calStartDate" runat="server" BackColor="White" BorderColor="Black"></asp:Calendar>
                </asp:TableCell>

                <asp:TableCell runat="server">
                        <asp:Calendar ID="calEndDate" runat="server" BackColor="White" BorderColor="Black"></asp:Calendar>
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">

                <asp:TableCell runat="server">
                    <div class="center">
                        Minimum Quantity Sold
                    <br />
                        <asp:TextBox ID="txtMinQty" runat="server"></asp:TextBox>
                    </div>
                </asp:TableCell>

                <asp:TableCell runat="server">
                    <div class="center">
                        Maximum Quantity Sold
                    <br />
                        <asp:TextBox ID="txtMaxQty" runat="server"></asp:TextBox>
                    </div>
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">

                <asp:TableCell runat="server">
                    <div class="center">
                        Pick the Product<br />
                        <asp:DropDownList ID="ddProducts" runat="server" Width="300"></asp:DropDownList>
                    </div>
                </asp:TableCell>

                <asp:TableCell runat="server">
                    <div class="center">
                        Pick the store(s)
                    <br />
                        <div id="storeList">
                            <asp:CheckBoxList ID="cblStores" runat="server"></asp:CheckBoxList>
                        </div>
                    </div>
                </asp:TableCell>

            </asp:TableRow>
        </asp:Table>
        <div class="center">
            <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" BorderStyle="Solid" Height="50px" Width="115px" />
        </div>
</asp:Content>


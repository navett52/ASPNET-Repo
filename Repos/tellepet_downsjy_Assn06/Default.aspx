<%--
    Evan Tellep
    Jeff Downs
    ASP.NET
    Bill Nicholson
    3/1/2017
    Assignment 06
    Making a from to intake values for a stored procedure that inserts transactions and their details into
        the appropriate tables.
    Ref: Old Assignments
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<link href="Themes/StyleSheet.css" rel="stylesheet" />
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="calendar">
            Date
        <br /><asp:Calendar ID="calDateOfTrans" runat="server"></asp:Calendar>
        </div>
      <br />Loyalty Number
        <br /><asp:DropDownList ID="ddLoyaltyNumbers" runat="server"></asp:DropDownList> <%-- No dependencies --%>
        <br />Time (00:00:00)
         <br /> <asp:TextBox ID="txtTimeOfTrans" runat="server"></asp:TextBox> <%-- Use Regex to validate time format --%>
        <br />Type 
        <br /><asp:DropDownList ID="ddTransType" runat="server"></asp:DropDownList> <%-- No dependencies --%>
        <br />Stores
         <br /><asp:DropDownList ID="ddStores" runat="server"></asp:DropDownList> <%-- No dependencies --%>
        <br />Employee
         <br /><asp:DropDownList ID="ddEmpl" runat="server"></asp:DropDownList> <%-- Dependencies: Stores --%>
        <br />Product
         <br /><asp:DropDownList ID="ddProduct" runat="server" AutoPostBack="true"></asp:DropDownList> <%-- Dependencies: Stores --%>
        <br />Qty.
         <br /><asp:TextBox ID="txtQty" runat="server"></asp:TextBox> <%-- Validate to only accept numbers --%>
        <br />Price Per Sellable Unit
         <br /><asp:DropDownList ID="ddPricePerSellableUnitAsMarked" runat="server"></asp:DropDownList> <%-- Dependencies: Product --%>
        <br />Price Per Sellable Item
         <br /><asp:DropDownList ID="ddPricePerSellableUnitToCustomer" runat="server"></asp:DropDownList> <%-- Dependencies: Product --%>
        <br />Transaction Comment
         <br /><asp:TextBox ID="txtTransComment" runat="server"></asp:TextBox>
        <br />Transaction Detail Comment
         <br /><asp:TextBox ID="txtTransDetailComment" runat="server"></asp:TextBox>
        <br />Coupon Code
         <br /><asp:DropDownList ID="ddCoupon" runat="server"></asp:DropDownList> <%-- Pull from tCoupon --%>
        <br />
         <br /><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>

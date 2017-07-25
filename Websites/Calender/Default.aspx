<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="calenderHolder" %>

<%@ Register Src="~/Calender/CalendarRange.ascx" TagPrefix="uc1" TagName="CalendarRange" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:CalendarRange runat="server" ID="CalendarRange" />
        <br />
        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblChosenStartDate" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblChosenThroughDate" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>

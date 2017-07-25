<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarRange.ascx.cs" Inherits="CalendarRange" %>
<asp:Table ID="Table1" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Calendar ID="calStartDate" runat="server"></asp:Calendar>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Calendar ID="calThroughDate" runat="server"></asp:Calendar>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

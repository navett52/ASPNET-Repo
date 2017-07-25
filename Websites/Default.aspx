<%-- ASP.NET Comment --%>
<!-- HTML Comment -->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Hello World" ID="lblHello" />
            <table style="border: solid 2px" id="tblTable">
                <tr>
                    <td>
                        <span>Hello from my table.</span>
                    </td>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="Change label text" OnClick="btnOK_Click" />
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" name="Bob" />
                    </td>
                    <td>
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

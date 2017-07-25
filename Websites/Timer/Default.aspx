<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:UpdatePanel ID="updMain" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btnDisplay" runat="server" Text="999" />
                </ContentTemplate>
                <triggers>
                    <asp:AsyncPostBackTrigger ControlID="timerMain" />
                </triggers>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="updColor" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btnColor" runat="server" Text="       " />
                    <asp:Label ID="lblUpdate" runat="server" Text="Nothing"></asp:Label>
                </ContentTemplate>
                <triggers>
                    <asp:AsyncPostBackTrigger ControlID="timerColor" />
                </triggers>
            </asp:UpdatePanel>

            <asp:Timer ID="timerMain" runat="server" Interval="30" OnTick="timerMain_Tick"></asp:Timer>
            <asp:Timer ID="timerColor" runat="server" Interval="1000" OnTick="timerColor_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>

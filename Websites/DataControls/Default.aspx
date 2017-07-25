<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="dlPopTartFlavor" runat="server" DataKeyField="PopTartFlavorID" DataSourceID="dsPopTart" OnEditCommand="dlPopTartFlavor_EditCommand" OnUpdateCommand="dlPopTartFlavor_UpdateCommand" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemTemplate>
                <asp:Label Text='<%# Eval("PopTartFlavorID") %>' runat="server" Visible="false" ID="PopTartFlavorIDLabel" />
                PopTartFlavor:
                <asp:Label Text='<%# Eval("PopTartFlavor") %>' runat="server" ID="PopTartFlavorLabel" /><br />
                <br />
                <asp:LinkButton runat="server" ID="lbButton_ItemEdit" CommandName="edit" >Edit</asp:LinkButton>
            </ItemTemplate>
            <AlternatingItemStyle BackColor="#CCCCCC" />
            <EditItemTemplate>
                PopTartFlavor:
                <asp:TextBox ID="txtPopTartFlavor_Edit" runat="server" Text='<%# Eval("PopTartFlavor") %>'></asp:TextBox>
                <asp:TextBox ID="txtPopTartFlavorID_Edit" runat="server" Text='<%# Eval("PopTartFlavorID") %>' Visible="false"></asp:TextBox>
                <br />
                <asp:LinkButton runat="server" ID="lbButton_EditUpdate" CommandName="update" >Update</asp:LinkButton>
            </EditItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        <asp:SqlDataSource runat="server" ID="dsPopTart" 
            ConnectionString='<%$ ConnectionStrings:PopTartsConnectionString %>' 
            DeleteCommand="DELETE FROM [tPopTartFlavor] WHERE [PopTartFlavorID] = @original_PopTartFlavorID AND [PopTartFlavor] = @original_PopTartFlavor" 
            InsertCommand="INSERT INTO [tPopTartFlavor] ([PopTartFlavor]) VALUES (@PopTartFlavor)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM [tPopTartFlavor] ORDER BY [PopTartFlavor]" 
            UpdateCommand="UPDATE [tPopTartFlavor] SET [PopTartFlavor] = @PopTartFlavor WHERE [PopTartFlavorID] = @original_PopTartFlavorID">
            <DeleteParameters>
                <asp:Parameter Name="original_PopTartFlavorID" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="original_PopTartFlavor" Type="String"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PopTartFlavor" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PopTartFlavor" Type="String"></asp:Parameter>
                <asp:Parameter Name="original_PopTartFlavorID" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="original_PopTartFlavor" Type="String"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

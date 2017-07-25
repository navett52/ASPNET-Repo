<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvCat" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CatID" DataSourceID="dsCat" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="CatID" HeaderText="CatID" InsertVisible="False" ReadOnly="True" SortExpression="CatID" Visible="False" />
                <asp:BoundField DataField="Breed" HeaderText="Breed" SortExpression="Breed" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="dsCar" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsCat" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:PopTartsConnectionString %>" DeleteCommand="DELETE FROM [tCat] WHERE [CatID] = @original_CatID AND [Breed] = @original_Breed" InsertCommand="INSERT INTO [tCat] ([Breed]) VALUES (@Breed)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [tCat] ORDER BY [Breed]" UpdateCommand="UPDATE [tCat] SET [Breed] = @Breed WHERE [CatID] = @original_CatID AND [Breed] = @original_Breed">
            <DeleteParameters>
                <asp:Parameter Name="original_CatID" Type="Int32" />
                <asp:Parameter Name="original_Breed" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Breed" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Breed" Type="String" />
                <asp:Parameter Name="original_CatID" Type="Int32" />
                <asp:Parameter Name="original_Breed" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

<%--
    Evan Tellep
    Prof. Bill Nicholson
    ASP.NET
    Mevtric (Final)
    4/26/2017
    Ref: A lot of MSDN, Stack Overflow, and some Code Project
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/tellepet_Final/FinalMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tellepet_Final_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="scrAjax" runat="server"></asp:ScriptManager>
    <div class="row">
        <asp:UpdatePanel ID="updNumOfEmployeesPerStore" runat="server">
            <ContentTemplate>
                <%-- Store Status Ajax Configuration --%>
                <asp:Timer ID="tmrUpdNumOfEmployeesPerStore" runat="server" Interval="3000"></asp:Timer>
                <asp:Chart class="col-8" ID="chNumOfEmployeesPerStore" runat="server" DataSourceID="dsNumOfEmployees" Height="484px" Width="1181px">
                    <Series>
                        <asp:Series Name="sNumOfEmployeesPerStore" ChartType="Bar" XValueMember="StoreName" YValueMembers="NumOfEmployees"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="chaNumOfEmployeesPerStore"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="dsNumOfEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:GroceryStoreSimulatorConnectionString %>"
                    SelectCommand="spDisplayStoresWithLessOrGreaterThanGivenEmployees_tellepet" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddNumOfEmployees" DefaultValue="600" Name="numOfSpecifiedEmployees" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="ddOperator" DefaultValue="0" Name="operator" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <%-- End Store Status Ajax Configuration --%>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:DropDownList ID="ddOperator" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddNumOfEmployees" runat="server"></asp:DropDownList>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%-- Store Status Ajax Configuration --%>
                <asp:Timer ID="Timer1" runat="server" Interval="3000"></asp:Timer>
                <asp:Chart class="col-8" ID="Chart1" runat="server" DataSourceID="dsProductInfo" Height="499px" Width="1183px">
                    <Series>
                        <asp:Series Name="sNumOfEmployeesPerStore" XValueMember="Name" YValueMembers="SumOfCaloriesSold"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="chaNumOfEmployeesPerStore"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="dsProductInfo" runat="server" ConnectionString="<%$ ConnectionStrings:GroceryStoreSimulatorConnectionString %>"
                    SelectCommand="SELECT TOP(10) vProductInfo.Name, vProductInfo.Description, tTransaction.TransactionTypeID, SUM(vProductInfo.Calories) AS SumOfCaloriesSold FROM tTransactionDetail INNER JOIN tTransaction ON tTransactionDetail.TransactionID = tTransaction.TransactionID INNER JOIN vProductInfo ON tTransactionDetail.ProductID = vProductInfo.ProductID WHERE (tTransaction.TransactionTypeID = 1) GROUP BY vProductInfo.Name, vProductInfo.Description, tTransaction.TransactionTypeID ORDER BY SUM(vProductInfo.Calories) DESC">
                </asp:SqlDataSource>
                <%-- End Store Status Ajax Configuration --%>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="updCustomCharts" runat="server">
            <ContentTemplate>

            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Panel id="pnlCustomCharts" runat="server" postbackurl="~/tellepet_Final/Contruct.aspx"></asp:Panel>
    </div>
</asp:Content>

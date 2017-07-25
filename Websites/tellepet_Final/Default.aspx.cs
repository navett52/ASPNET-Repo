/*
 * <%--
    Evan Tellep
    Prof. Bill Nicholson
    ASP.NET
    Mevtric (Final)
    4/26/2017
    Ref: A lot of MSDN, Stack Overflow, and some Code Project
    Props: Given to Bill Nicholson for providing the ADO.NET stuffs
--%>
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class tellepet_Final_Default : System.Web.UI.Page
{

    // Make sure you understand why these properties are static
    private static System.Data.SqlClient.SqlConnection conn;
    private static SqlCommand comm;
    private static SqlDataReader reader;

    /**
     *  Page Load event handler
     * 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // We will open the connection one time and leave it open.
            OpenConnection();

            //Setting the chart interval to make sure we get a label for every piece of data
            setChartInterval(chNumOfEmployeesPerStore, "chaNumOfEmployeesPerStore", 1, 'x');

            //Populate dropdown for > <
            ddOperator.Items.Add(new ListItem("Greater than", "1"));
            ddOperator.Items.Add(new ListItem("Less than", "0"));

            //Populate dropdown for num of employees
            for (int i = 0; i < 1000; i += 100)
            {
                ddNumOfEmployees.Items.Add(new ListItem(Convert.ToString(i), Convert.ToString(i)));
            }
        }
        //Keep making sure the chart stays at proper interval
        setChartInterval(chNumOfEmployeesPerStore, "chaNumOfEmployeesPerStore", 1, 'x');

        //If there is a chart hiding in our session variable, add it to the page.
        if (Session["customChart"] != null)
        {
            pnlCustomCharts.Controls.Add(((Chart)Session["customChart"]));
        }
    }

    /// <summary>
    /// Sets the chart interval to how many labels will be displayed.
    /// </summary>
    /// <param name="ChartControl">The chart you want to set the interval for</param>
    /// <param name="ChartAreaID">The chart area you want to set the interval for</param>
    /// <param name="Interval">The interval you want to set it to</param>
    /// <param name="Axis">The axis you want to set the interval for</param>
    public void setChartInterval(Chart ChartControl, String ChartAreaID, int Interval, Char Axis)
    {
        switch (Axis)
        {
            case 'x':
                ChartControl.ChartAreas[ChartAreaID].AxisX.LabelStyle.Interval = Interval;
                break;
            case 'y':
                ChartControl.ChartAreas[ChartAreaID].AxisY.LabelStyle.Interval = Interval;
                break;
        }

    }

    /// <summary>
    /// This method takes care of populating the number of employees by store chart
    /// </summary>
    /// <param name="ChartControl">The chart to update</param>
    /// <param name="SeriesID">The series to update</param>
    /// <param name="numOfSpecifiedEmployees">The num of employees you want to select against</param>
    /// <param name="Operator">Greater than or Less than</param>
    public void populateNumOfEmployeesChart(Chart ChartControl, String SeriesID, int numOfSpecifiedEmployees, String Operator)
    {
        List<int> numOfEmployees = new List<int>();
        List<string> storesWhoHaveEmployees = new List<string>();
        String staffingSituation = "";

        switch (Operator)
        {
            case "Greater than":
                staffingSituation = @"SELECT NumOfEmployees, StoreName FROM NumOfEmployeesPerStore_tellepet WHERE (NumOfEmployees > @numOfSpecifiedEmployees)";
                break;
            case "Less than":
                staffingSituation = @"SELECT NumOfEmployees, StoreName FROM NumOfEmployeesPerStore_tellepet WHERE (NumOfEmployees < @numOfSpecifiedEmployees)";
                break;
        }

        comm = new SqlCommand(staffingSituation, conn);
        comm.Parameters.Add(new SqlParameter("numOfSpecifiedEmployees", numOfSpecifiedEmployees));
        reader = comm.ExecuteReader();
        ChartControl.DataBindTable(reader, "StoreName");
        ChartControl.DataBind();
        try { reader.Close(); }
        catch (Exception ex) { }
    }

    /**
     * Open the connection to the database
     */
    private void OpenConnection()
    {
        System.Configuration.ConnectionStringSettings strConn;
        strConn = ReadConnectionString();
        // Console.WriteLine(strConn.ConnectionString);

        conn = new System.Data.SqlClient.SqlConnection(strConn.ConnectionString);

        // This could go wrong in so many ways...
        try
        {
            Controls.Add(new LiteralControl("<p>Connection Succeeded</p>"));
            conn.Open();
        }
        catch (Exception ex)
        {
            // Miserable error handling...
            Response.Write(ex.Message);
            Controls.Add(new LiteralControl("<p>" + ex.Message + "</p>"));
        }
    }

    /** Read the connection string from the web.config file. 
    * This is a much more secure way to store sensitive information. Don't hard-code connection information in the source code.
    * Adapted from http://msdn.microsoft.com/en-us/library/ms178411.aspx
    */
    private System.Configuration.ConnectionStringSettings ReadConnectionString()
    {
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/Web.config";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulatorConnectionString"];
        }
        return connString;
    }

}
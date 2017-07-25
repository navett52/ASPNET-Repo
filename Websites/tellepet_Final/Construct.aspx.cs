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

using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class tellepet_Final_Construct : System.Web.UI.Page
{
    // Make sure you understand why these properties are static
    private static System.Data.SqlClient.SqlConnection conn;
    private static SqlCommand comm;
    private static SqlDataReader reader;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OpenConnection();

            //Populate the table check box list
            DataTable tables = conn.GetSchema("Tables");
            foreach (DataRow row in tables.Rows)
            {
                string tableName = "";
                if (Convert.ToString(row[2])[0] == 't' || Convert.ToString(row[2])[0] == 'v')
                {
                    tableName = Convert.ToString(row[2]).Substring(1, Convert.ToString(row[2]).Length - 1);
                    chblDBTables.Items.Add(new ListItem(tableName, Convert.ToString(row[2])));
                }
                else
                {
                    chblDBTables.Items.Add(new ListItem(Convert.ToString(row[2]), Convert.ToString(row[2])));
                }
            }
            //Display the table in order
            var orderedTables = chblDBTables.Items.Cast<ListItem>().OrderBy(i => i.Text).ToArray();
            chblDBTables.Items.Clear();
            chblDBTables.Items.AddRange(orderedTables);
        }
    }

    /// <summary>
    /// Constructs the chart to be added to the controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnConstruct_Click(object sender, EventArgs e)
    {
        //Create a list for the selected tables
        List<String> tables = new List<string>();
        foreach (ListItem item in chblDBTables.Items)
        {
            if (item.Selected)
            {
                tables.Add(item.Value);
            }
        }

        //Create a list for selected columns
        List<String> columns = new List<String>();
        foreach (ListItem item in chblColumns.Items)
        {
            if (item.Selected)
            {
                if (!columns.Contains(item.Value + "." + item.Text))
                {
                    columns.Add(item.Value + "." + item.Text);
                }
            }
        }

        //Response.Write(constructQuery(tables, columns, Convert.ToInt32(txtTopRecords.Text))); //Debug Statement

        //Takes care of loading all necassary components for a chart
        Chart chart = new Chart();
        Series series = new Series("Default");
        series.ChartType = SeriesChartType.Column;
        chart.Series.Add(series);
        ChartArea chartArea = new ChartArea();
        chart.ChartAreas.Add(chartArea);

        //Construct the query using the parameters we grabbed from the form
        string[] queryData = constructQuery(tables, columns, Convert.ToInt32(txtTopRecords.Text));

        //Run the query that was built
        comm = new SqlCommand(queryData[0], conn);
        reader = comm.ExecuteReader();
        chart.DataBindTable(reader, queryData[1]);
        try { reader.Close(); }
        catch (Exception ex) { }

        //Put the chart in the Session variable so it can be loaded on the Default.aspx
        Session["customChart"] = chart;
        Response.Redirect("Default.aspx");
    }

    /// <summary>
    /// Constructs the query based on the info we give
    /// </summary>
    /// <param name="Tables">The tables we want to use in the query</param>
    /// <param name="Columns">The columns we wish to query</param>
    /// <param name="TopRecords">How many of the top records should we display</param>
    /// <returns></returns>
    public string[] constructQuery(List<String> Tables, List<String> Columns, int TopRecords = 0)
    {
        string[] result = new string[2];

        SelectQueryBuilder query = new SelectQueryBuilder();

        //Admittedly a bit outdated. Had to do with what I was originally doing. More so putting this here so I know to revisit it.
        if (Tables.Count > 1)
        {
            string[] tablesArray = Tables.ToArray();
            query.SelectFromTable(tablesArray[0]);
        }
        else
        {
            query.SelectFromTable(Tables[0]);
        }

        //The area that takes care of creating relationships if they exist
        if (Tables.Count > 1)
        {
            //Gets the selected tables
            List<string> selectedText = new List<string>();
            foreach (ListItem item in chblDBTables.Items)
            {
                if (item.Selected)
                {
                    selectedText.Add(item.Text);
                }
            }

            //The main logic behind setting the joins. Only does inner currently, though now that the inner logic is done adding outter and other logic shouldn't be too awful
            foreach (String table in Tables)
            {
                List<ListItem> selectedItem = new List<ListItem>();
                foreach (ListItem column in chblColumns.Items)
                {
                    if (column.Selected && column.Value == table)
                    {
                        selectedItem.Add(column);
                    }
                }
                foreach (String comparisonTable in Tables)
                {
                    if (comparisonTable != table)
                    {
                        foreach (ListItem selectedColumn in selectedItem)
                        {
                            foreach (ListItem comparisonColumn in chblColumns.Items)
                            {
                                if (selectedColumn.Text == comparisonColumn.Text && selectedColumn.Value != comparisonColumn.Value && selectedColumn.Value != Tables[0])
                                {
                                    query.AddJoin(JoinType.InnerJoin, table, selectedColumn.Text, Comparison.Equals, comparisonTable, selectedColumn.Text);
                                    result[1] = selectedColumn.Text; //This is set arbitrarily for testing purposes. FIX IT LATER
                                }
                            }
                        }
                    }
                }
            }
        }
        //Set the columns we want to query
        query.SelectColumns(Columns.ToArray());
        //Set the amount of top records we want to see
        query.TopRecords = TopRecords;

        //Put the query that was buil into the first index
        result[0] = query.BuildQuery();
        return result;
    }

    /// <summary>
    /// Takes care of populating the columns check box list based on the tables selected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chblDBTables_SelectedIndexChanged(object sender, EventArgs e)
    {
        int lastSelectedIndex = 0;
        string lastSelectedValue = "";

        chblColumns.Items.Clear();

        foreach (ListItem listitem in chblDBTables.Items)
        {
            if (listitem.Selected)
            {
                int thisIndex = chblDBTables.Items.IndexOf(listitem);

                if (lastSelectedIndex < thisIndex)
                {
                    lastSelectedIndex = thisIndex;
                    lastSelectedValue = listitem.Value;
                }
                comm = new SqlCommand("SELECT * FROM " + listitem.Value, conn);
                reader = comm.ExecuteReader();
                chblColumns.Items.Add(new ListItem(listitem.Text + " columns below, do not select this item."));
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    chblColumns.Items.Add(new ListItem(reader.GetName(i), listitem.Value));
                }
                reader.Close();
            }
        }
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
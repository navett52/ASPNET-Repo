using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
private void PopulateDropDown()
    {
        //variables to hold the data returned by the query and add it to the dropdown menu
        int modelID;
        string model;
        ListItem modelItem;

        // Clear the list box, in case we've already loaded something into it.
        drpModel.Items.Clear();
        // create sql command object with the open connection object
        comm = new SqlCommand("SELECT * FROM tRobo", conn);
        //try to close the reader in case it's stil open, do nothing if we can't
        try
        {
            reader.Close();
        } catch (Exception ex)
        {
        }

        //use the reader object to execuet our query
        reader = comm.ExecuteReader();

        //iterate through the dataset line by line
        while (reader.Read())
        {
            //stores the primary key of the model
            modelID = reader.GetInt32(0);
            //stores the name of the model
            model = reader.GetString(1);
            //creates a list item with the text of the name of the model, and the value of the primary key of the model
            modelItem = new ListItem(model, modelID.ToString());
            //adds the item to the dropdown menu
            drpModel.Items.Add(modelItem);
        }
        //populates the options list box with options for the default model in the dropdown
        PopulateOptionList(Convert.ToInt32(drpModel.SelectedValue));
    }
*/

public partial class _Default : System.Web.UI.Page {

    private static System.Data.SqlClient.SqlConnection conn;
    private static SqlCommand comm;
    private static SqlDataReader reader;

    static Group01 group01;
    static Group02 group02;
    static Group03 group03;
    static Group04 group04;
    static Group05 group05;
    protected void Page_Load(object sender, EventArgs e)
    {
        instantiateObjects();
    }

    private void instantiateObjects()
    {
        group01 = new Group01();
        group02 = new Group02();
        group03 = new Group03();
        group04 = new Group04();
        group05 = new Group05();

        if(!IsPostBack)
        {
            OpenConnection();
        }
    }

    private void Group01Method()
    {
        int productIDWithMostReturns = group01.GetProductIDWithTheMostReturns();

        comm = new SqlCommand("SELECT tProduct.Description, tName.Name FROM tProduct INNER JOIN tName ON tProduct.NameID = tName.NameID WHERE(tProduct.ProductID = " + productIDWithMostReturns + ")", conn);
        //try to close the reader in case it's stil open, do nothing if we can't
        try
        {
            reader.Close();
        }
        catch (Exception ex)
        {
        }

        reader = comm.ExecuteReader();

        reader.Read();


    }

    private void OpenConnection()
    {
        //creates a configuration setting object for the connection string
        System.Configuration.ConnectionStringSettings strConn;
        //sets the value of the connections setting object to the connection string
        strConn = ReadConnectionString();

        //initializes the connection object with the value of our connection string
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
        }
    }

    /**
     * Returns a settings object that holds the connection string for the database
     */
private System.Configuration.ConnectionStringSettings ReadConnectionString()
    {
        //string to store the path so the web.config file
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";

        //creates an object that points to the web.config file
        System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;

        //if the connection string is present, sets the object to equal the connection string in the web.config file
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulatorConnectionString"];
        }

        //returns our connection string settings object
        return connString;
    }
}
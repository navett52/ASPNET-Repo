/*
<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/22/2017
    Assignment05
    Code to connect to the database as well as add functionality to the interface.
--%> 
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Databasing_Assn05_Default : System.Web.UI.Page
{

    //Making the objects that interact with the DB
    private static System.Data.SqlClient.SqlConnection conn;
    private static SqlCommand comm;
    private static SqlDataReader reader;

    /// <summary>
    /// Populate the dropdown and populate the available enchantments for the first dropdown item on the page load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        openConnection();
        if (!IsPostBack)
        {
            populateDropDown();
            populateLeftListBox(ddTool.SelectedValue);
        }
    }

    /// <summary>
    /// Changing the available enchantments based on the selected tool
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddTool_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbSelectedEnchantments.Items.Clear();
        populateLeftListBox(ddTool.SelectedValue);
    }

    /// <summary>
    /// Opening the database connection
    /// </summary>
    public void openConnection()
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
            Console.WriteLine(ex.Message);
        }
    }

    /** Read the connection string from the web.config file. 
      * This is a much more secure way to store sensitive information. Don't hard-code connection information in the source code.
      * Adapted from http://msdn.microsoft.com/en-us/library/ms178411.aspx
      */
    private System.Configuration.ConnectionStringSettings ReadConnectionString()
    {
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["tellepetDB"];
        }
        return connString;
    }

    public void populateDropDown()
    {
        String tmp;
        int tmpID;
        ListItem myListItem;

        // Clear the list box, in case we've already loaded something into it.
        ddTool.Items.Clear();
        comm = new SqlCommand("SELECT * FROM tTool", conn);
        try { reader.Close(); } catch (Exception ex) { }
        reader = comm.ExecuteReader();

        while (reader.Read())
        {
            tmpID = reader.GetInt32(0);
            tmp = reader.GetString(1);
            //System.Console.WriteLine(tmp);
            //lbFish.Items.Add(tmp);
            myListItem = new ListItem(tmp, Convert.ToString(tmpID));
            ddTool.Items.Add(myListItem);
        }
    }

    /// <summary>
    /// Populate the left list box based on the selected drop down item
    /// </summary>
    /// <param name="selectedValue"></param>
    public void populateLeftListBox(String selectedValue)
    {
        String tmp;
        int tmpID;
        ListItem myListItem;
        // Clear the list box, in case we've already loaded something into it.
        lbAvailableEnchantments.Items.Clear();
        comm = new SqlCommand("SELECT tAvailableEnchantment.AvailableEnchantment FROM tAvailableEnchantment INNER JOIN tTool_AvailableEnchantment ON tAvailableEnchantment.AvailableEnchantmentID = tTool_AvailableEnchantment.AvailableEnchantmentID INNER JOIN tTool ON tTool_AvailableEnchantment.ToolID = tTool.ToolID WHERE tTool.ToolID =" + selectedValue , conn);
        try { reader.Close(); } catch (Exception ex) { }
        reader = comm.ExecuteReader();

        while (reader.Read())
        {
            tmp = reader.GetString(0);
            //System.Console.WriteLine(tmp);
            //lbFish.Items.Add(tmp);
            myListItem = new ListItem(tmp);
            lbAvailableEnchantments.Items.Add(myListItem);
        }
    }

    /// <summary>
    /// Adds all available enchantments over to selected enchantments
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAll_Click(object sender, EventArgs e)
    {
        lbSelectedEnchantments.Items.Clear();
        foreach (ListItem item in lbAvailableEnchantments.Items)
        {
            lbSelectedEnchantments.Items.Add(item);
        }
        lbAvailableEnchantments.Items.Clear();
    }

    /// <summary>
    /// Removes all selected enchantments
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemoveAll_Click(object sender, EventArgs e)
    {
        lbSelectedEnchantments.Items.Clear();
        populateLeftListBox(ddTool.SelectedValue);
    }

    /// <summary>
    /// Add the selected item to the selected enchantments box
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddSelected_Click(object sender, EventArgs e)
    {
        if (lbAvailableEnchantments.SelectedIndex >= 0)
        {
            lbSelectedEnchantments.Items.Add(lbAvailableEnchantments.SelectedItem);
            lbAvailableEnchantments.Items.Remove(lbAvailableEnchantments.SelectedItem);
        }
    }

    /// <summary>
    /// Remove the selected item from the selected enchantments box and puts it back into the available enchantments box
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemoveSelected_Click(object sender, EventArgs e)
    {
        if (lbSelectedEnchantments.SelectedIndex >= 0)
        {
            lbAvailableEnchantments.Items.Add(lbSelectedEnchantments.SelectedItem);
            lbSelectedEnchantments.Items.Remove(lbSelectedEnchantments.SelectedItem);
        }
    }

    /// <summary>
    /// Submits all the selected enchantments and the selected tool to the summary page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<string> enchants = new List<string>();
        foreach (ListItem item in lbSelectedEnchantments.Items)
        {
            enchants.Add(item.Text);
        }
        Page.Session["toolEnchantments"] = enchants;
        Response.Redirect("~/Databasing_Assn05/Display.aspx?tool=" + ddTool.SelectedItem.Text);
    }
}
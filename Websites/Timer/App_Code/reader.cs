using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for reader
/// </summary>
public class reader
{
    public String read()
    {
        SqlDataReader dataReader = null;
        // Open the conection, write the record to the store file, close the connection. No worries.
        SqlConnection myConnection;

        // These credentials must have 'insert' permission on the Store table!
        string connectionString = "user id=GroceryStoreSimulatorLogin;" +
                                  "password=P@ssword;server=IL-SERVER-001.uccc.uc.edu\\MSSQLSERVER2012;" +
                                  "Trusted_Connection=no;" +
                                  "database=GroceryStoreSimulator; " +
                                  "connection timeout=30";

        myConnection = new System.Data.SqlClient.SqlConnection(connectionString);
        myConnection.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = myConnection;
        cmd.CommandText = "select top 1 [LastName], [FirstName] from tEmpl Order by EmplID DESC";
        cmd.CommandText = "select top 1 [LastName], [FirstName] FROM tEmpl WHERE EmplID = " + ((new Random().Next(3489)) + 1);
        //cmd.CommandText = "select foo from [fGetProductInfoForDisplayByProductID]";
        cmd.CommandType = CommandType.Text;
        Boolean found = false;
        String result = "";
        try
        {
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                result = dataReader.GetString(0) + ", " + dataReader.GetString(1);
                found = true;
            }
        }
        catch (Exception ex)
        {
            result = ex.Message;
            found = false;
        }
        finally
        {
            try { dataReader.Close(); } catch (Exception ex) { }
        }
        return result;
    }
}
/*<%--
    Evan Tellep
    Jeff Downs
    ASP.NET
    Bill Nicholson
    3/1/2017
    Assignment 06
    Populating the form with the appropriate data then running the stored procedure.
    Ref: Old Assignments
--%>*/
using ds_TransTypeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ds_LoyaltyDropdownTableAdapters;
using ds_StoreTableAdapters;
using ds_ProductTableAdapters;
using ds_PricePerSellableUnitAsMarkedTableAdapters;
using ds_EmployeeTableAdapters;
using ds_EmployeeOfSpecificStoreTableAdapters;
using ds_CouponTableAdapters;
using System.Data;

public partial class _Default : System.Web.UI.Page {
    //Making the objects that interact with the DB
    private static System.Data.SqlClient.SqlConnection conn;
    private static SqlCommand comm;
    private static SqlDataReader reader;

    /// <summary>
    /// Populate the dropdown and populate the available enchantments for the first dropdown item on the page load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            openConnection();

            //Populating the Transaction Type drop down using the databse.
            tTransactionTypeTableAdapter transTypeAdapter = new tTransactionTypeTableAdapter();
            ds_TransType.tTransactionTypeDataTable transTypes = transTypeAdapter.GetData();
            ddTransType.DataTextField = "TransactionType";
            ddTransType.DataValueField = "TransactionTypeID";
            ddTransType.DataSource = transTypes;
            ddTransType.DataBind();

            //Populating Loyalty Numbers to drop down using data set.
            tLoyaltyTableAdapter loyaltyAdapter = new tLoyaltyTableAdapter();
            ds_LoyaltyDropdown.tLoyaltyDataTable loyaltyNumber = loyaltyAdapter.GetData();
            ddLoyaltyNumbers.DataTextField = "LoyaltyNumber";
            ddLoyaltyNumbers.DataValueField = "LoyaltyID";
            ddLoyaltyNumbers.DataSource = loyaltyNumber;
            ddLoyaltyNumbers.DataBind();

            //Populating Stores to drop down using data set.
            tStoreTableAdapter storeAdapter = new tStoreTableAdapter();
            ds_Store.tStoreDataTable store = storeAdapter.GetData();
            ddStores.DataTextField = "Store";
            ddStores.DataValueField = "StoreID";
            ddStores.DataSource = store;
            ddStores.DataBind();

            //Populating Product into drop down using data set
            tProductTableAdapter productAdapter = new tProductTableAdapter();
            ds_Product.tProductDataTable product = productAdapter.GetData();
            ddProduct.DataTextField = "Description";
            ddProduct.DataValueField = "ProductID";
            ddProduct.DataSource = product;
            ddProduct.DataBind();

            //Populating Employees into drop down using data set.
            tEmplTableAdapter emplAdapter = new tEmplTableAdapter();
            ds_Employee.tEmplDataTable employee = emplAdapter.GetData();
            ddEmpl.DataTextField = "Empl";
            ddEmpl.DataValueField = "EmplID";
            ddEmpl.DataSource = employee;
            ddEmpl.DataBind();

            //Populating Coupons into drop down using data set.
            tCouponTableAdapter couponAdapter = new tCouponTableAdapter();
            ds_Coupon.tCouponDataTable coupon = couponAdapter.GetData();
            ddCoupon.DataTextField = "Coupon";
            ddCoupon.DataValueField = "CouponDetailID";
            ddCoupon.DataSource = coupon;
            ddCoupon.DataBind();

            //Populating both price per sellable unit dropdowns on initial load
            populatePriceDropdown();

            //Populating Employee based on Store in initial Load
            popluateEmployeeDropdown();
        }

        //Repopulating both price per sellable unit dropdowns on any other load
        populatePriceDropdown();

        //Populating Employee based on Store on every other load
        popluateEmployeeDropdown();
    }



    /// <summary>
    /// Opening the database connection
    /// </summary>
    public void openConnection() {
        System.Configuration.ConnectionStringSettings strConn;
        strConn = ReadConnectionString();
        // Console.WriteLine(strConn.ConnectionString);

        conn = new System.Data.SqlClient.SqlConnection(strConn.ConnectionString);

        // This could go wrong in so many ways...
        try {
            conn.Open();
        } catch (Exception ex) {
            // Miserable error handling...
            Console.WriteLine(ex.Message);
        }
    }

    /** Read the connection string from the web.config file. 
      * This is a much more secure way to store sensitive information. Don't hard-code connection information in the source code.
      * Adapted from http://msdn.microsoft.com/en-us/library/ms178411.aspx
      */
    private System.Configuration.ConnectionStringSettings ReadConnectionString() {
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0) {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulatorPopulator"];
        }
        return connString;
    }

    protected void btnSubmit_Click(object sender, EventArgs e) {
        //Checking with regex to see if time is properly entered
        Regex checktime = new Regex(@"^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$"); //Ref: http://stackoverflow.com/questions/884848/regular-expression-to-validate-valid-time
        if (!checktime.IsMatch(txtTimeOfTrans.Text)) {
            Response.Write("The time entered is not in the correct format!");
        } else
        {
            //If time is entered correctly disect the string and enter it into a TimeSpan object
            TimeSpan timeOfTrans = new TimeSpan(Convert.ToInt32(txtTimeOfTrans.Text.Substring(0, 2)), Convert.ToInt32(txtTimeOfTrans.Text.Substring(3, 2)), Convert.ToInt32(txtTimeOfTrans.Text.Substring(6, 2)));
            //Open the DB connection and proceed to populate the variables for the stored procedure
            openConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spAddTransactionAndDetail";
            command.Parameters.AddWithValue("@LoyaltyID", Convert.ToInt32(ddLoyaltyNumbers.SelectedValue));
            command.Parameters.AddWithValue("@DateOfTransaction", calDateOfTrans.SelectedDate);
            command.Parameters.AddWithValue("@TimeOfTransaction", timeOfTrans);
            command.Parameters.AddWithValue("@TransactionTypeID", Convert.ToInt32(ddTransType.SelectedValue));
            command.Parameters.AddWithValue("@StoreID", Convert.ToInt32(ddStores.SelectedValue));
            command.Parameters.AddWithValue("@EmplID", Convert.ToInt32(ddEmpl.SelectedValue));
            command.Parameters.AddWithValue("@ProductID", Convert.ToInt32(ddProduct.SelectedValue));
            command.Parameters.AddWithValue("@Qty", Convert.ToInt32(txtQty.Text));
            command.Parameters.AddWithValue("@PricePerSellableUnitAsMarked", Convert.ToDouble(ddPricePerSellableUnitAsMarked.SelectedValue));
            command.Parameters.AddWithValue("@PricePerSellableUnitToTheCustomer", Convert.ToDouble(ddPricePerSellableUnitToCustomer.SelectedValue));
            command.Parameters.AddWithValue("@TransactionComment", txtTransComment.Text);
            command.Parameters.AddWithValue("@TransactionDetailComment", txtTransDetailComment.Text);
            command.Parameters.AddWithValue("@couponDetailID", 42);
            command.Parameters.AddWithValue("@TransactionID", 0);
            command.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// This method populates the 2 price dropdowns based on what product was selected.
    /// by Evan Tellep
    /// </summary>
    public void populatePriceDropdown() {
        //Populating Product into drop down using data set
        tPriceTableAdapter ipriceAdapter = new tPriceTableAdapter();
        ds_PricePerSellableUnitAsMarked.tProductDataTable ipricePerSellableUnit = ipriceAdapter.GetData(Convert.ToInt32(ddProduct.SelectedValue));
        ddPricePerSellableUnitAsMarked.DataTextField = "InitialPricePerSellableUnit";
        ddPricePerSellableUnitAsMarked.DataValueField = "ProductID";
        ddPricePerSellableUnitAsMarked.DataSource = ipricePerSellableUnit;
        ddPricePerSellableUnitAsMarked.DataBind();

        ddPricePerSellableUnitToCustomer.Items.Clear();
        ddPricePerSellableUnitToCustomer.Items.Add(new ListItem(ddPricePerSellableUnitAsMarked.SelectedItem.Text, ddPricePerSellableUnitAsMarked.SelectedValue));
    }

    /// <summary>
    /// Populating the employee dropdown list
    /// by Jeff Downs
    /// </summary>
    public void popluateEmployeeDropdown() {
        //Populating employees based on the specified store 
        tEmplStoreTableAdapter employeeStoreAdapter = new tEmplStoreTableAdapter();
        ds_EmployeeOfSpecificStore.tEmplDataTable employee = employeeStoreAdapter.GetData(Convert.ToInt32(ddStores.SelectedValue));
        ddEmpl.DataTextField = "Empl";
        ddEmpl.DataValueField = "StoreID";
        ddEmpl.DataSource = employee;
        ddEmpl.DataBind();
    }
}

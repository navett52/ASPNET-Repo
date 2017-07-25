using EmployeesTableAdapters;
using ProductsTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Only do this once
        if (!IsPostBack)
        {
            tEmplTableAdapter myTableAdapter = new tEmplTableAdapter();
            Employees.tEmplDataTable myTable = myTableAdapter.GetData();
            lbEmployees.DataTextField = "EmplInfo";
            lbEmployees.DataValueField = "EmplID";
            lbEmployees.DataSource = myTable;
            lbEmployees.DataBind();

            tProductTableAdapter productAdapter = new tProductTableAdapter();
            Products.tProductDataTable productTable = productAdapter.GetData();
            lbProducts.DataTextField = "Product";
            lbProducts.DataValueField = "ProductID";
            lbProducts.DataSource = productTable;
            lbProducts.DataBind();
        }
    }
}
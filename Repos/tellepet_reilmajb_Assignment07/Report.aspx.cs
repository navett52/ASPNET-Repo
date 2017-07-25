/*
<%--
    Evan Tellep and Jake Reilman
    Prof. Bill Nicholson
    ASP.NET
    Assignment 07
    3/22/17
    Assn Desc: Creating web form to generate reports
    Ref:  
--%>
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{
    List<List<string>> reportData = new List<List<string>>(); //Instantiating a class variable to grab the session variable.

    /// <summary>
    /// This page load dynamically adds html to the page filled in with the report data.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Check and cast session variable data into a List of List<string>
            if (Session["Data"] is List<List<string>>)
            {
                reportData = (List<List<string>>)Session["Data"];
            }
            int i = 1; //Counter to label each record cell as
            //Dynamically create the html and add it into the literal control
            foreach (List<string> data in reportData)
            {
                litReport.Text += "<div class=\"reportCell\""; //Open reportCell
                litReport.Text += "<h1>Store" + i + "</h1>"; //Label as reportCell
                litReport.Text += "<div class=\"store\">Store: " + data[0] + "</div>"; //Store name
                litReport.Text += "<div class=\"address\">Address: " + data[1] + "</div>"; //Store address
                litReport.Text += "<div class=\"product\">Product Info: " + data[2] + "</div>"; //Product info
                litReport.Text += "<div class=\"qty\">Quantity of Product Sold over Date Range: " + data[3] + "</div>"; //Quantity of product sold over date range
                litReport.Text += "</div>"; //Close reportCell
                i++; //Increment cell count
            }
        }
    }
}

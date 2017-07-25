/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/22/2017
    Assignment05
    Code to auto display the selected enchantments on the page
--%>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Databasing_Assn05_Display : System.Web.UI.Page
{
    //Create an array to hold the selected enchantments that were passed over
    List<string> selectedEnchants = new List<string>();

    /// <summary>
    /// Display the selected enchantments on page load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        selectedEnchants = Page.Session["toolEnchantments"] as List<string>;
        lblTitle.Text = "Your " + Request.QueryString["tool"] + " will have the following enchantments:";
        foreach (String enchant in selectedEnchants)
        {
            blSelectedEnchants.Items.Add(enchant);
        }
    }
}
/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/1/2017
    Assignment02
    Displaying the loyalty number
--%>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rewards_DisplayLoyaltyNum : System.Web.UI.Page
{
    //Creating a private variable to hold the value grabbed from the previous page
    private string loyaltyNum;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Grabbing the loyalty number out of the query string and displaying it on the page
        loyaltyNum = Request.QueryString["loyaltyNum"];
        lblLoyaltyNum.Text += loyaltyNum;
    }
}
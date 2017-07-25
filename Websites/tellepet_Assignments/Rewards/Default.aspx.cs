/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/1/2017
    Assignment02
    Code behind to add funtionality to the keypad
--%>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rewards_Default : System.Web.UI.Page
{
    //create an array to hold the generic buttons
    private Button[] numberBtns;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Add the generic buttons to the array
        numberBtns = new Button[10] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };

        //Set the same handler to the generic buttons
        foreach (Button number in numberBtns)
        {
            number.Click += numberTyping;
        }
    }

    /// <summary>
    /// Grabs the button clicked and adds it's text to the loyalty num display above keypad
    /// </summary>
    /// <param name="sender">Object that sent the event</param>
    /// <param name="e">Parameters pertaining to the event</param>
    private void numberTyping(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            Button key = (Button)sender;
            lblLoyaltyNum.Text += key.Text;
        }
    }

    /// <summary>
    /// If this button is clicked it resets the text to nothing
    /// </summary>
    /// <param name="sender">Object that fired the event</param>
    /// <param name="e">Data pertaining to the event</param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblLoyaltyNum.Text = "";
    }

    /// <summary>
    /// When clicked removes one character from the displayed string
    /// </summary>
    /// <param name="sender">Object that sent the event</param>
    /// <param name="e">Info pertaining to the event</param>
    protected void btnBackspace_Click(object sender, EventArgs e)
    {
        if (lblLoyaltyNum.Text.Length > 0)
        {
            lblLoyaltyNum.Text = lblLoyaltyNum.Text.Remove(lblLoyaltyNum.Text.Length - 1, 1);
        }
    }

    /// <summary>
    /// Redirects you to the page that displays the entered value and passes the value along via query string
    /// </summary>
    /// <param name="sender">Object that fired the event</param>
    /// <param name="e">Info about the event</param>
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Rewards/DisplayLoyaltyNum.aspx?loyaltyNum=" + lblLoyaltyNum.Text);
    }
}
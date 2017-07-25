/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    3/7/2017
    Midterm
    Changing the questions and tallying how the user answered each question displaying an
        appropriate response after completion.
    src: http://www.computerhope.com/issues/ch000575.htm
    ref: MSDN
--%>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class tellepet_midterm_Default : System.Web.UI.Page
{
    //Creating static counters to store values as the user traverses the page
    private static int windowsCounter; //Counts how many times the user answers in favor of windows
    private static int linuxCounter; //Counts how many times the user answers in favor of linux
    private static int questionCounter; //Keeps track of what question the user is on

    protected void Page_Load(object sender, EventArgs e)
    {
        //On initial page load...
        if (!IsPostBack)
        {
            questionCounter = 1; //Set question counter to one since user is on the first question

            question1.Visible = true; //Since all questions are default not visible make question 1 visible

            //Populate the dropdowns with appropriate ansers and values for those answers
            ddQuestion01.Items.Add(new ListItem("Low", "Linux"));
            ddQuestion01.Items.Add(new ListItem("High", "Windows"));

            ddQuestion02.Items.Add(new ListItem("Yes", "Windows"));
            ddQuestion02.Items.Add(new ListItem("Not Especially", "Linux"));

            ddQuestion03.Items.Add(new ListItem("Yes", "Linux"));
            ddQuestion03.Items.Add(new ListItem("No", "Windows"));

            ddQuestion04.Items.Add(new ListItem("Yes", "Windows"));
            ddQuestion04.Items.Add(new ListItem("No", "Linux"));

            ddQuestion05.Items.Add(new ListItem("Yes", "Linux"));
            ddQuestion05.Items.Add(new ListItem("No", "Windows"));

            ddQuestion06.Items.Add(new ListItem("Yes", "Windows"));
            ddQuestion06.Items.Add(new ListItem("No", "Linux"));

            ddQuestion07.Items.Add(new ListItem("Yes", "Linux"));
            ddQuestion07.Items.Add(new ListItem("No", "Windows"));

            ddQuestion08.Items.Add(new ListItem("Yes", "Windows"));
            ddQuestion08.Items.Add(new ListItem("No", "Linux"));

            ddQuestion09.Items.Add(new ListItem("Yes", "Linux"));
            ddQuestion09.Items.Add(new ListItem("No", "Windows"));
        }

    }

    /// <summary>
    /// When an answer is submitted put the currently selected value in the session variable and switch questions accordingly
    /// as well as iterating the counters.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Storing the currently selected value to keep track of if the user answered in favor of windows or linux
        //as well as changing visibility of questions accordingly.
        switch (questionCounter)
        {
            case 1:
                Session["OS"] = ddQuestion01.SelectedValue;
                question1.Visible = false;
                question2.Visible = true;
                break;
            case 2:
                Session["OS"] = ddQuestion02.SelectedValue;
                question2.Visible = false;
                question3.Visible = true;
                break;
            case 3:
                Session["OS"] = ddQuestion03.SelectedValue;
                question3.Visible = false;
                question4.Visible = true;
                break;
            case 4:
                Session["OS"] = ddQuestion04.SelectedValue;
                question4.Visible = false;
                question5.Visible = true;
                break;
            case 5:
                Session["OS"] = ddQuestion05.SelectedValue;
                question5.Visible = false;
                question6.Visible = true;
                break;
            case 6:
                Session["OS"] = ddQuestion06.SelectedValue;
                question6.Visible = false;
                question7.Visible = true;
                break;
            case 7:
                Session["OS"] = ddQuestion07.SelectedValue;
                question7.Visible = false;
                question8.Visible = true;
                break;
            case 8:
                Session["OS"] = ddQuestion08.SelectedValue;
                question8.Visible = false;
                question9.Visible = true;
                break;
            case 9:
                Session["OS"] = ddQuestion09.SelectedValue;
                question9.Visible = false;
                break;
        }

        string operatingSystem = Convert.ToString(Session["OS"]); //Converting the session variable to a string so we can switch on it
        //Increment the appropriate counter based on the session value.
        switch (operatingSystem)
        {
            case "Windows":
                windowsCounter++;
                break;
            case "Linux":
                linuxCounter++;
                break;
        }

        //If the last question has been answered display the appropriate answer to the user.
        if (questionCounter == 9)
        {
            btnSubmit.Visible = false; //Hide the submit button cause we're done with this
            if (windowsCounter > linuxCounter)
            {
                lblResult.Text = "You should get Windows!";
            }
            else
            {
                lblResult.Text = "You should get Linux!";
            }
            btnRedo.Visible = true; //Show the redo button if the user would like to retake the quiz
        }
        questionCounter++; //incrementing the question counter at the end of each question/answer cycle.
    }

    /// <summary>
    /// Reload the page entirley when the redo button is pressed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRedo_Click(object sender, EventArgs e)
    {
        Server.Transfer(Request.Path);
    }
}
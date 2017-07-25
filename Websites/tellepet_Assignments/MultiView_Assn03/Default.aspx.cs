/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/8/2017
    Assignment03
    Code behind to take care of switching and population of multiviews control
--%>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiView_Assn03_Default : System.Web.UI.Page
{
    //An array to hold the min amount of views we were required to show
    View[] interstingViews = new View[8] { new View(), new View(), new View(), new View(), new View(), new View(), new View(), new View() };
    //A value to hold the entered text and preserve the stat throughout the interaction
    private static int amountOfViews = 0;

    /// <summary>
    /// For dynamic views you have to make sure to create them before the page loads and the view implicitly try to get run
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        //If it is a postback and is not the first time the button has been pressed, initialize the views in here
        if (IsPostBack && amountOfViews !=0)
        {
            initViews(amountOfViews);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    /// <summary>
    /// When the button is clicked populate the multiview control as well as the dropdown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        //If this is the buttons first time being clicked then everything is empty and you can run the view initializing method
        if (amountOfViews == 0)
        {
            amountOfViews = Convert.ToInt32(txtListAmount.Text);
            initViews(amountOfViews);
        //If it is not the buttons first time being clicked then get the new desired view amount and get rid of the old views and dropdown items and repopulate it all
        } else if (Convert.ToInt32(txtListAmount.Text) != amountOfViews)
        {
            mvDisplay.Views.Clear();
            ddViews.Items.Clear();
            amountOfViews = Convert.ToInt32(txtListAmount.Text);
            initViews(amountOfViews);
        }
        
    }

    /// <summary>
    /// When the selected dropdown item is changed, change the view accordingly based on the items index
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddViews_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sender is DropDownList)
        {
            DropDownList dropdown = (DropDownList)sender;
            mvDisplay.ActiveViewIndex = dropdown.Items.IndexOf(dropdown.SelectedItem);
        }
    }

    /// <summary>
    /// A method to initialize all views that are going to be used
    /// </summary>
    /// <param name="numOfViews"></param>
    public void initViews(int numOfViews)
    {
        //Create an array of the images I plan to have populate my views
        Image[] images = new Image[8] { new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image() };
        images[0].ImageUrl = "/MultiView_Assn03/Images/AgonBanner2.png";
        images[1].ImageUrl = "/MultiView_Assn03/Images/AgoncraftLogo.png";
        images[2].ImageUrl = "/MultiView_Assn03/Images/BattleRing.png";
        images[3].ImageUrl = "/MultiView_Assn03/Images/CrystalCove.png";
        images[4].ImageUrl = "/MultiView_Assn03/Images/DarkMansionBuild.PNG";
        images[5].ImageUrl = "/MultiView_Assn03/Images/donkeyleg.png";
        images[6].ImageUrl = "/MultiView_Assn03/Images/IlarisUnboundConcept.png";
        images[7].ImageUrl = "/MultiView_Assn03/Images/NRGnocloud.png";

        //for each view in the class variable, interesting views, add one of the images to each view
        int j = 0;
        foreach (View view in interstingViews)
        {
            view.Controls.Add(images[j]);
            j++;
        }

        //Populate the multiview and the dropdown based on the number entered into the text box
        for (int i = 0; i < numOfViews; i++)
        {
            if (mvDisplay.Views.Count < 8)
            {
                mvDisplay.Views.Add(interstingViews[i]);
            } else
            {
                mvDisplay.Views.Add(new View());
            }
            ddViews.Items.Add("View " + i);
        }
        mvDisplay.ActiveViewIndex = 0;
    }

}
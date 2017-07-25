using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class calenderHolder : System.Web.UI.Page
{
    public object CalenderRange { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        //The user has clicked the OK button
        //Display the selected dates in a label on the form
        try
        {
            if (CalendarRange.startDate < DateTime.Today)
            {
                throw new Exception();
            }
            lblError.Text = "";
            lblChosenStartDate.Text = "Start Date: " + CalendarRange.startDate;
            lblChosenThroughDate.Text = "Through Date: " + CalendarRange.throughDate;
        } catch (Exception)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblChosenStartDate.Text = "";
            lblChosenThroughDate.Text = "";
            lblError.Text = "You have selected a date in the past as your start date! You cannot do that!";
        }
        
    }
}
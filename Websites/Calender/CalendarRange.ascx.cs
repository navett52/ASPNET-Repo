using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CalendarRange : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Initialize the start date on each calendar to be today
        //Checks to see if the page refresh is cause by a postback. If not it means it's the initial page load and sets the start dates.
        if (!IsPostBack)
        {
            this.calStartDate.SelectedDate = DateTime.Today;
            this.calThroughDate.SelectedDate = DateTime.Today;
        }
    }

    public DateTime startDate
    {
        get { return calStartDate.SelectedDate; }
    }

    public DateTime throughDate
    {
        get { return calThroughDate.SelectedDate; }
    }
}
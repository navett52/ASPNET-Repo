using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Config.incrementPageLoadCounter(); //increment the pageLoadCounter anytime the page loads
        //Response.Write("Page Load Counter = " + Config.pageLoadCounterForDefault);
        if (IsPostBack)
        {

        } else
        {
            // look at the runtime environment and print it to the HTML's strem
            Response.Write(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory());
            //Read the email address from web.config and insert into the html stream
            Response.Write(ConfigurationManager.AppSettings["email"]);
        }
    }
}
/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    1/25/2017
    Assignment01
    Create a page that solves a project euler problem of our choice
    Ref: http://stackoverflow.com/questions/4808612/how-to-split-a-number-into-individual-digits-in-c
--%>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Assignment01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //instantiating the problem class and running the solve method.
        Problem016 problem = new Problem016();
        //Putting the answer into the lbl
        lblAnswer.Text += problem.Solve();
    }
}
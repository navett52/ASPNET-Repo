/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/15/2017
    Assignment04
    Creating web request objects and reading them
--%>*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebScraping_Assn04_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnScrape1_Click(object sender, EventArgs e)
    {
        //Create web request objects then read a string using a reader
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(txtSite1.Text);
        HttpWebResponse response = (HttpWebResponse)req.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        String site1 = reader.ReadToEnd();
        reader.Close();

        //Create web request objects then read a string using a reader
        HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create(txtSite2.Text);
        HttpWebResponse response2 = (HttpWebResponse)req2.GetResponse();
        reader = new StreamReader(response2.GetResponseStream());
        String site2 = reader.ReadToEnd();
        reader.Close();

        //Producing the Frankensite
        Frankensite f = new Frankensite();
        lblSiteScrapings.Text = f.fuse(site1, site2);
    }
}
/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    2/15/2017
    Assignment04
    Class to create the Frankensite
--%>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for Frankensite
/// </summary>
public class Frankensite
{
    /// <summary>
    /// Blank constructor
    /// </summary>
    public Frankensite() {}

    /// <summary>
    /// Where the Frankensite is constructed by ripping each web page apart then putting them back together one tag at a time
    /// </summary>
    /// <param name="siteString1">The source code for the first site</param>
    /// <param name="siteString2">The source code for the second site</param>
    /// <returns>A fusion of the two websites</returns>
    public string fuse(String siteString1, String siteString2)
    {
        //Creating the variables needed
        string frankensite = "";
        string body = "";
        string head = getBetween(siteString1, "<head>", "</head>") + getBetween(siteString2, "<head>", "</head>");
        string[] firstSiteTags = null;
        string[] secondSiteTags = null;

        //Run the website strings through formatting to isolate the tags
        siteString1 = format(siteString1);
        siteString2 = format(siteString2);

        //Check to see which site is longer and set the tag arrays accordingly
        if (siteString1.Length > siteString2.Length)
        {
            firstSiteTags = siteString1.Split('\r');
            secondSiteTags = siteString2.Split('\r');
        }
        else
        {
            firstSiteTags = siteString2.Split('\r');
            secondSiteTags = siteString1.Split('\r');
        }
        
        //Fuse the two sites together one tag at a time, until the site with fewer tags runs out
        for (int i = 0; i < firstSiteTags.Length; i++)
        {
            body += firstSiteTags[i];
            if (i < secondSiteTags.Length)
            {
                body += secondSiteTags[i];
            }
        }
        
        //Re-unite the head of the sites with the newly fused body
        frankensite += head + body;

        //Eureka!
        return frankensite;
    }

    /// <summary>
    /// Formatting the site strings to where each tag sits on it's own line
    /// </summary>
    /// <param name="siteString"></param>
    /// <returns></returns>
    public string format(String siteString)
    {
        for (int i = 0; i < siteString.Length - 1; i++)
        {
            //Check to see if the left carrot has a trailing slash, if so this is a closing tag and does not need a new line inserted before it
            if (siteString[i + 1] == '/')
            {
                continue;
            }
            else if (siteString[i] == '<')
            {
                siteString = siteString.Insert(i, Environment.NewLine);
                i += 2;
            }
        }
        return siteString;
    }

    /// <summary>
    /// Gets a string from between two string that reside within the original string
    /// Ref: http://stackoverflow.com/questions/10709821/find-text-in-string-with-c-sharp
    /// </summary>
    /// <param name="strSource"></param>
    /// <param name="strStart"></param>
    /// <param name="strEnd"></param>
    /// <returns></returns>
    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        int Start, End;
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        else
        {
            return "";
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for Config
/// </summary>
public static class Config
{
    private static int mPageLoadCounterForDefault;
    static Config()
    {
        mPageLoadCounterForDefault = 0;
        // This will run on the first reference to the class
    }

    public static int pageLoadCounterForDefault
    {
        get { return mPageLoadCounterForDefault; }
        //set { mPageLoadCounterForDefault = value; }
    }

    public static void incrementPageLoadCounter()
    {
        mPageLoadCounterForDefault++;
    }

    //Write a method to print the value of mPageLoadCounterForDefault to the html stream
    public static void print()
    {
        
    }
}
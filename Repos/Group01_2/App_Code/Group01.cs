/*
 * Group Project for IT3047
 * Bill Nicholson
 * nicholdw@ucmauil.uc.edu
 * Edited by: Evan Tellep & Justin Meyer
 */
using ds_ProductIDWithMostReturnsTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// ProductID with the most returns
/// </summary>
public class Group01
{
    public Group01()
    {
        // No constructor needed here folks
    }
    /// <summary>
    /// Use dataset to return the ProductID of the product that was returned the most.
    /// (Return includes Exchange AND Refund)
    /// </summary>
    /// <author>
    /// Evan Tellep
    /// Justin Meyer
    /// </author>
    /// <returns>ProductID with most Returns</returns>
    public int GetProductIDWithTheMostReturns()
    {
        vProductIDWithTheMostReturnsTableAdapter pIDWithMostReturns = new vProductIDWithTheMostReturnsTableAdapter();
        ds_ProductIDWithMostReturns.vProductIDWithTheMostReturnsDataTable pIDWithMostReturnsDataTable = pIDWithMostReturns.GetData();
        return Convert.ToInt32(pIDWithMostReturnsDataTable.Rows[0]["ProductID"]);
    }

}
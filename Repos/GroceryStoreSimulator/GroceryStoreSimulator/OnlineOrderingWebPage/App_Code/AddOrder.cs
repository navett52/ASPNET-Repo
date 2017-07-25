using dsAddOrderTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AddOrder
/// </summary>
public class AddOrder
{
    public AddOrder()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static int? PlaceOrder(int LoyaltyID, int StoreID, int OrderStatusID, ListBox productInfo)
    {
        AddOrderTableAdapter AddOrder = new AddOrderTableAdapter();
        int? orderID = 0;
        AddOrder.spAddOrder(ref orderID, StoreID, 0, OrderStatusID, LoyaltyID);
        //Delimeter : + 10 padded spaces
        foreach (ListItem product in productInfo.Items)
        {
            int quantity = Convert.ToInt32(product.Text); //Need to strip spaces and use : delimeter to get quantity placed after the product name in .text
            AddOrder.spAddOrderDetail();
        }

        return orderID;
    }
}
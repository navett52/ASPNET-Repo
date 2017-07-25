using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void dlPopTartFlavor_EditCommand(object source,
        DataListCommandEventArgs e)
    {
        dlPopTartFlavor.EditItemIndex = e.Item.ItemIndex;
        dlPopTartFlavor.DataBind();
    }
    protected void dlPopTartFlavor_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        String PopTartFlavorID = dlPopTartFlavor.DataKeys[e.Item.ItemIndex].ToString();
        String PopTartFlavor = ((TextBox)e.Item.FindControl("txtPopTartFlavor_Edit")).Text;
        dsPopTart.UpdateParameters["original_PopTartFlavorID"].DefaultValue = PopTartFlavorID;
        dsPopTart.UpdateParameters["PopTartFlavor"].DefaultValue = PopTartFlavor;
        dsPopTart.Update();

        dlPopTartFlavor.EditItemIndex = -1;
        dlPopTartFlavor.DataBind();
    }

}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void timerMain_Tick(object sender, EventArgs e)
    {
        //Change the text of a button by subtracting 1
        btnDisplay.Text = Convert.ToString(Convert.ToInt32(btnDisplay.Text) - 1);
    }

    protected void timerColor_Tick(object sender, EventArgs e)
    {
        Random randomGen = new Random();
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        KnownColor randomColorName = names[randomGen.Next(names.Length)];
        Color randomColor = Color.FromKnownColor(randomColorName);
        btnColor.BackColor = randomColor;

        //lblUpdate.Text = new Reader().read();
    }
}
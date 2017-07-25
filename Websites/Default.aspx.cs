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
        /*Random randomGen = new Random();
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor)); //Getting known color names from an Enum into an array
        KnownColor randomColorName = names[randomGen.Next(names.Length)]; //Grabbing a color name from the array using a random index
        Color randomColor = Color.FromKnownColor(randomColorName); //Assigning the color name to randomColor
        lblHello.ForeColor = randomColor; //Assigning the new color to the text*/
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (lblHello.Text == "I just changed the text of this Label.")
        {
            lblHello.Text = "Hello World";
            CheckBox1.Checked = true;
        } else
        {
            //change the contents of the Label: lblHello
            lblHello.Text = "I just changed the text of this Label.";
            CheckBox1.Checked = false;
        }

        if (CheckBox1.Checked == true)
        {
            CheckBox1.Checked = false;
        } else
        {
            CheckBox1.Checked = true;
        }

        //Random r = new Random();
        //lblHello.BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        //^another way to do it.
        
    }
}
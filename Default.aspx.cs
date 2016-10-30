using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Application.Lock();//so 2 simultaneous visitors don't cause counter to go wrong

        if(Application["pageCounter"] == null)
        {
            Application["pageCounter"] = 1;
        }
        else
        {
            Application["pageCounter"] = (int)Application["pageCounter"] + 1;
        }
        appStateCounter.Text += (int)Application["pageCounter"];


        Application.UnLock();


       
    }
}
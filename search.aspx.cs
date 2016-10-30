using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void rad_CheckedChanged(object sender, EventArgs e)
    {
        


        if(radSearchRcpName.Checked)
        {
            searchBy.ucProp = "Search By Recipe Name: ";
            searchBy.Visible = true;
        }
        else if (radSearchSubmitBy.Checked)
        {
            searchBy.ucProp = "Search by Person Name: ";
            searchBy.Visible = true;
        }

    }
}
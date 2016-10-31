using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Net;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;//causing ambiguity bw WebControls.Controls & Forms.Controls. So used full statement where needed below

public partial class recipes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) populateRecipes();//without this POSTBACK chk, populating of DataList's Literals gave ERROR. OSme validation breach!!!
    }

    private void populateRecipes()
    {
        OleDbConnection conn = null;
        OleDbCommand cmd = null;
        OleDbDataReader reader = null;
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("cookbook.mdb");
        string query = "SELECT * FROM RECIPES";


        try
        {
            conn = new OleDbConnection(connStr);
            conn.Open();
            cmd = new OleDbCommand(query, conn);
            reader = cmd.ExecuteReader();
            displayRecipes.DataSource = reader;
            displayRecipes.DataBind();
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
            Response.End();
        }
        finally
        {
            if (reader != null) reader.Close();
            if (conn != null) conn.Close();
        }
    }

    


    //In design-mode, select dataList & in 'properties' doubleClick ItenCommand to generate following event handler
    //this handler is called by onItemCommand="" q time one of items in DataList fires an event
    protected void displayRecipes_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //if the btn e Commandname 'showMore' fired then do this
        if (e.CommandName == "showMore")
        {
            //if details already displayed for the recipe-item that fired & we clicked btn for same again THEN just make everything invisible.
            if (((Literal)e.Item.FindControl("byLit")).Visible == true)
            {
                //Make all Literal ctrls invisible, before making one recipe details visible
                foreach (Control c1 in displayRecipes.Items)
                {
                    foreach (Control c2 in c1.Controls)
                    {
                        if (c2 is Literal)
                        {
                            c2.Visible = false;
                        }
                    }
                } 
                //keep focus on the btn clicked
            ((Button)e.Item.FindControl("showMore")).Focus();
            }

            





            //if recipe-item clicked was NOT already visible THEN make it visible aft making ALL invisible
            else
            {
                foreach (Control c1 in displayRecipes.Items)
                {
                    foreach (Control c2 in c1.Controls)
                    {
                        if (c2 is Literal)
                        {
                            c2.Visible = false;
                        }
                    }
                }
                //===========================================================================
                //Literal li1 = (Literal)e.Item.FindControl("byLit"); 
                //li1.Text = "Submitted By: " + e.CommandArgument;
                //above 2 stats reduced below:
                //
                //((Literal)e.Item.FindControl("byLit")).Text = "Submitted By: " + e.CommandArgument + "<br />";


                //make all pre-populated asp:Literals visible
                ((Literal)e.Item.FindControl("byLit")).Visible = true;
                ((Literal)e.Item.FindControl("timeLit")).Visible = true;
                ((Literal)e.Item.FindControl("portionLit")).Visible = true;
                ((Literal)e.Item.FindControl("categoryLit")).Visible = true;
                ((Literal)e.Item.FindControl("cuisineLit")).Visible = true;
                ((Literal)e.Item.FindControl("descLit")).Visible = true;
                //===========================================================================
                ((Button)e.Item.FindControl("showMore")).Focus();
            }
        }
    }

    protected void openDbFile_Click(object sender, EventArgs e)
    {
        ////using System.Diagnostics;
        ////open file or folder
        //String absPath = Server.MapPath("cookbook.mdb");//get absolute path in server's folders
        ////@ ignores the escape character backslash//Process.Start(@"C:\Users\Zoya\Google Drive\_Semester-3\_comp229-web_Primala\_Assignments\aspAssign1");
        //Process.Start(absPath);

        //============================================================

        //
        using (var client = new WebClient())
        {
            client.DownloadFile("http://studentweb.cencol.ca/shafiqu/aspAssign1/Default.aspx", @"C:\Users\Zoya\Desktop\downLoadedFile.aspx");
            //System.Windows.Forms.MessageBox.Show("File Downloaded Successfully");//using System.Windows.Forms; giving err so put whole statement here.

            //System.Windows.Forms.MessageBox.Show( //overload used to keep pop-up window atop
            //    "File Downloaded Successfully",
            //    "It is a Heading",
            //    System.Windows.Forms.MessageBoxButtons.OK,
            //    System.Windows.Forms.MessageBoxIcon.Warning,
            //    System.Windows.Forms.MessageBoxDefaultButton.Button1,
            //    System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly//this line keeps pop-up on top
            //    );


            System.Windows.Forms.MessageBox.Show( //a 3rd way. Use OL that needs a window-obj as 1st arg
                new System.Windows.Forms.Form { TopMost = true },
                "File Downloaded Successfullly",
                "Some Heading"/*,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Exclamation*/
                );


            //Response.Write("Download Successful");//this line runs ONLY if above line was successful
            //Response.End();//erminates the App
        }
    }
}
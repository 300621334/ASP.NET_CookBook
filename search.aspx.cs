using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

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

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        string queryStr = "";

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("cookbook.mdb"));

        if (radSearchRcpName.Checked) //select w col of tbl to look into "recipeName" or "fromName"
        {
            queryStr = "SELECT * FROM recipes WHERE recipeName LIKE @searchWord";
        }
        else if(radSearchSubmitBy.Checked)
        {
            queryStr = "SELECT * FROM recipes WHERE fromName LIKE @searchWord";
        }

        OleDbCommand query = new OleDbCommand(queryStr, conn);
        query.Parameters.AddWithValue("searchWord", System.Data.SqlDbType.VarChar);//in Access .Add() is obsolete
        query.Parameters["searchWord"].Value = searchBy.ucProp;//try to read ucProp fires "get" & fetch value of search TextBox

        conn.Open();//reader requires an OPEN connection to be able to read
        OleDbDataReader reader;
        

        reader = query.ExecuteReader();//returns a reader

        //searchGridView.DataSource = reader;
        //searchGridView.DataBind();
        displayRecipes.DataSource = reader;
        displayRecipes.DataBind();

    }


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
            //keep focus on the btn clicked. Extract ctrl invisible to C# like this
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
}
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

        searchGridView.DataSource = reader;
        searchGridView.DataBind();

    }
}
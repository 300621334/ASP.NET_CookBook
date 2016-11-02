using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Net;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class addressBook : System.Web.UI.Page
{
    
    

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack) bindDataGrid();
    }

    private void bindDataGrid()
    {
        OleDbConnection conn = null;
        OleDbCommand query = null; //SQL
        OleDbDataReader reader = null;//container to hold result set
        string connStr = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + Server.MapPath("cookbook.mdb");
        string queryStr = "SELECT * FROM addresses";//this is NOT file name BUT name of tbl inside tat file

        conn = new OleDbConnection(connStr);
        query = new OleDbCommand(queryStr, conn);

        try
        {
            conn.Open();
            reader = query.ExecuteReader();
            grid.DataSource = reader;
            grid.DataKeyNames = new string[] {"CookName"};//Used in DetailsBind() //we tell DataGrid which array of keys(fields) to store for use in asp:DetailsView p-483. We 
            grid.DataBind();
            //for asp:repeater & asp:DataList we need to use <ItemTemplate> etc to generate tbl on webpage. But DataGrid makes tbl auto
            //to show select cols out of query result, in ctrl put AutoGenerateColumns="false" & put <columns> & <BoundField>

        }
        //catch (Exception ex) { }
        finally
        {
            if(reader != null) reader.Close();
            conn.Close();
        }

    }

    //on selecting a row in DataView, display info in label below it
    protected void grid_SelectedIndexChanged(object sender, EventArgs e)
    {
        int gridRowIndex = grid.SelectedIndex; //index of row selected
        GridViewRow aRow = grid.Rows[gridRowIndex]; //pull WHOLE row
        string aCell = aRow.Cells[0].Text; //pull one cell out of whole row
        gridLbl.Text = "Details of selected cook \"" + aCell + "\" are below";

        //feed data into DetailsView
        BindDetails();


        //focus not working !!!!!!
        focusHereWhenGridViewRowSelected.Focus();


    }

    private void BindDetails()
    {
        int selectedIndex = grid.SelectedIndex;//which row is selected in GridView
        string cookName = (String)grid.DataKeys[selectedIndex].Value;//from selected row in GridView, pull value of col defined in DataKeyNames
        //pull DB again. This time use selected row from GridView & use name in that row to pull record of that cook ONLY & show in DetailsView
        OleDbConnection conn; OleDbCommand query; OleDbDataReader reader=null;
        string connStr = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + Server.MapPath("cookbook.mdb");
        string queryStr = "SELECT * FROM addresses WHERE CookName=@cookNameParam";//tbl is addresses inside DB CookBook.mdb (tbl is not CookBook)
        conn = new OleDbConnection(connStr);
        query = new OleDbCommand(queryStr, conn);//this query has a placeHolder @cookNameParam to be fed a value below
        query.Parameters.Add("cookNameParam", OleDbType.VarChar);//
        query.Parameters["cookNameParam"].Value = cookName;//str from DataKeys fed to SQL
        try
        {
            conn.Open();
            reader = query.ExecuteReader();
            DetailsView1.DataSource = reader;//instead of grid.DataSource

            DetailsView1.DataBind();
        }
        //catch (Exception ex) { }
        finally
        {
            if (reader != null) reader.Close();
            conn.Close();
            //focus on this <label> below DetailsView so that page scrolls to show it in full
        }

    }
}
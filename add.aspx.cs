using System;
using System.Collections.Generic;
using System.Data.OleDb;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //on btn click, saveRecipe into DB
    protected void saveRecipe(object sender, EventArgs e)
    {
        OleDbConnection conn = null;
        OleDbCommand insertIntoCmd = null;
        OleDbDataReader reader = null;

        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("cookbook.mdb");
        //string query = "SELECT * FROM RECIPES";
        string queryInsertInto = "INSERT INTO recipes VALUES (@recipeName, @fromName, @cookingTime, @portions, @category, @cuisine, @private, @description)";


        //initialize connection & query
        conn = new OleDbConnection(connStr);
        insertIntoCmd = new OleDbCommand(queryInsertInto, conn);

        //obsolete in MS_Access:-//insertIntoSql.Parameters.Add("@recipeName", System.Data.SqlDbType.VarChar);
        
        //insertIntoCmd.Parameters.AddWithValue("@id", System.Data.SqlDbType.VarChar);//removed ID column
        insertIntoCmd.Parameters.AddWithValue("@recipeName", System.Data.SqlDbType.VarChar);
        insertIntoCmd.Parameters.AddWithValue("@fromName", System.Data.SqlDbType.VarChar);
        insertIntoCmd.Parameters.AddWithValue("@cookingTime", System.Data.SqlDbType.VarChar);
        insertIntoCmd.Parameters.AddWithValue("@portions", System.Data.SqlDbType.VarChar);
        insertIntoCmd.Parameters.AddWithValue("@category", System.Data.SqlDbType.VarChar);
        insertIntoCmd.Parameters.AddWithValue("@cuisine", System.Data.SqlDbType.VarChar);
        insertIntoCmd.Parameters.AddWithValue("@private", System.Data.SqlDbType.VarChar);
        insertIntoCmd.Parameters.AddWithValue("@description", System.Data.SqlDbType.VarChar);

        //insertIntoCmd.Parameters["@recipeName"].Value = id.......;//removed ID column
        insertIntoCmd.Parameters["@recipeName"].Value = recipeName.ucProp;//try read property(get/set) of User Ctrl "ucProp"
        insertIntoCmd.Parameters["@fromName"].Value = submitBy.ucProp;
        insertIntoCmd.Parameters["@cookingTime"].Value = cookTime.ucProp;
        insertIntoCmd.Parameters["@portions"].Value = portions.ucProp;
        insertIntoCmd.Parameters["@category"].Value = category.SelectedItem.ToString();
        insertIntoCmd.Parameters["@cuisine"].Value = cuisine.SelectedItem.ToString();
        insertIntoCmd.Parameters["@private"].Value = CheckBox1.Checked?"1":"0";
        insertIntoCmd.Parameters["@description"].Value = desc.Text;

        try
        {
           conn.Open();
           int x =  insertIntoCmd.ExecuteNonQuery();//if this missed, NO data inserted//for SELECT ExecuteReader.
                                                    //'x' is number of rows affected

            if (x > 0)//if at least 1 row was affected
            {
                Response.Write("Recipe Added Successfully.");//writes on top-left cormer of webpage BUT page stays alive
                //Response.End();//kills the page.
            }


            //reader = insertIntoCmd.ExecuteNonQuery();//NOT assign to reader coz we are NOT trying to read. 
            //reader = insertIntoCmd.ExecuteReader();//gives err IF no rows returned e.g. no SELECT statement
        }
        catch (Exception err)
        {
            Response.Write(err.Message);//writes on top-left cormer of webpage
            Response.End();
        }
        finally
        {
            if (reader != null) reader.Close();
            if (conn != null) conn.Close();

        }
    }



}
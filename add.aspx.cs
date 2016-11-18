using System;
using System.Collections.Generic;
using System.Data.OleDb;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //to use microsoft's SQL-Server DB
using System.Web.Configuration;
//using Oracle.ManagedDataAccess.Client; //to use Oracle DB
//using Oracle.ManagedDataAccess.Types;



public partial class add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////category.Items.Clear();
        ////cuisine.Items.Clear();

        //http://stackoverflow.com/questions/7227510/what-is-the-right-way-to-populate-a-dropdownlist-from-a-database

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("cookbook.mdb"));
        OleDbCommand fillCategoriesCmd = new OleDbCommand("SELECT category FROM categories", conn);
        conn.Open();
        OleDbDataReader reader = fillCategoriesCmd.ExecuteReader();//open() needed for ExecuteReader
        category.DataSource = reader;
        category.DataTextField = "category";//col name from DB tbl whose value is used as TEXT="" for dropdown items
        category.DataValueField = "category";//col which provides value="" for dropdown items
        category.DataBind();

        //fill cuisine start from a new command. Connection is the same.
        OleDbCommand fillCuisineCmd = new OleDbCommand("SELECT DISTINCT cuisine FROM recipes", conn);
        reader = fillCuisineCmd.ExecuteReader();
        cuisine.DataSource = reader;
        cuisine.DataTextField = "cuisine";
        cuisine.DataValueField = "cuisine";
        cuisine.DataBind();

        conn.Close();//close conn AFTER both dropDown lists filled 




        ////Tried to use SQL server to populate drop downs but failed
        ////using System.Web.Configuration;
        //// SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["EmployeeDatabaseConnectionString"].ConnectionString);
        //SqlConnection connSql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //SqlCommand cmdSql = new SqlCommand("SELECT category FROM categories", connSql);
        //connSql.Open();
        //SqlDataReader readerSql = cmdSql.ExecuteReader();
        //category.DataSource = readerSql;
        //category.DataBind();
        //connSql.Close();




        ////populate Submited By - submitByList
        //OleDbCommand fillSubmitByCmd = new OleDbCommand("SELECT  userName FROM users", conn);
        //reader = fillSubmitByCmd.ExecuteReader();
        //submitByList.DataSource = reader;
        //submitByList.DataTextField = "userName";
        //submitByList.DataValueField = "userName";
        //submitByList.DataBind();


        //conn.Close();
    }


    //on btn click, saveRecipe into DB & if invalid ctrl display error/red box etc
    protected void saveRecipe(object sender, EventArgs e)
    {
        //write to DB
        OleDbConnection conn = null;
        OleDbCommand insertIntoCmd = null;
        OleDbDataReader reader = null;

        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("cookbook.mdb");
        //string query = "SELECT * FROM RECIPES";
        string queryInsertInto = "INSERT INTO recipes VALUES (@recipeName, @fromName, @cookingTime, @portions, @category, @cuisine, @private, @description)";


        //initialize connection & query
        conn = new OleDbConnection(connStr);
        insertIntoCmd = new OleDbCommand(queryInsertInto, conn);


        //below is longer version where I declared data type first then assigned value to param
        //but in this shorter version no need to declare type. Just Add-With-Value
        insertIntoCmd.Parameters.AddWithValue("@recipeName", recipeName.ucProp);
        insertIntoCmd.Parameters.AddWithValue("@fromName", submitBy.ucProp);
        insertIntoCmd.Parameters.AddWithValue("@cookingTime", cookTime.ucProp);
        insertIntoCmd.Parameters.AddWithValue("@portions", portions.ucProp);
        insertIntoCmd.Parameters.AddWithValue("@category", category.SelectedItem.ToString());
        insertIntoCmd.Parameters.AddWithValue("@cuisine", cuisine.SelectedItem.ToString());
        insertIntoCmd.Parameters.AddWithValue("@private", CheckBox1.Checked ? "1" : "0");
        insertIntoCmd.Parameters.AddWithValue("@description", desc.Text);


        ////obsolete in MS_Access:-//insertIntoSql.Parameters.Add("@recipeName", System.Data.SqlDbType.VarChar);

        ////insertIntoCmd.Parameters.AddWithValue("@id", System.Data.SqlDbType.VarChar);//removed ID column
        //insertIntoCmd.Parameters.AddWithValue("@recipeName", System.Data.SqlDbType.VarChar);
        //insertIntoCmd.Parameters.AddWithValue("@fromName", System.Data.SqlDbType.VarChar);
        //insertIntoCmd.Parameters.AddWithValue("@cookingTime", System.Data.SqlDbType.VarChar);
        //insertIntoCmd.Parameters.AddWithValue("@portions", System.Data.SqlDbType.VarChar);
        //insertIntoCmd.Parameters.AddWithValue("@category", System.Data.SqlDbType.VarChar);
        //insertIntoCmd.Parameters.AddWithValue("@cuisine", System.Data.SqlDbType.VarChar);
        //insertIntoCmd.Parameters.AddWithValue("@private", System.Data.SqlDbType.VarChar);
        //insertIntoCmd.Parameters.AddWithValue("@description", System.Data.SqlDbType.VarChar);

        ////insertIntoCmd.Parameters["@recipeName"].Value = id.......;//removed ID column
        //insertIntoCmd.Parameters["@recipeName"].Value = recipeName.ucProp;//try read property(get/set) of User Ctrl "ucProp"
        //insertIntoCmd.Parameters["@fromName"].Value = submitBy.ucProp;
        ////insertIntoCmd.Parameters["@fromName"].Value = submitByList.SelectedValue;
        //insertIntoCmd.Parameters["@cookingTime"].Value = cookTime.ucProp;
        //insertIntoCmd.Parameters["@portions"].Value = portions.ucProp;
        //insertIntoCmd.Parameters["@category"].Value = category.SelectedItem.ToString();
        //insertIntoCmd.Parameters["@cuisine"].Value = cuisine.SelectedItem.ToString();
        //insertIntoCmd.Parameters["@private"].Value = CheckBox1.Checked?"1":"0";
        //insertIntoCmd.Parameters["@description"].Value = desc.Text;

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
        //submitBtn.Focus();//doesn't work probably bcoz validators PostBack the page AFT this handler is long gone!!!



        ////need to disable clientside validation for following to work
        ////http://stackoverflow.com/questions/665603/asp-net-how-to-change-the-background-color-of-a-control-that-failed-validation
        ////color red the required incomplete fields
        //Page.Validate();
        //foreach(BaseValidator v in Page.Validators)//collection of validators iterated thru
        //{
        //    if(!v.IsValid)
        //    {
        //        Control c = (Control)this.FindControl(v.ControlToValidate);//"this" is the Page
        //        TextBox t = (TextBox)c;//recipeName$TextBox1 is the CtrlToValidate w is a TextBox
        //        t.BackColor = System.Drawing.Color.Red;

        //    }
        //}



        //empty all text boxes aft saving recipe
        //attempt to submitBy.ucProp = ""; will empty the LABEL instead of txt box
        //created a new prop 'ucText' in UC to be able to empty TextBox1 inside UC
        recipeName.ucText = string.Empty;
        submitBy.ucText = "";
        cookTime.ucText = "";
        portions.ucText = "";
        CheckBox1.Checked = false;
        desc.Text = "";



    }//saveRecipe() ends

   

    }
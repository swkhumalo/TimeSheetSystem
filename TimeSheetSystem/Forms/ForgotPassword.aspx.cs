using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace TimeSheetSystem.Forms
{
    public partial class ForgotPassword : System.Web.UI.Page
    { 
        //Static declaration
        static SqlConnection connectionA = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;
        private string sql;


        //Validation Function
        protected void Page_Load(object sender, EventArgs e)
        {
            //connectionA.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SW KHUMALO\Music\TimeSheetSystem\TimeSheetSystem\App_Data\DBTimeSheet.mdf;Integrated Security=True;Connect Timeout=30";
            connectionA.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SW KHUMALO\Music\TimeSheetSystem\TimeSheetSystem\App_Data\DBTimeSheet.mdf";
        }
        private bool valid()
        {
            //Email Containts @ and .com
            if (txtEmail.Text.Contains('@') && txtEmail.Text.Contains('.'))
            {
                connectionA.Close();
                return true;
            }
            else
            {
                connectionA.Close();
                Response.Write("<script>alert('Please Check Your Email It Might Not Contain (@ or .com) ')</script>");
                return false;
            }
        }
        protected void btnRecovery_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                try
                {
                    connectionA.Open();
                    SqlCommand comd = new SqlCommand();
                    sql = "SELECT * FROM `AdminUsers` WHERE `Email` = '" + txtEmail.Text + "'";
                    adapter.SelectCommand = connectionA.CreateCommand();
                    adapter.SelectCommand.CommandText = sql;
                    reader = adapter.SelectCommand.ExecuteReader();


                    string email = "";
                    string security = "";

                    // Email Check
                    while (reader.Read())
                    {
                        if (reader["Email"].ToString() == txtEmail.Text.ToLower())
                        {
                            email = reader["Email"].ToString();
                            security = reader["Security"].ToString();
                            reader.Close();
                            connectionA.Close();
                        }
                    }

                    reader.Close();
                    connectionA.Close();
                    //Sending Confirmation Email
                    Response.Write("<script>alert('Successfully Recoverd Please Check Your Email....')</script>");
                }
                catch(Exception x)
                {
                    Response.Write("<script>alert('" + x.Message + x.Data + "') </script>");
                    connectionA.Close();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signin.aspx");
        }
        
    }
}
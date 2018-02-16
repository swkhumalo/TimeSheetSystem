using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace TimeSheetSystem.Forms
{
    public partial class Dashboard : System.Web.UI.Page
    {
        static SqlConnection connectionA = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionA = new SqlConnection(ConfigurationManager.ConnectionStrings["DBTimeSheetConnectionStr"].ConnectionString);

            try
            {
                connectionA.Open();
                //Admin Details all Users
                SqlCommand comd = new SqlCommand();
                comd.Connection = connectionA;
                comd.CommandText = "SELECT * FROM [AdminUsers] WHERE Email = @Email";
                comd.Parameters.AddWithValue("@Email", WebForm1.email);
                reader = comd.ExecuteReader();
                if (reader.Read())
                {
                    Label1.Text = "Welcome " + reader["InitialsSurname"].ToString();
                }
                reader.Close();

                
                /*
                //Retriving all Admin Users
                comd.CommandText = "SELECT * FROM AdminUsers";
                reader = comd.ExecuteReader();

                GridView1.DataSource = reader;
                GridView1.DataBind();
                */

                //Retrieving all Employees
                int num = 0;
                comd.CommandText = "SELECT * FROM Employees";
                reader = comd.ExecuteReader();
                while (reader.Read())
                {
                    num++;
                }
                Employees1.Text = num.ToString();
                Employees.Text = num.ToString();
                reader.Close();
                


                //Retrieving visitors
                comd.CommandText = "SELECT * FROM Visitors";
                reader = comd.ExecuteReader();
                while (reader.Read())
                {
                    LabelVisitors.Text = reader[0].ToString();
                }
                reader.Close();
                connectionA.Close();
            }
            catch (Exception exp)
            {
                connectionA.Close();
                Response.Write(string.Format("<script>alert('{0}')</script>", exp.Message));
            }

        }
        
    }
}
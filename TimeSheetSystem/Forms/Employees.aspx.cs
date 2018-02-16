using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;

namespace TimeSheetSystem.Forms
{
    public partial class Employees : System.Web.UI.Page
    {
        public static string EmpNo = "";

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
                    Label5.Text = "Welcome " + reader["InitialsSurname"].ToString();
                }
                reader.Close();

                 //Retrieving all Employees
                int num = 0;
                comd.CommandText = "SELECT * FROM Employees";
                reader = comd.ExecuteReader();
                while (reader.Read())
                {
                    num++;
                }
                Employees1.Text = num.ToString();
                reader.Close();
                connectionA.Close();
            }
            catch (Exception exp)
            {
                connectionA.Close();
                Response.Write(string.Format("<script>alert('{0}')</script>", exp.Message));
            }

        }
        
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EmpNo = ((Label)GridView1.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("Label1")).Text;

            if (e.CommandName == "Sel")
            {
                Response.Redirect("EditEmployees.aspx");
            }
           
        }
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            int EmpIndex = Convert.ToInt32(GridView1.DataKeys[index].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM [Employees] WHERE EmployeeNo = @EmployeeNo", connectionA);
            cmd.Parameters.AddWithValue("@EmployeeNo", EmpIndex.ToString());
            connectionA.Open();
            cmd.ExecuteNonQuery();
            Response.Write(string.Format("<script>alert('Successfully Deleted......!')</script>"));
            connectionA.Close();
        }
    }
}
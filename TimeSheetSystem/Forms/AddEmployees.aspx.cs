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
    public partial class AddEmployees : System.Web.UI.Page
    {
        static SqlConnection connectionA = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;
        private string sql;

        DateTime time = Convert.ToDateTime("00:00:00");
        
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
                Response.Write(string.Format("<script>alert('{0}')</script>", exp.Message));
            }
            finally
            {
                connectionA.Close();
            }
        }
        void clear()
        {
            txtEmployeeNo.Text = string.Empty;
            txtInitials.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtIDNo.Text = string.Empty;

            txtEmployeeNo.Focus();
        }
        void ShowMessage(String msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Validation", "<script language='javascript'>alert('" + msg + "');</script>");
        }
        private bool valid()
        {
            //Connect To The Database
            try
            {
                connectionA.Open();
                SqlCommand cmd = new SqlCommand();
                sql = "SELECT * FROM Employees";
                adapter.SelectCommand = connectionA.CreateCommand();
                adapter.SelectCommand.CommandText = sql;
                reader = adapter.SelectCommand.ExecuteReader();

                // Email Check
                while (reader.Read())
                {
                    if (reader["EmployeeNo"].ToString() == txtEmployeeNo.Text.ToLower())
                    {
                        connectionA.Close();
                        reader.Close();
                        ShowMessage("The Employee You've Entered Already Registered In The System");
                        return false;
                    }
                   
                }

                //Email Containts @ and .com
                if (txtIDNo.Text.Length == 13)
                {
                    connectionA.Close();
                    return true;
                }
                else
                {
                    connectionA.Close();
                    ShowMessage("Please Check Your ID Number");
                    return false;
                }

            }
            catch (Exception exp)
            {
                Response.Write(string.Format("<script>alert('{0}')</script>", exp.Message));
                return false;
            }
            finally
            {
                connectionA.Close();
            }


   
        }
        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                try
                {
                    connectionA.Open();

                    sql = "INSERT INTO Employees(EmployeeNo, Initials, FirstName, LastName, IdentityNo) VALUES (@EmployeeNo, @Initials, @FirstName, @LastName, @IdentityNo)";
                    SqlCommand cmd = new SqlCommand(sql, connectionA);

                    cmd.Parameters.AddWithValue("@EmployeeNo", txtEmployeeNo.Text);
                    cmd.Parameters.AddWithValue("@Initials", txtInitials.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@IdentityNo", txtIDNo.Text);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    
             

                    //Initializing the timesheet with the employee
                    sql = "INSERT INTO TimeSheet(EmployeeNo,TimeIn,TimeOut,BreakIn,BreakOut,HoursWorked,Monday,Tuesday,Wednesday,Thursday,Friday,Wages) VALUES (@EmployeeNo, @TimeIn, @TimeOut, @BreakIn, @BreakOut, @HoursWorked, @Monday, @Tuesday, @Wednesday, @Thursday, @Friday, @Wages)";
                    cmd = new SqlCommand(sql, connectionA);

                    cmd.Parameters.AddWithValue("@EmployeeNo", txtEmployeeNo.Text);
                    cmd.Parameters.AddWithValue("@TimeIn", time);
                    cmd.Parameters.AddWithValue("@TimeOut", time);
                    cmd.Parameters.AddWithValue("@BreakIn", time);
                    cmd.Parameters.AddWithValue("@BreakOut", time);
                    cmd.Parameters.AddWithValue("@HoursWorked", 0);
                    cmd.Parameters.AddWithValue("@Monday", 0);
                    cmd.Parameters.AddWithValue("@Tuesday", 0);
                    cmd.Parameters.AddWithValue("@Wednesday", 0);
                    cmd.Parameters.AddWithValue("@Thursday", 0);
                    cmd.Parameters.AddWithValue("@Friday", 0);
                    cmd.Parameters.AddWithValue("@Wages", 0);
                    
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    clear();
                    connectionA.Close();

                    ShowMessage("Successfully Registered....!");
                }
                catch (Exception x)
                {
                    ShowMessage(x.Message);
                }
                finally
                {
                    connectionA.Close();
                }
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
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
    public partial class EditEmployees : System.Web.UI.Page
    {
        static SqlConnection connectionA = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;
        private string sql;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionA = new SqlConnection(ConfigurationManager.ConnectionStrings["DBTimeSheetConnectionStr"].ConnectionString);

            if (!IsPostBack)
            {
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

                    //Retriving all users
                    comd.CommandText = "SELECT * FROM Employees WHERE EmployeeNo = '" + Employees.EmpNo + "'";
                    reader = comd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtEmployeeNo.Text = reader["EmployeeNo"].ToString();
                        txtInitials.Text = reader["Initials"].ToString();
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtIDNo.Text = reader["IdentityNo"].ToString();
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
        }
        void clear()
        {
            txtInitials.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmployeeNo.Text = string.Empty;
            txtIDNo.Text = string.Empty;
        }
        void ShowMessage(String msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Validation", "<script language='javascript'>alert('" + msg + "');</script>");
        }
        protected void btnAddClient0_Click(object sender, EventArgs e)
        {
            clear(); 
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Update Client's Information
                connectionA.Open();
                sql = "UPDATE Employees SET Initials = '" + txtInitials.Text.ToString() + "', FirstName = '" + txtFirstName.Text + "', LastName = '" + txtLastName.Text + "' WHERE EmployeeNo = '" + txtEmployeeNo.Text.ToString() + "'";

                try
                {
                    adapter.UpdateCommand = connectionA.CreateCommand();
                    adapter.UpdateCommand.CommandText = sql;
                    adapter.UpdateCommand.ExecuteNonQuery();
                    connectionA.Close();
                    Response.Write("<script>alert('Employee Successfully Updated.........')</script>");
                    clear();
                }
                catch(Exception ex)
                {
                    ShowMessage(ex.Message + ex.Data);
                    connectionA.Close();
                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + x.Data + "') </script>");
                connectionA.Close();
            }
        }
    }
}
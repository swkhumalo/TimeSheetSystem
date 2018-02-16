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
    public partial class Registration : System.Web.UI.Page
    {

        static SqlConnection connectionA = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;
        private string sql;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionA = new SqlConnection(ConfigurationManager.ConnectionStrings["DBTimeSheetConnectionStr"].ConnectionString);
        }
        void clear()
        {
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtconfirmPassword.Text = string.Empty;
            txtEmail.Focus();
        }
        void ShowMessage(String msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Validation", "<script language='javascript'>alert('" + msg + "');</script>");
        }
        private bool valid()
        {
            if (txtconfirmPassword.Text == txtPassword.Text)
            {
                if (txtPassword.Text.Length <= 7)
                {
                    Response.Write("<script>alert('Password Too Week (8 characters)')</script>");
                    return false;
                }

                //Connect To The Database
                try
                {
                    connectionA.Open();
                    SqlCommand cmd = new SqlCommand();
                    sql = "SELECT * FROM AdminUsers";
                    adapter.SelectCommand = connectionA.CreateCommand();
                    adapter.SelectCommand.CommandText = sql;
                    reader = adapter.SelectCommand.ExecuteReader();

                    // Email Check
                    while (reader.Read())
                    {
                        if (reader["Email"].ToString() == txtEmail.Text.ToLower())
                        {
                            connectionA.Close();
                            reader.Close();
                            Response.Write("<script>alert('The email you entered is already registered in the system')</script>");
                            return false;
                        }
                    }

                }
                catch (Exception exp)
                {
                    connectionA.Close();
                    Response.Write(string.Format("<script>alert('{0}')</script>", exp.Message));
                    return false;
                }


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
            else
            {
                Response.Write("<script>alert('Passwords doesnt match')</script>");
                return false;
            }
        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                try
                {
                    connectionA.Open();

                    sql = "INSERT INTO AdminUsers(InitialsSurname, Email, Security) VALUES (@InitialsSurname, @Email, @Security)";
                    SqlCommand cmd = new SqlCommand(sql, connectionA);

                    cmd.Parameters.AddWithValue("@InitialsSurname", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Security", txtPassword.Text);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    clear();
                    connectionA.Close();

                    ShowMessage("Successfully Registered....!");
                    Response.Redirect("Signin.aspx");
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
        protected void btnAccountLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signin.aspx");
        }
    }
}
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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string email = " ";

        static SqlConnection connectionA = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;
        private string sql;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionA = new SqlConnection(ConfigurationManager.ConnectionStrings["DBTimeSheetConnectionStr"].ConnectionString);
            email = txtEmail.Text;
        }
        protected void btnForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
        protected void btnLinkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
        void ShowMessage(String msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Validation", "<script language='javascript'>alert('" + msg + "');</script>");
        } 
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                connectionA.Open();

                sql = "SELECT * FROM [AdminUsers] WHERE Email = @Email AND Security = @Security";
                SqlCommand cmd = new SqlCommand(sql, connectionA);

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Security", txtPassword.Text);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ShowMessage("Access Granted......!");
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    ShowMessage("User Doesn't Exist Only Admin User");
                }

                connectionA.Close();
            }
            catch (Exception c)
            {
                Response.Write("<script>alert('" + c.Message + "')</script>");
                connectionA.Close();
            }
        }

    }
}
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
    public partial class TimeSheet : System.Web.UI.Page
    {
        public static string EmpNo = "";

        static SqlConnection connectionA = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;
        public static string id = "";

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
                comd.CommandText = "SELECT * FROM `TimeSheet`";
                reader = comd.ExecuteReader();

                GridView1.DataSource = reader;
                GridView1.DataBind();
                */
                connectionA.Close();
            }
            catch (Exception exp)
            {
                connectionA.Close();
                Response.Write(string.Format("<script>alert('{0}')</script>", exp.Message));
            }

        }
        protected void GridView1_IndexChanged(object sender, EventArgs e)
        {
            Label l1 = GridView1.SelectedRow.FindControl("lblEmpNo") as Label;

            id = l1.Text;
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EmpNo = ((Label)GridView1.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("Label1")).Text;

            if (e.CommandName == "Sel")
            {
                Response.Redirect("EditTimeSheet.aspx");
            }
            
        }


    }
}
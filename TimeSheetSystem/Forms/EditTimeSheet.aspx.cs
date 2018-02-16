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
    public partial class EditTimeSheet : System.Web.UI.Page
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


                    //Retriving all TimeSheet
                    comd.CommandText = "SELECT * FROM TimeSheet WHERE EmployeeNo = '" + TimeSheet.EmpNo + "'";
                    reader = comd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtEmployeeNo.Text = reader["EmployeeNo"].ToString();
                        txtTimeIn.Text = reader["TimeIn"].ToString();
                        txtTimeOut.Text = reader["TimeOut"].ToString();
                        txtBreakIn.Text = reader["BreakIn"].ToString();
                        txtBreakOut.Text = reader["BreakOut"].ToString();
                    }
                    reader.Close();

                    //Retriving all users
                    comd.CommandText = "SELECT * FROM Employees WHERE EmployeeNo = '" + TimeSheet.EmpNo + "'";
                    reader = comd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtLastName.Text = reader["LastName"].ToString();
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
        private bool valid()
        {
            try
            {
                //initializing those fields into datetime
                DateTime TimeIn = Convert.ToDateTime(txtTimeIn.Text);
                DateTime BreakOut = Convert.ToDateTime(txtBreakOut.Text);
                DateTime TimeOut = Convert.ToDateTime(txtTimeOut.Text);
                DateTime BreakIn = Convert.ToDateTime(txtBreakIn.Text);

                if (TimeOut < TimeIn)
                {
                    Response.Write("<script>alert('You Can't Clock-Out Before Clock-In')</script>");
                    return false;
                }
                else if (TimeOut < BreakIn || TimeOut < BreakOut)
                {
                    Response.Write("<script>alert('You Can't Clock-Out Before Break-In or Break-Out')</script>");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception exp)
            {
                connectionA.Close();
                Response.Write(string.Format("<script>alert('{0}')</script>", exp.Message));
                return false;
            }
        }
        void clear()
        {
            txtTimeIn.Text = string.Empty;
            txtTimeOut.Text = string.Empty;
            txtBreakIn.Text = string.Empty;
            txtBreakOut.Text = string.Empty;
            txtEmployeeNo.Text = string.Empty;
            txtLastName.Text = string.Empty;
        }
        void ShowMessage(String msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Validation", "<script language='javascript'>alert('" + msg + "');</script>");
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("TimeSheet.aspx");
        }
        protected void btnTotalWage_Click(object sender, EventArgs e)
        {
            //initializing those fields into datetime
            DateTime TimeIn = Convert.ToDateTime(txtTimeIn.Text);
            DateTime BreakOut = Convert.ToDateTime(txtBreakOut.Text);
            DateTime TimeOut = Convert.ToDateTime(txtTimeOut.Text);
            DateTime BreakIn = Convert.ToDateTime(txtBreakIn.Text);

            //Checking the time difference between 2 times
            TimeSpan MorningSession = BreakOut - TimeIn;
            TimeSpan AfternoonSession = TimeOut - BreakIn;
            TimeSpan breakHour = BreakIn - BreakOut;

            //Convert it into minutes
            int TotalMorningSessionMinutes = (int)Math.Round(MorningSession.TotalMinutes);
            int TotalAfternooSessionMinutes = (int)Math.Round(AfternoonSession.TotalMinutes);
            int TotalBreakHourSessionMinutes = (int)Math.Round(breakHour.TotalMinutes);

            double totalHoursWorked = (TotalMorningSessionMinutes + TotalAfternooSessionMinutes) / 60;

            //Wages 
            double wagesMonday = 0.0;
            double wagesTuesday = 0.0;
            double wagesWednesday = 0.0;
            double wagesThursday = 0.0;
            double wagesFriday = 0.0;

            double wagesPW = 0.0;

            if (RadioButton1.Checked)
            {
                wagesMonday = 70.50 * totalHoursWorked;
            }
            else if (RadioButton2.Checked)
            {
                wagesTuesday = 65.50 * totalHoursWorked;
            }
            else if (RadioButton3.Checked)
            {
                wagesWednesday = 55.50 * totalHoursWorked;
            }
            else if (RadioButton4.Checked)
            {
                wagesThursday = 50.50 * totalHoursWorked;
            }
            else if (RadioButton5.Checked)
            {
                wagesFriday = 50.00 * totalHoursWorked;
            }
            wagesPW = wagesMonday + wagesTuesday + wagesWednesday + wagesThursday + wagesFriday;

            //convert EmployeeNo To Int
            int EmpNo = Convert.ToInt32(txtEmployeeNo.Text);
           
            if (valid())
            {
                try
                {
                    if (RadioButton1.Checked)
                    {
                        //wagesMonday = 70.50 * totalHoursWorked;
                        connectionA.Open();
                        //Update Employee's Time Sheet
                        sql = "UPDATE TimeSheet SET TimeIn = '" + TimeIn + "', TimeOut = '" + TimeOut + "', BreakIn = '" + BreakIn + "', BreakOut = '" + BreakOut + "', HoursWorked = '" + totalHoursWorked + "', Monday = '" + wagesMonday + "', Wages = '" + wagesPW + "' WHERE EmployeeNo = '" + EmpNo + "'";

                        try
                        {
                            adapter.UpdateCommand = connectionA.CreateCommand();
                            adapter.UpdateCommand.CommandText = sql;
                            adapter.UpdateCommand.ExecuteNonQuery();
                            connectionA.Close();
                            Response.Write("<script>alert('TimeSheet Successfully Updated.........')</script>");
                            clear();
                            Response.Redirect("TimeSheet.aspx");
                        }
                        catch (Exception ex)
                        {
                            ShowMessage(ex.Message + ex.Data);
                            connectionA.Close();
                        }
                    }
                    else if (RadioButton2.Checked)
                    {
                        //wagesTuesday = 65.50 * totalHoursWorked;
                        connectionA.Open();
                        //Update Employee's Time Sheet
                        sql = "UPDATE TimeSheet SET TimeIn = '" + TimeIn + "', TimeOut = '" + TimeOut + "', BreakIn = '" + BreakIn + "', BreakOut = '" + BreakOut + "', HoursWorked = '" + totalHoursWorked + "', Tuesday = '" + wagesTuesday + "', Wages = '" + wagesPW + "' WHERE EmployeeNo = '" + EmpNo + "'";

                        try
                        {
                            adapter.UpdateCommand = connectionA.CreateCommand();
                            adapter.UpdateCommand.CommandText = sql;
                            adapter.UpdateCommand.ExecuteNonQuery();
                            connectionA.Close();
                            Response.Write("<script>alert('TimeSheet Successfully Updated.........')</script>");
                            clear();
                            Response.Redirect("TimeSheet.aspx");

                        }
                        catch (Exception ex)
                        {
                            ShowMessage(ex.Message + ex.Data);
                            connectionA.Close();
                        }
                    }
                    else if (RadioButton3.Checked)
                    {
                        //wagesWednesday = 55.50 * totalHoursWorked;
                        connectionA.Open();
                        //Update Employee's Time Sheet
                        sql = "UPDATE TimeSheet SET TimeIn = '" + TimeIn + "', TimeOut = '" + TimeOut + "', BreakIn = '" + BreakIn + "', BreakOut = '" + BreakOut + "', HoursWorked = '" + totalHoursWorked + "', Wednesday = '" + wagesWednesday + "', Wages = '" + wagesPW + "' WHERE EmployeeNo = '" + EmpNo + "'";

                        try
                        {
                            adapter.UpdateCommand = connectionA.CreateCommand();
                            adapter.UpdateCommand.CommandText = sql;
                            adapter.UpdateCommand.ExecuteNonQuery();
                            connectionA.Close();
                            Response.Write("<script>alert('TimeSheet Successfully Updated.........')</script>");
                            clear();
                            Response.Redirect("TimeSheet.aspx");

                        }
                        catch (Exception ex)
                        {
                            ShowMessage(ex.Message + ex.Data);
                            connectionA.Close();
                        }
                    }
                    else if (RadioButton4.Checked)
                    {
                        //wagesThursday = 50.50 * totalHoursWorked;
                        connectionA.Open();
                        //Update Employee's Time Sheet
                        sql = "UPDATE TimeSheet SET TimeIn = '" + TimeIn + "', TimeOut = '" + TimeOut + "', BreakIn = '" + BreakIn + "', BreakOut = '" + BreakOut + "', HoursWorked = '" + totalHoursWorked + "', Thursday = '" + wagesThursday + "', Wages = '" + wagesPW + "' WHERE EmployeeNo = '" + EmpNo + "'";

                        try
                        {
                            adapter.UpdateCommand = connectionA.CreateCommand();
                            adapter.UpdateCommand.CommandText = sql;
                            adapter.UpdateCommand.ExecuteNonQuery();
                            connectionA.Close();
                            Response.Write("<script>alert('TimeSheet Successfully Updated.........')</script>");
                            clear();
                            Response.Redirect("TimeSheet.aspx");

                        }
                        catch (Exception ex)
                        {
                            ShowMessage(ex.Message + ex.Data);
                            connectionA.Close();
                        }
                    }
                    else if (RadioButton5.Checked)
                    {
                        //wagesFriday = 50.00 * totalHoursWorked;
                        connectionA.Open();
                        //Update Employee's Time Sheet
                        sql = "UPDATE TimeSheet SET TimeIn = '" + TimeIn + "', TimeOut = '" + TimeOut + "', BreakIn = '" + BreakIn + "', BreakOut = '" + BreakOut + "', HoursWorked = '" + totalHoursWorked + "', Friday = '" + wagesFriday + "', Wages = '" + wagesPW + "' WHERE EmployeeNo = '" + EmpNo + "'";

                        try
                        {
                            adapter.UpdateCommand = connectionA.CreateCommand();
                            adapter.UpdateCommand.CommandText = sql;
                            adapter.UpdateCommand.ExecuteNonQuery();
                            connectionA.Close();
                            Response.Write("<script>alert('TimeSheet Successfully Updated.........')</script>");
                            clear();
                            Response.Redirect("TimeSheet.aspx");

                        }
                        catch (Exception ex)
                        {
                            ShowMessage(ex.Message + ex.Data);
                            connectionA.Close();
                        }
                    }
                    
                }
                catch (Exception x)
                {
                    Response.Write("<script>alert('" + x.Message + x.Data + "') </script>");
                    connectionA.Close();
                }
            }
           
        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
            RadioButton5.Checked = false;
        }
        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
            RadioButton5.Checked = false;
        }
        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Checked = false;
            RadioButton1.Checked = false;
            RadioButton4.Checked = false;
            RadioButton5.Checked = false;
        }
        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton1.Checked = false;
            RadioButton5.Checked = false;
        }
        protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
            RadioButton1.Checked = false;
        }
    }
}
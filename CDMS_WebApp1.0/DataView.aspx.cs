using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CDMS_WebApp1._0
{
    public partial class DataView : System.Web.UI.Page
    {
        private static string _connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _connectionString = ConfigurationManager.ConnectionStrings["CDMS_ConnectionString"].ConnectionString;

                //FromDateTextBox.Value = DateTime.Now.ToShortDateString();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string slno = ((Button)(sender)).CommandArgument;

            Response.Redirect("DataLog.aspx?FromDataView=true&SlNo=" + slno);
        }

        protected void ShowButton_Click(object sender, EventArgs e)
        {
            PrintButton.Visible = false;
            HeaderLabel.Text = string.Empty;
            if (string.IsNullOrEmpty(FromDateTextBox.Value) || string.IsNullOrEmpty(FromDateTextBox.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('select dates');", true);
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                string sql = "";
                if (Contamination_LevelTextBox.Text == "")
                {
                    GridView2.Visible = false;
                    GridView1.Visible = true;
                    sql = "SELECT Sl_No,DATE_FORMAT(Date, '%d/%m/%Y') as Date,Current_Shift,Room_No,Contamination_level,Air_activity,Remarks from new_cdms  where current_shift='" + DropDownList1.Text + "' and date between  '" + FromDateTextBox.Value + "' and '" + ToDateTextBox.Value + "' order by date";

                    MySqlCommand sCommand = new MySqlCommand(sql, connection);
                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(sCommand);
                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);
                    DataSet sDs = new DataSet();
                    var rowsAffected = sAdapter.Fill(sDs, "new_cdms");
                    //stable = sDs.Tables["new_cdms"];
                    GridView1.DataSource = sDs.Tables["new_cdms"];
                    GridView1.DataBind();
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        HeaderLabel.Text = "Shift Details";
                        PrintButton.Visible = true;
                    }
                }
                else
                {
                    GridView2.Visible = true;
                    GridView1.Visible = false;
                    if (SmearDropDownList.Text == "S")
                    {
                        sql = "SELECT DATE_FORMAT(Date, '%d/%m/%Y') as Date,Unit,Room_No,Contamination_level,Remarks FROM new_cdms where Smear_airsample='" + SmearDropDownList.Text + "'  and date between '" + FromDateTextBox.Value + "' and '" + ToDateTextBox.Value + "' and CAST(contamination_level AS double) " + ConditionDropDownList.Text +  " '" + Convert.ToDecimal(Contamination_LevelTextBox.Text) + "' order by date";

                    }
                    else
                    {
                        sql = "SELECT DATE_FORMAT(Date, '%d/%m/%Y') as Date,Unit,Room_No,Air_activity,Remarks FROM new_cdms where Smear_airsample='" + SmearDropDownList.Text + "' and date between '" + FromDateTextBox.Value + "' and '" + ToDateTextBox.Value + "' and CAST(Air_activity AS double) " +  ConditionDropDownList.Text   + " '" + Convert.ToDecimal(Contamination_LevelTextBox.Text) + "' order by date";

                    }
                    MySqlCommand sCommand = new MySqlCommand(sql, connection);
                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(sCommand);
                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);
                    DataSet sDs = new DataSet();
                    var rowsAffected = sAdapter.Fill(sDs, "new_cdms");
                    //stable = sDs.Tables["new_cdms"];
                    GridView2.DataSource = sDs.Tables["new_cdms"];
                    GridView2.DataBind();

                    connection.Close();
                    if (rowsAffected > 0 && SmearDropDownList.Text == "S")
                    {
                        HeaderLabel.Text = "Loose Contamination level";
                        PrintButton.Visible = true;
                    }
                    else if (rowsAffected > 0)
                    {
                        HeaderLabel.Text = "Air activity level";
                        PrintButton.Visible = true;
                    }
                }
                //DataTable stable;

            }
        }

        protected void SmearDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SmearDropDownList.Text)
            {
                case "A":
                    valueLabel.Text = "Air Activity";
                    break;
                case "S":
                    valueLabel.Text = "Contamination Level :";
                    break;
                default:
                    valueLabel.Text = "Contamination Level :";
                    break;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection("Data Source=10.38.31.10;user id =ghpu;password=ghpu123;database=backup"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Sl_No,DATE_FORMAT(Contamination_Date, '%d/%m/%Y') as Contamination_Date,Unit,Room_No,Contamination_level,Remarks from cdms_backup", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}

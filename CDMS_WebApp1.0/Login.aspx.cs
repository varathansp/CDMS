using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CDMS_WebApp1._0
{
    public partial class Login : System.Web.UI.Page
    {
        private static string _connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _connectionString = ConfigurationManager.ConnectionStrings["CDMS_ConnectionString"].ConnectionString;
                LoginLabel.Visible = false;
            }
        }








        protected void Button1_Click3(object sender, EventArgs e)
        {
            string s963 = "select * from pass where username='" + UserNameTextBox.Text + "' and password='" + PasswordTextBox.Text + "'";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand cm4440 = new MySqlCommand(s963, connection);
            MySqlDataReader rs4440;
            rs4440 = cm4440.ExecuteReader();
            if (rs4440.HasRows)
            {
                rs4440.Read();
                Session["UserId"] = rs4440.GetString(0);
                Response.Redirect("Home.aspx");
            }
            else
            {
                LoginLabel.Visible = true;
                LoginLabel.Text = "Invalid Credentials";
                PasswordTextBox.Text = "";
                PasswordTextBox.Focus();
            }
            connection.Close();
        }

    }
}


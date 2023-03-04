using CDMS_WebApp1._0.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CDMS_WebApp1._0
{

    public partial class Home : System.Web.UI.Page
    {
        private static string _connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CDMS_ConnectionString"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            Date.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt ddd");
            string s2;
            s2 = "select * from new_cdms";
            MySqlCommand cmd2 = new MySqlCommand(s2, connection);
            MySqlDataReader rs2;
            rs2 = cmd2.ExecuteReader();
            while ((rs2.Read()))
            {
                //Label2.Text = (rs2["shp"].ToString());
                //Label3.Text = (rs2["shp1"].ToString());
                //Label4.Text = (rs2["shift_technician"].ToString());
            }

            rs2.Close();



        }
    }
}

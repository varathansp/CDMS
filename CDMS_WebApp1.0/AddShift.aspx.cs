using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using CDMS_WebApp1._0.Utilities;

namespace CDMS_WebApp1._0
{
    public partial class AddShift : System.Web.UI.Page
    {
        private static string _connectionString;

        private static AddShiftModel existingShift = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Request.QueryString["IsEmptyShift"] != null && Request.QueryString["IsEmptyShift"].ToString() == "true")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('Please add the shift first');",true);
                    }
                    DateText.Text = DateTime.Now.ToShortDateString();
                }
                _connectionString = ConfigurationManager.ConnectionStrings["CDMS_ConnectionString"].ConnectionString;
                
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                string s6;
                s6 = "select distinct username from shp order by username";
                MySqlCommand cmd6 = new MySqlCommand(s6, connection);
                MySqlDataReader rs6;
                rs6 = cmd6.ExecuteReader();
                while ((rs6.Read()))
                    Physicist1DropDownList.Items.Add(rs6["username"].ToString());
                rs6.Close();
                string s7;
                s7 = "select distinct username from shp1 order by username";
                MySqlCommand cmd7 = new MySqlCommand(s7, connection);
                MySqlDataReader rs7;
                rs7 = cmd7.ExecuteReader();
                while ((rs7.Read()))
                    Physicist2DropDownList.Items.Add(rs7["username"].ToString());
                rs7.Close();
                string s8;
                s8 = "select distinct username from shp2 order by username";
                MySqlCommand cmd8 = new MySqlCommand(s8, connection);
                MySqlDataReader rs8;
                rs8 = cmd8.ExecuteReader();
                while ((rs8.Read()))
                    PhysicistRSDDropDownList.Items.Add(rs8["username"].ToString());
                rs8.Close();
                string s10;
                s10 = "select distinct username from Contract_staff1 order by username";
                MySqlCommand cmd10 = new MySqlCommand(s10, connection);
                MySqlDataReader rs10;
                rs10 = cmd10.ExecuteReader();
                while ((rs10.Read()))
                    ContractStaff1DropDownList.Items.Add(rs10["username"].ToString());
                rs10.Close();
                string s11;
                s11 = "select distinct username from Contract_staff2 order by username";
                MySqlCommand cmd11 = new MySqlCommand(s11, connection);
                MySqlDataReader rs11;
                rs11 = cmd11.ExecuteReader();
                while ((rs11.Read()))
                    ContractStaff2DropDownList.Items.Add(rs11["username"].ToString());
                rs11.Close();
                string s12;
                s12 = "select distinct username from Contract_staff3 order by username";
                MySqlCommand cmd12 = new MySqlCommand(s12, connection);
                MySqlDataReader rs12;
                rs12 = cmd12.ExecuteReader();
                while ((rs12.Read()))
                    ContractStaff3DropDownList.Items.Add(rs12["username"].ToString());
                rs12.Close();
                string s13;
                s13 = "select distinct username from users order by username";
                MySqlCommand cmd13 = new MySqlCommand(s13, connection);
                MySqlDataReader rs13;
                rs13 = cmd13.ExecuteReader();
                while ((rs13.Read()))
                    ShiftTechnicianDropDownList.Items.Add(rs13["username"].ToString());
                rs13.Close();
                string s14;
                s14 = "select distinct username from users order by username";
                MySqlCommand cmd14 = new MySqlCommand(s14, connection);
                MySqlDataReader rs14;
                rs14 = cmd14.ExecuteReader();
                while ((rs14.Read()))
                    T2TechnicianDropDownList.Items.Add(rs14["username"].ToString());
                rs14.Close();
                connection.Close();
                //if (Request.QueryString["EditMode"].ToString() == "true")
                //{
                //    ReadQueryString();
                //}



            }
            catch (Exception ex)
            {

            }
        }

        private void ReadQueryString()
        {
            DateText.Text = Request.QueryString["Date"].ToString();
            ShiftDropDownList.Text = Request.QueryString["Shift"].ToString();
            CrewDropDownList.Text = Request.QueryString["Crew"].ToString();

            ShiftTechnicianDropDownList.Text = Request.QueryString["ShiftTechnician"].ToString();
            T2TechnicianDropDownList.Text = Request.QueryString["T2Technician"].ToString();
            ContractStaff1DropDownList.Text = Request.QueryString["ContractStaff1"].ToString();
            ContractStaff2DropDownList.Text = Request.QueryString["ContractStaff2"].ToString();
            ContractStaff3DropDownList.Text = Request.QueryString["ContractStaff3"].ToString();

            Physicist1DropDownList.Text = Request.QueryString["Physicist1"].ToString();
            Physicist1Notes.Text = Request.QueryString["Physicist1Notes"].ToString();
            Physicist2DropDownList.Text = Request.QueryString["Physicist2"].ToString();
            Physicist2Notes.Text = Request.QueryString["Physicist2Notes"].ToString();
            PhysicistRSDDropDownList.Text = Request.QueryString["PhysicistRSD"].ToString();
        }

        protected void AddShiftButton_Click(object sender, EventArgs e)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CDMS_ConnectionString"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            string sql2 = "SELECT * FROM shift WHERE date = '" + Convert.ToDateTime(DateText.Text).ToString("yyyy-MM-dd") + "' and  Current_Shift = '" + ShiftDropDownList.Text + "'";

            MySqlCommand cmd2 = new MySqlCommand(sql2, connection);
            MySqlDataReader rs1z;
             rs1z = cmd2.ExecuteReader();
             
            string shiftText = string.Empty;
            if (rs1z.HasRows)
            {
                while ((rs1z.Read()))
                {
                    
                     shiftText ="<b>Existing Shift</b>"  + "<br />" + "Date :" + Convert.ToDateTime(rs1z["Date"].ToString()).ToString("yyyy-MM-dd") + "<br />" + "  Shift : " + (rs1z["Current_Shift"].ToString()) + "<br />" +  " Crew : " + (rs1z["Current_Shift"].ToString());
                }
                rs1z.Close();
                existingShift = new AddShiftModel();
                existingShift.Date = DateText.Text;
                existingShift.Shift = ShiftDropDownList.Text;
                existingShift.Crew = CrewDropDownList.Text;
                existingShift.ShiftTechnician = ShiftTechnicianDropDownList.Text;
                existingShift.T2Technician = T2TechnicianDropDownList.Text;
                existingShift.ContractStaff1 = ContractStaff1DropDownList.Text;
                existingShift.ContractStaff2 = ContractStaff2DropDownList.Text;
                existingShift.ContractStaff3 = ContractStaff3DropDownList.Text;
                existingShift.Physicist1 = Physicist1DropDownList.Text;
                existingShift.Physicist1Notes = Physicist1Notes.Text;
                existingShift.Physicist2 = Physicist2DropDownList.Text;
                existingShift.Physicist2Notes = Physicist2Notes.Text;
                existingShift.PhysicistRSD = PhysicistRSDDropDownList.Text;

                var message = "Shift " + ShiftDropDownList.Text + " is already added for the date " + Convert.ToDateTime(DateText.Text).ToString("yyyy-MM-dd");
                ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('" + message + "');", true);

                ExistingShiftLabel.Text = shiftText;
                UseExistingShift.Visible = true;
                connection.Close();
            }
            else
            {

                AddShiftModel addshift = new AddShiftModel();
                addshift.Date = DateText.Text;
                addshift.Shift = ShiftDropDownList.Text;
                addshift.Crew = CrewDropDownList.Text;
                addshift.ShiftTechnician = ShiftTechnicianDropDownList.Text;
                addshift.T2Technician = T2TechnicianDropDownList.Text;
                addshift.ContractStaff1 = ContractStaff1DropDownList.Text;
                addshift.ContractStaff2 = ContractStaff2DropDownList.Text;
                addshift.ContractStaff3 = ContractStaff3DropDownList.Text;
                addshift.Physicist1 = Physicist1DropDownList.Text;
                addshift.Physicist1Notes = Physicist1Notes.Text;
                addshift.Physicist2 = Physicist2DropDownList.Text;
                addshift.Physicist2Notes = Physicist2Notes.Text;
                addshift.PhysicistRSD = PhysicistRSDDropDownList.Text;
                connection.Close();
                connection.Open();
                //string sql = "insert into shift values('','" + Convert.ToDateTime(DateText.Text).ToString("yyyy-MM-dd") + "','" + ShiftDropDownList.Text + "','" + CrewDropDownList.Text + "','" + Physicist1DropDownList.Text + "', '" + Physicist1Notes.Text + "','"
                //       + Physicist2DropDownList.Text + "','" + Physicist2Notes.Text + "','" + PhysicistRSDDropDownList.Text + "','" + ShiftTechnicianDropDownList.Text + "','" + T2TechnicianDropDownList.Text + "','" + ContractStaff1DropDownList.Text
                //       + "','" + ContractStaff2DropDownList.Text + "','" + ContractStaff3DropDownList.Text + "')";
                string sql = "insert into shift values('','" + Convert.ToDateTime(DateText.Text).ToString("yyyy-MM-dd") + "','" + ShiftDropDownList.Text + "','" + CrewDropDownList.Text + "','" + PhysicistRSDDropDownList.Text + "','" + Physicist1DropDownList.Text + "','"
                      + Physicist2DropDownList.Text + "','" + ShiftTechnicianDropDownList.Text + "','" + ContractStaff1DropDownList.Text
                      + "','" + ContractStaff2DropDownList.Text + "','" + ContractStaff3DropDownList.Text + "')";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                
                ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('Shift Added');", true);
                Session["SessionShift"] = addshift;

                ExistingShiftLabel.Text = string.Empty;
                UseExistingShift.Visible = false;
                Response.Redirect("DataLog.aspx");
            }
        }

        protected void ShiftDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            crew();
        }

        protected void CrewDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            crew();
        }
        public void crew()
        {
            if (CrewDropDownList.Text == "A")
            {
                Physicist1DropDownList.Text = "harianedath";
                Physicist2DropDownList.Text = "tamilselvanl";
                //PhysicistRSDDropDownList.Text = "sundar.s";
                ContractStaff1DropDownList.Text = "M.B.Prabhu";
                ContractStaff2DropDownList.Text = "Sudalai Esakki Pandi";
                //ContractStaff3DropDownList.Text = "hariharasuthan";
            }

            if (CrewDropDownList.Text == "B")
            {
                //Physicist1DropDownList.Text = "nxaustine";
                //Physicist2DropDownList.Text = "vasanthbabum";
                //PhysicistRSDDropDownList.Text = "siva.m";
                ContractStaff1DropDownList.Text = "Sankar T";
                ContractStaff2DropDownList.Text = "Jeya Kumar P";
                ContractStaff3DropDownList.Text = "P.Suresh";
            }

            if (CrewDropDownList.Text == "C")
            {
                Physicist1DropDownList.Text = "arunkrishnan";
                //Physicist2DropDownList.Text = "abhijithaj";
                //PhysicistRSDDropDownList.Text = "lingadurai.g";
                //ContractStaff1DropDownList.Text = "Sundarraj J";
                ContractStaff2DropDownList.Text = "Selvakumar";
                //ContractStaff3DropDownList.Text = "Mahendran";
            }

            if (CrewDropDownList.Text == "D")
            {
                Physicist1DropDownList.Text = "austabalanm";
                Physicist2DropDownList.Text = "karthikeyansb";
                //PhysicistRSDDropDownList.Text = "saravanan.k";
                ContractStaff1DropDownList.Text = "Ramachandran";
                //ContractStaff2DropDownList.Text = "Ramarajan P";
                ContractStaff3DropDownList.Text = "Anandaraman";
            }
        }

        protected void UseExistingShift_Click(object sender, EventArgs e)
        {
            Session["SessionShift"] = existingShift;
            Response.Redirect("DataLog.aspx");
        }
    }
}
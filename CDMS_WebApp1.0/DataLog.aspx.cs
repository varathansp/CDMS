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
    public partial class DataLog : System.Web.UI.Page
    {
        private static string _connectionString;

        private static AddShiftModel AddShiftResponse;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _connectionString = ConfigurationManager.ConnectionStrings["CDMS_ConnectionString"].ConnectionString;

                LivedTextBox.Enabled = false;
                SampleCountsTextBox.Enabled = false;
                NetCountsTextBox.Enabled = false;

                //MaterialClearanceDiv.Visible = true;

                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                string s;
                s = "select max(sl_no) from new_cdms";
                MySqlCommand cmdsss = new MySqlCommand(s, connection);
                MySqlDataReader rs;
                rs = cmdsss.ExecuteReader();
                rs.Read();
                int n;
                n = rs.GetInt32(0) + 1;
                rs.Close();
                SLNODropDownList.Text = n.ToString();
                //SearchDropDownList.Text = n;

                //SearchDropDownList.Items.Clear();
                //string s1;
                //s1 = "select sl_no from new_cdms order by sl_no desc";
                //MySqlCommand cmd1 = new MySqlCommand(s1, connection);
                //MySqlDataReader rs1;
                //rs1 = cmd1.ExecuteReader();
                //while ((rs1.Read()))

                //    SearchDropDownList.Items.Add(rs1["sl_no"].ToString());

                //rs1.Close();

                SearchDropDownList.Items.Clear();
                string s2;
                s2 = "select distinct sl_no from new_cdms order by sl_no desc ";
                MySqlCommand cmd2 = new MySqlCommand(s2, connection);
                MySqlDataReader rs2;
                rs2 = cmd2.ExecuteReader();
                while ((rs2.Read()))
                {
                    SLNODropDownList.Items.Add(rs2["sl_no"].ToString());
                    SearchDropDownList.Items.Add(rs2["sl_no"].ToString());
                }

                rs2.Close();

                UnitDropDownList.Items.Clear();
                string s3;
                s3 = "select distinct unit from new_cdms order by unit";
                MySqlCommand cmd3 = new MySqlCommand(s3, connection);
                MySqlDataReader rs3;
                rs3 = cmd3.ExecuteReader();
                while ((rs3.Read()))
                    UnitDropDownList.Items.Add(rs3["unit"].ToString());

                rs3.Close();

                LocationUnitDropDownList.Items.Clear();
                string s4;
                s4 = "select distinct unit from eff order by unit";
                MySqlCommand cmd4 = new MySqlCommand(s4, connection);
                MySqlDataReader rs4;
                rs4 = cmd4.ExecuteReader();
                while ((rs4.Read()))
                    LocationUnitDropDownList.Items.Add(rs4["unit"].ToString());

                rs4.Close();

                string s15;
                s15 = "select distinct username from contract_staff1 order by username";
                MySqlCommand cmd15 = new MySqlCommand(s15, connection);
                MySqlDataReader rs15;
                rs15 = cmd15.ExecuteReader();
                while ((rs15.Read()))
                    MaterialCountedByDropDownList.Items.Add(rs15["username"].ToString());
                rs15.Close();
                connection.Close();

                //if (Request.QueryString["Crew"] != null)
                //{
                //    ReadQueryStrings();
                //}

                DataEntryPanel.Enabled = false;
                BGCPanel.Enabled = false;
                MaterialPanel.Enabled = false;
                BottomPanel.Enabled = false;

                MaterialPanel.Visible = false;

                //if (Request.QueryString["EditMode"].ToString() == "true" || Request.QueryString["FromAddShift"].ToString() == "true") 
                //{
                //    DataEntryPanel.Enabled = true;
                //    BGCPanel.Enabled = true;
                //    MaterialPanel.Enabled = true;
                //    BottomPanel.Enabled = true;
                //   // AddShiftButton.Visible = true;

                //   // AddShiftButton.Text = "Edit Shift";
                //    InitialAddRecord.Visible = false;
                //}
                if (Request.QueryString["FromDataView"] != null && Request.QueryString["FromDataView"].ToString() == "true")
                {
                    int slno = Convert.ToInt32(Request.QueryString["SlNo"].ToString());
                    Search(slno);
                    ViewMode();
                }
                if (Session["SessionShift"] == null)
                {
                    Response.Redirect("AddShift.aspx?IsEmptyShift=true");
                }
                else
                {
                    ReadShiftFromSession();
                }
                //LoadCountingSystem();

                BuildingTextBox.Visible = false;

            }
        }
        private void ReadShiftFromSession()
        {


            AddShiftResponse = (AddShiftModel)Session["SessionShift"];
        }

        protected void SmearDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SmearDropDownList.Text == "A")
                {
                    
                    MySqlConnection connection = new MySqlConnection(_connectionString);
                    connection.Open();
                    string s33;

                    s33 = "select * from new_cdms WHERE Air_activity != '' order by sl_no desc limit 1";

                    MySqlCommand cmd33 = new MySqlCommand(s33, connection);
                    MySqlDataReader rs33;
                    rs33 = cmd33.ExecuteReader();
                    while ((rs33.Read()))
                        HeaderLabel.Text = "Last AirActivity Value";
                        DateLabel.Text="Date : " +(rs33["date"].ToString());
                        ValueLabel.Text ="AirActivity : " + (rs33["air_activity"].ToString());
                        RoomNoLabel.Text = "Room No : " + (rs33["Room_No"].ToString());
                    rs33.Close();

                    ActivityDropDownList.Enabled = true;
                    TimeofSamplingTextBox.Text = DateTime.Now.ToString("HH:mm");
                    TimeofCountingTextBox.Text = DateTime.Now.ToString("HH:mm");
                    TimeofSamplingTextBox.Enabled = true;
                    TimeofCountingTextBox.Enabled = true;

                    ContaminationLevelTextBox.Text = "";
                    RemarksTextBox.Text = "";
                    LLDTextBox.Text = "";
                    MDAdpmTextBox.Text = "";
                    MDABqTextBox.Text = "";
                    LLDBKGTextBox.Text = "";

                    SamplingTimeTextBox.Text = "5";
                    BKGCountTimeTextBox.Text = "1";
                    SampleCountTimeTextBox.Text = "1";
                    AreaCorrectionFactorTextBox.Text = "17.64";
                    HalfLifeTextBox.Text = "20";
                    RemarksTextBox.Text = "";
                    TotalAreaSwipedTextBox.Text = "";

                    AerosolDropDownList.Enabled = true;
                    LivedTextBox.Enabled = true;
                    ActivityDropDownList.Enabled = true;
                    ElapsedTimeTextBox.Enabled = true;
                    HalfLifeTextBox.Enabled = true;
                    FlowrateTextBox.Enabled = true;
                    DecayCorrectionFactorTextBox.Enabled = true;
                    AreaCorrectionFactorTextBox.Enabled = true;
                    SamplingTimeTextBox.Enabled = true;
                    TotalAirSampledTextBox.Enabled = true;
                    AirActivityTextBox.Enabled = true;
                    DACTextBox.Enabled = true;
                }
                else if (SmearDropDownList.Text == "S")
                {
                    MySqlConnection connection = new MySqlConnection(_connectionString);
                    connection.Open();

                    string s34;
                    s34 = "select * from new_cdms where contamination_level != '' order by sl_no desc limit 1";

                    MySqlCommand cmd34 = new MySqlCommand(s34, connection);
                    MySqlDataReader rs34;
                    rs34 = cmd34.ExecuteReader();
                    while ((rs34.Read()))
                        HeaderLabel.Text = "Last Contamination Value";
                    DateLabel.Text = "Date : " + (rs34["date"].ToString());
                    ValueLabel.Text = "Contamination Level : " + (rs34["contamination_level"].ToString());
                    RoomNoLabel.Text = "Room No : " + (rs34["Room_No"].ToString());
                    rs34.Close();

                    ActivityDropDownList.Text = "";
                    AerosolDropDownList.Enabled = false;
                    LivedTextBox.Enabled = false;
                    ActivityDropDownList.Enabled = false;
                    TimeofSamplingTextBox.Enabled = false;
                    TimeofCountingTextBox.Enabled = false;
                    ElapsedTimeTextBox.Enabled = false;
                    HalfLifeTextBox.Enabled = false;
                    FlowrateTextBox.Enabled = false;
                    DecayCorrectionFactorTextBox.Enabled = false;
                    AreaCorrectionFactorTextBox.Enabled = false;
                    SamplingTimeTextBox.Enabled = false;
                    TotalAirSampledTextBox.Enabled = false;
                    AirActivityTextBox.Enabled = false;
                    DACTextBox.Enabled = false;
                    TotalAreaSwipedTextBox.Text = "100";
                    BKGCountTimeTextBox.Text = "1";
                    SampleCountTimeTextBox.Text = "1";
                    // ActivityDropDownList.Text = ""
                    RemarksTextBox.Text = "";
                    SamplingTimeTextBox.Text = "";
                    DACTextBox.Text = "";
                    AirActivityTextBox.Text = "";
                    FlowrateTextBox.Text = "";
                    TimeofSamplingTextBox.Text = "";
                    TimeofCountingTextBox.Text = "";
                    SamplingTimeTextBox.Text = "";
                    DecayCorrectionFactorTextBox.Text = "";
                    FlowrateTextBox.Text = "";
                    TotalAirSampledTextBox.Text = "";
                    AirActivityTextBox.Text = "";
                    DACTextBox.Text = "";
                    LivedTextBox.Text = "";
                    AerosolDropDownList.Text = "";
                    AreaCorrectionFactorTextBox.Text = "";
                    ElapsedTimeTextBox.Text = "";
                    HalfLifeTextBox.Text = "";
                    NetCountsTextBox.Text = "";
                    RemarksTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void AddRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                string s;
                s = "select max(sl_no) from new_cdms";
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand cmds = new MySqlCommand(s, connection);
                MySqlDataReader rsd1;
                rsd1 = cmds.ExecuteReader();
                rsd1.Read();
                int n1;
                n1 = rsd1.GetInt32(0) + 1;
                //SLNODropDownList.Text = n1.ToString();
                //SearchDropDownList.Text = n1.ToString();

                rsd1.Close();
                connection.Close();


                string sql = "insert into new_cdms values(" + n1.ToString() + ",'" + Convert.ToDateTime(AddShiftResponse.Date).ToString("yyyy-MM-dd") + "','"
                    + CountingSystemDropDownList.Text + "','" + CounterEfficiencyTextBox.Text + "','" + Convert.ToDateTime(AsON.Text).ToString("yyyy-MM-dd") + "', '" + RackDropDownList.Text + "','"
                    + SampleDescriptionDropDownList.Text + "','" + SmearDropDownList.Text + "','" + AerosolDropDownList.Text + "','" + TimeofSamplingTextBox.Text + "','" + TimeofCountingTextBox.Text + "','" + ElapsedTimeTextBox.Text
                    + "','" + AreaCorrectionFactorTextBox.Text + "','" + DecayCorrectionFactorTextBox.Text + "','" + HalfLifeTextBox.Text + "','" + FlowrateTextBox.Text + "','" + SamplingTimeTextBox.Text + "','" + TotalAirSampledTextBox.Text
                    + "','" + BKGCountTimeTextBox.Text + "','" + SampleCountTimeTextBox.Text + "','" + BKGCountsTextBox.Text + "','" + SampleCountsTextBox.Text + "','" + NetCountsTextBox.Text + "','" + TotalAreaSwipedTextBox.Text
                    + "','" + ContaminationLevelTextBox.Text + "','" + AirActivityTextBox.Text + "','" + DACTextBox.Text + "','','" + RemarksTextBox.Text + "',"
                    + UnitDropDownList.Text + ",'" + StatusDropDownList.Text + "','" + LLDTextBox.Text + "','" + MDAdpmTextBox.Text + "','" + MDABqTextBox.Text + "','" + LLDBKGTextBox.Text
                    + "','" + LivedTextBox.Text + "'," + LocationUnitDropDownList.Text + ",'" + AddShiftResponse.Shift + "','','', '','','','','','','','','"
                    + LocationUnitDropDownList.Text + "','" + string.Empty + "','" + PlantStatusDropDownList.Text + "','','" + MaterialIdTextBox.Text + "','"
                    + Convert.ToDateTime(ContaminationDateTextBox.Text).ToString("yyyy-MM-dd HH:mm:ss") + "','" + Session["UserId"].ToString() + "','" + RequestedByTextBox.Text + "','" + LocationFromDropDownList.Text
                    + "','" + LocationToDropDownList.Text + "','" + PurposeDropDownList.Text + "','" + InstrumentLocationDropDownList.Text + "','" + AddShiftResponse.T2Technician + "','" + MaterialCountedByDropDownList.Text + "')";

                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();

                // ComboBox19.Text = n4
                ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('New Record Inserted');", true);

                //DACTextBox.Text = "";
                //TimeofSamplingTextBox.Text = "";
                //TimeofCountingTextBox.Text = "";
                //DecayCorrectionFactorTextBox.Text = "";
                //FlowrateTextBox.Text = "";
                //TotalAirSampledTextBox.Text = "";
                //AirActivityTextBox.Text = "";
                //SampleCountsTextBox.Text = "";
                //NetCountsTextBox.Text = "";
                //ContaminationLevelTextBox.Text = "";
                //RemarksTextBox.Text = "";
                //LivedTextBox.Text = "";


                SampleDescriptionDropDownList.Items.Add("R");
                SampleDescriptionDropDownList.Items.Add("N");
                SampleDescriptionDropDownList.Items.Add("O");
                SampleDescriptionDropDownList.Items.Add("M");
                SampleDescriptionDropDownList.Items.Add("Radeye-B20");
                SampleDescriptionDropDownList.Items.Add("NRP");




                SLNODropDownList.Items.Clear();
                SearchDropDownList.Items.Clear();

                string ssss;
                ssss = "select sl_no from new_cdms order by sl_no desc";
                MySqlCommand cmdz = new MySqlCommand(ssss, connection);
                MySqlDataReader rsz;
                rsz = cmdz.ExecuteReader();
                while ((rsz.Read()))
                {
                    SLNODropDownList.Items.Add(rsz.GetInt32(0).ToString());
                    SearchDropDownList.Items.Add(rsz.GetInt32(0).ToString());
                }
                ViewMode();

                LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100).ToString("0.00");
                LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");
                rsz.Close();
                connection.Close();


            }
            catch (Exception ex)
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void ViewMode()
        {
            AddRecordButton.Visible = false;
            //AddShiftButton.Visible = false;
            InitialAddRecord.Visible = true;
            DataEntryPanel.Enabled = false;
            BGCPanel.Enabled = false;
            MaterialPanel.Enabled = false;
            BottomPanel.Enabled = false;

            EditButton.Visible = true;
            DeleteButton.Visible = true;
        }

        protected void TimeofCountingTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int aa = CDMSUtilities.strLeft(TimeofSamplingTextBox.Text, 2);
                int bb = CDMSUtilities.strRight(TimeofSamplingTextBox.Text, 2);

                int cc = CDMSUtilities.strLeft(TimeofCountingTextBox.Text, 2);
                int dd = CDMSUtilities.strRight(TimeofCountingTextBox.Text, 2);

                int kk = cc - aa;

                if (kk < 0)
                {
                    aa = (((24 + kk) * 60) - bb) + dd;

                    ElapsedTimeTextBox.Text = aa.ToString();
                }
                else
                {
                    aa = (aa * 60) + bb;
                    cc = (cc * 60) + dd;
                    ElapsedTimeTextBox.Text = (cc - aa).ToString();
                }

                DecayCorrectionFactorTextBox.Text = Math.Round(Math.Exp(0.693 / Convert.ToDouble(HalfLifeTextBox.Text) * Convert.ToDouble(ElapsedTimeTextBox.Text)), 3).ToString();

                DACTextBox.Text = (Convert.ToDouble(AirActivityTextBox.Text) / Convert.ToDouble(LivedTextBox.Text)).ToString("0.00");

            }
            catch (Exception ex)
            {
            }
        }

        //protected void addshiftbutton_click(object sender, Eventargs e)
        //{

        //    //session["newrecorddata"] = new addshiftmodel() { contractstaff1 = "me" };
        //    //if (addshiftbutton.text == "edit shift")
        //    //{
        //    //    string query = setquerystring();
        //    //    response.redirect("addshift.aspx?" + query);

        //    //}
        //    //else
        //    //{
        //    //    response.redirect("addshift.aspx?editmode=false");
        //    //}

        //}

        //private string SetQueryString()
        //{
        //    Dictionary<string, string> addShiftDictionary = new Dictionary<string, string>();
        //    if (AddShiftButton.Text == "Edit Shift")
        //    {
        //        addShiftDictionary.Add("EditMode", "true");
        //    }
        //    else
        //    { addShiftDictionary.Add("EditMode", "false"); }
        //    addShiftDictionary.Add("Date", AddShiftResponse.Date);
        //    addShiftDictionary.Add("Shift", AddShiftResponse.Shift);
        //    addShiftDictionary.Add("Crew", AddShiftResponse.Crew);

        //    addShiftDictionary.Add("ShiftTechnician", AddShiftResponse.ShiftTechnician);
        //    addShiftDictionary.Add("T2Technician", AddShiftResponse.T2Technician);
        //    addShiftDictionary.Add("ContractStaff1", AddShiftResponse.ContractStaff1);
        //    addShiftDictionary.Add("ContractStaff2", AddShiftResponse.ContractStaff2);
        //    addShiftDictionary.Add("ContractStaff3", AddShiftResponse.ContractStaff3);


        //    addShiftDictionary.Add("Physicist1", AddShiftResponse.Physicist1);
        //    addShiftDictionary.Add("Physicist1Notes", AddShiftResponse.Physicist1Notes);
        //    addShiftDictionary.Add("Physicist2", AddShiftResponse.Physicist2);
        //    addShiftDictionary.Add("Physicist2Notes", AddShiftResponse.Physicist2Notes);
        //    addShiftDictionary.Add("PhysicistRSD", AddShiftResponse.PhysicistRSD);

        //    StringBuilder queryString = new StringBuilder();

        //    foreach (var keyValuePair in addShiftDictionary)
        //    {
        //        queryString.Append(keyValuePair.Key + "=" + keyValuePair.Value + "&");
        //    }
        //    queryString.Length--;

        //    return queryString.ToString();
        //}

        protected void FlowrateTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ContaminationLevelTextBox.Text = "";
                TotalAreaSwipedTextBox.Text = "";

                LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100).ToString("0.00");
                LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");

                TotalAirSampledTextBox.Text = (Convert.ToDouble(FlowrateTextBox.Text) * Convert.ToDouble(SamplingTimeTextBox.Text)).ToString();
                AirActivityTextBox.Text = Math.Round((Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(FlowrateTextBox.Text) / Convert.ToDouble(SamplingTimeTextBox.Text) * Convert.ToDouble(AreaCorrectionFactorTextBox.Text) * Convert.ToDouble(DecayCorrectionFactorTextBox.Text)), 3).ToString();
                if (Convert.ToDouble(AirActivityTextBox.Text) >= Convert.ToDouble(LLDTextBox.Text))
                {
                    DACTextBox.ForeColor = Color.Red;
                    AirActivityTextBox.Text = Math.Round((Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(FlowrateTextBox.Text) / Convert.ToDouble(SamplingTimeTextBox.Text) * Convert.ToDouble(AreaCorrectionFactorTextBox.Text) * Convert.ToDouble(DecayCorrectionFactorTextBox.Text)), 3).ToString();
                    DACTextBox.Text = Math.Round((Convert.ToDouble(AirActivityTextBox.Text) / Convert.ToDouble(LivedTextBox.Text)), 2).ToString();
                }
                else
                {
                    DACTextBox.Text = "BDL";
                    DACTextBox.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void BKGCountTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100).ToString("0.00");
                LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");
            }
            catch (Exception ex)
            {
            }
        }

        protected void SampleCountsTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SampleCountsDropDownList.Text == "A")
                {
                    ActivityDropDownList.Enabled = true;
                    TimeofSamplingTextBox.Enabled = true;
                    TimeofCountingTextBox.Enabled = true;
                    ContaminationLevelTextBox.Text = "";
                    RemarksTextBox.Text = "";
                    LLDTextBox.Text = "";
                    MDAdpmTextBox.Text = "";
                    MDABqTextBox.Text = "";
                    LLDBKGTextBox.Text = "";
                    BKGCountsTextBox.Enabled = false;
                    SamplingTimeTextBox.Text = "5";
                    BKGCountTimeTextBox.Text = "1";
                    SampleCountTimeTextBox.Text = "1";
                    AreaCorrectionFactorTextBox.Text = "17.64";
                    HalfLifeTextBox.Text = "20";
                    RemarksTextBox.Text = "";
                    TotalAreaSwipedTextBox.Text = "";
                    LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                    MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(BKGCountTimeTextBox.Text)).ToString("0.00");
                    LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                    MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");
                    NetCountsTextBox.Text = Math.Round(Convert.ToDouble(SampleCountsTextBox.Text) / Convert.ToDouble(SampleCountTimeTextBox.Text) - Convert.ToDouble(BKGCountsTextBox.Text) / (Convert.ToDouble(BKGCountTimeTextBox.Text)), 2).ToString();
                    AerosolDropDownList.Enabled = true;
                    LivedTextBox.Enabled = true;
                    ActivityDropDownList.Enabled = true;
                    ElapsedTimeTextBox.Enabled = true;
                    HalfLifeTextBox.Enabled = true;
                    FlowrateTextBox.Enabled = true;
                    DecayCorrectionFactorTextBox.Enabled = true;
                    AreaCorrectionFactorTextBox.Enabled = true;
                    SamplingTimeTextBox.Enabled = true;
                    TotalAirSampledTextBox.Enabled = true;
                    AirActivityTextBox.Enabled = true;
                    DACTextBox.Enabled = true;
                }
                else if (SampleCountsDropDownList.Text == "S")
                {
                    ActivityDropDownList.Text = "";
                    AerosolDropDownList.Enabled = false;
                    LivedTextBox.Enabled = false;
                    ActivityDropDownList.Enabled = false;
                    TimeofSamplingTextBox.Enabled = false;
                    TimeofCountingTextBox.Enabled = false;
                    ElapsedTimeTextBox.Enabled = false;
                    HalfLifeTextBox.Enabled = false;
                    FlowrateTextBox.Enabled = false;
                    DecayCorrectionFactorTextBox.Enabled = false;
                    AreaCorrectionFactorTextBox.Enabled = false;
                    SamplingTimeTextBox.Enabled = false;
                    TotalAirSampledTextBox.Enabled = false;
                    AirActivityTextBox.Enabled = false;
                    DACTextBox.Enabled = false;
                    BKGCountsTextBox.Enabled = false;
                    // TotalAreaSwipedTextBox.Text = 100
                    BKGCountTimeTextBox.Text = "1";
                    SampleCountTimeTextBox.Text = "1";
                    // ActivityDropDownList.Text = ""
                    RemarksTextBox.Text = "";
                    SamplingTimeTextBox.Text = "";
                    DACTextBox.Text = "";
                    AirActivityTextBox.Text = "";
                    FlowrateTextBox.Text = "";
                    TimeofSamplingTextBox.Text = "";
                    TimeofCountingTextBox.Text = "";
                    SamplingTimeTextBox.Text = "";
                    DecayCorrectionFactorTextBox.Text = "";
                    FlowrateTextBox.Text = "";
                    TotalAirSampledTextBox.Text = "";
                    AirActivityTextBox.Text = "";
                    DACTextBox.Text = "";
                    LivedTextBox.Text = "";
                    AerosolDropDownList.Text = "";
                    AreaCorrectionFactorTextBox.Text = "";
                    ElapsedTimeTextBox.Text = "";
                    HalfLifeTextBox.Text = "";
                    NetCountsTextBox.Text = "";
                    RemarksTextBox.Text = "";

                    // TotalAreaSwipedTextBox.Text = 100

                    NetCountsTextBox.Text = Math.Round((Convert.ToDouble(SampleCountsTextBox.Text) / Convert.ToDouble(SampleCountTimeTextBox.Text) - Convert.ToDouble(BKGCountsTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text)), 2).ToString();
                    ContaminationLevelTextBox.Text = Math.Round(Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(TotalAreaSwipedTextBox.Text), 2).ToString();
                    if (Convert.ToDouble(SampleCountsTextBox.Text) >= Convert.ToDouble(LLDBKGTextBox.Text))
                        ContaminationLevelTextBox.ForeColor = Color.Red;
                    else
                    {
                        ContaminationLevelTextBox.Text = "BDL";
                        ContaminationLevelTextBox.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //StatusDropDownList.Items.Clear();

                string s17;

                s17 = "update new_cdms set counting_system='" + CountingSystemDropDownList.Text.ChangeNull() + "',counter_efficiency='" + CounterEfficiencyTextBox.Text.ChangeNull() + "',as_on='"
                    + AsON.Text.ChangeNull() + "',  rack_number='" + RackDropDownList.Text.ChangeNull() + "',Room_No='" + LocationUnitDropDownList.Text.ChangeNull()
                    + "',smear_airsample='" + SmearDropDownList.Text.ChangeNull() + "',aerosol_iodine='" + AerosolDropDownList.Text.ChangeNull() + "',time_ofsampling='"
                    + TimeofSamplingTextBox.Text.ChangeNull() + "',time_ofcounting='" + TimeofCountingTextBox.Text.ChangeNull() + "',Elapsed_time='" + ElapsedTimeTextBox.Text.ChangeNull()
                    + "',Area_correctionfactor='" + AreaCorrectionFactorTextBox.Text.ChangeNull() + "',Decay_correctionfactor='" + DecayCorrectionFactorTextBox.Text.ChangeNull()
                    + "',halflife='" + HalfLifeTextBox.Text.ChangeNull() + "',flowrate='" + FlowrateTextBox.Text.ChangeNull() + "',sampling_time='" + SamplingTimeTextBox.Text.ChangeNull()
                    + "',total_airsampled='" + TotalAirSampledTextBox.Text.ChangeNull() + "',Bkg_counttime='" + BKGCountTimeTextBox.Text.ChangeNull() + "',Sample_counttime='"
                    + SampleCountTimeTextBox.Text.ChangeNull() + "',bkg_counts='" + BKGCountsTextBox.Text.ChangeNull() + "',gross_counts='" + SampleCountsTextBox.Text.ChangeNull() + "',net_counts='"
                    + NetCountsTextBox.Text.ChangeNull() + "',Total_areaswiped='" + TotalAreaSwipedTextBox.Text.ChangeNull() + "',contamination_level='" + ContaminationLevelTextBox.Text.ChangeNull()
                    + "',activity='" + AirActivityTextBox.Text.ChangeNull() + "',air_activity='" + DACTextBox.Text.ChangeNull() + "',Shift_Technician='" + AddShiftResponse.ShiftTechnician.ChangeNull() + "',remarks='"
                    + RemarksTextBox.Text.ChangeNull() + "', unit=" + UnitDropDownList.Text.ChangeNull() + ",status='" + SampleDescriptionDropDownList.Text.ChangeNull() + "',LLD='" + LLDTextBox.Text.ChangeNull() + "',MDA_dpm='"
                    + MDAdpmTextBox.Text.ChangeNull() + "',MDA_Bq='" + MDABqTextBox.Text.ChangeNull() + "',LLD_Bkg='" + LLDBKGTextBox.Text.ChangeNull() + "',Lived='" + LivedTextBox.Text + "',efficiency_unit="
                    + LocationUnitDropDownList.Text.ChangeNull() + ",current_shift='" + AddShiftResponse.Shift.ChangeNull() + "',crew='" + AddShiftResponse.Crew.ChangeNull() + "', SHP='" + AddShiftResponse.Physicist1.ChangeNull()
                    + "',SHP_Comments='" + AddShiftResponse.Physicist1Notes.ChangeNull() + "',Review_Officer='" + AddShiftResponse.Physicist1.ChangeNull() + "',Review_Comments='" + AddShiftResponse.Physicist1Notes
                    + "',Contract_Staff1='" + AddShiftResponse.ContractStaff1.ChangeNull() + "',Contract_Staff2='" + AddShiftResponse.ContractStaff2.ChangeNull() + "',Contract_Staff3='"
                    + AddShiftResponse.ContractStaff3.ChangeNull() + "',SHP1='" + AddShiftResponse.Physicist2 + "',SHP1_Comments='" + AddShiftResponse.Physicist2Notes.ChangeNull() + "',Location='"
                    + LocationUnitDropDownList.Text.ChangeNull() + "',Approved_Comments='" + "comment" + "',Plant_Status='" + PlantStatusDropDownList.Text.ChangeNull() + "',SHP2='" + AddShiftResponse.PhysicistRSD.ChangeNull()
                    + "',Material_ID='" + MaterialIdTextBox.Text.ChangeNull() + "',Contamination_Date='" + ContaminationDateTextBox.Text.ChangeNull()
                    + "',Requested_By='" + RequestedByTextBox.Text.ChangeNull() + "',Location_From='" + LocationFromDropDownList.Text.ChangeNull() + "',Location_To='" + LocationToDropDownList.Text.ChangeNull() + "',Purpose='"
                    + PurposeDropDownList.Text.ChangeNull() + "',Instrument_Location='" + InstrumentLocationDropDownList.Text.ChangeNull() + "',T2_Technician='" + AddShiftResponse.T2Technician.ChangeNull() + "',Material_Countedby='"
                    + MaterialCountedByDropDownList.Text.ChangeNull() + "'   where sl_no=" + SearchDropDownList.Text + "";

                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand cmd17 = new MySqlCommand(s17, connection);
                cmd17.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('Record Updated');", true);

                //StatusDropDownList.Items.Add("R");
                //StatusDropDownList.Items.Add("N");
                //StatusDropDownList.Items.Add("O");
                //StatusDropDownList.Items.Add("M");
                //StatusDropDownList.Items.Add("Radeye-B20");
                //StatusDropDownList.Items.Add("NRP");

                //ContaminationDateTextBox.Enabled = true;
                //cmd_view.Enabled = true;
                connection.Close();

                SaveButton.Visible = false;
                EditButton.Visible = true;
                InitialAddRecord.Visible = true;
                AddRecordButton.Visible = false;
                //AddShiftButton.Visible = false;

                DataEntryPanel.Enabled = false;
                BGCPanel.Enabled = false;
                MaterialPanel.Enabled = false;
                BottomPanel.Enabled = false;

                //AddShiftButton.Text = "Add Shift";

            }
            catch (Exception ex)
            {
            }
        }

        protected void SampleCountTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // TotalAreaSwipedTextBox.Text = 100
                NetCountsTextBox.Text = Math.Round((Convert.ToDouble(SampleCountsTextBox.Text) / Convert.ToDouble(SampleCountTimeTextBox.Text) - Convert.ToDouble(BKGCountsTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text)), 2).ToString();
                ContaminationLevelTextBox.Text = Math.Round((Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(TotalAreaSwipedTextBox.Text)), 2).ToString();
                TotalAirSampledTextBox.Text = "";
                if (Convert.ToDouble(SampleCountsTextBox.Text) >= Convert.ToDouble(LLDBKGTextBox.Text))
                    ContaminationLevelTextBox.ForeColor = Color.Red;
                else
                {
                    ContaminationLevelTextBox.Text = "BDL";
                    ContaminationLevelTextBox.ForeColor = Color.Green;
                }

                AirActivityTextBox.Text = Math.Round((Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(FlowrateTextBox.Text) / Convert.ToDouble(SamplingTimeTextBox.Text) * Convert.ToDouble(AreaCorrectionFactorTextBox.Text) * Convert.ToDouble(DecayCorrectionFactorTextBox.Text)), 3).ToString();
                if (Convert.ToDouble(AirActivityTextBox.Text) >= Convert.ToDouble(LLDTextBox.Text))
                {
                    DACTextBox.ForeColor = Color.Red;
                    AirActivityTextBox.Text = Math.Round((Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(FlowrateTextBox.Text) / Convert.ToDouble(SamplingTimeTextBox.Text) * Convert.ToDouble(AreaCorrectionFactorTextBox.Text) * Convert.ToDouble(DecayCorrectionFactorTextBox.Text)), 3).ToString();
                    DACTextBox.Text = Math.Round((Convert.ToDouble(AirActivityTextBox.Text) / Convert.ToDouble(LivedTextBox.Text)), 2).ToString();
                }
                else
                {
                    DACTextBox.Text = "BDL";
                    DACTextBox.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void ActivityDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ActivityDropDownList.SelectedIndex == 0)
                {
                    TimeofSamplingTextBox.Enabled = true;
                    TimeofCountingTextBox.Enabled = true;
                    LivedTextBox.Text = "2000";
                    DACTextBox.Text = (Convert.ToDouble(AirActivityTextBox.Text) / (double)2000).ToString("0.000");
                }
                else if (ActivityDropDownList.SelectedIndex == 1)
                {
                    TimeofSamplingTextBox.Text = DateTime.Now.ToString("HH:mm");
                    TimeofCountingTextBox.Text = DateTime.Now.ToString("HH:mm");
                    TimeofSamplingTextBox.Enabled = false;
                    TimeofCountingTextBox.Enabled = false;
                    LivedTextBox.Text = "60";
                    DACTextBox.Text = (Convert.ToDouble(AirActivityTextBox.Text) / (double)60).ToString("0.000");

                    TotalAirSampledTextBox.Text = (Convert.ToDouble(FlowrateTextBox.Text) * Convert.ToDouble(SamplingTimeTextBox.Text)).ToString();
                    AirActivityTextBox.Text = Math.Round((Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(FlowrateTextBox.Text) / Convert.ToDouble(SamplingTimeTextBox.Text) * Convert.ToDouble(AreaCorrectionFactorTextBox.Text) * Convert.ToDouble(DecayCorrectionFactorTextBox.Text)), 3).ToString();
                    if (Convert.ToDouble(AirActivityTextBox.Text) >= Convert.ToDouble(LLDTextBox.Text))
                    {
                        DACTextBox.ForeColor = Color.Red;
                        AirActivityTextBox.Text = Math.Round((Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(FlowrateTextBox.Text) / Convert.ToDouble(SamplingTimeTextBox.Text) * Convert.ToDouble(AreaCorrectionFactorTextBox.Text) * Convert.ToDouble(DecayCorrectionFactorTextBox.Text)), 3).ToString();
                        DACTextBox.Text = Math.Round((Convert.ToDouble(AirActivityTextBox.Text) / Convert.ToDouble(LivedTextBox.Text)), 2).ToString();
                    }
                    else
                    {
                        DACTextBox.Text = "BDL";
                        DACTextBox.ForeColor = Color.Green;
                    }

                    ContaminationLevelTextBox.Text = "";
                    TotalAreaSwipedTextBox.Text = "";
                    LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                    MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100).ToString("0.00");
                    LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                    MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void BKGCountsTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100).ToString("0.00");
                LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");
            }
            catch (Exception ex)
            {
            }
        }

        private void Search(int searchId)
        {
            StatusDropDownList.Items.Clear();
            string sz;
            sz = "select * from new_cdms where sl_no=" + searchId + "";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand cmdz = new MySqlCommand(sz, connection);
            MySqlDataReader rs1z;
            rs1z = cmdz.ExecuteReader();
            rs1z.Read();
            AddShiftModel fetchedShiftModel = new AddShiftModel();
            SearchDropDownList.Text = (rs1z.IsDBNull(0) ? null : rs1z.GetInt32(0).ToString());
            fetchedShiftModel.Date = (rs1z.IsDBNull(1) ? null : rs1z.GetDateTime(1).ToString("yyyy-MM-dd"));
            LocationUnitDropDownList.Text = (rs1z.IsDBNull(36) ? null : rs1z.GetInt32(36).ToString());
            LocationUnitDropDownList_SelectedIndexChanged(null, new EventArgs() { });
            //LoadCountingSystem();
            CountingSystemDropDownList.Text = (rs1z.IsDBNull(2) ? null : rs1z.GetString(2));
            CounterEfficiencyTextBox.Text = (rs1z.IsDBNull(3) ? null : rs1z.GetString(3));
            AsON.Text = (rs1z.IsDBNull(4) ? null : rs1z.GetDateTime(4).ToString("yyyy-MM-dd"));
            RackDropDownList.Items.Clear();
            RackDropDownList.Items.Add(rs1z.IsDBNull(5) ? string.Empty : rs1z.GetString(5));
            //RackDropDownList.Text = (rs1z.IsDBNull(5) ? null : rs1z.GetString(5));
            //SampleDescriptionDropDownList.Text = (rs1z.IsDBNull(6) ? null : rs1z.GetString(6));
            var sd = (rs1z.IsDBNull(6) ? null : rs1z.GetString(6));
            SmearDropDownList.Text = (rs1z.IsDBNull(7) ? null : rs1z.GetString(7));
            AerosolDropDownList.Text = (rs1z.IsDBNull(8) ? null : rs1z.GetString(8));
            TimeofSamplingTextBox.Text = (rs1z.IsDBNull(9) ? null : rs1z.GetString(9));
            TimeofCountingTextBox.Text = (rs1z.IsDBNull(10) ? null : rs1z.GetString(10));
            ElapsedTimeTextBox.Text = (rs1z.IsDBNull(11) ? null : rs1z.GetString(11));
            AreaCorrectionFactorTextBox.Text = (rs1z.IsDBNull(12) ? null : rs1z.GetString(12));
            DecayCorrectionFactorTextBox.Text = (rs1z.IsDBNull(13) ? null : rs1z.GetString(13));
            HalfLifeTextBox.Text = (rs1z.IsDBNull(14) ? null : rs1z.GetString(14));
            FlowrateTextBox.Text = (rs1z.IsDBNull(15) ? null : rs1z.GetString(15));
            SamplingTimeTextBox.Text = (rs1z.IsDBNull(16) ? null : rs1z.GetString(16));
            TotalAirSampledTextBox.Text = (rs1z.IsDBNull(17) ? null : rs1z.GetString(17));
            BKGCountTimeTextBox.Text = (rs1z.IsDBNull(18) ? null : rs1z.GetString(18));
            SampleCountTimeTextBox.Text = (rs1z.IsDBNull(19) ? null : rs1z.GetString(19));
            BKGCountsTextBox.Text = (rs1z.IsDBNull(20) ? null : rs1z.GetString(20));
            SampleCountsTextBox.Text = (rs1z.IsDBNull(21) ? null : rs1z.GetString(21));
            NetCountsTextBox.Text = (rs1z.IsDBNull(22) ? null : rs1z.GetString(22));
            TotalAreaSwipedTextBox.Text = (rs1z.IsDBNull(23) ? null : rs1z.GetString(23));
            ContaminationLevelTextBox.Text = (rs1z.IsDBNull(24) ? null : rs1z.GetString(24));
            AirActivityTextBox.Text = (rs1z.IsDBNull(25) ? null : rs1z.GetString(25));
            DACTextBox.Text = (rs1z.IsDBNull(26) ? null : rs1z.GetString(26));
            fetchedShiftModel.ShiftTechnician = (rs1z.IsDBNull(27) ? null : rs1z.GetString(27));
            RemarksTextBox.Text = (rs1z.IsDBNull(28) ? null : rs1z.GetString(28));
            UnitDropDownList.Text = (rs1z.IsDBNull(29) ? null : rs1z.GetInt32(29).ToString());
            //StatusDropDownList.Text = (rs1z.IsDBNull(30) ? null : rs1z.GetString(30));
            var status = (rs1z.IsDBNull(30) ? null : rs1z.GetString(30));
            LLDTextBox.Text = (rs1z.IsDBNull(31) ? null : rs1z.GetString(31));
            MDAdpmTextBox.Text = (rs1z.IsDBNull(32) ? null : rs1z.GetString(32));
            MDABqTextBox.Text = (rs1z.IsDBNull(33) ? null : rs1z.GetString(33));
            LLDBKGTextBox.Text = (rs1z.IsDBNull(34) ? null : rs1z.GetString(34));
            LivedTextBox.Text = (rs1z.IsDBNull(35) ? null : rs1z.GetString(35));
            //LocationUnitDropDownList.Text = (rs1z.IsDBNull(36) ? null : rs1z.GetInt32(36).ToString());
            fetchedShiftModel.Shift = (rs1z.IsDBNull(37) ? null : rs1z.GetString(37));
            fetchedShiftModel.Crew = (rs1z.IsDBNull(38) ? null : rs1z.GetString(38));
            fetchedShiftModel.Physicist1 = (rs1z.IsDBNull(39) ? null : rs1z.GetString(39));
            fetchedShiftModel.Physicist1Notes = (rs1z.IsDBNull(40) ? null : rs1z.GetString(40));
            fetchedShiftModel.Physicist1 = (rs1z.IsDBNull(41) ? null : rs1z.GetString(41));
            fetchedShiftModel.Physicist1Notes = (rs1z.IsDBNull(42) ? null : rs1z.GetString(42));
            fetchedShiftModel.ContractStaff1 = (rs1z.IsDBNull(43) ? null : rs1z.GetString(43));
            fetchedShiftModel.ContractStaff2 = (rs1z.IsDBNull(44) ? null : rs1z.GetString(44));
            fetchedShiftModel.ContractStaff3 = (rs1z.IsDBNull(45) ? null : rs1z.GetString(45));
            fetchedShiftModel.Physicist2 = (rs1z.IsDBNull(46) ? null : rs1z.GetString(46));
            fetchedShiftModel.Physicist2Notes = (rs1z.IsDBNull(47) ? null : rs1z.GetString(47));
            //BuildingTextBox.Text = (rs1z.IsDBNull(48) ? null : rs1z.GetString(48));
            //TextBox30.Text = (rs1z.IsDBNull(49) ? null : rs1z.GetString(49));
            PlantStatusDropDownList.Text = (rs1z.IsDBNull(50) ? null : rs1z.GetString(50));
            fetchedShiftModel.PhysicistRSD = (rs1z.IsDBNull(51) ? null : rs1z.GetString(51));
            MaterialIdTextBox.Text = (rs1z.IsDBNull(52) ? null : rs1z.GetInt32(52).ToString());
            ContaminationDateTextBox.Text = (rs1z.IsDBNull(53) ? null : rs1z.GetDateTime(53).ToString());
            //Login.username.Text = (rs1z.IsDBNull(54) ? null : rs1z.GetString(54));
            RequestedByTextBox.Text = (rs1z.IsDBNull(55) ? null : rs1z.GetString(55));
            LocationFromDropDownList.Text = (rs1z.IsDBNull(56) ? null : rs1z.GetString(56));
            LocationToDropDownList.Text = (rs1z.IsDBNull(57) ? null : rs1z.GetString(57));
            PurposeDropDownList.Text = (rs1z.IsDBNull(58) ? null : rs1z.GetString(58));
            InstrumentLocationDropDownList.Items.Clear();
            InstrumentLocationDropDownList.Items.Add(rs1z.IsDBNull(59) ? string.Empty : rs1z.GetString(59));
            //InstrumentLocationDropDownList.Text = (rs1z.IsDBNull(59) ? null : rs1z.GetString(59));
            fetchedShiftModel.T2Technician = (rs1z.IsDBNull(60) ? null : rs1z.GetString(60));
            MaterialCountedByDropDownList.Text = (rs1z.IsDBNull(61) ? null : rs1z.GetString(61));

            AddShiftResponse = fetchedShiftModel;

            StatusDropDownList.Items.Clear();
            StatusDropDownList.Items.Add("R");
            StatusDropDownList.Items.Add("N");
            StatusDropDownList.Items.Add("O");
            StatusDropDownList.Items.Add("M");
            StatusDropDownList.Items.Add("Radeye-B20");

            ContaminationDateTextBox.Visible = true;
            UnitDropDownList.Enabled = true;
            //Label2.Visible = true;
            //Label64.Visible = false;
            BuildingTextBox.Visible = false;
            //Label5.Visible = false;
            ContaminationDateTextBox.Enabled = true;
            rs1z.Close();


            SampleDescriptionDropDownList.Items.Clear();
            if (StatusDropDownList.Text == "R")
            {
                string s21;
                s21 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                MySqlCommand cmd21 = new MySqlCommand(s21, connection);
                MySqlDataReader rs21;
                rs21 = cmd21.ExecuteReader();
                while ((rs21.Read()))
                {
                    SampleDescriptionDropDownList.Items.Add(rs21["Room_No"].ToString());
                    //TextBox31.Visible = false;
                    //Label64.Visible = false;
                    //Label40.Visible = false;
                    //TextBox34.Visible = false;
                    //Label52.Visible = false;
                    //ComboBox23.Visible = false;
                    //Label49.Visible = false;
                    //ComboBox24.Visible = false;
                    //Label53.Visible = false;
                    //ComboBox20.Visible = false;
                    //Label62.Visible = false;
                    //ComboBox25.Visible = false;
                    //Label69.Visible = false;
                }
                rs21.Close();
            }
            if (StatusDropDownList.Text == "N")
            {
                string s22;
                s22 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                MySqlCommand cmd22 = new MySqlCommand(s22, connection);
                MySqlDataReader rs22;
                rs22 = cmd22.ExecuteReader();
                while ((rs22.Read()))
                {
                    SampleDescriptionDropDownList.Items.Add(rs22["Room_No"].ToString());
                    //TextBox31.Visible = false;
                    //Label64.Visible = false;
                    //Label40.Visible = false;
                    //TextBox34.Visible = false;
                    //Label52.Visible = false;
                    //ComboBox23.Visible = false;
                    //Label49.Visible = false;
                    //ComboBox24.Visible = false;
                    //Label53.Visible = false;
                    //ComboBox20.Visible = false;
                    //Label62.Visible = false;
                    //ComboBox25.Visible = false;
                    //Label69.Visible = false;
                }
                rs22.Close();
            }
            if (StatusDropDownList.Text == "O")
            {
                string s23;
                s23 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                MySqlCommand cmd23 = new MySqlCommand(s23, connection);
                MySqlDataReader rs23;
                rs23 = cmd23.ExecuteReader();
                while ((rs23.Read()))
                {
                    SampleDescriptionDropDownList.Items.Add(rs23["Room_No"].ToString());
                    //TextBox31.Visible = false;
                    //Label64.Visible = false;
                    //Label40.Visible = false;
                    //TextBox34.Visible = false;
                    //Label52.Visible = false;
                    //ComboBox23.Visible = false;
                    //Label49.Visible = false;
                    //ComboBox24.Visible = false;
                    //Label53.Visible = false;
                    //ComboBox20.Visible = false;
                    //Label62.Visible = false;
                    //ComboBox25.Visible = false;
                    //Label69.Visible = false;
                }
                rs23.Close();
            }

            if (StatusDropDownList.Text == "Radeye-B20")
            {
                string ss;
                ss = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                MySqlCommand cm = new MySqlCommand(ss, connection);
                MySqlDataReader r;
                r = cm.ExecuteReader();
                while ((r.Read()))
                {
                    SampleDescriptionDropDownList.Items.Add(r["Room_No"].ToString());
                    //TextBox31.Visible = false;
                    //Label64.Visible = false;
                    //Label40.Visible = false;
                    //TextBox34.Visible = false;
                    //Label52.Visible = false;
                    //ComboBox23.Visible = false;
                    //Label49.Visible = false;
                    //ComboBox24.Visible = false;
                    //Label53.Visible = false;
                    //ComboBox20.Visible = false;
                    //Label62.Visible = true;
                    //ComboBox25.Visible = true;
                    //TableLayoutPanel3.Visible = true;
                    //Label69.Visible = true;
                }
                r.Close();
            }



            if (StatusDropDownList.Text == "M")
            {
                string s24;
                s24 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                MySqlCommand cmd24 = new MySqlCommand(s24, connection);
                MySqlDataReader rs24;
                rs24 = cmd24.ExecuteReader();
                while ((rs24.Read()))
                {
                    SampleDescriptionDropDownList.Items.Add(rs24["Room_No"].ToString());
                    //TextBox31.Visible = true;
                    //Label64.Visible = true;
                    //Label49.Visible = true;
                    //Label40.Visible = true;
                    //Label52.Visible = true;
                    //Label53.Visible = true;
                    //TextBox34.Visible = true;
                    //ComboBox23.Visible = true;
                    //ComboBox24.Visible = true;
                    //ComboBox20.Visible = true;
                    //Label62.Visible = true;
                    //ComboBox25.Visible = true;
                    //TableLayoutPanel3.Visible = true;
                    //Label69.Visible = true;
                }
                rs24.Close();
            }
            if (StatusDropDownList.Text == "NRP")
            {
                string s244;
                s244 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                MySqlCommand cmd244 = new MySqlCommand(s244, connection);
                MySqlDataReader rs244;
                rs244 = cmd244.ExecuteReader();
                while ((rs244.Read()))
                {
                    SampleDescriptionDropDownList.Items.Add(rs244["Room_No"].ToString());
                    //TextBox31.Visible = true;
                    //TextBox31.Text = "NRP";
                    //Label64.Visible = true;
                    //Label49.Visible = true;
                    //Label40.Visible = true;
                    //Label52.Visible = true;
                    //Label53.Visible = true;
                    //TextBox34.Visible = true;
                    //ComboBox23.Visible = true;
                    //ComboBox24.Visible = true;
                    //ComboBox20.Visible = true;
                    //Label62.Visible = true;
                    //ComboBox25.Visible = true;
                    //TableLayoutPanel3.Visible = true;
                    //Label69.Visible = true;
                }
                rs244.Close();

                //if (Login.username.Text == "lingadurai.g" | Login.username.Text == "siva.m" | Login.username.Text == "saravanan.k" | Login.username.Text == "sundar.s")
                //{
                //    GroupBox8.Enabled = true;
                //    cmd_view.Enabled = true;
                //    cmd_delete.Enabled = true;
                //    cmd_edit.Enabled = true;
                //    cmd_add.Enabled = true;
                //}
                //else
                //{
                //    GroupBox8.Enabled = true;
                //    cmd_view.Enabled = true;

                //    cmd_add.Enabled = false;


                //    LLDTextBox.Text = Round(Sqrt(BKGCountsTextBox.Text * SampleCountTimeTextBox.Text * (1 + SampleCountTimeTextBox.Text / (double)BKGCountTimeTextBox.Text)) * 3.29 + 3, 2);
                //    MDAdpmTextBox.Text = Format(LLDTextBox.Text / (double)CounterEfficiencyTextBox.Text * 100 / (double)BKGCountTimeTextBox.Text, "0.00");
                //    LLDBKGTextBox.Text = Val(LLDTextBox.Text) + Val(BKGCountsTextBox.Text);
                //    MDABqTextBox.Text = Format(MDAdpmTextBox.Text / (double)60, "0.00");
                //}
                connection.Close();
            }

            StatusDropDownList.Text = status;
            SampleDescriptionDropDownList.Text = sd;

        }



        private void Delete()
        {
            try
            {
                StatusDropDownList.Items.Clear();

                string s20;
                MySqlCommand cmd20 = new MySqlCommand();
                s20 = "Delete from new_cdms where Sl_no=" + SearchDropDownList.Text + "";
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand cmd19 = new MySqlCommand(s20, connection);
                cmd19.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('Deleted');", true);

                SearchDropDownList.Items.Clear();
                string s1;
                s1 = "select sl_no from new_cdms order by sl_no";
                MySqlCommand cmd1 = new MySqlCommand(s1, connection);
                MySqlDataReader rs1;
                rs1 = cmd1.ExecuteReader();
                while ((rs1.Read()))
                    SearchDropDownList.Items.Add(rs1["sl_no"].ToString());
                StatusDropDownList.Items.Add("R");
                StatusDropDownList.Items.Add("N");
                StatusDropDownList.Items.Add("O");
                StatusDropDownList.Items.Add("M");
                StatusDropDownList.Items.Add("Radeye-B20");
                StatusDropDownList.Items.Add("NRP");

                rs1.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
            }
        }

        protected void UnitDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StatusDropDownList.Items.Clear();

                string s20;
                s20 = "select distinct Status from new_cdms where unit=" + UnitDropDownList.Text + "";
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand cmd20 = new MySqlCommand(s20, connection);
                MySqlDataReader rs20;
                rs20 = cmd20.ExecuteReader();
                while ((rs20.Read()))
                    StatusDropDownList.Items.Add(rs20["status"].ToString());
                rs20.Close();
                connection.Close();
            }

            catch (Exception ex)
            {
            }
        }

        protected void StatusDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SampleDescriptionDropDownList.Items.Clear();
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                if (StatusDropDownList.Text == "R")
                {
                    string s21;
                    s21 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";

                    MySqlCommand cmd21 = new MySqlCommand(s21, connection);
                    MySqlDataReader rs21;
                    rs21 = cmd21.ExecuteReader();
                    while ((rs21.Read()))
                    {
                        SampleDescriptionDropDownList.Items.Add(rs21["Room_No"].ToString());
                        //TextBox31.Visible = false;
                        //Label64.Visible = false;
                        //Label40.Visible = false;
                        //TextBox34.Visible = false;
                        //Label52.Visible = false;
                        //ComboBox23.Visible = false;
                        //Label49.Visible = false;
                        //ComboBox24.Visible = false;
                        //Label53.Visible = false;
                        //ComboBox20.Visible = false;
                        //Label62.Visible = false;
                        //ComboBox25.Visible = false;
                        //Label69.Visible = false;
                    }
                    rs21.Close();

                    MaterialPanel.Visible = false;
                }
                if (StatusDropDownList.Text == "N")
                {
                    string s22;
                    s22 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                    MySqlCommand cmd22 = new MySqlCommand(s22, connection);
                    MySqlDataReader rs22;
                    rs22 = cmd22.ExecuteReader();
                    while ((rs22.Read()))
                    {
                        SampleDescriptionDropDownList.Items.Add(rs22["Room_No"].ToString());
                        //TextBox31.Visible = false;
                        //Label64.Visible = false;
                        //Label40.Visible = false;
                        //TextBox34.Visible = false;
                        //Label52.Visible = false;
                        //ComboBox23.Visible = false;
                        //Label49.Visible = false;
                        //ComboBox24.Visible = false;
                        //Label53.Visible = false;
                        //ComboBox20.Visible = false;
                        //Label62.Visible = false;
                        //ComboBox25.Visible = false;
                        //Label69.Visible = false;
                    }
                    rs22.Close();

                    MaterialPanel.Visible = false;
                }
                if (StatusDropDownList.Text == "O")
                {
                    string s23;
                    s23 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                    MySqlCommand cmd23 = new MySqlCommand(s23, connection);
                    MySqlDataReader rs23;
                    rs23 = cmd23.ExecuteReader();
                    while ((rs23.Read()))
                    {
                        SampleDescriptionDropDownList.Items.Add(rs23["Room_No"].ToString());
                        //TextBox31.Visible = false;
                        //Label64.Visible = false;
                        //Label40.Visible = false;
                        //TextBox34.Visible = false;
                        //Label52.Visible = false;
                        //ComboBox23.Visible = false;
                        //Label49.Visible = false;
                        //ComboBox24.Visible = false;
                        //Label53.Visible = false;
                        //ComboBox20.Visible = false;
                        //Label62.Visible = false;
                        //ComboBox25.Visible = false;
                        //Label69.Visible = false;
                    }
                    rs23.Close();

                    MaterialPanel.Visible = false; ;
                }

                if (StatusDropDownList.Text == "M")
                {
                    string s24;
                    s24 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                    MySqlCommand cmd24 = new MySqlCommand(s24, connection);
                    MySqlDataReader rs24;
                    rs24 = cmd24.ExecuteReader();
                    while ((rs24.Read()))
                    {
                        SampleDescriptionDropDownList.Items.Add(rs24["Room_No"].ToString());
                        //TextBox31.Visible = true;
                        //Label64.Visible = true;
                        //Label49.Visible = true;
                        //Label40.Visible = true;
                        //Label52.Visible = true;
                        //Label53.Visible = true;
                        //TextBox34.Visible = true;
                        //ComboBox23.Visible = true;
                        //ComboBox24.Visible = true;
                        //ComboBox20.Visible = true;
                        //Label62.Visible = true;
                        //ComboBox25.Visible = true;
                        //TableLayoutPanel3.Visible = true;
                        //Label69.Visible = true;
                    }
                    rs24.Close();

                    MaterialPanel.Visible = true;
                }

                if (StatusDropDownList.Text == "NRP")
                {
                    string s245;
                    s245 = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                    MySqlCommand cmd245 = new MySqlCommand(s245, connection);
                    MySqlDataReader rs245;
                    rs245 = cmd245.ExecuteReader();
                    while ((rs245.Read()))
                    {
                        SampleDescriptionDropDownList.Items.Add(rs245["Room_No"].ToString());
                        //TextBox31.Visible = true;
                        //TextBox31.Text = "NRP";
                        //Label64.Visible = true;
                        //Label49.Visible = true;
                        //Label40.Visible = true;
                        //Label52.Visible = true;
                        //Label53.Visible = true;
                        //TextBox34.Visible = true;
                        //ComboBox23.Visible = true;
                        //ComboBox24.Visible = true;
                        //ComboBox20.Visible = true;
                        //Label62.Visible = true;
                        //ComboBox25.Visible = true;
                        //TableLayoutPanel3.Visible = true;
                        //Label69.Visible = true;
                    }
                    rs245.Close();

                    MaterialPanel.Visible = true;
                }

                if (StatusDropDownList.Text == "Radeye-B20")
                {
                    string ss;
                    ss = "select distinct Room_No from new_cdms where  status='" + StatusDropDownList.Text + "'  and unit=" + UnitDropDownList.Text + " ";
                    MySqlCommand cm = new MySqlCommand(ss, connection);
                    MySqlDataReader r;
                    r = cm.ExecuteReader();
                    while ((r.Read()))
                    {
                        SampleDescriptionDropDownList.Items.Add(r["Room_No"].ToString());
                        //TextBox31.Visible = false;
                        //Label64.Visible = false;
                        //Label40.Visible = false;
                        //TextBox34.Visible = false;
                        //Label52.Visible = false;
                        //ComboBox23.Visible = false;
                        //Label49.Visible = false;
                        //ComboBox24.Visible = false;
                        //Label53.Visible = false;
                        //ComboBox20.Visible = false;
                        //Label62.Visible = true;
                        //ComboBox25.Visible = true;
                        //TableLayoutPanel3.Visible = true;
                        //Label69.Visible = true;
                    }
                    r.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void LocationUnitDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CountingSystemDropDownList.Items.Clear();
                RackDropDownList.Items.Clear();
                InstrumentLocationDropDownList.Items.Clear();
                CounterEfficiencyTextBox.Text = "";
                BKGCountsTextBox.Text = "";
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                string s22;
                s22 = "select distinct counting_instrument from eff where unit=" + LocationUnitDropDownList.Text + "";
                MySqlCommand cmd25 = new MySqlCommand(s22, connection);
                MySqlDataReader rs22;
                rs22 = cmd25.ExecuteReader();
                while ((rs22.Read()))

                    CountingSystemDropDownList.Items.Add(rs22["counting_instrument"].ToString());

                rs22.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void CountingSystemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RackDropDownList.Items.Clear();
                InstrumentLocationDropDownList.Items.Clear();
                CounterEfficiencyTextBox.Text = "";
                BKGCountsTextBox.Text = "";
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                string s23;
                s23 = "select distinct rack_no,instrument_location from eff where unit=" + LocationUnitDropDownList.Text + " and counting_instrument='" + CountingSystemDropDownList.Text + "' order by rack_no asc";
                MySqlCommand cmd23 = new MySqlCommand(s23, connection);
                MySqlDataReader rs23;
                rs23 = cmd23.ExecuteReader();
                bool isFirstRecord = true;
                while ((rs23.Read()))
                {
                    RackDropDownList.Items.Add(rs23["rack_no"].ToString());

                    if (isFirstRecord)
                    {
                        InstrumentLocationDropDownList.Items.Add(rs23["instrument_location"].ToString());
                        isFirstRecord = false;
                    }
                }

                rs23.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void RackDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                string s23;
                s23 = "select distinct efficiency,bkg_counts,rack_no from eff where counting_instrument='" + CountingSystemDropDownList.Text + "' and rack_no='" + RackDropDownList.Text + "'";
                MySqlCommand cmd29 = new MySqlCommand(s23, connection);
                MySqlDataReader rs29;
                rs29 = cmd29.ExecuteReader();
                while ((rs29.Read()))
                {
                    CounterEfficiencyTextBox.Text = (rs29["efficiency"].ToString());
                    BKGCountsTextBox.Text = (rs29["bkg_counts"].ToString());
                }
                BKGCountsTextBox.Enabled = true;
                BKGCountTimeTextBox.Text = "1";
                SampleCountTimeTextBox.Text = "1";
                LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100).ToString("0.00");
                LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");
                rs29.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
            }
        }
        //private void Button2_Click(System.Object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        Add_shift.Show();

        //        this.Hide();
        //        UnitDropDownList.Enabled = false;
        //        GroupBox1.Enabled = true;
        //        GroupBox2.Enabled = true;
        //        GroupBox8.Enabled = true;
        //        SearchDropDownList.Enabled = true;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        protected void SampleCountsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SampleCountsDropDownList.Text == "A")
                {
                    SmearDropDownList.Text = "A";
                    ActivityDropDownList.Enabled = true;
                    TimeofSamplingTextBox.Enabled = true;
                    TimeofCountingTextBox.Enabled = true;
                    ContaminationLevelTextBox.Text = "";
                    RemarksTextBox.Text = "";
                    LLDTextBox.Text = "";
                    MDAdpmTextBox.Text = "";
                    MDABqTextBox.Text = "";
                    LLDBKGTextBox.Text = "";
                    SampleCountsTextBox.Enabled = true;
                    SamplingTimeTextBox.Text = "5";
                    BKGCountTimeTextBox.Text = "1";
                    SampleCountTimeTextBox.Text = "1";
                    AreaCorrectionFactorTextBox.Text = "17.64";
                    HalfLifeTextBox.Text = "20";
                    RemarksTextBox.Text = "";
                    TotalAreaSwipedTextBox.Text = "";
                    AerosolDropDownList.Enabled = true;
                    LivedTextBox.Enabled = true;
                    ActivityDropDownList.Enabled = true;
                    ElapsedTimeTextBox.Enabled = true;
                    HalfLifeTextBox.Enabled = true;
                    FlowrateTextBox.Enabled = true;
                    DecayCorrectionFactorTextBox.Enabled = true;
                    AreaCorrectionFactorTextBox.Enabled = true;
                    SamplingTimeTextBox.Enabled = true;
                    TotalAirSampledTextBox.Enabled = true;
                    AirActivityTextBox.Enabled = true;
                    DACTextBox.Enabled = true;
                    LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                    MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100).ToString("0.00");
                    LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                    MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");
                }
                else if (SampleCountsDropDownList.Text == "S")
                {
                    SmearDropDownList.Text = "S";
                    SampleCountsTextBox.Enabled = true;
                    ActivityDropDownList.Enabled = false;
                    AerosolDropDownList.Enabled = false;
                    LivedTextBox.Enabled = false;
                    ActivityDropDownList.Enabled = false;
                    TimeofSamplingTextBox.Enabled = false;
                    TimeofCountingTextBox.Enabled = false;
                    ElapsedTimeTextBox.Enabled = false;
                    HalfLifeTextBox.Enabled = false;
                    FlowrateTextBox.Enabled = false;
                    DecayCorrectionFactorTextBox.Enabled = false;
                    AreaCorrectionFactorTextBox.Enabled = false;
                    SamplingTimeTextBox.Enabled = false;
                    TotalAirSampledTextBox.Enabled = false;
                    AirActivityTextBox.Enabled = false;
                    DACTextBox.Enabled = false;
                    TotalAreaSwipedTextBox.Text = "100";
                    BKGCountTimeTextBox.Text = "1";
                    SampleCountTimeTextBox.Text = "1";
                    RemarksTextBox.Text = "";
                    SamplingTimeTextBox.Text = "";
                    DACTextBox.Text = "";
                    AirActivityTextBox.Text = "";
                    FlowrateTextBox.Text = "";
                    TimeofSamplingTextBox.Text = "";
                    TimeofCountingTextBox.Text = "";
                    SamplingTimeTextBox.Text = "";
                    DecayCorrectionFactorTextBox.Text = "";
                    FlowrateTextBox.Text = "";
                    TotalAirSampledTextBox.Text = "";
                    AirActivityTextBox.Text = "";
                    DACTextBox.Text = "";
                    LivedTextBox.Text = "";
                    AerosolDropDownList.Text = "";
                    AreaCorrectionFactorTextBox.Text = "";
                    ElapsedTimeTextBox.Text = "";
                    HalfLifeTextBox.Text = "";
                    NetCountsTextBox.Text = "";
                    RemarksTextBox.Text = "";
                    LLDTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(BKGCountsTextBox.Text) * Convert.ToDouble(SampleCountTimeTextBox.Text) * (1 + Convert.ToDouble(SampleCountTimeTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text))) * 3.29 + 3, 2).ToString();
                    MDAdpmTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100).ToString("0.00");
                    LLDBKGTextBox.Text = (Convert.ToDouble(LLDTextBox.Text) + Convert.ToDouble(BKGCountsTextBox.Text)).ToString();
                    MDABqTextBox.Text = (Convert.ToDouble(MDAdpmTextBox.Text) / (double)60).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
            }
        }
        //private void Button3_Click_1(System.Object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        DACTextBox.Text = "";
        //        TimeofSamplingTextBox.Text = "";
        //        TimeofCountingTextBox.Text = "";
        //        DecayCorrectionFactorTextBox.Text = "";
        //        FlowrateTextBox.Text = "";
        //        TotalAirSampledTextBox.Text = "";
        //        AirActivityTextBox.Text = "";
        //        SampleCountsTextBox.Text = "";
        //        NetCountsTextBox.Text = "";
        //        ContaminationLevelTextBox.Text = "";
        //        RemarksTextBox.Text = "";
        //        LivedTextBox.Text = "";
        //        TotalAreaSwipedTextBox.Text = "";
        //        // LLDTextBox.Text = ""
        //        // MDAdpmTextBox.Text = ""
        //        // MDABqTextBox.Text = ""
        //        // LLDBKGTextBox.Text = ""
        //        // LivedTextBox.Text = ""
        //        ElapsedTimeTextBox.Text = "";
        //        HalfLifeTextBox.Text = "";
        //        SamplingTimeTextBox.Text = "";
        //        AreaCorrectionFactorTextBox.Text = "";
        //        BKGCountTimeTextBox.Text = "";
        //        SampleCountTimeTextBox.Text = "";
        //        AerosolDropDownList.Text = "";
        //        UnitDropDownList.Enabled = true;
        //        ContaminationDateTextBox.Enabled = false;
        //        cmd_edit.Enabled = true;
        //        cmd_delete.Enabled = true;
        //        cmd_view.Enabled = true;
        //        StatusDropDownList.Items.Add("R");
        //        StatusDropDownList.Items.Add("N");
        //        StatusDropDownList.Items.Add("O");
        //        StatusDropDownList.Items.Add("M");
        //        StatusDropDownList.Items.Add("Radeye-B20");
        //        StatusDropDownList.Items.Add("NRP");
        //        cmd_new.Enabled = true;
        //        cmd_add.Enabled = true;
        //        TableLayoutPanel1.Enabled = true;
        //        TableLayoutPanel2.Enabled = true;
        //        TableLayoutPanel3.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        protected void TotalAreaSwipedTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NetCountsTextBox.Text = Math.Round((Convert.ToDouble(SampleCountsTextBox.Text) / Convert.ToDouble(SampleCountTimeTextBox.Text) - Convert.ToDouble(BKGCountsTextBox.Text) / Convert.ToDouble(BKGCountTimeTextBox.Text)), 2).ToString();
                ContaminationLevelTextBox.Text = Math.Round((Convert.ToDouble(NetCountsTextBox.Text) / (double)60 / Convert.ToDouble(CounterEfficiencyTextBox.Text) * 100 / Convert.ToDouble(TotalAreaSwipedTextBox.Text)), 2).ToString();
                if (Convert.ToDouble(SampleCountsTextBox.Text) >= Convert.ToDouble(LLDBKGTextBox.Text))
                    ContaminationLevelTextBox.ForeColor = Color.Red;
                else
                {
                    ContaminationLevelTextBox.Text = "BDL";
                    ContaminationLevelTextBox.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            EditButton.Visible = false;
            SaveButton.Visible = true;
            DataEntryPanel.Enabled = true;
            BGCPanel.Enabled = true;
            MaterialPanel.Enabled = true;
            BottomPanel.Enabled = true;

            InitialAddRecord.Visible = false;
            AddRecordButton.Visible = false;

            //AddShiftButton.Visible = true;
            //AddShiftButton.Text = "Edit Shift";
        }

        protected void InitialAddRecord_Click(object sender, EventArgs e)
        {
            //AddShiftButton.Visible = true;
            InitialAddRecord.Visible = false;
            AddRecordButton.Visible = true;

            EditButton.Visible = false;
            SaveButton.Visible = false;
            DeleteButton.Visible = false;

            DataEntryPanel.Enabled = true;
            BGCPanel.Enabled = true;
            MaterialPanel.Enabled = true;
            BottomPanel.Enabled = true;

            AsON.Text = DateTime.Now.ToShortDateString();
            ContaminationDateTextBox.Text = DateTime.Now.ToString();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Search(Convert.ToInt32(SearchDropDownList.Text));
            ViewMode();
        }
        protected void LoadCountingSystem()
        {
            try
            {
                CountingSystemDropDownList.Items.Clear();
                RackDropDownList.Items.Clear();
                InstrumentLocationDropDownList.Items.Clear();
                CounterEfficiencyTextBox.Text = "";
                BKGCountsTextBox.Text = "";
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                string s22;
                s22 = "select distinct counting_instrument from eff"; // where unit=" + LocationUnitDropDownList.Text + "";
                MySqlCommand cmd25 = new MySqlCommand(s22, connection);
                MySqlDataReader rs22;
                rs22 = cmd25.ExecuteReader();
                while ((rs22.Read()))

                    CountingSystemDropDownList.Items.Add(rs22["counting_instrument"].ToString());

                rs22.Close();
                connection.Close();

                SampleDescriptionDropDownList.Items.Clear();
                SampleDescriptionDropDownList.Items.Add("R");
                SampleDescriptionDropDownList.Items.Add("N");
                SampleDescriptionDropDownList.Items.Add("O");
                SampleDescriptionDropDownList.Items.Add("M");
                SampleDescriptionDropDownList.Items.Add("Radeye-B20");
                SampleDescriptionDropDownList.Items.Add("NRP");
            }
            catch (Exception ex)
            {
            }
        }
        private void ClearControls()
        {

        }

        protected void AddShiftButton_Click(object sender, EventArgs e)
        {

        }
    }
    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static string ChangeNull(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return " ";
            }
            else
            {
                return str;
            }
        }


    }
}

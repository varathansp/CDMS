using System;
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
    public partial class Response : System.Web.UI.Page
    {
        
        private static string _connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                _connectionString = ConfigurationManager.ConnectionStrings["CDMS_ConnectionString"].ConnectionString;
                ClientScript.GetPostBackEventReference(this, string.Empty);
                //CreatedDateTextBox.Value = DateTime.Today.ToString("yyyy-MM-dd");// DateTime.Now.ToString();
                DateTextBox.Value = DateTime.Today.ToString("yyyy-MM-dd");
                AsOnTextBox.Value = DateTime.Parse("2010-08-10").ToString("yyyy-MM-dd");

                SearchIdDropDownList.Items.Clear();
                string s1;
                s1 = "select id from responses order by id asc";
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand cmd1 = new MySqlCommand(s1, connection);
                MySqlDataReader rs1;
                rs1 = cmd1.ExecuteReader();
                while ((rs1.Read()))

                    SearchIdDropDownList.Items.Add(rs1["id"].ToString());

                rs1.Close();
                connection.Close();

                EditButton.Visible = false;
                UpdateButton.Visible = false;
                DeleteButton.Visible = false;
                SaveButton.Visible = true;

                CreatedDateLabel.Visible = false;
                CreatedDateValueLabel.Visible = false;
                CreatedByLabel.Visible = false;
                CreatedByDropDownList.Visible = false;

                ModifiedDateLabel.Visible = false;
                ModifiedDateValueLabel.Visible = false;
                ModifiedByLabel.Visible = false;
                ModifiedByDropDownList.Visible = false;

                RemarksLabel.Visible = false;
                RemarksTextBox.Visible = false;

            }
            


        }

       
        private string GetMean(string one, string two, string three)
        {
            if (one == string.Empty) { one = "0"; };
            if (two == string.Empty) { two = "0"; };
            if (three == string.Empty) { three = "0"; };
            return ((Convert.ToDouble(one) + Convert.ToDouble(two) + Convert.ToDouble(three)) / 3).ToString("0.##");
        }
        private string GetEfficiency(string mean, string pa)
        {
            if (mean == string.Empty) { mean = "0"; };
            if (pa == string.Empty) { pa = "0"; };
            return (Convert.ToDouble(mean) * 100 / (60 * Convert.ToDouble(pa) * 1000)).ToString("0.##");
        }
        protected void S1T1_TextChanged(object sender, EventArgs e)
        {
            M1.Text = GetMean(S1T1.Text, S1T2.Text, S1T3.Text);
            E1.Text = GetEfficiency(M1.Text, PATextBox.Text);
        }
        protected void S1T2_TextChanged(object sender, EventArgs e)
        {
            M1.Text = GetMean(S1T1.Text, S1T2.Text, S1T3.Text);
            E1.Text = GetEfficiency(M1.Text, PATextBox.Text);
        }

        protected void S1T3_TextChanged(object sender, EventArgs e)
        {
            M1.Text = GetMean(S1T1.Text, S1T2.Text, S1T3.Text);
            E1.Text = GetEfficiency(M1.Text, PATextBox.Text);
        }

        protected void S2T1_TextChanged(object sender, EventArgs e)
        {
            M2.Text = GetMean(S2T1.Text, S2T2.Text, S2T3.Text);
            E2.Text = GetEfficiency(M2.Text, PATextBox.Text);
        }

        protected void S2T2_TextChanged(object sender, EventArgs e)
        {
            M2.Text = GetMean(S2T1.Text, S2T2.Text, S2T3.Text);
            E2.Text = GetEfficiency(M2.Text, PATextBox.Text);
        }

        protected void S2T3_TextChanged(object sender, EventArgs e)
        {
            M2.Text = GetMean(S2T1.Text, S2T2.Text, S2T3.Text);
            E2.Text = GetEfficiency(M2.Text, PATextBox.Text);
        }

        protected void S3T1_TextChanged(object sender, EventArgs e)
        {
            M3.Text = GetMean(S3T1.Text, S3T2.Text, S3T3.Text);
            E3.Text = GetEfficiency(M3.Text, PATextBox.Text);
        }

        protected void S3T2_TextChanged(object sender, EventArgs e)
        {
            M3.Text = GetMean(S3T1.Text, S3T2.Text, S3T3.Text);
            E3.Text = GetEfficiency(M3.Text, PATextBox.Text);
        }

        protected void S3T3_TextChanged(object sender, EventArgs e)
        {
            M3.Text = GetMean(S3T1.Text, S3T2.Text, S3T3.Text);
            E3.Text = GetEfficiency(M3.Text, PATextBox.Text);
        }

        protected void S4T1_TextChanged(object sender, EventArgs e)
        {
            M4.Text = GetMean(S4T1.Text, S4T2.Text, S4T3.Text);
            E4.Text = GetEfficiency(M4.Text, PATextBox.Text);
        }

        protected void S4T2_TextChanged(object sender, EventArgs e)
        {
            M4.Text = GetMean(S4T1.Text, S4T2.Text, S4T3.Text);
            E4.Text = GetEfficiency(M4.Text, PATextBox.Text);
        }

        protected void S4T3_TextChanged(object sender, EventArgs e)
        {
            M4.Text = GetMean(S4T1.Text, S4T2.Text, S4T3.Text);
            E4.Text = GetEfficiency(M4.Text, PATextBox.Text);
        }

        protected void S5T1_TextChanged(object sender, EventArgs e)
        {
            M5.Text = GetMean(S5T1.Text, S5T2.Text, S5T3.Text);
            E5.Text = GetEfficiency(M5.Text, PATextBox.Text);
        }

        protected void S5T2_TextChanged(object sender, EventArgs e)
        {
            M5.Text = GetMean(S5T1.Text, S5T2.Text, S5T3.Text);
            E5.Text = GetEfficiency(M5.Text, PATextBox.Text);
        }

        protected void S5T3_TextChanged(object sender, EventArgs e)
        {
            M5.Text = GetMean(S5T1.Text, S5T2.Text, S5T3.Text);
            E5.Text = GetEfficiency(M5.Text, PATextBox.Text);
        }

        protected void S6T1_TextChanged(object sender, EventArgs e)
        {
            M6.Text = GetMean(S6T1.Text, S6T2.Text, S6T3.Text);
            E6.Text = GetEfficiency(M6.Text, PATextBox.Text);
        }

        protected void S6T2_TextChanged(object sender, EventArgs e)
        {
            M6.Text = GetMean(S6T1.Text, S6T2.Text, S6T3.Text);
            E6.Text = GetEfficiency(M6.Text, PATextBox.Text);
        }

        protected void S6T3_TextChanged(object sender, EventArgs e)
        {
            M6.Text = GetMean(S6T1.Text, S6T2.Text, S6T3.Text);
            E6.Text = GetEfficiency(M6.Text, PATextBox.Text);
        }

        protected void S7T1_TextChanged(object sender, EventArgs e)
        {
            M7.Text = GetMean(S7T1.Text, S7T2.Text, S7T3.Text);
            E7.Text = GetEfficiency(M7.Text, PATextBox.Text);
        }

        protected void S7T2_TextChanged(object sender, EventArgs e)
        {
            M7.Text = GetMean(S7T1.Text, S7T2.Text, S7T3.Text);
            E7.Text = GetEfficiency(M7.Text, PATextBox.Text);
        }

        protected void S7T3_TextChanged(object sender, EventArgs e)
        {
            M7.Text = GetMean(S7T1.Text, S7T2.Text, S7T3.Text);
            E7.Text = GetEfficiency(M7.Text, PATextBox.Text);
        }

        protected void S8T1_TextChanged(object sender, EventArgs e)
        {
            M8.Text = GetMean(S8T1.Text, S8T2.Text, S8T3.Text);
            E8.Text = GetEfficiency(M8.Text, PATextBox.Text);
            doubtFulFormulas();
        }

        protected void S8T2_TextChanged(object sender, EventArgs e)
        {
            M8.Text = GetMean(S8T1.Text, S8T2.Text, S8T3.Text);
            E8.Text = GetEfficiency(M8.Text, PATextBox.Text);
            doubtFulFormulas();
        }

        protected void S8T3_TextChanged(object sender, EventArgs e)
        {
            M8.Text = GetMean(S8T1.Text, S8T2.Text, S8T3.Text);
            E8.Text = GetEfficiency(M8.Text, PATextBox.Text);
            doubtFulFormulas();
        }

        protected void S9T1_TextChanged(object sender, EventArgs e)
        {
            M9.Text = GetMean(S9T1.Text, S9T2.Text, S9T3.Text);
            E9.Text = GetEfficiency(M9.Text, PATextBox.Text);
        }

        protected void S9T2_TextChanged(object sender, EventArgs e)
        {
            M9.Text = GetMean(S9T1.Text, S9T2.Text, S9T3.Text);
            E9.Text = GetEfficiency(M9.Text, PATextBox.Text);
        }

        protected void S9T3_TextChanged(object sender, EventArgs e)
        {
            M9.Text = GetMean(S9T1.Text, S9T2.Text, S9T3.Text);
            E9.Text = GetEfficiency(M9.Text, PATextBox.Text);
        }

        protected void S10T1_TextChanged(object sender, EventArgs e)
        {
            M10.Text = GetMean(S10T1.Text, S10T2.Text, S10T3.Text);
            E10.Text = GetEfficiency(M10.Text, PATextBox.Text);
        }

        protected void S10T2_TextChanged(object sender, EventArgs e)
        {
            M10.Text = GetMean(S10T1.Text, S10T2.Text, S10T3.Text);
            E10.Text = GetEfficiency(M10.Text, PATextBox.Text);
        }

        protected void S10T3_TextChanged(object sender, EventArgs e)
        {
            M10.Text = GetMean(S10T1.Text, S10T2.Text, S10T3.Text);
            E10.Text = GetEfficiency(M10.Text, PATextBox.Text);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string sqlt;
            string username = "test user";
            MySqlCommand cmdttt = new MySqlCommand();

            sqlt = "insert into responses values('" + GetNextId() + "','" + DateTextBox.Value + "','" + SourceTextBox.Text + "','" + AsOnTextBox.Value + "','" + GCSDropDownList.Text + "','" +
                  SourceUINTextBox.Text + "','" + PATextBox.Text + "','" + LocationTextBox.Text + "'," + CountingTimeTextBox.Text + "," + VoltageTextBox.Text +
                  "," + observation1TextBox.Text + "," + observation2TextBox.Text + "," + observation3TextBox.Text + "," + (Counts1TextBox.Text == String.Empty ? "0" : Counts1TextBox.Text) + "," +
                  (Counts2TextBox.Text == string.Empty ? "0" : Counts2TextBox.Text) + "," + (Counts3TextBox.Text == string.Empty ? "0" : Counts3TextBox.Text) + ",'" + CountRate1TextBox.Text + "','" + CountRate2TextBox.Text + "','" + CountRate3TextBox.Text + "','" +
                  MeanTextBox.Text + "','" +

                  R1.Text + "','" + R2.Text + "','" + R3.Text + "','" + R4.Text + "','" + R5.Text + "','" + R6.Text + "','" + R7.Text + "','" + R8.Text + "','" + R9.Text + "','" + R10.Text +
                  "'," + S1T1.Text + "," + S2T1.Text + "," + S3T1.Text + "," + S4T1.Text + "," + S5T1.Text + "," + S6T1.Text + "," + S7T1.Text + "," + S8T1.Text + "," + S9T1.Text + "," + S10T1.Text +

                  "," + S1T2.Text +
                  "," + S2T2.Text + "," + S3T2.Text + "," + S4T2.Text + "," + S5T2.Text + "," + S6T2.Text + "," + S7T2.Text +
                  "," + S8T2.Text + "," + S9T2.Text + "," + S10T2.Text +

                  "," + S1T3.Text + "," + S2T3.Text + "," + S3T3.Text +
                  "," + S4T3.Text + "," + S5T3.Text + "," + S6T3.Text + "," + S7T3.Text + "," + S8T3.Text + "," + S9T3.Text +
                  "," + S10T3.Text +

                  ",'" + M1.Text + "','" + M2.Text + "','" + M3.Text + "','" + M4.Text + "','" +
                  M5.Text + "','" + M6.Text + "','" + M7.Text + "','" + M8.Text + "','" + M9.Text + "','" +
                  M10.Text +

                  "','" + E1.Text + "','" + E2.Text + "','" + E3.Text + "','" + E4.Text + "','" +
                  E5.Text + "','" + E6.Text + "','" + E7.Text + "','" + E8.Text + "','" + E9.Text + "','" +
                  E10.Text + "',"

                  + BCTTextBox.Text + "," + SCTTextBox.Text + ",'" + BGCRTextBox.Text + "','" + KTextBox.Text + "','" +
                  ETextBox.Text + "','" +

                  MDATextBox.Text + "','" + MDA2TextBox.Text + "','" +

                  PerformaceCheckedByDropDownList.Text + "','" + ReviewedByDropDownList.Text + "','" + IssuedByDropDownList.Text + "','" +

                  username + "','" + DateTime.Today.ToString("yyyy-MM-dd") +
                  "',' ',' ','" + RemarksTextBox.Text + "')";

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            cmdttt = new MySqlCommand(sqlt, connection);
            cmdttt.ExecuteNonQuery();

            ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('New Record Inserted');", true);

            EditPanel.Enabled = false;
            SaveButton.Visible = false;
            DeleteButton.Enabled = true;
            DeleteButton.Visible = true;
            ClearButton.Visible = true;
            EditButton.Visible = true;
            EditButton.Enabled = true;
            UpdateButton.Visible = false;

            CreatedDateLabel.Visible = true;
            CreatedDateValueLabel.Visible = true;

            ModifiedDateLabel.Visible = true;
            ModifiedDateValueLabel.Visible = true;

            ModifiedByLabel.Visible = true;
            ModifiedByDropDownList.Visible = true;
            ModifiedByDropDownList.Enabled = false;
            //ModifiedDateTextBox.Enabled = false;

            RemarksLabel.Visible = true;
            RemarksTextBox.Visible = true;
            RemarksTextBox.Enabled = false;

            InitialActivityTextBox_TextChanged(null, new EventArgs());

            CreatedDateValueLabel.Text = DateTime.Now.ToString();
            ModifiedDateValueLabel.Text = "Not Modified";

            SearchIdDropDownList.Items.Clear();
            string s1T;
            s1T = "select distinct id from responses order by id asc";
            MySqlCommand cmd1T = new MySqlCommand(s1T, connection);
            MySqlDataReader rs1T;
            rs1T = cmd1T.ExecuteReader();
            while ((rs1T.Read()))

                SearchIdDropDownList.Items.Add(rs1T["id"].ToString());

            rs1T.Close();
            connection.Close();
        }

        private string GetNextId()
        {
            string s1T = "select max(ID) from responses";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand cmd1T = new MySqlCommand(s1T, connection);

            int maxId = Convert.ToInt32(cmd1T.ExecuteScalar());
            connection.Close();
            return (maxId + 1).ToString();
        }

        protected void Search()
        {
            EditPanel.Enabled = false;
            SaveButton.Visible = false;
            DeleteButton.Enabled = true;
            DeleteButton.Visible = true;
            ClearButton.Visible = true;
            EditButton.Visible = true;
            EditButton.Enabled = true;
            UpdateButton.Visible = false;

            CreatedDateLabel.Visible = true;
            CreatedDateValueLabel.Visible = true;

            ModifiedDateLabel.Visible = true;
            ModifiedDateValueLabel.Visible = true;

            ModifiedByLabel.Visible = true;
            ModifiedByDropDownList.Visible = true;
            ModifiedByDropDownList.Enabled = false;
            //ModifiedDateTextBox.Enabled = false;
            
            RemarksLabel.Visible = true;
            RemarksTextBox.Visible = true;
            RemarksTextBox.Enabled = false;

            InitialActivityTextBox.Visible = true;

            string sz;
            sz = "select * from responses where id=" + SearchIdDropDownList.Text + "";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand cmdz = new MySqlCommand(sz, connection);
            MySqlDataReader rs1z;
            rs1z = cmdz.ExecuteReader();
            rs1z.Read();
            SearchIdDropDownList.Text = (rs1z.IsDBNull(0) ? default(int).ToString() : rs1z.GetInt32(0).ToString());
            DateTextBox.Value = (rs1z.IsDBNull(1) ? default(DateTime).ToString() : rs1z.GetDateTime(1).ToString());
            SourceTextBox.Text = (rs1z.IsDBNull(2) ? null : rs1z.GetString(2));
            AsOnTextBox.Value = (rs1z.IsDBNull(3) ? default(DateTime).ToString() : rs1z.GetDateTime(3).ToString());
            GCSDropDownList.Text = (rs1z.IsDBNull(4) ? null : rs1z.GetString(4));
            SourceUINTextBox.Text = (rs1z.IsDBNull(5) ? null : rs1z.GetString(5));
            PATextBox.Text = (rs1z.IsDBNull(6) ? null : rs1z.GetString(6));
            LocationTextBox.Text = (rs1z.IsDBNull(7) ? null : rs1z.GetString(7));
            CountingTimeTextBox.Text = (rs1z.IsDBNull(8) ? default(int).ToString() : rs1z.GetInt32(8).ToString());
            VoltageTextBox.Text = (rs1z.IsDBNull(9) ? default(int).ToString() : rs1z.GetInt32(9).ToString());
            observation1TextBox.Text = (rs1z.IsDBNull(10) ? default(int).ToString() : rs1z.GetInt32(10).ToString());
            observation2TextBox.Text = (rs1z.IsDBNull(11) ? default(int).ToString() : rs1z.GetInt32(11).ToString());
            observation3TextBox.Text = (rs1z.IsDBNull(12) ? default(int).ToString() : rs1z.GetInt32(12).ToString());
            Counts1TextBox.Text = (rs1z.IsDBNull(13) ? default(int).ToString() : rs1z.GetInt32(13).ToString());
            Counts2TextBox.Text = (rs1z.IsDBNull(14) ? default(int).ToString() : rs1z.GetInt32(14).ToString());
            Counts3TextBox.Text = (rs1z.IsDBNull(15) ? default(int).ToString() : rs1z.GetInt32(15).ToString());
            CountRate1TextBox.Text = (rs1z.IsDBNull(16) ? null : rs1z.GetString(16));
            CountRate2TextBox.Text = (rs1z.IsDBNull(17) ? null : rs1z.GetString(17));
            CountRate3TextBox.Text = (rs1z.IsDBNull(18) ? null : rs1z.GetString(18));
            MeanTextBox.Text = (rs1z.IsDBNull(19) ? null : rs1z.GetString(19));

            R1.Text = (rs1z.IsDBNull(20) ? null : rs1z.GetString(20));
            R2.Text = (rs1z.IsDBNull(21) ? null : rs1z.GetString(21));
            R3.Text = (rs1z.IsDBNull(22) ? null : rs1z.GetString(22));
            R4.Text = (rs1z.IsDBNull(23) ? null : rs1z.GetString(23));
            R5.Text = (rs1z.IsDBNull(24) ? null : rs1z.GetString(24));
            R6.Text = (rs1z.IsDBNull(25) ? null : rs1z.GetString(25));
            R7.Text = (rs1z.IsDBNull(26) ? null : rs1z.GetString(26));
            R8.Text = (rs1z.IsDBNull(27) ? null : rs1z.GetString(27));
            R9.Text = (rs1z.IsDBNull(28) ? null : rs1z.GetString(28));
            R10.Text = (rs1z.IsDBNull(29) ? null : rs1z.GetString(29));

            S1T1.Text = (rs1z.IsDBNull(30) ? default(int).ToString() : rs1z.GetInt32(30).ToString());
            S2T1.Text = (rs1z.IsDBNull(31) ? default(int).ToString() : rs1z.GetInt32(31).ToString());
            S3T1.Text = (rs1z.IsDBNull(32) ? default(int).ToString() : rs1z.GetInt32(32).ToString());
            S4T1.Text = (rs1z.IsDBNull(33) ? default(int).ToString() : rs1z.GetInt32(33).ToString());
            S5T1.Text = (rs1z.IsDBNull(34) ? default(int).ToString() : rs1z.GetInt32(34).ToString());
            S6T1.Text = (rs1z.IsDBNull(35) ? default(int).ToString() : rs1z.GetInt32(35).ToString());
            S7T1.Text = (rs1z.IsDBNull(36) ? default(int).ToString() : rs1z.GetInt32(36).ToString());
            S8T1.Text = (rs1z.IsDBNull(37) ? default(int).ToString() : rs1z.GetInt32(37).ToString());
            S9T1.Text = (rs1z.IsDBNull(38) ? default(int).ToString() : rs1z.GetInt32(38).ToString());
            S10T1.Text = (rs1z.IsDBNull(39) ? default(int).ToString() : rs1z.GetInt32(39).ToString());

            S1T2.Text = (rs1z.IsDBNull(40) ? default(int).ToString() : rs1z.GetInt32(40).ToString());
            S2T2.Text = (rs1z.IsDBNull(41) ? default(int).ToString() : rs1z.GetInt32(41).ToString());
            S3T2.Text = (rs1z.IsDBNull(42) ? default(int).ToString() : rs1z.GetInt32(42).ToString());
            S4T2.Text = (rs1z.IsDBNull(43) ? default(int).ToString() : rs1z.GetInt32(43).ToString());
            S5T2.Text = (rs1z.IsDBNull(44) ? default(int).ToString() : rs1z.GetInt32(44).ToString());
            S6T2.Text = (rs1z.IsDBNull(45) ? default(int).ToString() : rs1z.GetInt32(45).ToString());
            S7T2.Text = (rs1z.IsDBNull(46) ? default(int).ToString() : rs1z.GetInt32(46).ToString());
            S8T2.Text = (rs1z.IsDBNull(47) ? default(int).ToString() : rs1z.GetInt32(47).ToString());
            S9T2.Text = (rs1z.IsDBNull(48) ? default(int).ToString() : rs1z.GetInt32(48).ToString());
            S10T2.Text = (rs1z.IsDBNull(49) ? default(int).ToString() : rs1z.GetInt32(49).ToString());


            S1T3.Text = (rs1z.IsDBNull(50) ? default(int).ToString() : rs1z.GetInt32(50).ToString());
            S2T3.Text = (rs1z.IsDBNull(51) ? default(int).ToString() : rs1z.GetInt32(51).ToString());
            S3T3.Text = (rs1z.IsDBNull(52) ? default(int).ToString() : rs1z.GetInt32(52).ToString());
            S4T3.Text = (rs1z.IsDBNull(53) ? default(int).ToString() : rs1z.GetInt32(53).ToString());
            S5T3.Text = (rs1z.IsDBNull(54) ? default(int).ToString() : rs1z.GetInt32(54).ToString());
            S6T3.Text = (rs1z.IsDBNull(55) ? default(int).ToString() : rs1z.GetInt32(55).ToString());
            S7T3.Text = (rs1z.IsDBNull(56) ? default(int).ToString() : rs1z.GetInt32(56).ToString());
            S8T3.Text = (rs1z.IsDBNull(57) ? default(int).ToString() : rs1z.GetInt32(57).ToString());
            S9T3.Text = (rs1z.IsDBNull(58) ? default(int).ToString() : rs1z.GetInt32(58).ToString());
            S10T3.Text = (rs1z.IsDBNull(59) ? default(int).ToString() : rs1z.GetInt32(59).ToString());


            M1.Text = (rs1z.IsDBNull(60) ? null : rs1z.GetString(60));
            M2.Text = (rs1z.IsDBNull(61) ? null : rs1z.GetString(61));
            M3.Text = (rs1z.IsDBNull(62) ? null : rs1z.GetString(62));
            M4.Text = (rs1z.IsDBNull(63) ? null : rs1z.GetString(63));
            M5.Text = (rs1z.IsDBNull(64) ? null : rs1z.GetString(64));
            M6.Text = (rs1z.IsDBNull(65) ? null : rs1z.GetString(65));
            M7.Text = (rs1z.IsDBNull(66) ? null : rs1z.GetString(66));
            M8.Text = (rs1z.IsDBNull(67) ? null : rs1z.GetString(67));
            M9.Text = (rs1z.IsDBNull(68) ? null : rs1z.GetString(68));
            M10.Text = (rs1z.IsDBNull(69) ? null : rs1z.GetString(69));

            E1.Text = (rs1z.IsDBNull(70) ? null : rs1z.GetString(70));
            E2.Text = (rs1z.IsDBNull(71) ? null : rs1z.GetString(71));
            E3.Text = (rs1z.IsDBNull(72) ? null : rs1z.GetString(72));
            E4.Text = (rs1z.IsDBNull(73) ? null : rs1z.GetString(73));
            E5.Text = (rs1z.IsDBNull(74) ? null : rs1z.GetString(74));
            E6.Text = (rs1z.IsDBNull(75) ? null : rs1z.GetString(75));
            E7.Text = (rs1z.IsDBNull(76) ? null : rs1z.GetString(76));
            E8.Text = (rs1z.IsDBNull(77) ? null : rs1z.GetString(77));
            E9.Text = (rs1z.IsDBNull(78) ? null : rs1z.GetString(78));
            E10.Text = (rs1z.IsDBNull(79) ? null : rs1z.GetString(79));

            BCTTextBox.Text = (rs1z.IsDBNull(80) ? default(int).ToString() : rs1z.GetInt32(80).ToString());
            SCTTextBox.Text = (rs1z.IsDBNull(81) ? default(int).ToString() : rs1z.GetInt32(81).ToString());
            BGCRTextBox.Text = (rs1z.IsDBNull(82) ? null : rs1z.GetString(82));
            KTextBox.Text = (rs1z.IsDBNull(83) ? null : rs1z.GetString(83));
            ETextBox.Text = (rs1z.IsDBNull(84) ? null : rs1z.GetString(84));

            MDATextBox.Text = (rs1z.IsDBNull(85) ? null : rs1z.GetString(85));
            MDA2TextBox.Text = (rs1z.IsDBNull(86) ? null : rs1z.GetString(86));




            PerformaceCheckedByDropDownList.Text = (rs1z.IsDBNull(87) ? null : rs1z.GetString(87));

            ReviewedByDropDownList.Text = (rs1z.IsDBNull(88) ? null : rs1z.GetString(88));
            IssuedByDropDownList.Text = (rs1z.IsDBNull(89) ? null : rs1z.GetString(89));
            //Login.username.Text = (rs1z.IsDBNull(90) ? null : rs1z.GetString(90));
            CreatedDateValueLabel.Text = (rs1z.IsDBNull(91) ? default(DateTime).ToString() : rs1z.GetDateTime(91).ToString());
            ModifiedByDropDownList.Text = (rs1z.IsDBNull(92) ? null : rs1z.GetString(92));
            var modifiedDate = (rs1z.IsDBNull(93) ? default(DateTime) : rs1z.GetDateTime(93));
            if (modifiedDate.Year == 1)
            {
                ModifiedDateValueLabel.Text = "Not Modified";
            }
            else
            {
                ModifiedDateValueLabel.Text = (rs1z.IsDBNull(93) ? default(DateTime).ToString() : rs1z.GetDateTime(93).ToString());
            }

            RemarksTextBox.Text = (rs1z.IsDBNull(94) ? null : rs1z.GetString(94));

            rs1z.Close();
            connection.Close();
            CountingTimeTextBox_TextChanged(null, new EventArgs());
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            Counts1TextBox.Text = string.Empty;
            Counts2TextBox.Text = string.Empty;
            Counts3TextBox.Text = string.Empty;
            CountRate1TextBox.Text = string.Empty;
            CountRate2TextBox.Text = string.Empty;
            CountRate3TextBox.Text = string.Empty;
            MeanTextBox.Text = string.Empty;

            S1T1.Text = string.Empty;
            S2T1.Text = string.Empty;
            S3T1.Text = string.Empty;
            S4T1.Text = string.Empty;
            S5T1.Text = string.Empty;
            S6T1.Text = string.Empty;
            S7T1.Text = string.Empty;
            S8T1.Text = string.Empty;
            S9T1.Text = string.Empty;
            S10T1.Text = string.Empty;

            S1T2.Text = string.Empty;
            S2T2.Text = string.Empty;
            S3T2.Text = string.Empty;
            S4T2.Text = string.Empty;
            S5T2.Text = string.Empty;
            S6T2.Text = string.Empty;
            S7T2.Text = string.Empty;
            S8T2.Text = string.Empty;
            S9T2.Text = string.Empty;
            S10T2.Text = string.Empty;


            S1T3.Text = string.Empty;
            S2T3.Text = string.Empty;
            S3T3.Text = string.Empty;
            S4T3.Text = string.Empty;
            S5T3.Text = string.Empty;
            S6T3.Text = string.Empty;
            S7T3.Text = string.Empty;
            S8T3.Text = string.Empty;
            S9T3.Text = string.Empty;
            S10T3.Text = string.Empty;

            M1.Text = string.Empty;
            M2.Text = string.Empty;
            M3.Text = string.Empty;
            M4.Text = string.Empty;
            M5.Text = string.Empty;
            M6.Text = string.Empty;
            M7.Text = string.Empty;
            M8.Text = string.Empty;
            M9.Text = string.Empty;
            M10.Text = string.Empty;

            E1.Text = string.Empty;
            E2.Text = string.Empty;
            E3.Text = string.Empty;
            E4.Text = string.Empty;
            E5.Text = string.Empty;
            E6.Text = string.Empty;
            E7.Text = string.Empty;
            E8.Text = string.Empty;
            E9.Text = string.Empty;
            E10.Text = string.Empty;

            BGCRTextBox.Text = string.Empty;
            KTextBox.Text = string.Empty;
            ETextBox.Text = string.Empty;

            EditButton.Visible = false;
            UpdateButton.Visible = false;
            DeleteButton.Visible = false;
            SaveButton.Visible = true;

            CreatedDateLabel.Visible = false;
            CreatedDateValueLabel.Visible = false;
            CreatedByLabel.Visible = false;
            CreatedByDropDownList.Visible = false;

            ModifiedDateLabel.Visible = false;
            ModifiedDateValueLabel.Visible = false;
            ModifiedByLabel.Visible = false;
            ModifiedByDropDownList.Visible = false;

            RemarksLabel.Visible = false;
            RemarksTextBox.Visible = false;

            EditPanel.Enabled = true;
        }

        protected void OpenPDFButton_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            string a8;
            MySqlCommand b8 = new MySqlCommand();
            a8 = "delete from responses where id=" + SearchIdDropDownList.Text + "";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            b8 = new MySqlCommand(a8, connection);
            b8.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('Delete Successfully');", true);


            SearchIdDropDownList.Items.Clear();
            string s1x;
            s1x = "select distinct id from responses order by id asc";
            MySqlCommand cmd1x = new MySqlCommand(s1x, connection);
            MySqlDataReader rs1x;
            rs1x = cmd1x.ExecuteReader();
            while ((rs1x.Read()))

                SearchIdDropDownList.Items.Add(rs1x["id"].ToString());

            rs1x.Close();
            connection.Close();
            ClearButton_Click(null, new EventArgs());
        }
        private string GetCountRate(string counts, string pa)
        {
            if (counts == string.Empty) { counts = "0"; };
            if (pa == string.Empty) { pa = "0"; };
            return (Convert.ToDouble(counts) / Convert.ToDouble(pa)).ToString("0.##");
        }
        protected void Counts1TextBox_TextChanged(object sender, EventArgs e)
        {
            CountRate1TextBox.Text = GetCountRate(Counts1TextBox.Text, CountingTimeTextBox.Text);
            MeanTextBox.Text = GetMean(CountRate1TextBox.Text, CountRate2TextBox.Text, CountRate3TextBox.Text);
            BGCRTextBox.Text = MeanTextBox.Text;
        }

        protected void Counts2TextBox_TextChanged(object sender, EventArgs e)
        {
            CountRate2TextBox.Text = GetCountRate(Counts2TextBox.Text, CountingTimeTextBox.Text);
            MeanTextBox.Text = GetMean(CountRate1TextBox.Text, CountRate2TextBox.Text, CountRate3TextBox.Text);
            BGCRTextBox.Text = MeanTextBox.Text;
        }

        protected void Counts3TextBox_TextChanged(object sender, EventArgs e)
        {
            CountRate3TextBox.Text = GetCountRate(Counts3TextBox.Text, CountingTimeTextBox.Text);
            MeanTextBox.Text = GetMean(CountRate1TextBox.Text, CountRate2TextBox.Text, CountRate3TextBox.Text);
            BGCRTextBox.Text = MeanTextBox.Text;
        }

        protected void CountingTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            CountRate1TextBox.Text = GetCountRate(Counts1TextBox.Text, CountingTimeTextBox.Text);
            MeanTextBox.Text = GetMean(CountRate1TextBox.Text, CountRate2TextBox.Text, CountRate3TextBox.Text);
            CountRate2TextBox.Text = GetCountRate(Counts2TextBox.Text, CountingTimeTextBox.Text);
            MeanTextBox.Text = GetMean(CountRate1TextBox.Text, CountRate2TextBox.Text, CountRate3TextBox.Text);
            CountRate3TextBox.Text = GetCountRate(Counts3TextBox.Text, CountingTimeTextBox.Text);
            MeanTextBox.Text = GetMean(CountRate1TextBox.Text, CountRate2TextBox.Text, CountRate3TextBox.Text);

            BGCRTextBox.Text = MeanTextBox.Text;
        }

        private void doubtFulFormulas()
        {
            KTextBox.Text = ((Convert.ToDouble(E8.Text) * Convert.ToDouble(SCTTextBox.Text)) / 100).ToString("0.##");
            ETextBox.Text = E8.Text;
            string MDA = Math.Round(Math.Sqrt(Convert.ToDouble(MeanTextBox.Text == string.Empty ? "0" : MeanTextBox.Text) * Convert.ToDouble(SCTTextBox.Text) * (1 + Convert.ToDouble(SCTTextBox.Text) / Convert.ToDouble(BCTTextBox.Text))) * 3.29 + 3, 2).ToString();
            MDATextBox.Text = Math.Round(Convert.ToDouble(MDA) / (Convert.ToDouble(ETextBox.Text) * Convert.ToDouble(SCTTextBox.Text) * 100), 2).ToString();
            MDA2TextBox.Text = (Convert.ToDouble(MDATextBox.Text) / 60).ToString("0.##");
        }

        protected void ModifiedByDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ModifiedDateTextBox.Enabled = true;
            RemarksTextBox.Enabled = true;
        }

        protected void AsOnTextBox_TextChanged(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(DateTextBox.Value);
            DateTime d2 = Convert.ToDateTime(AsOnTextBox.Value);
            TimeSpan result = d1.Subtract(d2);
            var days = result.TotalDays;
            PATextBox.Text = (Convert.ToDouble(InitialActivityTextBox.Text == string.Empty ? "0" : InitialActivityTextBox.Text) * Math.Exp((-0.693 * days) / (28 * 365))).ToString("0.###");

            M1.Text = GetMean(S1T1.Text, S1T2.Text, S1T3.Text);
            E1.Text = GetEfficiency(M1.Text, PATextBox.Text);
            M2.Text = GetMean(S2T1.Text, S2T2.Text, S2T3.Text);
            E2.Text = GetEfficiency(M2.Text, PATextBox.Text);
            M3.Text = GetMean(S3T1.Text, S3T2.Text, S3T3.Text);
            E3.Text = GetEfficiency(M3.Text, PATextBox.Text);
            M4.Text = GetMean(S4T1.Text, S4T2.Text, S4T3.Text);
            E4.Text = GetEfficiency(M4.Text, PATextBox.Text);
            M5.Text = GetMean(S5T1.Text, S5T2.Text, S5T3.Text);
            E5.Text = GetEfficiency(M5.Text, PATextBox.Text);
            M6.Text = GetMean(S6T1.Text, S6T2.Text, S6T3.Text);
            E6.Text = GetEfficiency(M6.Text, PATextBox.Text);
            M7.Text = GetMean(S7T1.Text, S7T2.Text, S7T3.Text);
            E7.Text = GetEfficiency(M7.Text, PATextBox.Text);
            M8.Text = GetMean(S8T1.Text, S8T2.Text, S8T3.Text);
            E8.Text = GetEfficiency(M8.Text, PATextBox.Text);
            M9.Text = GetMean(S9T1.Text, S9T2.Text, S9T3.Text);
            E9.Text = GetEfficiency(M9.Text, PATextBox.Text);
            M10.Text = GetMean(S10T1.Text, S10T2.Text, S10T3.Text);
            E10.Text = GetEfficiency(M10.Text, PATextBox.Text);

            doubtFulFormulas();
        }

        protected void InitialActivityTextBox_TextChanged(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(DateTextBox.Value);
            DateTime d2 = Convert.ToDateTime(AsOnTextBox.Value);
            TimeSpan result = d1.Subtract(d2);
            var days = result.TotalDays;
            PATextBox.Text = (Convert.ToDouble(InitialActivityTextBox.Text == string.Empty ? "0" : InitialActivityTextBox.Text) * Math.Exp((-0.693 * days) / (28 * 365))).ToString("0.###");

            M1.Text = GetMean(S1T1.Text, S1T2.Text, S1T3.Text);
            E1.Text = GetEfficiency(M1.Text, PATextBox.Text);
            M2.Text = GetMean(S2T1.Text, S2T2.Text, S2T3.Text);
            E2.Text = GetEfficiency(M2.Text, PATextBox.Text);
            M3.Text = GetMean(S3T1.Text, S3T2.Text, S3T3.Text);
            E3.Text = GetEfficiency(M3.Text, PATextBox.Text);
            M4.Text = GetMean(S4T1.Text, S4T2.Text, S4T3.Text);
            E4.Text = GetEfficiency(M4.Text, PATextBox.Text);
            M5.Text = GetMean(S5T1.Text, S5T2.Text, S5T3.Text);
            E5.Text = GetEfficiency(M5.Text, PATextBox.Text);
            M6.Text = GetMean(S6T1.Text, S6T2.Text, S6T3.Text);
            E6.Text = GetEfficiency(M6.Text, PATextBox.Text);
            M7.Text = GetMean(S7T1.Text, S7T2.Text, S7T3.Text);
            E7.Text = GetEfficiency(M7.Text, PATextBox.Text);
            M8.Text = GetMean(S8T1.Text, S8T2.Text, S8T3.Text);
            E8.Text = GetEfficiency(M8.Text, PATextBox.Text);
            M9.Text = GetMean(S9T1.Text, S9T2.Text, S9T3.Text);
            E9.Text = GetEfficiency(M9.Text, PATextBox.Text);
            M10.Text = GetMean(S10T1.Text, S10T2.Text, S10T3.Text);
            E10.Text = GetEfficiency(M10.Text, PATextBox.Text);

            doubtFulFormulas();

            CountingTimeTextBox_TextChanged(null, new EventArgs());
        }

        protected void DateTextBox_TextChanged(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(DateTextBox.Value);
            DateTime d2 = Convert.ToDateTime(AsOnTextBox.Value);
            TimeSpan result = d1.Subtract(d2);
            var days = result.TotalDays;
            PATextBox.Text = (Convert.ToDouble(InitialActivityTextBox.Text == string.Empty ? "0" : InitialActivityTextBox.Text) * Math.Exp((-0.693 * days) / (28 * 365))).ToString("0.###");
        }


        protected void SearchIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            EditPanel.Enabled = true;
            ModifiedByDropDownList.Enabled = true;
            RemarksTextBox.Enabled = true;

            EditButton.Visible = false;
            UpdateButton.Visible = true;
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            EditPanel.Enabled = false;
            ModifiedByDropDownList.Enabled = false;
            RemarksTextBox.Enabled = false;
            ModifiedDateValueLabel.Text = DateTime.Now.ToString();

            //

            string s17;

            s17 = "update responses set date='" + Convert.ToDateTime(DateTextBox.Value).ToString("yyyy-MM-dd") + "',source='" + SourceTextBox.Text + "',as_on='" + Convert.ToDateTime(AsOnTextBox.Value).ToString("yyyy-MM-dd") + "',gcs_make='" + GCSDropDownList.Text + "',source_uin='" + SourceUINTextBox.Text + "',present_activity='" + PATextBox.Text + "',location='" + LocationTextBox.Text + "',counting_time=" + CountingTimeTextBox.Text + ",voltage=" + VoltageTextBox.Text + ",observation_No_1=" + observation1TextBox.Text + ",observation_No_2=" + observation2TextBox.Text + ",observation_No_3=" + observation3TextBox.Text + ",counts_1=" + Counts1TextBox.Text + ",counts_2=" + Counts2TextBox.Text + ",counts_3=" + Counts3TextBox.Text + "" 
                + ",countrate_1='" + CountRate1TextBox.Text + "',countrate_2='" + CountRate2TextBox.Text + "' ,countrate_3='" + CountRate3TextBox.Text + "',mean_cpm='" + MeanTextBox.Text + "',rack_position_1='" + R1.Text + "',rack_position_2='" + R2.Text + "',rack_position_3='" + R3.Text + "',rack_position_4='" + R4.Text + "',rack_position_5='" + R5.Text + "',rack_position_6='" + R6.Text + "',rack_position_7='" + R7.Text + "',rack_position_8='" + R8.Text + "',rack_position_9='" + R9.Text + "',rack_position_10='" + R10.Text + "',count_trail1_1=" + S1T1.Text + ",count_trail1_2=" + S2T1.Text + ",count_trail1_3=" + S3T1.Text + ",count_trail1_4=" + S4T1.Text + ",count_trail1_5=" + S5T1.Text + ""
                +",count_trail1_6=" + S6T1.Text + ",count_trail1_7=" + S7T1.Text + ",count_trail1_8=" + S8T1.Text + ",count_trail1_9=" + S9T1.Text + ",count_trail1_10=" + S10T1.Text + ",count_trail2_1=" + S1T2.Text + ",count_trail2_2=" + S2T2.Text + ",count_trail2_3=" + S3T2.Text + ",count_trail2_4=" + S4T2.Text + ",count_trail2_5=" + S5T2.Text + ",count_trail2_6=" + S6T2.Text + ",count_trail2_7=" + S7T2.Text + ",count_trail2_8=" + S8T2.Text + ",count_trail2_9=" + S9T2.Text + ",count_trail2_10=" + S10T2.Text + ",count_trail3_1=" + S1T3.Text + ",count_trail3_2=" + S2T3.Text + ",count_trail3_3=" + S3T3.Text + ",count_trail3_4=" + S4T3.Text + ",count_trail3_5=" + S5T3.Text + ""
                +",count_trail3_6=" + S6T3.Text + ",count_trail3_7=" + S7T3.Text + ",count_trail3_8=" + S8T3.Text + ",count_trail3_9=" + S9T3.Text + ",count_trail3_10=" + S10T3.Text + ",bkg_mean1='" + M1.Text + "',bkg_mean2='" + M2.Text + "',bkg_mean3='" + M3.Text + "',bkg_mean4='" + M4.Text + "',bkg_mean5='" + M5.Text + "',bkg_mean6='" + M6.Text + "',bkg_mean7='" + M7.Text + "',bkg_mean8='" + M8.Text + "',bkg_mean9='" + M9.Text + "',bkg_mean10='" + M10.Text + "',rack_efficiency1='" + E1.Text + "',rack_efficiency2='" + E2.Text + "',rack_efficiency3='" + E3.Text + "',rack_efficiency4='" + E4.Text + "',rack_efficiency5='" + E5.Text + "'"
                +",rack_efficiency6='" + E6.Text + "',rack_efficiency7='" + E7.Text + "',rack_efficiency8='" + E8.Text + "',rack_efficiency9='" + E9.Text + "',rack_efficiency10='" + E10.Text + "',bkg_counttime=" + BCTTextBox.Text + ",sample_counttime=" + SCTTextBox.Text + ",bkg_countrate='" + BGCRTextBox.Text + "',efficiency_k='" + KTextBox.Text + "',bkg_efficiency='" + ETextBox.Text + "',mda_dpm='" + MDATextBox.Text + "',mda_bq='" + MDA2TextBox.Text + "',checked_by='" + PerformaceCheckedByDropDownList.Text + "',reviewed_by='" + ReviewedByDropDownList.Text + "',issued_by='" + IssuedByDropDownList.Text + "',modified_by='" + ModifiedByDropDownList.Text + "',modified_by_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',remarks='" + RemarksTextBox.Text + "' where id=" + SearchIdDropDownList.Text + "";


            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand cmd17 = new MySqlCommand(s17, connection);
            cmd17.ExecuteNonQuery();

            ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('Record Updated');", true);
            
            EditButton.Visible = true;
            UpdateButton.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "Info", "alert('Record Updadted');", true);
        }
    }
}
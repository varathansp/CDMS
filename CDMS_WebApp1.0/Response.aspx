<%@ Page Language="C#" MasterPageFile="CustomeControls/CDMS.Master" AutoEventWireup="true"
    CodeBehind="Response.aspx.cs" Inherits="CDMS_WebApp1._0.Response" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        @media print {
            body * {
                visibility: hidden;
            }

            #section-to-print, #section-to-print * {
                visibility: visible;
            }

            #section-to-print {
                position: absolute;
                left: 0;
                top: 0;
            }
        }
        @page {
    size: auto;   /* auto is the initial value */
    margin:10px;  /* this affects the margin in the printer settings */
}
    </style>
    <script type="text/javascript">



        function display() {
            document.getElementById('<%= InitialActivity.ClientID %>').style.display = 'none';
            document.getElementById('<%= InitialActivityTextBox.ClientID %>').style.display = 'none';
            window.print();
            document.getElementById('<%= InitialActivity.ClientID %>').style.display = '';
            document.getElementById('<%= InitialActivityTextBox.ClientID %>').style.display = '';
        }

        function fnConfirmSave() {
            return confirm("Are you sure to save?");
        }
        function fnConfirmDelete() {
            return confirm("Are you sure to Delete?");
        }
        function fnConfirmEdit() {
            return confirm("Are you sure to Edit?");
        }
        function fnSetDateTime(control,post) {
            switch (control) {
                case "DateTextBox":
                    document.getElementById('<%= DateTextBox.ClientID %>').value = document.getElementById("DateTextBoxDatePicker").value;
                    if (post) {
                        __doPostBack('<%= DateTextBox.ClientID %>');
                    }
                case "AsOnTextBox":
                    document.getElementById('<%= AsOnTextBox.ClientID %>').value = document.getElementById("AsOnTextBoxDatePicker").value;
                    if (post) {
                         __doPostBack('<%= AsOnTextBox.ClientID %>');
                    }
                default:

            }
        }

        //calculations
        var $ = function (id) { return document.getElementById(id); };
        var $N = function (id) { var res = document.getElementById(id).value; return Number(res); };

        //mean

        function GetCountRate( counts,  pa)
        {
            if (counts == '' || isNaN(counts) ) { counts = 0; };
            if (pa == '' || isNaN(pa)) { pa = 0; };
            return Number(counts / pa);
        }
        function GetMean( one,  two,  three)
        {
            if (one == '' || isNaN(one))  { one = 0; };
            if (two == '' || isNaN(two)) { two = 0; };
            if (three == '' || isNaN(three)) { three = 0; };
            return Number((Number(one) + Number(two) + Number(three)) / 3);
        }
        function Counts1TextBox_TextChanged()
        {
            $("<%= CountRate1TextBox.ClientID %>").value = GetCountRate($("<%= Counts1TextBox.ClientID %>").value, $("<%= CountingTimeTextBox.ClientID %>").value);
            $("<%= MeanTextBox.ClientID %>").value = GetMean($("<%= CountRate1TextBox.ClientID %>").value, $("<%= CountRate2TextBox.ClientID %>").value, $("<%= CountRate3TextBox.ClientID %>").value);
            $("<%= BGCRTextBox.ClientID %>").value = $("<%= MeanTextBox.ClientID %>").value;
        }

        function Counts2TextBox_TextChanged()
        {
            $("<%= CountRate2TextBox.ClientID %>").value = GetCountRate($("<%= Counts2TextBox.ClientID %>").value, $("<%= CountingTimeTextBox.ClientID %>").value);
            $("<%= MeanTextBox.ClientID %>").value = GetMean($("<%= CountRate1TextBox.ClientID %>").value, $("<%= CountRate2TextBox.ClientID %>").value, $("<%= CountRate3TextBox.ClientID %>").value);
            $("<%= BGCRTextBox.ClientID %>").value = $("<%= MeanTextBox.ClientID %>").value;
        }

        function Counts3TextBox_TextChanged()
        {
            $("<%= CountRate3TextBox.ClientID %>").value = GetCountRate($("<%= Counts3TextBox.ClientID %>").value, $("<%= CountingTimeTextBox.ClientID %>").value);
            $("<%= MeanTextBox.ClientID %>").value = GetMean($("<%= CountRate1TextBox.ClientID %>").value, $("<%= CountRate2TextBox.ClientID %>").value, $("<%= CountRate3TextBox.ClientID %>").value);
            $("<%= BGCRTextBox.ClientID %>").value = $("<%= MeanTextBox.ClientID %>").value;
        }

        function CountingTimeTextBox_TextChanged()
        {
            $("<%= CountRate1TextBox.ClientID %>").value = GetCountRate($("<%= Counts1TextBox.ClientID %>").value, $("<%= CountingTimeTextBox.ClientID %>").value);
            $("<%= CountRate2TextBox.ClientID %>").value = GetCountRate($("<%= Counts2TextBox.ClientID %>").value, $("<%= CountingTimeTextBox.ClientID %>").value);
            $("<%= CountRate3TextBox.ClientID %>").value = GetCountRate($("<%= Counts3TextBox.ClientID %>").value, $("<%= CountingTimeTextBox.ClientID %>").value);

            $("<%= MeanTextBox.ClientID %>").value = GetMean($("<%= CountRate1TextBox.ClientID %>").value, $("<%= CountRate2TextBox.ClientID %>").value, $("<%= CountRate3TextBox.ClientID %>").value);
            $("<%= BGCRTextBox.ClientID %>").value = $("<%= MeanTextBox.ClientID %>").value;
        }

        //trail

        function GetEfficiency( mean,  pa)
        {
            if (mean == '' || isNaN(mean)) { mean = 0; };
            if (pa == '' || isNaN(pa)) { pa = 0; };
            return (Number(mean) * 100 / (60 * Number(pa) * 1000));
        }
        function S1T1_TextChanged()
        {
           $("<%= M1.ClientID %>").value  = GetMean( $("<%= S1T1.ClientID %>").value ,  $("<%= S1T2.ClientID %>").value ,  $("<%= S1T3.ClientID %>").value );
           $("<%= E1.ClientID %>").value  = GetEfficiency($("<%= M1.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }
        function S1T2_TextChanged()
        {
           $("<%= M1.ClientID %>").value  = GetMean( $("<%= S1T1.ClientID %>").value ,  $("<%= S1T2.ClientID %>").value ,  $("<%= S1T3.ClientID %>").value );
           $("<%= E1.ClientID %>").value  = GetEfficiency($("<%= M1.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S1T3_TextChanged()
        {
           $("<%= M1.ClientID %>").value  = GetMean( $("<%= S1T1.ClientID %>").value ,  $("<%= S1T2.ClientID %>").value ,  $("<%= S1T3.ClientID %>").value );
           $("<%= E1.ClientID %>").value  = GetEfficiency($("<%= M1.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S2T1_TextChanged()
        {
            $("<%= M2.ClientID %>").value  = GetMean( $("<%= S2T1.ClientID %>").value ,  $("<%= S2T2.ClientID %>").value ,  $("<%= S2T3.ClientID %>").value );
           $("<%= E2.ClientID %>").value  = GetEfficiency($("<%= M2.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S2T2_TextChanged()
        {
            $("<%= M2.ClientID %>").value  = GetMean( $("<%= S2T1.ClientID %>").value ,  $("<%= S2T2.ClientID %>").value ,  $("<%= S2T3.ClientID %>").value );
           $("<%= E2.ClientID %>").value  = GetEfficiency($("<%= M2.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S2T3_TextChanged()
        {
             $("<%= M2.ClientID %>").value  = GetMean( $("<%= S2T1.ClientID %>").value ,  $("<%= S2T2.ClientID %>").value ,  $("<%= S2T3.ClientID %>").value );
           $("<%= E2.ClientID %>").value  = GetEfficiency($("<%= M2.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S3T1_TextChanged()
        {
            $("<%= M3.ClientID %>").value  = GetMean( $("<%= S3T1.ClientID %>").value ,  $("<%= S3T2.ClientID %>").value ,  $("<%= S3T3.ClientID %>").value );
           $("<%= E3.ClientID %>").value  = GetEfficiency($("<%= M3.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S3T2_TextChanged()
        {
           $("<%= M3.ClientID %>").value  = GetMean( $("<%= S3T1.ClientID %>").value ,  $("<%= S3T2.ClientID %>").value ,  $("<%= S3T3.ClientID %>").value );
           $("<%= E3.ClientID %>").value  = GetEfficiency($("<%= M3.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S3T3_TextChanged()
        {
           $("<%= M3.ClientID %>").value  = GetMean( $("<%= S3T1.ClientID %>").value ,  $("<%= S3T2.ClientID %>").value ,  $("<%= S3T3.ClientID %>").value );
           $("<%= E3.ClientID %>").value  = GetEfficiency($("<%= M3.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S4T1_TextChanged()
        {
           $("<%= M4.ClientID %>").value  = GetMean( $("<%= S4T1.ClientID %>").value ,  $("<%= S4T2.ClientID %>").value ,  $("<%= S4T3.ClientID %>").value );
           $("<%= E4.ClientID %>").value  = GetEfficiency($("<%= M4.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S4T2_TextChanged()
        {
           $("<%= M4.ClientID %>").value  = GetMean( $("<%= S4T1.ClientID %>").value ,  $("<%= S4T2.ClientID %>").value ,  $("<%= S4T3.ClientID %>").value );
           $("<%= E4.ClientID %>").value  = GetEfficiency($("<%= M4.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S4T3_TextChanged()
        {
           $("<%= M4.ClientID %>").value  = GetMean( $("<%= S4T1.ClientID %>").value ,  $("<%= S4T2.ClientID %>").value ,  $("<%= S4T3.ClientID %>").value );
           $("<%= E4.ClientID %>").value  = GetEfficiency($("<%= M4.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S5T1_TextChanged()
        {
           $("<%= M5.ClientID %>").value  = GetMean( $("<%= S5T1.ClientID %>").value ,  $("<%= S5T2.ClientID %>").value ,  $("<%= S5T3.ClientID %>").value );
           $("<%= E5.ClientID %>").value  = GetEfficiency($("<%= M5.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S5T2_TextChanged()
        {
           $("<%= M5.ClientID %>").value  = GetMean( $("<%= S5T1.ClientID %>").value ,  $("<%= S5T2.ClientID %>").value ,  $("<%= S5T3.ClientID %>").value );
           $("<%= E5.ClientID %>").value  = GetEfficiency($("<%= M5.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S5T3_TextChanged()
        {
           $("<%= M5.ClientID %>").value  = GetMean( $("<%= S5T1.ClientID %>").value ,  $("<%= S5T2.ClientID %>").value ,  $("<%= S5T3.ClientID %>").value );
           $("<%= E5.ClientID %>").value  = GetEfficiency($("<%= M5.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S6T1_TextChanged()
        {
           $("<%= M6.ClientID %>").value  = GetMean( $("<%= S6T1.ClientID %>").value ,  $("<%= S6T2.ClientID %>").value ,  $("<%= S6T3.ClientID %>").value );
           $("<%= E6.ClientID %>").value  = GetEfficiency($("<%= M6.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S6T2_TextChanged()
        {
           $("<%= M6.ClientID %>").value  = GetMean( $("<%= S6T1.ClientID %>").value ,  $("<%= S6T2.ClientID %>").value ,  $("<%= S6T3.ClientID %>").value );
           $("<%= E6.ClientID %>").value  = GetEfficiency($("<%= M6.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S6T3_TextChanged()
        {
           $("<%= M6.ClientID %>").value  = GetMean( $("<%= S6T1.ClientID %>").value ,  $("<%= S6T2.ClientID %>").value ,  $("<%= S6T3.ClientID %>").value );
           $("<%= E6.ClientID %>").value  = GetEfficiency($("<%= M6.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S7T1_TextChanged()
        {
           $("<%= M7.ClientID %>").value  = GetMean( $("<%= S7T1.ClientID %>").value ,  $("<%= S7T2.ClientID %>").value ,  $("<%= S7T3.ClientID %>").value );
           $("<%= E7.ClientID %>").value  = GetEfficiency($("<%= M7.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S7T2_TextChanged()
        {
            $("<%= M7.ClientID %>").value  = GetMean( $("<%= S7T1.ClientID %>").value ,  $("<%= S7T2.ClientID %>").value ,  $("<%= S7T3.ClientID %>").value );
           $("<%= E7.ClientID %>").value  = GetEfficiency($("<%= M7.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S7T3_TextChanged()
        {
            $("<%= M7.ClientID %>").value  = GetMean( $("<%= S7T1.ClientID %>").value ,  $("<%= S7T2.ClientID %>").value ,  $("<%= S7T3.ClientID %>").value );
           $("<%= E7.ClientID %>").value  = GetEfficiency($("<%= M7.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S8T1_TextChanged()
        {
           $("<%= M8.ClientID %>").value  = GetMean( $("<%= S8T1.ClientID %>").value ,  $("<%= S8T2.ClientID %>").value ,  $("<%= S8T3.ClientID %>").value );
           $("<%= E8.ClientID %>").value  = GetEfficiency($("<%= M8.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
            doubtFulFormulas();
        }

        function S8T2_TextChanged()
        {
            $("<%= M8.ClientID %>").value  = GetMean( $("<%= S8T1.ClientID %>").value ,  $("<%= S8T2.ClientID %>").value ,  $("<%= S8T3.ClientID %>").value );
            $("<%= E8.ClientID %>").value  = GetEfficiency($("<%= M8.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
            doubtFulFormulas();
        }

        function S8T3_TextChanged()
        {
            $("<%= M8.ClientID %>").value  = GetMean( $("<%= S8T1.ClientID %>").value ,  $("<%= S8T2.ClientID %>").value ,  $("<%= S8T3.ClientID %>").value );
            $("<%= E8.ClientID %>").value  = GetEfficiency($("<%= M8.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
            doubtFulFormulas();
        }

        function S9T1_TextChanged()
        {
           $("<%= M9.ClientID %>").value  = GetMean( $("<%= S9T1.ClientID %>").value ,  $("<%= S9T2.ClientID %>").value ,  $("<%= S9T3.ClientID %>").value );
           $("<%= E9.ClientID %>").value  = GetEfficiency($("<%= M9.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S9T2_TextChanged()
        {
           $("<%= M9.ClientID %>").value  = GetMean( $("<%= S9T1.ClientID %>").value ,  $("<%= S9T2.ClientID %>").value ,  $("<%= S9T3.ClientID %>").value );
           $("<%= E9.ClientID %>").value  = GetEfficiency($("<%= M9.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S9T3_TextChanged()
        {
           $("<%= M9.ClientID %>").value  = GetMean( $("<%= S9T1.ClientID %>").value ,  $("<%= S9T2.ClientID %>").value ,  $("<%= S9T3.ClientID %>").value );
           $("<%= E9.ClientID %>").value  = GetEfficiency($("<%= M9.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S10T1_TextChanged()
        {
           $("<%= M10.ClientID %>").value  = GetMean( $("<%= S10T1.ClientID %>").value ,  $("<%= S10T2.ClientID %>").value ,  $("<%= S10T3.ClientID %>").value );
           $("<%= E10.ClientID %>").value  = GetEfficiency($("<%= M10.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S10T2_TextChanged()
        {
           $("<%= M10.ClientID %>").value  = GetMean( $("<%= S10T1.ClientID %>").value ,  $("<%= S10T2.ClientID %>").value ,  $("<%= S10T3.ClientID %>").value );
           $("<%= E10.ClientID %>").value  = GetEfficiency($("<%= M10.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function S10T3_TextChanged()
        {
           $("<%= M10.ClientID %>").value  = GetMean( $("<%= S10T1.ClientID %>").value ,  $("<%= S10T2.ClientID %>").value ,  $("<%= S10T3.ClientID %>").value );
           $("<%= E10.ClientID %>").value  = GetEfficiency($("<%= M10.ClientID %>").value , $("<%= PATextBox.ClientID %>").value );
        }

        function doubtFulFormulas()
        {
            $("<%= KTextBox.ClientID %>").value = Number(($N("<%= E8.ClientID %>") * $N("<%= SCTTextBox.ClientID %>")) / 100);
            $("<%= ETextBox.ClientID %>").value = $("<%= E8.ClientID %>").value;
            var MDA = Math.round(Math.sqrt($("<%= MeanTextBox.ClientID %>").value == '' ? 0 : $N("<%= MeanTextBox.ClientID %>") * $N("<%= SCTTextBox.ClientID %>") * (1 + $N("<%= SCTTextBox.ClientID %>") / $N("<%= BCTTextBox.ClientID %>"))) * 3.29 + 3, 2);
            $("<%= MDATextBox.ClientID %>").value = Math.round(Number(MDA) / ($N("<%= ETextBox.ClientID %>") * $N("<%= SCTTextBox.ClientID %>")  * 100), 2);
            $("<%= MDA2TextBox.ClientID %>").value = Number($N("<%= MDATextBox.ClientID %>") / 60);
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div>

        <div style="display: inline-grid" id="section-to-print">
            <asp:Panel ID="EditPanel" runat="server" Style="display: inline-grid">
                <h2>Performance Check of Geiger Counting System</h2>
                <div style="align-content: flex-end">
                    <asp:Label ID="InitialActivity" runat="server" Text="Initial_Activity"></asp:Label>  &nbsp;&nbsp;
                <asp:TextBox ID="InitialActivityTextBox" runat="server" AutoPostBack="true" OnTextChanged="InitialActivityTextBox_TextChanged"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date &nbsp;&nbsp;
                <input id="DateTextBoxDatePicker" type="date" onchange="fnSetDateTime('DateTextBox',true)" />
                    <asp:HiddenField ID="DateTextBox" runat="server" OnValueChanged="DateTextBox_TextChanged" />
                </div>
                <%-- <div style="align-content:flex-end">
                    Initial_Activity &nbsp;&nbsp; <asp:TextBox ID="InitialActivityTextBox"  runat="server" AutoPostBack="true" OnTextChanged="InitialActivityTextBox_TextChanged"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Date &nbsp;&nbsp; <input id="DateTextBoxDatePicker"   type ="date"   onchange="fnSetDateTime('DateTextBox')"/>
                    <asp:HiddenField ID="DateTextBox" runat="server" OnValueChanged="DateTextBox_TextChanged" />
                 </div>--%>
                <table border="1">
                    <tr>
                        <td>Source
                        </td>
                        <td>
                            <asp:TextBox ID="SourceTextBox" Text="Sr-90+Y-90, 2.9 kBq as on 10/08/2010" runat="server"
                                Width="200px"></asp:TextBox>
                        </td>
                        <td>Source UIN
                        </td>
                        <td>
                            <asp:TextBox ID="SourceUINTextBox" Text="KK-HPU-S-SR90-003K-01" runat="server"></asp:TextBox>
                        </td>
                        <td>As_on
                        </td>
                        <td>
                            <input id="AsOnTextBoxDatePicker" type="date" onchange="fnSetDateTime('AsOnTextBox',true)" />
                            <asp:HiddenField ID="AsOnTextBox" runat="server"   OnValueChanged="AsOnTextBox_TextChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>GCS
                        </td>
                        <td>
                            <asp:DropDownList ID="GCSDropDownList" runat="server">
                                <asp:ListItem>GCS-180359023</asp:ListItem> 
                                <asp:ListItem>Nucleonix :07/04/094</asp:ListItem>
                                <asp:ListItem>GCS-180/87</asp:ListItem>
                                <asp:ListItem>GCS-155/79</asp:ListItem>
                                <asp:ListItem>GCS-1802480214</asp:ListItem>
                                <asp:ListItem>GCS-180359025</asp:ListItem>
                                <asp:ListItem>GCS-180359027</asp:ListItem>
                                <asp:ListItem>GCS-180359026</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>Present activity (KBq) :
                        </td>
                        <td>
                            <asp:TextBox ID="PATextBox" runat="server"></asp:TextBox>
                        </td>
                        <td>Location
                        </td>
                        <td>
                            <asp:TextBox ID="LocationTextBox" Text="UFC" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <h3>1. Background Check</h3>
                <table border="1">
                    <tr>
                        <td>Counting Time (Min)
                        </td>
                        <td>Voltage (Volt)
                        </td>
                        <td>Observation No
                        </td>
                        <td>Counts
                        </td>
                        <td>Count Rate (CPM)
                        </td>
                        <td>Mean (CPM)
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="3">
                            <asp:TextBox ID="CountingTimeTextBox" Text="5" runat="server" AutoPostBack="true"
                                Onchange="return CountingTimeTextBox_TextChanged()"></asp:TextBox>
                        </td>
                        <td rowspan="3">
                            <asp:TextBox ID="VoltageTextBox" Text="900" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="observation1TextBox" Text="1" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Counts1TextBox" runat="server" AutoPostBack="true"  Onchange="return Counts1TextBox_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="CountRate1TextBox" runat="server" Enabled="False" ></asp:TextBox>
                        </td>
                        <td rowspan="3">
                            <asp:TextBox ID="MeanTextBox" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="observation2TextBox" Text="2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Counts2TextBox" runat="server" AutoPostBack="true" Onchange="return Counts2TextBox_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="CountRate2TextBox" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="observation3TextBox" Text="3" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Counts3TextBox" runat="server" AutoPostBack="true" Onchange="return Counts3TextBox_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="CountRate3TextBox" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <h3>2.Efficiency Check :
                </h3>
                <div>
                    (Counts for 60 Seconds) Minimum Detectable Activity (dpm) =
                <asp:TextBox ID="MDATextBox" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp; Minimum Detectable Activity(Bq) =
                <asp:TextBox ID="MDA2TextBox" runat="server"></asp:TextBox>
                </div>
                Efficiency (%) = (CPS/DPS)*100
            <br />
                <table border="1">
                    <tr>
                        <td>SL No.
                        </td>
                        <td>Rack Position
                        </td>
                        <td>Trail 1
                        </td>
                        <td>Trail 2
                        </td>
                        <td>Trail 3
                        </td>
                        <td>Mean
                        </td>
                        <td>Efficiency (%)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S1" Text="1" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R1" Text="10th Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S1T1" runat="server" AutoPostBack="true" Onchange="return S1T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S1T2" runat="server" AutoPostBack="true" Onchange="return S1T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S1T3" runat="server" AutoPostBack="true" Onchange="return S1T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M1" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E1" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S2" Text="2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R2" Text="9th Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S2T1" runat="server" AutoPostBack="true" Onchange="return S2T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S2T2" runat="server" AutoPostBack="true" Onchange="return S2T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S2T3" runat="server" AutoPostBack="true" Onchange="return S2T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M2" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E2" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S3" Text="3" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R3" Text="8th Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S3T1" runat="server" AutoPostBack="true" Onchange="return S3T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S3T2" runat="server" AutoPostBack="true" Onchange="return S3T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S3T3" runat="server" AutoPostBack="true" Onchange="return S3T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M3" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E3" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S4" Text="4" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R4" Text="7th Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S4T1" runat="server" AutoPostBack="true" Onchange="return S4T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S4T2" runat="server" AutoPostBack="true" Onchange="return S4T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S4T3" runat="server" AutoPostBack="true" Onchange="return S4T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M4" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E4" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S5" Text="5" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R5" Text="6th Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S5T1" runat="server" AutoPostBack="true" Onchange="return S5T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S5T2" runat="server" AutoPostBack="true" Onchange="return S5T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S5T3" runat="server" AutoPostBack="true" Onchange="return S5T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M5" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E5" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S6" Text="6" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R6" Text="5th Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S6T1" runat="server" AutoPostBack="true" Onchange="return S6T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S6T2" runat="server" AutoPostBack="true" Onchange="return S6T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S6T3" runat="server" AutoPostBack="true" Onchange="return S6T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M6" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E6" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S7" Text="7" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R7" Text="4th Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S7T1" runat="server" AutoPostBack="true" Onchange="return S7T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S7T2" runat="server" AutoPostBack="true" Onchange="return S7T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S7T3" runat="server" AutoPostBack="true" Onchange="return S7T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M7" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E7" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S8" Text="8" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R8" Text="3rd Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S8T1" runat="server" AutoPostBack="true" Onchange="return S8T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S8T2" runat="server" AutoPostBack="true" Onchange="return S8T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S8T3" runat="server" AutoPostBack="true" Onchange="return S8T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M8" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E8" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S9" Text="9" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R9" Text="2nd Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S9T1" runat="server" AutoPostBack="true" Onchange="return S9T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S9T2" runat="server" AutoPostBack="true" Onchange="return S9T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S9T3" runat="server" AutoPostBack="true" Onchange="return S9T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M9" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E9" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="S10" Text="10" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="R10" Text="1st Rack" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S10T1" runat="server" AutoPostBack="true" Onchange="return S10T1_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S10T2" runat="server" AutoPostBack="true" Onchange="return S10T2_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="S10T3" runat="server" AutoPostBack="true" Onchange="return S10T3_TextChanged()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="M10" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="E10" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <h3>3. Minimum Detectable Activity(MDA) : At 3rd rack</h3>
                <table border="1">
                    <tr>
                        <td>1
                        </td>
                        <td>tb = Background count time
                        </td>
                        <td>
                            <asp:TextBox ID="BCTTextBox" Text="5" runat="server"></asp:TextBox>Min
                        </td>
                    </tr>
                    <tr>
                        <td>2
                        </td>
                        <td>tg = Sample count time
                        </td>
                        <td>
                            <asp:TextBox ID="SCTTextBox" Text="1" runat="server"></asp:TextBox>Min
                        </td>
                    </tr>
                    <tr>
                        <td>3
                        </td>
                        <td>rb= Back ground count rate (CPM)
                        </td>
                        <td>
                            <asp:TextBox ID="BGCRTextBox" runat="server" Enabled="False"></asp:TextBox>CPM
                        </td>
                    </tr>
                    <tr>
                        <td>4
                        </td>
                        <td>K * = (Efficiency/100)*tg
                        </td>
                        <td>
                            <asp:TextBox ID="KTextBox" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>5
                        </td>
                        <td>Efficiency =
                        </td>
                        <td>
                            <asp:TextBox ID="ETextBox" runat="server" Enabled="False"></asp:TextBox>%
                        </td>
                    </tr>
                </table>
                <br />
                <div>
                    Performace checked by :&nbsp;&nbsp;
                <asp:DropDownList ID="PerformaceCheckedByDropDownList" runat="server">
                    <asp:ListItem>Sreejith S SA/E</asp:ListItem>
                    <asp:ListItem>Ajeesh SA/E</asp:ListItem>
                    <asp:ListItem>Arun Krishnan SA/D</asp:ListItem>
                    <asp:ListItem>Tamil Selvan L SA/B</asp:ListItem>
                </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp; Reviewed by :&nbsp;
                <asp:DropDownList ID="ReviewedByDropDownList" runat="server">
                    <asp:ListItem>Ratheesh S, SO/E</asp:ListItem>
                    <asp:ListItem>Arun Krishnan SA/D</asp:ListItem>
                </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp; Issued by :&nbsp;
                <asp:DropDownList ID="IssuedByDropDownList" runat="server">
                    <asp:ListItem>NK Asokan, Station HP&RSO</asp:ListItem>
                </asp:DropDownList>
                </div>
            </asp:Panel>
        </div>

        <div style="display: inline-grid; width: 20px;">
        </div>
        <div style="display: inline-grid; width: 180px;">
            <br />
            <br />
            <br />
            Search Id
                <asp:DropDownList ID="SearchIdDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SearchIdDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="PrintButton" runat="server" Text="Print" OnClientClick="return display()" />
            <br />
            <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" />
            <br />
            <asp:Button ID="SaveButton" runat="server" Text="Add Record" OnClick="SaveButton_Click"
                OnClientClick=" return fnConfirmSave()" />
            <asp:Button ID="EditButton" runat="server" Text="Edit" Style="height: 26px" OnClick="EditButton_Click" />
            <asp:Button ID="UpdateButton" runat="server" Text="Save" Style="height: 26px" OnClick="UpdateButton_Click"  />
            <br />
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click"
                OnClientClick=" return fnConfirmDelete()" />
            <br />
            <asp:Label ID="CreatedByLabel" runat="server" Text="Created By : "></asp:Label>
            <asp:DropDownList ID="CreatedByDropDownList" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="CreatedDateLabel" runat="server" Text="Created Date :"></asp:Label>
            <asp:Label ID="CreatedDateValueLabel" runat="server"></asp:Label>
            <%--<input id="CreatedDateTextBoxDatePicker" visible ="false"  type="date" onchange="fnSetDateTime('CreatedDateTextBox')" />
                <asp:HiddenField ID="CreatedDateTextBox" runat="server" />--%>
            <br />
            <asp:Label ID="ModifiedDateLabel" runat="server" Text="Modified Date : "></asp:Label>
            <asp:Label ID="ModifiedDateValueLabel" runat="server"></asp:Label>
            <%--<input id="ModifiedDateTextBoxDatePicker" visible="false"  type="date" onchange="fnSetDateTime('ModifiedDateTextBox')" />
                <asp:HiddenField ID="ModifiedDateTextBox" runat="server" />--%>
            <br />
            <asp:Label ID="ModifiedByLabel" runat="server" Text="Modified By : "></asp:Label>
            <asp:DropDownList ID="ModifiedByDropDownList" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="ModifiedByDropDownList_SelectedIndexChanged">
            </asp:DropDownList>

            <br />
            <asp:Label ID="RemarksLabel" runat="server" Text="Remarks : "></asp:Label>
            <asp:TextBox ID="RemarksTextBox" runat="server"></asp:TextBox>
        </div>
    </div>
    <script type="text/javascript">

        if (document.getElementById('<%= DateTextBox.ClientID %>').value.toString() == "") {
            document.getElementById('DateTextBoxDatePicker').valueAsDate = new Date();
        }
        else {
            document.getElementById('DateTextBoxDatePicker').valueAsDate = new Date(document.getElementById('<%= DateTextBox.ClientID %>').value.toString());
        }


        if (document.getElementById('<%= AsOnTextBox.ClientID %>').value == "") {
            document.getElementById('AsOnTextBoxDatePicker').valueAsDate = new Date();
        }
        else {
            document.getElementById('AsOnTextBoxDatePicker').valueAsDate = new Date(document.getElementById('<%= AsOnTextBox.ClientID %>').value.toString());
        }




        fnSetDateTime('DateTextBox', false);
        fnSetDateTime('AsOnTextBox', false);

    </script>
</asp:Content>

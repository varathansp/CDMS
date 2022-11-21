<%@ Page Language="C#" MasterPageFile="CustomeControls/CDMS.Master" AutoEventWireup="true"
    CodeBehind="DataView.aspx.cs" Inherits="CDMS_WebApp1._0.DataView" %>

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
        .style2
        {
            height: 26px;
            position: absolute;
            left: 1040px;
            top: 220px;
            width: 73px;
        }
        .style4
        {
            height: 26px;
            position: absolute;
            left: 967px;
            top: 219px;
            width: 78px;
        }
        .style5
        {
            height: 82px;
        }
    </style>
    <script lang="javascript" type="text/javascript">
        function fnSetDateTime(control) {
            switch (control) {
                case "FromDateTextBox":
                    document.getElementById('<%= FromDateTextBox.ClientID %>').value = document.getElementById("FromDateDatePicker").value;
                case "ToDateTextBox":
                    document.getElementById('<%= ToDateTextBox.ClientID %>').value = document.getElementById("ToDateDatePicker").value;

                default:

            }
        }

        function DataPrint() {
            window.print();
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div>
        <h2>
            Data Log View</h2>
        <table>
            <tr>
                <td class="style5">
                    From :
                    <input id="FromDateDatePicker" type="date" onchange="fnSetDateTime('FromDateTextBox')" />
                    <asp:HiddenField ID="FromDateTextBox" runat="server" />
                </td>
                <td class="style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To :
                    <input id="ToDateDatePicker" type="date" onchange="fnSetDateTime('ToDateTextBox')" />
                    <asp:HiddenField ID="ToDateTextBox" runat="server" />
                </td>
                <td class="style5">
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select :
                    <asp:DropDownList ID="SmearDropDownList" runat="server" Width="171px" AutoPostBack="true" OnSelectedIndexChanged="SmearDropDownList_SelectedIndexChanged" >
                        <Items>
                            <asp:ListItem Text="Select" Value="" />
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="valueLabel" runat="server" Text="Contamination Level :"></asp:Label>
                    <asp:TextBox ID="Contamination_LevelTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                 Shift :
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" 
                        style="margin-left: 0px" Width="66px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>I</asp:ListItem>
                        <asp:ListItem>II</asp:ListItem>
                        <asp:ListItem>III</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ShowButton" runat="server" Text="Show" 
                        OnClick="ShowButton_Click" CssClass="style4" />
                </td>
                <td class="style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="PrintButton" runat="server" Text="Print" 
                        Visible="false" OnClientClick="return DataPrint()" CssClass="style2" />
                </td>
            </tr>
        </table>
    </div>
    <div id="section-to-print">
        <asp:Label ID="HeaderLabel" runat="server" Text="" Width="683px" 
            Height="31px" Font-Size="Larger" Font-Bold="true"></asp:Label>  
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="sl_no">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="OpenButton" runat="server" CausesValidation="false" Text="Open" CommandArgument='<%# Eval("sl_no") %>'
                            OnClick="GridView1_SelectedIndexChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server">
            <Columns>
                <asp:TemplateField ShowHeader="False"></asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <script type="text/javascript">
        if (document.getElementById('<%= FromDateTextBox.ClientID %>').value.toString() == "") {
            document.getElementById('FromDateDatePicker').valueAsDate = new Date();
        }
        else {
            document.getElementById('FromDateDatePicker').valueAsDate = new Date(document.getElementById('<%= FromDateTextBox.ClientID %>').value.toString());
        }
        if (document.getElementById('<%= ToDateTextBox.ClientID %>').value == "") {
            document.getElementById('ToDateDatePicker').valueAsDate = new Date();
        }
        else {
            document.getElementById('ToDateDatePicker').valueAsDate = new Date(document.getElementById('<%= ToDateTextBox.ClientID %>').value.toString());
        }
        fnSetDateTime('FromDateTextBox');
        fnSetDateTime('ToDateTextBox');
              
    </script>
</asp:Content>

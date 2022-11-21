<%@ Page Language="C#" MasterPageFile="CustomeControls/CDMS.Master" AutoEventWireup="true" CodeBehind="AddShift.aspx.cs" Inherits="CDMS_WebApp1._0.AddShift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
   
    
    <div style="display:inline-flex; height: 818px; width: 946px; background-color: #FFFFFF;">
        <div >
            <table >
                <tr>
                    <td colspan="2">
                        <h3>Crew Details</h3>
                    </td>
                </tr>
                <tr>
                    <td>Date</td>
                    <td>
                        <asp:TextBox ID="DateText" runat="server" Height="19px" Width="167px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>Shift</td>
                    <td>
                        <asp:DropDownList ID="ShiftDropDownList" runat="server" OnSelectedIndexChanged="ShiftDropDownList_SelectedIndexChanged" AutoPostBack="true" Width="171px">
                            <asp:ListItem>I</asp:ListItem>
                            <asp:ListItem>II</asp:ListItem>
                            <asp:ListItem>III</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>Crew</td>
                    <td>
                        <asp:DropDownList ID="CrewDropDownList" runat="server" OnSelectedIndexChanged="CrewDropDownList_SelectedIndexChanged" AutoPostBack="true" Width="171px">
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>D</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td></td>
                    <td>(Select Crew)</td>
                </tr>

            </table>

        </div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
        <div >
            <table class="style2">
                <tr>
                    <td colspan="2">
                        <h3>Sample Counted by </h3>
                    </td>
                </tr>
                <tr>
                    <td class="style3">Shift Technician</td>
                    <td class="style5">
                        <asp:DropDownList ID="ShiftTechnicianDropDownList" runat="server" Width="171px">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td class="style3">T2 Technician</td>
                    <td class="style5">
                        <asp:DropDownList ID="T2TechnicianDropDownList" runat="server" Width="171px">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td class="style3">Contract Staff 1</td>
                    <td class="style5">
                        <asp:DropDownList ID="ContractStaff1DropDownList" runat="server" Width="171px">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td class="style3">Contract Staff 2</td>
                    <td class="style5">
                        <asp:DropDownList ID="ContractStaff2DropDownList" runat="server" Width="171px">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td class="style3">Contract Staff 3</td>
                    <td class="style5">
                        <asp:DropDownList ID="ContractStaff3DropDownList" runat="server" Width="171px">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
            </table>
        </div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <div  >
                <table class="style6" >
                    <tr>
                        <td colspan="2">
                            <h3>Checked by</h3>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">Shift Health Physicist 1</td>
                        <td class="style5">
                            <asp:DropDownList ID="Physicist1DropDownList" runat="server" Width="171px">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    &nbsp;<tr>
                        <td class="style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            Review</td>
                        <td class="style5">
                            <asp:TextBox ID="Physicist1Notes" runat="server" Width="169px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="style7">Shift Health Physicist 2</td>
                        <td class="style5">
                            <asp:DropDownList ID="Physicist2DropDownList" runat="server" Width="171px">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="background-color: #FFFFFF"></td>
                    </tr>
                    &nbsp;<tr>
                        <td class="style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            Review</td>
                        <td class="style5">
                            <asp:TextBox ID="Physicist2Notes" runat="server" Width="170px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="style7">Shift Health Physicist (RSD)</td>
                        <td class="style5">
                            <asp:DropDownList ID="PhysicistRSDDropDownList" runat="server" Width="171px">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2">
        <asp:Button ID="AddShiftButton" runat="server" Text="Add Shift" OnClick="AddShiftButton_Click" />
                        </td>
                    </tr>
                </table>
            </div>
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <div style="position:relative; top: -1px; left: 1px;">
            <div style="position:absolute; top:50%;left:50%">
            </div>
    </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style2
        {
            width: 304px;
        }
        .style3
        {
            width: 123px;
        }
        .style5
        {
            width: 171px;
        }
        .style6
        {
            width: 351px;
        }
        .style7
        {
            width: 170px;
        }
    </style>

</asp:Content>

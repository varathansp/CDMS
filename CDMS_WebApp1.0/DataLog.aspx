<%@ Page Language="C#" MasterPageFile="CustomeControls/CDMS.Master" AutoEventWireup="true" CodeBehind="DataLog.aspx.cs" Inherits="CDMS_WebApp1._0.DataLog" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">  
    <script lang="javascript" type="text/javascript">

        function fnConfirmSave() {
            return confirm("Are you sure to save?");
        }
        function fnConfirmDelete() {
            return confirm("Are you sure to Delete?");
        }
        function fnConfirmEdit() {
            return confirm("Are you sure to Edit?");
        }
        function fnConfirmSaveAfterEdit() {
            return confirm("Are you sure to save the edited record?");
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 242px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h2 style="text-align: center">Data Log for Counting Instruments</h2>
    <div style="display: inline-flex">
        <div>
            Serach Record : 
         <asp:DropDownList ID="SearchDropDownList" runat="server" Width="160px"></asp:DropDownList>

            <asp:Button ID="SearchButton" runat="server" Text="Go" OnClick="SearchButton_Click" />
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <div>Sl.No 
            <asp:DropDownList ID="SLNODropDownList" runat="server" Width="160px"></asp:DropDownList></div>

        &nbsp;&nbsp;&nbsp;&nbsp;
        <div>
            <%--<asp:Button ID="AddShiftButton" runat="server" Text="Add Shift" Width="111px" OnClick="AddShiftButton_Click" />--%>
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <div>
            <asp:Button ID="InitialAddRecord" runat="server" Text="Add Record" Width="111px" OnClick="InitialAddRecord_Click"  />
        </div>
    </div>
   
    <br />
    <div style="display: inline-flex"  >
         <asp:Panel ID= "DataEntryPanel"  runat = "server">
        <div style="flex: 1;">
            <table>
                <tr>
                    <td colspan="2">
                        <h3>Data Entry</h3>
                    </td>
                </tr>
                <tr>
                    <td>Unit</td>
                    <td>
                        <asp:DropDownList ID="UnitDropDownList" runat="server" Width="171px" AutoPostBack="true" OnSelectedIndexChanged="UnitDropDownList_SelectedIndexChanged">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>Plant Status</td>
                    <td>
                        <asp:DropDownList ID="PlantStatusDropDownList" runat="server" Width="171px">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                                <asp:ListItem>Operating</asp:ListItem>
                                <asp:ListItem>ShutDown</asp:ListItem>
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>Status</td>
                    <td>
                        <asp:DropDownList ID="StatusDropDownList" runat="server" Width="171px" AutoPostBack="true" OnSelectedIndexChanged="StatusDropDownList_SelectedIndexChanged">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>Sample Description</td>
                    <td>
                        <asp:DropDownList ID="SampleDescriptionDropDownList" runat="server" Width="171px">
                            <Items>
                                <asp:ListItem Text="Select" Value=" " />
                            </Items>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
            </table>
        </div>
              </asp:Panel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           <asp:Panel ID= "BGCPanel"  runat = "server">
         <div style="flex: 1;">
                <table border="0">
                    <tr>
                        <td colspan="2">
                            <h3>Background Checking</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Location Unit</td>
                        <td>
                            <asp:DropDownList ID="LocationUnitDropDownList" runat="server" Width="171px" AutoPostBack="true" OnSelectedIndexChanged="LocationUnitDropDownList_SelectedIndexChanged">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                    <asp:ListItem>0</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Counting System</td>
                        <td>
                            <asp:DropDownList ID="CountingSystemDropDownList" runat="server" Width="171px" AutoPostBack="true" OnSelectedIndexChanged="CountingSystemDropDownList_SelectedIndexChanged">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Rack</td>
                        <td>
                            <asp:DropDownList ID="RackDropDownList" runat="server" Width="171px" AutoPostBack="true" OnSelectedIndexChanged="RackDropDownList_SelectedIndexChanged">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Counter Efficiency</td>
                        <td>
                            <asp:TextBox ID="CounterEfficiencyTextBox" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Intrument Location</td>
                        <td>
                            <asp:DropDownList ID="InstrumentLocationDropDownList" runat="server" Width="171px">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>As on</td>
                        <td>
                            <asp:TextBox ID="AsON" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>BKG Counts</td>
                        <td>
                            <asp:TextBox ID="BKGCountsTextBox" runat="server" OnTextChanged="BKGCountsTextBox_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                </table>
            </div>
               </asp:Panel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Panel ID= "MaterialPanel"  runat = "server">    
        <div style="flex: 1;">
                <table border="0">
                    <tr>
                        <td colspan="2">
                            <h3>Material Clearance</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Material Id</td>
                        <td>
                            <asp:TextBox ID="MaterialIdTextBox" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Purpose </td>
                        <td>
                            <asp:DropDownList ID="PurposeDropDownList" runat="server" Width="171px">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                    <asp:ListItem>Shifting</asp:ListItem>
                                    <asp:ListItem>For Service</asp:ListItem>
                                    <asp:ListItem>Maintenance</asp:ListItem>
                                    <asp:ListItem>Replacement</asp:ListItem>
                                    <asp:ListItem>Response checks</asp:ListItem>
                                    <asp:ListItem>Overhandling</asp:ListItem>
                                    <asp:ListItem>Calibration</asp:ListItem>
                                    <asp:ListItem>PM Checks</asp:ListItem>
                                    <asp:ListItem>Testing</asp:ListItem>
                                    <asp:ListItem>Grinding</asp:ListItem>
                                    <asp:ListItem>Scrapyard</asp:ListItem>
                                    <asp:ListItem>Sampling</asp:ListItem>
                                    <asp:ListItem>Survey</asp:ListItem>
                                    <asp:ListItem>Disposal</asp:ListItem>
                                    <asp:ListItem>Refill</asp:ListItem>
                                    <asp:ListItem>Welding</asp:ListItem>
                                    <asp:ListItem>For Storage</asp:ListItem>
                                    <asp:ListItem>Return</asp:ListItem>
                                    <asp:ListItem>Polising</asp:ListItem>
                                    <asp:ListItem>Wood cleaning</asp:ListItem>
                                    <asp:ListItem>Checking</asp:ListItem>

                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Location From</td>
                        <td>
                            <asp:DropDownList ID="LocationFromDropDownList" runat="server" Width="171px">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                    <asp:ListItem>1UJA</asp:ListItem>
                                    <asp:ListItem>1UJB</asp:ListItem>
                                    <asp:ListItem>1UKA</asp:ListItem>
                                    <asp:ListItem>1UKC</asp:ListItem>
                                    <asp:ListItem>1UKB</asp:ListItem>
                                    <asp:ListItem>1UMA</asp:ListItem>
                                    <asp:ListItem>1UBA</asp:ListItem>
                                    <asp:ListItem>1UQA</asp:ListItem>
                                    <asp:ListItem>0UYB</asp:ListItem>
                                    <asp:ListItem>0UKU</asp:ListItem>
                                    <asp:ListItem>0UKS</asp:ListItem>
                                    <asp:ListItem>0UJY</asp:ListItem>
                                    <asp:ListItem>0UQR</asp:ListItem>
                                    <asp:ListItem>0UTF</asp:ListItem>
                                    <asp:ListItem>0UFC</asp:ListItem>
                                    <asp:ListItem>0UAC</asp:ListItem>
                                    <asp:ListItem>2UJA</asp:ListItem>
                                    <asp:ListItem>2UJB</asp:ListItem>
                                    <asp:ListItem>2UKA</asp:ListItem>
                                    <asp:ListItem>2UKC</asp:ListItem>
                                    <asp:ListItem>2UKB</asp:ListItem>
                                    <asp:ListItem>2UMA</asp:ListItem>
                                    <asp:ListItem>2UBA</asp:ListItem>
                                    <asp:ListItem>2UQA</asp:ListItem>
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Location To</td>
                        <td>
                            <asp:DropDownList ID="LocationToDropDownList" runat="server" Width="171px">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                    <asp:ListItem>0UKU                   </asp:ListItem>
                                    <asp:ListItem>0UKS                   </asp:ListItem>
                                    <asp:ListItem>0USV                   </asp:ListItem>
                                    <asp:ListItem>1UMA                   </asp:ListItem>
                                    <asp:ListItem>1UBA                   </asp:ListItem>
                                    <asp:ListItem>1UQA                   </asp:ListItem>
                                    <asp:ListItem>2UMA                   </asp:ListItem>
                                    <asp:ListItem>2UBA                   </asp:ListItem>
                                    <asp:ListItem>2UQA                   </asp:ListItem>
                                    <asp:ListItem>DM PLANT               </asp:ListItem>
                                    <asp:ListItem>NTC                    </asp:ListItem>
                                    <asp:ListItem>Outside Operating Plant</asp:ListItem>
                                </Items>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Requested By</td>
                        <td>
                            <asp:TextBox ID="RequestedByTextBox" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Material Counted By</td>
                        <td>
                            <asp:DropDownList ID="MaterialCountedByDropDownList" runat="server" Width="171px">
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
              </asp:Panel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <div>
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:Button ID="EditButton" runat="server" Text="Edit" Width="111px" Visible="false" OnClick="EditButton_Click" />
                            <asp:Button ID="SaveButton" runat="server" Text="Save" Width="111px" Visible="false" OnClick="SaveButton_Click" OnClientClick="fnConfirmSaveAfterEdit()" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" Text="Delete" Visible="false" Width="111px" />
                            <br />
                            </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                </table>
            </div>

    </div>
        
    <hr style="border-width: thick" />
        <asp:Panel ID= "BottomPanel"  runat = "server">
    
    <div style="display: inline-flex;" >
        <div style="">
            <table>
                <tr>
                    <td colspan="3">
                        <h3>Sampling Details for Air Samples</h3>
                    </td>
                </tr>
                <tr>
                    <td>Smear/Air Sample</td>
                    <td>
                        <asp:DropDownList ID="SmearDropDownList" runat="server" Width="171px" 
                            AutoPostBack="true" 
                            OnSelectedIndexChanged="SmearDropDownList_SelectedIndexChanged" 
                            style="height: 22px">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>S</asp:ListItem>
                            </Items>
                        </asp:DropDownList></td>
                        <td><asp:Label ID="HeaderLabel" runat="server" Width="178px"></asp:Label></td>
                    <%--<td class="style1">
                        <asp:Panel ID="Panel2" runat="server" Width="144px">
                            <asp:Label ID="HeaderLabel" runat="server" Width="78px"></asp:Label>
                            <asp:Label ID="DateLabel" runat="server" width="78px"></asp:Label>
                            <asp:Label ID="ValueLabel" runat="server" Width="78px"></asp:Label>
                            <asp:Label ID="RoomNoLabel" runat="server" width="78px"></asp:Label>
                        </asp:Panel>
                    </td>--%>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>Aerosol/Iodine</td>
                    <td>
                        <asp:DropDownList ID="AerosolDropDownList" runat="server" Width="171px">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                                <asp:ListItem>-</asp:ListItem>
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>I</asp:ListItem>
                            </Items>
                        </asp:DropDownList></td>
                    <td class="style1"><asp:Label ID="DateLabel" runat="server" width="178px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>Time of Sampling</td>
                    <td>
                        <asp:TextBox ID="TimeofSamplingTextBox" runat="server"></asp:TextBox>
                    </td>

                    <td class="style1"><asp:Label ID="ValueLabel" runat="server" Width="178px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>Time of Counting</td>
                    <td>
                        <asp:TextBox ID="TimeofCountingTextBox" runat="server" AutoPostBack="true" OnTextChanged="TimeofCountingTextBox_TextChanged"></asp:TextBox></td>
                    <td class="style1">
                        <asp:Label ID="RoomNoLabel" runat="server" width="178px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>Elapsed Time</td>
                    <td>
                        <asp:TextBox ID="ElapsedTimeTextBox" runat="server"></asp:TextBox></td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>Half Life</td>
                    <td>
                        <asp:TextBox ID="HalfLifeTextBox" Text="20" runat="server"></asp:TextBox></td>
                    <td class="style1"></td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>Flowrate(m3/min)</td>
                    <td>
                        <asp:TextBox ID="FlowrateTextBox" runat="server" OnTextChanged="FlowrateTextBox_TextChanged"></asp:TextBox></td>
                    <td class="style1"></td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>Sampling time(min)</td>
                    <td>
                        <asp:TextBox ID="SamplingTimeTextBox" Text="5" runat="server"></asp:TextBox></td>
                    <td class="style1"></td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>Total Air Sampled(m3)</td>
                    <td>
                        <asp:TextBox ID="TotalAirSampledTextBox" runat="server"></asp:TextBox></td>
                    <td class="style1"></td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>

            </table>

        </div>
        <div style="padding-top: 65px">
            <table>
                <tr>
                    <td>Select Activity
                        <br />
                        <asp:DropDownList ID="ActivityDropDownList" runat="server" Width="171px" AutoPostBack="true" OnSelectedIndexChanged="ActivityDropDownList_SelectedIndexChanged">
                            <Items>
                                <asp:ListItem Text="Select" Value="" />
                            </Items>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="LivedTextBox" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Decay Correction Factor
                        <br />
                        <asp:TextBox ID="DecayCorrectionFactorTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Area Correction Factor
                        <br />
                        <asp:TextBox ID="AreaCorrectionFactorTextBox" Text="17.64" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Air Activity(Bq/m3)
                        <br />
                        <asp:TextBox ID="AirActivityTextBox" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>DAC
                        <br />
                        <asp:TextBox ID="DACTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <div style="">
                <table border="0">
                    <tr>
                        <td colspan="2">
                            <h3>Sample Counting Data</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>BKG Count Time (min)</td>
                        <td>
                            <asp:TextBox ID="BKGCountTimeTextBox" Text="1" runat="server" OnTextChanged="BKGCountTimeTextBox_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Sample Count Time (min)</td>
                        <td>
                            <asp:TextBox ID="SampleCountTimeTextBox" Text="1" runat="server" OnTextChanged="SampleCountTimeTextBox_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Sample Counts (CPM)
                            <asp:DropDownList ID="SampleCountsDropDownList" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="SampleCountsDropDownList_SelectedIndexChanged">
                                <Items>
                                    <asp:ListItem Text="Select" Value="" />
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>S</asp:ListItem>
                                </Items>
                            </asp:DropDownList></td>
                        <td>
                            <asp:TextBox ID="SampleCountsTextBox" runat="server" OnTextChanged="SampleCountsTextBox_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Net Counts (CPM)</td>
                        <td>
                            <asp:TextBox ID="NetCountsTextBox" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Total Area Swiped (Bq/cm2)</td>
                        <td>
                            <asp:TextBox ID="TotalAreaSwipedTextBox" runat="server" OnTextChanged="TotalAreaSwipedTextBox_TextChanged"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Contamination Level (Bq/cm2)</td>
                        <td>
                            <asp:TextBox ID="ContaminationLevelTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="2">Remarks</td>

                    </tr>
                    <tr>
                        <td colspan="2" rowspan="5">
                            <asp:TextBox ID="RemarksTextBox" Width="444px" runat="server" Height="65px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        <div style="padding-top: 65px">
            <table>
                <tr>
                    <td>LLD
                        <br />
                        <asp:TextBox ID="LLDTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>MDA (dpm)
                        <br />
                        <asp:TextBox ID="MDAdpmTextBox" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>MDA (Bq)
                        <br />
                        <asp:TextBox ID="MDABqTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>LLD + Bkg counts
                        <br />
                        <asp:TextBox ID="LLDBKGTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <br />
                        <br />
                        
                </tr>

            </table>
        </div>
        <div style="padding-top: 65px">
            <table>
                <tr>
                    <td><%--Building--%>
                        <br />
                        <asp:TextBox ID="BuildingTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td> Contamination Date 
                        <br />
                         <asp:TextBox ID="ContaminationDateTextBox" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                       
                    </td>
                </tr>

                <tr>
                    <td>
                        <br />
                        <br />
                       &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="AddRecordButton" runat="server" Text="Add Record" Width="140px" OnClick="AddRecordButton_Click"  OnClientClick ="return fnConfirmSave()" /></td>
                </tr>

            </table>
        </div>
       
    </div>
        </asp:Panel>
</asp:Content>

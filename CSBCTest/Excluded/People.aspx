<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="People.aspx.vb" Inherits="People" title="People" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 430px; height: 164px">
        <tr>
            <td align="left" colspan="2" rowspan="3">
                <asp:Panel ID="Panel1" runat="server" BackColor="#E0E0E0" BorderColor="Navy" BorderWidth="1px"
                    Height="75px" Width="280px">
                    <asp:Label ID="lblLastSeason" runat="server" Height="20px" Width="280px">Last Played:</asp:Label><br />
                    <asp:Label ID="lblLastRating" runat="server" Height="20px" Width="280px" Visible="False">Last Rating:</asp:Label><br />
                    <asp:LinkButton ID="btnTeam" runat="server" TabIndex="20" Width="279px"></asp:LinkButton><br />
                    <asp:Label ID="lblBalance" runat="server" Height="20px" Width="280px">Balance:</asp:Label></asp:Panel>
            </td>
            <td align="left" style="height: 20px">
                <asp:Label ID="lblLastName" runat="server" Height="20px" Text="Last Name:" Width="120px"></asp:Label></td>
            <td align="left" colspan="3" style="height: 20px" width="150" valign="middle">
                <asp:TextBox ID="txtLastName" runat="server" BorderStyle="Solid" BorderWidth="1px"
                    Height="15px" TabIndex="1" Width="210px"></asp:TextBox></td>
            <td align="left" colspan="1" style="height: 20px">
                <asp:ImageButton ID="imgLastName" runat="server" Height="20px" ImageUrl="~/Images/SEARCH.JPG"
                    TabIndex="2" Width="20px" ToolTip="Search By Last Name" /></td>
            <td align="left" rowspan="2" style="width: 103px">
                <asp:CheckBoxList ID="chkMoney" runat="server" BackColor="#E0E0E0" BorderColor="Navy"
                    BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="20px" RepeatColumns="1"
                    Width="100px" TabIndex="11">
                    <asp:ListItem>Current BM</asp:ListItem>
                    <asp:ListItem>Plays Up</asp:ListItem>
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td align="left" height="20" style="width: 105px">
                <asp:Label ID="lblFirstName" runat="server" Height="20px" Text="First Name:" Width="120px"></asp:Label></td>
            <td align="left" colspan="3" height="20" width="150">
                <asp:TextBox ID="txtFirstName" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="15px"
                    TabIndex="3" Width="210px"></asp:TextBox>
            </td>
            <td align="left" colspan="1" height="20">
                <asp:ImageButton ID="imgFirstName" runat="server" Height="20px" ImageUrl="~/Images/SEARCH.JPG"
                    TabIndex="4" Width="20px" ToolTip="Search By Name" /></td>
        </tr>
        <tr>
            <td align="left" height="20" style="width: 105px">
                <asp:Label ID="lblBirthDate" runat="server" Height="20px" Text="BirthDate:" Width="120px"></asp:Label></td>
            <td align="left" height="20" width="150">
                <igtxt:WebDateTimeEdit ID="mskBirthDate" runat="server" BorderStyle="Solid" BorderWidth="1px"
                    Height="15px" TabIndex="5" Width="77px">
                </igtxt:WebDateTimeEdit>
                </td>
            <td align="left" height="20" valign="top" style="width: 150px">
                <asp:CheckBox ID="chkBC" runat="server" Font-Size="Small" TabIndex="9" Text="BC"
                    TextAlign="Left" Width="40px" /></td>
            <td align="right" rowspan="2" valign="top">
                <asp:RadioButtonList ID="radGender" runat="server" BorderStyle="Solid"
                    BorderWidth="1px" Height="20px" RepeatColumns="1"
                    TextAlign="Left" Width="80px" TabIndex="10">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList></td>
            <td align="left" rowspan="1" style="width: 103px">
            </td>
            <td align="left" rowspan="3" style="width: 103px">
                <asp:CheckBoxList ID="chkParentPlayer" runat="server" BackColor="#E0E0E0" BorderColor="Navy"
                    BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="1px" RepeatColumns="1"
                    Width="100px" TabIndex="12">
                    <asp:ListItem>Parent</asp:ListItem>
                    <asp:ListItem>Coach</asp:ListItem>
                    <asp:ListItem>Player</asp:ListItem>
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 20px" bgcolor="#e0e0e0" valign="bottom">
                <asp:Label ID="lblHousehold" runat="server" Height="20px" Text="Household" Width="280px" BackColor="#E0E0E0" BorderStyle="None" BorderWidth="1px" Font-Underline="True"></asp:Label></td>
            <td align="left" style="width: 105px; height: 20px">
                <asp:Label ID="lblCelPhone" runat="server" Height="20px" Text="Cel Phone:" Width="120px"></asp:Label></td>
            <td align="left" style="width: 120px; height: 20px"><igtxt:WebMaskEdit ID="txtCellPhone" runat="server" BorderStyle="Solid" BorderWidth="1px"
                    Height="15px" InputMask="###-###-####" TabIndex="6" Width="80px">
            </igtxt:WebMaskEdit>
            </td>
            <td align="left" style="width: 150px; height: 20px">
            </td>
            <td align="left" style="width: 120px; height: 20px">
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 20px;" bordercolor="mediumblue" bgcolor="#e0e0e0" colspan="2">
                <asp:LinkButton ID="lnkHouseName" runat="server" TabIndex="20" Width="250px"></asp:LinkButton>&nbsp;
                <asp:ImageButton ID="imgHouse" runat="server" Height="20px" ImageUrl="~/Images/SEARCH.JPG"
                    TabIndex="18" Width="20px" ToolTip="Search By Household" /></td>
            <td align="left" style="width: 105px; height: 20px;">
                <asp:Label ID="lblWorkPhone" runat="server" Height="20px" Text="Work Phone:" Width="120px"></asp:Label></td>
            <td align="left" colspan="3" style="height: 20px">
                <igtxt:WebMaskEdit ID="txtWorkPhone" runat="server" BorderStyle="Solid" BorderWidth="1px"
                    Height="15px" InputMask="###-###-#### Ext. 99999" TabIndex="7" Width="153px">
                </igtxt:WebMaskEdit>
            </td>
            <td align="left" colspan="1" style="height: 20px">
            </td>
        </tr>
        <tr>
            <td align="left" bordercolor="mediumblue" colspan="2" height="20" bgcolor="#e0e0e0">
                <asp:Label ID="lblAddress" runat="server" Height="20px" Width="280px">Address</asp:Label></td>
            <td align="left" height="20" style="width: 105px">
                <asp:Label ID="lblGrade" runat="server" Height="20px" Text="Grade:" Width="120px"></asp:Label></td>
            <td align="left" colspan="3" height="20">
                <asp:DropDownList ID="cmbGrade" runat="server" Height="20px" Width="80px" TabIndex="8">
                    <asp:ListItem Value="0">K</asp:ListItem>
                    <asp:ListItem Value="1">1st</asp:ListItem>
                    <asp:ListItem Value="2">2nd</asp:ListItem>
                    <asp:ListItem Value="3">3rd</asp:ListItem>
                    <asp:ListItem Value="4">4th</asp:ListItem>
                    <asp:ListItem Value="5">5th</asp:ListItem>
                    <asp:ListItem Value="6">6th</asp:ListItem>
                    <asp:ListItem Value="7">7th</asp:ListItem>
                    <asp:ListItem Value="8">8th</asp:ListItem>
                    <asp:ListItem Value="9">9th</asp:ListItem>
                    <asp:ListItem Value="10">10th</asp:ListItem>
                    <asp:ListItem Value="11">11th</asp:ListItem>
                    <asp:ListItem Value="12">12th</asp:ListItem>
                    <asp:ListItem Value="99" Selected="True">Adult</asp:ListItem>
                </asp:DropDownList></td>
            <td height="20">
            </td>
            <td align="center" height="20" style="width: 103px">
                <asp:Button ID="btnSave" runat="server" TabIndex="14" Text="Save" Width="90px" /></td>
        </tr>
        <tr>
            <td align="left" bordercolor="mediumblue" colspan="2" height="20" bgcolor="#e0e0e0">
                <asp:Label ID="lblCSZ" runat="server" Height="20px" Width="280px">City, State Zip</asp:Label></td>
            <td align="left" height="20" style="width: 105px">
                <asp:Label ID="lblSchoolName" runat="server" Height="20px" Text="School:" Width="120px"></asp:Label></td>
            <td align="left" colspan="3" height="20">
                <asp:TextBox ID="txtSchool" runat="server" BorderStyle="Solid" BorderWidth="1px"
                    Height="15px" TabIndex="17" Width="210px"></asp:TextBox></td>
            <td height="20">
            </td>
            <td align="center" height="20" style="width: 103px">
                <asp:Button ID="btnRegister" runat="server" TabIndex="15" Text="Register" Width="90px" /></td>
        </tr>
        <tr>
            <td align="left" bordercolor="mediumblue" colspan="2" height="20" bgcolor="#e0e0e0">
                <asp:Label ID="lblPhone" runat="server" Height="20px" Width="280px">Phone</asp:Label></td>
            <td align="left" height="20" style="width: 105px">
                <asp:LinkButton ID="btnComments" runat="server" TabIndex="20" Width="84px">Comments</asp:LinkButton></td>
            <td align="left" colspan="3" height="20">
            </td>
            <td height="20">
            </td>
            <td align="center" height="20" style="width: 103px">
                <asp:Button ID="btnDelete" runat="server" TabIndex="16" Text="Delete" Width="90px" /></td>
        </tr>
        <tr>
            <td align="left" bordercolor="mediumblue" colspan="2" valign="top" bgcolor="#e0e0e0">
                <asp:Label ID="lblEmail" runat="server" Height="20px" Width="280px">Email</asp:Label></td>
            <td align="left" colspan="4" rowspan="3" valign="top">
                <asp:TextBox ID="txtComments" runat="server" Height="56px" TextMode="MultiLine" Width="327px"></asp:TextBox></td>
            <td height="20">
            </td>
            <td align="center" rowspan="4" style="width: 103px" valign="top">
                <asp:Label ID="lblDelete" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Visible="False" Width="87px"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" bordercolor="mediumblue" colspan="2" valign="top">
            </td>
            <td height="20">
            </td>
        </tr>
        <tr>
            <td align="left" bordercolor="mediumblue" colspan="2" rowspan="3">
                <igtbl:UltraWebGrid ID="grdMembers" runat="server" Height="123px" Width="280px">
                    <Bands>
                        <igtbl:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <FilterOptions AllString="" EmptyString="" NonEmptyString="">
                                <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                    CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px" Width="200px">
                                    <Padding Left="2px" />
                                </FilterDropDownStyle>
                                <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                                </FilterHighlightRowStyle>
                            </FilterOptions>
                        </igtbl:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                        CellClickActionDefault="RowSelect" ColWidthDefault="33%" HeaderClickActionDefault="SortMulti"
                        Name="grdTotals" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Single"
                        TableLayout="Fixed" UseFixedHeaders="True" Version="4.00">
                        <GroupByBox>
                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderWidth="1px">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <FilterOptionsDefault>
                            <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                Font-Size="11px" Width="200px">
                                <Padding Left="2px" />
                            </FilterDropDownStyle>
                            <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                            </FilterHighlightRowStyle>
                        </FilterOptionsDefault>
                        <SelectedRowStyleDefault BackColor="Gainsboro" ForeColor="Black">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#002D62" BorderStyle="Solid" Font-Bold="True" Font-Names="Arial"
                            Font-Size="9pt" ForeColor="White" HorizontalAlign="Center">
                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                        </HeaderStyleDefault>
                        <RowAlternateStyleDefault BackColor="WhiteSmoke">
                        </RowAlternateStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" Font-Names="Arial" Font-Size="9pt" Height="123px"
                            Width="280px">
                        </FrameStyle>
                        <Pager>
                            <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
                        </Pager>
                        <AddNewBox>
                            <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
                        </AddNewBox>
                    </DisplayLayout>
                </igtbl:UltraWebGrid></td>
            <td align="center" style="width: 103px" valign="top">
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4" height="20">
                <asp:Label ID="lblVolunteer" runat="server" Height="20px" Text="*** VOLUNTEER ***" Width="151px"></asp:Label></td>
            <td align="right" colspan="1" height="20">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="6" rowspan="1" style="height: 7px" valign="top">
                <asp:CheckBoxList ID="chkVolunteer" runat="server" BackColor="#E0E0E0" BorderColor="Navy"
                    BorderStyle="Solid" BorderWidth="1px" Height="93px" RepeatColumns="3" Width="466px" TabIndex="13" RepeatDirection="Horizontal">
                    <asp:ListItem>Board Officer</asp:ListItem>
                    <asp:ListItem>Board Member</asp:ListItem>
                    <asp:ListItem>Athletic Director</asp:ListItem>
                    <asp:ListItem>Sponsor</asp:ListItem>
                    <asp:ListItem>Sign Ups</asp:ListItem>
                    <asp:ListItem>Try Outs</asp:ListItem>
                    <asp:ListItem>Tee Shirts</asp:ListItem>
                    <asp:ListItem>Printing Co.</asp:ListItem>
                    <asp:ListItem>Equipment</asp:ListItem>
                    <asp:ListItem>Electrician</asp:ListItem>
                    <asp:ListItem>Asst Coach</asp:ListItem>
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td align="left" colspan="8" style="height: 28px">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Width="748px"></asp:Label></td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</asp:Content>


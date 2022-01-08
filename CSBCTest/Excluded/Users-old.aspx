<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Users" title="Users" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script id="Infragistics" type="text/javascript">
<!--

function grdMembers_DELETE(gridName, cellId){
	//Add code to handle your event here.
}
// -->
</script>
<script language="javascript" type="text/javascript">
<!--

// -->
</script>

    &nbsp;
    <table style="width: 371px; height: 123px">
        <tr>
            <td align="left">
                <asp:Label ID="lblHouseNameCaption" runat="server" Text="Household:" Width="86px"></asp:Label></td>
            <td align="left" style="width: 222px">
                <asp:Label ID="lblHouseHold" runat="server" Font-Bold="True" Width="299px"></asp:Label></td>
            <td align="left" style="width: 222px">
                <asp:ImageButton ID="imgName" runat="server" Height="20px" ImageUrl="~/Images/SEARCH.JPG"
                    TabIndex="1" ToolTip="Search By Name" Width="20px" />
                <asp:Label ID="lblHouseID" runat="server" Font-Bold="True" Width="10px" Visible="False"></asp:Label></td>
            <td align="right" style="width: 60px">
                <asp:Button ID="btnNew" runat="server" Text="New" Width="90px" TabIndex="7" Height="24px" /></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblEmailCaption" runat="server" Text="Email:" Width="86px"></asp:Label></td>
            <td align="left" style="width: 222px">
                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Width="299px"></asp:Label></td>
            <td align="left" style="width: 222px">
            </td>
            <td align="right" style="width: 60px">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="90px" TabIndex="8" Enabled="False" /></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblName" runat="server" Text="Name:" Width="86px"></asp:Label></td>
            <td align="left" style="width: 222px">
                <asp:TextBox ID="txtName" runat="server" Width="294px" TabIndex="2" Font-Bold="True"></asp:TextBox></td>
            <td align="left" style="width: 222px">
                <asp:Label ID="lblID" runat="server" Width="40px" Visible="False"></asp:Label></td>
            <td style="width: 60px" align="right">
                <asp:Button ID="btnDelete" runat="server" Enabled="False" Height="24px" Text="Delete"
                    Width="90px" /></td>
        </tr>
        <tr>
            <td align="left" style="height: 22px">
                <asp:Label ID="lblUsernameCaption" runat="server" Text="UserName:" Width="86px"></asp:Label></td>
            <td style="width: 222px; height: 22px" align="left">
                <asp:TextBox ID="txtUserName" runat="server" Font-Bold="True" TabIndex="4" Width="294px"></asp:TextBox></td>
            <td style="width: 222px; height: 22px">
            </td>
            <td align="center" rowspan="3" style="width: 60px" valign="top">
                <asp:Label ID="lblDeleteUser" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Height="61px" Width="89px"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="height: 22px">
                <asp:Label ID="lblUserType" runat="server" Text="UserType:" Width="86px"></asp:Label></td>
            <td style="width: 222px; height: 22px">
                <asp:DropDownList ID="cboUserType" runat="server" Font-Bold="True" TabIndex="5" Width="299px">
                    <asp:ListItem Value="0">Public Website</asp:ListItem>
                    <asp:ListItem Value="2">Board Member</asp:ListItem>
                    <asp:ListItem Value="3">Administrator</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 222px; height: 22px">
                </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblPasswordCaption" runat="server" Text="Password:" Width="86px"></asp:Label></td>
            <td style="width: 222px" align="left">
                <asp:TextBox ID="txtPWord" runat="server" Font-Bold="True" TabIndex="6" Width="294px"></asp:TextBox></td>
            <td align="left" style="width: 222px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Update Allow to:" Width="127px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 279px" valign="top">
                <igtbl:UltraWebGrid ID="grdUsers" runat="server" CaptionAlign="Left" DisplayLayout-FixedColumnScrollType="Pixel"
                    DisplayLayout-HeaderTitleModeDefault="NotSet" DisplayLayout-ScrollBarView="Vertical"
                    DisplayLayout-TableLayout="fixed" DisplayLayout-UseFixedHeaders="false" DisplayLayout-ViewType="Flat"
                    Height="229px" Width="372px">
                    <Bands>
                        <igtbl:UltraGridBand>
                            <RowEditTemplate>
                                <br />
                                <p align="center">
                                    <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK" />&nbsp;
                                    <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel" /></p>
                            </RowEditTemplate>
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
                            <RowTemplateStyle BackColor="Window" BorderColor="Window" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </igtbl:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                        CellClickActionDefault="RowSelect" ColWidthDefault="33%" HeaderClickActionDefault="SortMulti"
                        HeaderTitleModeDefault="Never" Name="grdUsers" NoDataMessage="No Users" RowHeightDefault="20px"
                        RowSelectorsDefault="No" ScrollBar="Always" ScrollBarView="Vertical" SelectTypeRowDefault="Single"
                        TableLayout="Fixed" Version="4.00" StationaryMargins="Header">
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
                        <FrameStyle BackColor="Window" BorderColor="Navy" BorderStyle="None" BorderWidth="1px"
                            Font-Names="Arial" Font-Size="9pt" Height="229px" Width="372px">
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
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                    </DisplayLayout>
                </igtbl:UltraWebGrid></td>
            <td align="left" colspan="2" valign="top" style="height: 279px">
                <asp:ListBox ID="lstRoles" runat="server" Height="239px" SelectionMode="Multiple"
                    Width="109px"></asp:ListBox></td>
        </tr>
        <tr>
            <td align="left" colspan="4" valign="top">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Width="600px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


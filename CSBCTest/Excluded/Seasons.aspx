<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="Seasons.aspx.vb" Inherits="Seasons" title="Seasons" %>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script id="Infragistics" type="text/javascript">
<!--

function grdMembers_DELETE(gridName, cellId){
	//Add code to handle your event here.
}
// -->
</script>
    <table style="width: 371px; height: 123px">
        <tr>
            <td align="left">
                <asp:Label ID="lblName" runat="server" Text="Name:" Width="180px"></asp:Label></td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtName" runat="server" Width="303px" TabIndex="1"></asp:TextBox></td>
            <td align="right" colspan="1" style="width: 222px">
                <asp:Button ID="btnNew" runat="server" Text="New Season" Width="90px" TabIndex="13" /></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date:" Width="180px"></asp:Label></td>
            <td style="width: 222px" align="left">
                <igtxt:WebDateTimeEdit ID="mskStartDate" runat="server" HorizontalAlign="Right" Width="91px" TabIndex="2">
                </igtxt:WebDateTimeEdit>
            </td>
            <td style="width: 222px">
                <asp:TextBox ID="txtSeasonID" runat="server" TabIndex="1" Visible="False" Width="18px"></asp:TextBox></td>
            <td style="width: 60px" align="right">
                </td>
            <td align="right" style="width: 222px">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="90px" TabIndex="14" Visible="False" /></td>
        </tr>
        <tr>
            <td align="left" style="height: 22px">
                <asp:Label ID="lblEndDate" runat="server" Text="End Date:" Width="180px"></asp:Label></td>
            <td style="width: 222px; height: 22px" align="left"><igtxt:WebDateTimeEdit ID="mskEndDate" runat="server" HorizontalAlign="Right" Width="91px" TabIndex="3">
            </igtxt:WebDateTimeEdit>
                </td>
            <td style="width: 222px; height: 22px">
            </td>
            <td style="width: 222px; height: 22px">
            </td>
            <td style="width: 222px; height: 22px">
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblFee" runat="server" Text="Players Fee" Width="180px"></asp:Label></td>
            <td style="width: 222px" align="left">
                <igtxt:WebCurrencyEdit ID="mskPlayersFee" runat="server" Width="91px" TabIndex="4">
                </igtxt:WebCurrencyEdit>
                </td>
            <td align="left" colspan="1" rowspan="4" valign="top">
            </td>
            <td align="left" colspan="2" rowspan="4">
                &nbsp;<asp:Panel ID="pnlSeason" runat="server" BorderStyle="Solid" BorderWidth="1px"
                    Height="60px" Width="150px">
                    <asp:CheckBox ID="chkSchedules" runat="server" Text="Games Schedules" Width="183px" TabIndex="8" />
                    <asp:CheckBox ID="chkCurrentSeason" runat="server" Text="Current Season" Width="182px" TabIndex="9" /><br />
                    <asp:CheckBox ID="chkRegistration" runat="server" Text="Online Registration" Width="183px" AutoPostBack="True" TabIndex="10" /><br />
                    <br />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblSponsorFee" runat="server" Text="Sponsor Fee:" Width="180px"></asp:Label></td>
            <td align="left" style="width: 222px">
                <igtxt:WebCurrencyEdit ID="mskSponsorFee" runat="server" Width="91px" TabIndex="5">
                </igtxt:WebCurrencyEdit>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label1" runat="server" Text="Sponsor Discounted Fee:" Width="180px"></asp:Label></td>
            <td align="left" style="width: 222px"><igtxt:WebCurrencyEdit ID="mskSponsorFeeDiscounted" runat="server" Width="91px" TabIndex="6">
            </igtxt:WebCurrencyEdit>
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 12px">
                <asp:Label ID="lblNewYear" runat="server" Text="New School Year?:" Width="180px" Visible="False"></asp:Label></td>
            <td style="width: 222px; height: 12px;" align="left">
                <asp:CheckBox ID="chkNewSchool" runat="server" Text="Yes" Visible="False" TabIndex="7" /></td>
        </tr>
        <tr>
            <td align="left">
                </td>
            <td style="width: 222px">
                </td>
            <td style="width: 222px" align="left">
            </td>
            <td style="width: 60px" align="right">
                <asp:Label ID="lblORStarts" runat="server" Text="Online Starts:" Width="116px" Enabled="False" Height="19px"></asp:Label></td>
            <td align="left" style="width: 222px">
                <igtxt:WebDateTimeEdit ID="mskORStart" runat="server" EditModeFormat="MM/dd/yyyy h:mm tt" TabIndex="11">
                </igtxt:WebDateTimeEdit>
            </td>
        </tr>
        <tr>
            <td align="left">
                </td>
            <td align="left" style="width: 222px">
                </td>
            <td align="left" style="width: 222px">
            </td>
            <td style="width: 60px" align="right">
                <asp:Label ID="lblORStops" runat="server" Text="Online Stops:" Width="116px" Enabled="False"></asp:Label></td>
            <td align="left" style="width: 222px">
                <igtxt:WebDateTimeEdit ID="mskOREnd" runat="server" EditModeFormat="MM/dd/yyyy h:mm tt" Enabled="False" TabIndex="12">
                </igtxt:WebDateTimeEdit>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td align="left" colspan="1">
            </td>
            <td colspan="1">
                &nbsp;</td>
            <td colspan="1" style="width: 222px">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="5">
                <igtbl:UltraWebGrid ID="grdSeasons" runat="server" CaptionAlign="Left" DisplayLayout-FixedColumnScrollType="Pixel"
                    DisplayLayout-HeaderTitleModeDefault="NotSet" DisplayLayout-ScrollBarView="Vertical"
                    DisplayLayout-TableLayout="fixed" DisplayLayout-UseFixedHeaders="false" DisplayLayout-ViewType="Flat"
                    Height="181px" Width="730px" TabIndex="12">
                    <Bands>
                        <igtbl:UltraGridBand HeaderClickAction="SortSingle">
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
                        HeaderTitleModeDefault="Never" Name="grdSeasons" RowHeightDefault="20px" RowSelectorsDefault="No"
                        ScrollBarView="Vertical" SelectTypeRowDefault="Single" Version="4.00" NoDataMessage="No Seasons Data Found" ScrollBar="Always" TableLayout="Fixed">
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
                            Font-Names="Arial" Font-Size="9pt" Height="181px" Width="730px">
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
        </tr>
        <tr>
            <td align="left" colspan="5" valign="top">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Width="727px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="SearchSeasons.aspx.vb" Inherits="SearchSeasons" title="Select a Season" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
			<td align="left" colspan="5">
				<igtbl:UltraWebGrid ID="grdSeasons" runat="server" CaptionAlign="Left" DisplayLayout-FixedColumnScrollType="Pixel"
					DisplayLayout-HeaderTitleModeDefault="NotSet" DisplayLayout-ScrollBarView="Vertical"
					DisplayLayout-TableLayout="fixed" DisplayLayout-UseFixedHeaders="false" DisplayLayout-ViewType="Flat"
					Height="398px" Width="730px" TabIndex="12">
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
							Font-Names="Arial" Font-Size="9pt" Height="398px" Width="730px">
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


<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="Coaches.aspx.vb" Inherits="Coaches" title="Coaches" %>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form class="form-horizontal" runat="server" role="form">

    <table style="width: 303px">
        <tr>
            <td align="left">
                <asp:Label ID="lblCoach" runat="server" Font-Bold="True" Font-Underline="False" Text="Coach"
                    Width="104px"></asp:Label></td>
            <td align="right">
                <asp:Label ID="lblShirt" runat="server" Font-Bold="True" Font-Underline="False" Text="Shirt:"
                    Width="72px"></asp:Label></td>
            <td align="left" style="width: 146px">
                <asp:DropDownList ID="cmbSizes" runat="server" Height="20px"
                    TabIndex="1" Width="124px">
                    <asp:ListItem Selected="True">N/A</asp:ListItem>
                    <asp:ListItem>SMALL</asp:ListItem>
                    <asp:ListItem>MEDIUM</asp:ListItem>
                    <asp:ListItem>LARGE</asp:ListItem>
                    <asp:ListItem>X-LARGE</asp:ListItem>
                    <asp:ListItem>XX-LARGE</asp:ListItem>
                    <asp:ListItem>3X-LARGE</asp:ListItem>
                </asp:DropDownList></td>
            <td align="left" style="width: 169px">
                <asp:Label ID="lblCoaches" runat="server" Font-Bold="True" Font-Italic="False" Height="20px"
                    Text="Current Season Coaches" Width="183px"></asp:Label></td>
            <td align="right">
                <asp:LinkButton ID="lnkPrint" runat="server" Height="20px" TabIndex="20" Width="95px" Font-Size="Small">Print Coaches</asp:LinkButton></td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" rowspan="7">
                <asp:DropDownList ID="cmbCoaches" runat="server" AutoPostBack="True" Height="20px"
                    TabIndex="1" Width="320px">
                </asp:DropDownList>
                <asp:Panel ID="pnlCoach" runat="server" BorderStyle="None" Height="50px" Visible="False"
                    Width="5px" BorderWidth="1px">
                    <asp:LinkButton ID="lnkName" runat="server" Height="20px" TabIndex="20" Width="317px">Name</asp:LinkButton>
                    <asp:Label ID="lblAddress" runat="server" Font-Italic="True" Height="20px" Text="Address"
                        Width="317px"></asp:Label>
                    <asp:Label ID="lblCSZ" runat="server" Font-Italic="True" Height="20px" Text="City, State, Zip"
                        Width="317px"></asp:Label>
                    <asp:Label ID="lblPhone" runat="server" Font-Italic="True" Height="20px" Text="Phone"
                        Width="317px"></asp:Label></asp:Panel>
            </td>
            <td align="left" colspan="2" rowspan="9" valign="top">
                <igtbl:ultrawebgrid id="grdCoaches" runat="server" captionalign="Left" displaylayout-fixedcolumnscrolltype="Pixel"
                    displaylayout-headertitlemodedefault="NotSet" displaylayout-scrollbarview="Vertical"
                    displaylayout-tablelayout="fixed" displaylayout-usefixedheaders="false" displaylayout-viewtype="Flat"
                    height="165px" width="280px"><Bands>
<igtbl:UltraGridBand><RowEditTemplate>
                                <br  />
                                <p align="center">
                                    <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK"  />&nbsp;
                                    <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel"  /></p>
                            
</RowEditTemplate>

<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>

<FilterOptions EmptyString="" AllString="" NonEmptyString="">
<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>

<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>
</FilterOptions>

<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
<BorderDetails WidthRight="3px" WidthLeft="3px" WidthTop="3px" WidthBottom="3px"></BorderDetails>
</RowTemplateStyle>
</igtbl:UltraGridBand>
</Bands>

<DisplayLayout Version="4.00" AllowSortingDefault="OnClient" NoDataMessage="No Coaches Found" AllowColSizingDefault="Free" HeaderTitleModeDefault="Never" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdCoaches" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" ScrollBarView="Vertical" RowHeightDefault="20px" SelectTypeRowDefault="Single" ScrollBar="Always" TableLayout="Fixed" StationaryMargins="Header">
<GroupByBox>
<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
</GroupByBox>

<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>

<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</FooterStyleDefault>

<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BackColor="Window">
<BorderDetails ColorTop="Window" ColorLeft="Window"></BorderDetails>

<Padding Left="3px"></Padding>
</RowStyleDefault>

<FilterOptionsDefault>
<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>

<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>
</FilterOptionsDefault>

<SelectedRowStyleDefault ForeColor="Black" BackColor="Gainsboro"></SelectedRowStyleDefault>

<HeaderStyleDefault ForeColor="White" HorizontalAlign="Center" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" Font-Bold="True" BackColor="#002D62">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</HeaderStyleDefault>

<RowAlternateStyleDefault BackColor="WhiteSmoke"></RowAlternateStyleDefault>

<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>

<FrameStyle BorderWidth="1px" BorderColor="Navy" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="280px" Height="165px"></FrameStyle>

<Pager>
<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</Pager>

<AddNewBox>
<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</AddNewBox>
    <ActivationObject BorderColor="" BorderWidth="">
    </ActivationObject>
</DisplayLayout>
</igtbl:ultrawebgrid>
                &nbsp;
            </td>
            <td align="center" rowspan="9" valign="middle">
                <table>
                    <tr>
                        <td style="width: 3px">
                            <asp:Button ID="btnNew" runat="server" TabIndex="3" Text="New" Width="90px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 3px">
                            <asp:Button ID="btnSave" runat="server" TabIndex="4" Text="Save" Width="90px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 3px">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="5" Text="Delete" Width="90px" /></td>
                    </tr>
                    <tr>
                        <td align="center" rowspan="2" style="width: 3px">
                            <asp:Label ID="lblDelete" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                                Height="51px" Visible="False" Width="88px"></asp:Label></td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
            <td align="left" colspan="2" rowspan="1">
                <asp:Label ID="lblPreferred" runat="server" Font-Bold="True" Font-Italic="False"
                    Height="20px" Text="Prefered Phone:" Width="183px"></asp:Label></td>
            <td align="left" colspan="1" rowspan="1">
                <igtxt:webmaskedit id="txtCoachPhone" runat="server" borderstyle="Solid" borderwidth="1px"
                    height="15px" inputmask="###-###-####" tabindex="2" width="103px" BackColor="Transparent" HorizontalAlign="Right"></igtxt:webmaskedit>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" rowspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="height: 21px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" Height="20px"
                    Text="Coaches' Kids" Width="183px"></asp:Label></td>
            <td align="left" colspan="3" style="height: 21px">
                <asp:Label ID="lblPlayers" runat="server" Font-Bold="True" Font-Italic="False" Height="20px"
                    Text="Current Season Players" Width="183px"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="3" rowspan="6" valign="top">
                <igtbl:ultrawebgrid id="grdKids" runat="server" captionalign="Left" displaylayout-fixedcolumnscrolltype="Pixel"
                    displaylayout-headertitlemodedefault="NotSet" displaylayout-scrollbarview="Vertical"
                    displaylayout-tablelayout="fixed" displaylayout-usefixedheaders="false" displaylayout-viewtype="Flat"
                    height="134px" width="314px"><Bands>
<igtbl:UltraGridBand><RowEditTemplate>
                                <br  />
                                <p align="center">
                                    <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK"  />&nbsp;
                                    <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel"  /></p>
                            
</RowEditTemplate>

<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>

<FilterOptions EmptyString="" AllString="" NonEmptyString="">
<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>

<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>
</FilterOptions>

<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
<BorderDetails WidthRight="3px" WidthLeft="3px" WidthTop="3px" WidthBottom="3px"></BorderDetails>
</RowTemplateStyle>
</igtbl:UltraGridBand>
</Bands>

<DisplayLayout Version="4.00" AllowSortingDefault="OnClient" NoDataMessage="No Players To coach" AllowColSizingDefault="Free" HeaderTitleModeDefault="Never" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdKids" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" ScrollBarView="Vertical" RowHeightDefault="20px" SelectTypeRowDefault="Single" ScrollBar="Always" TableLayout="Fixed" StationaryMargins="Header">
<GroupByBox>
<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
</GroupByBox>

<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>

<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</FooterStyleDefault>

<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BackColor="Window">
<BorderDetails ColorTop="Window" ColorLeft="Window"></BorderDetails>

<Padding Left="3px"></Padding>
</RowStyleDefault>

<FilterOptionsDefault>
<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>

<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>
</FilterOptionsDefault>

<SelectedRowStyleDefault ForeColor="Black" BackColor="Gainsboro"></SelectedRowStyleDefault>

<HeaderStyleDefault ForeColor="White" HorizontalAlign="Center" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" Font-Bold="True" BackColor="#002D62">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</HeaderStyleDefault>

<RowAlternateStyleDefault BackColor="WhiteSmoke"></RowAlternateStyleDefault>

<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>

<FrameStyle BorderWidth="1px" BorderColor="Navy" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="314px" Height="134px"></FrameStyle>

<Pager>
<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</Pager>

<AddNewBox>
<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</AddNewBox>
    <ActivationObject BorderColor="" BorderWidth="">
    </ActivationObject>
</DisplayLayout>
</igtbl:ultrawebgrid>
            </td>
            <td align="left" colspan="3" rowspan="7" valign="top">
                <igtbl:ultrawebgrid id="grdPlayers" runat="server" captionalign="Left" displaylayout-fixedcolumnscrolltype="Pixel"
                    displaylayout-headertitlemodedefault="NotSet" displaylayout-scrollbarview="Vertical"
                    displaylayout-tablelayout="fixed" displaylayout-usefixedheaders="false" displaylayout-viewtype="Flat"
                    height="138px" width="280px"><Bands>
<igtbl:UltraGridBand><RowEditTemplate>
                                <br  />
                                <p align="center">
                                    <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK"  />&nbsp;
                                    <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel"  /></p>
                            
</RowEditTemplate>

<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>

<FilterOptions EmptyString="" AllString="" NonEmptyString="">
<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>

<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>
</FilterOptions>

<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
<BorderDetails WidthRight="3px" WidthLeft="3px" WidthTop="3px" WidthBottom="3px"></BorderDetails>
</RowTemplateStyle>
</igtbl:UltraGridBand>
</Bands>

<DisplayLayout Version="4.00" AllowSortingDefault="OnClient" NoDataMessage="No Players Found" AllowColSizingDefault="Free" HeaderTitleModeDefault="Never" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdPlayers" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" ScrollBarView="Vertical" RowHeightDefault="20px" SelectTypeRowDefault="Single" ScrollBar="Always" TableLayout="Fixed" StationaryMargins="Header">
<GroupByBox>
<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
</GroupByBox>

<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>

<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</FooterStyleDefault>

<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BackColor="Window">
<BorderDetails ColorTop="Window" ColorLeft="Window"></BorderDetails>

<Padding Left="3px"></Padding>
</RowStyleDefault>

<FilterOptionsDefault>
<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>

<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>
</FilterOptionsDefault>

<SelectedRowStyleDefault ForeColor="Black" BackColor="Gainsboro"></SelectedRowStyleDefault>

<HeaderStyleDefault ForeColor="White" HorizontalAlign="Center" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" Font-Bold="True" BackColor="#002D62">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</HeaderStyleDefault>

<RowAlternateStyleDefault BackColor="WhiteSmoke"></RowAlternateStyleDefault>

<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>

<FrameStyle BorderWidth="1px" BorderColor="Navy" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="280px" Height="138px"></FrameStyle>

<Pager>
<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</Pager>

<AddNewBox>
<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</AddNewBox>
    <ActivationObject BorderColor="" BorderWidth="">
    </ActivationObject>
</DisplayLayout>
</igtbl:ultrawebgrid>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
            <td align="left" colspan="3">
                <asp:LinkButton ID="lnkComments" runat="server" Height="20px" TabIndex="6" Width="183px">Comments:</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="left" colspan="4" rowspan="3" valign="top">
                <asp:TextBox ID="txtComments" runat="server" Height="67px" TextMode="MultiLine" Width="522px"></asp:TextBox></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="6">
    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
        Width="746px"></asp:Label></td>
        </tr>
    </table>
</form>

</asp:Content>


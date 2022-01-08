<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="Calendar.aspx.vb" Inherits="Calendar" title="Activities Calendar" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 402px; height: 149px">
        <tr>
            <td align="left" rowspan="11" valign="top">
                &nbsp;<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
            <td>
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td style="height: 21px" align="center">
                <asp:Label ID="lblDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Navy"
                    Width="200px"></asp:Label></td>
            <td colspan="2" style="height: 21px" align="left">
                <asp:CheckBox ID="chkDisplay" runat="server" TabIndex="1" Text="Show as Upcoming event"
                    Width="202px" /></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblTitle" runat="server" Text="Title:" Width="128px"></asp:Label></td>
            <td colspan="2" align="left">
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="20" TabIndex="2"
                    Width="261px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblSubTitle" runat="server" Text="SubTitle:" Width="128px"></asp:Label></td>
            <td colspan="2" align="left">
                <asp:TextBox ID="txtSubTitle" runat="server" MaxLength="20" TabIndex="3"
                    Width="261px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <asp:Label ID="lblDescr" runat="server" Text="Description:" Width="128px"></asp:Label></td>
            <td align="left" colspan="2" rowspan="1">
                <asp:TextBox ID="txtDescription1" runat="server" Height="18px" MaxLength="300" TabIndex="4" Width="261px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtDescription2" runat="server" Height="18px" MaxLength="300" TabIndex="5"
                    Width="261px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtDescription3" runat="server" Height="18px" MaxLength="300" TabIndex="6"
                    Width="261px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" TabIndex="7" Text="Save" Width="104px" /></td>
            <td>
                <asp:Button ID="btnDelete" runat="server" TabIndex="8" Text="Delete" Width="104px" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td align="center" rowspan="3" valign="top">
                <asp:Label ID="lblDeleteDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Height="61px" Width="89px"></asp:Label></td>
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
            <td align="left" colspan="2" rowspan="8" valign="top">
                &nbsp;<igtbl:ultrawebgrid id="grdActivities" runat="server" captionalign="Left" displaylayout-fixedcolumnscrolltype="Pixel"
                    displaylayout-headertitlemodedefault="NotSet" displaylayout-scrollbarview="Vertical"
                    displaylayout-tablelayout="fixed" displaylayout-usefixedheaders="false" displaylayout-viewtype="Flat"
                    height="142px" width="414px"><Bands>
<igtbl:UltraGridBand><RowEditTemplate>
                                <br  />
                                <p align="center">
                                    <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK"  />&nbsp;
                                    <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel"  /></p>
                            
</RowEditTemplate>

<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>

<FilterOptions NonEmptyString="" AllString="" EmptyString="">
<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>

<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>
</FilterOptions>

<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
<BorderDetails WidthRight="3px" WidthLeft="3px" WidthTop="3px" WidthBottom="3px"></BorderDetails>
</RowTemplateStyle>
</igtbl:UltraGridBand>
</Bands>

<DisplayLayout Version="4.00" AllowSortingDefault="OnClient" NoDataMessage="No Activities Found" AllowColSizingDefault="Free" HeaderTitleModeDefault="Never" ScrollBar="Always" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdActivities" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" TableLayout="Fixed" ScrollBarView="Vertical" RowHeightDefault="20px" SelectTypeRowDefault="Single" StationaryMargins="Header">
<GroupByBox>
<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
</GroupByBox>

<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>

<ActivationObject BorderWidth="" BorderColor=""></ActivationObject>

<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</FooterStyleDefault>

<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BackColor="Window">
<BorderDetails ColorTop="Window" ColorLeft="Window"></BorderDetails>

<Padding Left="3px"></Padding>
</RowStyleDefault>

<FilterOptionsDefault>
<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>

<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>
</FilterOptionsDefault>

<SelectedRowStyleDefault ForeColor="Black" BackColor="Gainsboro"></SelectedRowStyleDefault>

<HeaderStyleDefault ForeColor="White" HorizontalAlign="Center" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" Font-Bold="True" BackColor="#002D62">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</HeaderStyleDefault>

<RowAlternateStyleDefault BackColor="WhiteSmoke"></RowAlternateStyleDefault>

<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>

<FrameStyle BorderWidth="1px" BorderColor="Navy" BorderStyle="None" Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="414px" Height="142px"></FrameStyle>

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
</DisplayLayout>
</igtbl:ultrawebgrid></td>
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
                &nbsp;</td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Width="600px"></asp:Label></td>
            <td colspan="1">
            </td>
        </tr>
    </table>
</asp:Content>


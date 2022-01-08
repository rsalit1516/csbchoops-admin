<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="ContentUPD.aspx.vb" Inherits="ContentUPD" title="Content Update" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 749px; height: 198px">
        <tr>
            <td align="left" rowspan="1" style="width: 312px">
            </td>
            <td align="left" rowspan="1" style="width: 312px">
            </td>
            <td align="left" rowspan="1" style="width: 312px">
            </td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
            <td align="left" style="width: 270px; height: 26px">
                <asp:Button ID="btnReturn" runat="server" Text="Preview" Width="104px" TabIndex="7" /></td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 312px; height: 28px;">
                <asp:Label ID="lblLineText" runat="server" Font-Bold="False" Text="Line Text:"
                    Width="113px"></asp:Label></td>
            <td align="left" colspan="3" rowspan="1" style="height: 28px">
                <asp:TextBox ID="txtDescr" runat="server" Width="340px" TabIndex="1"></asp:TextBox></td>
            <td align="left" style="width: 270px; height: 28px">
                <asp:Button ID="btnNew" runat="server" Text="New" Width="104px" TabIndex="8" /></td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 312px">
                <asp:Label ID="lblFontSize" runat="server" Font-Bold="False" Text="Font Size:" Width="113px"></asp:Label></td>
            <td align="left" rowspan="1" style="width: 312px">
                <asp:DropDownList ID="cmbSize" runat="server" Width="141px" TabIndex="2">
                    <asp:ListItem>XSMALL</asp:ListItem>
                    <asp:ListItem Selected="True">SMALL</asp:ListItem>
                    <asp:ListItem>MEDIUM</asp:ListItem>
                    <asp:ListItem>LARGE</asp:ListItem>
                </asp:DropDownList></td>
            <td align="left" rowspan="1" style="width: 312px">
                <asp:Label ID="lblFontColor" runat="server" Font-Bold="False" Text="Font Color:"
                    Width="100px"></asp:Label></td>
            <td align="left" style="width: 270px; height: 26px"><asp:DropDownList ID="cmbColor" runat="server" Width="256px" TabIndex="3">
                <asp:ListItem>BLACK</asp:ListItem>
                <asp:ListItem>BLUE</asp:ListItem>
                <asp:ListItem>GREEN</asp:ListItem>
                <asp:ListItem>NAVY</asp:ListItem>
                <asp:ListItem>RED</asp:ListItem>
                <asp:ListItem>YELLOW</asp:ListItem>
            </asp:DropDownList></td>
            <td align="left" style="width: 270px; height: 26px">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="104px" TabIndex="9" /></td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 312px">
                <asp:Label ID="lblTarget" runat="server" Height="19px" Width="113px">Target:</asp:Label></td>
            <td align="left" colspan="3" rowspan="1">
                <asp:TextBox ID="txtLink" runat="server" Width="519px"></asp:TextBox></td>
            <td align="left" style="width: 270px; height: 26px">
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="104px" TabIndex="10" /></td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 312px">
                <asp:Label ID="lblStart" runat="server" Height="19px" Width="113px">Start:</asp:Label></td>
            <td align="left" rowspan="1" style="width: 312px">
                <igtxt:WebDateTimeEdit ID="mskStart" runat="server" EditModeFormat="MM/dd/yyyy h:mm tt"
                    TabIndex="4">
                </igtxt:WebDateTimeEdit>
            </td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
            <td align="center" style="width: 270px; height: 26px">
                <asp:Label ID="lblDelete" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Width="100px"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 312px">
                <asp:Label ID="lblEnd" runat="server" Height="19px" Width="113px">End:</asp:Label></td>
            <td align="left" rowspan="1" style="width: 312px">
                <igtxt:webdatetimeedit id="mskEnd" runat="server" editmodeformat="MM/dd/yyyy h:mm tt"
                    tabindex="5" DisplayModeFormat="MM/dd/yyyy h:mm tt"></igtxt:webdatetimeedit>
            </td>
            <td align="left" rowspan="1" style="width: 312px">
            </td>
            <td align="left" style="width: 270px; height: 26px">
                </td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 312px; height: 47px;">
                </td>
            <td align="left" rowspan="1" style="height: 47px;" colspan="3">
                <asp:CheckBoxList ID="chkBIU" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                    TabIndex="6" Width="430px">
                    <asp:ListItem>Bold</asp:ListItem>
                    <asp:ListItem>Italic</asp:ListItem>
                    <asp:ListItem>Underscore</asp:ListItem>
                </asp:CheckBoxList></td>
            <td align="left" style="width: 270px; height: 47px">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="5" rowspan="7" valign="top">
                &nbsp;<igtbl:ultrawebgrid id="grdDescr" runat="server" height="228px" width="743px" TabIndex="11"><Bands>
<igtbl:UltraGridBand>
<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>

<FilterOptions NonEmptyString="" AllString="" EmptyString="">
<FilterHighlightRowStyle ForeColor="White" BackColor="#151C55"></FilterHighlightRowStyle>

<FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>
</FilterOptions>
</igtbl:UltraGridBand>
</Bands>

<DisplayLayout Version="4.00" AllowSortingDefault="OnClient" UseFixedHeaders="True" AllowColSizingDefault="Free" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdDescr" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" TableLayout="Fixed" RowHeightDefault="20px" SelectTypeRowDefault="Single">
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

<FrameStyle Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="743px" Height="228px"></FrameStyle>

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
            <td align="left" colspan="5" rowspan="1" valign="top" style="height: 21px">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#C00000" Width="747px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


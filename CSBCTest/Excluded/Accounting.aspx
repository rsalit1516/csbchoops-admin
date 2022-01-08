<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="Accounting.aspx.vb" Inherits="Accounting" title="Sponsor Detail" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    <table style="width: 371px; height: 123px">
        <tr>
            <td align="left">
                <asp:Label ID="lblName" runat="server" Text="Sponsor Name:" Width="180px" Font-Bold="True"></asp:Label></td>
            <td align="left" colspan="3">
                <asp:Label ID="lblSponsorName" runat="server" Width="442px"></asp:Label></td>
            <td align="right" colspan="1">
                <asp:Button ID="btnNew" runat="server" TabIndex="5" Text="New Payment" Width="90px" /></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblPaymentDate" runat="server" Text="Payment Date:" Width="180px" Font-Bold="True"></asp:Label></td>
            <td align="left" style="width: 222px">
                <igtxt:webdatetimeedit id="mskDate" runat="server" horizontalalign="Right" tabindex="1"
                    width="68px">
                </igtxt:webdatetimeedit>
            </td>
            <td align="left" rowspan="4" style="width: 222px">
                <asp:RadioButtonList ID="radPayment" runat="server" BorderColor="Blue" BorderStyle="Solid"
                    BorderWidth="2px" Height="63px" RepeatColumns="1"
                    TabIndex="4" Width="110px">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Check</asp:ListItem>
                    <asp:ListItem>C.Card</asp:ListItem>
                </asp:RadioButtonList></td>
            <td align="right" style="width: 60px">
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" TabIndex="6" Text="Save"
                    Width="90px" Enabled="False" /></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblPayment" runat="server" Text="Payment Amount:" Width="180px" Font-Bold="True"></asp:Label></td>
            <td align="left" style="width: 222px">
                <igtxt:webcurrencyedit id="mskAmount" runat="server" tabindex="2" width="68px">
                </igtxt:webcurrencyedit>
            </td>
            <td align="right" style="width: 60px">
            </td>
            <td align="right">
                <asp:Button ID="btnDelete" runat="server" TabIndex="7" Text="Delete" Width="90px" Enabled="False" /></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblCheck" runat="server" Text="Check #:" Width="180px" Font-Bold="True"></asp:Label></td>
            <td align="left" style="width: 222px">
                <asp:TextBox ID="txtCheck" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="15px"
                    TabIndex="3" Width="115px"></asp:TextBox></td>
            <td align="right" style="width: 60px">
            </td>
            <td align="center" rowspan="3" valign="top">
                <asp:Label ID="lblDelete" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Visible="False" Width="87px"></asp:Label></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblBalCaption" runat="server" Font-Bold="True" Font-Underline="False"
                    Text="Balance:" Width="180px"></asp:Label></td>
            <td align="left" style="width: 222px">
                <asp:Label ID="lblBalance" runat="server" BorderStyle="None" BorderWidth="1px" Font-Bold="False"
                    Font-Underline="False" Width="100px"></asp:Label></td>
            <td align="right" style="width: 60px">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                </td>
            <td style="width: 222px">
            </td>
            <td align="right" style="width: 60px">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" rowspan="7">
                <igtbl:ultrawebgrid id="grdPayments" runat="server" captionalign="Top" height="144px"
                    tabindex="9" width="394px" style="left: 17px; top: 136px">
                <Bands>
                    <igtbl:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <FilterOptions AllString="" EmptyString="" NonEmptyString="">
                            <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                    CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px" Width="200px">
                                <Padding Left="2px"  />
                            </FilterDropDownStyle>
                            <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                            </FilterHighlightRowStyle>
                        </FilterOptions>
                    </igtbl:UltraGridBand>
                </Bands>
                <DisplayLayout AllowColSizingDefault="Free" AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                        CellClickActionDefault="RowSelect" ColWidthDefault="33%" HeaderClickActionDefault="SortMulti"
                        Name="grdPayments" RowHeightDefault="20px" RowSelectorsDefault="No" ScrollBarView="Vertical"
                        SelectTypeRowDefault="Single" Version="4.00" ScrollBar="Always" NoDataMessage="No payments">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"  />
                    </FooterStyleDefault>
                    <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderWidth="1px">
                        <BorderDetails ColorLeft="Window" ColorTop="Window"  />
                        <Padding Left="3px"  />
                    </RowStyleDefault>
                    <FilterOptionsDefault>
                        <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                Font-Size="11px" Width="200px">
                            <Padding Left="2px"  />
                        </FilterDropDownStyle>
                        <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                        </FilterHighlightRowStyle>
                    </FilterOptionsDefault>
                    <SelectedRowStyleDefault BackColor="Gainsboro" ForeColor="Black">
                    </SelectedRowStyleDefault>
                    <HeaderStyleDefault BackColor="#002D62" BorderStyle="Solid" Font-Bold="True" Font-Names="Arial"
                            Font-Size="9pt" ForeColor="White" HorizontalAlign="Center">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"  />
                    </HeaderStyleDefault>
                    <RowAlternateStyleDefault BackColor="WhiteSmoke">
                    </RowAlternateStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" Font-Names="Arial" Font-Size="9pt" Height="144px"
                            Width="394px" BorderStyle="None">
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
            </igtbl:ultrawebgrid>&nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td align="right" style="width: 60px">
            </td>
            <td align="center" rowspan="1" style="width: 75px" valign="top">
            </td>
            <td align="center" rowspan="1" valign="top">
                <asp:LinkButton ID="btnReturn" runat="server" Height="20px" TabIndex="8" Width="81px">Done</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="left" style="width: 222px">
            </td>
            <td align="right" style="width: 60px">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 222px">
            </td>
            <td align="right" style="width: 60px">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="1" style="width: 222px; height: 21px;">
            </td>
            <td colspan="1" style="height: 21px">
                &nbsp;</td>
            <td colspan="1" style="height: 21px">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="1" style="width: 222px">
            </td>
            <td colspan="1">
            </td>
            <td colspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="1" style="width: 222px">
            </td>
            <td colspan="1">
            </td>
            <td colspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="1" style="width: 222px">
            </td>
            <td colspan="1">
            </td>
            <td colspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="5" style="height: 21px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="5" valign="top">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Width="727px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


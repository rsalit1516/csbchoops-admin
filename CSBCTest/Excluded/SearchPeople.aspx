<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="SearchPeople.aspx.vb" Inherits="SearchPeople" title="Search People" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 765px; height: 198px">
        <tr>
            <td align="left" rowspan="1" style="width: 223px">
            </td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
            <td style="width: 107px; height: 26px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 26px">
                <igtbl:ultrawebgrid id="grdPeople" runat="server" height="197px" width="747px">
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
                        Name="grdPeople" NoDataMessage="No People found" RowHeightDefault="20px" RowSelectorsDefault="No"
                        ScrollBarView="Vertical" SelectTypeRowDefault="Single"
                        StationaryMarginsOutlookGroupBy="True"
                        Version="4.00" ScrollBar="Always">
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
                        <FrameStyle BackColor="Window" BorderColor="Navy" BorderStyle="None" BorderWidth="1px"
                            Font-Names="Arial" Font-Size="9pt" Height="197px" Width="747px">
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
                </igtbl:ultrawebgrid>
            </td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 223px">
                <asp:Label ID="lblLastName" runat="server" Font-Bold="True" Text="Last Name" Width="120px"></asp:Label></td>
            <td align="left" style="width: 270px; height: 26px">
                <asp:TextBox ID="txtLastName" runat="server" Width="330px"></asp:TextBox></td>
            <td style="width: 107px; height: 26px">
                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="104px" /></td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 223px">
                <asp:Label ID="lblFirstName" runat="server" Font-Bold="True" Text="First Name" Width="120px"></asp:Label></td>
            <td align="left" style="width: 270px; height: 26px">
                <asp:TextBox ID="txtFirstName" runat="server" Width="330px"></asp:TextBox></td>
            <td style="width: 107px; height: 26px">
                <asp:Button ID="btnNew" runat="server" Text="Add New" Width="104px" /></td>
        </tr>
        <tr>
            <td align="left" bordercolor="#000000" rowspan="1" style="width: 223px" valign="top">
                &nbsp;</td>
            <td align="left" style="width: 270px; height: 10px">
            </td>
            <td style="width: 107px; height: 10px">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" rowspan="1" valign="top">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#C00000" Width="735px"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" colspan="1" style="width: 223px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp;</td>
        </tr>
    </table>
</asp:Content>


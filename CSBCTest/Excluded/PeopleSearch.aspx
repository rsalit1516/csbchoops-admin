<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="PeopleSearch.aspx.vb" Inherits="PeopleSearch" title="Untitled Page" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table style="width: 755px">
        <tr>
            <td style="width: 3px; height: 215px;" colspan=2 align="center">
                <igtbl:UltraWebGrid ID="grdPeople" runat="server" Height="194px" Width="750px">
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
                        Name="grdPeople" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Single"
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
                        <FilterOptionsDefault AllString="(All)" EmptyString="(Empty)" NonEmptyString="(NonEmpty)">
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
                        <FrameStyle BackColor="Window" Font-Names="Arial" Font-Size="9pt" Height="194px"
                            Width="750px">
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
            <td style="width: 300px">
        <asp:Label ID="lblLastName" runat="server" Height="22px" Width="88px">Last Name:</asp:Label></td>
            <td style="width: 561px" align="left">
            <asp:TextBox
            ID="txtLastName" runat="server" BackColor="White" Height="22px" TabIndex="1"
            Width="320px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <asp:Label ID="lblFirstNam" runat="server" Height="22px" Width="88px">First Name:</asp:Label></td>
            <td align="left" style="width: 561px">
            <asp:TextBox
                ID="txtFirstName" runat="server" BackColor="White" Height="24" TabIndex="2" Width="321px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 300px; height: 71px">
            </td>
            <td align="left" style="width: 561px; height: 71px">
                &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Button
                    ID="cmbRefresh" runat="server" TabIndex="3" Text="Search" Width="89px" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button
                        ID="cmbReturn" runat="server" TabIndex="4" Text="Add New" Width="89" /></td>
        </tr>
        <tr>
            <td style="width: 3px; height: 36px">
            </td>
            <td align="left" style="width: 561px; height: 36px">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Large"
                    Font-Strikeout="False" ForeColor="Red"></asp:Label>
    <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HiddenField ID="HiddenField2" runat="server" /><asp:HiddenField ID="HiddenField7" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    &nbsp;
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenField6" runat="server" />
    &nbsp; &nbsp;
</asp:Content>


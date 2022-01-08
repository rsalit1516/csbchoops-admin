<%@ page language="VB" masterpagefile="~/MasterPage.master" autoeventwireup="false" inherits="Welcome, App_Web_wjirbhsa" title="Welcome To CSBC" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="grdTotals" class="table-bordered" runat="server">
        
    </asp:GridView>
    <igtbl:UltraWebGrid ID="grdTotals1" runat="server" Height="383px" Width="750px">
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
            Name="grdTotals1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Single" Version="4.00">
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
            <FrameStyle BackColor="Window" Font-Names="Arial" Font-Size="9pt" Height="383px"
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
    </igtbl:UltraWebGrid>
    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>&nbsp;&nbsp;
 
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Divisions.aspx.vb" Inherits="Divisions" Title="Divisions" %>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form-horizontal" runat="server" role="form">
        <div class="container">

            <div class="row">
                <div class="col-md-5">
                    <div class="form-group form-horizontal">
                        <label for="txtName">
                            <asp:Label ID="lblLastName" runat="server" Text="Name:"></asp:Label></label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                            TabIndex="1"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group ">
                                <label for="txtMinDate">Min Date:</label>
                                <igtxt:WebDateTimeEdit ID="txtMinDate" runat="server" TabIndex="2" class="form-control">
                                </igtxt:WebDateTimeEdit>

                            </div>
                            <div class="form-group ">
                                <label for="txtMaxDate">Max Date:</label>
                                <asp:TextBox ID="txtMaxDate" runat="server" CssClass="form-control date">
                                </asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">
                            <asp:RadioButtonList ID="radGender" runat="server" CssClass="form-control radio"
                                RepeatColumns="1" RepeatLayout="Flow" TabIndex="4" TextAlign="Left">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group ">
                                <label for="txtMinDate">Min Date 2:</label>
                                <igtxt:WebDateTimeEdit ID="txtMinDate2" runat="server" TabIndex="2" class="form-control">
                                </igtxt:WebDateTimeEdit>

                            </div>
                            <div class="form-group ">
                                <label for="txtMaxDate">Max Date 2:</label>
                                <asp:TextBox ID="txtMaxDate2" runat="server" CssClass="form-control date">
                                </asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">
                            <asp:RadioButtonList ID="radGender2" runat="server" CssClass="form-control radio"
                                RepeatColumns="1" RepeatLayout="Flow" TabIndex="4" TextAlign="Left">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                    </div>
                    <div class="row">
                        <div class="form-group">
                            <label for="cboAD">Director:</label>
                            <asp:Label ID="Label6" runat="server" Height="20px" Text="Director:" Width="120px"></asp:Label>

                            <asp:DropDownList ID="cboAD" runat="server" TabIndex="8" class="form-control dropdown">
                            </asp:DropDownList>

                            <label for="lblHPhon">AD Phone</label>
                            <asp:Label ID="lblHPhon" runat="server" CssClass="for-control label"></asp:Label>
                            <asp:Label ID="lblCPhon" runat="server" Height="20px" Width="256px"></asp:Label>
                        </div>

                    </div>

                </div>
                <div class="col-md-6">
                    <asp:DataGrid runat="server" ID="gridDivisionsNew">
                    </asp:DataGrid>
                    <igtbl:UltraWebGrid ID="grdDivisions" runat="server" CaptionAlign="Top" Height="244px"
                        TabIndex="11" Width="338px">
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
                            Name="grdDivisions" RowHeightDefault="20px" RowSelectorsDefault="No" ScrollBarView="Vertical"
                            SelectTypeRowDefault="Single" Version="4.00" StationaryMargins="Header" TableLayout="Fixed">
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
                            <FrameStyle BackColor="Window" Font-Names="Arial" Font-Size="9pt" Height="244px"
                                Width="338px">
                            </FrameStyle>
                            <Pager>
                                <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </BorderDetails >
                                </Style>
                            </Pager>
                            <AddNewBox>
                                <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </BorderDetails >
                                </Style>
                            </AddNewBox>
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                        </DisplayLayout>
                    </igtbl:UltraWebGrid>

                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <h2>Teams</h2>
                    <igtbl:UltraWebGrid ID="grdTeams" runat="server" CaptionAlign="Top" Height="181px"
                        TabIndex="11" Width="399px">
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
                            Name="grdTeams" RowHeightDefault="20px" RowSelectorsDefault="No" ScrollBarView="Vertical"
                            SelectTypeRowDefault="Single" Version="4.00" ScrollBar="Always" NoDataMessage="No Teams To Display" StationaryMargins="Header" TableLayout="Fixed">
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
                            <FrameStyle BackColor="Window" Font-Names="Arial" Font-Size="9pt" Height="181px"
                                Width="399px" BorderStyle="None">
                            </FrameStyle>
                            <Pager>
                                <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </BorderDetails >
                                </Style>
                            </Pager>
                            <AddNewBox>
                                <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </BorderDetails >
                                </Style>
                            </AddNewBox>
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                        </DisplayLayout>
                    </igtbl:UltraWebGrid>
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btnNew" runat="server" TabIndex="12" Text="New Division" Width="90px" CssClass="btn" />
                    <asp:Button ID="btnSave" runat="server" TabIndex="13" Text="Save" Width="90px" CssClass="btn" />
                    <asp:Button ID="btnDelete" runat="server" TabIndex="14" Text="Delete" Width="90px" CssClass="btn" />
                    <asp:Label ID="lblDelete" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                        Visible="False" Width="87px"></asp:Label>
                    <h2>Tryouts</h2>
                    <div class="form-group">
                        <label for="txtVenue">Venue:</label>

                        <asp:TextBox ID="txtVenue" runat="server" CssClass="form-control" TabIndex="15"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtDate">Date:</label>
                        <igtxt:WebDateTimeEdit ID="txtDate" runat="server" BorderStyle="Solid" BorderWidth="1px"
                            Height="15px" TabIndex="16" Width="82px">
                        </igtxt:WebDateTimeEdit>

                    </div>
                    <div class="form-group">
                        <label for="txtTime">Time:</label>

                        <asp:TextBox ID="txtTime" runat="server" CssClass="form-control" TabIndex="15"></asp:TextBox>
                    </div>

                </div>
            </div>
        </div>

        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
            Width="746px"></asp:Label>
        <asp:HiddenField ID="hdnMinDateOld" runat="server" />
        <asp:HiddenField ID="hdnMaxDateOld" runat="server" />
        <asp:HiddenField ID="hdnGenderOld" runat="server" />
        <asp:HiddenField ID="hdnGender2Old" runat="server" />
        <asp:HiddenField ID="hdnMinDate2Old" runat="server" />
        <asp:HiddenField ID="hdnMaxDate2Old" runat="server" />
    </form>
</asp:Content>


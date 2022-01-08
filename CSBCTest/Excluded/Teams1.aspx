<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Teams1.aspx.cs" Inherits="CSBC.Admin.Web.Teams1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-5">
                    <div class="form-control">
                        <label for="lblDivision">
                            <asp:Label ID="lblDivision" runat="server" Height="20px" Width="110px">Division:</asp:Label>
                        </label>
                        <asp:DropDownList ID="cmbDivisions" runat="server" Height="20px" TabIndex="1" Width="219px" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <div class="form-control">

                        <asp:Label ID="lblTeamName" runat="server" Height="20px" Width="110px">Team Name:</asp:Label>
                    </div>
                </div>

            


            <div class="col-md-7">
                <div class="row">
                    <div class="col-md-6">
                    </div>
                    <asp:LinkButton ID="lnkTeams" runat="server" TabIndex="11" Width="214px"></asp:LinkButton>
                    <div class="col-md-6">
                        <asp:Button ID="btnNew" runat="server" TabIndex="12" Text="New Team" Width="90px" />
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <asp:GridView ID="grdTeams" runat="server"></asp:GridView>

                            <div class="col-md-4">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </div>


        <table style="width: 249px; height: 164px">

            <tr>
                <td align="left" valign="top" colspan="2"></td>
                <td align="left" colspan="15">
                    <asp:TextBox ID="txtName" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="15px"
                        TabIndex="2" Width="186px"></asp:TextBox></td>
                <td align="left" colspan="2" style="width: 27px">
                    <asp:ImageButton ID="imgTeam" runat="server" Height="20px" ImageUrl="~/Images/SEARCH.JPG"
                        TabIndex="3" ToolTip="Search By Household" Width="20px" /></td>
                <td align="center" colspan="15" rowspan="9" valign="top">

                    <!--
                <igtbl:ultrawebgrid id="grdTeams-old" runat="server" height="195px" tabindex="10" width="300px"><Bands>
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

<DisplayLayout Version="4.00" AllowSortingDefault="OnClient" UseFixedHeaders="True" StationaryMargins="Header" AllowColSizingDefault="Free" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdTeams" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" TableLayout="Fixed" ScrollBarView="Vertical" RowHeightDefault="20px" SelectTypeRowDefault="Single" NoDataMessage="No Team To Display">
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

<FrameStyle Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="300px" Height="195px"></FrameStyle>

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

                    -->

                </td>
                <td style="width: 18px"></td>
            </tr>
            <tr>
                <td align="left" colspan="2" valign="top">
                    <asp:Label ID="lblTeamNnr" runat="server" Height="20px" Width="110px">Team No./Color:</asp:Label></td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtNumber" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="15px"
                        TabIndex="4" Width="26px" MaxLength="2"></asp:TextBox></td>
                <td align="left" colspan="14">
                    <asp:DropDownList ID="cmbColors" runat="server" Height="20px" TabIndex="5" Width="178px" Font-Size="Small">
                    </asp:DropDownList></td>
                <td align="left" colspan="1">
                    <asp:Button ID="btnSave" runat="server" TabIndex="13" Text="Save" Width="90px" /></td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="2" style="height: 24px">
                    <asp:Label ID="lblCoachName" runat="server" Height="20px" Width="110px">Coach Name:</asp:Label></td>
                <td align="left" colspan="17" style="height: 24px">
                    <asp:DropDownList ID="cmbCoach" runat="server" Height="20px" TabIndex="6" Width="219px">
                    </asp:DropDownList></td>
                <td style="width: 18px; height: 24px">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="14" Text="Delete" Width="90px" /></td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="2" style="height: 23px">
                    <asp:Label ID="lblCoachPhone" runat="server" Height="20px" Width="110px">Coach Phone:</asp:Label></td>
                <td align="left" colspan="17" style="height: 23px">
                    <asp:Label ID="lblCHPhone" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False"
                        Font-Underline="False" Height="20px" Width="219px"></asp:Label></td>
                <td align="left" colspan="1" rowspan="4" valign="top">&nbsp;<asp:Label ID="lblDeleteTeam" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 23px" valign="top"></td>
                <td align="left" colspan="17" style="height: 23px">
                    <asp:Label ID="lblCCPhone" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Font-Underline="False" Height="20px" Width="219px"></asp:Label></td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:Label ID="lblAsstCoach" runat="server" Height="20px" Width="110px">Asst Coach:</asp:Label></td>
                <td align="left" colspan="17">
                    <asp:DropDownList ID="cmbAsstCoach" runat="server" Height="20px" TabIndex="8" Width="219px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:Label ID="lblAsstPhone" runat="server" Height="20px" Width="110px">Asst Phone:</asp:Label></td>
                <td align="left" colspan="17">
                    <asp:Label ID="lblHAsstPhone" runat="server" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="False" Font-Underline="False" Height="20px" Width="219px"></asp:Label></td>
            </tr>
            <tr>
                <td align="left" colspan="2"></td>
                <td align="left" colspan="17">
                    <asp:Label ID="lblCAsstPhone" runat="server" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="False" Font-Underline="False" Height="20px" Width="219px"></asp:Label></td>
                <td align="left" colspan="1" rowspan="1" valign="top"></td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 23px">
                    <asp:Label ID="lblSponsor" runat="server" Height="20px" Width="110px">Sponsor:</asp:Label></td>
                <td align="left" colspan="17" style="height: 23px">
                    <asp:DropDownList ID="cmbSponsors" runat="server" Height="20px" TabIndex="9" Width="219px" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td style="width: 18px; height: 23px"></td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 23px">
                    <asp:Label ID="lblPreferredColor" runat="server" Height="20px" Width="110px">Preferred Color:</asp:Label></td>
                <td align="left" colspan="17" style="height: 23px">
                    <asp:Label ID="lblColors" runat="server" Font-Bold="False" Font-Underline="False" Height="20px"
                        Width="219px" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small"></asp:Label></td>
                <td align="right" colspan="15" rowspan="1" valign="top"></td>
                <td style="width: 18px; height: 23px"></td>
            </tr>
            <tr>
                <td align="center" colspan="10" style="height: 26px">&nbsp;<asp:Label ID="lblMembersList" runat="server" Font-Bold="True" Font-Underline="True" Height="20px"
                    Width="156px">Team Players</asp:Label>
                </td>
                <td align="center" colspan="24" style="height: 26px">
                    <asp:Button ID="btnAdd" runat="server" TabIndex="15" Text="Add to Team" Width="90px" />
                    <asp:Label ID="lblUndrafted" runat="server" Font-Bold="True" Font-Underline="True"
                        Height="20px" Width="208px">Undrafted Players</asp:Label>&nbsp;</td>
                <td align="center" colspan="1" style="height: 26px"></td>
            </tr>
            <tr>
                <td align="center" colspan="19" rowspan="3" valign="top" style="height: 171px" title="Teams Builder">
                    <asp:GridView ID="grdPlayers" runat="server"></asp:GridView>

                    <!--
                <igtbl:UltraWebGrid ID="grdPlayers" runat="server" CaptionAlign="Left" DisplayLayout-FixedColumnScrollType="Pixel"
                    DisplayLayout-HeaderTitleModeDefault="NotSet" DisplayLayout-ScrollBarView="Vertical"
                    DisplayLayout-TableLayout="fixed" DisplayLayout-UseFixedHeaders="false" DisplayLayout-ViewType="Flat"
                    Height="177px" Width="333px">
                    <Bands>
                        <igtbl:UltraGridBand>
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
                        HeaderTitleModeDefault="Never" Name="grdPlayers" RowHeightDefault="20px" RowSelectorsDefault="No"
                        ScrollBarView="Vertical" SelectTypeRowDefault="Single" StationaryMargins="Header"
                        TableLayout="Fixed" UseFixedHeaders="True" Version="4.00" NoDataMessage="No Players on Team" ScrollBar="Always">
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
                            Font-Names="Arial" Font-Size="9pt" Height="177px" Width="333px">
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
                </igtbl:UltraWebGrid></td>
            <td align="center" colspan="18" rowspan="3" valign="top" style="height: 171px">
                <igtbl:ultrawebgrid id="grdUndrafted" runat="server" height="177px" tabindex="10"
                    width="393px">
                <Bands>
                    <igtbl:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <FilterOptions EmptyString="" AllString="" NonEmptyString="">
                            <FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
                                <Padding Left="2px" />
                            </FilterDropDownStyle>
                            <FilterHighlightRowStyle ForeColor="White" BackColor="#151C55">
                            </FilterHighlightRowStyle>
                        </FilterOptions>
                    </igtbl:UltraGridBand>
                </Bands>
                <DisplayLayout Version="4.00" AllowSortingDefault="OnClient" UseFixedHeaders="True" StationaryMargins="Header" AllowColSizingDefault="Free" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdUndrafted" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" TableLayout="Fixed" RowHeightDefault="20px" SelectTypeRowDefault="Extended" NoDataMessage="No Player To Display">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                    </GroupByBox>
                    <GroupByRowStyleDefault BorderColor="Window" BackColor="Control">
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BorderWidth="1px" BorderColor="Silver" BackColor="Window">
                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <FilterOptionsDefault>
                        <FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
                            <Padding Left="2px" />
                        </FilterDropDownStyle>
                        <FilterHighlightRowStyle ForeColor="White" BackColor="#151C55">
                        </FilterHighlightRowStyle>
                    </FilterOptionsDefault>
                    <SelectedRowStyleDefault ForeColor="Black" BackColor="Gainsboro">
                    </SelectedRowStyleDefault>
                    <HeaderStyleDefault ForeColor="White" HorizontalAlign="Center" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" Font-Bold="True" BackColor="#002D62">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                    </HeaderStyleDefault>
                    <RowAlternateStyleDefault BackColor="WhiteSmoke">
                    </RowAlternateStyleDefault>
                    <EditCellStyleDefault BorderWidth="0px" BorderStyle="None">
                    </EditCellStyleDefault>
                    <FrameStyle Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="393px" Height="177px">
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
            </igtbl:UltraWebGrid>

                    -->
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td align="left" colspan="37" rowspan="1" valign="top" style="height: 12px">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                        Width="718px"></asp:Label></td>
            </tr>
        </table>
</asp:Content>





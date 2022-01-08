<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Sponsors.aspx.vb" Inherits="Sponsors" title="Sponsors Profile" %>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 303px">
    
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="lblSponsorName" runat="server" Font-Bold="True" Font-Underline="False"
                    Text="Sponsor Name:" Width="104px"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtSponsorName" runat="server" Width="226px" MaxLength="50" TabIndex="1"></asp:TextBox>
                <asp:ImageButton ID="imgSponsors" runat="server" Height="20px" ImageUrl="~/Images/SEARCH.JPG"
                    TabIndex="2" ToolTip="Search Sponsors" Width="20px" /></td>
            <td align="center">
                <asp:Label ID="lblSponsors" runat="server" Font-Bold="True" Font-Italic="False" Height="20px"
                    Text="Current Season Sponsors" Width="183px"></asp:Label></td>
            <td style="width: 4px">
                <asp:LinkButton ID="lnkPrint" runat="server" Height="20px" TabIndex="20" Width="95px" Font-Size="Small">Print Sponsors</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="lblContact" runat="server" Font-Bold="True" Font-Underline="False"
                    Text="Contact Name:" Width="104px"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtContact" runat="server" MaxLength="50" TabIndex="3" Width="250px"></asp:TextBox></td>
            <td align="center" rowspan="6">
                <igtbl:ultrawebgrid id="grdSponsors" runat="server" captionalign="Left" displaylayout-fixedcolumnscrolltype="Pixel"
                    displaylayout-headertitlemodedefault="NotSet" displaylayout-scrollbarview="Vertical"
                    displaylayout-tablelayout="fixed" displaylayout-usefixedheaders="false" displaylayout-viewtype="Flat"
                    height="138px" width="273px" style="left: -106px; top: -249px" TabIndex="17"><Bands>
<igtbl:UltraGridBand><RowEditTemplate>
                                <br  />
                                <p align="center">
                                    <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK"  />&nbsp;
                                    <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel"  /></p>
                            
</RowEditTemplate>

<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>

<FilterOptions EmptyString="" AllString="" NonEmptyString=""><FilterHighlightRowStyle ForeColor="White" BackColor="#151C55">
</FilterHighlightRowStyle>
    <FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
        <Padding Left="2px" />
    </FilterDropDownStyle>
</FilterOptions>
    <RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
    </RowTemplateStyle>
</igtbl:UltraGridBand>
                    </Bands>
                    <DisplayLayout Version="4.00" AllowSortingDefault="OnClient" NoDataMessage="No Sponsors Found" AllowColSizingDefault="Free" HeaderTitleModeDefault="Never" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdSponsors" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" ScrollBarView="Vertical" RowHeightDefault="20px" SelectTypeRowDefault="Single" ScrollBar="Always" TableLayout="Fixed" StationaryMargins="Header">
                        <GroupByBox>
                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                        </GroupByBox>
                        <GroupByRowStyleDefault BorderColor="Window" BackColor="Control">
                        </GroupByRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                        <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BorderWidth="1px" BorderColor="Silver" BackColor="Window">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <FilterOptionsDefault>
                            <FilterHighlightRowStyle ForeColor="White" BackColor="#151C55">
                            </FilterHighlightRowStyle>
                            <FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
                                <Padding Left="2px" />
                            </FilterDropDownStyle>
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
                        <FrameStyle BorderWidth="1px" BorderColor="Navy" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="273px" Height="138px">
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
</igtbl:ultrawebgrid></td>
            <td style="width: 4px">
                </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="lblAddress" runat="server" Font-Bold="True" Font-Underline="False"
                    Text="Address:" Width="104px"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtAddress" runat="server" Width="250px" AutoCompleteType="Disabled" MaxLength="50" TabIndex="4"></asp:TextBox></td>
            <td style="width: 4px">
                            <asp:Button ID="btnSave" runat="server" TabIndex="22" Text="Save" Width="90px" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="lblCity" runat="server" Font-Bold="True" Font-Underline="False" Text="City:"
                    Width="104px"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtCity" runat="server" Width="250px" MaxLength="50" TabIndex="5"></asp:TextBox></td>
            <td style="width: 4px">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="23" Text="Delete" Width="90px" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="lblState" runat="server" Font-Bold="True" Font-Underline="False" Text="State/Zip/Phone:"
                    Width="104px"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtState" runat="server" MaxLength="2" Width="21px" TabIndex="6"></asp:TextBox>&nbsp;
                <asp:TextBox ID="txtZip" runat="server" MaxLength="5" Width="60px" TabIndex="7"></asp:TextBox>&nbsp;<igtxt:webmaskedit id="txtPhone" runat="server" borderstyle="Solid" borderwidth="1px" inputmask="###-###-####" tabindex="8" width="93px" BackColor="Transparent" HorizontalAlign="Right" BorderColor="InactiveCaption"></igtxt:webmaskedit>
            </td>
            <td style="width: 4px" align="center" rowspan="3" valign="top">
                            <asp:Label ID="lblDelete" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                                Height="51px" Visible="False" Width="88px"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="lblUniform" runat="server" Font-Bold="True" Font-Underline="False"
                    Text="(Name on Shirt):" Width="104px" Font-Italic="True" Font-Size="Small"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtUniformName" runat="server" Width="250px" MaxLength="50" TabIndex="9"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="False" Text="Colors:"
                    Width="104px"></asp:Label></td>
            <td align="left" colspan="2"><asp:DropDownList ID="cmbColors" runat="server" Height="20px" TabIndex="10" Width="122px">
            </asp:DropDownList>&nbsp;&nbsp;
                <asp:DropDownList ID="cmbColors2" runat="server" Height="20px" TabIndex="11" Width="122px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" style="width: 134px; height: 26px;">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="False" Text="Size:"
                    Width="104px"></asp:Label></td>
            <td align="left" colspan="2" style="height: 26px">
                <asp:DropDownList ID="cmbSizes" runat="server" Height="20px" TabIndex="12" Width="124px">
                    <asp:ListItem Selected="True" Value="N/A">N/A</asp:ListItem>
                    <asp:ListItem Value="SMALL">SMALL</asp:ListItem>
                    <asp:ListItem Value="MEDIUM">MEDIUM</asp:ListItem>
                    <asp:ListItem Value="LARGE">LARGE</asp:ListItem>
                    <asp:ListItem Value="X-LARGE">X-LARGE</asp:ListItem>
                    <asp:ListItem Value="XX-LARGE">XX-LARGE</asp:ListItem>
                    <asp:ListItem Value="3X-LARGE">3X-LARGE</asp:ListItem>
                </asp:DropDownList></td>
            <td align="center" style="height: 26px">
                <asp:Label ID="lblPlayers" runat="server" Font-Bold="True" Font-Italic="False" Height="20px"
                    Text="Current Season Players" Width="183px"></asp:Label></td>
            <td style="width: 4px; height: 26px;" align="center">
                </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="lblWebsite" runat="server" Font-Bold="True" Font-Underline="False"
                    Text="Website:" Width="104px"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtWebsite" runat="server" Width="250px" MaxLength="50" TabIndex="13"></asp:TextBox></td>
            <td align="center" rowspan="9" valign="top">
                <igtbl:UltraWebGrid ID="grdPlayers" runat="server" CaptionAlign="Left" DisplayLayout-FixedColumnScrollType="Pixel"
                    DisplayLayout-HeaderTitleModeDefault="NotSet" DisplayLayout-ScrollBarView="Vertical"
                    DisplayLayout-TableLayout="fixed" DisplayLayout-UseFixedHeaders="false" DisplayLayout-ViewType="Flat"
                    Height="105px" Style="left: -106px; top: -249px" TabIndex="19" Width="273px">
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
                                <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                                </FilterHighlightRowStyle>
                                <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                    CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px" Width="200px">
                                    <Padding Left="2px" />
                                </FilterDropDownStyle>
                            </FilterOptions>
                            <RowTemplateStyle BackColor="Window" BorderColor="Window" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </igtbl:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                        CellClickActionDefault="RowSelect" ColWidthDefault="33%" HeaderClickActionDefault="SortMulti"
                        HeaderTitleModeDefault="Never" Name="grdPlayers" NoDataMessage="No Players Found"
                        RowHeightDefault="20px" RowSelectorsDefault="No" ScrollBar="Always" ScrollBarView="Vertical"
                        SelectTypeRowDefault="Single" TableLayout="Fixed" Version="4.00" StationaryMargins="Header">
                        <GroupByBox>
                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                        </GroupByRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderWidth="1px">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <FilterOptionsDefault>
                            <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                            </FilterHighlightRowStyle>
                            <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                Font-Size="11px" Width="200px">
                                <Padding Left="2px" />
                            </FilterDropDownStyle>
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
                        <FrameStyle BackColor="Window" BorderColor="Navy" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Arial" Font-Size="9pt" Height="105px" Width="273px">
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
            <td align="center" valign="top">
                </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Font-Underline="False" Text="Email:"
                    Width="104px"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtEmail" runat="server" Width="250px" MaxLength="50" TabIndex="14"></asp:TextBox></td>
            <td align="center" style="width: 172px">
                </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="False" Text="Season Fee:"
                    Width="106px"></asp:Label></td>
            <td align="left" colspan="2">
                <asp:DropDownList ID="cmbFees" runat="server" Height="20px" TabIndex="15" Width="100px">
                </asp:DropDownList></td>
            <td align="center" style="width: 172px">
            </td>
        </tr>
        <tr>
            <td align="left" rowspan="4">
                <asp:Label ID="lblBalCaption" runat="server" Font-Bold="True" Font-Underline="False"
                    Text="Balance:" Width="104px"></asp:Label></td>
            <td align="left" rowspan="4">
                <asp:Label ID="lblBalance" runat="server" Font-Bold="False" Font-Underline="False"
                    Width="100px" BorderStyle="None" BorderWidth="1px"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnPayments" runat="server" Height="20px" TabIndex="16" Width="81px">Payments</asp:LinkButton></td>
            <td align="left" rowspan="4">
            </td>
            <td align="left" colspan="1" rowspan="4">
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
            <td align="left" rowspan="1">
            </td>
            <td align="left" rowspan="1">
            </td>
            <td align="left" rowspan="1">
            </td>
            <td align="left" colspan="1" rowspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" rowspan="1">
                <asp:LinkButton ID="lnkComments" runat="server" Height="20px" TabIndex="16" Width="183px">Comments:</asp:LinkButton></td>
            <td align="left" rowspan="1">
            </td>
            <td align="left" colspan="1" rowspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" rowspan="3">
                <asp:TextBox ID="txtComments" runat="server" Height="52px" TextMode="MultiLine" Width="353px"></asp:TextBox></td>
            <td align="left" rowspan="1">
            </td>
            <td align="center" colspan="1" rowspan="1">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" Height="20px"
                    Text="Sponsors' Kids" Width="183px"></asp:Label></td>
            <td align="left" colspan="1" rowspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" rowspan="1">
            </td>
            <td align="center" colspan="1" rowspan="9" valign="top">
                <igtbl:ultrawebgrid id="grdKids" runat="server" captionalign="Left" displaylayout-fixedcolumnscrolltype="Pixel"
                    displaylayout-headertitlemodedefault="NotSet" displaylayout-scrollbarview="Vertical"
                    displaylayout-tablelayout="fixed" displaylayout-usefixedheaders="false" displaylayout-viewtype="Flat"
                    height="81px" width="273px" style="left: -316px; top: -120px" TabIndex="18">
                <Bands>
                    <igtbl:UltraGridBand>
                        <RowEditTemplate>
                            <br  />
                            <p align="center">
                                <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK"  />&nbsp;
                                <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel"  /></p>
                        </RowEditTemplate>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <FilterOptions EmptyString="" AllString="" NonEmptyString="">
                            <FilterHighlightRowStyle ForeColor="White" BackColor="#151C55">
                            </FilterHighlightRowStyle>
                            <FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
                                <Padding Left="2px" />
                            </FilterDropDownStyle>
                        </FilterOptions>
                        <RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                        </RowTemplateStyle>
                    </igtbl:UltraGridBand>
                </Bands>
                <DisplayLayout Version="4.00" AllowSortingDefault="OnClient" NoDataMessage="No Players Sponsored" AllowColSizingDefault="Free" HeaderTitleModeDefault="Never" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="grdKids" BorderCollapseDefault="Separate" ColWidthDefault="33%" RowSelectorsDefault="No" ScrollBarView="Vertical" RowHeightDefault="20px" SelectTypeRowDefault="Single" ScrollBar="Always" TableLayout="Fixed" StationaryMargins="Header">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                    </GroupByBox>
                    <GroupByRowStyleDefault BorderColor="Window" BackColor="Control">
                    </GroupByRowStyleDefault>
                    <ActivationObject BorderColor="" BorderWidth="">
                    </ActivationObject>
                    <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BorderWidth="1px" BorderColor="Silver" BackColor="Window">
                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <FilterOptionsDefault>
                        <FilterHighlightRowStyle ForeColor="White" BackColor="#151C55">
                        </FilterHighlightRowStyle>
                        <FilterDropDownStyle BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" Font-Size="11px" Font-Names="Verdana,Arial,Helvetica,sans-serif" BackColor="White" Width="200px" CustomRules="overflow:auto;">
                            <Padding Left="2px" />
                        </FilterDropDownStyle>
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
                    <FrameStyle BorderWidth="1px" BorderColor="Navy" BorderStyle="Solid" Font-Size="9pt" Font-Names="Arial" BackColor="Window" Width="273px" Height="81px">
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
            <td align="left" colspan="1" rowspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" rowspan="1">
            </td>
            <td align="left" colspan="1" rowspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" rowspan="1">
            </td>
            <td align="left" rowspan="1">
            </td>
            <td align="left" rowspan="1">
            </td>
            <td align="left" colspan="1" rowspan="1">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" rowspan="5" valign="top">
                </td>
            <td align="left" colspan="1" rowspan="5" valign="top">
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
            <td align="left" colspan="3" rowspan="1" valign="top">
            </td>
            <td align="left" colspan="1" rowspan="1" valign="top">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="5" style="height: 21px">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Width="748px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


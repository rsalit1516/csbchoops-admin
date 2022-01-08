<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BoardUPD.aspx.vb" Inherits="BoardUPD" title="Board Members" %>

<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics2.WebUI.WebCombo.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-8">
        <gridview ID="grdBM" runat="server"
                               AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered table-condensed"
                    RowStyle-CssClass="td"
                    HeaderStyle-CssClass="th"
                    AutoGenerateSelectButton="True" 
                    DataKeyNames="ID"
                    ItemType="CSBC.Core.Models.Director"
                    SelectMethod="GetAllRecords"
                    AutoGenerateEditButton="True"
                    AutoGeneratedDeleteButton="true">
                    <Columns>
                        <asp:DynamicField DataField ="ID" />
                        <asp:DynamicField DataField ="Title" />
                        <asp:DynamicField DataField ="People.LastName" />

                    </Columns>

                </gridview> 
                </div>
        </div>
        </div>
    <table style="width: 749px; height: 198px">
        <tr>
            <td align="left" colspan="2" style="height: 26px">
                
</td>
            <td align="left" style="width: 270px; height: 26px">
                <table style="width: 116px">
                    <tr>
                        <td>
                <asp:Button ID="btnNew" runat="server" Text="New" Width="104px" /></td>
                    </tr>
                    <tr>
                        <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="104px" /></td>
                    </tr>
                    <tr>
                        <td>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="104px" /></td>
                    </tr>
                    <tr>
                        <td align="center" rowspan="3" valign="top">
                <asp:Label ID="lblDeleteBM" runat="server" Font-Size="Small" ForeColor="Red" Width="100px" Font-Bold="True"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" rowspan="1" style="width: 312px">
                <asp:Label ID="lblBoard" runat="server" Font-Bold="True" Text="Board Members (Volunteers):"
                    Width="309px"></asp:Label></td>
            <td align="left" style="height: 26px; width: 270px;">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Text="Title:" Width="307px"></asp:Label></td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="left" rowspan="5" style="width: 312px" valign="top" bordercolor="#000000">
                <asp:DropDownList ID="cboBM" runat="server" Width="295px" AutoPostBack="True">
                </asp:DropDownList>
                <table style="width: 306px; height: 135px">
                    <tr>
                        <td style="width: 302px;" rowspan="4">
                            <table style="width: 145px">
                                <tr>
                                    <td style="width: 301px">
                            <asp:Label ID="lblName" runat="server" Font-Bold="True" Width="298px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 301px">
                            <asp:Label ID="lblAddress" runat="server" Height="19px" Width="298px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 301px">
                            <asp:Label ID="lblCSZ" runat="server" Height="19px" Width="298px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 301px; height: 21px">
                            <asp:Label ID="lblPhone" runat="server" Height="19px" Width="298px"></asp:Label></td>
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
                </table>
            </td>
            <td align="left" style="height: 26px; width: 270px;" valign="top">
                <asp:TextBox ID="txtTitle" runat="server" Width="307px"></asp:TextBox></td>
            <td align="left" style="width: 270px; height: 26px" valign="top">
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 26px; width: 270px;">
                <asp:Label ID="lblPreferredphone" runat="server" Font-Bold="True" Text="Preferred Phone:"
                    Width="307px"></asp:Label></td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 26px; width: 270px;">
                <asp:DropDownList ID="cobPhones" runat="server" Width="307px">
                </asp:DropDownList></td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 26px; width: 270px;">
                <asp:CheckBox ID="chkEmail" runat="server" Font-Bold="True" Text="Hide Email" TextAlign="Left"
                    Width="307px" /></td>
            <td align="left" style="width: 270px; height: 26px">
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 10px; width: 270px;">
                <asp:Label ID="lblEmail" runat="server" Height="19px" Width="307px"></asp:Label></td>
            <td align="left" style="width: 270px; height: 10px">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" rowspan="1" valign="top">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#C00000" Width="735px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="true" CodeBehind="GameSchedules.aspx.cs" Inherits="CSBC.Admin.Web.GameSchedules" %>
<%@ MasterType VirtualPath="~/CSBCAdminMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width: 402px; height: 149px">
        <tr>
            <td align="left" rowspan="11" valign="top">
                &nbsp;<asp:Calendar ID="Calendar1" runat="server">
                    <SelectedDayStyle BackColor="#E0E0E0" />
                    <TodayDayStyle BackColor="White" />
                </asp:Calendar>
            </td>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Division:" Width="128px"></asp:Label></td>
            <td colspan="2" align="left"><asp:DropDownList ID="cmbDivisions" runat="server" Height="20px" TabIndex="1" Width="264px">
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 21px" align="right">
                <asp:Label ID="lblDate" runat="server" Text="Date / Time:" Width="128px" Font-Bold="True"></asp:Label></td>
            <td colspan="2" style="height: 21px" align="left">
                <asp:TextBox id="txtGameDate" runat="server"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="txtTime" runat="server" MaxLength="20" TabIndex="3"
                    Width="80px" ForeColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>&nbsp;
                <asp:Label ID="lblPlayoff" runat="server" Text="* Playoff *" Width="88px" Font-Bold="True" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 24px">
                <asp:Label ID="lblLocation" runat="server" Text="Location:" Width="128px" Font-Bold="True"></asp:Label></td>
            <td colspan="2" align="left" style="height: 24px"><asp:DropDownList ID="cmbVenues" runat="server" Height="20px" TabIndex="4" Width="264px">
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblHome" runat="server" Text="Teams:" Width="128px" Font-Bold="True"></asp:Label></td>
            <td colspan="2" align="left">
                <asp:TextBox ID="txtHome" runat="server" ForeColor="Black" MaxLength="20" TabIndex="5"
                    Width="64px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                v
                <asp:TextBox ID="txtVisitor" runat="server" ForeColor="Black" MaxLength="20" TabIndex="6"
                    Width="64px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                <asp:TextBox ID="txtDescr" runat="server" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black"
                    MaxLength="20" TabIndex="7" Visible="False" Width="64px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" colspan="2" rowspan="6">
                <asp:ListBox ID="lstEmails" runat="server" Font-Names="Courier New" Font-Size="Small"
                    Height="88px" SelectionMode="Multiple" Width="408px"></asp:ListBox></td>
            <td align="center">
                <asp:Button ID="btnNew" runat="server" TabIndex="8" Text="New" Width="104px" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" TabIndex="9" Text="Save" Width="104px" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnDelete" runat="server" TabIndex="10" Text="Delete" Width="104px" Enabled="False" /></td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Label ID="lblDeleteDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Height="61px" Width="89px"></asp:Label></td>
        </tr>
    
        <tr>
            <td style="width: 163px">
            </td>
            <td>
                <asp:Button ID="btnSend" runat="server" TabIndex="11" Text="Email" Width="104px" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" rowspan="8" valign="top">
                
                <asp:GridView id = "gridGames" runat="server"></asp:GridView>
                
                                <br  />
                                <p align="center">
                                    <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK"  />&nbsp;
                                    <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel"  /></p>
                            
</td>
        
        <tr>
            <td colspan="3">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    Width="600px"></asp:Label></td>
            <td colspan="1">
            </td>
        </tr>
    </table>
</asp:Content>

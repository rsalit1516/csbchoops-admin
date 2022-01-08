<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Colors.aspx.vb" Inherits="Colors" title="Uniform Colors" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script id="Infragistics" type="text/javascript">
<!--

function grdMembers_DELETE(gridName, cellId){
	//Add code to handle your event here.
}
// -->
</script>
<script language="javascript" type="text/javascript">
<!--

// -->
</script>

    
    <table style="width: 371px; height: 123px">
        <tr>
            <td align="left">
                <asp:Label ID="lblName" runat="server" Text="Name:" Width="86px"></asp:Label></td>
            <td align="left" style="width: 222px">
                <asp:TextBox ID="txtName" runat="server" Width="399px" TabIndex="1"></asp:TextBox></td>
            <td style="width: 60px">
                <asp:Button ID="btnNew" runat="server" Text="New" Width="90px" TabIndex="3" /></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblDiscontinue" runat="server" Text="Discontinued:" Width="85px"></asp:Label></td>
            <td style="width: 222px" align="left">
                <asp:CheckBox ID="chkDiscontinue" runat="server" TabIndex="2" Width="136px" />
                </td>
            <td style="width: 60px">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="90px" TabIndex="4" /></td>
        </tr>
        <tr>
            <td align="left" style="height: 22px">
                <asp:Label ID="lblID" runat="server" Width="40px" Visible="False"></asp:Label></td>
            <td style="width: 222px; height: 22px">
                </td>
            <td align="center" rowspan="2" style="width: 60px" valign="top">
                </td>
        </tr>
        <tr>
            <td align="left">
                </td>
            <td style="width: 222px">
                </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:GridView id="grdColors" runat="server"
                    AutoGenerateColumns ="true">


                </asp:GridView>
</td>
            <td colspan="1">
                </td>
        </tr>
        <tr>
            <td align="left" colspan="3" valign="top" style="height: 17px">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Width="600px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


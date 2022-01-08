<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DraftListReport.aspx.cs" Inherits="CSBC.Admin.Web.DraftListReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
    
    </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDivisionPlayers" TypeName="CSBC.Core.Repositories.PlayerRepository">
            <SelectParameters>
                <asp:Parameter DefaultValue="757" Name="divisionId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

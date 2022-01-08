<%@ page language="VB" autoeventwireup="false" inherits="_Default, App_Web_2dfoq8ib" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=12.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" Runat="server" AutoDataBind="True"
            Height="947px" ReportSourceID="CrystalReportSource1" Width="845px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Reports/CrystalReport1.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>

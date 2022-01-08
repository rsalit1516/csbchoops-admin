<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="CSBC.Admin.Web.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />


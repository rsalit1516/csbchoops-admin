<%@ Page Title="" Language="C#" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="true" CodeBehind="Announce.aspx.cs" Inherits="CSBC.Admin.Web.Announce" %>

<%@ Register Src="~/MailForm.ascx" TagPrefix="uc1" TagName="MailForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <uc1:MailForm runat="server" id="MailForm" />
    </div>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="CSBC.Admin.Web.Header" %>
<%@  Reference VirtualPath="~/CSBCAdminMasterPage.master" %>

<header class="row">
    <form runat="server">
        <div class="col-md-6">
            <div class="center-block">
                <asp:Label ID="lblTitle" runat="server" CssClass="h3"></asp:Label>
            </div>
        </div>
        <div class="col-md-3 ">
            <asp:DropDownList ID="ddlSeasons" runat="server" CssClass="form-control dropdown"></asp:DropDownList>
            <asp:Label ID="lblActiveSeason" runat="server" class="text-info"></asp:Label>
        </div>
        <div class="col-md-3 pull-right">
            <asp:Label ID="lblUser" runat="server" CssClass="text-success"></asp:Label>

        </div>
    </form>
</header>

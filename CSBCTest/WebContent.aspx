<%@ Page Title="Web Content" Language="C#" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="true"
    CodeBehind="WebContent.aspx.cs"
    Inherits="CSBC.Admin.Web.WebContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="col-sm-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="panel-title">Content Detail</div>
                </div>
                <div class="panel-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtTitle">Title</label>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtSubTitle">Sub-Title</label>
                            <asp:TextBox ID="txtSubTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    
                   
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="txtBody">Body</label>
                            <asp:TextBox ID="txtBody" TextMode="MultiLine" runat="server" Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="dropdown">
                            <label for="txtType">Type</label>
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtLocation">Location</label>
                            <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtDateAndTime">Date and Time</label>
                            <asp:TextBox ID="txtDateAndTime" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtExpiration">Expiration</label>
                            <asp:TextBox ID="txtExpiration" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <asp:HiddenField ID="txtWebContentId" runat="server" />
                </div>
                <div class="panel-footer">
                    <div class="btn-group">
                        <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnNew" OnClick="btnNew_Click" Text="New" />
                        <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnSave" OnClick="btnSave_Click" Text="Save" />
                        <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnCancel" OnClick="btnCancel_Click" Text="Cancel" />
                         <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnDelete" OnClick="btnDelete_Click" Text="Delete" />
                    </div>
                </div>
            </div>

            <%--<div ng-include="'app/webcontent/webcontentsummary.html'"></div>--%>
            <div class="col-sm-12">
                <div class="col-sm-6">
                    <div class="well well-sm">
                        <asp:CheckBox runat="server" ID="chkShowExpired" Text="Show Expired" AutoPostBack="true" OnCheckedChanged="chkShowExpired_CheckedChanged" />
                    </div>
                </div>
                <asp:GridView ID="gridContent" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered"
                    RowStyle-CssClass="td"
                    HeaderStyle-CssClass="th"
                    ItemType="CSBC.Core.Models.WebContent"
                    DataKeyNames="WebContentId"
                    OnRowCommand="gridContent_RowCommand">
                    <Columns>
                        <asp:TemplateField ShowHeader="true">
                            <HeaderTemplate>Title</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkTitle" runat="server" Text='<%# Item.Title%>'
                                    CommandName="Select"
                                    CommandArgument='<%# Item.WebContentId%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="true">
                            <HeaderTemplate>SubTitle</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSubTitle" runat="server" Text='<%# Item.SubTitle%>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="true">
                            <HeaderTemplate>Type</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text='<%# Item.WebContentType.WebContentTypeDescription%>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="true">
                            <HeaderTemplate>Body</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblBody" runat="server" Text='<%# Item.Body%>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="true">
                            <HeaderTemplate>Expiration</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblExpiration" runat="server" Text='<%# Item.ExpirationDate.Value.ToShortDateString()%>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </section>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="~/Scripts/jquery-ui-1.11.4.js"></script>

    <script src="Scripts/bootstrap.min.js"></script>
    <%-- <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/angular-sanitize.min.js"></script>--%>
    <script src="Scripts/toastr.min.js"></script>
    <script src="app/PageBehavior.js"></script>

    <script src="/Scripts/CSBCUI.js" type="text/javascript"></script>
    <%-- <script src="app/app.js"></script>
    <script src="app/webContent/webContentSummary.js"></script>
    <script src="app/webContent/webContent.js"></script>--%>
</asp:Content>

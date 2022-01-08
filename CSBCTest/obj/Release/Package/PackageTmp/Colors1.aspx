﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="true" CodeBehind="Colors1.aspx.cs" Inherits="CSBC.Admin.Web.Colors1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-8">
        <section class="panel panel-primary">
            <div class="panel-heading">
                <div class="panel-title">
                    Colors
                </div>
            </div>

            <div style="overflow-y: scroll; height: 400px">

                <asp:GridView ID="grdColors" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered table-condensed"
                    RowStyle-CssClass="td"
                    HeaderStyle-CssClass="th"
                    AutoGenerateSelectButton="False"
                    DataKeyNames="ID"
                    ItemType="CSBC.Core.Models.Color"
                    SelectMethod="GetAllRecords"
                    UpdateMethod="grdColors_UpdateItem"
                    DeleteMethod="grdColors_DeleteItem"
                    AutoGenerateEditButton="True"
                    AutoGeneratedDeleteButton="True">
                    <Columns>
                        <asp:BoundField DataField="ID" />
                        <asp:BoundField DataField="ColorName" HeaderText="Color Name" />
                        <asp:BoundField DataField="Discontinued" HeaderText="Discontinued" />

                    </Columns>
                </asp:GridView>

            </div>
        </section>
    </div>
    <div class="col-md-4">
        <section class="panel panel-primary">
            <div class="panel-heading">
                <div class="panel-title">Color</div>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="txtName" class="control-label">
                        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                    </label>
                    <asp:TextBox ID="txtName" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                </div>
                <div class="form-group checkbox-inline col-md-6">
                    <%--<label for="chkDiscontinue" class="control-label">Discontinued</label>--%>
                    <asp:CheckBox ID="chkDiscontinue" runat="server" TabIndex="2" Text="Discontinued" CssClass="control-label" />
                </div>

            </div>

            <div class="panel-footer btn-group">
                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" TabIndex="3" OnClick="btnNew_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" TabIndex="4" OnClick="btnSave_Click" />
            </div>
        </section>
    </div>

    <asp:Label ID="lblID" runat="server" Width="40px" Visible="False"></asp:Label>



    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Width="600px"></asp:Label>

</asp:Content>

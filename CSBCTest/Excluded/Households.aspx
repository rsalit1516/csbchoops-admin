<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="true" CodeFile="Households.aspx.vb" Inherits="Households" Title="Households" %>

<%@ Import Namespace="CSBCHoops.Web.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row">
        <div class="col-md-8">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="panel-title">
                        Household Info
                    </div>
                </div>
                <div class="panel-body">

                    <div class="form-group col-md-8">
                        <label class="control-label" for="txtName">
                            Household Name</label>
                        <asp:TextBox ID="txtName" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <a href="searchHouse.aspx"><span class="glyphicon glyphicon-search"></span></a>
                    </div>

                    <div class="form-group col-md-8">
                        <label class=" control-label" for="lblAddress">
                            Address
                        </label>

                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" TabIndex="3">
                        </asp:TextBox>
                    </div>
                    <!--<div class="col-md-1">
                            <asp:ImageButton ID="imgAddress" runat="server" Height="20px" class="glyphicon glyphicon-search"
                                TabIndex="4" ToolTip="Search By Address" />
                        </div> -->

                    <div class="col-md-2 ">
                        <a href="searchHouse.aspx"><span class="glyphicon glyphicon-search"></span></a>

                    </div>

                    <div class="form-group col-md-8">
                        <label class="control-label" for="txtAddress2">
                            Address 2
                        </label>

                        <asp:TextBox ID="txtAddress2" runat="server" class="form-control" TabIndex="5"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label" for="lblCity">
                            City
                        </label>
                        <asp:TextBox ID="txtCity" runat="server" class="form-control" TabIndex="6"></asp:TextBox>
                    </div>


                    <div class="form-group col-md-3">
                        <label for="txtState">State</label>
                        <asp:TextBox ID="txtState" runat="server" class="form-control" TabIndex="8"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-3">
                        <label class="control-label" for="txtZip">Zip</label>
                        <asp:TextBox ID="txtZip" runat="server" class="form-control" TabIndex="9"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label class="control-label" for="lblPhone">Phone</label>
                        <asp:TextBox ID="txtPhone" runat="server" class="form-control" TabIndex="6"></asp:TextBox>

                    </div>

                    <div class="form-group col-md-6">
                        <label class="control-label" for="lblEmail">
                            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                        </label>

                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" TabIndex="12"></asp:TextBox>
                    </div>


                    <div class="col-md-2 checkbox">
                        <asp:CheckBox ID="chkEmail" runat="server" TabIndex="9" Text="Mailing List" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="txtSportsCard">Sports Card</label>
                        <asp:TextBox ID="txtCityCard" runat="server" class="form-control" TabIndex="14"></asp:TextBox>
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblUserNameCaption" runat="server" Text="UserName:" Width="180px"></asp:Label>
                        <asp:Label ID="lblUserName" runat="server" Width="254px"></asp:Label>
                    </div>
                </div>
                <div class="panel-footer btn-group">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Member" CssClass="btn btn-primary" TabIndex="17" />  
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" TabIndex="15" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary" TabIndex="16" />
                    <asp:Label ID="lblDelete" runat="server" Visible="False" Width="88px" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
        <label>
            <asp:Label ID="lblMembersList" runat="server" Font-Bold="True" Font-Underline="True" Text="Household Members"></asp:Label></label>

       
        <asp:GridView ID="grdMembers" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <div class="row">
            <asp:LinkButton ID="btnComments" runat="server" TabIndex="20">Comments</asp:LinkButton>
        </div>
        <table style="width: 371px; height: 123px">
            <tr>
                <td colspan="2" align="left"></td>
                <td colspan="2">
                    <asp:TextBox ID="txtComments" runat="server" Height="131px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" colspan="4" valign="top">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Width="600px"></asp:Label></td>
            </tr>
        </table>
        <asp:HiddenField ID="hidEMail" runat="server" />
    </div>
    <asp:ListBox ID="listHouseHolds" runat="server" AutoPostBack="True"></asp:ListBox>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" CodeFile="SearchHouse.aspx.vb" Inherits="SearchHouse" Title="Search Households" %>
<script runat="server"></script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
        
            <div class="row">
                <div class="col-md-offset-1 col-md-8">

                    <div class="table-responsive">
                        <asp:GridView ID="grdHouseholds" runat="server" 
                            CssClass="table table-hover" 
                            AutoGenerateColumns="false"
                            DataKeyNames="HouseId"                  
                            OnRowCommand="grdHouseholds_OnRowCommand"
                            ItemType ="CSBC.Core.Models.Household">
                            <RowStyle CssClass="table" />
                            <Columns>
                                <asp:TemplateField HeaderText="Team No." ItemStyle-Width="10px" ShowHeader="true">
                                    <HeaderTemplate>Name</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkName" runat="server" Text='<%# Item.Name%>'
                                            CommandName="Select"
                                            CommandArgument='<%# Item.HouseID%>'></asp:LinkButton>
                                    </ItemTemplate>

                                    <ItemStyle Width="10px"></ItemStyle>    
                                    </asp:TemplateField>
                                
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Address1" HeaderText="Address" />
                                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:TemplateField>

                                    <ItemTemplate>

                                        <asp:Button ID="Button1" runat="server" Text='Select'
                                            CommandArgument="Button1" OnClick="Button1_OnClick" />

                                    </ItemTemplate>

                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>

                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-md-offset-3 col-md-6">

                <div class="form-group">
                    <label class="" for="txtLastName">
                        <asp:Label ID="lblName" runat="server" Font-Bold="True" Text="Family Name" Width="120px"></asp:Label>
                    </label>


                    <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn" />

                </div>
                <div class="form-group">
                    <label class="" for="txtAddress">

                        <asp:Label ID="lblAddress" runat="server" Text="Address"
                            Width="120px"></asp:Label></label>

                    <asp:TextBox ID="txtAddress" runat="server" class="form-control"></asp:TextBox>

                    <asp:Button ID="btnNew" runat="server" Text="Add New" class="btn" />

                </div>
                <asp:Label ID="lblError" runat="server" class="label-danger"></asp:Label>
            </div>
        </div>

</asp:Content>


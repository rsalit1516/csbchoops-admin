<%@ Page Language="C#" MasterPageFile="~/CSBCAdminMasterPage.master" AutoEventWireup="false" Inherits="Welcome.aspx.cs Title="Welcome To CSBC" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
        <div class="container">
            <h2>Welcome</h2>
            <form runat="server">
                   <asp:GridView ID="grdTotals" 
                    runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="DivisionID">
                            <Columns>
                                <asp:BoundField DataField="DivisionID" HeaderText="DivisionID" >
                                <ItemStyle Width="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Div_Desc" HeaderText="Division">
                                <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Totals" >
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Coaches" HeaderText="Coaches" >
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Sponsors" HeaderText="Sponsors" >
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalOR" HeaderText="Online Total" >
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Coaches" HeaderText="Online Coaches" >
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SponsorsOR" HeaderText="Online Sponsors" >
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                            </Columns>
            </asp:GridView>                             
            </form>
            <asp:Label ID="lblError" runat="server" class="has-error"></asp:Label>&nbsp;&nbsp;
        </div>
   
</asp:Content>


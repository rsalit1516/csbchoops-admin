<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="CSBC.Admin.Web.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Coral Springs Basketball Club - Login</title>
        <link href="~/Content/bootstrap.css" rel="stylesheet" media="screen" />
    <style type="text/css">
        body {
            padding-top: 30px;
        }
    </style>
    <link href="~/Content/bootstrap-responsive.css" rel="stylesheet" />
    <link href="~/Content/body.css" rel="stylesheet" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />

</head>
<body>
   

    <div class="container">
        <img style="HEIGHT: 109px" height="109" alt="" src="Images/top.jpg" width="770" border="0"/>
        <div class="row">
            <div class="container">
            <div class="col-md-offset-3 col-md-4">
                <form class="form-horizontal center-block" runat="server" role="form">
                    <div class="form-group">
                        <label class="control-label" for="txtUserName">
                            <asp:Label ID="Label2" runat="server" Text="User Name:"></asp:Label>
                        </label>
                        <div>
                            <asp:TextBox ID="txtUserName" runat="server" class="form-control"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group center-block">
                        <label class="control-label" for="txtPassweord">
                            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
                        </label>
                        <div>
                        </div>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control">
                        </asp:TextBox>
                    </div>
                    <asp:Button class="btn btn-default" type="button" ID="btnSubmit" runat="server" CommandName="CommandBtn_Click" 
                        Text="Log In" UseSubmitBehavior="True" CommandArgument="Submit" />
                    <asp:LinkButton ID="lnkPassword" runat="server" Font-Size="Small">Forgot Password?</asp:LinkButton>
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                </form>
       </div>
                     </div>
        </div>
    </div>

</body>
</html>
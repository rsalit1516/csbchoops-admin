Imports System.Data
Imports CSBC.Components
Partial Class SearchRegistration
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Search Registration/Payments"
            Session("AccessType") = AccessType()
            Call LoadRows()
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Payments", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = "AccessType::" & ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadRows()
        Dim oPayments As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPayments.GetPlayer(0, Session("CompanyID"), Session("SeasonID"))
            grdRegistrations.Clear()
            grdRegistrations.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdRegistrations
                    .DataSource = rsData
                    .DataBind()
                    With grdRegistrations.DisplayLayout.Bands(0).Columns
                        .FromKey("PlayerID").Hidden = True
                        .FromKey("PeopleID").Hidden = True
                        .FromKey("div_desc").Header.Caption = "Division"
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadRows::" & ex.Message
        Finally
            oPayments = Nothing
        End Try
    End Sub

    Protected Sub grdRegistrations_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdRegistrations.SelectedRowsChange
        Session("PlayerID") = grdRegistrations.DisplayLayout.ActiveRow.Cells.FromKey("PlayerID").Value
        Session("PeopleID") = grdRegistrations.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
        Response.Redirect("Payments.aspx")
    End Sub

End Class


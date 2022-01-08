Imports System.Data
Imports System.Data.SqlClient
Imports CSBC.Components

Public Class ReportRosters
    Inherits System.Web.UI.Page
    Private rsData As DataTable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Call GetDivisions()
        End If
        Session("Title") = "Roster Reports"
    End Sub

    Private Sub GetDivisions()
        Dim oDivisions As New Season.ClsDivisions
        Dim rsData As DataTable
        Try
            rsData = oDivisions.LoadDivision(0, Session("CompanyID"), Session("SeasonID"), "DivisionID, Div_Desc as Division, Teams")
            grdDivisions.ResetBands()
            With grdDivisions
                .DataSource = rsData
                .DataBind()
            End With
            With grdDivisions.DisplayLayout.Bands(0).Columns
                .FromKey("DivisionID").Hidden = True
                .FromKey("Division").Width = 100
                .FromKey("Teams").Hidden = True
            End With
        Catch ex As Exception
            lblError.Text = "GetDivisions::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If grdDivisions.DisplayLayout.SelectedRows.Count = 0 Then Exit Sub
        Session("DivisionID") = grdDivisions.DisplayLayout.ActiveRow.Cells.FromKey("DivisionID").Value()
        Session("DivDesc") = grdDivisions.DisplayLayout.ActiveRow.Cells.FromKey("Division").Value()
        Session("DivisionTeams") = grdDivisions.DisplayLayout.ActiveRow.Cells.FromKey("Teams").Value()
        Response.Redirect("report.aspx?Report=Roster.rpt")
    End Sub

   
End Class


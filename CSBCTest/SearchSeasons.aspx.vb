Imports System.Data
Imports CSBC.Components
Partial Class SearchSeasons
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Search Seasons"
            Session("AccessType") = AccessType()
            Call LoadRows()
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Seasons", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = "AccessType::" & ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadRows()
        Dim oSeasons As New Season.ClsSeasons
        Dim rsData As DataTable
        Try
            rsData = oSeasons.GetRecords(Session("CompanyID"))
            grdSeasons.Clear()
            grdSeasons.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdSeasons
                    .DataSource = rsData
                    .DataBind()
                    With grdSeasons.DisplayLayout.Bands(0).Columns
                        .FromKey("SeasonID").Hidden = True
                        .FromKey("Sea_Desc").Header.Caption = "Season"
                        .FromKey("Sea_Desc").Width = 170
                        .FromKey("FromDate").Width = 70
                        .FromKey("FromDate").Format = "MM/dd/yyyy"
                        .FromKey("FromDate").CellStyle.HorizontalAlign = HorizontalAlign.Right
                        .FromKey("FromDate").Header.Caption = "From"
                        .FromKey("ToDate").Width = 70
                        .FromKey("ToDate").Format = "MM/dd/yyyy"
                        .FromKey("ToDate").CellStyle.HorizontalAlign = HorizontalAlign.Right
                        .FromKey("ToDate").Header.Caption = "To"
                        .FromKey("CurrentSeason").Header.Caption = "Current"
                        .FromKey("CurrentSeason").Width = 80
                        .FromKey("CurrentSeason").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("CurrentSignUps").Header.Caption = "Online"
                        .FromKey("CurrentSignUps").Width = 100
                        .FromKey("CurrentSignUps").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("CurrentSchedule").Header.Caption = "Schedules"
                        .FromKey("CurrentSchedule").Width = 80
                        .FromKey("CurrentSchedule").CellStyle.HorizontalAlign = HorizontalAlign.Center
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oSeasons = Nothing
        End Try
    End Sub

    Protected Sub grdSeasons_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdSeasons.SelectedRowsChange
        Session("SeasonID") = grdSeasons.DisplayLayout.ActiveRow.Cells.FromKey("SeasonID").Value
        Session("SeasonDesc") = grdSeasons.DisplayLayout.ActiveRow.Cells.FromKey("Sea_Desc").Value
        Response.Redirect("Welcome.aspx")

    End Sub
End Class

Imports System.Data
Imports System.Data.SqlClient
Imports CSBC.Components

Public Class SearchSponsor
    Inherits System.Web.UI.Page
    Private rsData As DataTable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            If Session("FirstLetter") > "" Then txtName.Text = Session("FirstLetter")
            Call GetData()
            Session("Title") = "Search Sponsors"
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Session("FirstLetter") = ""
        If txtName.Text > "" Then
            Session("FirstLetter") = txtName.Text
        End If
        Call GetData()
    End Sub

    Private Sub GetData()
        Dim oSponsors As New Season.clsSponsors
        Try
            rsData = oSponsors.LoadAllponsors(0, Session("CompanyID"), Session("SeasonID"), Session("FirstLetter"), "SponsorProfileID, spoName")
            grdSponsors.Clear()
            If rsData.Rows.Count > 0 Then
                With grdSponsors
                    .DataSource = rsData
                    .DataBind()
                    With .DisplayLayout.Bands(0).Columns
                        .FromKey("SponsorProfileID").Hidden = True
                        .FromKey("SpoName").Width = 100
                        .FromKey("SpoName").Header.Caption = "Name"
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "GetData::" & ex.Message
        Finally
            oSponsors = Nothing
        End Try
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Session.Add("SponsorProfileID", 0)
        'Session("FirstLetter") = grdSponsors.DisplayLayout.ActiveRow.Cells.FromKey("SpoName").Value()
        Response.Redirect("Sponsors.aspx")
    End Sub

    Protected Sub grdSponsors_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdSponsors.SelectedRowsChange
        Session("SponsorProfileID") = grdSponsors.DisplayLayout.ActiveRow.Cells.FromKey("SponsorProfileID").Value()
        Session("FirstLetter") = grdSponsors.DisplayLayout.ActiveRow.Cells.FromKey("SpoName").Value()
        Response.Redirect("Sponsors.aspx")
    End Sub

End Class


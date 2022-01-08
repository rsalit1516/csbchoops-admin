Imports System.Data
Imports CSBC.Components
Imports CSBC.Core.Models

Partial Class Seasons
    Inherits System.Web.UI.Page
    Private sGlobal As New CSBC.Components.ClsGlobal

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Seasons"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnNew.Enabled = False
            End If
            Me.txtName.Focus()
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
        Dim oSeasons As New Season
        Dim dataContext As New CSBC.Core.Data.CSBCDbContext
        Dim rep As New SeasonRepository(dataContext)
        Dim rsData As DataTable
        Try
            rsData = rep.GetRecords(Session("CompanyID"))
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

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oSeason As New Season.ClsSeasons
        'Try
        '    With oSeason
        '        .CompanyID = Session("CompanyID")
        '        .SeasonID = RowID
        '        .SeasonDesc = txtName.Text
        '        .SeasonStart = mskStartDate.Value
        '        .SeasonEnd = mskEndDate.Value
        '        .NewSchoolYear = chkNewSchool.Checked
        '        .CurrSeason = chkCurrentSeason.Checked
        '        .CurrRegistration = chkRegistration.Checked
        '        .CurrSchedules = chkSchedules.Checked
        '        .ORStart = sGlobal.TimeAdjusted(Session("TimeZone"), mskORStart.Value)
        '        .OREnd = sGlobal.TimeAdjusted(Session("TimeZone"), mskOREnd.Value)
        '        .PlayersFee = mskPlayersFee.Value
        '        .SponsorFee = mskSponsorFee.Value
        '        .SponsorFeeDiscounted = mskSponsorFeeDiscounted.Value
        '        .CreatedUser = Session("UserName")
        '        oSeason.UpdRow(RowID, Session("CompanyID"), Session("TimeZone"))
        '    End With
        'Catch ex As Exception
        '    Session("ErrorMSG") = "UpdRow::" & ex.Message
        'Finally
        '    oSeason = Nothing
        'End Try
    End Sub

    Private Sub ClearFields()
        grdSeasons.Controls.Clear()
        'If chkCurrentSeason.Checked = True Then Session("SeasonDesc") = txtName.Text
        txtName.Text = ""
        Session("ErrorMsg") = ""
        mskStartDate.Text = ""
        mskEndDate.Text = ""
        mskORStart.Text = ""
        mskOREnd.Text = ""
        lblNewYear.Visible = False
        chkNewSchool.Visible = False
        mskPlayersFee.Text = ""
        mskSponsorFee.Text = ""
        mskSponsorFeeDiscounted.Text = ""
        chkCurrentSeason.Checked = False
        chkRegistration.Checked = False
        chkSchedules.Checked = False

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & Session("ErrorMsg"))
            Exit Sub
        End If
        UpdRow(txtSeasonID.Text)
        If Session("ErrorMsg") = "" Then
            If txtSeasonID.Text > 0 Then
                Call MsgBox("Changes successfully completed")
            Else
                Call MsgBox("New Record Added Successfully")
            End If
            LoadRows()
            ClearFields()
            btnSave.Visible = False
        End If
        lblError.Text = Session("ErrorMsg")
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        If txtName.Text = "" Then
            Session.Add("ErrorMsg", "Name missing ")
            errorRTN = True
        End If
        If Not IsDate(mskStartDate.Value) Then
            Session.Add("ErrorMsg", "Invalid/missing Minimun date mm/dd/yyyy ")
            errorRTN = True
        End If
        If Not IsDate(mskEndDate.Value) Then
            Session.Add("ErrorMsg", "Invalid/missing Maximum date mm/dd/yyyy ")
            errorRTN = True
        End If
        If Not IsNumeric(mskPlayersFee.Value) Then
            Session.Add("ErrorMsg", "Players Fee Invalid/missing ")
            errorRTN = True
        End If
        If Not IsNumeric(mskSponsorFee.Value) Then
            Session.Add("ErrorMsg", "Sponsors Fee Invalid/missing ")
            errorRTN = True
        End If
        If Not IsNumeric(mskSponsorFeeDiscounted.Value) Then
            Session.Add("ErrorMsg", "Sponsors Discounted Fee Invalid/missing ")
            errorRTN = True
        End If
        If chkRegistration.Checked = True Then
            If Not IsDate(mskORStart.Value) Then
                Session.Add("ErrorMsg", "Invalid/missing OR Start date mm/dd/yyyy ")
                errorRTN = True
            End If
            If Not IsDate(mskOREnd.Value) Then
                Session.Add("ErrorMsg", "Invalid/missing OR End date mm/dd/yyyy ")
                errorRTN = True
            End If
        End If
    End Function

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        txtSeasonID.Text = 0
        Call ClearFields()
        btnSave.Visible = True
        chkNewSchool.Visible = True
        lblNewYear.Visible = True
        txtName.Focus()
    End Sub

    Protected Sub grdSeasons_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdSeasons.SelectedRowsChange
        txtSeasonID.Text = grdSeasons.DisplayLayout.ActiveRow.Cells.FromKey("SeasonID").Value
        LoadRecord(txtSeasonID.Text)
        btnSave.Visible = True
    End Sub

    Private Sub LoadRecord(ByVal RowID As Long)
        Dim oSeason As New Season.ClsSeasons
        Dim season As New Season

        Try
            'season.TimeZone = Session("TimeZone")
            oSeason.GetSeason(Session("CompanyID"), RowID)
            txtName.Text = oSeason.SeasonDesc
            'mskStartDate.Value = oSeason.SeasonStart
            'mskEndDate.Value = oSeason.SeasonEnd
            'chkNewSchool.Checked = oSeason.NewSchoolYear
            'chkCurrentSeason.Checked = oSeason.CurrSeason
            'chkRegistration.Checked = oSeason.CurrRegistration
            'If oSeason.CurrRegistration = False Then
            ' lblORStarts.Enabled = False
            ' lblORStops.Enabled = False
            ' mskORStart.Enabled = False
            'mskOREnd.Enabled = False
            'mskORStart.Text = ""
            'mskOREnd.Text = ""
            'Else
            'lblORStarts.Enabled = True
            'lblORStops.Enabled = True
            'mskORStart.Enabled = True
            'mskOREnd.Enabled = True
            'mskORStart.Value = oSeason.ORStart
            'mskOREnd.Value = oSeason.OREnd
            'End If
            'chkSchedules.Checked = oSeason.CurrSchedules
            'mskPlayersFee.Value = oSeason.PlayersFee
            'mskSponsorFee.Value = oSeason.SponsorFee
            'mskSponsorFeeDiscounted.Value = oSeason.SponsorFeeDiscounted
        Catch ex As Exception
            lblError.Text = "LoadRecord::" & ex.Message
        Finally
            oSeason = Nothing
        End Try
    End Sub

    Protected Sub chkRegistration_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRegistration.CheckedChanged
        If chkRegistration.Checked = True Then
            lblORStarts.Enabled = True
            lblORStops.Enabled = True
            mskORStart.Enabled = True
            mskOREnd.Enabled = True
        Else
            lblORStarts.Enabled = False
            lblORStops.Enabled = False
            mskORStart.Enabled = False
            mskOREnd.Enabled = False
        End If
    End Sub

    Protected Sub grdSeasons_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles grdSeasons.InitializeLayout

    End Sub
End Class

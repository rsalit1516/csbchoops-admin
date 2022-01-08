Imports System.Data
Imports CSBC.Components
Public Class Teams
    Inherits System.Web.UI.Page
    Dim SQL As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Team Builder"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" And Session("AccessType") <> "P" Then
                btnSave.Enabled = False
            End If
            If Session("USERACCESS") = "R" Then
                btnDelete.Enabled = False
            End If

            Call LoadDivisions()
            Session("DivisionID") = cmbDivisions.SelectedValue
            Call LoadCoaches()
            Call LoadSponsors()
            Call LoadColors()

            If Session("TeamID") = 0 Then
                Call ClearFields()
                If Session("FirstLetter") > "" And Session("SearchType") = "TeamName" Then txtName.Text = Session("FirstLetter")
            Else
                Call LoadRow(Session("TeamID"))

                Call TeamPlayers(Session("TeamID"))
            End If
            Call LoadUndrafted(cmbDivisions.SelectedValue)
            Call LoadTeams(cmbDivisions.SelectedValue)
            lnkTeams.Text = cmbDivisions.SelectedItem.Text
        End If
        If cmbDivisions.SelectedValue <> Session("DivisionID") Then
            Session("DivisionID") = cmbDivisions.SelectedValue()
            Session("TeamID") = 0
            grdPlayers.Clear()
            grdPlayers.Columns.Clear()
            Call ClearFields()
            Call LoadUndrafted(cmbDivisions.SelectedValue)
            Call LoadTeams(cmbDivisions.SelectedValue)
            lnkTeams.Text = cmbDivisions.SelectedItem.Text
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Teams", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = "AccessType::" & ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadRow(ByVal TeamID As Long)
        Dim oTeams As New Season.ClsTeams
        Dim rsData As DataTable
        lblColors.Text = ""
        Try
            rsData = oTeams.LoadTeam(TeamID, Session("CompanyID"), Session("SeasonID"))
            If rsData.Rows.Count > 0 Then
                txtName.Text = rsData.Rows(0).Item("TeamName") & ""
                If rsData.Rows(0).Item("TeamNumber") > "0" Then
                    txtNumber.Text = rsData.Rows(0).Item("TeamNumber") & ""
                Else
                    txtNumber.Text = ""
                End If
                cmbColors.SelectedValue = rsData.Rows(0).Item("ColorID") & ""
                Session("DivisionID") = rsData.Rows(0).Item("DivisionID") & ""
                Session("CoachID") = rsData.Rows(0).Item("CoachID") & ""
                cmbAsstCoach.SelectedValue = rsData.Rows(0).Item("AssCoachID") & ""
                lblCHPhone.Text = ""
                lblCCPhone.Text = ""
                lblCAsstPhone.Text = ""
                lblHAsstPhone.Text = ""
                If Not IsDBNull(rsData.Rows(0).Item("CoachPhone")) Then
                    If rsData.Rows(0).Item("CoachPhone") > " " Then lblCHPhone.Text = "H-" & rsData.Rows(0).Item("CoachPhone") & ""
                End If
                If Not IsDBNull(rsData.Rows(0).Item("CoachCell")) Then
                    If rsData.Rows(0).Item("CoachCell") > " " Then lblCCPhone.Text = "C-" & rsData.Rows(0).Item("CoachCell") & ""
                End If
                lblHAsstPhone.Text = ""
                If Not IsDBNull(rsData.Rows(0).Item("AsstPhone")) Then
                    If rsData.Rows(0).Item("AsstPhone") > " " Then lblHAsstPhone.Text = "H-" & rsData.Rows(0).Item("AsstPhone") & ""
                End If
                If Not IsDBNull(rsData.Rows(0).Item("AsstCell")) Then
                    If rsData.Rows(0).Item("AsstCell") > " " Then lblCAsstPhone.Text = "C-" & rsData.Rows(0).Item("AsstCell") & ""
                End If
                If IsDBNull(rsData.Rows(0).Item("CoachID")) Then Session("CoachID") = 0
                Session("SponsorID") = rsData.Rows(0).Item("SponsorID") & ""
                If IsDBNull(rsData.Rows(0).Item("SponsorID")) Then Session("SponsorID") = 0
                If rsData.Rows(0).Item("TeamName") = "REFUNDS" Then
                    btnDelete.Enabled = False
                    btnSave.Enabled = False
                Else
                    btnDelete.Enabled = True
                    btnSave.Enabled = True
                End If
                Session.Add("LinkName", txtName.Text)
                cmbDivisions.SelectedValue = Session("DivisionID")
                cmbCoach.SelectedValue = Session("CoachID")
                If IsDBNull(rsData.Rows(0).Item("SponsorID")) Then
                    cmbSponsors.SelectedValue = 0
                Else
                    cmbSponsors.SelectedValue = Session("SponsorID")
                End If
                lblDeleteTeam.Text = ""
                lblDeleteTeam.Visible = False
                Call SponsorColors(Session("SponsorID"))
            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oTeams = Nothing
        End Try
    End Sub

    Private Sub LoadDivisions()
        Dim oDivisions As New Season.ClsDivisions
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            rsData = oDivisions.LoadDivision(0, Session("CompanyID"), Session("SeasonID"), "DivisionID, Div_Desc")
            dRow = rsData.NewRow
            dRow("DivisionID") = 0
            dRow("Div_Desc") = "NONE"
            If rsData.Rows.Count = 0 Then rsData.Rows.InsertAt(dRow, 0)
            With cmbDivisions
                .DataSource = rsData
                .DataValueField = "DivisionID"
                .DataTextField = "Div_Desc"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadDivisions::" & ex.Message
        Finally
            oDivisions = Nothing
            If Session("DivisionID") > 0 Then cmbDivisions.SelectedValue = Session("DivisionID")
        End Try
    End Sub

    Private Sub LoadCoaches()

        Dim oCoaches As New Season.clsCoaches
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            rsData = oCoaches.LoadCoaches(0, Session("CompanyID"), Session("SeasonID"), "CoachID, Name") ', Session("TeamID"), cmbDivisions.SelectedValue())
            dRow = rsData.NewRow
            dRow("CoachID") = 0
            dRow("Name") = "NO COACH"
            rsData.Rows.InsertAt(dRow, 0)
            With cmbCoach
                .DataSource = rsData
                .DataValueField = "CoachID"
                .DataTextField = "Name"
                .DataBind()
            End With
            rsData.Rows(0).Delete()
            dRow = rsData.NewRow
            dRow("CoachID") = 0
            dRow("Name") = "NO ASST COACH"
            rsData.Rows.InsertAt(dRow, 0)
            With cmbAsstCoach
                .DataSource = rsData
                .DataValueField = "CoachID"
                .DataTextField = "Name"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadCoaches::" & ex.Message
        Finally
            oCoaches = Nothing
        End Try
    End Sub

    Private Sub LoadSponsors()
        Dim oSponsors As New Season.clsSponsors
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            rsData = oSponsors.LoadSeasonSponsors(0, Session("CompanyID"), Session("SeasonID"), Session("DivisionID"), Session("TeamID"), "SponsorID, SpoName")
            dRow = rsData.NewRow
            dRow("SponsorID") = 0
            dRow("SpoName") = "NO SPONSOR"
            rsData.Rows.InsertAt(dRow, 0)
            With cmbSponsors
                .DataSource = rsData
                .DataValueField = "SponsorID"
                .DataTextField = "SpoName"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadSponsors::" & ex.Message
        Finally
            oSponsors = Nothing
        End Try
    End Sub

    Private Sub LoadColors()
        Dim oColors As New Website.ClsColors
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            rsData = oColors.LoadColor(0, Session("CompanyID"), Session("TeamID"), cmbDivisions.SelectedValue())
            dRow = rsData.NewRow
            dRow("ID") = 0
            If rsData.Rows.Count = 0 Then
                dRow("ColorName") = "NO Color"
            Else
                dRow("ColorName") = " "
                rsData.Rows.InsertAt(dRow, 0)
            End If
            With cmbColors
                .DataSource = rsData
                .DataValueField = "ID"
                .DataTextField = "ColorName"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadColors::" & ex.Message
        Finally
            oColors = Nothing
        End Try
    End Sub

    Private Sub SponsorColors(ByVal SponsorID As Int32)
        Dim oColors As New Season.clsSponsors
        Dim rsData As DataTable
        lblColors.Text = ""
        Try
            rsData = oColors.SponsorsColor(SponsorID, Session("CompanyID"), Session("SeasonID"))
            If rsData.Rows.Count > 0 Then
                lblColors.Text = rsData.Rows(0).Item("Color1Name") & ""
                If lblColors.Text > "" And rsData.Rows(0).Item("Color2Name") & "" > "" Then lblColors.Text = lblColors.Text & ", "
                lblColors.Text = lblColors.Text & rsData.Rows(0).Item("Color2Name") & ""
            End If
        Catch ex As Exception
            lblError.Text = "SponsorColors::" & ex.Message
        Finally
            oColors = Nothing
        End Try

    End Sub

    Private Sub LoadUndrafted(ByVal DivisionID As Long)
        Dim oPlayers As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPlayers.GetUndrafted(DivisionID, Session("CompanyID"), Session("SeasonID"), "PeopleID, DraftID, (rtrim(LastName) + ', ' + FirstName) as Name, SpoName")
            grdUndrafted.Clear()
            If rsData.Rows.Count > 0 Then
                With grdUndrafted
                    .DataSource = rsData
                    .DataBind()
                End With
                With grdUndrafted.DisplayLayout.Bands(0).Columns
                    .FromKey("PeopleID").Hidden = True
                    .FromKey("DraftID").Header.Caption = "ID"
                    .FromKey("DraftID").Width = 40
                    .FromKey("DraftID").CellStyle.HorizontalAlign = HorizontalAlign.Left
                    .FromKey("Name").Width = 180
                    .FromKey("SpoName").Width = 180
                    .FromKey("SpoName").Header.Caption = "Sponsor"
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadUndrafted::" & ex.Message
        Finally
            oPlayers = Nothing
        End Try

    End Sub

    Private Sub TeamPlayers(ByVal TeamID As Long)
        Dim oPlayers As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPlayers.GetTeamPlayers(TeamID, Session("CompanyID"), Session("SeasonID"), "DraftID, PeopleID, (FirstName +' '+ LastName) AS Name, PlayerID ")
            grdPlayers.Clear()
            grdPlayers.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdPlayers
                    .DataSource = rsData
                    .DataBind()
                End With
                grdPlayers.Columns.Add("Remove", "")
                With grdPlayers.DisplayLayout.Bands(0).Columns
                    .FromKey("PeopleID").Hidden = True
                    .FromKey("PlayerID").Hidden = True
                    .FromKey("DraftID").Header.Caption = "ID"
                    .FromKey("DraftID").Width = 40
                    .FromKey("DraftID").CellStyle.HorizontalAlign = HorizontalAlign.Left
                    .FromKey("Name").Width = 180
                    .FromKey("Remove").Width = 80
                    .FromKey("Remove").NullText = "Remove"
                    .FromKey("Remove").Type = Infragistics.WebUI.UltraWebGrid.ColumnType.Button
                    .FromKey("Remove").CellStyle.HorizontalAlign = HorizontalAlign.Center
                End With
            End If
        Catch ex As Exception
            lblError.Text = "TeamPlayers::" & ex.Message
        Finally
            oPlayers = Nothing
        End Try
    End Sub

    Private Sub LoadTeams(ByVal DivisionID As Long)
        Dim oTeams As New Season.ClsTeams
        Dim rsData As DataTable
        Try
            rsData = oTeams.LoadDivisionTeams(DivisionID, Session("CompanyID"), Session("SeasonID"), False, "TeamID, TeamNumber, TeamColor, TeamName")
            'grdTeams.ResetBands()
            grdTeams.Clear()
            'grdTeams.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdTeams
                    .DataSource = rsData
                    .DataBind()
                End With

                With grdTeams.DisplayLayout.Bands(0).Columns
                    .FromKey("TeamID").Hidden = True
                    .FromKey("TeamNumber").CellStyle.HorizontalAlign = HorizontalAlign.Center
                    .FromKey("TeamNumber").Header.Caption = "#"
                    .FromKey("TeamNumber").Width = 30
                    .FromKey("TeamNumber").Format = "##"
                    .FromKey("TeamColor").Width = 100
                    .FromKey("TeamName").Width = 130
                    .FromKey("TeamName").Format = "Name"
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadTeams::" & ex.Message
        Finally
            oTeams = Nothing
        End Try
    End Sub

    Private Sub UpdRow(ByVal TeamID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oTeam As New Season.ClsTeams
        Try
            With oTeam
                .TeamName = txtName.Text
                .TeamNumber = txtNumber.Text
                .TeamColorID = cmbColors.SelectedValue
                .CoachID = cmbCoach.SelectedValue
                .DivisionID = cmbDivisions.SelectedValue
                .CoCoachID = cmbAsstCoach.SelectedValue
                .SponsorID = cmbSponsors.SelectedValue
                .CreatedUser = Session("UserName")
                .SeasonID = Session("SeasonID")
                oTeam.UpdRow(TeamID, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            oTeam = Nothing
        End Try
    End Sub

    Private Sub ClearFields()
        grdPlayers.Controls.Clear()
        txtName.Text = ""
        txtNumber.Text = ""
        cmbColors.SelectedValue = 0
        Session("CoachID") = 0
        cmbCoach.SelectedValue = 0
        cmbAsstCoach.SelectedValue = 0
        cmbSponsors.SelectedValue = 0
        lblColors.Text = ""
        lblCHPhone.Text = ""
        lblCCPhone.Text = ""
        lblHAsstPhone.Text = ""
        lblCAsstPhone.Text = ""
        Session("SponsorID") = 0
        btnDelete.Enabled = True
        btnSave.Enabled = True
        lblError.Text = ""
    End Sub

    Private Sub AddRow()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oTeam As New Season.ClsTeams
        Try
            With oTeam
                .SeasonID = Session("SeasonID")
                .DivisionID = cmbDivisions.SelectedValue
                .CoachID = cmbCoach.SelectedValue
                .CoCoachID = cmbAsstCoach.SelectedValue
                .SponsorID = cmbSponsors.SelectedValue
                .TeamName = txtName.Text
                .TeamColorID = cmbColors.SelectedValue
                .TeamNumber = txtNumber.Text
                .CreatedUser = Session("UserName")
                oTeam.UpdRow(0, Session("CompanyID"), Session("TimeZone"))
                Session("TeamId") = .TeamId
            End With
        Catch ex As Exception
            Session("ErrorMSG") = ex.Message
        Finally
            oTeam = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        lblError.Text = ""
        txtNumber.Text = txtNumber.Text.PadLeft(2, "0")
        If Session("TeamID") > 0 Then
            If errorRTN() = False Then
                Call UpdRow(Session("TeamID"))
                'Call MsgBox("Changes successfully completed")
                lblError.Text = "Changes successfully completed"
                Call LoadTeams(Session("DivisionID"))
                Call LoadColors()
                'Call LoadCoaches()
                Call LoadRow(Session("TeamID"))
            End If
        Else
            If errorRTN() = False Then
                Call AddRow()
                ' Call MsgBox("New Record Added Successfully")
                lblError.Text = "New Record Added Successfully"
                Call LoadTeams(Session("DivisionID"))
                Call LoadColors()
                'Call LoadCoaches()
                Call LoadRow(Session("TeamID"))
            End If
        End If
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        If txtName.Text = "" Then
            lblError.Text = "Name missing"
            errorRTN = True
            txtName.Focus()
        ElseIf Not IsNumeric(txtNumber.Text) Then
            lblError.Text = "Team Number missing or incorrect"
            errorRTN = True
            txtNumber.Focus()
        End If
        If errorRTN = True Then Response.End()
    End Function

    Private Sub UpdPlayer(ByVal PeopleID As Long, ByVal TeamID As Long)
        Dim oPlayers As New Season.ClsPlayers
        Try
            oPlayers.UpdatePlayer(PeopleID, Session("CompanyID"), Session("SeasonID"), TeamID)
        Catch ex As Exception
            lblError.Text = "UpdPlayer::" & ex.Message
        Finally
            oPlayers = Nothing
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
        '2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
        '3) In your server-side click event, do this:
        If Session("USERACCESS") = "R" Then Exit Sub
        Dim btn As Button = CType(sender, Button)
        If lblDeleteTeam.Text = "" Then btn.CommandArgument = "Confirm"
        If btn.CommandArgument = "Confirm" Then
            lblDeleteTeam.Text = "*Click Delete button again to confirm.*"
            lblError.Text = lblDeleteTeam.Text
            lblDeleteTeam.Visible = True
            btn.CommandArgument = "Delete"
        ElseIf btn.CommandArgument = "Delete" Then
            If Session("TeamID") > 0 Then
                Call DELRow(Session("TeamID"))
                grdPlayers.Controls.Clear()
                Session("TeamID") = 0
                Call LoadTeams(cmbDivisions.SelectedValue)
                Call ClearFields()
                grdPlayers.Rows.Clear()
                Call LoadUndrafted(Session("DivisionID"))
            End If
            lblError.Text = ""
            lblDeleteTeam.Text = ""
            lblDeleteTeam.Visible = False
            btn.CommandArgument = "Confirm"
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.
    End Sub

    Private Sub DELRow(ByVal TeamID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oTeam As New Season.ClsTeams
        Try
            oTeam.DELRow(TeamID, Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            Session("ErrorMsg") = ex.Message
        Finally
            oTeam = Nothing
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim idx As Long

        If Session("TeamID") = 0 Then
            lblError.Text = "No team selected, a team must be added before drafting players"
            Exit Sub
            '    If errorRTN() = False Then Call UpdRow(Session("TeamID"))
            'Else
            '    If errorRTN() = False Then Call AddRow()
        End If

        For idx = 0 To grdUndrafted.DisplayLayout.SelectedRows.Count - 1
            Session("PeopleID") = grdUndrafted.DisplayLayout.SelectedRows(idx).Cells.FromKey("PeopleID").Value
            Call UpdPlayer(Session("PeopleID"), Session("TeamID"))
        Next idx
        Call LoadUndrafted(Session("DivisionID"))
        Call TeamPlayers(Session("TeamID"))
    End Sub

   
    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label

        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"

        Page.Controls.Add(strScript)

    End Sub

    Protected Sub lnkTeams_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTeams.Click
        Response.Redirect("Divisions.aspx")
    End Sub

    Protected Sub imgTeam_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgTeam.Click
        Session("FirstLetter") = txtName.Text
        Session("SearchType") = "TeamName"
        Response.Redirect("SearchTeam.aspx")
    End Sub

    Protected Sub grdTeams_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdTeams.SelectedRowsChange
        If grdTeams.DisplayLayout.ActiveRow Is Nothing Then Exit Sub
        Session("TeamID") = grdTeams.DisplayLayout.ActiveRow.Cells.FromKey("TeamID").Value

        If Session("TeamID") > 0 Then
            Call ClearFields()
            Call LoadColors()
            'Call LoadCoaches()
            'Call LoadSponsors()
            Call LoadRow(Session("TeamID"))
            Call TeamPlayers(Session("TeamID"))
            'Call LoadTeams(cmbDivisions.SelectedValue)
        End If
    End Sub

    Protected Sub grdPlayers_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.CellEventArgs) Handles grdPlayers.ClickCellButton
        Session("PeopleID") = grdPlayers.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
        If Session("PeopleID") > 0 Then
            Call UpdPlayer(Session("PeopleID"), 0)
            Call LoadUndrafted(Session("DivisionID"))
            Call TeamPlayers(Session("TeamID"))
        End If
    End Sub

    Protected Sub grdPlayers_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdPlayers.SelectedRowsChange
        Session("PeopleID") = grdPlayers.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
        If Session("PeopleID") > 0 Then
            Session("TeamID") = 0
            Session("HouseID") = 0
            Response.Redirect("Payments.aspx")
        End If
    End Sub

    Private Sub grdUndrafted_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdUndrafted.DblClick
        If Session("TeamID") > 0 Then
            Session("PeopleID") = grdUndrafted.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
            Call UpdPlayer(Session("PeopleID"), Session("TeamID"))
            Call LoadUndrafted(Session("DivisionID"))
            Call TeamPlayers(Session("TeamID"))
        Else
            lblError.Text = "No team selected, a team must be added before drafting players"
        End If
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Session.Add("TeamID", 0)
        cmbCoach.SelectedValue = 0
        cmbAsstCoach.SelectedValue = 0
        cmbSponsors.SelectedValue = 0
        Call ClearFields()
        'If cmbDivisions.SelectedValue <> Session("DivisionID") Then
        '    'Call LoadCoaches()
        '    'Call LoadSponsors()
        '    Call LoadColors()
        'End If
        'Call LoadUndrafted(cmbDivisions.SelectedValue)
        Call LoadTeams(Session("DivisionID"))
        Call TeamPlayers(Session("TeamID"))
        lnkTeams.Text = cmbDivisions.SelectedItem.Text
        txtName.Focus()
    End Sub

    Private Sub cmbSponsors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSponsors.SelectedIndexChanged

        SponsorColors(cmbSponsors.SelectedValue)
        Session("SponsorID") = cmbSponsors.SelectedItem.Value
    End Sub

    Protected Sub cmbCoach_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCoach.SelectedIndexChanged
        lblCHPhone.Text = ""
        lblCCPhone.Text = ""
        Session("CoachID") = cmbCoach.SelectedItem.Value
        If Session("CoachID") > 0 Then
            Dim oCoach As New Season.clsCoaches
            Dim rsData As DataTable
            Try
                rsData = oCoach.LoadCoaches(Session("CoachID"), Session("CompanyID"), Session("SeasonID"))
                If rsData.Rows.Count > 0 Then
                    If Not IsDBNull(rsData.Rows(0).Item("CoachPhone")) Then
                        If rsData.Rows(0).Item("CoachPhone") > " " Then lblCHPhone.Text = "H-" & rsData.Rows(0).Item("CoachPhone") & ""
                    End If
                    If Not IsDBNull(rsData.Rows(0).Item("Cellphone")) Then
                        If rsData.Rows(0).Item("Cellphone") > " " Then lblCCPhone.Text = "C-" & rsData.Rows(0).Item("Cellphone") & ""
                    End If
                End If
            Catch ex As Exception
                lblError.Text = "cmbCoach::" & ex.Message
            Finally
                oCoach = Nothing
            End Try
        End If
    End Sub

    Protected Sub cmbAsstCoach_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAsstCoach.SelectedIndexChanged
        lblCAsstPhone.Text = ""
        lblHAsstPhone.Text = ""
        If cmbAsstCoach.SelectedItem.Value > "0" Then
            Dim oCoach As New Season.clsCoaches
            Dim rsData As DataTable
            Try
                rsData = oCoach.LoadCoaches(cmbAsstCoach.SelectedItem.Value, Session("CompanyID"), Session("SeasonID"))
                If rsData.Rows.Count > 0 Then
                    If Not IsDBNull(rsData.Rows(0).Item("CoachPhone")) Then
                        If rsData.Rows(0).Item("CoachPhone") > " " Then lblHAsstPhone.Text = "H-" & rsData.Rows(0).Item("CoachPhone") & ""
                    End If
                    If Not IsDBNull(rsData.Rows(0).Item("Cellphone")) Then
                        If rsData.Rows(0).Item("Cellphone") > " " Then lblCAsstPhone.Text = "C-" & rsData.Rows(0).Item("Cellphone") & ""
                    End If
                End If
            Catch ex As Exception
                lblError.Text = "cmbAsstCoach::" & ex.Message
            Finally
                oCoach = Nothing
            End Try
        End If
    End Sub

    Protected Sub grdTeams_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles grdTeams.InitializeLayout

    End Sub
End Class

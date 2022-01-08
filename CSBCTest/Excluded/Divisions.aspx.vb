Imports System.Data
Imports CSBC.Components
Partial Class Divisions
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Divisions"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
            End If
            Me.txtName.Focus()
            'Session("ReportName") = "TryoutsInfo"
            Call LoadDivisions()
            Call LoadDirectors()
            If Session("DivisionID") = 0 Then
                Call ClearFields()
            Else
                Call LoadRow(Session("DivisionID"))
            End If
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Divisions", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadDivisions()
        Dim oDivisions As New Season.ClsDivisions
        Dim rsData As DataTable
        Try
            rsData = oDivisions.LoadDivision(0, Session("CompanyID"), Session("SeasonID"), "DivisionID, Div_Desc as Division, MinDate, MaxDate")
            grdDivisions.ResetBands()
            With grdDivisions
                .DataSource = rsData
                .DataBind()
            End With
            With grdDivisions.DisplayLayout.Bands(0).Columns
                .FromKey("DivisionID").Hidden = True
                '.FromKey("Gender").CellStyle.HorizontalAlign = HorizontalAlign.Center
                '.FromKey("Gender").Width = 50
                .FromKey("Division").Width = 100
                .FromKey("MinDate").Width = 60
                .FromKey("MinDate").Format = "MM/dd/yyyy"
                .FromKey("MinDate").CellStyle.HorizontalAlign = HorizontalAlign.Left
                .FromKey("MaxDate").Width = 60
                .FromKey("MaxDate").Format = "MM/dd/yyyy"
                .FromKey("MaxDate").CellStyle.HorizontalAlign = HorizontalAlign.Left
            End With
        Catch ex As Exception
            lblError.Text = "LoadDivisions::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try
    End Sub

    Private Sub LoadDirectors()
        Dim dRow As DataRow
        Dim oDivisions As New Season.ClsDivisions
        Dim rsData As DataTable
        Try
            rsData = oDivisions.LoadDirector(Session("CompanyID"))
            cboAD.Items.Clear()
            dRow = rsData.NewRow
            dRow("PeopleID") = 0
            dRow("Name") = "NO AD"
            rsData.Rows.InsertAt(dRow, 0)
            With cboAD
                .DataSource = rsData
                .DataValueField = "PeopleID"
                .DataTextField = "Name"
                .DataBind()
            End With

        Catch ex As Exception
            lblError.Text = "LoadDirectors::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try

    End Sub

    Private Sub ClearFields()
        txtName.Text = ""
        txtMinDate.Text = ""
        txtMaxDate.Text = ""
        hdnMinDateOld.Value = ""
        hdnMaxDateOld.Value = ""
        txtMinDate2.Text = ""
        txtMaxDate2.Text = ""
        hdnMinDate2Old.Value = ""
        hdnMaxDate2Old.Value = ""
        txtTime.Text = ""
        txtDate.Text = ""
        txtVenue.Text = ""
        cboAD.SelectedIndex = 0
        lblHPhon.Text = ""
        lblCPhon.Text = ""
        grdTeams.Rows.Clear()
        hdnGenderOLD.Value = ""
        radGender.Items(0).Selected() = False
        radGender.Items(1).Selected() = False
        hdnGender2OLD.Value = ""
        radGender2.Items(0).Selected() = False
        radGender2.Items(1).Selected() = False
        lblError.Text = ""
        lblDelete.Text = ""
    End Sub

    Private Sub LoadRow(ByVal RowID As Long)
        Dim oDivisions As New Season.ClsDivisions
        Dim rsData As DataTable
        Try
            rsData = oDivisions.LoadDivision(RowID, Session("CompanyID"), Session("SeasonID"))

            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    txtName.Text = rsData.Rows(0).Item("Div_Desc") + ""
                    txtMinDate.Text = rsData.Rows(0).Item("MinDate") + ""
                    hdnMinDateOld.Value = rsData.Rows(0).Item("MinDate") + ""
                    txtMaxDate.Text = rsData.Rows(0).Item("MaxDate") + ""
                    hdnMaxDateOld.Value = rsData.Rows(0).Item("MaxDate") + ""
                    txtMinDate2.Text = rsData.Rows(0).Item("MinDate2") + ""
                    hdnMinDate2Old.Value = rsData.Rows(0).Item("MinDate2") + ""
                    txtMaxDate2.Text = rsData.Rows(0).Item("MaxDate2") + ""
                    hdnMaxDate2Old.Value = rsData.Rows(0).Item("MaxDate2") + ""
                    lblHPhon.Text = ""
                    lblCPhon.Text = ""
                    If Not IsDBNull(rsData.Rows(0).Item("HousePhone")) Then
                        If rsData.Rows(0).Item("HousePhone") > "" Then lblHPhon.Text = "H-" & rsData.Rows(0).Item("HousePhone") & ""
                    End If

                    If Not IsDBNull(rsData.Rows(0).Item("CellPhone")) Then
                        If rsData.Rows(0).Item("CellPhone") & "" > "" Then
                            If rsData.Rows(0).Item("HousePhone") & "" > "" Then
                                lblCPhon.Text += "  C-" & rsData.Rows(0).Item("CellPhone") & ""
                            Else
                                lblHPhon.Text += "  C-" & rsData.Rows(0).Item("CellPhone") & ""
                            End If
                        End If
                    End If
                    cboAD.SelectedValue = 0
                    If Not IsDBNull(rsData.Rows(0).Item("AD")) Then
                        If IsNumeric(rsData.Rows(0).Item("DirectorID")) And rsData.Rows(0).Item("AD") = True Then
                            cboAD.SelectedValue = rsData.Rows(0).Item("DirectorID")
                        End If
                    End If
                    hdnGenderOld.Value = RTrim(rsData.Rows(0).Item("Gender")) & ""
                    If RTrim(rsData.Rows(0).Item("Gender")) = "M" Then
                        radGender.Items(0).Selected() = True
                        radGender.Items(1).Selected() = False
                    Else
                        radGender.Items(1).Selected() = True
                        radGender.Items(0).Selected() = False
                    End If
                    If Not IsDBNull(rsData.Rows(0).Item("Gender2")) Then
                        hdnGender2Old.Value = RTrim(rsData.Rows(0).Item("Gender2")) & ""
                        If RTrim(rsData.Rows(0).Item("Gender2")) = "M" Then
                            radGender2.Items(0).Selected() = True
                            radGender2.Items(1).Selected() = False
                        Else
                            radGender2.Items(1).Selected() = True
                            radGender2.Items(0).Selected() = False
                        End If
                    End If
                    txtVenue.Text = rsData.Rows(0).Item("DraftVenue") & ""
                    txtDate.Text = rsData.Rows(0).Item("DraftDate") & ""
                    txtTime.Text = rsData.Rows(0).Item("DraftTime") & ""
                End If
            End If

        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try

        Call LoadTeams(Session("DivisionID"))
    End Sub

    Private Sub LoadTeams(ByVal iDivisionID As Int32)

        Dim oTeams As New Season.ClsTeams
        Dim rsData As DataTable
        Try
            grdTeams.Clear()
            grdTeams.Columns.Clear()
            rsData = oTeams.LoadDivisionTeams(iDivisionID, Session("CompanyID"), Session("SeasonID"), True)
            If rsData.Rows.Count > 0 Then
                With grdTeams
                    .Rows.Clear()
                    .DataSource = rsData
                    .DataBind()
                End With
                'TeamNumber, Name, TeamColor
                With grdTeams.DisplayLayout.Bands(0).Columns
                    .FromKey("TeamID").Hidden = True
                    .FromKey("CoachPhone").Header.Caption = "Coach Phone"
                    .FromKey("CoachPhone").Width = 80
                    .FromKey("CoachPhone").HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                    .FromKey("Nbr").Width = 30
                    .FromKey("Nbr").CellStyle.HorizontalAlign = HorizontalAlign.Center
                    .FromKey("Name").Width = 100
                    .FromKey("Color").Width = 100
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadTeams::" & ex.Message
        Finally
            oTeams = Nothing
        End Try

    End Sub

    Private Sub grdTeams_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdTeams.DblClick
        Session("TeamID") = grdTeams.DisplayLayout.ActiveRow.Cells(0).Text()
        If Session("TeamID") > 0 Then
            Response.Redirect("Teams.aspx")
        End If
    End Sub

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oDivision As New Season.ClsDivisions
        Try
            With oDivision
                .SeasonID = Session("SeasonID")
                .Div_Desc = txtName.Text
                .MinDate = txtMinDate.Text
                .MaxDate = txtMaxDate.Text
                If radGender.Items(0).Selected() = True Then .Gender = "M"
                If radGender.Items(1).Selected() = True Then .Gender = "F"
                If IsDate(txtMinDate2.Text) Then .MinDate2 = txtMinDate2.Text
                If IsDate(txtMaxDate2.Text) Then .MaxDate2 = txtMaxDate2.Text
                If radGender2.Items(0).Selected() = True Then .Gender2 = "M"
                If radGender2.Items(1).Selected() = True Then .Gender2 = "F"
                .DraftVenue = txtVenue.Text
                If IsDate(txtDate.Text) Then .DraftDate = txtDate.Text
                .DraftTime = txtTime.Text
                .DirectorID = cboAD.SelectedValue
                .CoDirectorID = 0 'cboAD.SelectedValue
                .CreatedUser = Session("UserName")
                oDivision.UpdRow(RowID, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            oDivision = Nothing
        End Try
    End Sub

    Private Sub ADDRow()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oDivisions As New Season.ClsDivisions
        Try
            With oDivisions
                .SeasonID = Session("SeasonID")
                .Div_Desc = txtName.Text
                .DirectorID = cboAD.SelectedValue
                .DraftVenue = txtVenue.Text
                If IsDate(txtDate.Text) Then .DraftDate = txtDate.Text
                .DraftTime = txtTime.Text
                .MinDate = txtMinDate.Text
                .MaxDate = txtMaxDate.Text
                If radGender.Items(0).Selected() = True Then .Gender = "M"
                If radGender.Items(1).Selected() = True Then .Gender = "F"
                If IsDate(txtMinDate2.Text) Then .MinDate2 = txtMinDate2.Text
                If IsDate(txtMaxDate2.Text) Then .MaxDate2 = txtMaxDate2.Text
                If radGender2.Items(0).Selected() = True Then .Gender2 = "M"
                If radGender2.Items(1).Selected() = True Then .Gender2 = "F"

                .CreatedUser = Session("UserName")
                oDivisions.UpdRow(0, Session("CompanyID"), Session("TimeZone"))
                Session("DivisionID") = .DivisionID
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "ADDRow::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try

        Call AddGroup(Session("DivisionID"), "REFUNDS")
        Call AddGroup(Session("DivisionID"), "WAITING LIST")
        Call AddGroup(Session("DivisionID"), "NO SHOW")
    End Sub

    Private Sub AddGroup(ByVal DivisionID As Integer, ByVal sGroup As String)
        If Session("AccessType") = "R" Or getGroup(DivisionID, sGroup) > 0 Then Exit Sub
        Dim oTeams As New Season.ClsTeams
        Try
            With oTeams
                .SeasonID = Session("SeasonID")
                .DivisionID = DivisionID
                .TeamName = sGroup
                .TeamNumber = 0
                .CoCoachID = 0
                .CreatedUser = Session("UserName")
                oTeams.UpdRow(0, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "AddGroup::" & ex.Message
        Finally
            oTeams = Nothing
        End Try
    End Sub

    Private Function getGroup(ByVal DivisionID As String, ByVal sGroup As String) As Integer
        Dim oTeams As New Season.ClsTeams
        getGroup = 0
        Try
            getGroup = oTeams.GetTeamCount(DivisionID, sGroup, Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            Session("ErrorMSG") = "getGroup::" & ex.Message
        Finally
            oTeams = Nothing
        End Try

    End Function

    Private Function errorRTN() As Boolean
        Dim PlayersCount As Integer = 0
        If Session("DivisionID") > 0 Then PlayersCount = PlayersAssigned()
        errorRTN = False
        If PlayersCount > 0 Then
            If (hdnGenderOLD.Value = "M" And radGender.Items(1).Selected() = True) Or _
               (hdnGenderOLD.Value = "F" And radGender.Items(0).Selected() = True) Then
                Session.Add("ErrorMsg", "Can't change Gender, Unasigned players from division first ")
                errorRTN = True
            End If
        End If
        If txtName.Text = "" Then
            Session.Add("ErrorMsg", "Name missing ")
            txtName.Focus()
            errorRTN = True
        End If
        If txtMinDate.Text = "" And errorRTN = False Then
            Session.Add("ErrorMsg", "Invalid/missing Minimun date mm/dd/yyyy ")
            txtMinDate.Focus()
            errorRTN = True
        End If
        If txtMaxDate.Text = "" And errorRTN = False Then
            Session.Add("ErrorMsg", "Invalid/missing Maximum date mm/dd/yyyy ")
            txtMaxDate.Focus()
            errorRTN = True
        End If
        If radGender.Items(0).Selected() = False And radGender.Items(1).Selected() = False And errorRTN = False Then
            Session.Add("ErrorMsg", "Gender missing ")
            radGender.Focus()
            errorRTN = True
        End If
        If txtMinDate2.Text = "" And txtMaxDate2.Text > "" And errorRTN = False Then
            Session.Add("ErrorMsg", "Invalid/missing Minimum 2 date mm/dd/yyyy ")
            txtMinDate2.Focus()
            errorRTN = True
        End If
        If txtMaxDate2.Text = "" And txtMinDate2.Text > "" And errorRTN = False Then
            Session.Add("ErrorMsg", "Invalid/missing Maximum 2 date mm/dd/yyyy ")
            txtMaxDate2.Focus()
            errorRTN = True
        End If
        If txtMinDate2.Text > "" And txtMaxDate2.Text > "" And (radGender2.Items(0).Selected() = False And radGender2.Items(1).Selected() = False) And errorRTN = False Then
            Session.Add("ErrorMsg", "Gender2 missing ")
            radGender2.Focus()
            errorRTN = True
        End If

        If errorRTN = True Then
            lblError.Text = Session("ErrorMSG")
        End If
    End Function


    '' '' ''Private Sub btnAddPeople_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPeople.Click
    '' '' ''    If Session("DivisionID") > 0 Then
    '' '' ''        Session.Add("PeopleID", 0)
    '' '' ''        Response.Redirect("PeopleUPD.aspx")
    '' '' ''    Else
    '' '' ''        Session.Add("ErrorMsg", "Must Add Division First")
    '' '' ''        Response.Redirect("MsgBox.aspx")
    '' '' ''    End If
    '' '' ''End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub


    Private Function PlayersAssigned() As Integer
        If Session("AccessType") = "R" Then Exit Function
        Dim oTeams As New Season.ClsTeams
        PlayersAssigned = 0
        Try
            PlayersAssigned = oTeams.GetPlayersCount(Session("DivisionID"), Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            Session("ErrorMSG") = "PlayersAssigned::" & ex.Message
        Finally
            oTeams = Nothing
        End Try
    End Function

    Private Sub DELRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oDivisions As New Season.ClsDivisions
        Try
            oDivisions.DELRow(RowID, Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            Session("ErrorMSG") = "DELRow::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try

    End Sub

    Private Sub ReassignDivision(ByVal DivisionID As Long)
        If Session("AccessType") = "R" Then Exit Sub

        Dim oDivisions As New Season.ClsDivisions
        Try
            With oDivisions
                oDivisions.ReassignDiv(DivisionID, Session("CompanyID"), Session("SeasonID"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "ReassignDivision::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try

    End Sub

    'Private Sub UpdPlayers(ByVal DivisionID As Long)
    '    If Session("AccessType") = "R" Then Exit Sub

    '    Dim oDivisions As New Season.ClsDivisions
    '    Try
    '        With oDivisions
    '            .TeamID = 0
    '            .DivisionID = 0
    '            oDivisions.UpdPlayers(DivisionID, Session("CompanyID"), Session("SeasonID"))
    '        End With
    '    Catch ex As Exception
    '        Session("ErrorMSG") = "UpdPlayers::" & ex.Message
    '    Finally
    '        oDivisions = Nothing
    '    End Try
    'End Sub

    Protected Sub grdDivisions_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdDivisions.SelectedRowsChange
        Session("DivisionID") = grdDivisions.DisplayLayout.ActiveRow.Cells.FromKey("DivisionID").Value
        Call ClearFields()
        Call LoadRow(Session("DivisionID"))
        Me.txtName.Focus()
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Session("DivisionID") = 0
        Call ClearFields()
        Me.txtName.Focus()
        Call LoadDivisions()
        grdTeams.Clear()
        grdTeams.Columns.Clear()
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
        '2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
        '3) In your server-side click event, do this:
        If Session("AccessType") = "R" Then Exit Sub

        Dim PlayersCount As Integer
        Dim btn As Button = CType(sender, Button)
        PlayersCount = PlayersAssigned()
        If PlayersCount > 0 Then
            Session("ErrorMSG") = "(" & PlayersCount & ") players must be removed before deleting"
            lblError.Text = Session("ErrorMSG")
            MsgBox(Session("ErrorMSG"))
        End If
        If lblDelete.Text = "" Then btn.CommandArgument = "Confirm"
        If btn.CommandArgument = "Confirm" Then
            lblDelete.Text = "*Click Delete button again to confirm.*"
            lblDelete.Visible = True
            btn.CommandArgument = "Delete"
        ElseIf btn.CommandArgument = "Delete" Then
            If Session("DivisionID") > 0 Then
                Call DELRow(Session("DivisionID"))
                grdTeams.Rows.Clear()
                Session("DivisionID") = 0
                Call ClearFields()
                Call LoadDivisions()
                grdTeams.Clear()
            End If
            lblDelete.Text = ""
            lblDelete.Visible = False
            btn.CommandArgument = "Confirm"
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        lblError.Text = ""
        Session("ErrorMSG") = ""
        If Session("DivisionID") > 0 Then
            UpdDivision()
        Else
            AddDivision()
        End If
    End Sub

    Private Sub AddDivision()
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("ErrorMsg") = "" Then Call ADDRow()
        If Session("ErrorMsg") = "" Then Call MsgBox("New Record Added Successfully")
        If Session("ErrorMsg") = "" Then Call LoadTeams(Session("DivisionID"))
        If Session("ErrorMsg") = "" Then Call LoadRow(Session("DivisionID"))
        If Session("ErrorMsg") = "" Then Call ReassignDivision(Session("DivisionID"))
        If Session("ErrorMsg") = "" Then Call LoadDivisions()
        lblError.Text = Session("ErrorMsg")

    End Sub

    Private Sub UpdDivision()
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("ErrorMsg") = "" Then Call UpdRow(Session("DivisionID"))
        If Session("ErrorMsg") = "" Then Call MsgBox("Changes successfully completed")
        If Session("ErrorMsg") = "" Then Call LoadTeams(Session("DivisionID"))
        If Session("ErrorMsg") = "" Then Call LoadRow(Session("DivisionID"))
        If Session("ErrorMsg") = "" Then Call ReassignDivision(Session("DivisionID"))
        If Session("ErrorMsg") = "" Then Call LoadDivisions()
        lblError.Text = Session("ErrorMsg")

    End Sub

End Class

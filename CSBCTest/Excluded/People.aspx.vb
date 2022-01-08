Imports System.Data
Imports CSBC.Components
Partial Class People
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "People"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnComments.Visible = False
            End If

            If Session("PeopleID") > 0 Then Session("PlayerID") = GetPlayer()
            If Session("HouseID") > 0 Then Call ReadHouse()
            If Session("PeopleID") = 0 Then
                Call ClearFields()
                If Session("FirstLetter") > "" And Session("SearchType") = "LastName" Then
                    txtLastName.Text = Session("FirstLetter")
                End If
            Else
                Call LoadPeople(Session("PeopleID"))
                Call LoadComments(Session("PeopleID"))
            End If
            If txtLastName.Text > "" Then
                txtFirstName.Focus()
            Else
                txtLastName.Focus()
            End If
            'If Session("PeopleID") > 0 Or Session("PeopleID") Is Nothing Then

        End If

    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "People", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = "AccessType::" & ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Function GetPlayer() As Long
        GetPlayer = 0
        lblBalance.Text = ""
        btnTeam.Visible = False
        Dim oPlayer As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPlayer.GetRecords(Session("PeopleID"), Session("CompanyID"), Session("SeasonID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    GetPlayer = rsData.Rows(0).Item("PlayerID")
                    btnTeam.Visible = True
                    Session("TeamID") = rsData.Rows(0).Item("TeamID")
                    If IsDBNull(rsData.Rows(0).Item("TeamID")) Then Session("TeamID") = 0
                    Session("DivisionID") = rsData.Rows(0).Item("DivisionID")
                    If IsDBNull(rsData.Rows(0).Item("DivisionID")) Then Session("DivisionID") = 0
                    btnTeam.Text = rsData.Rows(0).Item("Div_Desc") & " (Team: " & rsData.Rows(0).Item("TeamNumber") & ")"
                    If IsDBNull(rsData.Rows(0).Item("TeamNumber")) Then btnTeam.Text = rsData.Rows(0).Item("Div_Desc") & ": Undrafted"
                    btnTeam.ToolTip = rsData.Rows(0).Item("TeamName") & "-" & rsData.Rows(0).Item("TeamColor")
                    lblBalance.Text = "Balance: " & Format(rsData.Rows(0).Item("BalanceOwed"), "currency") & ""
                End If
            End If
            Session.Add("LinkName", txtFirstName.Text & ", " & txtLastName.Text())
        Catch ex As Exception
            lblError.Text = "GetPlayer::" & ex.Message
        Finally
            oPlayer = Nothing
            Session.Add("LinkName", txtLastName.Text)
        End Try

    End Function

    Private Sub ReadHouse()
        Dim oHousehold As New Profile.ClsHouseholds
        Dim rsData As DataTable
        Try
            rsData = oHousehold.GetRecords(Session("HouseID"), Session("CompanyID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    lnkHouseName.Text = rsData.Rows(0).Item("Name") & ""
                    lblAddress.Text = " " & rsData.Rows(0).Item("Address1") & ""
                    lblCSZ.Text = " " & rsData.Rows(0).Item("City") & " " & rsData.Rows(0).Item("State") & " " & rsData.Rows(0).Item("Zip") & ""
                    lblPhone.Text = " " & rsData.Rows(0).Item("Phone") & ""
                    lblEmail.Text = " " & rsData.Rows(0).Item("Email") & ""
                End If
            End If
            Session.Add("LinkName", txtFirstName.Text & ", " & txtLastName.Text())
        Catch ex As Exception
            lblError.Text = "ReadHouse::" & ex.Message
        Finally
            oHousehold = Nothing
            Session.Add("LinkName", txtLastName.Text)
        End Try

        Call LoadMembers(Session("HouseID"))
    End Sub

    Private Sub LoadPeople(ByVal PeopleID As Long)
        Dim oPeople As New Profile.ClsPeople
        Dim rsData As DataTable

        Try
            rsData = oPeople.LoadPeople(PeopleID, Session("CompanyID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    If IsNumeric(rsData.Rows(0).Item("HouseID")) And Session("HouseID") = 0 Then
                        Session("HouseID") = rsData.Rows(0).Item("HouseID")
                    End If
                    txtFirstName.Text = rsData.Rows(0).Item("FirstName") & ""
                    txtLastName.Text = rsData.Rows(0).Item("LastName") & ""
                    txtCellPhone.Text = rsData.Rows(0).Item("CellPhone") & ""
                    txtWorkPhone.Text = rsData.Rows(0).Item("WorkPhone") & ""
                    If IsDBNull(rsData.Rows(0).Item("LatestSeason")) Then
                        lblLastSeason.Text = "Last Season: UNKNOWN"
                    Else
                        If rsData.Rows(0).Item("LatestSeason") > "" Then
                            lblLastSeason.Text = "Last Season: " & rsData.Rows(0).Item("LatestSeason")
                        Else
                            lblLastSeason.Text = "Last Season: UNKNOWN"
                        End If
                    End If
                    If IsDate(rsData.Rows(0).Item("BirthDate")) Then
                        mskBirthDate.Text = rsData.Rows(0).Item("BirthDate")
                    Else
                        mskBirthDate.Text = vbNull
                    End If
                    If IsDBNull(rsData.Rows(0).Item("Gender")) Then
                    Else
                        If rsData.Rows(0).Item("Gender") = "M" Then
                            radGender.Items(0).Selected() = True
                            radGender.Items(1).Selected() = False
                        Else
                            radGender.Items(1).Selected() = True
                            radGender.Items(0).Selected() = False
                        End If
                    End If
                    txtSchool.Text = rsData.Rows(0).Item("SchoolName") & ""
                    cmbGrade.SelectedIndex = rsData.Rows(0).Item("Grade") & ""

                    chkBC.Checked = rsData.Rows(0).Item("BC")
                    chkMoney.Items(0).Selected() = rsData.Rows(0).Item("FeeWaived")
                    chkMoney.Items(1).Selected() = rsData.Rows(0).Item("GiftedLevelsUP")

                    chkVolunteer.Items(0).Selected() = rsData.Rows(0).Item("BoardOfficer")
                    chkVolunteer.Items(1).Selected() = rsData.Rows(0).Item("BoardMember")
                    chkVolunteer.Items(2).Selected() = rsData.Rows(0).Item("AD")
                    chkVolunteer.Items(3).Selected() = rsData.Rows(0).Item("Sponsor")
                    chkVolunteer.Items(4).Selected() = rsData.Rows(0).Item("SignUps")
                    chkVolunteer.Items(5).Selected() = rsData.Rows(0).Item("TryOuts")
                    chkVolunteer.Items(6).Selected() = rsData.Rows(0).Item("TeeShirts")
                    chkVolunteer.Items(7).Selected() = rsData.Rows(0).Item("Printing")
                    chkVolunteer.Items(8).Selected() = rsData.Rows(0).Item("Equipment")
                    chkVolunteer.Items(9).Selected() = rsData.Rows(0).Item("Electrician")
                    chkVolunteer.Items(10).Selected() = rsData.Rows(0).Item("AsstCoach")

                    chkParentPlayer.Items(0).Selected() = rsData.Rows(0).Item("Parent")
                    chkParentPlayer.Items(1).Selected() = rsData.Rows(0).Item("Coach")
                    chkParentPlayer.Items(2).Selected() = rsData.Rows(0).Item("Player")
                    txtComments.Enabled = True
                    btnComments.Enabled = True
                End If
            End If
            Session.Add("LinkName", txtFirstName.Text & ", " & txtLastName.Text())
        Catch ex As Exception
            lblError.Text = "LoadPeople::" & ex.Message
        Finally
            oPeople = Nothing
            Session.Add("LinkName", txtLastName.Text)
        End Try
        If Session("HouseID") > 0 Then Call ReadHouse()
        txtLastName.Focus()
    End Sub

    Private Sub LoadComments(ByVal PeopleID As Long)
        Dim oComments As New Website.ClsComments
        Dim rsData As DataTable
        Try
            rsData = oComments.GetRecords(0, Session("PeopleID"), "P", Session("CompanyID"))
            If Not rsData Is Nothing Then
                For I As Integer = 0 To rsData.Rows.Count - 1
                    txtComments.Text = txtComments.Text & " " & rsData.Rows(I).Item("Comment") & vbCrLf
                Next
            End If
            Session.Add("LinkName", txtFirstName.Text & ", " & txtLastName.Text())
        Catch ex As Exception
            lblError.Text = "LoadComments::" & ex.Message
        Finally
            oComments = Nothing
            Session.Add("LinkName", txtLastName.Text)
        End Try
    End Sub

    Private Sub UpdPeople(ByVal iPeopleID As Int32)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oPeople As New Profile.ClsPeople
        Try
            With oPeople
                .LastName = txtLastName.Text
                .FirstName = txtFirstName.Text
                .WorkPhone = txtWorkPhone.Text
                .CellPhone = txtCellPhone.Text
                If IsDate(mskBirthDate.Text) Then .BirthDate = mskBirthDate.Text
                .HouseId = Session("HouseID")
                If radGender.Items(0).Selected() = True Then .Gender = "M"
                If radGender.Items(1).Selected() = True Then .Gender = "F"
                .SchoolName = txtSchool.Text
                .Grade = cmbGrade.SelectedIndex
                If chkMoney.Items(1).Selected() = True Then
                    .GiftedLevelsUP = 1
                Else
                    .GiftedLevelsUP = 0
                End If
                If chkMoney.Items(0).Selected() = True Then
                    .FeeWaived = 1
                Else
                    .FeeWaived = 0
                End If
                If chkParentPlayer.Items(0).Selected() = True Then
                    .Parent = 1
                Else
                    .Parent = 0
                End If
                If chkParentPlayer.Items(1).Selected() Then
                    .Coach = 1
                Else
                    .Coach = 0
                End If
                If chkParentPlayer.Items(2).Selected() = True Then
                    .Player = 1
                Else
                    .Player = 0
                End If
                If chkVolunteer.Items(0).Selected() Then
                    .BoardOfficer = 1
                Else
                    .BoardOfficer = 0
                End If
                If chkVolunteer.Items(1).Selected() Then
                    .BoardMember = 1
                Else
                    .BoardMember = 0
                End If
                If chkVolunteer.Items(2).Selected() Then
                    .AD = 1
                Else
                    .AD = 0
                End If
                If chkVolunteer.Items(3).Selected() Then
                    .Sponsor = 1
                Else
                    .Sponsor = 0
                End If
                If chkVolunteer.Items(4).Selected() Then
                    .SignUps = 1
                Else
                    .SignUps = 0
                End If
                If chkVolunteer.Items(5).Selected() Then
                    .TryOuts = 1
                Else
                    .TryOuts = 0
                End If
                If chkVolunteer.Items(6).Selected() Then
                    .TeeShirts = 1
                Else
                    .TeeShirts = 0
                End If
                If chkVolunteer.Items(7).Selected() Then
                    .Printing = 1
                Else
                    .Printing = 0
                End If
                If chkVolunteer.Items(8).Selected() Then
                    .Equipment = 1
                Else
                    .Equipment = 0
                End If
                If chkVolunteer.Items(9).Selected() Then
                    .Electrician = 1
                Else
                    .Electrician = 0
                End If
                If chkVolunteer.Items(10).Selected() Then
                    .AsstCoach = 1
                Else
                    .AsstCoach = 0
                End If
                If chkBC.Checked Then
                    .BC = 1
                Else
                    .BC = 0
                End If
                oPeople.UpdRow(iPeopleID, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdPeople::" & ex.Message
        Finally
            oPeople = Nothing
        End Try
        'Session("PlayerID") = GetPlayer()
        'If Session("PlayerID") > 0 Then
        Call SetDivision()
        Session("PlayerID") = GetPlayer()
        'End If
        Call LoadPeople(Session("PeopleID"))
    End Sub

    Private Sub ClearFields()
        txtFirstName.Text = ""
        txtWorkPhone.Text = ""
        txtCellPhone.Text = ""
        mskBirthDate.Text = ""
        txtSchool.Text = ""
        cmbGrade.SelectedIndex = 13
        chkMoney.Items(0).Selected() = False
        chkMoney.Items(1).Selected() = False
        chkBC.Checked = False
        chkParentPlayer.Items(0).Selected = False
        chkParentPlayer.Items(1).Selected = False
        chkParentPlayer.Items(2).Selected = False
        chkVolunteer.Items(0).Selected() = False
        chkVolunteer.Items(1).Selected() = False
        chkVolunteer.Items(2).Selected() = False
        chkVolunteer.Items(3).Selected() = False
        chkVolunteer.Items(4).Selected() = False
        chkVolunteer.Items(5).Selected() = False
        chkVolunteer.Items(6).Selected() = False
        chkVolunteer.Items(7).Selected() = False
        chkVolunteer.Items(8).Selected() = False
        chkVolunteer.Items(9).Selected() = False
        chkVolunteer.Items(10).Selected() = False
        txtComments.Enabled = False
        btnComments.Enabled = False
    End Sub

    Private Sub ADDPeople()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oPeople As New Profile.ClsPeople
        Try
            With oPeople
                .HouseId = Session("HouseID")
                .LastName = txtLastName.Text
                .FirstName = txtFirstName.Text
                .WorkPhone = txtWorkPhone.Text
                .CellPhone = txtCellPhone.Text
                If IsDate(mskBirthDate.Text) Then .BirthDate = mskBirthDate.Text

                If radGender.Items(0).Selected() = True Then .Gender = "M"
                If radGender.Items(1).Selected() = True Then .Gender = "F"
                .SchoolName = txtSchool.Text
                .Grade = cmbGrade.SelectedIndex
                If chkMoney.Items(0).Selected() = True Then
                    .FeeWaived = 1
                Else
                    .FeeWaived = 0
                End If
                If chkMoney.Items(1).Selected() = True Then
                    .GiftedLevelsUP = 1
                Else
                    .GiftedLevelsUP = 0
                End If
                If chkParentPlayer.Items(0).Selected() = True Then
                    .Parent = 1
                Else
                    .Parent = 0
                End If
                If chkParentPlayer.Items(1).Selected() = True Then
                    .Coach = 1
                Else
                    .Coach = 0
                End If
                If chkParentPlayer.Items(2).Selected() = True Then
                    .Player = 1
                Else
                    .Player = 0
                End If
                If chkVolunteer.Items(0).Selected() = True Then
                    .BoardOfficer = 1
                Else
                    .BoardOfficer = 0
                End If
                If chkVolunteer.Items(1).Selected() = True Then
                    .BoardMember = 1
                Else
                    .BoardMember = 0
                End If
                If chkVolunteer.Items(2).Selected() = True Then
                    .AD = 1
                Else
                    .AD = 0
                End If
                If chkVolunteer.Items(3).Selected() = True Then
                    .Sponsor = 1
                Else
                    .Sponsor = 0
                End If
                If chkVolunteer.Items(4).Selected() = True Then
                    .SignUps = 1
                Else
                    .SignUps = 0
                End If
                If chkVolunteer.Items(5).Selected() = True Then
                    .TryOuts = 1
                Else
                    .TryOuts = 0
                End If
                If chkVolunteer.Items(6).Selected() = True Then
                    .TeeShirts = 1
                Else
                    .TeeShirts = 0
                End If
                If chkVolunteer.Items(7).Selected() = True Then
                    .Printing = 1
                Else
                    .Printing = 0
                End If
                If chkVolunteer.Items(8).Selected() = True Then
                    .Equipment = 1
                Else
                    .Equipment = 0
                End If
                If chkVolunteer.Items(9).Selected() = True Then
                    .Electrician = 1
                Else
                    .Electrician = 0
                End If
                If chkVolunteer.Items(10).Selected() = True Then
                    .AsstCoach = 1
                Else
                    .AsstCoach = 0
                End If
                If chkBC.Checked = True Then
                    .BC = 1
                Else
                    .BC = 0
                End If
                .CreatedUser = Session("UserName")
                oPeople.UpdRow(0, Session("CompanyID"), Session("TimeZone"))
                Session("PeopleID") = .PeopleId
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "ADDPeople::" & ex.Message
        Finally
            oPeople = Nothing
        End Try
        Call LoadPeople(Session("PeopleID"))
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Session("PeopleID") > 0 Then
            If errorRTN() = True Then
                Call MsgBox("ERROR: " & lblError.Text)
                Exit Sub
            End If
            If Session("ErrorMsg") = "" Then Call UpdPeople(Session("PeopleID"))
            If Session("ErrorMsg") = "" Then Call MsgBox(txtFirstName.Text & " Changes successfully completed")
            lblError.Text = Session("ErrorMsg")
            txtLastName.Focus()
        Else
            If errorRTN() = True Then
                Call MsgBox("ERROR: " & lblError.Text)
                Exit Sub
            End If
            If Session("ErrorMsg") = "" Then Call ADDPeople()
            If Session("ErrorMsg") = "" Then Call MsgBox(txtFirstName.Text & " New Record Added Successfully")
            If Session("ErrorMsg") = "" Then Call ClearFields()
            lblError.Text = Session("ErrorMsg")
            txtFirstName.Focus()
            Session("PeopleID") = 0
        End If
    End Sub


    Private Sub btnComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComments.Click
        If Session("PeopleID") = 0 Then
            If errorRTN() = False Then Call ADDPeople()
        End If
        If Session("PeopleID") > 0 Then
            If errorRTN() = False Then Call UpdPeople(Session("PeopleID"))
            Session("CallingScreen") = "People.aspx"
            Session.Add("LinkID", Session("PeopleID"))
            Session.Add("CommentType", "P")
            Session("Title") = "Comments"
            Response.Redirect("Comments.aspx")
        End If
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        If Session("HouseId") = 0 Then
            lblError.Text = "Household missing"
            imgHouse.Focus()
            errorRTN = True
        ElseIf txtFirstName.Text = "" Then
            lblError.Text = "Name missing"
            txtFirstName.Focus()
            errorRTN = True
        ElseIf txtLastName.Text = "" Then
            lblError.Text = "Last Name missing"
            txtLastName.Focus()
            errorRTN = True
        ElseIf Not IsDate(mskBirthDate.Text) And chkParentPlayer.Items(2).Selected() = True Then
            lblError.Text = "BirthDate Missing "
            mskBirthDate.Focus()
            errorRTN = True
        ElseIf radGender.Items(0).Selected = False And radGender.Items(1).Selected = False Then
            lblError.Text = "Gender Missing "
            radGender.Focus()
            errorRTN = True
        ElseIf chkParentPlayer.Items(0).Selected = False And chkParentPlayer.Items(1).Selected = False And chkParentPlayer.Items(2).Selected = False Then
            lblError.Text = "Parent, Coach or Player not selected"
            chkParentPlayer.Focus()
            errorRTN = True
        End If
    End Function

    Private Sub btnTeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTeam.Click
        Response.Redirect("Teams.aspx")
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
        '2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
        '3) In your server-side click event, do this:
        If Session("AccessType") = "R" Then Exit Sub
        Dim btn As Button = CType(sender, Button)
        If lblDelete.Text = "" Then btn.CommandArgument = "Confirm"
        If btn.CommandArgument = "Confirm" Then
            lblDelete.Text = "*Click Delete button again to confirm.*"
            lblDelete.Visible = True
            btn.CommandArgument = "Delete"
        ElseIf btn.CommandArgument = "Delete" Then
            If Session("PeopleID") > 0 Then
                Call DELRow(Session("PeopleID"))
                'Call DELComments(Session("PeopleID"))
                'Call DELPlayerPtn(Session("PeopleID"))
                If Session("HouseID") > 0 Then Call LoadMembers(Session("HouseID"))
                Call ClearFields()
                txtFirstName.Focus()
            End If
            lblDelete.Text = ""
            lblDelete.Visible = False
            btn.CommandArgument = "Confirm"
        End If
        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.
    End Sub

    Private Sub DELRow(ByVal iPeopleID As Int32)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oPeople As New Profile.ClsPeople
        Try
            oPeople.DELRow(iPeopleID, Session("CompanyID"))
        Catch ex As Exception
            Session("ErrorMSG") = "DELRow::" & ex.Message
        Finally
            oPeople = Nothing
        End Try

    End Sub

    'Private Sub DELComments(ByVal RowID As Long)
    '    If Session("AccessType") = "R" Then Exit Sub
    '    Dim oComments As New Website.ClsComments
    '    Try
    '        oComments.DELRow(0, RowID, "P", Session("CompanyID"))
    '    Catch ex As Exception
    '        Session("ErrorMSG") = "DELComments::" & ex.Message
    '    Finally
    '        oComments = Nothing
    '    End Try
    'End Sub

    'Private Sub DELPlayerPtn(ByVal RowID As Long)
    '    If Session("AccessType") = "R" Then Exit Sub
    '    Dim oPlayer As New Season.ClsPlayers
    '    Try
    '        With oPlayer
    '            oPlayer.DELPlayerByPeople(RowID, Session("CompanyID"), Session("SeasonID"))
    '        End With
    '    Catch ex As Exception
    '        Session("ErrorMSG") = "DELPlayerPtn::" & ex.Message
    '    Finally
    '        oPlayer = Nothing
    '    End Try

    'End Sub

    Private Sub LoadMembers(ByVal RowID As Long)
        Dim oPeople As New Profile.ClsPeople
        Dim rsData As DataTable
        Try
            rsData = oPeople.GetMembers(Session("HouseID"), Session("CompanyID"))
            grdMembers.Rows.Clear()
            With grdMembers
                .DataSource = rsData
                .DataBind()
            End With
            'grdMembers.DisplayLayout.StationaryMargins = Infragistics.WebUI.UltraWebGrid.StationaryMargins.Header
            With grdMembers.DisplayLayout.Bands(0).Columns
                .FromKey("PeopleID").Hidden = True
                .FromKey("Gender").CellStyle.HorizontalAlign = HorizontalAlign.Center
                .FromKey("Gender").Header.Caption = "Gender"
                .FromKey("Gender").Width = 50
                .FromKey("Name").Width = 130
                .FromKey("BirthDate").Width = 70
                .FromKey("BirthDate").Format = "MM/dd/yyyy"
                .FromKey("BirthDate").CellStyle.HorizontalAlign = HorizontalAlign.Right
            End With
        Catch ex As Exception
            lblError.Text = "LoadMembers::" & ex.Message
        Finally
            oPeople = Nothing
            Session.Add("LinkName", txtLastName.Text)
        End Try

    End Sub

    Private Function SetDivision() As Long
        If Session("AccessType") = "R" Then Exit Function
        Dim oPlayer As New Season.ClsPlayers
        Try
            With oPlayer
                oPlayer.SetDivision(Session("PeopleID"), Session("CompanyID"), Session("SeasonID"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "SetDivision::" & ex.Message
        Finally
            oPlayer = Nothing
        End Try
    End Function

    Protected Sub grdMembers_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdMembers.SelectedRowsChange
        Session("PeopleID") = grdMembers.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
        If Session("PeopleID") > 0 Then
            Session("PlayerID") = GetPlayer()
            Call LoadPeople(Session("PeopleID"))
            Call LoadComments(Session("PeopleID"))
        End If
    End Sub

    Protected Sub imgHouse_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgHouse.Click
        If lnkHouseName.Text = "Name" Then
            Session("FirstLetter") = txtLastName.Text
        Else
            Session("FirstLetter") = lnkHouseName.Text
        End If
        Session("SearchType") = "Name"
        Session("CallingScreen") = "People.aspx"
        Response.Redirect("SearchHouse.aspx")
    End Sub

    Private Sub imgFirstName_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgFirstName.Click
        If Session("PeopleID") > 0 Then Session("HouseID") = 0
        Session("FirstLetter") = txtFirstName.Text
        Session("SearchType") = "FirstName"
        Session("CallingScreen") = "People.aspx"
        Response.Redirect("SearchPeople.aspx")
    End Sub

    Protected Sub lnkHouseName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHouseName.Click
        Response.Redirect("Households.aspx")
    End Sub

    Protected Sub imgLastName_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgLastName.Click
        'If Session("PeopleID") > 0 Then Session("HouseID") = 0
        Session("FirstLetter") = txtLastName.Text
        Session("SearchType") = "LastName"
        Session("CallingScreen") = "People.aspx"
        Response.Redirect("SearchPeople.aspx")
    End Sub

    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Session("PeopleID") > 0 Then
            If errorRTN() = False Then
                Call UpdPeople(Session("PeopleID"))
            End If
        Else
            If errorRTN() = False Then
                Call ADDPeople()
            End If
        End If

        If Session("PeopleID") > 0 Then
            Response.Redirect("Payments.aspx")
        End If
    End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub
End Class

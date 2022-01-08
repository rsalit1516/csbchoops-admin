Imports System.Data
Imports CSBC.Components
Partial Class Payments
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Or Session("PeopleID") = 0 Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Registration/Payments"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnOR.Enabled = False
            End If

            Session.Remove("DivisionID")
            Call LoadDivisions()
            If Session("PeopleID") > 0 Then
                Call ClearFields()
                Call LoadPeople(Session("PeopleID"))
                Call GetPlayerID()
                If Session("PlayerID") > 0 Then Call LoadPlayer(Session("PlayerID"))
                Call GetDivision()
                If Session("DivisionID") > 0 Then
                    cboDivisions.SelectedValue = Session("DivisionID")
                    Call LoadGrid()
                Else
                    btnTeam.Text = "*NO DIVISION FOUND*"
                    btnTeam.Visible = True
                End If
            End If
            ' Set the focus
            SetFocus(txtDraftID)
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

    Private Sub LoadDivisions()
        Dim oDivisions As New Season.ClsDivisions
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            cboDivisions.Items.Clear()
            rsData = oDivisions.LoadDivision(0, Session("CompanyID"), Session("SeasonID"))
            dRow = rsData.NewRow
            dRow("DivisionID") = 0
            dRow("Div_Desc") = "Select One"
            If rsData.Rows.Count = 0 Then rsData.Rows.InsertAt(dRow, 0)
            With cboDivisions
                .DataSource = rsData
                .DataValueField = "DivisionID"
                .DataTextField = "Div_Desc"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadDivisions::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try
    End Sub

    Private Sub ClearFields()
        mskPayDate.Text = Now()
        mskAmount.Text = GetSeasonFee()
        mskBalance.Text = 0
        txtDraftNotes.Text = ""
        txtMemo.Text = ""
        radPayment.Items(0).Selected() = True
        radPayment.Items(1).Selected() = False
        radPayment.Items(2).Selected() = False
        radPayment.Items(3).Selected() = False
        Session.Add("PayID", 0)
        txtDraftID.Text = ""
        txtDraftNotes.Text = ""
        cboRating.SelectedIndex = 0
        btnTeam.Visible = False
        'chkPlaysDown.Checked = False
        PlaysDownUp.SelectedIndex = 0
        lblbm.Visible = False
    End Sub

    Private Sub LoadPeople(ByVal PeopleID As Long)
        Dim oPeople As New Profile.ClsPeople
        Dim rsData As DataTable
        Try
            rsData = oPeople.LoadPeople(PeopleID, Session("CompanyID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    If IsNumeric(rsData.Rows(0).Item("HouseID")) Then ' And Session("HouseID") = 0 Then
                        Session("HouseID") = rsData.Rows(0).Item("HouseID")
                    End If
                    lnkName.Text = rsData.Rows(0).Item("LastName") & ", " & rsData.Rows(0).Item("FirstName")
                    If IsDBNull(rsData.Rows(0).Item("HousePhone")) Then
                        lblPhone.Text = ""
                    Else
                        lblPhone.Text = rsData.Rows(0).Item("HousePhone")
                    End If
                    lblAddress.Text = rsData.Rows(0).Item("Address1")
                    lblCSZ.Text = rsData.Rows(0).Item("City") & " " & rsData.Rows(0).Item("State") & " " & rsData.Rows(0).Item("Zip")
                    If rsData.Rows(0).Item("FeeWaived") = True Then lblBM.Visible = True

                    txtPlaysUp.Text = rsData.Rows(0).Item("GiftedLevelsUP")
                End If
            End If
        Catch ex As Exception
            lblError.Text = "LoadPeople::" & ex.Message
        Finally
            oPeople = Nothing
        End Try
    End Sub

    Private Sub GetPlayerID()
        Dim oPlayer As New Season.ClsPlayers
        Dim rsData As DataTable
        Session("PlayerID") = 0
        Try
            rsData = oPlayer.GetRecords(Session("PeopleID"), Session("CompanyID"), Session("SeasonID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    If Not IsDBNull(rsData.Rows(0).Item("PlayerID")) Then
                        Session("PlayerID") = rsData.Rows(0).Item("PlayerID")
                    End If
                End If
            End If
        Catch ex As Exception
            lblError.Text = "GetPlayerID::" & ex.Message
        Finally
            oPlayer = Nothing
        End Try
    End Sub

    Private Sub LoadPlayer(ByVal PlayerID As Long)
        Dim oPlayer As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPlayer.GetPlayer(PlayerID, Session("CompanyID"), Session("SeasonID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    If Not IsDBNull(rsData.Rows(0).Item("PlayerID")) Then
                        'Session("HouseID") = rsData.Rows(0).Item("HouseID")
                        Session("PlayerID") = rsData.Rows(0).Item("PlayerID")
                        txtDraftID.Text = rsData.Rows(0).Item("DraftID") & ""
                        txtDraftNotes.Text = rsData.Rows(0).Item("DraftNotes") & ""
                        If IsDBNull(rsData.Rows(0).Item("Rating")) Then
                            cboRating.SelectedIndex = 0
                        Else
                            cboRating.SelectedIndex = rsData.Rows(0).Item("Rating") & ""
                        End If
                        btnTeam.Visible = True
                        btnTeam.Text = rsData.Rows(0).Item("Div_Desc") & " (Team: " & rsData.Rows(0).Item("TeamNumber") & ")"
                        If IsDBNull(rsData.Rows(0).Item("TeamNumber")) Then btnTeam.Text = rsData.Rows(0).Item("Div_Desc") & ": Undrafted"
                        Session("TeamID") = rsData.Rows(0).Item("TeamID")
                        If IsDBNull(rsData.Rows(0).Item("TeamID")) Then Session("TeamID") = 0
                        btnTeam.ToolTip = rsData.Rows(0).Item("TeamName") & "-" & rsData.Rows(0).Item("TeamColor")
                        Session("DivisionID") = rsData.Rows(0).Item("DivisionID")
                        If IsDBNull(rsData.Rows(0).Item("DivisionID")) Then Session("DivisionID") = 0
                        If IsDate(rsData.Rows(0).Item("PaidDate")) Then
                            mskPayDate.Text = rsData.Rows(0).Item("PaidDate")
                        Else
                            mskPayDate.Text = ""
                        End If
                        mskAmount.Text = rsData.Rows(0).Item("PaidAmount")
                        mskBalance.Text = rsData.Rows(0).Item("BalanceOwed")
                        txtMemo.Text = rsData.Rows(0).Item("CheckMemo") & ""
                        txtCheck.Text = rsData.Rows(0).Item("NoteDesc") & ""
                        txtDraftNotes.Text = rsData.Rows(0).Item("DraftNotes") & ""
                        radPayment.Enabled = True
                        radPayment.Items(0).Selected() = False
                        radPayment.Items(1).Selected() = False
                        radPayment.Items(2).Selected() = False
                        radPayment.Items(3).Selected() = False
                        If Not IsDBNull(rsData.Rows(0).Item("PayType")) Then
                            If UCase(rsData.Rows(0).Item("PayType")) = "CHECK" Then radPayment.Items(0).Selected() = True
                            If UCase(rsData.Rows(0).Item("PayType")) = "CC" Then radPayment.Items(1).Selected() = True
                            If UCase(rsData.Rows(0).Item("PayType")) = "OR" Then
                                radPayment.Items(2).Selected() = True
                                radPayment.Enabled = False
                            End If
                            If UCase(rsData.Rows(0).Item("PayType")) = "CASH" Then radPayment.Items(3).Selected() = True
                        End If
                        chkWaived.Items(0).Selected() = rsData.Rows(0).Item("Scholarship")
                        chkWaived.Items(1).Selected() = rsData.Rows(0).Item("Rollover")
                        chkWaived.Items(2).Selected() = rsData.Rows(0).Item("FamilyDisc")
                        chkWaived.Items(3).Selected() = rsData.Rows(0).Item("AthleticDirector")
                        'chkWaived.Items(4).Selected() = rsData.Rows(0).Item("PartialRefund")
                        If rsData.Rows(0).Item("PlaysDown") = True Then
                            PlaysDownUp.SelectedIndex = 2
                        ElseIf rsData.Rows(0).Item("PlaysUp") = True Then
                            PlaysDownUp.SelectedIndex = 1
                        Else
                            PlaysDownUp.SelectedIndex = 0
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            lblError.Text = "LoadPlayer::" & ex.Message
        Finally
            oPlayer = Nothing
        End Try
    End Sub

    Private Sub GetDivision()
        Dim oDivisions As New Season.ClsDivisions
        Dim rsData As DataTable
        Try
            rsData = oDivisions.GetDivision(Session("PeopleID"), Session("CompanyID"), Session("SeasonID"))

            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    If IsDBNull(rsData.Rows(0).Item("DivisionID")) Then
                        Session("DivisionID") = 0
                    Else
                        Session("DivisionID") = rsData.Rows(0).Item("DivisionID")
                    End If
                End If
            End If
        Catch ex As Exception
            lblError.Text = "GetDivision::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try
    End Sub

    Private Sub LoadGrid()
        Dim oPlayer As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPlayer.GetDraftList(0, Session("CompanyID"), Session("SeasonID"), Session("DivisionID"), "PlayerID, PeopleID, DraftID, LastName + ' ' + FirstName as Name, BirthDate")
            If Not rsData Is Nothing Then
                grdPlayers.Rows.Clear()
                With grdPlayers
                    .DataSource = rsData
                    .DataBind()
                    With .DisplayLayout.Bands(0).Columns
                        .FromKey("PlayerID").Hidden = True
                        .FromKey("PeopleID").Hidden = True
                        .FromKey("Name").Width = 130
                        .FromKey("BirthDate").Width = 70
                        .FromKey("BirthDate").Format = "MM/dd/yyyy"
                        .FromKey("BirthDate").CellStyle.HorizontalAlign = HorizontalAlign.Right
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadGrid::" & ex.Message
        Finally
            oPlayer = Nothing
        End Try
    End Sub

    Private Function GetSeasonFee() As Long
        Dim oSeason As New Season.ClsSeasons
        GetSeasonFee = 0
        Try
            oSeason.GetSeason(Session("CompanyID"), Session("SeasonID"))
            GetSeasonFee = oSeason.PlayersFee
        Catch ex As Exception
            lblError.Text = "GetSeasonFee::" & ex.Message
        Finally
            oSeason = Nothing
        End Try
    End Function

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("USERACCESS") = "R" Then Exit Sub
        If Session("PlayerID") > 0 Then
            If errorRTN() = False Then
                Call UPDPlayer()
                Call MsgBox("Changes successfully completed")
            End If
        Else
            If errorRTN() = False Then
                Call UPDPlayer()
                Call MsgBox("New Record Added Successfully")
            End If
        End If
        If Session("PlayerID") > 0 Then Call LoadPlayer(Session("PlayerID"))
        If Session("DivisionID") > 0 Then
            cboDivisions.SelectedValue = Session("DivisionID")
            Call LoadGrid()
        End If
        btnTeam.Visible = True
    End Sub

    Private Sub UPDPlayer()
        If Session("USERACCESS") = "R" Then Exit Sub
        If Session("PlayerID") = 0 Then
            ADDPlayer()
        Else
            UpdRow(Session("PlayerID"))
        End If
    End Sub

    Private Sub ADDPlayer()
        Dim oPlayers As New Season.ClsPlayers
        Try
            oPlayers.PlaysDown = 0
            oPlayers.Playsup = 0
            If PlaysDownUp.Items(2).Selected = True Then
                oPlayers.PlaysDown = 1
            ElseIf PlaysDownUp.Items(1).Selected = True Then
                oPlayers.PlaysUp = 1
            End If
            oPlayers.CompanyId = Session("CompanyId")
            oPlayers.SeasonId = Session("SeasonID")
            oPlayers.DivisionId = Session("DivisionId")
            oPlayers.PeopleId = Session("PeopleID")
            oPlayers.DraftId = txtDraftID.Text
            oPlayers.DraftNotes = txtDraftNotes.Text
            oPlayers.Rating = cboRating.SelectedIndex
            oPlayers.PaidDate = mskPayDate.Value
            oPlayers.PaidAmount = mskAmount.Value
            oPlayers.BalanceOwed = mskBalance.Value
            oPlayers.Notes = txtCheck.Text
            If radPayment.Items(0).Selected() = True Then oPlayers.PayType = "CHECK"
            If radPayment.Items(1).Selected() = True Then oPlayers.PayType = "CC"
            If radPayment.Items(2).Selected() = True Then oPlayers.PayType = "CHECK"
            If radPayment.Items(3).Selected() = True Then oPlayers.PayType = "CASH"
            If chkWaived.Items(0).Selected() = True Then
                oPlayers.Scholarship = 1
            Else
                oPlayers.Scholarship = 0
            End If
            If chkWaived.Items(1).Selected() = True Then
                oPlayers.Rollover = 1
            Else
                oPlayers.Rollover = 0
            End If
            If chkWaived.Items(2).Selected() = True Then
                oPlayers.FamilyDisc = 1
            Else
                oPlayers.FamilyDisc = 0
            End If
            If chkWaived.Items(3).Selected() = True Then
                oPlayers.AthleticDirector = 1
            Else
                oPlayers.AthleticDirector = 0
            End If
            If chkWaived.Items(4).Selected() = True Then
                oPlayers.PartialRefund = 1
            Else
                oPlayers.PartialRefund = 0
            End If
            oPlayers.UserID = Session("UserID")
            oPlayers.AddNewPlayer(Session("TimeZone"))
            Session("playerID") = oPlayers.PlayerId
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oPlayers = Nothing
        End Try
    End Sub

    Private Sub UpdRow(ByVal RowID As Long)
        Dim oPlayers As New Season.ClsPlayers
        Try
            If oPlayers.DivisionId <> Session("DivisionID") Then
                oPlayers.DivisionId = Session("DivisionID")
                oPlayers.TeamId = 0
            End If
            oPlayers.Notes = txtCheck.Text
            oPlayers.Rating = cboRating.SelectedIndex
            oPlayers.PaidDate = mskPayDate.Value
            oPlayers.PaidAmount = mskAmount.Value
            oPlayers.BalanceOwed = mskBalance.Value
            oPlayers.DraftId = txtDraftID.Text
            oPlayers.CheckMemo = txtMemo.Text
            oPlayers.DraftNotes = txtDraftNotes.Text
            oPlayers.PlaysDown = 0
            oPlayers.PlaysUp = 0
            If PlaysDownUp.Items(2).Selected = True Then
                oPlayers.PlaysDown = 1
            ElseIf PlaysDownUp.Items(1).Selected = True Then
                oPlayers.PlaysUp = 1
            End If
            If chkWaived.Items(0).Selected() = True Then
                oPlayers.Scholarship = 1
            Else
                oPlayers.Scholarship = 0
            End If
            If chkWaived.Items(1).Selected() = True Then
                oPlayers.Rollover = 1
            Else
                oPlayers.Rollover = 0
            End If
            If chkWaived.Items(2).Selected() = True Then
                oPlayers.FamilyDisc = 1
            Else
                oPlayers.FamilyDisc = 0
            End If
            If chkWaived.Items(3).Selected() = True Then
                oPlayers.AthleticDirector = 1
            Else
                oPlayers.AthleticDirector = 0
            End If
            If chkWaived.Items(4).Selected() = True Then
                oPlayers.PartialRefund = 1
            Else
                oPlayers.PartialRefund = 0
            End If
            If radPayment.Items(0).Selected() = True Then
                oPlayers.PayType = "CHECK"
            ElseIf radPayment.Items(1).Selected() = True Then
                oPlayers.PayType = "CC"
            ElseIf radPayment.Items(2).Selected() = True Then
                oPlayers.PayType = "OR"
            ElseIf radPayment.Items(3).Selected() = True Then
                oPlayers.PayType = "CASH"
            End If

            oPlayers.UserID = Session("UserID")
            oPlayers.SeasonId = Session("SeasonID")
            oPlayers.PeopleId = Session("PeopleID")
            oPlayers.ApplyEdit(RowID, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oPlayers = Nothing
        End Try

    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        txtDraftID.Text = Trim(txtDraftID.Text)
        If Not IsDate(mskPayDate.Text) Then
            Call MsgBox("Date Missing ")
            errorRTN = True
        ElseIf mskAmount.Text = "" Then
            Call MsgBox("Amount Missing ")
            errorRTN = True
        ElseIf mskBalance.Text = "" Then
            Call MsgBox("Incorrect Balance value")
            errorRTN = True
        ElseIf txtDraftID.Text = "" And radPayment.Items(2).Selected = False Then
            Call MsgBox("Draft-ID Missing ")
            errorRTN = True
        ElseIf Len(txtDraftID.Text) = 3 And IsNumeric(Right(txtDraftID.Text, 1)) Then
            Call MsgBox("Invalid Draft-ID, use 2 digits number")
            errorRTN = True
        End If
        If Len(txtDraftID.Text) = 1 Then txtDraftID.Text = "0" & txtDraftID.Text
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
        '2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
        '3) In your server-side click event, do this:
        If Session("USERACCESS") = "R" Then Exit Sub
        Dim btn As Button = CType(sender, Button)
        If lblDelete.Text = "" Then btn.CommandArgument = "Confirm"
        If btn.CommandArgument = "Confirm" Then
            lblDelete.Text = "*Click Delete button again to confirm.*"
            lblDelete.Visible = True
            btn.CommandArgument = "Delete"
        ElseIf btn.CommandArgument = "Delete" Then
            If Session("PlayerID") > 0 Then
                Call DELRow(Session("PlayerID"))
                If lblError.Text > " " Then Exit Sub
                Response.Redirect("People.aspx")
                'Call GetDivision()
                'Call ClearFields()
                'If Session("DivisionID") > 0 Then Call LoadGrid()
        End If
        lblDelete.Text = ""
        lblDelete.Visible = False
        btn.CommandArgument = "Confirm"
        End If
        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.
    End Sub

    Private Sub DELRow(ByVal RowID As Long)
        If Session("USERACCESS") = "R" Then Exit Sub
        Dim oPlayers As New Season.ClsPlayers
        Try
            oPlayers.DeletePlayer(RowID, Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oPlayers = Nothing
        End Try
        Session("PlayerID") = 0
    End Sub

    Private Sub btnTeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTeam.Click
        Response.Redirect("Teams.aspx")
    End Sub

    Private Sub imgLast_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgLast.Click
        Response.Redirect("PaymentSearch.aspx")
    End Sub

    Private Sub lnkName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkName.Click
        Response.Redirect("People.aspx")
    End Sub

    Private Sub cboDivisions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDivisions.SelectedIndexChanged
        Session("DivisionID") = cboDivisions.SelectedItem.Value
        Call LoadGrid()
    End Sub

    Private Sub grdPlayers_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdPlayers.DblClick
        Session("PlayerID") = grdPlayers.DisplayLayout.ActiveRow.Cells.FromKey("PlayerID").Value
        Session("PeopleID") = grdPlayers.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
        Call ClearFields()
        Call LoadPeople(Session("PeopleID"))
        Call GetPlayerID()
        Call LoadPlayer(Session("PlayerID"))
    End Sub

    Private Sub btnOR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOR.Click
        If Session("USERACCESS") = "R" Then Exit Sub
        Dim oPlayers As New Season.ClsPlayers
        Try
            oPlayers.UpdateDraftID(cboDivisions.SelectedItem.Value, Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oPlayers = Nothing
        End Try
        Call LoadPlayer(Session("PlayerID"))
        Call LoadGrid()
    End Sub

End Class


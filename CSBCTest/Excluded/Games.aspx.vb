Imports System.Data
Imports System.Net.Mail
Imports CSBC.Components
Partial Class Games
    Inherits System.Web.UI.Page
    Private EmailsSent As Integer
    Private ErrorMsg As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Games"
            Session("AccessType") = AccessType()
            Calendar1.SelectedDate = Now 'Format(Now(), "d/m/y")

            Me.Calendar1.TodaysDate = Now()
            Me.Calendar1.TodayDayStyle.BackColor = Drawing.Color.LightGray

            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnNew.Enabled = False
                btnSend.Enabled = False
            End If
            'Me.txtTitle.Focus()

            Call LoadCombos()
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Games", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub UpdRow(ByVal ScheduleNo As Int16, ByVal GameNumber As Int16)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oGames As New Season.clsGames
        Try
            oGames.GameDate = mskDate.Text
            oGames.GameTime = txtTime.Text
            oGames.LocationNumber = cmbVenues.SelectedItem.Value
            oGames.Home = txtHome.Text
            oGames.Visitor = txtVisitor.Text
            oGames.Descr = txtDescr.Text
            If lblPlayoff.Visible = True Then
                oGames.GameType = "P"
            Else
                oGames.GameType = "R"
            End If
            oGames.UpdateGame(ScheduleNo, GameNumber)
        Catch ex As Exception
            lblError.Text = "UpdRow:" & ex.Message
        Finally
            oGames = Nothing
        End Try
    End Sub

    Private Sub ClearFields()
        cmbDivisions.SelectedIndex = 0
        lblPlayoff.Visible = False
        mskDate.Text = ""
        txtTime.Text = ""
        txtHome.Text = ""
        txtVisitor.Text = ""
        cmbVenues.SelectedIndex = 0
        lblError.Text = ""
        txtDescr.Text = ""
    End Sub

    Private Sub ADDRow()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oGames As New Season.clsGames
        Try
            With oGames
                .GameDate = mskDate.Text
                .GameTime = txtTime.Text
                .Home = txtHome.Text
                .Visitor = txtVisitor.Text
                .LocationNumber = cmbVenues.SelectedItem.Value
                .Descr = txtDescr.Text
                .AddRecord(Session("CompanyID"), cmbDivisions.SelectedItem.Value)
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "ADDRow::" & ex.Message
        Finally
            oGames = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("USERACCESS") = "R" Then Exit Sub
        If IsNumeric(Session("ScheduleNo")) Then
            'If lblPlayoff.Visible = True Then
            If errorRTN() = True Then
                Call MsgBox("ERROR: " & lblError.Text)
                Exit Sub
            Else
                Call UpdRow(Session("ScheduleNo"), Session("GameNumber"))
                Call MsgBox("Changes successfully completed")
                Call LoadGames()
                cmbDivisions.Enabled = False
            End If
        Else
            If errorRTN() = True Then
                Call MsgBox("ERROR: " & lblError.Text)
                Exit Sub
            Else
                Call ADDRow()
                Call MsgBox("New Record Added Successfully")
                Call LoadGames()
                cmbDivisions.Enabled = False
            End If
        End If
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        If cmbDivisions.SelectedIndex = 0 Then
            lblError.Text = "Division missing"
            errorRTN = True
            cmbDivisions.Focus()
        End If
        If mskDate.Text = "" Then
            lblError.Text = "Date missing"
            errorRTN = True
            mskDate.Focus()
        End If
        If txtTime.Text = "" Then
            lblError.Text = "Time missing"
            errorRTN = True
            txtTime.Focus()
        End If
        If cmbVenues.SelectedIndex = 0 Then
            lblError.Text = "Location missing"
            errorRTN = True
            cmbVenues.Focus()
        End If
        If errorRTN = True Then Response.End()
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
        '2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
        '3) In your server-side click event, do this:
        If Session("USERACCESS") = "R" Then Exit Sub
        Dim btn As Button = CType(sender, Button)
        If lblDeleteDate.Text = "" Then btn.CommandArgument = "Confirm"
        If btn.CommandArgument = "Confirm" Then
            lblDeleteDate.Text = "*Click Delete button again to confirm.*"
            lblDeleteDate.Visible = True
            btn.CommandArgument = "Delete"
        ElseIf btn.CommandArgument = "Delete" Then
            If Session("ScheduleNo") > 0 Then
                Call DELRow(Session("ScheduleNo"), Session("GameNumber"))
                Call ClearFields()
                Call LoadGames()
                Session("ScheduleNo") = 0
            End If
            lblDeleteDate.Text = ""
            lblDeleteDate.Visible = False
            btn.CommandArgument = "Confirm"
            cmbDivisions.Enabled = False
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.
    End Sub

    Private Sub DELRow(ByVal ScheduleNumber As Int16, ByVal GameNumber As Int16)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oGames As New Season.clsGames
        Try
            oGames.DELRow(ScheduleNumber, GameNumber)
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oGames = Nothing
        End Try
    End Sub

    Private Sub LoadCombos()
        Call LoadVenues()
        Call LoadDivisions()
        Call LoadGames()
        If Session("ScheduleNo") > "" Then Call LoadTeams()
        Call LoadEmails(0)
    End Sub

    Private Sub LoadVenues()
        Dim oVenues As New Season.clsGames
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            rsData = oVenues.LoadVenues(0, Session("CompanyID")) ', cmbDivisions.SelectedValue())
            dRow = rsData.NewRow
            dRow("LocationNumber") = 0
            If rsData.Rows.Count = 0 Then
                dRow("LocationName") = "NO Venues"
            Else
                dRow("LocationName") = " "
                rsData.Rows.InsertAt(dRow, 0)
            End If
            With cmbVenues
                .DataSource = rsData
                .DataValueField = "LocationNumber"
                .DataTextField = "LocationName"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadVenues::" & ex.Message
        Finally
            oVenues = Nothing
        End Try
    End Sub

    Private Sub LoadDivisions()
        Dim oDivisions As New Season.ClsDivisions
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            rsData = oDivisions.LoadDivision(0, Session("CompanyID"), Session("SeasonID"), "DivisionID, Div_Desc as Division")
            dRow = rsData.NewRow
            dRow("DivisionID") = 0
            If rsData.Rows.Count = 0 Then
                dRow("Division") = "NO Division"
            Else
                dRow("Division") = " "
                rsData.Rows.InsertAt(dRow, 0)
            End If
            With cmbDivisions
                .DataSource = rsData
                .DataValueField = "DivisionID"
                .DataTextField = "Division"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadDivisions::" & ex.Message
        Finally
            oDivisions = Nothing
        End Try
    End Sub

    Private Sub LoadTeams()
        Dim oTeams As New Season.ClsTeams
        Dim rsData As DataTable
        Try
            rsData = oTeams.LoadDivisionTeams(Session("ScheduleNo"), Session("CompanyID"), Session("SeasonID"), True)
            txtHome.Text = rsData.Rows(0).Item("Home")
        Catch ex As Exception
            lblError.Text = "LoadTeams::" & ex.Message
        Finally
            oTeams = Nothing
        End Try
    End Sub

    Private Sub LoadGames()
        Dim oGames As New Season.clsGames
        Dim rsData As DataTable
        Try
            rsData = oGames.GetDayGames(Session("CompanyID"), Session("SeasonID"), Calendar1.SelectedDate.Date)
            If rsData.Rows.Count > 0 Then
                btnSend.Enabled = True
                With grdGames
                    .DataSource = rsData
                    .DataBind()
                    With .DisplayLayout.Bands(0).Columns
                        'Incluir Division descr and ID
                        .FromKey("GameDate").Hidden = True
                        .FromKey("GameTime").Hidden = True
                        .FromKey("GameType").Hidden = True
                        .FromKey("ScheduleNumber").Hidden = True
                        .FromKey("DivisionID").Hidden = True
                        .FromKey("LocationNumber").Hidden = True
                        .FromKey("GameNumber").Hidden = True
                        .FromKey("HomeTeam").Hidden = True
                        .FromKey("VisitorTeam").Hidden = True
                        .FromKey("Descr").Hidden = True
                        .FromKey("LocationName").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("LocationName").Width = 120
                        .FromKey("Division").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("Division").Width = 150
                        '.FromKey("Date").Format = "ddd MM/dd/yyyy"
                        '.FromKey("Date").CellStyle.HorizontalAlign = HorizontalAlign.Right
                        .FromKey("GameDateTime").Width = 150
                        .FromKey("GameDateTime").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("Teams").Width = 120
                        .FromKey("Teams").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        '.FromKey("Location").HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                    End With
                End With
            Else
                btnSend.Enabled = False
                grdGames.Rows.Clear()
                grdGames.Clear()
            End If
            lblError.Text = ""
        Catch ex As Exception
            lblError.Text = "LoadGames:" & ex.Message
        Finally
            oGames = Nothing
            rsData = Nothing
        End Try
    End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Call ClearFields()
        If Me.Calendar1.TodaysDate <> Me.Calendar1.SelectedDate Then
            Me.Calendar1.TodayDayStyle.BackColor = Drawing.Color.White
        End If

        Call LoadGames()
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If Session("AccessType") = "R" Then Exit Sub
        Call SendEmails()
        For I As Int16 = 0 To lstEmails.Items.Count - 1
            lstEmails.Items(I).Selected = False
        Next
    End Sub

    Private Sub LoadEmails(ByVal iGroupType As Int32)
        Dim oEmails As New Profile.ClsHouseholds
        Dim rsData As DataTable
        Try
            rsData = oEmails.LoadEmails(iGroupType, Session("CompanyID"), Session("SeasonID"))
            lstEmails.Items.Clear()
            If rsData.Rows.Count > 0 Then
                '   |||||   Set the DataValueField to the Primary Key
                lstEmails.DataValueField = "Email"
                '   |||||   Set the DataTextField to the text/data you want to display
                lstEmails.DataTextField = "Name"
                '   |||||   Set the DataSource the the OleDBDataReader's result
                lstEmails.DataSource = rsData
                '   |||||   Bind the Source Data to the Web/Server Control
                lstEmails.DataBind()

            End If
            For I As Int16 = 0 To lstEmails.Items.Count - 1
                lstEmails.Items(I).Selected = True
            Next
        Catch ex As Exception
            lblError.Text = "LoadEmails::" & ex.Message
        Finally
            oEmails = Nothing
        End Try
    End Sub

    Private Sub SendEmails()
        Dim oEmail As New System.Net.Mail.MailMessage()
        Dim oSmtp As New SmtpClient("mail.csbchoops.net")
        Dim EmailBody As String
        oSmtp = New SmtpClient("mail.csbchoops.net")
        oSmtp.Host = "mail.csbchoops.net"
        oSmtp.Credentials = New System.Net.NetworkCredential("registrar@csbchoops.net", "csbc0317")
        oSmtp.Port = 25

        EmailBody = "<table border='3' WIDTH = '500'>"
        EmailBody += "<tr bgcolor='#99CCFF'><th>Location Name</th><th>Division</th><th align='center'>Game Time</th><th>Teams</th></tr>"
        For idx As Long = 0 To grdGames.Rows.Count - 1
            EmailBody += "<tr><td>" + grdGames.DisplayLayout.Rows(idx).Cells(1).Text
            EmailBody += "</td><td>" + grdGames.DisplayLayout.Rows(idx).Cells(2).Text
            EmailBody += "</td><td>" + grdGames.DisplayLayout.Rows(idx).Cells(4).Text
            EmailBody += "</td><td>" + grdGames.DisplayLayout.Rows(idx).Cells(5).Text + "</td></tr>"
        Next idx
        EmailBody += "</table>"


        For I As Int16 = 0 To lstEmails.Items.Count - 1
            If IsEmail(lstEmails.Items(I).Value) = True And lstEmails.Items(I).Selected = True Then
                oEmail = New System.Net.Mail.MailMessage()
                oEmail.From = New System.Net.Mail.MailAddress("registration@csbchoops.net")
                oEmail.To.Add(lstEmails.Items(I).Value)
                oEmail.IsBodyHtml = True
                oEmail.Subject = Format(Calendar1.SelectedDate, "ddd MMM/dd/yyyy") + " Games Scheduled"
                oEmail.Body = EmailBody
                If GoodEmail(oSmtp, oEmail) = True Then EmailsSent += 1
                oEmail.Dispose()
                oEmail = Nothing
            End If
        Next

        If EmailsSent = 0 Then
            lblError.Text = ErrorMsg & " (0) Email(s) sent!"
        Else
            lblError.Text = "(" & EmailsSent & ") Email(s) sent!"
        End If
        'txtSubject.Text = ""
        'htmlMail.Text = ""
    End Sub

    Private Function IsEmail(ByVal Email As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(Email, pattern)
        If emailAddressMatch.Success Then
            IsEmail = True
        Else
            IsEmail = False
        End If
    End Function

    Private Function GoodEmail(ByVal oSmtp As Object, ByVal oEmail As Object) As Boolean
        GoodEmail = True
        Try
            oSmtp.Send(oEmail)
        Catch ex As Exception
            ErrorMsg = "Unable to send mail!  " & ex.Message
            GoodEmail = False
        End Try
    End Function

    Protected Sub grdGames_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdGames.DblClick
        Call SelectGame()
    End Sub

    Protected Sub grdGames_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdGames.SelectedRowsChange
        Call SelectGame()
    End Sub

    Private Sub SelectGame()
        ClearFields()
        Session("ScheduleNo") = grdGames.DisplayLayout.ActiveRow.Cells(7).Text()
        Session("GameNumber") = grdGames.DisplayLayout.ActiveRow.Cells(9).Text()
        Session("LocationNumber") = grdGames.DisplayLayout.ActiveRow.Cells(8).Text()
        Session("GameType") = grdGames.DisplayLayout.ActiveRow.Cells(6).Text()
        If Session("GameType") = "P" Then
            lblPlayoff.Visible = True
            btnDelete.Enabled = True
            txtHome.Enabled = True
            txtVisitor.Enabled = True
            txtDescr.Visible = True
        Else
            lblPlayoff.Visible = False
            btnDelete.Enabled = False
            txtHome.Enabled = False
            txtVisitor.Enabled = False
            txtDescr.Visible = False
            cmbDivisions.Enabled = False
        End If
        cmbVenues.SelectedIndex = grdGames.DisplayLayout.ActiveRow.Cells(8).Text()
        cmbDivisions.SelectedValue = grdGames.DisplayLayout.ActiveRow.Cells(12).Text()
        txtDescr.Text = grdGames.DisplayLayout.ActiveRow.Cells(13).Text()
        txtHome.Text = grdGames.DisplayLayout.ActiveRow.Cells(10).Text()
        If txtDescr.Text = txtHome.Text Then txtHome.Text = ""
        txtVisitor.Text = grdGames.DisplayLayout.ActiveRow.Cells(11).Text()
        mskDate.Text = grdGames.DisplayLayout.ActiveRow.Cells(0).Text()
        txtTime.Text = grdGames.DisplayLayout.ActiveRow.Cells(4).Text()
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call ClearFields()
        Session.Remove("ScheduleNo")
        Session.Remove("GameNumber")
        Session.Remove("LocationNumber")
        Session.Remove("GameType")

        cmbDivisions.Enabled = True
        btnSave.Enabled = True
        cmbDivisions.Focus()
    End Sub

End Class


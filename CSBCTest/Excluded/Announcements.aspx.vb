Imports System.Data
Imports System.Net.Mail
Imports CSBC.Components

Partial Class Announcements
    Inherits System.Web.UI.Page
    Private ErrorMsg As String
    Private EmailsSent As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Announcements"
            Session("AccessType") = AccessType()
            lblFrom.Text = Session("EmailSender")
            If Session("AccessType") = "R" Then
                btnSend.Enabled = False
            End If

            Me.txtSubject.Focus()
            Call LoadEmails(0)
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Emails", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

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
        Catch ex As Exception
            lblError.Text = "LoadEmails::" & ex.Message
        Finally
            oEmails = Nothing
        End Try
    End Sub

    Private Sub ClearFields()
        For I As Int32 = 0 To lstEmails.Items.Count - 1
            lstEmails.Items(I).Selected = False
        Next
        txtSubject.Text = ""
        txtSubject.Focus()
        'txtBody.Text = ""
        cboTo.SelectedValue = 0
        Session("ErrorMsg") = ""
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If Session("AccessType") = "R" Then Exit Sub
        If errorRTN() = False Then Call SendEmails()
        If lblError.Text = "" Then
            For I As Int32 = 0 To lstEmails.Items.Count - 1
                lstEmails.Items(I).Selected = False
            Next
        End If
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = True
        If txtSubject.Text = "" Then
            lblError.Text = "Subject missing "
            txtSubject.Focus()
            Exit Function
        End If
        If lstEmails.Items.Count = 0 Then
            lblError.Text = "Recipients missing "
            cboTo.Focus()
            Exit Function
        End If
        If htmlMail.Text = "" Then
            lblError.Text = "Email content missing "
            Exit Function
        End If
        errorRTN = False
    End Function

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Private Sub SendEmails()
        Dim oEmail As New System.Net.Mail.MailMessage()
        Dim oSmtp As New SmtpClient("mail.csbchoops.net")
        oSmtp = New SmtpClient("mail.csbchoops.net")
        oSmtp.Host = "mail.csbchoops.net"
        oSmtp.Credentials = New System.Net.NetworkCredential("registrar@csbchoops.net", "csbc0317")
        oSmtp.Port = 25

        For I As Int32 = 0 To lstEmails.Items.Count - 1
            If IsEmail(lstEmails.Items(I).Value) = True Then
                oEmail = New System.Net.Mail.MailMessage()
                oEmail.From = New System.Net.Mail.MailAddress("registration@csbchoops.net")
                oEmail.To.Add(lstEmails.Items(I).Value)
                oEmail.IsBodyHtml = True
                oEmail.Body = htmlMail.Text
                oEmail.Subject = txtSubject.Text
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
        txtSubject.Text = ""
        htmlMail.Text = ""
    End Sub

    Private Function GoodEmail(ByVal oSmtp As Object, ByVal oEmail As Object) As Boolean
        GoodEmail = True
        Try
            oSmtp.Send(oEmail)
        Catch ex As Exception
            ErrorMsg = "Unable to send mail!  " & ex.Message
            GoodEmail = False
        End Try
    End Function
    'Private Sub SendEmails()
    '    Dim emailCount As Integer = 0
    '    Dim BatchCount As Integer = 0

    '    For I As Int32 = 0 To lstEmails.Items.Count - 1
    '        emailCount += 1
    '        BatchCount += 1
    '        If (emailCount Mod 20 = 0) Then
    '            SendBatch(emailCount - 20, I)
    '            If lblError.Text > "" Then
    '                lblError.Text += " Count = " & emailCount & " Batch:" & BatchCount
    '                Exit Sub
    '            End If
    '            BatchCount = 0
    '        End If
    '    Next

    '    'This will send the last batch if it was less that the max per batch
    '    If emailCount Mod 20 = 0 = False Then
    '        SendBatch(lstEmails.Items.Count - BatchCount, lstEmails.Items.Count - 1)
    '    End If
    '    'If emailCount < lstEmails.Items.Count - 1 Or emailCount < 50 Then
    '    '    SendBatch(lstEmails.Items.Count - emailCount, lstEmails.Items.Count - 1)
    '    'End If

    '    If lblError.Text = "" Then lblError.Text = "(" & EmailsSent & ") Email(s) sent!"
    '    txtSubject.Text = ""
    '    htmlMail.Text = ""
    'End Sub

    'Private Sub SendBatch(ByVal iFrom As Int32, ByVal iTo As Int32)
    '    Dim oEmail As New System.Net.Mail.MailMessage()
    '    Dim oSmtp As New SmtpClient("mail.csbchoops.net")
    '    Try
    '        oSmtp.Host = "mail.csbchoops.net"
    '        oSmtp.Credentials = New System.Net.NetworkCredential("registrar@csbchoops.net", "0317")
    '        oSmtp.Port = 25

    '        For I As Int32 = iFrom To iTo
    '            If IsEmail(lstEmails.Items(I).Value) = True Then
    '                oEmail.Bcc.Add(lstEmails.Items(I).Value)
    '                EmailsSent += 1
    '            End If
    '        Next

    '        oEmail.From = New System.Net.Mail.MailAddress("registrar@csbchoops.net")
    '        oEmail.IsBodyHtml = True
    '        oEmail.Subject = txtSubject.Text
    '        oEmail.Body = htmlMail.Text
    '        oSmtp.Send(oEmail)
    '        oSmtp = Nothing
    '        oEmail.Dispose()
    '        oEmail = Nothing
    '    Catch ex As Exception
    '        lblError.Text = "Unable to send mail!  " & ex.Message
    '    End Try
    'End Sub

    Private Function IsEmail(ByVal Email As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(Email, pattern)
        If emailAddressMatch.Success Then
            IsEmail = True
        Else
            IsEmail = False
        End If
    End Function

    Protected Sub cboTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTo.SelectedIndexChanged
        Call LoadEmails(cboTo.SelectedItem.Value)
    End Sub
End Class

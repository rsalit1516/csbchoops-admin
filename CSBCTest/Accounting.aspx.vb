Imports System.Data
Imports CSBC.Components
'Imports CSBC.Core.Models

Partial Class Accounting
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        'Response.Cache.SetExpires(DateTime.Now)
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)

        'If Len(Session("CurrentPage")) = 0 Or Session("CurrentPage") = "Accounting.aspx" Then
        'Else
        '    Response.Redirect(Session("CurrentPage"))
        '    Response.End()
        'End If


        If Page.IsPostBack = False Then
            Session("Title") = "Sponsor Payments"
            Call LoadProfile(Session("SponsorProfileID"))
            Session("CurrentPage") = "Accounting.aspx"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
            End If
            If Session("SponsorProfileID") = 0 Then
                Call ClearFields()
            Else
                Call LoadPayments()
            End If
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Sponsors", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadProfile(ByVal SponsorProfileID As Long)
        Dim oSponsors As New CSBC.Components.Season.clsSponsors
        Dim rsData As DataTable
        Try
            rsData = oSponsors.LoadAllSponsors(SponsorProfileID, Session("CompanyID"))
            If rsData.Rows.Count > 0 Then
                lblSponsorName.Text = rsData.Rows(0).Item("SpoName") & ""
                Session("SponsorProfileID") = rsData.Rows(0).Item("SponsorProfileID") & ""
                lblBalance.Text = Format(rsData.Rows(0).Item("Balance"), "currency")
                If rsData.Rows(0).Item("Balance") > 0 Then lblBalance.ForeColor = Drawing.Color.Red
                If rsData.Rows(0).Item("Balance") = 0 Then lblBalance.ForeColor = Drawing.Color.Black
                If rsData.Rows(0).Item("Balance") < 0 Then lblBalance.ForeColor = Drawing.Color.DarkGreen
            End If

        Catch ex As Exception
            lblError.Text = "LoadProfile::" & ex.Message
        Finally
            oSponsors = Nothing
        End Try
    End Sub

    Private Sub LoadPayments()
        Dim oPayments As New CSBC.Components.Season.clsSponsors
        Dim rsData As DataTable
        Try
            rsData = oPayments.GetSponsorPayments(Session("CompanyID"), Session("SponsorProfileID"))
            grdPayments.Clear()
            grdPayments.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdPayments
                    .DataSource = rsData
                    .DataBind()
                    With grdPayments.DisplayLayout.Bands(0).Columns
                        .FromKey("PaymentID").Hidden = True
                        .FromKey("Memo").Hidden = True
                        '.FromKey("Sea_Desc").Header.Caption = "Season"
                        '.FromKey("Sea_Desc").Width = 170
                        .FromKey("TransactionDate").Width = 50
                        .FromKey("TransactionDate").Format = "MM/dd/yyyy"
                        .FromKey("TransactionDate").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("TransactionDate").Header.Caption = "Date"
                        .FromKey("Amount").Width = 50
                        .FromKey("Amount").Format = "$#,##0.00"
                        .FromKey("Amount").CellStyle.HorizontalAlign = HorizontalAlign.Right
                        .FromKey("TransactionNumber").Header.Caption = "Number"
                        .FromKey("TransactionNumber").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("TransactionNumber").Width = 100
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadPayments::" & ex.Message
        Finally
            oPayments = Nothing
        End Try
    End Sub

    Private Sub UpdRow(ByVal PaymentID As Long)
        'If Session("AccessType") = "R" Then Exit Sub
        'Dim oPayments As New Sponsor
        'Try
        '    With oPayments
        '        .CompanyID = Session("CompanyID")
        '        .SponsorProfileId = Session("SponsorProfileID")
        '        .CheckNo = txtCheck.Text
        '        .PaymentAmount = mskAmount.Text
        '        .PaymentDate = mskDate.Text
        '        If radPayment.Items(1).Selected = True Then .PaymentType = "Check"
        '        If radPayment.Items(0).Selected = True Then .PaymentType = "Cash"
        '        If radPayment.Items(2).Selected = True Then .PaymentType = "CC"
        '        .CreatedUser = Session("UserName")
        '        oPayments.UpdPayment(PaymentID, Session("CompanyID"), Session("TimeZone"))
        '    End With
        'Catch ex As Exception
        '    Session("ErrorMSG") = "UpdRow::" & ex.Message
        'Finally
        '    oPayments = Nothing
        'End Try
    End Sub

    Private Sub ClearFields()
        grdPayments.Controls.Clear()
        txtCheck.Text = ""
        Session("PaymentID") = 0
        Session("ErrorMsg") = ""
        mskDate.Text = ""
        mskAmount.Text = ""

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & Session("ErrorMsg"))
            lblError.Text = Session("ErrorMsg")
            Exit Sub
        End If
        UpdRow(Session("PaymentID"))
        If Session("PaymentID") > 0 Then
            Call MsgBox("Changes successfully completed")
        Else
            Call MsgBox("New Record Added Successfully")
        End If
        LoadPayments()
        LoadProfile(Session("SponsorProfileID"))
        ClearFields()
        btnSave.Enabled = False
        btnDelete.Enabled = False
        lblError.Text = Session("ErrorMsg")
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        If Not IsDate(mskDate.Value) Or mskDate.Text = "" Then
            Session.Add("ErrorMsg", "Missing Payment date mm/dd/yyyy ")
            errorRTN = True
            mskDate.Focus()
        ElseIf Not IsNumeric(mskAmount.Value) Or mskAmount.Text = "" Then
            Session.Add("ErrorMsg", "Missing Payment Amount ")
            errorRTN = True
            mskAmount.Focus()
        End If
    End Function

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        btnSave.Enabled = True
        Call ClearFields()
        mskDate.Focus()
        radPayment.Items(0).Selected = False
        radPayment.Items(1).Selected = True
        radPayment.Items(2).Selected = False

    End Sub

    Protected Sub grdPayments_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdPayments.SelectedRowsChange
        Session("PaymentID") = grdPayments.DisplayLayout.ActiveRow.Cells.FromKey("PaymentID").Value
        LoadRecord(Session("PaymentID"))
        btnSave.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub LoadRecord(ByVal iPaymentID As Long)
        Dim oPayments As New Season.clsSponsors
        Dim rsdata As DataTable
        Try
            rsdata = New DataTable() 'oPayments.SponsorPayment(iPaymentID, Session("CompanyID"))
            If rsdata.Rows.Count > 0 Then
                Session("PaymentID") = rsdata.Rows(0).Item("PaymentID")
                mskAmount.Text = rsdata.Rows(0).Item("amount")
                mskDate.Text = rsdata.Rows(0).Item("TransactionDate")
                txtCheck.Text = rsdata.Rows(0).Item("TransactionNumber")
                radPayment.Items(0).Selected = False
                radPayment.Items(1).Selected = False
                radPayment.Items(2).Selected = False
                Select Case UCase(rsdata.Rows(0).Item("PaymentType"))
                    Case "CHECK"
                        radPayment.Items(1).Selected = True
                    Case "CASH"
                        radPayment.Items(0).Selected = True
                    Case "CC"
                        radPayment.Items(2).Selected = True
                    Case Else
                        radPayment.Items(0).Selected = True
                End Select
            End If
        Catch ex As Exception
            lblError.Text = "LoadRecord::" & ex.Message
        Finally
            oPayments = Nothing
        End Try
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
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
            If Session("PaymentID") > 0 Then
                Call DELRow(Session("PaymentID"))
                Call ClearFields()
                Session("PaymentID") = 0
                Call LoadPayments()
                Call LoadProfile(Session("SponsorProfileID"))
            End If
            lblDelete.Text = ""
            lblDelete.Visible = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btn.CommandArgument = "Confirm"
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.

    End Sub

    Private Sub DELRow(ByVal iPaymentID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oPayments As New Season.clsSponsors
        Try
            'oPayments.DELSponsorPayments(iPaymentID, Session("CompanyID"))
        Catch ex As Exception
            Session("ErrorMSG") = "DELRow::" & ex.Message
        Finally
            oPayments = Nothing
        End Try

    End Sub

    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Session("CurrentPage") = ""
        Response.Redirect("Sponsors.aspx")
    End Sub
End Class

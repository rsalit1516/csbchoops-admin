Imports System.Data
Imports System.Net.Mail
Imports CSBC.Components
Partial Class Refunds
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Refunds"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
            End If

            Call LoadList()
            Call LoadRefunds()

        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Refunds", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadList()
        Dim oRefunds As New Season.ClsPlayers
        Dim rsData As DataTable

        Try
            rsData = oRefunds.GetBatches(Session("SeasonID"), Session("CompanyID"), "RefBatchId, CreatedDate")
            grdBatches.Clear()
            grdBatches.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                btnSave.Enabled = True
                With grdBatches
                    .DataSource = rsData
                    .DataBind()
                    With grdBatches.DisplayLayout.Bands(0).Columns
                        '.FromKey("SeasonID").Hidden = True
                        '.FromKey("CreatedUser").Hidden = True
                        .FromKey("RefBatchId").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("RefBatchId").Header.Caption = "Batch"
                        .FromKey("CreatedDate").CellStyle.HorizontalAlign = HorizontalAlign.Center
                        .FromKey("CreatedDate").Header.Caption = "Date / Time"
                        '.FromKey("CreatedDate").Format = "MM/dd/yyyy"
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadList::" & ex.Message
        Finally
            oRefunds = Nothing
        End Try
    End Sub

    Private Sub LoadRefunds()
        Dim oRefunds As New Season.ClsPlayers
        Dim rsData As DataTable

        Try
            rsData = oRefunds.GetRefundCandidates(Session("SeasonID"), Session("CompanyID"), "PeopleID, DraftID, LastName + ' ' + FirstName as PlayerName ")
            grdRefunds.Clear()
            grdRefunds.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdRefunds
                    .DataSource = rsData
                    .DataBind()
                    With grdRefunds.DisplayLayout.Bands(0).Columns
                        .FromKey("PeopleID").Hidden = True
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadRefunds::" & ex.Message
        Finally
            oRefunds = Nothing
        End Try
        If grdRefunds.Rows.Count = 0 Then btnSave.Enabled = False
    End Sub

    Private Sub AddBatch()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oBatches As New Season.ClsPlayers
        Try
            With oBatches
                .CreateRefundBatch(Session("CompanyID"), Session("SeasonID"), Session("UserID"), chkFinal.Checked)
                Session("BatchID") = .BatchId
            End With
        Catch ex As Exception
            Session("ErrorMSG") = ex.Message
        Finally
            oBatches = Nothing
        End Try

    End Sub

    Private Sub SendEmail(ByVal iBatchID As Int32)

        Dim oEmail As New System.Net.Mail.MailMessage()
        Dim oSmtp As New SmtpClient("mail.csbchoops.net")
        Try
            oSmtp.Host = "mail.csbchoops.net"
            oSmtp.Credentials = New System.Net.NetworkCredential("registrar@csbchoops.net", "0317")

            oEmail.Bcc.Add("treasurer@csbchoops.net")
            'oEmail.Bcc.Add("mannyrosa@yahoo.com")
            oEmail.From = New System.Net.Mail.MailAddress("administrator@csbchoops.net")
            oEmail.IsBodyHtml = True
            oEmail.Subject = "New Refunds Batch Ready"
            oEmail.Body = "A new batch of refunds (" & iBatchID & ") has been created for <br> " & Session("SeasonDesc")
            oSmtp.Send(oEmail)
            oSmtp = Nothing
            oEmail.Dispose()
            oEmail = Nothing
        Catch ex As Exception
            lblError.Text = "Unable to send mail!  " & ex.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        Call AddBatch()
        If Session("BatchID") > 0 Then
            Call SendEmail(Session("BatchID"))
            Call MsgBox("Refund Batch Successfully Created")
            Call LoadList()
            Call LoadRefunds()
        Else
            Call MsgBox("No players found for Refund")
            lblPlayers.Text = ""
            grdPlayers.Rows.Clear()
        End If
        btnSave.Enabled = False
    End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Protected Sub grdBatches_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdBatches.DblClick
        lblPlayers.Text = "Batch (" & grdBatches.DisplayLayout.ActiveRow.Cells.FromKey("RefBatchID").Value & ") Players"
        LoadBatchPlayers(grdBatches.DisplayLayout.ActiveRow.Cells.FromKey("RefBatchID").Value)
    End Sub

    Private Sub LoadBatchPlayers(ByVal iBatchID As Int32)
        Dim oPlayers As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPlayers.GetBatchPlayers(iBatchID, Session("CompanyID"), "DraftID, PlayerName")
            grdPlayers.Clear()
            grdPlayers.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdPlayers
                    .DataSource = rsData
                    .DataBind()
                    With grdPlayers.DisplayLayout.Bands(0).Columns
                        '.FromKey("CompanyID").Hidden = True
                        '.FromKey("PeopleID").Hidden = True
                        '.FromKey("RefundBatchID").Hidden = True
                        '.FromKey("PlayerID").Hidden = True
                        '.FromKey("HouseID").Hidden = True
                        '.FromKey("Mother").Hidden = True
                        '.FromKey("Father").Hidden = True
                        '.FromKey("Address1").Hidden = True
                        '.FromKey("City").Hidden = True
                        '.FromKey("State").Hidden = True
                        '.FromKey("Zip").Hidden = True
                        '.FromKey("PaidAmount").Hidden = True
                        '.FromKey("Online").Hidden = True
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadBatchPlayers::" & ex.Message
        Finally
            oPlayers = Nothing
        End Try
    End Sub

    Protected Sub grdPlayers_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdPlayers.DblClick
        Session("PeopleID") = grdPlayers.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value

        If Session("PeopleID") > 0 Then
            Response.Redirect("Payments.aspx")
        End If
    End Sub

    Protected Sub chkFinal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFinal.CheckedChanged
        If chkFinal.Checked = True Then
            btnSave.Enabled = True
            LoadFinalRefunds()
        End If
    End Sub
    Private Sub LoadFinalRefunds()
        Dim oRefunds As New Season.ClsPlayers
        Dim rsData As DataTable

        Try
            rsData = oRefunds.GetRefundFinalCandidates(Session("SeasonID"), Session("CompanyID"), "PeopleID, DraftID, LastName + ' ' + FirstName as PlayerName ")
            grdRefunds.Clear()
            grdRefunds.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdRefunds
                    .DataSource = rsData
                    .DataBind()
                    With grdRefunds.DisplayLayout.Bands(0).Columns
                        .FromKey("PeopleID").Hidden = True
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadRefunds::" & ex.Message
        Finally
            oRefunds = Nothing
        End Try
        If grdRefunds.Rows.Count = 0 Then btnSave.Enabled = False
    End Sub
End Class


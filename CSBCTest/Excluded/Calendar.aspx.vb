Imports System.Data
Imports CSBC.Components
Partial Class Calendar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Calendar"
            Session("AccessType") = AccessType()

            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
            End If
            Me.txtTitle.Focus()

            Call DELOLDDates()
            Call LoadActivities()
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Calendar", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oActivities As New Website.clsCalendar
        Try
            With oActivities
                .Title = txtTitle.Text
                .subTitle = txtSubTitle.Text
                '.dDate = lblDate.Text
                .bDisplay = chkDisplay.Checked
                .Desc1 = txtDescription1.Text
                .Desc2 = txtDescription2.Text
                .Desc3 = txtDescription3.Text
                '.CreatedUser = Session("UserName")
                .UpdRow(RowID, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            oActivities = Nothing
        End Try
    End Sub

    Private Sub ClearFields()
        txtTitle.Text = ""
        txtSubTitle.Text = ""
        txtDescription1.Text = ""
        txtDescription2.Text = ""
        txtDescription3.Text = ""
        Session.Remove("ID")
        chkDisplay.Checked = True
    End Sub

    Private Sub ADDRow()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oActivities As New Website.clsCalendar
        Try
            With oActivities
                .Title = txtTitle.Text
                .subTitle = txtSubTitle.Text
                .dDate = lblDate.Text
                .bDisplay = chkDisplay.Checked
                .iYear = Year(lblDate.Text)
                .iMonth = Month(lblDate.Text)
                .iDay = Day(lblDate.Text)
                .Desc1 = txtDescription1.Text
                .Desc2 = txtDescription2.Text
                .Desc3 = txtDescription3.Text
                .CreatedUser = Session("UserName")
                .UpdRow(0, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            oActivities = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("USERACCESS") = "R" Then Exit Sub
        If Session("ID") > 0 Then
            If errorRTN() = False Then
                Call UpdRow(Session("ID"))
                Call MsgBox("Changes successfully completed")
                Call LoadActivities()
            End If
        Else
            If errorRTN() = False Then
                Call ADDRow()
                Call MsgBox("New Record Added Successfully")
                Call LoadActivities()
            End If
        End If
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        If txtTitle.Text = "" Then
            If Session("USERACCESS") = "R" Then
                Response.Write("Update Not allowed")
            Else
                Response.Write("Name missing ")
            End If
            errorRTN = True
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
            If Session("ID") > 0 Then
                Call DELRow(Session("ID"))
                Call ClearFields()
                Call LoadActivities()
                Session("ID") = 0
            End If
            lblDeleteDate.Text = ""
            lblDeleteDate.Visible = False
            btn.CommandArgument = "Confirm"
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.
    End Sub

    Private Sub DELRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oActivities As New Website.clsCalendar
        Try
            oActivities.DELRow(RowID, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oActivities = Nothing
        End Try
    End Sub

    Private Sub LoadRow(ByVal dID As Int32)
        Call ClearFields()
        Dim oActivities As New Website.clsCalendar
        Dim rsData As DataTable
        Try
            rsData = oActivities.LoadCalendar(Session("CompanyID"), dID)
            Session.Remove("ID")
            If rsData.Rows.Count > 0 Then
                Session("ID") = rsData.Rows(0).Item("ID")
                If rsData.Rows(0).Item("Display") = 1 Then
                    chkDisplay.Checked = True
                Else
                    chkDisplay.Checked = False
                End If
                lblDate.Text = Format(rsData.Rows(0).Item("dDate"), "ddd MMM/dd/yyyy")
                txtTitle.Text = rsData.Rows(0).Item("sTitle") & ""
                txtSubTitle.Text = rsData.Rows(0).Item("sSubTitle") & ""
                txtDescription1.Text = rsData.Rows(0).Item("sDesc1") & ""
                txtDescription2.Text = rsData.Rows(0).Item("sDesc2") & ""
                txtDescription3.Text = rsData.Rows(0).Item("sDesc3") & ""
            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oActivities = Nothing
        End Try
    End Sub

    Private Sub LoadActivities()
        Dim oActivities As New Website.clsCalendar
        Dim rsData As DataTable

        Try
            rsData = oActivities.LoadCalendar(Session("CompanyID"), 0, "ID, dDate, sTitle")
            grdActivities.Clear()
            grdActivities.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdActivities
                    .DataSource = rsData
                    .DataBind()
                    With grdActivities.DisplayLayout.Bands(0).Columns
                        .FromKey("ID").Hidden = True
                        .FromKey("sTitle").Header.Caption = "Description"
                        .FromKey("sTitle").Width = 150
                        .FromKey("dDate").Header.Caption = "Date"
                        .FromKey("dDate").Width = 70
                        .FromKey("dDate").Format = "MM/dd/yyyy"
                        .FromKey("dDate").CellStyle.HorizontalAlign = HorizontalAlign.Left
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadActivities::" & ex.Message
        Finally
            oActivities = Nothing
        End Try
    End Sub

    Private Sub DELOLDDates()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oActivities As New Website.clsCalendar
        Try
            oActivities.DELRow(0, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oActivities = Nothing
        End Try
    End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Call ClearFields()
        txtTitle.Focus()
        For I As Int32 = 0 To grdActivities.Rows.Count - 1
            If grdActivities.Rows(I).Cells(1).Text = Calendar1.SelectedDate Then
                Call LoadRow(grdActivities.Rows(I).Cells(0).Text)
                Exit For
            End If
        Next
        lblDate.Text = Calendar1.SelectedDate
    End Sub

    Protected Sub grdActivities_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdActivities.DblClick
        Calendar1.SelectedDate = grdActivities.DisplayLayout.ActiveRow.Cells(1).Text()
        Call LoadRow(grdActivities.DisplayLayout.ActiveRow.Cells(0).Text())
    End Sub

End Class


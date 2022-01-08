Imports System.Data
Imports System.Data.SqlClient
Imports CSBC.Components

Public Class BoardUPD
    Inherits System.Web.UI.Page
    Private rsData As DataTable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Board Members"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
            End If
            Call LoadFlagged()
            Call LoadList()
            If Session("DirectorID") > 0 Then
                Call LoadRow(Session("DirectorID"))
            End If
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Directors", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadFlagged()
        Dim dRow As DataRow
        Dim oPeople As New Volunteers.ClsDirectors
        Try
            rsData = oPeople.GetBoard(Session("CompanyID"))
            dRow = rsData.NewRow
            dRow("PeopleID") = 0
            dRow("Name") = " "
            rsData.Rows.InsertAt(dRow, 0)
            With cboBM
                .DataSource = rsData
                .DataValueField = "PeopleID"
                .DataTextField = "Name"
                .DataBind()
            End With

        Catch ex As Exception
            lblError.Text = "LoadFlagged::" & ex.Message
        Finally
            oPeople = Nothing
        End Try
    End Sub

    Private Sub LoadList()
        Dim oDirectors As New Volunteers.ClsDirectors
        Try
            rsData = oDirectors.GetDirectors(Session("CompanyID"), 0)
            With grdBM
                .DataSource = rsData
                .DataBind()
                'grdBM.DisplayLayout.StationaryMargins = Infragistics.WebUI.UltraWebGrid.StationaryMargins.Header
                With .DisplayLayout.Bands(0).Columns
                    .FromKey("ID").Hidden = True
                    .FromKey("Seq").Hidden = True
                    .FromKey("Name").Width = 140
                    .FromKey("Title").Width = 210
                    .FromKey("PhoneSelected").Header.Caption = "Phone"
                    .FromKey("PhoneSelected").Width = 90
                End With
            End With
        Catch ex As Exception
            lblError.Text = "LoadList::" & ex.Message
        Finally
            oDirectors = Nothing
        End Try

    End Sub

    Private Sub LoadRow(ByVal RowID As Long)
        Dim oDirectors As New Volunteers.ClsDirectors
        Try
            rsData = oDirectors.GetDirectors(Session("CompanyID"), RowID)
            cobPhones.Items.Clear()

            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    lblName.Text = rsData.Rows(0).Item("Name") + ""
                    lblAddress.Text = rsData.Rows(0).Item("Address1") + ""
                    lblCSZ.Text = rsData.Rows(0).Item("CITY") + " " + rsData.Rows(0).Item("STATE") + " " + rsData.Rows(0).Item("Zip")
                    lblPhone.Text = rsData.Rows(0).Item("PHONE") + ""
                    txtTitle.Text = rsData.Rows(0).Item("Title") + ""
                    lblEmail.Text = rsData.Rows(0).Item("Email") + ""
                    cobPhones.Items.Add(New ListItem("NONE", 0))
                    cobPhones.Items.Add(New ListItem(Trim(rsData.Rows(0).Item("Phone") + ""), 1))
                    cobPhones.Items.Add(New ListItem(Trim(rsData.Rows(0).Item("CellPhone") + ""), 2))
                    cobPhones.Items.Add(New ListItem(Trim(rsData.Rows(0).Item("WorkPhone") + ""), 3))
                    lblBoard.Visible = False
                    chkEmail.Checked = rsData.Rows(0).Item("EmailPref")

                    Select Case rsData.Rows(0).Item("PhonePref")
                        Case "HOME"
                            cobPhones.Items(1).Selected = True
                        Case "CELL"
                            cobPhones.Items(2).Selected = True
                        Case "WORK"
                            cobPhones.Items(3).Selected = True
                        Case Else
                            cobPhones.Items(0).Selected = True
                    End Select
                End If
            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oDirectors = Nothing
        End Try

        cboBM.Visible = False
    End Sub

    Private Sub LoadPeople(ByVal RowID As Long)
        Dim oPeople As New Profile.ClsPeople
        Try
            rsData = oPeople.LoadPeople(RowID, Session("CompanyID"))
            Call ClearFields()
            cobPhones.Items.Clear()
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    lblName.Text = rsData.Rows(0).Item("Name") + ""
                    lblAddress.Text = rsData.Rows(0).Item("Address1") + ""
                    lblCSZ.Text = rsData.Rows(0).Item("CITY") + " " + rsData.Rows(0).Item("STATE") + " " + rsData.Rows(0).Item("Zip")
                    lblPhone.Text = rsData.Rows(0).Item("HousePhone") + ""
                    lblEmail.Text = rsData.Rows(0).Item("Email") + ""
                    cobPhones.Items.Add(New ListItem("NONE", 0))
                    cobPhones.Items.Add(New ListItem(Trim(rsData.Rows(0).Item("HousePhone") + ""), 1))
                    cobPhones.Items.Add(New ListItem(Trim(rsData.Rows(0).Item("CellPhone") + ""), 2))
                    cobPhones.Items.Add(New ListItem(Trim(rsData.Rows(0).Item("WorkPhone") + ""), 3))
                    lblBoard.Visible = False
                    cobPhones.Items(1).Selected = True
                End If
            End If
        Catch ex As Exception
            lblError.Text = "LoadPeople::" & ex.Message
        Finally
            oPeople = Nothing
        End Try
        cboBM.Visible = False
    End Sub

    Private Sub ADDRow()
        If Session("AccessType") = "R" Then Exit Sub

        Dim oDirectors As New Volunteers.ClsDirectors
        Try
            oDirectors.PeopleID = cboBM.SelectedItem.Value
            oDirectors.Title = txtTitle.Text
            If cobPhones.Items(0).Selected = True Then oDirectors.PhoneType = ePhoneType.NONE
            If cobPhones.Items(1).Selected = True Then oDirectors.PhoneType = ePhoneType.HOME
            If cobPhones.Items(2).Selected = True Then oDirectors.PhoneType = ePhoneType.CELL
            If cobPhones.Items(3).Selected = True Then oDirectors.PhoneType = ePhoneType.WORK
            oDirectors.EmailPref = chkEmail.Checked
            oDirectors.UserID = Session("UserID")
            oDirectors.AddDirector(Session("CompanyID"), Session("TimeZone"))
        Catch ex As Exception
            lblError.Text = "ADDRow::" & ex.Message
        Finally
            oDirectors = Nothing
        End Try
    End Sub

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oDirectors As New Volunteers.ClsDirectors
        Try
            oDirectors.PeopleID = cboBM.SelectedItem.Value
            oDirectors.Title = txtTitle.Text
            If cobPhones.Items(0).Selected = True Then oDirectors.PhoneType = ePhoneType.NONE
            If cobPhones.Items(1).Selected = True Then oDirectors.PhoneType = ePhoneType.HOME
            If cobPhones.Items(2).Selected = True Then oDirectors.PhoneType = ePhoneType.CELL
            If cobPhones.Items(3).Selected = True Then oDirectors.PhoneType = ePhoneType.WORK
            oDirectors.EmailPref = chkEmail.Checked
            oDirectors.UserID = Session("UserID")
            oDirectors.UpdRow(RowID, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = "UpdRow::" & ex.Message
        Finally
            oDirectors = Nothing
        End Try

    End Sub

    Private Sub DELRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oDirectors As New Volunteers.ClsDirectors
        Try
            oDirectors.DELRow(RowID, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = "DELRow::" & ex.Message
        Finally
            oDirectors = Nothing
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ErrorsFound() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("DirectorID") > 0 Then
            Call UpdRow(Session("DirectorID"))
            If lblError.Text = "" Then
                Call MsgBox("Changes successfully completed")
                Call ClearFields()
                cboBM.SelectedValue = 0
            End If
        Else
            Call ADDRow()
            If lblError.Text = "" Then
                Call MsgBox("New Record Added Successfully")
                Call ClearFields()
                cboBM.SelectedValue = 0
            End If
        End If
        Call LoadList()

    End Sub

    Private Function ErrorsFound() As Boolean
        ErrorsFound = False
        If txtTitle.Text = "" Then
            ErrorsFound = True
            lblError.Text = "Missing Title description"
            txtTitle.Focus()
        End If
        If cboBM.SelectedItem.Value = 0 And cboBM.Visible = True Then
            ErrorsFound = True
            lblError.Text = "Missing Name"
            cboBM.Focus()
        End If

    End Function

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        '1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
        '2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
        '3) In your server-side click event, do this:
        If Session("AccessType") = "R" Or Session("DirectorID") = 0 Then Exit Sub

        Dim btn As Button = CType(sender, Button)
        If lblDeleteBM.Text = "" Then btn.CommandArgument = "Confirm"
        If btn.CommandArgument = "Confirm" Then
            lblDeleteBM.Text = "*Click Delete button again to confirm.*"
            lblDeleteBM.Visible = True
            btn.CommandArgument = "Delete"
        ElseIf btn.CommandArgument = "Delete" Then
            If Session("DirectorID") > 0 Then
                Call DELRow(Session("DirectorID"))
                Call ClearFields()
                cboBM.SelectedValue = 0
                Session("DirectorID") = 0
                Call LoadList()
                Call LoadFlagged()
            End If
            lblDeleteBM.Text = ""
            lblDeleteBM.Visible = False
            btn.CommandArgument = "Confirm"
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.

    End Sub

    Private Sub ClearFields()
        cboBM.Visible = True
        txtTitle.Text = ""
        cobPhones.Items.Clear()
        lblEmail.Text = ""
        lblAddress.Text = ""
        lblCSZ.Text = ""
        lblName.Text = ""
        lblBoard.Visible = True
        lblPhone.Text = ""
        lblDeleteBM.Text = ""
        lblError.Text = ""
    End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub


    Protected Sub cboBM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBM.SelectedIndexChanged
        'Session("PeopleID") = cboBM.SelectedItem.Value
        Call LoadPeople(cboBM.SelectedItem.Value)
    End Sub

    Private Sub grdBM_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.CellEventArgs) Handles grdBM.ClickCellButton
        If Session("AccessType") = "R" Then Exit Sub
        Call Regroup(grdBM.DisplayLayout.ActiveRow.Cells.FromKey("Seq").Value)
    End Sub

    Private Sub Regroup(ByVal iSeq As Int16)
        Dim oDirectors As New Volunteers.ClsDirectors
        Try
            'oDirectors.updDirectorSeq(e.Cell.Row.Index + 1, Session("CompanyID"))
            oDirectors.updDirectorSeq(iSeq, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = "grdBM_ClickCellButton::" & ex.Message
        Finally
            oDirectors = Nothing
        End Try

        Call LoadList()
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call ClearFields()
        cboBM.SelectedValue = 0
        Session("DirectorID") = 0
    End Sub

    Protected Sub grdBM_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdBM.SelectedRowsChange
        Session("DirectorID") = grdBM.DisplayLayout.ActiveRow.Cells.FromKey("ID").Value
        Call LoadRow(Session("DirectorID"))
    End Sub
End Class


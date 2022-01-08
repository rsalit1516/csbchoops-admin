Imports System.Data
Imports System.Web
Imports System.Web.Mvc
Imports CSBC.Components
Imports CSBC.Core

Partial Class Households
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")
        If Session("CompanyID") Is Nothing Then
            Session("CompanyID") = 1
        End If
        If Session("CompanyID") = 0 Then
            Session("CompanyID") = 1

        End If

        If Page.IsPostBack = False Then
            Session("Title") = "Households"
            Session("CallingScreen") = "Households.aspx"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnComments.Visible = False
            End If
            Me.txtName.Focus()
            If Session("HouseID") = 0 Then
                Call ClearFields()
                Dim SearchType As String = Session("SearchType") + ""
                Select Case SearchType
                    Case "Name"
                        txtName.Text = Session("FirstLetter")
                    Case "Email"
                        txtEmail.Text = Session("FirstLetter")
                    Case "City"
                        txtCity.Text = Session("FirstLetter")
                    Case "Phone"
                        txtPhone.Text = Session("FirstLetter")
                    Case "Address1"
                        txtAddress.Text = Session("FirstLetter")
                End Select
            Else
                Call LoadRow(Session("HouseID"))
                Call LoadMembers(Session("HouseID"))
                Call LoadComments(Session("HouseID"))
            End If
        End If

    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New CSBC.Components.Security.ClsUsers()
        Try
            oSecurity.GetAccess(Session("UserID"), "Households", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Function AccessType_User() As String
        Dim oSecurity As New CSBC.Components.Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Users", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType_User = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadRow(ByVal RowID As Long)
        Dim oHousehold As New Models.Household
        Dim rep As New Models.HouseholdRepository(New CSBC.Core.Data.CSBCDbContext)
        Dim rsData As DataTable

        Try
            rsData = rep.GetRecords(RowID, Session("CompanyID"))
            Call ClearFields()
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    txtName.Text = rsData.Rows(0).Item("Name") + ""
                    txtAddress.Text = rsData.Rows(0).Item("Address1") + ""
                    txtAddress2.Text = rsData.Rows(0).Item("Address2") + ""
                    txtCity.Text = rsData.Rows(0).Item("CITY") + " "
                    txtState.Text = rsData.Rows(0).Item("STATE") + " "
                    txtZip.Text = rsData.Rows(0).Item("Zip") + " "
                    txtPhone.Text = rsData.Rows(0).Item("PHONE") + ""
                    txtEmail.Text = rsData.Rows(0).Item("Email") + ""
                    chkEmail.Checked = rsData.Rows(0).Item("EmailList")
                    hidEMail.Value = rsData.Rows(0).Item("Email") + ""
                    txtCityCard.Text = rsData.Rows(0).Item("SportsCard") + ""
                    lblUserName.Text = rsData.Rows(0).Item("UserName") + ""
                    If AccessType_User() = "U" Then lblUserName.ToolTip = rsData.Rows(0).Item("PWord") + ""
                    btnComments.Enabled = True
                    txtComments.Enabled = True
                End If
            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oHousehold = Nothing
            Session.Add("LinkName", txtName.Text)
        End Try
    End Sub

    Private Sub LoadMembers(ByVal RowID As Long)
        Dim oPeople As New CSBC.Components.Profile.ClsHouseholds
        Dim rsData As DataTable

        Try
            rsData = oPeople.LoadMembers(RowID, Session("CompanyID"))
            'grdMembers.Clear()
            grdMembers.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdMembers
                    .DataSource = rsData
                    .DataBind()
                    'grdMembers.Columns.Add("Remove", "")
                    With grdMembers.Columns
                        '.DisplayLayout.Bands(0).Columns()
                        .Item("PeopleId").Visible = False
                        .Item("Gender").ItemStyle.HorizontalAlign = HorizontalAlign.Center

                        .Item("Gender").HeaderText = "Gender"
                        .Item("Gender").ItemStyle.Width = 50
                        .Item("Name").ItemStyle.Width = 130
                        .Item("BirthDate").ItemStyle.Width = 70
                        '.Item("BirthDate").ControlStyle.ItemStyle..Format = "MM/dd/yyyy"
                        .Item("BirthDate").ItemStyle.HorizontalAlign = HorizontalAlign.Right
                        .Item("Remove").ItemStyle.Width = 80
                        '.Item("Remove").ItemStyle..NullText = "Remove"
                        '.Item("Remove").Type = Infragistics.WebUI.UltraWebGrid.ColumnType.Button
                        '.Item("Remove").CellStyle.HorizontalAlign = HorizontalAlign.Center
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadMembers::" & ex.Message
        Finally
            oPeople = Nothing
            Session.Add("LinkName", txtName.Text)
        End Try
    End Sub

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim household As New Models.Household
        Dim householdRepository As New Models.HouseholdRepository(New CSBC.Core.Data.CSBCDbContext)
        Try
            With household
                .Name = txtName.Text
                .Address1 = txtAddress.Text
                .Address2 = txtAddress2.Text
                .City = txtCity.Text
                .Email = txtEmail.Text
                .EmailList = chkEmail.Checked
                .SportsCard = txtCityCard.Text
                .State = txtState.Text
                .Zip = txtZip.Text
                .Phone = txtPhone.Text
                householdRepository.UpdRow(RowID, household, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            householdRepository = Nothing
        End Try
    End Sub

    Private Sub ClearFields()
        grdMembers.Controls.Clear()
        txtName.Text = ""
        txtAddress.Text = ""
        txtAddress2.Text = ""
        txtCity.Text = "CORAL SPRINGS"
        txtState.Text = "FL"
        txtZip.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
        chkEmail.Checked = False
        hidEMail.Value = ""
        txtCityCard.Text = ""
        txtComments.Enabled = False
        btnComments.Enabled = False
        Session("ErrorMsg") = ""
    End Sub

    Private Sub ADDRow()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oHouseholds As New CSBC.Components.Profile.ClsHouseholds
        Try
            With oHouseholds
                .Name = txtName.Text
                .Address1 = txtAddress.Text
                .Address2 = txtAddress2.Text
                .City = txtCity.Text
                .Email = txtEmail.Text
                If chkEmail.Checked Then
                    .EmailList = 1
                Else
                    .EmailList = 0
                End If
                .SportsCard = txtCityCard.Text
                .State = txtState.Text
                .Zip = txtZip.Text
                .Phone = txtPhone.Text
                .CreatedUser = Session("UserName")
                oHouseholds.UpdRow(0, Session("CompanyID"), Session("TimeZone"))
                Session("HouseID") = .HouseId
            End With
        Catch ex As Exception
            Session("ErrorMSG") = ex.Message
        Finally
            oHouseholds = Nothing
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        If Session("HouseID") > 0 Then
            UpdateHousehold()
        Else
            AddHouseholds()
        End If
    End Sub

    Private Sub UpdateHousehold()
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("ErrorMsg") = "" Then Call UpdRow(Session("HouseID"))
        'If Session("ErrorMsg") = "" Then Call UpdEmail(Session("HouseID"))
        If Session("ErrorMsg") = "" Then Call MsgBox("Changes successfully completed")
        lblError.Text = Session("ErrorMsg")
    End Sub

    Private Sub AddHouseholds()
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("ErrorMsg") = "" Then Call ADDRow()
        'If Session("ErrorMsg") = "" Then Call UpdEmail(Session("HouseID"))
        If Session("ErrorMsg") = "" Then Call MsgBox("New Record Added Successfully")
        lblError.Text = Session("ErrorMsg")
        btnComments.Enabled = True
        txtComments.Enabled = True
    End Sub

    Private Sub btnComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComments.Click
        If Session("HouseID") = 0 Then
            If errorRTN() = True Then
                Call MsgBox("ERROR: " & lblError.Text)
                Exit Sub
            End If
            Call ADDRow()
        End If

        If Session("HouseID") > 0 Then
            If errorRTN() = True Then
                Call MsgBox("ERROR: " & lblError.Text)
                Exit Sub
            End If
            Call UpdRow(Session("HouseID"))
            Session.Add("LinkID", Session("HouseID"))
            Session.Add("CommentType", "H")
            Session("CallingScreen") = "HouseHolds.aspx"
            Response.Redirect("Comments.aspx")
        End If
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        If txtName.Text = "" Then
            If Session("USERACCESS") = "R" Then
                lblError.Text = "Update Not allowed"
            Else
                lblError.Text = "Name missing "
            End If
            errorRTN = True
        End If
    End Function

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        'System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">" & vbCrLf)

        'System.Web.HttpContext.Current.Response.Write("alert(""" & Message & """)" & vbCrLf)

        'System.Web.HttpContext.Current.Response.Write("</SCRIPT>")


        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"

        Page.Controls.Add(strScript)

    End Sub

    Private Sub RemoveMember(ByVal PeopleID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oHousehold As New CSBC.Components.Profile.ClsHouseholds
        Try
            With oHousehold
                .HouseId = 0
                oHousehold.UpdMember(PeopleID, Session("CompanyID"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = ex.Message
        Finally
            oHousehold = Nothing
        End Try
    End Sub

    Private Sub LoadComments(ByVal HouseID As Long)
        Dim oComments As New Website.ClsComments
        Dim I As Integer
        Dim rsData As DataTable
        Try
            rsData = oComments.GetRecords(0, HouseID, Session("CompanyID"))
            txtComments.Text = ""
            If Not rsData Is Nothing Then
                For I = 0 To rsData.Rows.Count - 1
                    txtComments.Text = txtComments.Text & " " & rsData.Rows(I).Item("Comment") & vbCrLf
                Next
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oComments = Nothing
        End Try
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
            If Session("HouseID") > 0 Then
                Call DELRow(Session("HouseID"))
                'If Session("ErrorMsg") = "" Then Call DELComments(Session("HouseID"))
                'If Session("ErrorMsg") = "" Then Call DELUserPtn(Session("HouseID"))
                If Session("ErrorMsg") = "" Then Call RemoveMember(Session("HouseID"))
                'If Session("ErrorMsg") = "" Then Call DELEmail(Session("HouseID"))
                lblError.Text = Session("ErrorMsg")
                Call ClearFields()
                'grdMembers.Clear()
                grdMembers.Controls.Clear()
                'grdMembers.ResetBands()
                Session("HouseID") = 0
            End If
            lblDelete.Text = ""
            lblDelete.Visible = False
            btn.CommandArgument = "Confirm"
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.
    End Sub

    Private Sub DELRow(ByVal HouseID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oHouseholds As New CSBC.Components.Profile.ClsHouseholds
        Try
            oHouseholds.DELRow(HouseID, Session("CompanyID"))
        Catch ex As Exception
            Session("ErrorMsg") = ex.Message
        Finally
            oHouseholds = Nothing
        End Try
    End Sub

   

    'Private Sub imgAddress_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAddress.Click
    '    Session("FirstLetter") = txtAddress.Text
    '    Session("SearchType") = "Address1"
    '    Response.Redirect("SearchHouse.aspx")
    'End Sub

    'Private Sub imgPhone_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPhone.Click
    '    Session("FirstLetter") = Trim(txtPhone.Text)
    '    Session("SearchType") = "Phone"
    '    Response.Redirect("SearchHouse.aspx")
    'End Sub

    'Protected Sub imgEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgEmail.Click
    '    Session("FirstLetter") = txtEmail.Text
    '    Session("SearchType") = "Email"
    '    Response.Redirect("SearchHouse.aspx")
    'End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtName.Text > "" Then
            Session("PeopleID") = 0
            Session("FirstLetter") = txtName.Text
            Session("SearchType") = "LastName"
            Response.Redirect("People.aspx")
        End If
    End Sub

    'Protected Sub grdMembers_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.CellEventArgs) Handles grdMembers.ClickCellButton
    '    'Session("PeopleID") = grdMembers.DisplayLayout.ActiveRow.Cells(0).Text
    '    Session("PeopleID") = grdMembers.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
    '    If Session("PeopleID") > 0 Then
    '        Call RemoveMember(Session("PeopleID"))
    '        Call LoadMembers(Session("HouseID"))
    '    End If
    'End Sub

    'Protected Sub grdMembers_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdMembers.SelectedRowsChange
    '    Session("PeopleID") = grdMembers.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
    '    If Session("PeopleID") > 0 Then
    '        Session("HouseID") = 0
    '        Response.Redirect("People.aspx")
    '    End If
    'End Sub
End Class

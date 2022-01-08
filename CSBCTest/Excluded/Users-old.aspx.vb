Imports System.Data
Imports CSBC.Components
Partial Class users
    Inherits System.Web.UI.Page
    Private HouseHoldName As String
    Private HouseEmail As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Users"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnNew.Enabled = False
                btnDelete.Enabled = False
                txtPWord.Enabled = False
                txtPWord.TextMode = TextBoxMode.Password
            End If

            Me.txtName.Focus()
            Call LoadRoles(0)
            Call LoadList()
            If Session("CallingScreen") = "Users.aspx" Then
                Session("CallingScreen") = ""
                ReadHousehold(Session("HouseID"))
                lblHouseID.Text = Session("HouseID")
                lblEmail.Text = HouseEmail
                lblHouseHold.Text = HouseHoldName
                btnSave.Enabled = True
                If Session("UserRowID") > 0 Then
                    grdUsers.Rows(Session("GridIndex")).Selected = True
                    LoadRow(Session("UserRowID"))
                    For I As Int32 = 0 To lstRoles.Items.Count - 1
                        lstRoles.Items(I).Selected = False
                    Next
                    HilightRoles(Session("UserRowID"))
                End If
            End If
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Users", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadRow(ByVal RowID As Long)
        Dim oUser As New Security.ClsUsers
        Dim rsData As DataTable
        Try
            rsData = oUser.LoadUsers(RowID, Session("CompanyID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    lblID.Text = rsData.Rows(0).Item("UserID")
                    txtName.Text = rsData.Rows(0).Item("Name")
                    txtUserName.Text = rsData.Rows(0).Item("UserName")
                    Session("HouseID") = rsData.Rows(0).Item("HouseID")
                    txtPWord.Text = rsData.Rows(0).Item("PWord")
                    cboUserType.SelectedValue = rsData.Rows(0).Item("UserType")
                End If
            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oUser = Nothing
        End Try
    End Sub

    Private Sub ReadHousehold(ByVal RowID As Long)
        Dim oHouseholds As New Profile.ClsHouseholds
        Dim rsData As DataTable
        Try
            rsData = oHouseholds.GetRecords(RowID, Session("CompanyID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    HouseHoldName = rsData.Rows(0).Item("Name") & ""
                    HouseEmail = rsData.Rows(0).Item("email") & ""
                End If
            End If
        Catch ex As Exception
            lblError.Text = "ReadHousehold::" & ex.Message
        Finally
            oHouseholds = Nothing
        End Try
    End Sub

    Private Sub LoadList()
        Dim oUsers As New Security.ClsUsers
        Dim rsData As DataTable
        Try
            rsData = oUsers.LoadUsers(0, Session("CompanyID"), "UserID, Name")
            grdUsers.Clear()
            grdUsers.Columns.Clear()
            With grdUsers
                .DataSource = rsData
                .DataBind()
                With grdUsers.DisplayLayout.Bands(0).Columns
                    .FromKey("UserID").Hidden = True
                End With
            End With
        Catch ex As Exception
            lblError.Text = "LoadList::" & ex.Message
        Finally
            oUsers = Nothing
        End Try
    End Sub

    Private Sub LoadRoles(ByVal ID As Int32)
        Dim oUsers As New Security.ClsUsers
        Dim rsData As DataTable
        Try
            rsData = oUsers.LoadRoles(ID, Session("CompanyID"))
            If rsData.Rows.Count > 0 Then
                lstRoles.Items.Clear()
                '   |||||   Set the DataValueField to the Primary Key
                'lstRoles.DataValueField = "ProductID"
                '   |||||   Set the DataTextField to the text/data you want to display
                lstRoles.DataTextField = "ScreenName"
                '   |||||   Set the DataSource the the OleDBDataReader's result
                lstRoles.DataSource = rsData
                '   |||||   Bind the Source Data to the Web/Server Control
                lstRoles.DataBind()

            End If
        Catch ex As Exception
            lblError.Text = "LoadRoles::" & ex.Message
        Finally
            oUsers = Nothing
        End Try
    End Sub

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oUsers As New Security.ClsUsers
        Try
            With oUsers
                .HouseID = lblHouseID.Text
                .Name = txtName.Text
                .UserName = txtuserName.text
                .Usertype = cboUserType.SelectedValue
                .PWord = txtPWord.Text
                .CreatedUser = Session("UserName")
                .Roles = getRoles
                .UpdRow(RowID, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            oUsers = Nothing
        End Try
    End Sub

    Private Function GetRoles() As String
        Dim sRoles As String = ""
        Try
            For I As Int32 = 0 To lstRoles.Items.Count - 1
                If lstRoles.Items(I).Selected = True Then
                    If sRoles > "" Then sRoles = sRoles & ", "
                    sRoles = sRoles & lstRoles.Items(I).Text
                End If
            Next

        Catch ex As Exception
            lblError.Text = "GetRoles::" & ex.Message
        End Try
        GetRoles = sRoles
    End Function

    Private Sub ClearFields()
        grdUsers.Controls.Clear()
        For I As Int32 = 0 To lstRoles.Items.Count - 1
            lstRoles.Items(I).Selected = False
        Next
        txtName.Text = ""
        txtName.Focus()
        txtUserName.Text = ""
        lblHouseHold.Text = ""
        lblHouseID.Text = ""
        cboUserType.SelectedValue = 0
        txtPWord.Text = ""
        lblEmail.Text = ""
        Session("ErrorMsg") = ""
        Session("UserRowID") = 0
    End Sub

    Private Sub ADDRow()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oUsers As New Security.ClsUsers
        Try
            With oUsers
                .HouseID = lblHouseID.Text
                .Name = txtName.Text
                .UserName = txtUserName.Text
                .Usertype = cboUserType.SelectedValue
                .PWord = txtPWord.Text
                .CreatedUser = Session("UserName")
                .Roles = GetRoles()
                .UpdRow(0, Session("CompanyID"), Session("TimeZone"))
                Session("UserRowID") = .UserID
            End With
        Catch ex As Exception
            Session("ErrorMSG") = ex.Message
        Finally
            oUsers = Nothing
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        If Session("UserRowID") > 0 Then
            UpdateUser()
        Else
            AddUser()
        End If
        LoadList()
        If lblError.Text = "" Then
            For I As Int32 = 0 To lstRoles.Items.Count - 1
                lstRoles.Items(I).Selected = False
            Next
            HilightRoles(Session("UserRowID"))
        End If
    End Sub

    Private Sub UpdateUser()
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("ErrorMsg") = "" Then Call UpdRow(Session("UserRowID"))
        If Session("ErrorMsg") = "" Then Call MsgBox("Changes successfully completed")
        lblError.Text = Session("ErrorMsg")
    End Sub

    Private Sub AddUser()
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("ErrorMsg") = "" Then Call ADDRow()
        If Session("ErrorMsg") = "" Then Call MsgBox("New Record Added Successfully")
        lblError.Text = Session("ErrorMsg")
    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = True
        If txtName.Text = "" Then
            lblError.Text = "Name missing "
            txtName.Focus()
            Exit Function
        End If
        If lblHouseHold.Text = "" Then
            lblError.Text = "Household missing "
            Exit Function
        End If
        If lblEmail.Text = "" Then
            lblError.Text = "Email missing "
            Exit Function
        End If
        If txtPWord.Text = "" Then
            lblError.Text = "Password missing "
            txtPWord.Focus()
            Exit Function
        End If
        Dim username As String = CheckHouseHold(lblHouseID.Text)
        If username > " " Then
            lblError.Text = "Household Already has Username (" & username & ")"
            txtPWord.Focus()
            Exit Function
        End If
        errorRTN = False
    End Function

    Private Function CheckHouseHold(ByVal iHouseID As Int32) As String
        CheckHouseHold = ""
        Dim oUser As New Security.ClsUsers
        Try
            oUser.GetUserByHousehold(iHouseID, Session("UserRowID"), Session("CompanyID"))
            CheckHouseHold = oUser.UserName
        Catch ex As Exception
            lblError.Text = "CheckHouseHold::" & ex.Message
        Finally
            oUser = Nothing
        End Try
    End Function

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Protected Sub grdUsers_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdUsers.SelectedRowsChange
        Session("UserRowID") = grdUsers.DisplayLayout.ActiveRow.Cells.FromKey("UserID").Value
        Session("GridIndex") = grdUsers.DisplayLayout.ActiveRow.Index
        lblError.Text = ""
        If Session("UserRowID") > 0 Then
            LoadRow(Session("UserRowID"))

            ReadHousehold(Session("HouseID"))
            lblHouseHold.Text = HouseHoldName
            lblEmail.Text = HouseEmail
            lblHouseID.Text = Session("HouseID")

            For I As Int32 = 0 To lstRoles.Items.Count - 1
                lstRoles.Items(I).Selected = False
            Next
            HilightRoles(Session("UserRowID"))
            btnSave.Enabled = True
            btnDelete.Enabled = True
        End If
        If Session("AccessType") = "R" Then
            btnSave.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call ClearFields()
        Session("UserRowID") = 0
        txtName.Focus()
        btnSave.Enabled = True
    End Sub

    Private Sub HilightRoles(ByVal ID As Int32)
        Dim oUsers As New Security.ClsUsers
        Dim rsData As DataTable
        Try
            rsData = oUsers.LoadRoles(ID, Session("CompanyID"))

            For II As Int32 = 0 To rsData.Rows.Count - 1
                For I As Int32 = 0 To lstRoles.Items.Count - 1
                    If rsData.Rows(II).Item(0).ToString = lstRoles.Items(I).Text Then
                        lstRoles.Items(I).Selected = True
                    End If
                Next
            Next

        Catch ex As Exception
            lblError.Text = "HilightRoles::" & ex.Message
        Finally
            oUsers = Nothing
        End Try
    End Sub

    Protected Sub imgName_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgName.Click
        Session("FirstLetter") = lblHouseHold.Text
        Session("SearchType") = "Name"
        Session("CallingScreen") = "Users.aspx"
        Response.Redirect("SearchHouse.aspx")
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        '1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
        '2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
        '3) In your server-side click event, do this:
        If Session("AccessType") = "R" Or Session("UserRowID") = 0 Then Exit Sub

        Dim btn As Button = CType(sender, Button)
        If lblDeleteUser.Text = "" Then btn.CommandArgument = "Confirm"
        If btn.CommandArgument = "Confirm" Then
            lblDeleteUser.Text = "*Click Delete button again to confirm.*"
            lblDeleteUser.Visible = True
            btn.CommandArgument = "Delete"
        ElseIf btn.CommandArgument = "Delete" Then
            If Session("UserRowID") > 0 Then
                Call DELRow(Session("UserRowID"))
                Call ClearFields()
                Session("UserRowID") = 0
                Call LoadList()
            End If
            lblDeleteUser.Text = ""
            lblDeleteUser.Visible = False
            btn.CommandArgument = "Confirm"
        End If
        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.
    End Sub

    Private Sub DELRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oUsers As New Security.ClsUsers
        Try
            oUsers.DELRow(RowID, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = "DELRow::" & ex.Message
        Finally
            oUsers = Nothing
        End Try

    End Sub
End Class

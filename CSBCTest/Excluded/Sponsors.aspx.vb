Imports System.Data 'DataTable
Imports CSBC.Components
Partial Class Sponsors
    Inherits System.Web.UI.Page
    Private sSQL As String
    'Private CNString As String = System.Configuration.ConfigurationSettings.AppSettings("MyCN")
    'Private SqlCn = New System.Data.SqlClient.SqlConnection


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If Len(Session("CurrentPage")) = 0 Or Session("CurrentPage") = "Sponsors.aspx" Then
        'Else
        '    Response.Redirect(Session("CurrentPage"))
        '    Response.End()
        'End If

        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Sponsors"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
                lnkComments.Enabled = False
                btnPayments.Enabled = False
            End If
            Me.txtSponsorName.Focus()
            Call LoadPlayers()
            Call LoadSponsors()
            Call LoadColors()
            Call LoadFees()
            If Session("FirstLetter") > "" And Session("SponsorID") = 0 Then
                'Call ClearFields()
                If Session("SponsorProfileID") = 0 Then
                    txtSponsorName.Text = Session("FirstLetter")
                Else
                    Call LoadProfile(Session("SponsorProfileID"))
                End If
                btnPayments.Enabled = False
                lnkComments.Enabled = False
            Else
                If Session("SponsorID") = 0 Then
                    Call ClearFields()
                    txtComments.Enabled = False
                    lnkComments.Enabled = False
                    btnPayments.Enabled = False
                Else
                    Call LoadRow(Session("SponsorID"))
                    Call LoadComments(Session("SponsorID"))
                End If
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

    Private Sub LoadList()
        'SqlCn.Open()
        'sSQL = "SELECT SponsorID, SpoName, Phone, Address"
        'sSQL = sSQL + " FROM Sponsors WHERE SeasonID = " & Session("SeasonID")
        'sSQL = sSQL + " order by Sponame, Address"

        'sSQL = "SELECT S.SponsorID, P.spoName FROM Sponsors S join sponsorProfile P On S.SponsorProfileID = P.SponsorProfileID  "
        'sSQL += " WHERE S.SeasonID= " &  
        'sSQL += " and S.CompanyID =  @CompanyID "
        'sSQL += " AND (S.SponsorID = @SponsorID or @SponsorID = 0)"
        'sSQL += "Order by P.SpoName"
        'Try
        '    Dim selectCMD As SqlCommand = New SqlCommand(sSQL, SqlCn)
        '    rdr = selectCMD.ExecuteReader
        '    With grdSponsors
        '        .DataSource = rdr
        '        .DataBind()
        '    End With

        '    rdr.Close()
        'Catch ex As Exception
        '    Response.Write(ex.Message)
        '    Response.End()
        'Finally
        '    If SqlCn.State = ConnectionState.Open Then
        '        SqlCn.Close()
        '    End If
        'End Try
    End Sub

    Private Sub LoadSponsors()
        Dim oSponsors As New Season.clsSponsors
        Dim rsData As DataTable
        Try
            rsData = oSponsors.LoadSeasonSponsors(0, Session("CompanyID"), Session("SeasonID"), 0, 0, "SponsorID, SpoName, SponsorProfileID")
            grdSponsors.Clear()
            grdSponsors.Columns.Clear()
            With grdSponsors
                .DataSource = rsData
                .DataBind()
            End With
            With grdSponsors.DisplayLayout.Bands(0).Columns
                .FromKey("SponsorID").Hidden = True
                .FromKey("SponsorProfileID").Hidden = True
                .FromKey("SpoName").Header.Caption = "Sponsor's Name"
            End With
            'End If
        Catch ex As Exception
            lblError.Text = "LoadSponsors::" & ex.Message
        Finally
            oSponsors = Nothing
        End Try
    End Sub

    Private Sub LoadProfile(ByVal SponsorProfileID As Long)
        Dim oSponsors As New Season.clsSponsors
        Dim rsData As DataTable
        Try
            rsData = oSponsors.LoadAllSponsors(SponsorProfileID, Session("CompanyID"))
            If rsData.Rows.Count > 0 Then
                txtSponsorName.Text = rsData.Rows(0).Item("SpoName") & ""
                Session("SponsorProfileID") = rsData.Rows(0).Item("SponsorProfileID") & ""
                txtContact.Text = rsData.Rows(0).Item("ContactName") & ""
                txtAddress.Text = rsData.Rows(0).Item("Address") & ""
                txtCity.Text = rsData.Rows(0).Item("City") + ""
                txtState.Text = rsData.Rows(0).Item("state") + ""
                txtZip.Text = rsData.Rows(0).Item("Zip") + ""
                txtPhone.Text = rsData.Rows(0).Item("Phone") & ""
                txtWebsite.Text = rsData.Rows(0).Item("URL") & ""
                txtEmail.Text = rsData.Rows(0).Item("Email") & ""
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

    Private Sub LoadRow(ByVal SponsorID As Long)
        Dim oSponsors As New Season.clsSponsors
        Dim rsData As DataTable
        Try
            rsData = oSponsors.LoadSeasonSponsors(SponsorID, Session("CompanyID"), Session("SeasonID"))
            If rsData.Rows.Count > 0 Then
                txtSponsorName.Text = rsData.Rows(0).Item("SpoName") & ""
                Session("SponsorProfileID") = rsData.Rows(0).Item("SponsorProfileID") & ""
                txtUniformName.Text = rsData.Rows(0).Item("ShirtName") & ""
                txtContact.Text = rsData.Rows(0).Item("ContactName") & ""
                txtAddress.Text = rsData.Rows(0).Item("Address") & ""
                txtCity.Text = rsData.Rows(0).Item("City") + ""
                txtState.Text = rsData.Rows(0).Item("state") + ""
                txtZip.Text = rsData.Rows(0).Item("Zip") + ""
                txtPhone.Text = rsData.Rows(0).Item("Phone") & ""
                txtWebsite.Text = rsData.Rows(0).Item("URL") & ""
                txtEmail.Text = rsData.Rows(0).Item("Email") & ""
                lblBalance.Text = Format(rsData.Rows(0).Item("Balance"), "currency")
                If rsData.Rows(0).Item("Balance") > 0 Then lblBalance.ForeColor = Drawing.Color.Red
                If rsData.Rows(0).Item("Balance") = 0 Then lblBalance.ForeColor = Drawing.Color.Black
                If rsData.Rows(0).Item("Balance") < 0 Then lblBalance.ForeColor = Drawing.Color.DarkGreen
                cmbColors.SelectedValue = rsData.Rows(0).Item("Color1ID")
                cmbColors2.SelectedValue = rsData.Rows(0).Item("Color2ID")
                cmbSizes.SelectedValue = rsData.Rows(0).Item("ShirtSize")
                cmbFees.SelectedValue = Format(rsData.Rows(0).Item("FeeID"), "##0.00")
            End If

            'If IsNumeric(rsData.Rows(0).Item("SponsorID")) Then
            '    Session("SponsorID") = rsData.Rows(0).Item("SponsorID")
            'End If

            lnkComments.Enabled = True
            txtComments.Enabled = True
            btnPayments.Enabled = True

        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oSponsors = Nothing
            Session.Add("LinkName", txtSponsorName.Text)
        End Try

        Call getKids(SponsorID)
    End Sub

    Private Sub getKids(ByVal SponsorID As Long)
        Dim oPlayers As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPlayers.GetSponsorKids(Session("SeasonID"), SponsorID, Session("CompanyID"), False, "PeopleID, PlayerID, LastName + ', ' + FirstName as Name")
            grdKids.Clear()
            grdKids.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdKids
                    .DataSource = rsData
                    .DataBind()
                End With
                grdKids.Columns.Add("Remove", "")
                With grdKids.DisplayLayout.Bands(0).Columns
                    .FromKey("PeopleID").Hidden = True
                    .FromKey("PlayerID").Hidden = True
                    .FromKey("Name").Width = 130
                    .FromKey("Remove").Width = 80
                    .FromKey("Remove").NullText = "Remove"
                    .FromKey("Remove").Type = Infragistics.WebUI.UltraWebGrid.ColumnType.Button
                    .FromKey("Remove").CellStyle.HorizontalAlign = HorizontalAlign.Center
                End With
            End If
        Catch ex As Exception
            lblError.Text = "getKids::" & ex.Message
        Finally
            oPlayers = Nothing
        End Try
    End Sub

    Private Sub LoadPlayers()
        Dim oPlayers As New Season.ClsPlayers
        Dim rsData As DataTable
        'Dim dRow As DataRow

        Try
            rsData = oPlayers.GetSponsorKids(Session("SeasonID"), Session("SponsorID"), Session("CompanyID"), True, "PeopleID, PlayerID, (LastName + ', ' + FirstName) as Name")
            grdPlayers.Clear()
            grdPlayers.Columns.Clear()

            'dRow = rsData.NewRow
            'dRow.Item("PlayerID") = 0
            'dRow.Item("Name") = "Any Player"
            'dRow.Item("PeopleID") = 0
            'rsData.Rows.Add(dRow)

            If rsData.Rows.Count > 0 Then
                With grdPlayers
                    .DataSource = rsData
                    .DataBind()
                    With grdPlayers.DisplayLayout.Bands(0).Columns
                        .FromKey("PlayerID").Hidden = True
                        .FromKey("Name").Width = 250
                        .FromKey("Name").Header.Caption = "Player's Name"
                        .FromKey("PeopleID").Hidden = True
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadPlayers::" & ex.Message
        Finally
            oPlayers = Nothing
        End Try
    End Sub

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
            If Session("SponsorID") > 0 Then
                Call DELRow(Session("SponsorID"))
                Call ClearFields()
                Session("SponsorID") = 0
                Call LoadSponsors()
                Call LoadPlayers()
                grdKids.Controls.Clear()
            End If
            lblDelete.Text = ""
            lblDelete.Visible = False
            btn.CommandArgument = "Confirm"
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.

    End Sub

    Private Sub ClearFields()
        txtSponsorName.Text = ""
        Session("SponsorProfileID") = 0
        txtContact.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtState.Text = "FL"
        txtZip.Text = ""
        txtPhone.Text = ""
        txtUniformName.Text = ""
        cmbColors.SelectedValue = 0
        cmbColors2.SelectedValue = 0
        cmbSizes.SelectedValue = 0
        cmbFees.SelectedIndex = 2
        cmbSizes.SelectedValue = "LARGE"
        txtEmail.Text = ""
        txtWebsite.Text = ""
        lblBalance.Text = ""
        lblBalance.ForeColor = Drawing.Color.Black

        txtComments.Text = ""
        txtComments.Enabled = False
        lnkComments.Enabled = False
        btnPayments.Enabled = False
        'grdKids.Clear()
        'grdKids.Columns.Clear()

    End Sub

    Private Sub DELRow(ByVal iSponsorID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oSponsor As New Season.clsSponsors
        Try
            oSponsor.DELRow(iSponsorID, Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            Session("ErrorMSG") = "DELRow::" & ex.Message
        Finally
            oSponsor = Nothing
        End Try

    End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Private Sub LoadComments(ByVal RowID As Long)
        Dim oComments As New Website.ClsComments
        Dim rsData As DataTable
        txtComments.Text = ""
        Try
            rsData = oComments.GetRecords(0, Session("SponsorProfileID"), "S", Session("CompanyID"))
            If Not rsData Is Nothing Then
                For I As Integer = 0 To rsData.Rows.Count - 1
                    txtComments.Text = txtComments.Text & " " & rsData.Rows(I).Item("Comment") & vbCrLf
                Next
            End If
        Catch ex As Exception
            lblError.Text = "LoadComments::" & ex.Message
        Finally
            oComments = Nothing
        End Try

    End Sub

    Protected Sub grdSponsors_Click(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdSponsors.Click
        Session("SponsorID") = grdSponsors.DisplayLayout.ActiveRow.Cells.FromKey("SponsorID").Value()
        Session("SponsorProfileID") = grdSponsors.DisplayLayout.ActiveRow.Cells.FromKey("SponsorProfileID").Value()
        Call LoadRow(Session("SponsorID"))
        Call LoadComments(Session("SponsorID"))
    End Sub

    Protected Sub grdPlayers_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdPlayers.DblClick
        If Session("SponsorID") > 0 Then
            Session("PlayerID") = grdPlayers.DisplayLayout.ActiveRow.Cells.FromKey("PlayerID").Value()
            Call UpdPlayer(Session("SponsorID"), Session("PlayerID"))
            If Session("ErrorMSG") > "" Then
                lblError.Text = Session("ErrorMSG")
                Exit Sub
            End If
            Call LoadPlayers()
            Call LoadRow(Session("SponsorID"))
            Call getKids(Session("SponsorID"))
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        If Session("SponsorID") > 0 Then
            If errorRTN() = True Then
                Call MsgBox("Error: " & Session("ErrorMSG"))
                Exit Sub
            End If
            If Session("ErrorMSG") = "" Then Call UpdRow(Session("SponsorID"))
            If Session("ErrorMsg") = "" Then Call MsgBox(txtSponsorName.Text & " Changes successfully completed")
            lblError.Text = Session("ErrorMsg")
            txtSponsorName.Focus()
        Else
            If errorRTN() = True Then
                Call MsgBox("ERROR: " & lblError.Text)
                Exit Sub
            End If

            If Session("ErrorMsg") = "" Then Call UpdRow(0)
            If Session("ErrorMSG") = "" Then Call MsgBox(txtSponsorName.Text & " New Record Added Successfully")
            'If Session("ErrorMsg") = "" Then Call ClearFields()
            lblError.Text = Session("ErrorMsg")
            txtSponsorName.Focus()
            'Session("SponsorID") = 0
            'Session("SponsorSponsorID") = 0
            Call LoadSponsors()
        End If
    End Sub

    Protected Sub grdKids_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdKids.SelectedRowsChange
        Session("PeopleID") = grdKids.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
        If Session("PeopleID") > 0 Then
            Session("SponsorID") = 0
            Session("PlayerID") = 0
            Response.Redirect("Payments.aspx")
        End If
    End Sub

    Protected Sub grdKids_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.CellEventArgs) Handles grdKids.ClickCellButton
        Session("PlayerID") = grdKids.DisplayLayout.ActiveRow.Cells.FromKey("PlayerID").Value
        If Session("PlayerID") > 0 Then
            Call UpdPlayer(0, Session("PlayerID"))
            Call LoadRow(Session("SponsorID"))
            Call LoadPlayers()
            Call getKids(Session("SponsorID"))
        End If
    End Sub

    Private Sub UpdPlayer(ByVal SponsorID As Long, ByVal PlayerID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oPlayers As New Season.ClsPlayers
        Try
            With oPlayers
                .SponsorID = SponsorID
                oPlayers.UPDSponsor(Session("CompanyID"), Session("SeasonID"), PlayerID)
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdPlayer::" & ex.Message
        Finally
            oPlayers = Nothing
        End Try
    End Sub

    Private Sub UpdRow(ByVal RowID As Long)

        If Session("AccessType") = "R" Then Exit Sub
        Dim oSponsors As New Season.clsSponsors
        Try
            With oSponsors
                .HouseId = Session("HouseID")
                .SeasonId = Session("SeasonId")
                .SpoName = txtSponsorName.Text
                .SponsorProfileId = Session("SponsorProfileID")
                .ContactName = txtContact.Text
                .Address = txtAddress.Text
                .City = txtCity.Text
                .State = txtState.Text
                .Zip = txtZip.Text
                .URL = txtWebsite.Text
                .ShirtName = txtUniformName.Text
                .Email = txtEmail.Text
                .Phone = txtPhone.Text
                .SeasonId = Session("SeasonID")
                .Color1ID = cmbColors.SelectedItem.Value
                .Color2ID = cmbColors2.SelectedItem.Value
                .ShirtSize = cmbSizes.SelectedItem.Text
                .SeasonFee = cmbFees.SelectedItem.Text
                .CreatedUser = Session("UserID")
                oSponsors.UpdRow(RowID, Session("CompanyID"), Session("TimeZone"))
                Session("SponsorID") = .SponsorId
                Session("SponsorProfileID") = .SponsorProfileId
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            oSponsors = Nothing
        End Try
    End Sub

    Private Sub lnkComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkComments.Click
        If Session("SponsorProfileID") = 0 Then
            If errorRTN() = False Then Call UpdRow(0)
        End If
        If Session("SponsorProfileID") > 0 Then
            If errorRTN() = False Then Call UpdRow(Session("SponsorProfileID"))
            Session("CallingScreen") = "Sponsors.aspx"
            Session.Add("LinkID", Session("SponsorProfileID"))
            Session.Add("CommentType", "S")
            Session("Title") = "Comments"
            Response.Redirect("Comments.aspx")
        End If

    End Sub

    Private Function errorRTN() As Boolean
        errorRTN = False
        If txtSponsorName.Text = "" Then
            lblError.Text = "Name missing"
            txtSponsorName.Focus()
            errorRTN = True
        ElseIf txtEmail.Text > "" And IsEmail(txtEmail.Text) = False Then
            lblError.Text = "Invalid Email format"
            txtEmail.Focus()
            errorRTN = True
            'ElseIf Not IsDate(mskBirthDate.Text) And chkParentPlayer.Items(2).Selected() = True Then
            '    lblError.Text = "BirthDate Missing "
            '    mskBirthDate.Focus()
            '    errorRTN = True
            'ElseIf radGender.Items(0).Selected = False And radGender.Items(1).Selected = False Then
            '    lblError.Text = "Gender Missing "
            '    radGender.Focus()
            '    errorRTN = True
            'ElseIf chkParentPlayer.Items(0).Selected = False And chkParentPlayer.Items(1).Selected = False And chkParentPlayer.Items(2).Selected = False Then
            '    lblError.Text = "Parent, Coach or Player not selected"
            '    chkParentPlayer.Focus()
            '    errorRTN = True
        End If
    End Function

    Private Function IsEmail(ByVal Email As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(Email, pattern)
        If emailAddressMatch.Success Then
            IsEmail = True
        Else
            IsEmail = False
        End If
    End Function

    Protected Sub imgSponsors_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSponsors.Click
        Session("FirstLetter") = txtSponsorName.Text
        Session("SponsorID") = 0
        Response.Redirect("SearchSponsor.aspx")
    End Sub

    Protected Sub btnPayments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPayments.Click
        If Session("SponsorID") > 0 Then
            If errorRTN() = False Then
                Call UpdRow(Session("SponsorID"))
            Else
                Exit Sub
            End If
        Else
            If errorRTN() = False Then
                Call UpdRow(0)
            Else
                Exit Sub
            End If
        End If
        Response.Cache.SetExpires(DateTime.Now)
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Redirect("Accounting.aspx")
    End Sub

    Protected Sub grdKids_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdKids.DblClick
        Session("PeopleID") = grdKids.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
        Response.Redirect("People.aspx")
    End Sub

    Private Sub LoadColors()
        Dim oColors As New Website.ClsColors
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            rsData = oColors.LoadColors(0, Session("CompanyID"))
            dRow = rsData.NewRow
            dRow("ID") = 0
            If rsData.Rows.Count = 0 Then
                dRow("ColorName") = "NO Color"
            Else
                dRow("ColorName") = " "
                rsData.Rows.InsertAt(dRow, 0)
            End If
            With cmbColors
                .DataSource = rsData
                .DataValueField = "ID"
                .DataTextField = "ColorName"
                .DataBind()
            End With
            With cmbColors2
                .DataSource = rsData
                .DataValueField = "ID"
                .DataTextField = "ColorName"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadColors::" & ex.Message
        Finally
            oColors = Nothing
        End Try
    End Sub

    Private Sub LoadFees()
        Dim oSeasons As New Season.ClsSeasons
        Dim rsData As DataTable
        Try
            rsData = oSeasons.GetSeasonFees(Session("SeasonID"), Session("CompanyID"))
            If rsData.Rows.Count = 0 Then Exit Sub

            With cmbFees
                .DataSource = rsData
                .DataValueField = "Fee"
                .DataTextField = "Fee"
                .DataBind()
                .SelectedIndex = 2
            End With
        Catch ex As Exception
            lblError.Text = "LoadFees::" & ex.Message
        Finally
            oSeasons = Nothing
        End Try
    End Sub

    Protected Sub lnkPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrint.Click
        Response.Redirect("report.aspx?Report=Sponsors.rpt&amp;Type=pdf")
    End Sub

    Protected Sub grdPlayers_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles grdPlayers.InitializeLayout

    End Sub
End Class


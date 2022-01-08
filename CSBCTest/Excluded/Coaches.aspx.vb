Imports System.Data
Imports CSBC.Components
Partial Class Coaches
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Coaches"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
            End If
            'Me.txtName.Focus()
            Call LoadVolunteers()
            Call LoadPlayers()
            Call LoadCoaches()
            If Session("CoachID") = 0 Then
                Call ClearFields()
                txtComments.Enabled = False
                lnkComments.Enabled = False
            Else
                Call LoadRow(Session("CoachID"))
                Call LoadComments(Session("CoachID"))
            End If
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Coaches", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadCoaches()
        Dim oCoaches As New Season.clsCoaches
        Dim rsData As DataTable
        Try
            rsData = oCoaches.LoadCoaches(0, Session("CompanyID"), Session("SeasonID"))
            grdCoaches.Clear()
            grdCoaches.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdCoaches
                    .DataSource = rsData
                    .DataBind()
                End With
                With grdCoaches.DisplayLayout.Bands(0).Columns
                    .FromKey("CoachID").Hidden = True
                    .FromKey("Name").Width = 120
                    .FromKey("CoachPhone").Width = 80
                    .FromKey("CoachPhone").HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadCoaches::" & ex.Message
        Finally
            oCoaches = Nothing
        End Try
    End Sub

    Private Sub LoadRow(ByVal CoachID As Long)
        Dim oCoaches As New Season.clsCoaches
        Dim rsData As DataTable
        Try
            rsData = oCoaches.LoadCoaches(CoachID, Session("CompanyID"), Session("SeasonID"))
            If rsData.Rows.Count > 0 Then
                lnkName.Text = rsData.Rows(0).Item("Name") & ""
                lblAddress.Text = rsData.Rows(0).Item("Address1") & ""
                lblCSZ.Text = rsData.Rows(0).Item("City") + "  " + rsData.Rows(0).Item("state") + "  " + rsData.Rows(0).Item("Zip")
                lblPhone.Text = rsData.Rows(0).Item("HousePhone") & ""
                txtCoachPhone.Text = rsData.Rows(0).Item("CoachPhone") & ""
                If IsDBNull(rsData.Rows(0).Item("ShirtSize")) Then
                    cmbSizes.SelectedValue = "N/A"
                Else
                    cmbSizes.SelectedValue = rsData.Rows(0).Item("ShirtSize") & ""
                End If

                If IsNumeric(rsData.Rows(0).Item("PeopleID")) Then
                    Session("PeopleID") = rsData.Rows(0).Item("PeopleID")
                End If

                lnkComments.Enabled = True
                txtComments.Enabled = True

            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oCoaches = Nothing
        End Try

        Call getKids(CoachID)
        cmbCoaches.Visible = False
        pnlCoach.Visible = True
    End Sub

    Private Sub getKids(ByVal CoachID As Long)
        Dim oPlayers As New Season.ClsPlayers
        Dim rsData As DataTable
        Try
            rsData = oPlayers.GetCoachKids(Session("SeasonID"), CoachID, Session("CompanyID"))
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
        'PeopleID, Players.PlayerID, (People.LastName + ', ' + People.FirstName) as Name
    End Sub

    Private Sub LoadPlayers()
        Dim oPlayers As New Season.ClsPlayers
        Dim rsData As DataTable

        Try
            rsData = oPlayers.GetPlayer(0, Session("CompanyID"), Session("SeasonID"))
            grdPlayers.Clear()
            grdPlayers.Columns.Clear()
            If rsData.Rows.Count > 0 Then
                With grdPlayers
                    .DataSource = rsData
                    .DataBind()
                    With grdPlayers.DisplayLayout.Bands(0).Columns
                        .FromKey("PlayerID").Hidden = True
                        .FromKey("Name").Width = 250
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadPlayers::" & ex.Message
        Finally
            oPlayers = Nothing
        End Try
    End Sub

    Private Sub LoadVolunteers()
        Dim oCoaches As New Season.clsCoaches
        Dim rsData As DataTable
        Dim dRow As DataRow
        Try
            rsData = oCoaches.LoadCoachesVolunteers(Session("CompanyID"), 0)
            dRow = rsData.NewRow
            dRow("PeopleID") = 0
            dRow("ParentName") = " "
            rsData.Rows.InsertAt(dRow, 0)
            With cmbCoaches
                .DataSource = rsData
                .DataValueField = "PeopleID"
                .DataTextField = "ParentName"
                .DataBind()
            End With
        Catch ex As Exception
            lblError.Text = "LoadVolunteers::" & ex.Message
        Finally
            oCoaches = Nothing
        End Try

    End Sub

    Private Sub ADDRow()
        If Session("USERACCESS") = "R" Then Exit Sub

        Dim oCoaches As New Season.clsCoaches
        Try
            With oCoaches
                .ShirtSize = cmbSizes.Text
                .SeasonID = Session("SeasonID")
                .PeopleID = cmbCoaches.SelectedValue
                If txtCoachPhone.RawText > "" Then
                    .CoachPhone = txtCoachPhone.Text
                Else
                    .CoachPhone = ""
                End If
                .CreatedUser = Session("UserName")
                oCoaches.AddNewCoach()
                Session("CoachID") = .CoachID
            End With
        Catch ex As Exception
            Session("ErrorMSG") = ex.Message
        Finally
            oCoaches = Nothing
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
            If Session("CoachID") > 0 Then
                Call DELRow(Session("CoachID"))
                Call ClearFields()
                Session("CoachID") = 0
                Call LoadCoaches()
                Call LoadVolunteers()
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
        cmbCoaches.Visible = True
        pnlCoach.Visible = False
        txtComments.Text = ""
        txtCoachPhone.Text = ""
        txtComments.Enabled = False
        lnkComments.Enabled = False
        cmbCoaches.SelectedValue = "0"
        cmbSizes.SelectedValue = "N/A"
        'grdKids.Controls.Clear()
        grdKids.Clear()
        grdKids.Columns.Clear()

        'cobPlayers.SelectedValue = "0"
        'cobPlayers2.SelectedValue = "0"
    End Sub

    Private Sub DELRow(ByVal iCoachID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oCoach As New Season.clsCoaches
        Try
            oCoach.DELRow(iCoachID, Session("CompanyID"))
        Catch ex As Exception
            Session("ErrorMSG") = "DELRow::" & ex.Message
        Finally
            oCoach = Nothing
        End Try

    End Sub

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oCoach As New Season.clsCoaches
        Try
            oCoach.SeasonID = Session("SeasonID")
            oCoach.PeopleID = Session("PeopleID")
            oCoach.ShirtSize = cmbSizes.Text
            If txtCoachPhone.RawText > "" Then
                oCoach.CoachPhone = txtCoachPhone.Text
            Else
                oCoach.CoachPhone = ""
            End If
            'oCoach.UPDCoach(Session("CompanyID"), RowID) Add routine!!!!!
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            oCoach = Nothing
        End Try

    End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label

        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Private Sub LoadComments(ByVal CoachID As Long)
        Dim oComments As New Website.ClsComments
        Dim rsData As DataTable
        Try
            rsData = oComments.GetRecords(0, Session("CoachID"), "C", Session("CompanyID"))
            If Not rsData Is Nothing Then
                For I As Integer = 0 To rsData.Rows.Count - 1
                    txtComments.Text = txtComments.Text & " " & rsData.Rows(I).Item("Comment") & vbCrLf
                Next
            End If
            'Session.Add("LinkName", txtFirstName.Text & ", " & txtLastName.Text())
        Catch ex As Exception
            lblError.Text = "LoadComments::" & ex.Message
        Finally
            oComments = Nothing
            'Session.Add("LinkName", txtLastName.Text)
        End Try

    End Sub

    Private Sub UpdPlayer(ByVal CoachID As Long, ByVal PlayerID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oCoach As New Season.clsCoaches
        Try
            'oCoach.UpdatePlayer(Session("CompanyID"), Session("SeasonID"), CoachID, PlayerID) -- update
        Catch ex As Exception
            Session("ErrorMSG") = "UpdPlayer::" & ex.Message
        Finally
            oCoach = Nothing
        End Try
    End Sub

    Protected Sub grdKids_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdKids.SelectedRowsChange

        Session("PeopleID") = grdKids.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value
        If Session("PeopleID") > 0 Then
            Session("CoachID") = 0
            Session("PlayerID") = 0
            Response.Redirect("People.aspx")
        End If
    End Sub

    Protected Sub grdKids_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.CellEventArgs) Handles grdKids.ClickCellButton

        Session("PlayerID") = grdKids.DisplayLayout.ActiveRow.Cells.FromKey("PlayerID").Value
        If Session("PlayerID") > 0 Then
            Call UpdPlayer(0, Session("PlayerID"))
            Call LoadPlayers()
            Call getKids(Session("CoachID"))
        End If
    End Sub

    Protected Sub lnkComments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkComments.Click
        If Session("CoachID") > 0 Then
            Call UpdRow(Session("CoachID"))
        Else
            Call ADDRow()
        End If
        If Session("CoachID") > 0 Then
            Session("CallingScreen") = "Coaches.aspx"
            Session.Add("LinkID", Session("CoachID"))
            Session.Add("CommentType", "C")
            Response.Redirect("Comments.aspx")
        End If
    End Sub

    Protected Sub grdCoaches_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdCoaches.DblClick
        Session("CoachID") = grdCoaches.DisplayLayout.ActiveRow.Cells.FromKey("CoachID").Value()
        Call LoadRow(Session("CoachID"))
        Call LoadComments(Session("CoachID"))
    End Sub

    Protected Sub cmbCoaches_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCoaches.SelectedIndexChanged
        Dim oPeople As New Profile.ClsPeople
        Try
            cmbSizes.SelectedValue = oPeople.GetShirtSize(cmbCoaches.SelectedValue, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = "cmbCoaches_SelectedIndexChanged::" & ex.Message
        Finally
            oPeople = Nothing
        End Try
    End Sub

    Protected Sub grdPlayers_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdPlayers.DblClick

        If Session("CoachID") > 0 Then
            Session("PlayerID") = grdPlayers.DisplayLayout.ActiveRow.Cells.FromKey("PlayerID").Value()
            Call UpdPlayer(Session("CoachID"), Session("PlayerID"))
            Call LoadPlayers()
            Call getKids(Session("CoachID"))
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("CoachID") > 0 Then
            Call UpdRow(Session("CoachID"))
            Call MsgBox("Changes successfully completed")
        Else
            Call ADDRow()
            Call MsgBox("New Record Added Successfully")
        End If
        Call LoadPlayers()
        Call LoadVolunteers()
        Call LoadRow(Session("CoachID"))
        Call LoadCoaches()
        lnkComments.Enabled = True
        txtComments.Enabled = True

    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call ClearFields()
        Session("CoachID") = 0
    End Sub

    Protected Sub lnkName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkName.Click
        Response.Redirect("People.aspx")
    End Sub

    Protected Sub lnkPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrint.Click
        '    'Response.write to a new Windows (not from the menu)
        '    'Does not work if the URL is hidden
        '    Session("ReportName") = "SeasonCoaches"
        '    Dim strS As String 'Loading.Aspx?Page=Reports.aspx
        '    strS = "Reports.aspx',null, 'target=_top,toolbar=Yes"
        '    Response.Write("<script>" & vbCrLf)
        '    Response.Write("window.open('" & strS & "');" & vbCrLf)
        '    Response.Write("</script>")
        Response.Redirect("report.aspx?Report=Coaches.rpt")
    End Sub

End Class

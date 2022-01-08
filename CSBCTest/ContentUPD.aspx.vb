Imports System.Data
Imports CSBC.Components
Partial Class ContentUPD
    Inherits System.Web.UI.Page
    Private sGlobal As New CSBC.Components.ClsGlobal

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Content Update"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnDelete.Enabled = False
                btnSave.Enabled = False
                btnDelete.Enabled = False
            End If

            Session("cntID") = 0
            mskStart.Text = sGlobal.TimeAdjusted(Session("TimeZone"), Now())
            mskEnd.Text = DateAdd(DateInterval.Year, 1, sGlobal.TimeAdjusted(Session("TimeZone"), Now()))
            Call LoadList()
        End If

    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Content", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = "AccessType::" & ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadList()
        Dim oContent As New Website.ClsContent
        Dim rsData As DataTable
        rsData = oContent.GetContent(Session("CompanyID"), Session("Screen"), Session("TimeZone"), Session("SeqNbr"))
        Try
            With grdDescr
                .DataSource = rsData
                .DataBind()
            End With
            With grdDescr.DisplayLayout.Bands(0).Columns
                .FromKey("lineText").Header.Caption = "Line Text"
                .FromKey("startDate").Header.Caption = "Start"
                .FromKey("endDate").Header.Caption = "Stop"
                .FromKey("lineText").Width = 400
                .FromKey("startDate").Width = 130
                .FromKey("endDate").Width = 130
                .FromKey("cntID").Hidden = True
                .FromKey("cntSeq").Hidden = True
                .FromKey("Bold").Hidden = True
                .FromKey("UnderLN").Hidden = True
                .FromKey("Italic").Hidden = True
                .FromKey("FontSize").Hidden = True
                .FromKey("FontColor").Hidden = True
                .FromKey("Link").Hidden = True
                'sGlobal.TimeAdjusted(Session("TimeZone"), rsData.Rows(0).Item("StartDate"))
            End With
        Catch ex As Exception
            lblError.Text = "LoadList::" & ex.Message
        Finally
            oContent = Nothing
        End Try
    End Sub

    Private Sub LoadRow(ByVal RowID As Long)
        Dim oContent As New Website.ClsContent
        Dim rsData As DataTable

        Try
            rsData = oContent.GetContent(Session("CompanyID"), Session("Screen"), Session("TimeZone"), Session("SegNbr"), RowID)
            If rsData.Rows.Count > 0 Then
                txtDescr.Text = rsData.Rows(0).Item("LineText") + " "
                cmbSize.SelectedValue = rsData.Rows(0).Item("FontSize") & ""
                cmbColor.SelectedValue = rsData.Rows(0).Item("FontColor") & ""
                chkBIU.Items(0).Selected = False
                chkBIU.Items(1).Selected = False
                chkBIU.Items(2).Selected = False
                If rsData.Rows(0).Item("Bold") = True Then chkBIU.Items(0).Selected() = True
                If rsData.Rows(0).Item("Italic") = True Then chkBIU.Items(1).Selected() = True
                If rsData.Rows(0).Item("UnderLn") = True Then chkBIU.Items(2).Selected() = True
                txtLink.Text = rsData.Rows(0).Item("link") & ""
                mskStart.Value = rsData.Rows(0).Item("StartDate")
                mskEnd.Value = rsData.Rows(0).Item("EndDate")
            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oContent = Nothing
        End Try
    End Sub

    Private Sub ADDRow()

        If Session("AccessType") = "R" Then Exit Sub
        Dim oContent As New Website.ClsContent
        Try
            With oContent
                .cntScreen = Session("Screen")
                .LineText = txtDescr.Text
                .Bold = chkBIU.Items(0).Selected
                .Italic = chkBIU.Items(1).Selected
                .UnderLn = chkBIU.Items(2).Selected
                .cntSeq = Session("SeqNbr")
                .FontColor = cmbColor.SelectedValue
                .FontSize = cmbSize.SelectedValue
                .Link = txtLink.Text
                .StartDate = sGlobal.TimeAdjusted(Session("TimeZone"), mskStart.Text)
                .EndDate = sGlobal.TimeAdjusted(Session("TimeZone"), mskEnd.Text)
                '.CreatedUser = Session("UserName")
                .UpdRow(0, Session("CompanyID"))
                Session("cntID") = .cntId
            End With
        Catch ex As Exception
            lblError.Text = "ADDRow::" & ex.Message
        Finally
            oContent = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("cntID") > 0 Then
            Call UpdRow(Session("cntID"))
            If lblError.Text = "" Then lblError.Text = "Changes successfully completed"
        Else
            Call ADDRow()
            If lblError.Text = "" Then lblError.Text = "New Record Added Successfully"
        End If
        ClearFields()
        'Call LoadRow(Session("cntID"))
        Call LoadList()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
        '2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
        '3) In your server-side click event, do this:

        Dim btn As Button = CType(sender, Button)
        If lblDelete.Text = "" Then btn.CommandArgument = "Confirm"
        If btn.CommandArgument = "Confirm" Then
            lblDelete.Text = "*Click Delete button again to confirm.*"
            lblDelete.Visible = True
            btn.CommandArgument = "Delete"
        ElseIf btn.CommandArgument = "Delete" Then
            If Session("cntID") > 0 Then
                Call DELRow(Session("cntID"))
                Call ClearFields()
                Session("cntID") = 0
                Call LoadList()
            End If
            lblDelete.Text = ""
            lblDelete.Visible = False
            btn.CommandArgument = "Confirm"
        End If

        'You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
        'you need to confirm or have confirmed.

    End Sub

    Private Sub ClearFields()
        txtDescr.Text = ""
        mskEnd.Text = ""
        mskStart.Text = ""
        txtLink.Text = ""
        cmbColor.SelectedIndex = 0
        cmbSize.SelectedIndex = 1
        chkBIU.Items(0).Selected = False
        chkBIU.Items(1).Selected = False
        chkBIU.Items(2).Selected = False
    End Sub

    Private Sub DELRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oContent As New Website.ClsContent
        Try
            oContent.DELRow(RowID, Session("CompanyID"))
        Catch ex As Exception
            lblError.Text = "DELRow::" & ex.Message
        Finally
            oContent = Nothing
        End Try
    End Sub

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oContent As New Website.ClsContent
        Try
            With oContent
                .cntScreen = Session("Screen")
                ' .cntId = RowID
                .LineText = txtDescr.Text
                .Bold = chkBIU.Items(0).Selected
                .Italic = chkBIU.Items(1).Selected
                .UnderLn = chkBIU.Items(2).Selected
                .cntSeq = Session("SeqNbr")
                .FontColor = cmbColor.SelectedValue
                .FontSize = cmbSize.SelectedValue
                .Link = txtLink.Text
                .StartDate = sGlobal.TimeAdjusted(Session("TimeZone"), mskStart.Text)
                .EndDate = sGlobal.TimeAdjusted(Session("TimeZone"), mskEnd.Text)
                .UpdRow(RowID, Session("CompanyID"))
            End With
        Catch ex As Exception
            lblError.Text = "UpdRow::" & ex.Message
        Finally
            oContent = Nothing
        End Try
    End Sub


    Private Sub grdDescr_DblClick(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdDescr.DblClick
        Session("cntID") = grdDescr.DisplayLayout.ActiveRow.Cells(0).Text()
        Call ClearFields()
        Call LoadRow(Session("cntID"))
    End Sub

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Server.Transfer("Content.aspx")
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call ClearFields()
        Session("cntID") = 0
        mskStart.Text = sGlobal.TimeAdjusted(Session("TimeZone"), Now())
        mskEnd.Text = DateAdd(DateInterval.Year, 1, sGlobal.TimeAdjusted(Session("TimeZone"), Now()))
    End Sub
End Class

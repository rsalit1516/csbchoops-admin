Imports System.Data
Imports CSBC.Components
Imports CSBC.Admin.Web.ViewModels


Partial Class Colors
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Colors"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                btnSave.Enabled = False
            End If
            Me.txtName.Focus()

            Call LoadList()
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Colors", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadRow(ByVal RowID As Long)
        Dim oColor As New Website.ClsColors
        Dim rsData As DataTable
        Try
            'rsData = oColor.LoadColors(RowID, Session("CompanyID"))
            If Not rsData Is Nothing Then
                If rsData.Rows.Count > 0 Then
                    lblID.Text = rsData.Rows(0).Item("ID")
                    txtName.Text = rsData.Rows(0).Item("ColorName")
                    chkDiscontinue.Checked = rsData.Rows(0).Item("bDiscontinued").ToString
                End If
            End If
        Catch ex As Exception
            lblError.Text = "LoadRow::" & ex.Message
        Finally
            oColor = Nothing
        End Try
    End Sub

    Private Sub LoadList()
        Dim oColors As New ColorVM
        Dim rsData As List(Of ColorVM)

        Try
            rsData = oColors.GetRecords(Session("CompanyID"))
            grdColors.Columns.Clear()
            If rsData.Count > 0 Then
                With grdColors
                    .DataSource = rsData
                    .DataBind()
                    .Columns(0).Visible = False

                    '    (0).].Visible = false;
                    '.FromKey("ColorName").Header.Caption = "Color Name"
                    '.FromKey("bDiscontinued").Hidden = True
                    '.FromKey("sDiscontinued").Header.Caption = "Discontinued"
                    '.FromKey("sDiscontinued").CellStyle.HorizontalAlign = HorizontalAlign.Center
                End With
            End If
        Catch ex As Exception
            lblError.Text = "LoadList::" & ex.Message
        Finally
            oColors = Nothing
        End Try
    End Sub

    Private Sub UpdRow(ByVal RowID As Long)
        If Session("AccessType") = "R" Then Exit Sub
        Dim oColors As New Website.ClsColors
        Try
            With oColors
                .Descr = txtName.Text
                .bDiscontinue = chkDiscontinue.Checked
                oColors.UpdRow(RowID, Session("CompanyID"), Session("TimeZone"))
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "UpdRow::" & ex.Message
        Finally
            oColors = Nothing
        End Try
    End Sub

    Private Sub ClearFields()
        grdColors.Controls.Clear()
        txtName.Text = ""
        txtName.Focus()
        chkDiscontinue.Checked = False
        Session("ErrorMsg") = ""
        Session("ColorID") = 0
    End Sub

    Private Sub ADDRow()
        If Session("AccessType") = "R" Then Exit Sub
        Dim oColors As New Website.ClsColors
        Try
            With oColors
                .Descr = txtName.Text
                .CreatedUser = Session("UserName")
                .bDiscontinue = chkDiscontinue.Checked
                .UpdRow(0, Session("CompanyID"), Session("TimeZone"))
                Session("ColorID") = .ColorID
            End With
        Catch ex As Exception
            Session("ErrorMSG") = ex.Message
        Finally
            oColors = Nothing
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("AccessType") = "R" Then Exit Sub
        If Session("ColorID") > 0 Then
            UpdateColor()
        Else
            AddColor()
        End If
        LoadList()
        ClearFields()
    End Sub

    Private Sub UpdateColor()
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("ErrorMsg") = "" Then Call UpdRow(Session("ColorID"))
        If Session("ErrorMsg") = "" Then Call MsgBox("Changes successfully completed")
        lblError.Text = Session("ErrorMsg")
    End Sub

    Private Sub AddColor()
        If errorRTN() = True Then
            Call MsgBox("ERROR: " & lblError.Text)
            Exit Sub
        End If
        If Session("ErrorMsg") = "" Then Call ADDRow()
        If Session("ErrorMsg") = "" Then Call MsgBox("New Record Added Successfully")
        lblError.Text = Session("ErrorMsg")
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
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Protected Sub grdColors_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdColors.SelectedRowsChange
        Session("ColorID") = grdColors.DisplayLayout.ActiveRow.Cells.FromKey("ID").Value
        If Session("ColorID") > 0 Then
            LoadRow(Session("ColorID"))
            btnSave.Enabled = True
        End If
        If Session("AccessType") = "R" Then
            btnSave.Enabled = False
        End If
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call ClearFields()
        Session("ColorID") = 0
        txtName.Focus()
    End Sub
End Class

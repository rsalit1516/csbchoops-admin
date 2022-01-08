Imports System.Data
Imports CSBC.Components.Website
Partial Class Comments
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") = 0 Then
            Response.Redirect("Login.aspx")
        End If

        If Page.IsPostBack = False Then
            Call LoadList()
        End If
    End Sub

    Private Sub LoadList()
        Dim oComments As New ClsComments
        Dim dtResults As DataTable
        Try
            dtResults = oComments.GetRecords(0, Session("LinkID"), Session("CommentType"), Session("CompanyID"))
            grdComments.DataSource = dtResults
            grdComments.DataBind()
        Catch ex As Exception
            Session("ErrorMSG") = "LoadList::" & ex.Message
        Finally
            oComments = Nothing
        End Try
        With grdComments.DisplayLayout.Bands(0).Columns
            .FromKey("CompanyID").Hidden = True
            .FromKey("CommentID").Hidden = True
            .FromKey("CommentType").Hidden = True
            .FromKey("LinkID").Hidden = True
            '.FromKey("UserID").Hidden = True
            .FromKey("CreatedDate").Hidden = True
            .FromKey("CreatedUSer").Hidden = True
            .FromKey("Comment").Width = 300
        End With

        txtComment.Text = ""
        Session.Add("CommentID", "0")
        lblRecord.Text = Session("LinkName")
    End Sub

    Private Sub DELComment(ByVal CommentID As Long)
        Dim oComments As New ClsComments
        Try
            oComments.DELRow(CommentID, Session("LinkID"), Session("CommentType"), Session("CompanyID"))
            Call LoadList()

        Catch ex As Exception
            Session("ErrorMSG") = "DELComment::" & ex.Message
        Finally
            oComments = Nothing
        End Try

        Session.Add("CommentID", 0)
    End Sub

    Protected Sub grdComments_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdComments.SelectedRowsChange
        Session("CommentID") = grdComments.DisplayLayout.ActiveRow.Cells.FromKey("CommentID").Value
        If Session("CommentID") > 0 Then
        Else
            Exit Sub
        End If
        Dim oComment As New ClsComments
        Dim dtResults As DataTable
        Try
            dtResults = oComment.GetRecords(Session("CommentID"), Session("LinkID"), Session("CommentType"), Session("CompanyID"))
            txtComment.Text = dtResults.Rows(0).Item("Comment") & ""
        Catch ex As Exception
            Session("ErrorMSG") = "grdComments::" & ex.Message
        Finally
            oComment = Nothing
        End Try
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oComment As New ClsComments
        Try
            oComment.DELRow(Session("CommentID"), Session("LinkID"), Session("CommentType"), Session("CompanyID"))
        Catch ex As Exception
            Session("ErrorMSG") = "btnDelete::" & ex.Message
        Finally
            oComment = Nothing
        End Try
        txtComment.Text = ""
        Session("CommentID") = 0
        Call LoadList()

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim oComment As New ClsComments
        Try
            With oComment
                .Comment = txtComment.Text
                .LinkId = Session("LinkID")
                .CommentType = Session("CommentType")
            End With
            oComment.UpdRow(Session("CommentID"), Session("CompanyID"))
        Catch ex As Exception
            Session("ErrorMSG") = "btnSave::" & ex.Message
        Finally
            oComment = Nothing
        End Try
        Call LoadList()
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim oComment As New ClsComments
        Try
            With oComment
                .CommentType = Session("CommentType")
                .Comment = txtComment.Text
                .LinkId = Session("LinkID")
                .CreatedUser = Session("UserName")
                .UpdRow(0, Session("CompanyID"))
                Session("CommentID") = .CommentID
            End With
        Catch ex As Exception
            Session("ErrorMSG") = "SaveComments::" & ex.Message
        Finally
            oComment = Nothing
        End Try
        Call LoadList()
    End Sub

    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect(Session("CallingScreen"))
    End Sub
End Class

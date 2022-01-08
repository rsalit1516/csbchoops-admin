Imports System.Data
Imports CSBC.Components
Partial Class Content
    Inherits System.Web.UI.Page
    '    Private sSql As String
    Private sGlobal As New CSBC.Components.ClsGlobal

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Title") = "Content"
            Session("AccessType") = AccessType()
            If Session("AccessType") = "R" Then
                Img1.Visible = False
                Img2.Visible = False
                Img3.Visible = False
                Img4.Visible = False
                Img5.Visible = False
                Img6.Visible = False
                Img7.Visible = False
                Img8.Visible = False
                Img9.Visible = False
                Img10.Visible = False
                Img11.Visible = False
                Img12.Visible = False
                Img13.Visible = False
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
            End If
            Call LoadDates("Index")
            Call GetMessages("Index")
        End If
    End Sub

    Private Function AccessType() As String
        Dim oSecurity As New Security.ClsUsers
        Try
            oSecurity.GetAccess(Session("UserID"), "Content", Session("CompanyID"), Session("SeasonID"))
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            AccessType = oSecurity.AccessType
            oSecurity = Nothing
        End Try
    End Function

    Private Sub LoadDates(ByVal MessScreen As String)
        Dim oContent As New Website.ClsContent
        Dim rsData As DataTable

        Try
            rsData = oContent.GetDates(Session("CompanyID"), MessScreen)
            'Populate Dates Combo
            With cmbDates
                .Items.Clear()
                For I As Int32 = 0 To rsData.Rows.Count - 1
                    .Items.Add(New ListItem(Trim(rsData.Rows(I).Item("StartDate")), Trim(rsData.Rows(I).Item("StartDate"))))
                Next
                cmbDates.SelectedIndex = 0
            End With
        Catch ex As Exception
            lblError.Text = "LoadDates::" & ex.Message
        Finally
            oContent = Nothing
        End Try
    End Sub

    Private Sub GetMessages(ByVal MessScreen)
        Dim oContent As New Website.ClsContent
        Dim rsData As DataTable
        Dim contentDate As Date


        Try
            contentDate = cmbDates.SelectedValue
            rsData = oContent.GetContent(Session("CompanyID"), MessScreen, cmbDates.SelectedValue)
            Call ClearAllLines()
            For I As Int32 = 0 To rsData.Rows.Count - 1
                If rsData.Rows(I).Item("LineText") > "" Then
                    Select Case rsData.Rows(I).Item("cntSeq")
                        Case 1
                            SetProp(Link1, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 2
                            SetProp(Link2, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 3
                            SetProp(Link3, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 4
                            SetProp(Link4, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 5
                            SetProp(Link5, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 6
                            SetProp(Link6, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 7
                            SetProp(Link7, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 8
                            SetProp(Link8, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 9
                            SetProp(Link9, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 10
                            SetProp(Link10, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 11
                            SetProp(Link11, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 12
                            SetProp(Link12, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 13
                            SetProp(Link13, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 14
                            SetProp(Link14, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 15
                            SetProp(Link15, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))
                        Case 16
                            SetProp(Link16, rsData.Rows(I).Item("LineText"), rsData.Rows(I).Item("Bold"), rsData.Rows(I).Item("UnderLN"), rsData.Rows(I).Item("Italic"), rsData.Rows(I).Item("FontSize"), rsData.Rows(I).Item("FontColor"), rsData.Rows(I).Item("Link"))

                    End Select
                End If
            Next
        Catch ex As Exception
            lblError.Text = "GetMessages::" & ex.Message
        Finally
            oContent = Nothing
        End Try

    End Sub

    Private Sub ClearAllLines()
        Link1.Text = ""
        Link2.Text = ""
        Link3.Text = ""
        Link4.Text = ""
        Link5.Text = ""
        Link6.Text = ""
        Link7.Text = ""
        Link8.Text = ""
        Link9.Text = ""
        Link10.Text = ""
        Link11.Text = ""
        Link12.Text = ""
        Link13.Text = ""
        Link14.Text = ""
        Link15.Text = ""
        Link16.Text = ""
    End Sub

    Public Sub MsgBox(ByVal Message As String)
        Dim strScript As New Label
        strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" & Environment.NewLine & "window.alert('" + Message + "')</script>"
        Page.Controls.Add(strScript)
    End Sub

    Private Function SetProp(ByVal Link As Object, ByVal sText As String, ByVal bBold As Boolean, ByVal bUnderLn As Boolean, ByVal bItalic As Boolean, ByVal sFontSize As String, ByVal sFontColor As String, ByVal sLink As String) As HyperLink
        SetProp = Nothing
        Link.Text = sText
        Link.Font.Bold = bBold
        Link.Font.Underline = bUnderLn
        Link.Font.Italic = bItalic
        Select Case sFontSize
            Case "XSMALL"
                Link.Font.Size = System.Web.UI.WebControls.FontUnit.XXSmall
            Case "SMALL"
                Link.Font.Size = System.Web.UI.WebControls.FontUnit.XSmall
            Case "MEDIUM"
                Link.Font.Size = System.Web.UI.WebControls.FontUnit.Small
            Case "LARGE"
                Link.Font.Size = System.Web.UI.WebControls.FontUnit.Medium
        End Select
        Link.ForeColor = System.Drawing.Color.FromName(sFontColor)
        Link.NavigateUrl = sLink
    End Function

    Private Sub img1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img1.Click
        Call TransferOut(1)
    End Sub

    Private Sub img2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img2.Click
        Call TransferOut(2)
    End Sub

    Private Sub img3_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img3.Click
        Call TransferOut(3)
    End Sub

    Private Sub img4_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img4.Click
        Call TransferOut(4)
    End Sub

    Private Sub img5_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img5.Click
        Call TransferOut(5)
    End Sub

    Private Sub img6_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img6.Click
        Call TransferOut(6)
    End Sub

    Private Sub img7_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img7.Click
        Call TransferOut(7)
    End Sub

    Private Sub img8_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img8.Click
        Call TransferOut(8)
    End Sub

    Private Sub img9_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img9.Click
        Call TransferOut(9)
    End Sub

    Private Sub img10_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img10.Click
        Call TransferOut(10)
    End Sub

    Private Sub img11_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img11.Click
        Call TransferOut(11)
    End Sub

    Private Sub img12_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img12.Click
        Call TransferOut(12)
    End Sub

    Private Sub img13_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img13.Click
        Call TransferOut(13)
    End Sub

    Private Sub img14_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img14.Click
        Call TransferOut(14)
    End Sub

    Private Sub img15_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img15.Click
        Call TransferOut(15)
    End Sub

    Private Sub img16_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Img16.Click
        Call TransferOut(16)
    End Sub

    Private Sub TransferOut(ByVal iSeq As Integer)
        Session("SeqNbr") = iSeq
        Session("Screen") = "Index"
        Response.Redirect("ContentUPD.aspx")
    End Sub

    Private Sub cmbDates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDates.SelectedIndexChanged
        Call GetMessages("Index")
    End Sub
End Class

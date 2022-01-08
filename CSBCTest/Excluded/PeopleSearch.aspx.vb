Imports System.Data
Imports CSBC.Components.Profile
Partial Class PeopleSearch
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then LoadSessions()
        If Session("UserID") = 0 Then
            Response.Redirect("Login.aspx")
        End If

        If Page.IsPostBack = False Then
            CaptureSessions()

            If Session("FirstLetter") > "" Then Call SetSearching()
        End If
    End Sub

    Protected Sub CaptureSessions()
        Session("Title") = "People Search"
        HiddenField1.Value = Session("UserID")
        HiddenField2.Value = Session("FirstLetter")
        HiddenField3.Value = Session("PeopleID")
        HiddenField4.Value = Session("SearchType")
        HiddenField5.Value = Session("SeasonDesc")
        HiddenField6.Value = Session("CompanyID")
        HiddenField7.Value = Session("Title")
    End Sub

    Protected Sub LoadSessions()
        Session("FirstLetter") = ""
        Session("SearchType") = ""
        Session("CompanyID") = 1
        Session("UserID") = 0
        Session("PeopleID") = 0
        Session("SeasonDesc") = ""
        Session("Title") = ""

        If HiddenField1.Value > "" Then Session("UserID") = HiddenField1.Value
        If HiddenField2.Value > "" Then Session("FirstLetter") = HiddenField2.Value
        If HiddenField3.Value > "" Then Session("PeopleID") = HiddenField3.Value
        If HiddenField4.Value > "" Then Session("SearchType") = HiddenField4.Value
        If HiddenField5.Value > "" Then Session("SeasonDesc") = HiddenField5.Value
        If HiddenField6.Value > "" Then Session("CompanyID") = HiddenField6.Value
        If HiddenField7.Value > "" Then Session("Title") = HiddenField7.Value
    End Sub

    Protected Sub cmbRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRefresh.Click
        If txtFirstName.Text > "" Or txtLastName.Text > "" Then
            Session("FirstLetter") = ""
            Call LoadList()
        End If
    End Sub

    Protected Sub cmbReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbReturn.Click
        Session.Add("PeopleID", 0)
        Response.Redirect("PeopleUPD.aspx")
    End Sub

    Private Sub SetSearching()
        If Session("SearchType") = "FirstName" Then
            txtFirstName.Text = Session("FirstLetter")
        End If
        If Session("SearchType") = "LastName" Then
            txtLastName.Text = Session("FirstLetter")
        End If
        Call LoadList()
    End Sub

    Private Sub LoadList()
        Dim oPeople As New ClsPeople
        Dim dtResults As DataTable
        Try
            oPeople.FirstName = txtFirstName.Text
            oPeople.LastName = txtLastName.Text
            oPeople.CompanyId = Session("CompanyID")
            dtResults = oPeople.GetRecords(0, Session("CompanyID"))
            grdPeople.DataSource = dtResults
            grdPeople.DataBind()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            oPeople = Nothing
        End Try
        With grdPeople.DisplayLayout.Bands(0).Columns
            .FromKey("PeopleId").Hidden = True
            .FromKey("FirstName").Width = 150
            'align
            .FromKey("LastName").Width = 150
            .FromKey("Phone").Width = 80
            .FromKey("BirthDate").Format = "MM/dd/yyyy"
            .FromKey("BirthDate").Width = 80
            .FromKey("Address1").Header.Caption = "Address"
            .FromKey("Address1").Width = 250
        End With
    End Sub
End Class

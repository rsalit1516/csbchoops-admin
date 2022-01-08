Imports System.Data
Imports System.Data.SqlClient
Imports CSBC.Components

Public Class SearchHouse
    Inherits System.Web.UI.Page
    Private rsData As DataTable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Name") = ""
            Session("Address") = ""
            Session("Phone") = ""
            Session("Email") = ""
            Select Case Session("SearchType")
                Case "Name"
                    Session("Name") = Session("FirstLetter")
                Case "Address1"
                    Session("Address") = Session("FirstLetter")
                Case "Phone"
                    Session("Phone") = Session("FirstLetter")
                Case "Email"
                    Session("Email") = Session("FirstLetter")
                Case Else
                    Session("Name") = ""
                    Session("Address") = ""
                    Session("Phone") = ""
                    Session("Email") = ""
            End Select
            If Session("FirstLetter") > "" Then
                Call GetData()
            Else
                txtLastName.Focus()
            End If
            Session("Title") = "Search Households"
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Session("SearchByName") = ""
        Session("SearchByAddress") = ""
        Session("Name") = ""
        Session("Address") = ""
        Session("Phone") = ""
        Session("Email") = ""
        If txtLastName.Text > "" Then
            Session("SearchByName") = "Name"
            Session("Name") = txtLastName.Text
            Call GetData()
        End If
        If txtAddress.Text > "" Then
            Session("SearchByAddress") = "Address1"
            Session("Address") = txtAddress.Text
            Call GetData()
        End If

    End Sub

    Private Sub GetData()
        Dim oHouseholds As New Profile.ClsHouseholds
        Dim CompanyId As String = System.Configuration.ConfigurationManager.AppSettings("CompanyID")
        Try
            rsData = oHouseholds.GetRecords(0, CompanyId, Session("Name"), Session("Address"), Session("Phone"), Session("Email"))
            'grdHouseholds.Clear()
            If rsData.Rows.Count > 0 Then
                With grdHouseholds
                    .DataSource = rsData
                    .DataBind()


                    'grdHouseholds.Columns(0).Width = Unit.Percentage(33.3)
                    With .Columns
                        .Item(0).Visible = False
                        .Item(0).ItemStyle.Width = 100
                        .Item(1).ItemStyle.Width = 120
                        .Item(2).ItemStyle.Width = 200
                    End With
                End With
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oHouseholds = Nothing
        End Try
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Session.Add("HouseID", 0)
        Response.Redirect("HouseHolds1.aspx")
    End Sub

    Protected Sub grdHouseholds_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdHouseholds.RowCommand
        

       
    End Sub
    Private Sub grdHouseholds_OnRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Session("HouseID") = e.grdHouseholds.SelectedRow.Cells("HouseID").Text
    End Sub
    Protected Sub grdHouseholds_ButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, Control).Parent.Parent,  _
GridViewRow)
        Dim cell As String = gvRow.Cells(0).Text

        Session("HouseID") = cell
        If Session("CallingScreen") > "" Then
            Response.Redirect(Session("CallingScreen"))
        Else
            Response.Redirect("HouseHolds1.aspx")
        End If
    End Sub

    'Protected Sub grdHouseholds_SingleClick(sender As Object, e As GridViewCommandEventArgs) Handles grdHouseholds.SingleClick
    '    Session("HouseID") = grdHouseholds.SelectedRow.Cells("HouseID").Text
    '    If Session("CallingScreen") > "" Then
    '        Response.Redirect(Session("CallingScreen"))
    '    Else
    '        Response.Redirect("HouseHolds.aspx")
    '    End If
    'End Subs
End Class


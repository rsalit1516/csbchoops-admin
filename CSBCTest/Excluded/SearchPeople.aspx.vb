Imports System.Data
Imports System.Data.SqlClient
Imports CSBC.Components

Public Class SearchPeople
    Inherits System.Web.UI.Page
    Private rsData As DataTable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("UserID") Is Nothing Then Response.Redirect("Login.aspx")

        If Page.IsPostBack = False Then
            Session("Name") = ""
            Session("LastName") = ""
            Session("FirstName") = ""
            Dim SearchType As String = Session("SearchType") + ""
            Select Case SearchType
                Case "LastName"
                    Session("LastName") = Session("FirstLetter")
                Case "FirstName"
                    Session("FirstName") = Session("FirstLetter")
                Case Else
                    Session("Name") = ""
                    Session("LastName") = ""
                    Session("FirstName") = ""
            End Select
            If Session("FirstLetter") > "" Then
                Call GetData()
            Else
                txtLastName.Focus()
            End If
            Session("Title") = "Search People"
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Session("SearchByName") = ""
        Session("SearchByAddress") = ""
        Session("Name") = ""
        Session("LastName") = ""
        Session("FirstName") = ""
        If txtFirstName.Text > "" Then
            Session("SearchByName") = "FirstName"
            Session("FirstName") = txtFirstName.Text

        End If
        If txtLastName.Text > "" Then
            Session("SearchByName") = "LastName"
            Session("LastName") = txtLastName.Text

        End If
        If Session("SearchByName") > "" Then Call GetData()
    End Sub

    Private Sub GetData()
        Dim oPeople As New Profile.ClsPeople
        Try
            rsData = oPeople.GetRecords(0, Session("CompanyID"), Session("FirstName"), Session("LastName"), Session("Name"), Session("BirthDate"), "PeopleId, HouseID, LastName, FirstName, HousePhone, BirthDate, Address1")
            grdPeople.Clear()
            If rsData.Rows.Count > 0 Then
                With grdPeople
                    .DataSource = rsData
                    .DataBind()
                    'grdPeople.Columns(0).Width = Unit.Percentage(33.3)
                    With .DisplayLayout.Bands(0).Columns
                        .FromKey("PeopleId").Hidden = True
                        .FromKey("HouseID").Hidden = True
                        .FromKey("LastName").Width = 130
                        .FromKey("FirstName").Width = 130
                        .FromKey("HousePhone").Width = 80
                        .FromKey("BirthDate").Width = 70
                        .FromKey("BirthDate").Format = "MM/dd/yyyy"
                        .FromKey("BirthDate").CellStyle.HorizontalAlign = HorizontalAlign.Right
                        .FromKey("Address1").Width = 280
                        .FromKey("Address1").Header.Caption = "Address"
                        .FromKey("HousePhone").CellStyle.HorizontalAlign = HorizontalAlign.Right
                    End With


                End With
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            oPeople = Nothing
        End Try
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Session.Add("PeopleID", 0)
        Response.Redirect("People.aspx")
    End Sub

    Protected Sub grdPeople_SelectedRowsChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs) Handles grdPeople.SelectedRowsChange
        Session("PeopleID") = grdPeople.DisplayLayout.ActiveRow.Cells.FromKey("PeopleID").Value()
        Session("HouseID") = grdPeople.DisplayLayout.ActiveRow.Cells.FromKey("HouseID").Value()

        If Session("CallingScreen") > "" Then
            Response.Redirect(Session("CallingScreen"))
        Else
            Response.Redirect("People.aspx")
        End If
    End Sub

End Class


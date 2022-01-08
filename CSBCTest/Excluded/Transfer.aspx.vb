
Partial Class Transfer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case Request.QueryString("Transfer")
            Case "People.aspx"
                Session("PeopleID") = 0
                Session("HouseID") = 0
            Case "Households.aspx", "SearchRegistration.aspx"
                Session("HouseID") = 0
            Case "BoardUPD.aspx"
                Session("DirectorID") = 0
            Case "Division1.aspx"
                Session("DivisionID") = 0
            Case "Teams.aspx"
                Session("TeamID") = 0
                Session("DivisionID") = 0
            Case "Sponsors.aspx"
                Session("SponsorID") = 0
        End Select
        Session("CallingScreen") = ""
        Session("SearchByName") = ""
        Session("SearchByAddress") = ""
        Session("SearchType") = ""
        Session("Name") = ""
        Session("LastName") = ""
        Session("Address") = ""
        Session("Phone") = ""
        Session("Email") = ""
        Session("CurrentPage") = ""
        Session("FirstName") = ""
        Session("FirstLetter") = ""

        Response.Redirect(Request.QueryString("Transfer"))
    End Sub
End Class

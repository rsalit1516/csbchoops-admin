Imports CSBC.Components.Security
Namespace CSBC.Components.Season
    Public Class clsSponsors
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal
        Public Function LoadSponsors(ByVal SponsorID As Int32, ByVal CompanyID As Int32, ByVal SeasonID As Int32, ByVal DivisionID As Int32, ByVal TeamID As Int32) As DataTable

            Dim DB As New ClsDatabase
            Try
                sSQL = "exec [dbo].[GetSponsors]"
                sSQL += " @CompanyID = " & CompanyID
                sSQL += ", @SeasonID = " & SeasonID
                sSQL += ", @SponsorID = " & SponsorID
                sSQL += ", @DivisionID = " & DivisionID
                sSQL += ", @TeamID = " & TeamID
                'TODO:: Company
                sSQL = "exec [dbo].[GetSponsors]"
                sSQL += ", @SeasonID = " & SeasonID
                sSQL += ", @SponsorID = " & SponsorID
                sSQL += ", @DivisionID = " & DivisionID
                sSQL += ", @TeamID = " & TeamID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsSponsors:LoadSponsors::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function SponsorsColor(ByVal sponsorID As Int32, ByVal CompanyID As Int32, ByVal seasonid As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT Color1.Colorname as Color1, Color2.Colorname as Color2 "
                sSQL += "FROM Sponsors "
                sSQL += "LEFT JOIN Colors Color1 ON Color1ID = Color1.ID AND Sponsors.CompanyID = Color1.CompanyID "
                sSQL += "LEFT JOIN Colors Color2 ON Color2ID = Color2.ID AND Sponsors.CompanyID = Color2.CompanyID "
                sSQL += "WHERE Sponsors.SponsorID= " & sponsorID
                sSQL += " AND Sponsors.SeasonID=" & seasonid
                sSQL += " AND Sponsors.CompanyID=" & CompanyID
                'TODO:: Company
                sSQL = "SELECT Color1.Colorname as Color1, Color2.Colorname as Color2 "
                sSQL += "FROM Sponsors "
                sSQL += "LEFT JOIN Colors Color1 ON Color1ID = Color1.ID "
                sSQL += "LEFT JOIN Colors Color2 ON Color2ID = Color2.ID "
                sSQL += "WHERE Sponsors.SponsorID= " & sponsorID
                sSQL += " AND Sponsors.SeasonID=" & seasonid
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsSponsors:SponsorsColor::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetSponsorsInfo(ByVal iCompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetSponsorsInfo @CompanyID=" & iCompanyID
                'TODO:: Company
                sSQL = " EXEC GetSponsorsInfo "
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsSponsors:GetSponsorsInfo::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Function LoadAllSponsors(SponsorProfileID As Long, p2 As Object) As DataTable
            Throw New NotImplementedException
        End Function

        Function GetSponsorPayments(p1 As Object, p2 As Object) As DataTable
            Throw New NotImplementedException
        End Function

    End Class
End Namespace

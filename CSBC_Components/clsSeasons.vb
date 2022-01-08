Imports CSBC.Components.Security

Namespace CSBC.Components.Season
    Public Class ClsSeasons
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal
        Public Property CompanyID() As Integer
            Get
                CompanyID = stRowData.CompanyID
            End Get
            Set(ByVal value As Integer)
                stRowData.CompanyID = value
            End Set
        End Property

        Public Property SeasonID() As Integer
            Get
                SeasonID = stRowData.SeasonID
            End Get
            Set(ByVal value As Integer)
                stRowData.SeasonID = value
            End Set
        End Property

        Public Property SeasonDesc() As String
            Get
                SeasonDesc = stRowData.SeasonDesc
            End Get
            Set(ByVal value As String)
                stRowData.SeasonDesc = value
            End Set
        End Property

        Public Structure RowFields
            Public CompanyID As Integer
            Public SeasonID As Integer
            Public SeasonDesc As String
        End Structure

        Public stRowData As RowFields

        Property ParticipationFee As Long

        Public Sub GetSeason(ByVal CompanyID As Int32, Optional ByVal iSeasonID As Int32 = 0)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "select * from seasons where currentschedule = 1 AND CompanyID = " & CompanyID
                'TODO:: Company
                sSQL = "select Sea_Desc, SeasonID from seasons where currentschedule = 1 "
                If iSeasonID > 0 Then sSQL += " AND SeasonID = " & iSeasonID
                dtResults = DB.ExecuteGetSQL(sSQL)
                SeasonID = dtResults.Rows(0).Item("SeasonID").ToString
                SeasonDesc = dtResults.Rows(0).Item("Sea_Desc").ToString
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub GetCurrentSeason(ByVal CompanyID As Int32, Optional ByVal iSeasonID As Int32 = 0)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "select * from seasons where currentschedule = 1 AND CompanyID = " & CompanyID
                If iSeasonID > 0 Then sSQL += " AND SeasonID = " & iSeasonID
                dtResults = DB.ExecuteGetSQL(sSQL)
                SeasonID = dtResults.Rows(0).Item("SeasonID").ToString
                SeasonDesc = dtResults.Rows(0).Item("Sea_Desc").ToString
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Function GetRecords(ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "select Sea_Desc, SeasonID from seasons where CompanyID = " & CompanyID
                sSQL += " ORDER BY SeasonID Desc"
                GetRecords = DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetSeasonCounts(ByVal iSeasonID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC SeasonCounts @SeasonID = " & iSeasonID & ", @CompanyID= " & CompanyID
                'TODO:: Company
                sSQL = " EXEC SeasonCounts @SeasonID = " & iSeasonID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function
    End Class
End Namespace

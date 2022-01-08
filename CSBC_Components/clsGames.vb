Imports CSBC.Components.Security
Namespace CSBC.Components.Season
    Public Class clsGames
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal

        Public Property Location() As String
            Get
                Location = stRowData.Location
            End Get
            Set(ByVal value As String)
                stRowData.Location = value
            End Set
        End Property

        Public Property GameDate() As Date
            Get
                GameDate = stRowData.GameDate
            End Get
            Set(ByVal value As Date)
                stRowData.GameDate = value
            End Set
        End Property

        Public Property GameTime() As String
            Get
                GameTime = stRowData.GameTime
            End Get
            Set(ByVal value As String)
                stRowData.GameTime = value
            End Set
        End Property

        Public Property Home() As String
            Get
                Home = stRowData.Home
            End Get
            Set(ByVal value As String)
                stRowData.Home = value
            End Set
        End Property

        Public Property HomeTeamScore() As String
            Get
                HomeTeamScore = stRowData.HomeTeamScore
            End Get
            Set(ByVal value As String)
                stRowData.HomeTeamScore = value
            End Set
        End Property

        Public Property Visitor() As String
            Get
                Visitor = stRowData.Visitor
            End Get
            Set(ByVal value As String)
                stRowData.Visitor = value
            End Set
        End Property

        Public Property VisitingTeamScore() As String
            Get
                VisitingTeamScore = stRowData.VisitingTeamScore
            End Get
            Set(ByVal value As String)
                stRowData.VisitingTeamScore = value
            End Set
        End Property

        Public Structure RowFields
            Public Location As String
            Public GameDate As Date
            Public GameTime As String
            Public Home As String
            Public HomeTeamScore As String
            Public Visitor As String
            Public VisitingTeamScore As String
        End Structure

        Public stRowData As RowFields

        Property LocationNumber As String

        Property Descr As String

        Property GameType As String

        Public Sub GetGames(ByVal ScheduleNoAD As Integer, ByVal GameNo As Integer, ByVal GameType As String)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                'dtResults.Clear()
                sSQL = "EXEC GetGameScore @ScheduleNo = " & ScheduleNoAD
                sSQL += ", @GameNo=" & GameNo
                sSQL += ", @GameType=" & GameType
                dtResults = DB.ExecuteGetSQL(sSQL)
                If dtResults.Rows.Count > 0 Then
                    Location = dtResults.Rows(0).Item("LocationName").ToString
                    GameDate = dtResults.Rows(0).Item("GameDate").ToString
                    GameTime = dtResults.Rows(0).Item("GameTime").ToString
                    Home = dtResults.Rows(0).Item("Home").ToString
                    HomeTeamScore = dtResults.Rows(0).Item("HomeTeamScore").ToString
                    Visitor = dtResults.Rows(0).Item("Visitor").ToString
                    VisitingTeamScore = dtResults.Rows(0).Item("VisitingTeamScore").ToString
                End If
            Catch ex As Exception
                Throw New Exception("ClsGames:GetGames::" & ex.Message)
            Finally
                DB = Nothing
                dtResults = Nothing
            End Try

        End Sub

        Public Function GetStats(ByVal ScheduleNoAD As Integer, ByVal SeasonID As Integer) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC PlayerStats @ScheduleNo = " & ScheduleNoAD
                sSQL += ", @SeasonID=" & SeasonID
                Return DB.ExecuteGetSQL(sSQL)

            Catch ex As Exception
                Throw New Exception("ClsGames:GetStats::" & ex.Message)
            Finally
                DB = Nothing
            End Try

        End Function

        Public Function GetStanding(ByVal CompanyID As Int32, ByVal iDivision As Integer) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetStanding @ScheduleNumber = " & iDivision
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsGames:GetStanding::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub UpdateGameScores(ByVal ScheduleNoAD As Integer, ByVal GameNumber As Integer, ByVal GameType As String, Optional ByVal HomeScore As String = "", Optional ByVal VisitorScore As String = "")
            Dim DB As New ClsDatabase
            Try
                sSQL = "exec UpdateGameScore @ScheduleNo =" & ScheduleNoAD & ", @GameNo =" & GameNumber & ", @GameType = " & GameType
                If HomeScore > "" Then sSQL += ", @HomeScore =" & HomeScore
                If VisitorScore > "" Then sSQL += ", @VisitorScore =" & VisitorScore
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsGames:UpdateGameScores::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdateStats(ByVal iSeasonID As Integer, ByVal iScheduleNo As Integer, ByVal iGameNumber As Integer, ByVal iPeopleID As Integer, ByVal iRowID As Integer, ByVal iTeamNumber As Integer, Optional ByVal sPoints As String = "", Optional ByVal iDNP As Integer = 0)
            Dim DB As New ClsDatabase
            Try
                sSQL = "exec UpdateGameStats @ScheduleNo =" & iScheduleNo
                sSQL += ", @RowID =" & iRowID
                sSQL += ", @GameNo =" & iGameNumber
                sSQL += ", @TeamNumber =" & iTeamNumber
                sSQL += ", @PeopleID =" & iPeopleID
                sSQL += ", @SeasonID = " & iSeasonID
                If sPoints > "" Then sSQL += ", @Points =" & sPoints
                sSQL += ", @DNP =" & iDNP
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsGames:UpdateStats::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Function GetStats(ByVal CompanyID As Int32, ByVal iGameNumber As Integer, ByVal iScheduleNbr As Integer, ByVal iSeasonID As Integer) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetGameStats @GameNumber = " & iGameNumber
                sSQL += ", @ScheduleNumber = " & iScheduleNbr
                sSQL += ", @SeasonID = " & iSeasonID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsGames:GetStats::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Sub UpdateGame(ScheduleNo As Short, GameNumber As Short)
            Throw New NotImplementedException
        End Sub

        Sub AddRecord(p1 As Object, p2 As String)
            Throw New NotImplementedException
        End Sub

        Sub DELRow(ScheduleNumber As Short, GameNumber As Short)
            Throw New NotImplementedException
        End Sub

        Function LoadVenues(p1 As Integer, p2 As Object) As DataTable
            Throw New NotImplementedException
        End Function

        Function GetDayGames(p1 As Object, p2 As Object, p3 As Date) As DataTable
            Throw New NotImplementedException
        End Function

    End Class

End Namespace

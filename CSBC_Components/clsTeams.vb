Imports CSBC.Components.Security
Imports System.Security.Cryptography
Namespace CSBC.Components.Season
    Public Class ClsTeams
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal
        Public Property TeamId() As Integer
            Get
                TeamId = stRowData.TeamId
            End Get
            Set(ByVal value As Integer)
                stRowData.TeamId = value
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

        Public Property CompanyID() As Integer
            Get
                CompanyID = stRowData.CompanyID
            End Get
            Set(ByVal value As Integer)
                stRowData.CompanyID = value
            End Set
        End Property

        Public Property DivisionID() As Integer
            Get
                DivisionID = stRowData.DivisionID
            End Get
            Set(ByVal value As Integer)
                stRowData.DivisionID = value
            End Set
        End Property

        Public Property TeamName() As String
            Get
                TeamName = stRowData.TeamName
            End Get
            Set(ByVal value As String)
                stRowData.TeamName = value
            End Set
        End Property

        Public Property TeamNumber() As String
            Get
                TeamNumber = stRowData.TeamNumber
            End Get
            Set(ByVal value As String)
                stRowData.TeamNumber = value
            End Set
        End Property

        Public Property CoachID() As Integer
            Get
                CoachID = stRowData.CoachID
            End Get
            Set(ByVal value As Integer)
                stRowData.CoachID = value
            End Set
        End Property

        Public Property CoCoachID() As Integer
            Get
                CoCoachID = stRowData.CoCoachID
            End Get
            Set(ByVal value As Integer)
                stRowData.CoCoachID = value
            End Set
        End Property

        Public Property SponsorID() As Integer
            Get
                SponsorID = stRowData.SponsorID
            End Get
            Set(ByVal value As Integer)
                stRowData.SponsorID = value
            End Set
        End Property

        Public Property TeamColorID() As Integer
            Get
                TeamColorID = stRowData.TeamColorID
            End Get
            Set(ByVal value As Integer)
                stRowData.TeamColorID = value
            End Set
        End Property

        Public Property CreatedUser() As String
            Get
                CreatedUser = stRowData.CreatedUser
            End Get
            Set(ByVal value As String)
                stRowData.CreatedUser = value
            End Set
        End Property

        Private Structure RowFields
            Friend TeamId As Integer
            Friend SeasonID As Integer
            Friend CompanyID As Integer
            Friend DivisionID As Integer
            Friend TeamName As String
            Friend TeamNumber As String
            Friend CoachID As Integer
            Friend CoCoachID As Integer
            Friend SponsorID As Integer
            Friend TeamColorID As Integer
            Friend CreatedUser As String
        End Structure

        Private stRowData As RowFields

        Public Sub UpdRow(ByVal iTeamId As Long, ByVal iCompanyID As Int32, ByVal iTimeZone As Int32)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "EXEC UPDTeam "
                sSQL += " @CompanyID = " & dbIntField(0, iCompanyID)
                sSQL += ", @SeasonID = " & dbIntField(0, SeasonID)
                sSQL += ", @TeamId = " & dbIntField(0, iTeamId)
                sSQL += ", @DivisionID = " & dbIntField(0, DivisionID)
                sSQL += ", @CoachID = " & dbIntField(0, CoachID)
                sSQL += ", @coCoachID = " & dbIntField(0, CoCoachID)
                sSQL += ", @SponsorID = " & dbIntField(0, SponsorID)
                sSQL += ", @TeamColorID = " & dbIntField(0, TeamColorID)
                sSQL += ", @TeamName = " & dbStrField("", TeamName)
                sSQL += ", @TeamNumber = " & dbStrField("", TeamNumber)
                sSQL += ", @User = " & dbStrField("", CreatedUser)
                sSQL += ", @CreateDate = " & sGlobal.TimeAdjusted(iTimeZone, Now()).ToString
                'TODO:: Company
                sSQL = "EXEC UPDTeam "
                sSQL += " @SeasonID = " & dbIntField(0, SeasonID)
                sSQL += ", @TeamId = " & dbIntField(0, iTeamId)
                sSQL += ", @DivisionID = " & dbIntField(0, DivisionID)
                sSQL += ", @CoachID = " & dbIntField(0, CoachID)
                sSQL += ", @coCoachID = " & dbIntField(0, CoCoachID)
                sSQL += ", @SponsorID = " & dbIntField(0, SponsorID)
                sSQL += ", @TeamColorID = " & dbIntField(0, TeamColorID)
                sSQL += ", @TeamName = " & dbStrField("", TeamName)
                sSQL += ", @TeamNumber = " & dbStrField("", TeamNumber)
                sSQL += ", @User = " & dbStrField("", CreatedUser)
                sSQL += ", @CreateDate = " & sGlobal.TimeAdjusted(iTimeZone, Now()).ToString
                dtResults = DB.ExecuteGetSQL(sSQL)
                TeamId = dtResults.Rows(0).Item("TeamId").ToString

            Catch ex As Exception
                Throw New Exception("ClsTeams:UpdRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub DELRow(ByVal iTeamId As Long, ByVal iCompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Teams where TeamId=" & iTeamId
                sSQL += " AND CompanyID = " & iCompanyID
                'TODO:: Company
                sSQL = "DELETE FROM Teams where TeamId=" & iTeamId
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsTeams:DELRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Function LoadDivisionTeams(ByVal iDivisionID As Int32, ByVal iCompanyID As Int32, ByVal iSeasonID As Int32, Optional ByVal bExcludeOthers As Boolean = False) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetDivTeams @ScheduleNO= " & iDivisionID & ", @SeasonID = " & iSeasonID & ", @CompanyID = " & iCompanyID
                'TODO:: Company
                sSQL = "EXEC GetDivisionTeams @ScheduleNO= " & iDivisionID & ", @SeasonID = " & iSeasonID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsTeams:LoadDivisionTeams::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function LoadTeam(ByVal iTeamID As Int32, ByVal iCompanyID As Int32, ByVal iSeasonID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetTeams "
                sSQL += " @TeamID = " & iTeamID
                sSQL += ", @CompanyID = " & iCompanyID
                sSQL += ", @SeasonID = " & iSeasonID
                'TODO:: Company
                sSQL = "EXEC GetTeams "
                sSQL += " @TeamID = " & iTeamID
                sSQL += ", @SeasonID = " & iSeasonID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsTeams:LoadTeam::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetTeamCount(ByVal iDivisionID As Int32, ByVal sTeamName As String, ByVal iCompanyID As Int32, ByVal iSeasonID As Int32) As Integer
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "SELECT count(*) as rCount From Teams WHERE DivisionID = " & iDivisionID
                sSQL += " AND Teams.SeasonID = " & iSeasonID
                sSQL += " AND TeamName = " & sGlobal.Quotes(sTeamName)
                sSQL += " AND Teams.CompanyID = " & iCompanyID
                'TODO:: Company
                sSQL = "SELECT count(*) as rCount From Teams WHERE DivisionID = " & iDivisionID
                sSQL += " AND Teams.SeasonID = " & iSeasonID
                sSQL += " AND TeamName = " & sGlobal.Quotes(sTeamName)
                dtResults = DB.ExecuteGetSQL(sSQL)
                GetTeamCount = dtResults.Rows(0).Item("rCount").ToString
            Catch ex As Exception
                Throw New Exception("ClsTeams:GetTeamCount::" & ex.Message)
            Finally
                DB = Nothing
                dtResults = Nothing
            End Try
        End Function

        Public Function GetPlayersCount(ByVal iDivisionID As Int32, ByVal iCompanyID As Int32, ByVal iSeasonID As Int32) As Integer
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "SELECT count(*) as PlayersCount From Players WHERE DivisionID = " & iDivisionID
                sSQL += " AND SeasonID = " & iSeasonID
                sSQL += " AND CompanyID = " & iCompanyID
                'TODO:: Company
                sSQL = "SELECT count(*) as PlayersCount From Players WHERE DivisionID = " & iDivisionID
                sSQL += " AND SeasonID = " & iSeasonID
                dtResults = DB.ExecuteGetSQL(sSQL)
                GetPlayersCount = dtResults.Rows(0).Item("PlayersCount").ToString
            Catch ex As Exception
                Throw New Exception("ClsTeams:GetPlayersCount::" & ex.Message)
            Finally
                DB = Nothing
                dtResults = Nothing
            End Try
        End Function

        Private Function dbIntField(ByVal defautValue As Integer, Optional ByVal FieldValue As Integer = -1) As Integer
            If FieldValue = -1 Then
                dbIntField = defautValue
            Else
                dbIntField = FieldValue
            End If
        End Function

        Private Function dbStrField(ByVal defautValue As String, Optional ByVal FieldValue As String = "") As String
            If FieldValue = "" Then
                dbStrField = sGlobal.Quo(defautValue)
            Else
                If FieldValue = "" Then
                    dbStrField = ""
                Else
                    dbStrField = sGlobal.Quotes(FieldValue)
                End If
            End If
        End Function

        Private Function dbBoolField(ByVal defautValue As Integer, Optional ByVal FieldValue As Boolean = -2) As Int32
            If FieldValue = -2 Then
                dbBoolField = defautValue
            Else
                dbBoolField = FieldValue
            End If
        End Function

        Private Function dbDateField(ByVal defautValue As String, Optional ByVal FieldValue As String = "") As String
            If Not IsDate(FieldValue) Or FieldValue = "12:00:00 AM" Then
                dbDateField = defautValue
            Else
                dbDateField = sGlobal.Quo(FieldValue)
            End If
        End Function
    End Class
End Namespace

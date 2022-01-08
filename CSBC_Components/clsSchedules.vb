Imports CSBC.Components.Security
Namespace CSBC.Components.Season
    Public Class ClsSchedules
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal

        Public Function GetGames(ByVal iCompanyID As Int32, ByVal iSeasonID As Int32, ByVal iDivisionID As Int32, ByVal iTeam As Int32, ByVal sDivDesc As String, ByVal sTeamDesc As String) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC DivGames "
                If iDivisionID > 0 Then
                    sSQL += " @ScheduleNo = " & iDivisionID
                    If sTeamDesc <> "ALL TEAMS" Then
                        sSQL += ", @Div = " & sGlobal.Quo(sDivDesc)
                        sSQL += ", @TeamNbr = " & iTeam
                    End If
                Else
                    If sTeamDesc <> "ALL TEAMS" Then
                        sSQL += "  @Div = " & sGlobal.Quo(sDivDesc)
                        sSQL += ", @TeamNbr = " & iTeam
                    End If
                End If
                'sSQL += ", @SeasonName = " & sGlobal.Quo(sSeasonName)
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsSchedules:GetGames::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function
    End Class
End Namespace

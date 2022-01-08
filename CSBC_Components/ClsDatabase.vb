Imports System.Data.SqlClient
Namespace CSBC.Components.Security
    Public Class ClsDatabase
        Private sSQL As String
        'Private rdr As SqlClient.SqlDataReader
        Private CN As SqlConnection
        Private sGlobal As New CSBC.Components.ClsGlobal
        'Public iRow As Integer = 0
        Private CNString As String = Configuration.ConfigurationSettings.AppSettings("MyCN")
        Private ServerTimeAdj As Int32 = Configuration.ConfigurationSettings.AppSettings("ServerTime")

        'Public ReadOnly Property CNString() As String
        '    Get
        '        ' CNString = "Data Source=premSQL2b.brinkster.com;User Id=mannyrosa1;Password=rosa7057;Initial Catalog=mannyrosa1;"
        '        CNString = "Data Source = sknet61.gonewithewind.com,25000; Initial Catalog=C3089_csbcSQL;UID=C3089_webSQL;pwd=sqlMr7057"
        '    End Get
        'End Property

        Public Function AccessType(ByVal UserCode As Long, ByVal sSeasonId As Integer, ByVal sScreen As String) As DataTable
            Dim DB As New ClsDatabase

            Try
                sSQL = "exec GetAccess @UserCode = " & UserCode
                sSQL = sSQL + ", @Screen = " & sGlobal.Quo(sScreen)
                sSQL = sSQL + ", @SeasonId = " & sSeasonId

                AccessType = DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsDatabase:AccessType::" & ex.Message)
            Finally
                CN = Nothing
            End Try
        End Function

        Public Function ExecuteGetID(ByVal sSQL As String) As Int32
            Dim dtResults = New DataTable
            CN = New SqlConnection
            CN.ConnectionString = CNString
            CN.Open()
            Dim myAdapter = New SqlDataAdapter(sSQL, CN)
            Try
                myAdapter.Fill(dtResults)
                myAdapter.Dispose()
                myAdapter = Nothing
                Return dtResults.Rows(0).Item(0)
            Catch ex As Exception
                Throw New Exception("ClsDatabase:ExecuteGetID::" & ex.Message)
            Finally
                CN.Close()
                CN = Nothing
            End Try
            Return dtResults
        End Function

        'Public Function ExecuteGetSQL(ByVal sSQL As String) As SqlDataReader
        '    CN = New SqlConnection
        '    CN.ConnectionString = CNString
        '    CN.Open()
        '    Try
        '        Dim selectCMD As SqlCommand = New SqlCommand(sSQL, CN)
        '        rdr = selectCMD.ExecuteReader
        '        Return rdr
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        '    Return rdr
        '    CN.Close()
        '    CN = Nothing

        'End Function

        Public Function ExecuteGetSQL(ByVal sSQL As String) As DataTable
            Dim dtResults = New DataTable
            CN = New SqlConnection
            CN.ConnectionString = CNString
            CN.Open()
            Dim myAdapter = New SqlDataAdapter(sSQL, CN)
            Try
                myAdapter.Fill(dtResults)
                myAdapter.Dispose()
                myAdapter = Nothing
                Return dtResults
            Catch ex As Exception
                Throw New Exception("ClsDatabase:ExecuteGetSQL::" & ex.Message)
            Finally
                CN.Close()
                CN = Nothing
            End Try
            Return dtResults
        End Function

        Public Sub ExecuteUpdSQL(ByVal sSQL As String)
            CN = New SqlConnection
            CN.ConnectionString = CNString
            CN.Open()
            Dim selectCMD As SqlCommand = New SqlCommand(sSQL, CN)
            Try
                selectCMD.ExecuteNonQuery()
                CN.Close()
            Catch ex As Exception
                Throw New Exception("ClsDatabase:ExecuteUpdSQL::" & ex.Message)
            Finally
                selectCMD = Nothing
                CN.Close()
                CN = Nothing
            End Try
        End Sub
    End Class

End Namespace

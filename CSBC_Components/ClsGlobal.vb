
Namespace CSBC.Components
    Public Enum eSQLType
        READ = 1
        ADD = 2
        DELETE = 3
        UPDATE = 4
    End Enum

    Public Enum ePhoneType
        NONE = 0
        HOME = 1
        CELL = 2
        WORK = 3
    End Enum

    Public Enum eTimeZone
        Eastern = 1
        Central = 2
        Mountain = 3
        Pacific = 4
    End Enum

    Public Class ClsGlobal
        Private ServerTimeAdj As Int32 = System.Configuration.ConfigurationSettings.AppSettings("ServerTime")

        Public Function Quotes(ByVal InString As String) As String
            Dim NewString As String
            NewString = Replace(InString, "'", "''")
            Return "'" & UCase(NewString) & "'"
        End Function

        Public Function Quo(ByVal InString As String) As String
            Dim NewString As String
            NewString = Replace(InString, "'", "''")
            Return "'" & NewString & "'"
        End Function

        Public Function TimeAdjusted(ByVal iTimeZone As Int32, ByVal dDatetime As DateTime) As DateTime
            'The server timezones are the same as the company timezones
            'When the server is in eastern and the company in pacific, the adjustment is 3 
            'When the server is in central and company is in eastern the adjustment is -1
            TimeAdjusted = DateAdd(DateInterval.Hour, ServerTimeAdj - iTimeZone, dDatetime)
        End Function

    End Class
End Namespace

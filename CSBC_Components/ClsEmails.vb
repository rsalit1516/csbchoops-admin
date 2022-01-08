Imports CSBC.Components.Security
Namespace CSBC.Components.Profile
    Public Class ClsEmails
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal

        Public Property HouseId() As Long
            Get
                HouseId = stRowData.HouseId
            End Get
            Set(ByVal value As Long)
                stRowData.HouseId = value
            End Set
        End Property

        Public Property SeasonId() As Long
            Get
                SeasonId = stRowData.SeasonId
            End Get
            Set(ByVal value As Long)
                stRowData.SeasonId = value
            End Set
        End Property

        Public Property EmailAddress() As String
            Get
                EmailAddress = stRowData.EmailAddress
            End Get
            Set(ByVal value As String)
                stRowData.EmailAddress = value
            End Set
        End Property

        Private Structure RowFields
            Friend HouseId As Integer
            Friend SeasonId As String
            Friend EmailAddress As String
        End Structure

        Private stRowData As RowFields

        Public Sub UpdEmail(ByVal RowId As Long, ByVal CompanyID As Int32)
            Call DELEmail(RowId, SeasonId, CompanyID)
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC UPDEmail "
                sSQL += " @HouseId=" & RowId
                sSQL += ", @Email = " & sGlobal.Quotes(EmailAddress)
                sSQL += ", @SeasonId = " & SeasonId
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub DELEmail(ByVal RowId As Long, ByVal SeasonID As Int32, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Emails where HouseId = " & RowId
                sSQL += " AND SeasonID = " & SeasonID
                sSQL += " AND CompanyID = " & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub
    End Class
End Namespace

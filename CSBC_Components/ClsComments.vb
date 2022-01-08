Imports CSBC.Components.Security
Namespace CSBC.Components.Website
    Public Class ClsComments
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal

        Public Property CommentID() As Long
            Get
                CommentID = stRowData.CommentId
            End Get
            Set(ByVal value As Long)
                stRowData.CommentId = value
            End Set
        End Property

        Public Property CommentType() As String
            Get
                CommentType = stRowData.CommentType
            End Get
            Set(ByVal value As String)
                stRowData.CommentType = value
            End Set
        End Property

        Public Property LinkId() As Long
            Get
                LinkId = stRowData.LinkId
            End Get
            Set(ByVal value As Long)
                stRowData.LinkId = value
            End Set
        End Property

        Public Property Comment() As String
            Get
                Comment = stRowData.Comment
            End Get
            Set(ByVal value As String)
                stRowData.Comment = value
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
            Friend CommentId As Integer
            Friend CommentType As String
            Friend LinkId As Integer
            Friend Comment As String
            Friend CreatedUser As String
        End Structure

        Private stRowData As RowFields

        Public Sub DELRow(ByVal Id As Long, ByVal HouseId As Long, ByVal sType As String, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Comments where "
                If Id = 0 Then
                    sSQL += " CommentType = " & sGlobal.Quo(sType) & " and LinkId=" & HouseId
                Else
                    sSQL += " CommentId = " & Id
                End If
                sSQL += " AND CompanyID = " & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Function GetRecords(ByVal RowId As Long, ByVal sType As String, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT * FROM Comments WHERE CommentType= " & sGlobal.Quo(sType)
                sSQL += " AND LinkId = " & RowId
                sSQL += " AND CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub UpdRow(ByVal RowId As Long)
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC UPDComment "
                sSQL += " @CommentId=" & RowId
                sSQL += ", @CommentType = " & sGlobal.Quotes(CommentType)
                sSQL += ", @LinkId = " & LinkId
                sSQL += ", @Comment = " & sGlobal.Quotes(Comment)
                sSQL += ", @User = " & sGlobal.Quotes(CreatedUser)
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Sub UpdRow(p1 As Object, p2 As Object)
            Throw New NotImplementedException
        End Sub

        Function GetRecords(p1 As Object, p2 As Object, p3 As Object, p4 As Object) As DataTable
            Throw New NotImplementedException
        End Function

    End Class
End Namespace

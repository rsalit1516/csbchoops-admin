Imports CSBC.Components.Security
Namespace CSBC.Components.Website
    Public Class ClsContent
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal

        Public Property cntId() As Long
            Get
                cntId = stRowData.cntId
            End Get
            Set(ByVal value As Long)
                stRowData.cntId = value
            End Set
        End Property


        Public Property CompanyId() As Int32
            Get
                CompanyId = stRowData.CompanyId
            End Get
            Set(ByVal value As Int32)
                stRowData.CompanyId = value
            End Set
        End Property

        Public Property cntScreen() As String
            Get
                cntScreen = stRowData.cntScreen
            End Get
            Set(ByVal value As String)
                stRowData.cntScreen = value
            End Set
        End Property

        Public Property cntSeq() As Integer
            Get
                cntSeq = stRowData.cntSeq
            End Get
            Set(ByVal value As Integer)
                stRowData.cntSeq = value
            End Set
        End Property

        Public Property LineText() As String
            Get
                LineText = stRowData.LineText
            End Get
            Set(ByVal value As String)
                stRowData.LineText = value
            End Set
        End Property

        Public Property Bold() As Byte
            Get
                Bold = stRowData.Bold
            End Get
            Set(ByVal value As Byte)
                stRowData.Bold = value
            End Set
        End Property

        Public Property UnderLn() As Byte
            Get
                UnderLn = stRowData.UnderLn
            End Get
            Set(ByVal value As Byte)
                stRowData.UnderLn = value
            End Set
        End Property

        Public Property Italic() As Byte
            Get
                Italic = stRowData.Italic
            End Get
            Set(ByVal value As Byte)
                stRowData.Italic = value
            End Set
        End Property

        Public Property FontSize() As String
            Get
                FontSize = stRowData.FontSize
            End Get
            Set(ByVal value As String)
                stRowData.FontSize = value
            End Set
        End Property

        Public Property FontColor() As String
            Get
                FontColor = stRowData.FontColor
            End Get
            Set(ByVal value As String)
                stRowData.FontColor = value
            End Set
        End Property

        Public Property Link() As String
            Get
                Link = stRowData.Link
            End Get
            Set(ByVal value As String)
                stRowData.Link = value
            End Set
        End Property

        Public Property StartDate() As Date
            Get
                StartDate = stRowData.StartDate
            End Get
            Set(ByVal value As Date)
                stRowData.StartDate = value
            End Set
        End Property

        Public Property EndDate() As Date
            Get
                EndDate = stRowData.EndDate
            End Get
            Set(ByVal value As Date)
                stRowData.EndDate = value
            End Set
        End Property

        Public ReadOnly Property CreatedUser() As String
            Get
                CreatedUser = stRowData.CreatedUser
            End Get
        End Property

        Private Structure RowFields
            Friend CompanyId As Int32
            Friend cntId As Integer
            Friend cntScreen As String
            Friend cntSeq As Integer
            Friend LineText As String
            Friend Bold As Byte
            Friend UnderLn As Byte
            Friend Italic As Byte
            Friend FontSize As String
            Friend FontColor As String
            Friend Link As String
            Friend StartDate As Date
            Friend EndDate As Date
            Friend CreatedUser As String
        End Structure

        Private stRowData As RowFields

        Public Function Getdata(ByVal sScreenName As String, ByVal FromDate As DateTime, Optional ByVal RowId As Long = 0) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT * FROM Content"

                If RowId = 0 Then
                    sSQL += " where cntScreen = " & sGlobal.Quotes(sScreenName)
                Else
                    sSQL += " WHERE cntId = " & RowId
                End If
                If RowId = 0 Then sSQL += " order by cntSeq "

                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsContent:Getdata::" & ex.Message)
            Finally
                DB = Nothing
            End Try

        End Function

        Public Function GetContent(ByVal iCompanyID As Int32, ByVal sScreenName As String, ByVal dDate As DateTime) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetContent "
                sSQL += " @Screen = " & dbStrField("", sScreenName)
                sSQL += ", @dDate= " & dbDateField("null", dDate)
                sSQL += ", @CompanyID= " & dbIntField(0, iCompanyID)
                'TODO:: Company
                sSQL = "EXEC GetContent "
                sSQL += " @Screen = " & dbStrField("", sScreenName)
                sSQL += ", @dDate= " & dbDateField("null", dDate)
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsContent:GetContent::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetContentNodate(ByVal iCompanyID As Int32, ByVal sScreenName As String) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetContent "
                sSQL += " @Screen = " & dbStrField("", sScreenName)
                sSQL += ", @CompanyID= " & dbIntField(0, iCompanyID)
                'TODO:: Company
                sSQL = "EXEC GetContent "
                sSQL += " @Screen = " & dbStrField("", sScreenName)
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsContent:GetContentNodate::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub DELRow(ByVal RowId As Long)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Content where cntId = " & RowId
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsContent:DELRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Function UpdRow(ByVal RowId As Long) As Long
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC UpdContent "
                sSQL += " @cntId=" & RowId
                sSQL += ", @Seq = " & cntSeq
                sSQL += ", @Bold = " & Bold
                sSQL += ", @FontColor = " & FontColor
                sSQL += ", @FontSize = " & FontSize
                sSQL += ", @Italic = " & Italic
                sSQL += ", @LineText = " & sGlobal.Quo(LineText)
                sSQL += ", @Link = " & sGlobal.Quo(Link)
                sSQL += ", @UnderLn = " & UnderLn
                sSQL += ", @StartDate = " & sGlobal.Quo(StartDate)
                sSQL += ", @EndDate = " & sGlobal.Quo(EndDate)
                sSQL += ", @User = " & sGlobal.Quo(CreatedUser)
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsContent:UpdRow::" & ex.Message)
            Finally
                DB = Nothing
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

        Function GetDates(p1 As Object, MessScreen As String) As DataTable
            Throw New NotImplementedException
        End Function

        Function GetContent(p1 As Object, p2 As Object, p3 As Object, p4 As Object) As DataTable
            Throw New NotImplementedException
        End Function

        Sub UpdRow(p1 As Integer, p2 As Object)
            Throw New NotImplementedException
        End Sub

        Sub DELRow(RowID As Long, p2 As Object)
            Throw New NotImplementedException
        End Sub

        Function GetContent(p1 As Object, p2 As Object, p3 As Object, p4 As Object, RowID As Long) As DataTable
            Throw New NotImplementedException
        End Function

    End Class
End Namespace

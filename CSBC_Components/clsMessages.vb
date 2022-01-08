Imports CSBC.Components.Security
Namespace CSBC.Components.Website
    Public Class clsMessages
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal

        Public Property Message() As String
            Get
                Message = stRowData.Message
            End Get
            Set(ByVal value As String)
                stRowData.Message = value
            End Set
        End Property

        Public Property MessageCont() As Integer
            Get
                MessageCont = stRowData.MessageCont
            End Get
            Set(ByVal value As Integer)
                stRowData.MessageCont = value
            End Set
        End Property

        Public Structure RowFields
            Public Message As String
            Public MessageCont As Integer
        End Structure

        Public stRowData As RowFields

        Public Sub GetRecords(ByVal CompanyID As Integer, ByVal ScreenName As String)
            'Dim DB As New ClsDatabase
            'Dim dtResults As DataTable
            'Try

            '    sSQL = "EXEC CheckEncryption @UserName = " & sGlobal.Quo(sUserName) 'Check for encryption
            '    dtResults = DB.ExecuteGetSQL(sSQL)
            '    If dtResults.Rows.Count > 0 Then
            '        If dtResults.Rows(0).Item("PWD").ToString = False Then  'Not encripted
            '            sSQL = "EXEC CheckLoginNE @UserName = " & sGlobal.Quo(sUserName) & ", @Pword = " & sGlobal.Quo(sPwd) & ", @PassWord = " & sGlobal.Quo(HashPassword(sPwd)) 'Create encripted password
            '            DB.ExecuteUpdSQL(sSQL)
            '        End If
            '        dtResults.Clear()
            '        sSQL = "EXEC CheckLogin @UserName = " & sGlobal.Quo(sUserName) & ", @PassWord = " & sGlobal.Quo(HashPassword(sPwd)) 'Get User information
            '        dtResults = DB.ExecuteGetSQL(sSQL)
            '        If dtResults.Rows.Count > 0 Then
            '            UserID = dtResults.Rows(0).Item("UserID").ToString
            '            HouseID = dtResults.Rows(0).Item("HouseID").ToString
            '            UserName = dtResults.Rows(0).Item("UserName").ToString
            '            Usertype = dtResults.Rows(0).Item("Usertype").ToString
            '        End If
            '    End If
            'Catch ex As Exception
            '    Throw New Exception("ClsUsers:GetUser::" & ex.Message)
            'Finally
            '    DB = Nothing
            '    dtResults = Nothing
            'End Try

        End Sub

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

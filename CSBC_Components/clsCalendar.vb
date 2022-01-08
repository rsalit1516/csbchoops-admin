Imports CSBC.Components.Security
Namespace CSBC.Components.Website
    Public Class clsCalendar
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

        Public Property sTitle() As String
            Get
                sTitle = stRowData.sTitle
            End Get
            Set(ByVal value As String)
                stRowData.sTitle = value
            End Set
        End Property

        Public Property sDesc() As String
            Get
                sDesc = stRowData.sDesc
            End Get
            Set(ByVal value As String)
                stRowData.sDesc = value
            End Set
        End Property

        Public Property dDate() As DateTime
            Get
                sDesc = stRowData.dDate
            End Get
            Set(ByVal value As DateTime)
                stRowData.dDate = value
            End Set
        End Property

        Public Structure RowFields
            Public CompanyID As Integer
            Public sDesc As String
            Public sTitle As String
            Public dDate As DateTime

        End Structure

        Public stRowData As RowFields

        Public Function GetCalendar(ByVal CompanyID As Int32, ByVal bDisplay As Boolean, ByVal iTimeZone As Int32, Optional ByVal RowID As Long = 0) As DataTable
            Dim DB As New ClsDatabase
            sSQL = "select top 5 ID, rtrim(convert(char, dDate, 107)) + ': ' +  sTitle + ' ' + sSubTitle as Title from calendar "
            sSQL += " Where CompanyID =  " & CompanyID
            sSQL += " AND dDate > = convert(char, " & sGlobal.TimeAdjusted(iTimeZone, Now()).ToString & ", 107) "
            'TODO:: Company
            sSQL = "select top 5 ID, rtrim(convert(char, dDate, 107)) + ': ' +  sTitle + ' ' + sSubTitle as Title from calendar "
            sSQL += " WHERE dDate > = convert(char, '" & sGlobal.TimeAdjusted(iTimeZone, Now()).ToString & "', 107) "
            If bDisplay = True Then sSQL += " AND [Display] = 1"
            If RowID > 0 Then
                sSQL += " AND ID = " & RowID
            Else
                sSQL += " ORDER BY dDate"
            End If
            Try
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("GetCalendar: " & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetFullCalendar(ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            sSQL = "select iYear, iMonth, iDay, sTitle from calendar "
            sSQL += " Where CompanyID =  " & CompanyID
            'TODO:: Company
            sSQL = "select iYear, iMonth, iDay, sTitle from calendar "
            Try
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("GetFullCalendar: " & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub GetDayEvent(ByVal CompanyID As Int32, ByVal iMonth As Integer, ByVal iDay As Integer, ByVal iYear As Integer)
            Dim dtResults As DataTable
            Dim DB As New ClsDatabase
            sSQL = "select iYear, iMonth, iDay, sTitle + '<BR>' + sSubTitle as sTitle, dDate, "
            sSQL += " isnull((sDesc1 + '<BR>' + sDesc2 + '<BR>' + sDesc3), '') as sDesc from Calendar"
            sSQL += " WHERE iMonth = " & iMonth
            sSQL += " AND iDay = " & iDay
            sSQL += " AND iYear = " & iYear
            'TODO:: Company
            sSQL = "select iYear, iMonth, iDay, sTitle + '<BR>' + sSubTitle as sTitle, dDate, "
            sSQL += " isnull((sDesc1 + '<BR>' + sDesc2 + '<BR>' + sDesc3), '') as sDesc from Calendar"
            sSQL += " WHERE iMonth = " & iMonth
            sSQL += " AND iDay = " & iDay
            sSQL += " AND iYear = " & iYear

            Try
                dtResults = DB.ExecuteGetSQL(sSQL)
                If dtResults.Rows.Count > 0 Then
                    sTitle = dtResults.Rows(0).Item("sTitle").ToString
                    sDesc = dtResults.Rows(0).Item("sDesc").ToString
                    dDate = dtResults.Rows(0).Item("dDate").ToString
                End If
            Catch ex As Exception
                Throw New Exception("GetDayEvent: " & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        '    Public Sub AddDirector(ByVal CompanyID As Int32)
        '        Dim DB As New ClsDatabase
        '        Dim iTime As DateTime
        '        Dim dtResults As DataTable
        '        iTime = Now
        '        Try
        '            sSQL = "EXEC AddDirector @PeopleID = " & PeopleID
        '            sSQL += ", @Title = " & sGlobal.Quotes(Title)
        '            If PhoneType = ePhoneType.NONE Then sSQL += ", @PhonePref = 'NONE'"
        '            If PhoneType = ePhoneType.HOME Then sSQL += ", @PhonePref = 'HOME'"
        '            If PhoneType = ePhoneType.CELL Then sSQL += ", @PhonePref = 'CELL'"
        '            If PhoneType = ePhoneType.WORK Then sSQL += ", @PhonePref = 'WORK'"
        '            If EmailPref = True Then
        '                sSQL += ", @EmailPref = 1"
        '            Else
        '                sSQL += ", @EmailPref = 0"
        '            End If
        '            sSQL += ", @User = " & UserID
        '            sSQL += ", @CompanyID = " & CompanyID
        '            DB.ExecuteUpdSQL(sSQL)
        '            dtResults = DB.ExecuteGetSQL("SELECT max(ID) as ID from Directors where Title = " & dbStrField("", Title) & " AND PeopleID = " & dbIntField(0, PeopleID) & " AND CreatedUser = " & dbStrField("", UserID) & " AND CompanyID = " & dbIntField(0, CompanyID))
        '            DirectorID = dtResults.Rows(0).Item("ID").ToString
        '        Catch ex As Exception
        '            Throw New Exception("AddDirector: " & ex.Message)
        '        Finally
        '            DB = Nothing
        '        End Try
        '    End Sub

        '    Public Sub DELRow(ByVal RowID As Long, ByVal CompanyID As Int32)
        '        Dim DB As New ClsDatabase
        '        Try
        '            sSQL = "EXEC DelDirector @ID=" & RowID
        '            sSQL += ", @CompanyID = " & CompanyID
        '            DB.ExecuteUpdSQL(sSQL)
        '        Catch ex As Exception
        '            Throw New Exception("DELRow: " & ex.Message)
        '        Finally
        '            DB = Nothing
        '        End Try
        '    End Sub

        '    Public Sub UpdRow(ByVal RowID As Long, ByVal CompanyID As Int32)
        '        Dim DB As New ClsDatabase
        '        Try
        '            sSQL = "Update Directors SET"
        '            sSQL += " Title = " & sGlobal.Quotes(Title)
        '            If EmailPref = True Then
        '                sSQL += ", EmailPref = 1"
        '            Else
        '                sSQL += ", EmailPref = 0"
        '            End If
        '            If PhoneType = ePhoneType.NONE Then sSQL += ", PhonePref = 'NONE'"
        '            If PhoneType = ePhoneType.HOME Then sSQL += ", PhonePref = 'HOME'"
        '            If PhoneType = ePhoneType.CELL Then sSQL += ", PhonePref = 'CELL'"
        '            If PhoneType = ePhoneType.WORK Then sSQL += ", PhonePref = 'WORK'"
        '            sSQL += " where ID=" & RowID
        '            sSQL += " AND CompanyID = " & CompanyID
        '            DB.ExecuteUpdSQL(sSQL)
        '        Catch ex As Exception
        '            Throw New Exception("UpdRow: " & ex.Message)
        '        Finally
        '            DB = Nothing
        '        End Try
        '    End Sub

        '    Public Sub updDirectorSeq(ByVal iNewSeq As Integer, ByVal CompanyID As Int32)
        '        Dim DB As New ClsDatabase
        '        Try
        '            sSQL = "EXEC updDirectorSeq @NewSeq = " & iNewSeq
        '            sSQL += ", @CompanyID = " & CompanyID
        '            DB.ExecuteUpdSQL(sSQL)
        '        Catch ex As Exception
        '            Throw New Exception("updDirectorSeq: " & ex.Message)
        '        Finally
        '            DB = Nothing
        '        End Try
        '    End Sub

        '    Private Function dbIntField(ByVal defautValue As Integer, Optional ByVal FieldValue As Integer = -1) As Integer
        '        If FieldValue = -1 Then
        '            dbIntField = defautValue
        '        Else
        '            dbIntField = FieldValue
        '        End If
        '    End Function

        '    Private Function dbStrField(ByVal defautValue As String, Optional ByVal FieldValue As String = "") As String
        '        If FieldValue = "" Then
        '            dbStrField = sGlobal.Quo(defautValue)
        '        Else
        '            If FieldValue = "" Then
        '                dbStrField = ""
        '            Else
        '                dbStrField = sGlobal.Quo(FieldValue)
        '            End If
        '        End If
        '    End Function

        '    Private Function dbBoolField(ByVal defautValue As Integer, Optional ByVal FieldValue As Boolean = -2) As Int32
        '        If FieldValue = -2 Then
        '            dbBoolField = defautValue
        '        Else
        '            dbBoolField = FieldValue
        '        End If
        '    End Function

        '    Private Function dbDateField(ByVal defautValue As String, Optional ByVal FieldValue As String = "") As String
        '        If Not IsDate(FieldValue) Or FieldValue = "12:00:00 AM" Then
        '            dbDateField = defautValue
        '        Else
        '            dbDateField = sGlobal.Quo(FieldValue)
        '        End If
        '    End Function
    End Class
End Namespace


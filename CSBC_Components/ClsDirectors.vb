Imports CSBC.Components.Security
Namespace CSBC.Components.Volunteers
    Public Class ClsDirectors
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

        Public Property DirectorID() As Integer
            Get
                DirectorID = stRowData.DirectorID
            End Get
            Set(ByVal value As Integer)
                stRowData.DirectorID = value
            End Set
        End Property

        Public Property UserID() As Integer
            Get
                UserID = stRowData.UserID
            End Get
            Set(ByVal value As Integer)
                stRowData.UserID = value
            End Set
        End Property

        Public Property PeopleID() As Integer
            Get
                PeopleID = stRowData.PeopleID
            End Get
            Set(ByVal value As Integer)
                stRowData.PeopleID = value
            End Set
        End Property

        Public Property Title() As String
            Get
                Title = stRowData.Title
            End Get
            Set(ByVal value As String)
                stRowData.Title = value
            End Set
        End Property

        Public Property PhoneType() As Integer
            Get
                PhoneType = stRowData.PhoneType
            End Get
            Set(ByVal value As Integer)
                stRowData.PhoneType = value
            End Set
        End Property

        Public Property EmailPref() As Boolean
            Get
                EmailPref = stRowData.EmailPref
            End Get
            Set(ByVal value As Boolean)
                stRowData.EmailPref = value
            End Set
        End Property

        Public Structure RowFields
            Public CompanyID As Integer
            Public DirectorID As Integer
            Public UserID As Integer
            Public PeopleID As Integer
            Public Title As String
            Public PhoneType As Integer
            Public EmailPref As Boolean
        End Structure

        Public stRowData As RowFields

        Public Function GetDirectors(ByVal CompanyID As Int32, Optional ByVal RowID As Long = 0) As DataTable
            Dim DB As New ClsDatabase
            sSQL = "SELECT Directors.ID, Title, (People.LastName + ' ' +  People.FirstName) as Name, Households.Phone, Seq,"
            sSQL += " CASE PhonePref WHEN 'Home' THEN Households.Phone"
            sSQL += " WHEN 'Cell' THEN People.CellPhone"
            sSQL += " WHEN 'Work' THEN People.WorkPhone"
            sSQL += " WHEN 'None' THEN '' END AS PhoneSelected,"
            sSQL += " People.CellPhone,	People.WorkPhone, Households.Email, Households.Address1, Households.City,"
            sSQL += " Households.State, Households.Zip, PhonePref, EmailPref"
            sSQL += " FROM People"
            sSQL += " INNER JOIN Directors ON People.PeopleID = Directors.PeopleID AND People.CompanyID = Directors.CompanyID"
            sSQL += " INNER JOIN Households ON People.HouseID = Households.HouseID AND People.CompanyID = Households.CompanyID"
            sSQL += " Where People.CompanyID =  " & CompanyID
            If RowID > 0 Then
                sSQL += " AND Directors.ID = " & RowID
            Else
                sSQL += " ORDER BY Seq"
            End If
            'TODO:: Company
            sSQL = "SELECT Directors.ID, Title, (People.LastName + ' ' +  People.FirstName) as Name, Households.Phone, Seq,"
            sSQL += " CASE PhonePref WHEN 'Home' THEN Households.Phone"
            sSQL += " WHEN 'Cell' THEN People.CellPhone"
            sSQL += " WHEN 'Work' THEN People.WorkPhone"
            sSQL += " WHEN 'None' THEN '' END AS PhoneSelected,"
            sSQL += " People.CellPhone,	People.WorkPhone, Households.Email, Households.Address1, Households.City,"
            sSQL += " Households.State, Households.Zip, PhonePref, EmailPref"
            sSQL += " FROM People"
            sSQL += " INNER JOIN Directors ON People.PeopleID = Directors.PeopleID"
            sSQL += " INNER JOIN Households ON People.MainHouseID = Households.HouseID "
            If RowID > 0 Then
                sSQL += " Where Directors.ID = " & RowID
            Else
                sSQL += " ORDER BY Seq"
            End If
            Try
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("GetDirectors: " & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetBoard(ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            sSQL = "EXEC GetBoardInfo "
            'TODO:: Company
            'ssql += ", @CompanyID = " & CompanyID
            Try
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("GetBoard: " & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub AddDirector(ByVal CompanyID As Int32, ByVal iTimeZone As Int32)
            Dim DB As New ClsDatabase
            Dim iTime As DateTime
            Dim dtResults As DataTable
            iTime = Now
            Try
                sSQL = "EXEC AddDirector @PeopleID = " & PeopleID
                sSQL += ", @Title = " & sGlobal.Quotes(Title)
                If PhoneType = ePhoneType.NONE Then sSQL += ", @PhonePref = 'NONE'"
                If PhoneType = ePhoneType.HOME Then sSQL += ", @PhonePref = 'HOME'"
                If PhoneType = ePhoneType.CELL Then sSQL += ", @PhonePref = 'CELL'"
                If PhoneType = ePhoneType.WORK Then sSQL += ", @PhonePref = 'WORK'"
                If EmailPref = True Then
                    sSQL += ", @EmailPref = 1"
                Else
                    sSQL += ", @EmailPref = 0"
                End If
                sSQL += ", @User = " & UserID
                sSQL += ", @Now = " & sGlobal.TimeAdjusted(iTimeZone, Now()).ToString
                sSQL += ", @CompanyID = " & CompanyID
                DB.ExecuteUpdSQL(sSQL)
                dtResults = DB.ExecuteGetSQL("SELECT max(ID) as ID from Directors where Title = " & dbStrField("", Title) & " AND PeopleID = " & dbIntField(0, PeopleID) & " AND CreatedUser = " & dbStrField("", UserID) & " AND CompanyID = " & dbIntField(0, CompanyID))
                DirectorID = dtResults.Rows(0).Item("ID").ToString
            Catch ex As Exception
                Throw New Exception("AddDirector: " & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub DELRow(ByVal RowID As Long, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC DelDirector @ID=" & RowID
                sSQL += ", @CompanyID = " & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("DELRow: " & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdRow(ByVal RowID As Long, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "Update Directors SET"
                sSQL += " Title = " & sGlobal.Quotes(Title)
                If EmailPref = True Then
                    sSQL += ", EmailPref = 1"
                Else
                    sSQL += ", EmailPref = 0"
                End If
                If PhoneType = ePhoneType.NONE Then sSQL += ", PhonePref = 'NONE'"
                If PhoneType = ePhoneType.HOME Then sSQL += ", PhonePref = 'HOME'"
                If PhoneType = ePhoneType.CELL Then sSQL += ", PhonePref = 'CELL'"
                If PhoneType = ePhoneType.WORK Then sSQL += ", PhonePref = 'WORK'"
                sSQL += " where ID=" & RowID
                sSQL += " AND CompanyID = " & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("UpdRow: " & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub updDirectorSeq(ByVal iNewSeq As Integer, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC updDirectorSeq @NewSeq = " & iNewSeq
                sSQL += ", @CompanyID = " & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("updDirectorSeq: " & ex.Message)
            Finally
                DB = Nothing
            End Try
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
                    dbStrField = sGlobal.Quo(FieldValue)
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

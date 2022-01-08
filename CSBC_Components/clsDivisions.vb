Imports CSBC.Components.Security
Namespace CSBC.Components.Season
    Public Class ClsDivisions
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal

        Public Property SeasonID() As Integer
            Get
                SeasonID = stRowData.SeasonID
            End Get
            Set(ByVal value As Integer)
                stRowData.SeasonID = value
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

        Public Property DirectorID() As Integer
            Get
                DirectorID = stRowData.DirectorID
            End Get
            Set(ByVal value As Integer)
                stRowData.DirectorID = value
            End Set
        End Property

        Public Property CoDirectorID() As Integer
            Get
                CoDirectorID = stRowData.CoDirectorID
            End Get
            Set(ByVal value As Integer)
                stRowData.CoDirectorID = value
            End Set
        End Property

        Public Property TeamID() As Integer
            Get
                TeamID = stRowData.TeamID
            End Get
            Set(ByVal value As Integer)
                stRowData.TeamID = value
            End Set
        End Property

        Public Property ScheduleNumber() As Integer
            Get
                ScheduleNumber = stRowData.ScheduleNumber
            End Get
            Set(ByVal value As Integer)
                stRowData.ScheduleNumber = value
            End Set
        End Property

        Public Property Div_Desc() As String
            Get
                Div_Desc = stRowData.Div_Desc
            End Get
            Set(ByVal value As String)
                stRowData.Div_Desc = value
            End Set
        End Property

        Public Property Notes() As String
            Get
                Notes = stRowData.Notes
            End Get
            Set(ByVal value As String)
                stRowData.Notes = value
            End Set
        End Property

        Public Property Gender() As String
            Get
                Gender = stRowData.Gender
            End Get
            Set(ByVal value As String)
                stRowData.Gender = value
            End Set
        End Property

        Public Property Gender2() As String
            Get
                Gender2 = stRowData.Gender2
            End Get
            Set(ByVal value As String)
                stRowData.Gender2 = value
            End Set
        End Property

        Public Property MinDate() As Date
            Get
                MinDate = stRowData.MinDate
            End Get
            Set(ByVal value As Date)
                stRowData.MinDate = value
            End Set
        End Property

        Public Property MaxDate() As Date
            Get
                MaxDate = stRowData.MaxDate
            End Get
            Set(ByVal value As Date)
                stRowData.MaxDate = value
            End Set
        End Property

        Public Property MinDate2() As Date
            Get
                MinDate2 = stRowData.MinDate2
            End Get
            Set(ByVal value As Date)
                stRowData.MinDate2 = value
            End Set
        End Property

        Public Property MaxDate2() As Date
            Get
                MaxDate2 = stRowData.MaxDate2
            End Get
            Set(ByVal value As Date)
                stRowData.MaxDate2 = value
            End Set
        End Property

        Public Property DraftVenue() As String
            Get
                DraftVenue = stRowData.DraftVenue
            End Get
            Set(ByVal value As String)
                stRowData.DraftVenue = value
            End Set
        End Property

        Public Property DraftDate() As Date
            Get
                DraftDate = stRowData.DraftDate
            End Get
            Set(ByVal value As Date)
                stRowData.DraftDate = value
            End Set
        End Property

        Public Property DraftTime() As String
            Get
                DraftTime = stRowData.DraftTime
            End Get
            Set(ByVal value As String)
                stRowData.DraftTime = value
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

        Public Structure RowFields
            Public SeasonID As Integer
            Public DivisionID As Integer
            Public DirectorID As Integer
            Public CoDirectorID As Integer
            Public TeamID As Integer
            Public ScheduleNumber As Integer
            Public Div_Desc As String
            Public Notes As String
            Public Gender As String
            Public Gender2 As String
            Public MinDate As Date
            Public MinDate2 As Date
            Public MaxDate As Date
            Public MaxDate2 As Date
            Public DraftVenue As String
            Public DraftDate As Date
            Public DraftTime As String
            Public CreatedUser As String
        End Structure

        Public stRowData As RowFields

        Public Function GetRecords(ByVal CompanyID As Int32, ByVal SeasonID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "exec GetDivisionsInfo "
                sSQL += " @SeasonID=" & SeasonID
                sSQL += ", @CompanyID = " & CompanyID
                'TODO:: Company
                sSQL = "exec GetDivisionsInfo "
                sSQL += " @SeasonID=" & SeasonID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsDivisions:GetRecords::" & ex.Message)
            Finally
                DB = Nothing
            End Try

        End Function

        Public Function GetDivision(ByVal CompanyID As Int32, ByVal SeasonID As Int32, ByVal PeopleID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "exec GetDivision "
                sSQL += " @iSeason =" & SeasonID
                'sSQL += ", @CompanyID = " & CompanyID
                sSQL += ", @iPeopleID = " & PeopleID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsDivisions:GetDivision::" & ex.Message)
            Finally
                DB = Nothing
            End Try

        End Function

        Public Function LoadDivision(ByVal DivisionID As Int32, ByVal CompanyID As Int32, ByVal SeasonID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT Divisions.DivisionID, Divisions.Div_Desc, Divisions.Gender, MinDate, MaxDate, Divisions.Gender2, MinDate2, MaxDate2, "
                sSQL += " People.AD, Households.Phone, People.Cellphone, Divisions.DraftVenue, DraftDate, DraftTime, Divisions.DirectorID "
                sSQL += " FROM Divisions LEFT JOIN People ON Divisions.DirectorID = People.PeopleID AND Divisions.CompanyID = People.CompanyID "
                sSQL += " LEFT JOIN Households ON People.HouseID = Households.HouseID AND People.CompanyID = Households.CompanyID "
                sSQL += " WHERE Divisions.SeasonID = " & SeasonID
                sSQL += " AND Divisions.CompanyID = " & CompanyID
                'TODO:: Company
                sSQL = "SELECT Divisions.DivisionID, Divisions.Div_Desc, Divisions.Gender, MinDate, MaxDate, Divisions.Gender2, MinDate2, MaxDate2, "
                sSQL += " People.AD, Households.Phone, People.Cellphone, Divisions.DraftVenue, DraftDate, DraftTime, Divisions.DirectorID "
                sSQL += " FROM Divisions LEFT JOIN People ON Divisions.DirectorID = People.PeopleID "
                sSQL += " LEFT JOIN Households ON People.HouseID = Households.HouseID "
                sSQL += " WHERE Divisions.SeasonID = " & SeasonID
                If DivisionID > 0 Then sSQL += " AND DivisionID = " & DivisionID
                sSQL += " ORDER BY Divisions.Gender DESC , Divisions.MinDate DESC"
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsDivisions:LoadDivision::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function DivisionAD(ByVal CompanyID As Int32, ByVal SeasonID As Int32, ByVal ScheduleNo As Integer, ByVal sUserName As String, ByVal sPwd As String) As Integer
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            'I NEED TO USE THE COMPANY ID IN THE QUERY
            Try
                sSQL = "SELECT COUNT(*) AS DivisionTeams "
                sSQL += " FROM teams T JOIN divisions D ON T.divisionid = d.divisionid AND T.CompanyID = D.CompanyID"
                sSQL += " JOIN scheduledivisions ON ScheduleName = div_desc "
                sSQL += " join People ON People.PeopleID = DirectorID AND People.CompanyID = D.CompanyID"
                sSQL += " JOIN Users U ON U.HouseID = People.HouseID AND People.CompanyID = U.CompanyID"
                sSQL += " where T.seasonid = " & SeasonID
                sSQL += " AND teamnumber > 0 AND schedulenumber = " & ScheduleNo
                sSQL += " AND T.CompanyID = " & CompanyID
                sSQL += " AND d.divisionid IN (SELECT D.DivisionID FROM Users U"
                sSQL += " LEFT JOIN People P ON U.HouseID = P.HouseID AND U.CompanyID = P.CompanyID"
                sSQL += "  		LEFT JOIN Divisions D ON P.PeopleID = D.DirectorID AND D.CompanyID = P.CompanyID"
                sSQL += "         and D.SeasonID = " & SeasonID
                sSQL += "     where U.UserName = " & sGlobal.Quo(sUserName)
                sSQL += " and U.PWord = " & sGlobal.Quo(sPwd)
                sSQL += " AND U.CompanyID = " & CompanyID & ")"
                'TODO:: Company
                sSQL = "SELECT COUNT(*) AS DivisionTeams "
                sSQL += " FROM teams T JOIN divisions D ON T.divisionid = d.divisionid"
                sSQL += " JOIN scheduledivisions ON ScheduleName = div_desc "
                sSQL += " join People ON People.PeopleID = DirectorID"
                sSQL += " JOIN Users U ON U.HouseID = People.MainHouseID"
                sSQL += " where T.seasonid = " & SeasonID
                sSQL += " AND teamnumber > 0 AND schedulenumber = " & ScheduleNo
                sSQL += " AND d.divisionid IN (SELECT D.DivisionID FROM Users U"
                sSQL += " LEFT JOIN People P ON U.HouseID = P.MainHouseID"
                sSQL += "  		LEFT JOIN Divisions D ON P.PeopleID = D.DirectorID"
                sSQL += "         and D.SeasonID = " & SeasonID
                sSQL += "     where U.UserName = " & sGlobal.Quo(sUserName)
                sSQL += " and U.PWord = " & sGlobal.Quo(sPwd) & ")"

                dtResults = DB.ExecuteGetSQL(sSQL)
                DivisionAD = dtResults.Rows(0).Item("DivisionTeams").ToString
            Catch ex As Exception
                Throw New Exception("ClsDivisions:DivisionAD::" & ex.Message)
            Finally
                DB = Nothing
            End Try

        End Function

        Public Function LoadDirector(ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT People.PeopleID, (People.LastName + ', ' + People.FirstName) as Name "
                sSQL += " FROM People WHERE People.AD=1 "
                sSQL += " AND CompanyID = " & CompanyID
                sSQL += " ORDER BY People.LastName, People.FirstName"
                'TODO:: Company
                sSQL = "SELECT People.PeopleID, (People.LastName + ', ' + People.FirstName) as Name "
                sSQL += " FROM People WHERE People.AD=1 "
                sSQL += " ORDER BY People.LastName, People.FirstName"
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsDivisions:LoadDirector::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetStanding(ByVal iDiv As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetStanding @ScheduleNumber = " & iDiv
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsDivisions:GetStanding::" & ex.Message)
            Finally
                DB = Nothing
            End Try

        End Function


        Public Sub UpdRow(ByVal RowId As Long, ByVal CompanyID As Int32, ByVal iTimeZone As Int32)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable

            sSQL = "EXEC UPDDivision "
            sSQL += " @Div_Desc = " & dbStrField("", Div_Desc)
            sSQL += ", @SeasonID = " & dbIntField(0, SeasonID)
            sSQL += ", @MinDate = " & dbDateField("null", MinDate)
            sSQL += ", @MaxDate = " & dbDateField("null", MaxDate)
            sSQL += ", @Gender = " & dbStrField("", Gender)
            sSQL += ", @MinDate2 = " & dbDateField("null", MinDate2)
            sSQL += ", @MaxDate2 = " & dbDateField("null", MaxDate2)
            sSQL += ", @Gender2 = " & dbStrField("", Gender2)
            sSQL += ", @DraftVenue = " & dbStrField("", DraftVenue)
            sSQL += ", @DraftDate = " & dbDateField("null", DraftDate)
            sSQL += ", @DraftTime = " & dbStrField("", DraftTime)
            sSQL += ", @DirectorID = " & dbIntField(0, DirectorID)
            sSQL += ", @CoDirectorID = " & dbIntField(0, CoDirectorID)
            sSQL += ", @CreatedDate = " & sGlobal.TimeAdjusted(iTimeZone, Now()).ToString
            sSQL += ", @CreatedUser = " & dbStrField("", CreatedUser)
            sSQL += ", @DivisionID=" & RowId
            sSQL += ", @CompanyID= " & dbIntField(0, CompanyID)
            'TODO:: Company
            sSQL = "EXEC UPDDivision "
            sSQL += " @Div_Desc = " & dbStrField("", Div_Desc)
            sSQL += ", @SeasonID = " & dbIntField(0, SeasonID)
            sSQL += ", @MinDate = " & dbDateField("null", MinDate)
            sSQL += ", @MaxDate = " & dbDateField("null", MaxDate)
            sSQL += ", @Gender = " & dbStrField("", Gender)
            sSQL += ", @MinDate2 = " & dbDateField("null", MinDate2)
            sSQL += ", @MaxDate2 = " & dbDateField("null", MaxDate2)
            sSQL += ", @Gender2 = " & dbStrField("", Gender2)
            sSQL += ", @DraftVenue = " & dbStrField("", DraftVenue)
            sSQL += ", @DraftDate = " & dbDateField("null", DraftDate)
            sSQL += ", @DraftTime = " & dbStrField("", DraftTime)
            sSQL += ", @DirectorID = " & dbIntField(0, DirectorID)
            sSQL += ", @CoDirectorID = " & dbIntField(0, CoDirectorID)
            sSQL += ", @CreatedDate = " & sGlobal.TimeAdjusted(iTimeZone, Now()).ToString
            sSQL += ", @CreatedUser = " & dbStrField("", CreatedUser)
            sSQL += ", @DivisionID=" & RowId
            Try
                dtResults = DB.ExecuteGetSQL(sSQL)
                DivisionID = dtResults.Rows(0).Item("DivisionID").ToString
            Catch ex As Exception
                Throw New Exception("ClsDivisions:UpdRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdPlayers(ByVal RowID As Long, ByVal CompanyID As Int32, ByVal SeasonID As Int32)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable

            sSQL = "Update Players set "
            sSQL += " DivisionID = " & dbIntField(0, DivisionID)
            sSQL += ", TeamID = " & dbIntField(0, TeamID)
            sSQL += " where DivisionID = " & RowID
            sSQL += " AND SeasonID = " & SeasonID
            sSQL += " AND CompanyID = " & CompanyID
            'TODO:: Company
            sSQL = "Update Players set "
            sSQL += " DivisionID = " & dbIntField(0, DivisionID)
            sSQL += ", TeamID = " & dbIntField(0, TeamID)
            sSQL += " where DivisionID = " & RowID
            sSQL += " AND SeasonID = " & SeasonID
            Try
                dtResults = DB.ExecuteGetSQL(sSQL)
                DivisionID = dtResults.Rows(0).Item("DivisionID").ToString
            Catch ex As Exception
                Throw New Exception("ClsDivisions:UpdPlayers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub DELRow(ByVal RowId As Long, ByVal CompanyID As Int32, ByVal SeasonID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Divisions where DivisionId=" & RowId
                sSQL += " AND CompanyID = " & CompanyID
                sSQL += " AND SeasonID = " & SeasonID
                DB.ExecuteUpdSQL(sSQL)
                sSQL = "DELETE FROM Teams where SeasonID =" & SeasonID
                sSQL += " AND CompanyID = " & CompanyID
                sSQL += " AND DivisionId= " & RowId
                'TODO:: Company
                sSQL = "DELETE FROM Divisions where DivisionId=" & RowId
                sSQL += " AND SeasonID = " & SeasonID
                'TODO:: Company
                DB.ExecuteUpdSQL(sSQL)
                sSQL = "DELETE FROM Teams where SeasonID =" & SeasonID
                sSQL += " AND DivisionId= " & RowId
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsDivisions:DELRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub ReassignDiv(ByVal RowId As Long, ByVal CompanyID As Int32, ByVal SeasonID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC ReassignDiv "
                sSQL += "@DivisionID = " & RowId
                sSQL += " , @iSeason  =" & SeasonID
                sSQL += " , @CompanyID  =" & CompanyID
                'TODO:: Company
                sSQL = "EXEC ReassignDiv "
                sSQL += "@DivisionID = " & RowId
                sSQL += " , @iSeason  =" & SeasonID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsDivisions:ReassignDiv::" & ex.Message)
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

        Function LoadDivision(p1 As Integer, p2 As Object, p3 As Object, p4 As String) As DataTable
            Throw New NotImplementedException
        End Function

    End Class
End Namespace
Imports CSBC.Components.Security
Namespace CSBC.Components.Profile
    Public Class ClsPeople
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal

        Public Property PeopleId() As Long
            Get
                PeopleId = stRowData.PeopleId
            End Get
            Set(ByVal value As Long)
                stRowData.PeopleId = value
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

        Public Property HouseId() As Long
            Get
                HouseId = stRowData.HouseId
            End Get
            Set(ByVal value As Long)
                stRowData.HouseId = value
            End Set
        End Property

        Public Property FirstName() As String
            Get
                FirstName = stRowData.FirstName
            End Get
            Set(ByVal value As String)
                stRowData.FirstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                LastName = stRowData.LastName
            End Get
            Set(ByVal value As String)
                stRowData.LastName = value
            End Set
        End Property

        Public Property WorkPhone() As String
            Get
                WorkPhone = stRowData.WorkPhone
            End Get
            Set(ByVal value As String)
                stRowData.WorkPhone = value
            End Set
        End Property

        Public Property CellPhone() As String
            Get
                CellPhone = stRowData.CellPhone
            End Get
            Set(ByVal value As String)
                stRowData.CellPhone = value
            End Set
        End Property

        Public Property LastestSeason() As String
            Get
                LastestSeason = stRowData.LastestSeason
            End Get
            Set(ByVal value As String)
                stRowData.LastestSeason = value
            End Set
        End Property

        Public Property LatestShirtSize() As String
            Get
                LatestShirtSize = stRowData.LatestShirtSize
            End Get
            Set(ByVal value As String)
                stRowData.LatestShirtSize = value
            End Set
        End Property

        Public Property BirthDate() As Date
            Get
                BirthDate = stRowData.BirthDate
            End Get
            Set(ByVal value As Date)
                stRowData.BirthDate = value
            End Set
        End Property

        Public Property BC() As Byte
            Get
                BC = stRowData.BC
            End Get
            Set(ByVal value As Byte)
                stRowData.BC = value
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

        Public Property SchoolName() As String
            Get
                SchoolName = stRowData.SchoolName
            End Get
            Set(ByVal value As String)
                stRowData.SchoolName = value
            End Set
        End Property

        Public Property Grade() As Integer
            Get
                Grade = stRowData.Grade
            End Get
            Set(ByVal value As Integer)
                stRowData.Grade = value
            End Set
        End Property

        Public Property GiftedLevelsUP() As Integer
            Get
                GiftedLevelsUP = stRowData.GiftedLevelsUP
            End Get
            Set(ByVal value As Integer)
                stRowData.GiftedLevelsUP = value
            End Set
        End Property

        Public Property FeeWaived() As Byte
            Get
                FeeWaived = stRowData.FeeWaived
            End Get
            Set(ByVal value As Byte)
                stRowData.FeeWaived = value
            End Set
        End Property

        Public Property Parent() As Byte
            Get
                Parent = stRowData.Parent
            End Get
            Set(ByVal value As Byte)
                stRowData.Parent = value
            End Set
        End Property

        Public Property Player() As Byte
            Get
                Player = stRowData.Player
            End Get
            Set(ByVal value As Byte)
                stRowData.Player = value
            End Set
        End Property

        Public Property Coach() As Byte
            Get
                Coach = stRowData.Coach
            End Get
            Set(ByVal value As Byte)
                stRowData.Coach = value
            End Set
        End Property

        Public Property AsstCoach() As Byte
            Get
                AsstCoach = stRowData.AsstCoach
            End Get
            Set(ByVal value As Byte)
                stRowData.AsstCoach = value
            End Set
        End Property

        Public Property BoardOfficer() As Byte
            Get
                BoardOfficer = stRowData.BoardOfficer
            End Get
            Set(ByVal value As Byte)
                stRowData.BoardOfficer = value
            End Set
        End Property

        Public Property BoardMember() As Byte
            Get
                BoardMember = stRowData.BoardMember
            End Get
            Set(ByVal value As Byte)
                stRowData.BoardMember = value
            End Set
        End Property

        Public Property AD() As Byte
            Get
                AD = stRowData.AD
            End Get
            Set(ByVal value As Byte)
                stRowData.AD = value
            End Set
        End Property

        Public Property Sponsor() As Byte
            Get
                Sponsor = stRowData.Sponsor
            End Get
            Set(ByVal value As Byte)
                stRowData.Sponsor = value
            End Set
        End Property

        Public Property SignUps() As Byte
            Get
                SignUps = stRowData.SignUps
            End Get
            Set(ByVal value As Byte)
                stRowData.SignUps = value
            End Set
        End Property

        Public Property TryOuts() As Byte
            Get
                TryOuts = stRowData.TryOuts
            End Get
            Set(ByVal value As Byte)
                stRowData.TryOuts = value
            End Set
        End Property

        Public Property TeeShirts() As Byte
            Get
                TeeShirts = stRowData.TeeShirts
            End Get
            Set(ByVal value As Byte)
                stRowData.TeeShirts = value
            End Set
        End Property

        Public Property Printing() As Byte
            Get
                Printing = stRowData.Printing
            End Get
            Set(ByVal value As Byte)
                stRowData.Printing = value
            End Set
        End Property

        Public Property Equipment() As Byte
            Get
                Equipment = stRowData.Equipment
            End Get
            Set(ByVal value As Byte)
                stRowData.Equipment = value
            End Set
        End Property

        Public Property Electrician() As Byte
            Get
                Electrician = stRowData.Electrician
            End Get
            Set(ByVal value As Byte)
                stRowData.Electrician = value
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
            Friend PeopleId As Integer
            Friend CompanyId As Int32
            Friend HouseId As Integer
            Friend FirstName As String
            Friend LastName As String
            Friend WorkPhone As String
            Friend CellPhone As String
            Friend LastestSeason As String
            Friend LatestShirtSize As String
            Friend BirthDate As Date
            Friend BC As Byte
            Friend Gender As String
            Friend SchoolName As String
            Friend Grade As Integer
            Friend GiftedLevelsUP As Integer
            Friend FeeWaived As Byte
            Friend Parent As Byte
            Friend Player As Byte
            Friend Coach As Byte
            Friend AsstCoach As Byte
            Friend BoardOfficer As Byte
            Friend BoardMember As Byte
            Friend AD As Byte
            Friend Sponsor As Byte
            Friend SignUps As Byte
            Friend TryOuts As Byte
            Friend TeeShirts As Byte
            Friend Printing As Byte
            Friend Equipment As Byte
            Friend Electrician As Byte
            Friend CreatedUser As String
        End Structure

        Private stRowData As RowFields

        Public Function GetRecords(ByVal iPeopleId As Long, ByVal iCompanyId As Int32, Optional ByVal sFName As String = "", _
                Optional ByVal sLName As String = "", Optional ByVal sName As String = "", Optional ByVal dBirthDate As String = "") As DataTable
            Dim DB As New ClsDatabase
            Dim sOrder As String = " Order By"
            Try
                sSQL = "SELECT top 1000 PeopleId, LastName, FirstName, Phone, BirthDate, Address1 FROM People LEFT JOIN Households ON People.HouseId = Households.HouseId"
                sSQL += " AND People.CompanyID = Households.CompanyID"
                sSQL += " WHERE People.CompanyID =" & iCompanyId
                If iPeopleId > 0 Then sSQL += " AND PeopleId = " & iPeopleId

                If sFName > "" Then
                    sSQL += " AND FirstName like " & sGlobal.Quotes(sFName + "%")
                End If
                If sLName > "" Then
                    sSQL += " AND LastName like " & sGlobal.Quotes(sLName + "%")
                End If
                If sName > "" Then
                    sSQL += " AND Households.HouseName =" & sName
                End If

                If sFName > "" Then
                    If sOrder = " Order By" Then
                        sOrder += " FirstName "
                    Else
                        sOrder += ", FirstName "
                    End If
                End If

                If sLName > "" Then
                    If sOrder = " Order By" Then
                        sOrder += " LastName "
                    Else
                        sOrder += ", LastName "
                    End If
                End If

                If sName > "" Then
                    If sOrder = " Order By" Then
                        sOrder += " Households.HouseName "
                    Else
                        sOrder += ", Households.HouseName "
                    End If
                End If
                If sOrder <> " Order By" Then sSQL += sOrder

                'If sSearchType = "BirthDate" Then
                '    sSQL += " WHERE convert(char, birthdate,101) = " + sGlobal.Quotes(sFirstLetter)

                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPeople:GetRecords::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetMembers(ByVal iHouseID As Long, ByVal iCompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT PeopleID, (FirstName + ' ' + LastName) as Name, Gender, Birthdate  From People"
                sSQL += " where HouseID = " & iHouseID & " AND People.CompanyID = " & iCompanyID
                sSQL += " order by FirstName"
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPeople:GetMembers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub DELRow(ByVal iPeopleId As Long, ByVal iCompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM People where PeopleId=" & iPeopleId
                sSQL += " AND CompanyID = " & iCompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPeople:DELRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdRow(ByVal iPeopleId As Long, ByVal iCompanyID As Int32, ByVal iTimeZone As Int32)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "EXEC UPDPeople "
                sSQL += " @HouseId = " & dbIntField(vbNull, HouseId)
                sSQL += ", @Gender = " & dbStrField("", Gender)
                sSQL += ", @SchoolName = " & dbStrField("", SchoolName)
                sSQL += ", @Grade = " & dbIntField(0, Grade)
                sSQL += ", @GiftedLevelsUP = " & dbIntField(0, GiftedLevelsUP)
                sSQL += ", @FeeWaived = " & dbBoolField(False, FeeWaived)
                sSQL += ", @Parent = " & dbBoolField(False, Parent)
                sSQL += ", @Coach = " & dbBoolField(False, Coach)
                sSQL += ", @Player = " & dbBoolField(False, Player)
                sSQL += ", @BoardOfficer = " & dbBoolField(False, BoardOfficer)
                sSQL += ", @AD = " & dbBoolField(False, AD)
                sSQL += ", @Sponsor = " & dbBoolField(False, Sponsor)
                sSQL += ", @SignUps = " & dbBoolField(False, SignUps)
                sSQL += ", @TryOuts = " & dbBoolField(False, TryOuts)
                sSQL += ", @TeeShirts = " & dbBoolField(False, TeeShirts)
                sSQL += ", @Printing = " & dbBoolField(False, Printing)
                sSQL += ", @Equipment = " & dbBoolField(False, Equipment)
                sSQL += ", @Electrician = " & dbBoolField(False, Electrician)
                sSQL += ", @AsstCoach = " & dbBoolField(False, AsstCoach)
                sSQL += ", @BoardMember = " & dbBoolField(False, BoardMember)
                sSQL += ", @BC = " & dbBoolField(False, BC)
                sSQL += ", @LastName = " & dbStrField("", LastName)
                sSQL += ", @FirstName = " & dbStrField("", FirstName)
                sSQL += ", @WorkPhone = " & dbStrField("", WorkPhone)
                sSQL += ", @CellPhone = " & dbStrField("", CellPhone)
                sSQL += ", @BirthDate = " & dbDateField("NULL", BirthDate)
                sSQL += ", @CreatedDate = " & sGlobal.Quo(sGlobal.TimeAdjusted(iTimeZone, Now()))
                sSQL += ", @CreatedUser = " & dbStrField("", CreatedUser)
                sSQL += ", @PeopleID= " & dbIntField(0, iPeopleId)
                sSQL += ", @CompanyID= " & dbIntField(0, iCompanyID)
                dtResults = DB.ExecuteGetSQL(sSQL)
                PeopleId = dtResults.Rows(0).Item("PeopleID").ToString
            Catch ex As Exception
                Throw New Exception("ClsPeople:UpdRow::" & ex.Message)
            Finally
                DB = Nothing
                dtResults = Nothing
            End Try
        End Sub

        Public Sub UpdatePeopleOR(ByVal iPeopleId As Long, ByVal iCompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "UPDATE People "
                sSQL += "SET SchoolName = " & dbStrField("", SchoolName)
                sSQL += ", Grade = " & dbIntField(0, Grade)
                DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPeople:UpdatePeopleOR::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Function GetVolunteers(ByVal sVolunteer As String, ByVal iCompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT People.PeopleID, (People.LastName + ', ' + People.FirstName) as Name "
                sSQL += " FROM People"
                sSQL += " WHERE " & sVolunteer & "= 1 "
                sSQL += " AND CompanyID = " & iCompanyID
                sSQL += " Order by Name asc"
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPeople:GetVolunteers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetShirtSize(ByVal iPeopleID As Int32, ByVal iCompanyID As Int32) As String
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "select isnull(LatestShirtSize, 'N/A') as  LatestShirtSize from people "
                sSQL += "where(PeopleId = " & iPeopleID
                sSQL += " AND CompanyID = " & iCompanyID & ")"
                dtResults = DB.ExecuteGetSQL(sSQL)
                Return dtResults.Rows(0).Item("LatestShirtSize").ToString
            Catch ex As Exception
                Throw New Exception("ClsPeople:GetShirtSize::" & ex.Message)
            Finally
                DB = Nothing
                dtResults = Nothing
            End Try
        End Function

        Public Function LoadPeople(ByVal iPeopleID As Long, ByVal iCompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT Households.HouseID, Households.Name, People.FirstName, People.LastName, "
                sSQL += "(People.FirstName + ' ' + People.LastName) as Name, "
                sSQL += "People.Workphone, People.Cellphone, People.Email, People.LatestSeason, People.BirthDate, "
                sSQL += "People.Gender, People.FeeWaived, People.SchoolName, People.Grade, People.GiftedLevelsUP, "
                sSQL += "People.BoardOfficer, People.BoardMember, People.AD, People.Sponsor, People.Coach, People.AsstCoach, "
                sSQL += "People.SignUps, People.TryOuts, People.TeeShirts, People.Printing, People.Equipment, "
                sSQL += "People.Electrician, Households.Phone, Households.Address1, Households.Address2, "
                sSQL += "People.Player, People.Parent, People.BC,"
                sSQL += "Households.City, Households.State, Households.Zip "
                sSQL += "FROM Households RIGHT JOIN People ON Households.HouseID = People.HouseID "
                sSQL += "WHERE People.PeopleID = " & iPeopleID
                sSQL += " AND People.CompanyID = " & iCompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPeople:LoadPeople::" & ex.Message)
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
    End Class
End Namespace

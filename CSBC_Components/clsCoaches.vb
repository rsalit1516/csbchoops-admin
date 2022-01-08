Imports CSBC.Components.Security
Namespace CSBC.Components.Season
    Public Class clsCoaches
        Private sSQL As String
        Private sGlobal As New CSBC.Components.ClsGlobal


        Public Property CompanyId() As Integer
            Get
                CompanyId = stRowData.CompanyId
            End Get
            Set(ByVal value As Integer)
                stRowData.CompanyId = value
            End Set
        End Property

        Public Property CoachID() As Long
            Get
                CoachID = stRowData.CoachID
            End Get
            Set(ByVal value As Long)
                stRowData.CoachID = value
            End Set
        End Property

        Public Property SeasonID() As Long
            Get
                SeasonID = stRowData.SeasonID
            End Get
            Set(ByVal value As Long)
                stRowData.SeasonID = value
            End Set
        End Property

        Public Property PeopleID() As Long
            Get
                PeopleID = stRowData.PeopleID
            End Get
            Set(ByVal value As Long)
                stRowData.PeopleID = value
            End Set
        End Property

        Public Property PlayerID() As Long
            Get
                PlayerID = stRowData.PlayerID
            End Get
            Set(ByVal value As Long)
                stRowData.PlayerID = value
            End Set
        End Property

        Public Property ShirtSize() As String
            Get
                ShirtSize = stRowData.ShirtSize
            End Get
            Set(ByVal value As String)
                stRowData.ShirtSize = value
            End Set
        End Property

        Public Property CoachPhone() As String
            Get
                CoachPhone = stRowData.CoachPhone
            End Get
            Set(ByVal value As String)
                stRowData.CoachPhone = value
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
            Friend CompanyId As Integer
            Friend CoachID As Integer
            Friend SeasonID As Integer
            Friend PeopleID As Integer
            Friend PlayerID As Integer
            Friend ShirtSize As String
            Friend CoachPhone As String
            Friend CreatedUser As String
        End Structure

        Private stRowData As RowFields

        Public Function LoadCoaches(ByVal iCoachID As Int32, ByVal iCompanyID As Int32, ByVal iSeasonID As Int32) As DataTable

            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetCoaches "
                'sSQL += " @CompanyID = " & iCompanyID
                sSQL += "@SeasonID = " & iSeasonID
                'sSQL += ", @CoachID = " & iCoachID
                'sSQL += ", @DivisionID = " & DivisionID
                'sSQL += ", @TeamID = " & TeamID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsCoach:LoadCoaches::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function LoadCoachesVolunteers(ByVal iCompanyID As Int32, ByVal iSeasonID As Int32) As DataTable

            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT People.PeopleID, (People.LastName + ', ' + People.FirstName) as Name"
                sSQL += " FROM People WHERE People.Coach= 1 AND CompanyID = " & iCompanyID
                sSQL += " AND People.PeopleID Not In (Select PeopleID from Coaches where SeasonID = " & iSeasonID & " AND CompanyID = " & iCompanyID & ")"
                sSQL += " Order by LastName, FirstName"

                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsCoach:LoadCoachesVolunteers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub DELRow(ByVal iCoachID As Int32, ByVal iCompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Coaches where CoachId=" & iCoachID
                sSQL += " AND CompanyID = " & iCompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsCoach:DELRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        'Public Function LoadCoaches2(ByVal CoachID As Int32, ByVal CompanyID As Int32, ByVal SeasonID As Int32) As DataTable

        '    '      Sql = "SELECT DISTINCT Coaches.CoachID, People.LastName, People.FirstName, Households.Phone " & _
        '    '"FROM (People INNER JOIN Coaches ON People.PeopleID = Coaches.PeopleID) " & _
        '    '"INNER JOIN Households ON People.MainCoachID = Households.CoachID "
        '    '      Sql = Sql + "WHERE Coaches.SeasonID= " & Session("SeasonID")
        '    '      Sql = Sql + " ORDER BY LastName, FirstName"

        '    'NEED TO BE COMBINED ********************************************************

        '    '      Sql = "SELECT People.LastName, People.FirstName, Households.Phone, Coaches.ShirtSize, Coaches.PeopleID, " & _
        '    '"Households.Address1, Households.City, Households.State, Households.Zip, Coaches.CoachPhone " & _
        '    '"FROM Coaches INNER JOIN (People INNER JOIN Households ON People.MainCoachID = Households.CoachID) " & _
        '    '"ON Coaches.PeopleID = People.PeopleID "
        '    '      Sql = Sql & " Where Coaches.CoachID = " & RowID
        'End Function

        Public Sub AddNewCoach()
            Dim DB As New ClsDatabase
            Try
                'Find the next ID
                sSQL = "SELECT isnull(MAX(CoachID),0) + 1 as CoachID from Coaches where CompanyID = " & CompanyId
                CoachId = DB.ExecuteGetID(sSQL)

                sSQL = "INSERT INTO Coaches (CompanyID, CoachID, SeasonID, PeopleID, PlayerID, ShirtSize, CoachPhone, "
                sSQL += "CreatedUser)"
                sSQL += " VALUES "
                sSQL += "( " & dbIntField(vbNull, CompanyId)
                sSQL += ", " & dbIntField(vbNull, CoachID)
                sSQL += ", " & dbIntField(vbNull, SeasonId)
                sSQL += ", " & dbIntField(vbNull, PeopleID)
                sSQL += ", " & dbStrField(vbNull, PlayerID)
                sSQL += ", " & dbIntField("", ShirtSize)
                sSQL += ", " & dbStrField("", CoachPhone)
                sSQL += ", " & dbStrField("", CreatedUser)
                sSQL += ")"
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsCoaches:AddNewCoach::" & ex.Message)
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

    End Class
End Namespace

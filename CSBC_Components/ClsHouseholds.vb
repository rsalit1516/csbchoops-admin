Imports CSBC.Components.Security
Namespace CSBC.Components.Profile
    Public Class ClsHouseholds
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

        Public Property Name() As String
            Get
                Name = stRowData.Name
            End Get
            Set(ByVal value As String)
                stRowData.Name = value
            End Set
        End Property

        Public Property Address1() As String
            Get
                Address1 = stRowData.Address1
            End Get
            Set(ByVal value As String)
                stRowData.Address1 = value
            End Set
        End Property

        Public Property Address2() As String
            Get
                Address2 = stRowData.Address2
            End Get
            Set(ByVal value As String)
                stRowData.Address2 = value
            End Set
        End Property

        Public Property City() As String
            Get
                City = stRowData.City
            End Get
            Set(ByVal value As String)
                stRowData.City = value
            End Set
        End Property

        Public Property Email() As String
            Get
                Email = stRowData.Email
            End Get
            Set(ByVal value As String)
                stRowData.Email = value
            End Set
        End Property

        Public Property EmailList() As Boolean
            Get
                EmailList = stRowData.EmailList
            End Get
            Set(ByVal value As Boolean)
                stRowData.EmailList = value
            End Set
        End Property

        Public Property SportsCard() As String
            Get
                SportsCard = stRowData.SportsCard
            End Get
            Set(ByVal value As String)
                stRowData.SportsCard = value
            End Set
        End Property

        Public Property CartID() As Integer
            Get
                CartID = stRowData.CartID
            End Get
            Set(ByVal value As Integer)
                stRowData.CartID = value
            End Set
        End Property

        Public Property State() As String
            Get
                State = stRowData.State
            End Get
            Set(ByVal value As String)
                stRowData.State = value
            End Set
        End Property

        Public Property Zip() As String
            Get
                Zip = stRowData.Zip
            End Get
            Set(ByVal value As String)
                stRowData.Zip = value
            End Set
        End Property

        Public Property Phone() As String
            Get
                Phone = stRowData.Phone
            End Get
            Set(ByVal value As String)
                stRowData.Phone = value
            End Set
        End Property

        Public Property Guardian() As Long
            Get
                Guardian = stRowData.Guardian
            End Get
            Set(ByVal value As Long)
                stRowData.Guardian = value
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
            Friend HouseId As Integer
            Friend Name As String
            Friend Address1 As String
            Friend Address2 As String
            Friend City As String
            Friend Email As String
            Friend EmailList As Boolean
            Friend SportsCard As String
            Friend CartID As Integer
            Friend State As String
            Friend Zip As String
            Friend Phone As String
            Friend Guardian As Long
            Friend CreatedUser As String
        End Structure

        Private stRowData As RowFields

        Public Function GetRecords(ByVal RowId As Long, ByVal CompanyId As Int32, Optional ByVal sName As String = "", Optional ByVal sAddress As String = "", Optional ByVal sPhone As String = "", Optional ByVal sEmail As String = "") As DataTable
            Dim DB As New ClsDatabase
            Dim sOrder As String = " Order By"
            Try
                sSQL = "SELECT top 1000 HouseId, Name, Address1, Address2, City, State, Zip, Phone, Email, SportsCard, FeeWaived FROM HOUSEHOLDS "
                sSQL += "WHERE CompanyID =" & CompanyId
                If RowId > 0 Then sSQL += " AND HouseId = " & RowId

                If sName > "" Then
                    sSQL += " AND Name  like " & sGlobal.Quotes(sName + "%")
                End If
                If sAddress > "" Then
                    sSQL += " AND Address1 like " & sGlobal.Quotes(sAddress + "%")
                End If
                If sPhone > "" Then
                    sSQL += " AND Phone like " & sGlobal.Quotes(sPhone + "%")
                End If
                If sEmail > "" Then
                    sSQL += " AND Email like " & sGlobal.Quotes(sEmail + "%")
                End If
                If sName > "" Then
                    If sOrder = " Order By" Then
                        sOrder += " Name "
                    Else
                        sOrder += ", Name "
                    End If
                End If

                If sAddress > "" Then
                    If sOrder = " Order By" Then
                        sOrder += " Address1 "
                    Else
                        sOrder += ", Address1 "
                    End If
                End If

                If sPhone > "" Then
                    If sOrder = " Order By" Then
                        sOrder += " Phone "
                    Else
                        sOrder += ", Phone "
                    End If
                End If

                If sEmail > "" Then
                    If sOrder = " Order By" Then
                        sOrder += " Email "
                    Else
                        sOrder += ", Email "
                    End If
                End If
                If sOrder <> " Order By" Then sSQL += sOrder
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsHouseholds:GetRecords::" & ex.Message)
            Finally
                DB = Nothing
            End Try

        End Function

        Public Sub DELRow(ByVal RowId As Long, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Households where HouseId=" & RowId
                sSQL += " AND CompanyID = " & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsHouseholds:DELRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdRow(ByVal RowId As Long, ByVal CompanyID As Int32, ByVal iTimeZone As Int32)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "EXEC UPDHouse "
                sSQL += " @Name = " & dbStrField("", Name)
                sSQL += ", @HouseID = " & dbIntField(0, RowId)
                sSQL += ", @Address1 = " & dbStrField("", Address1)
                sSQL += ", @Address2 = " & dbStrField("", Address2)
                sSQL += ", @City = " & dbStrField("", City)
                sSQL += ", @Email = " & dbStrField("", Email)
                sSQL += ", @EmailList = " & dbBoolField(0, EmailList)
                sSQL += ", @Guardian = " & dbIntField(0, Guardian)
                sSQL += ", @SportsCard = " & dbStrField("", SportsCard)
                sSQL += ", @State = " & dbStrField("", State)
                sSQL += ", @Zip = " & dbStrField("", Zip)
                sSQL += ", @Phone = " & dbStrField("", Phone)
                sSQL += ", @User = " & dbStrField("", CreatedUser)
                sSQL += ", @CreateDate = " & sGlobal.Quo(sGlobal.TimeAdjusted(iTimeZone, Now()))
                sSQL += ", @CompanyID = " & dbIntField(0, CompanyID)

                dtResults = DB.ExecuteGetSQL(sSQL)
                HouseId = dtResults.Rows(0).Item("HouseID").ToString

            Catch ex As Exception
                Throw New Exception("ClsHouseholds:UpdRow::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Function GetHouseholdCart(ByVal RowID As Long, ByVal SeasonID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC GetShoppingCart "
                sSQL += " @HouseID = " & dbIntField(0, RowID)
                sSQL += ", @SeasonID = " & dbIntField(0, SeasonID)
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsHouseholds:GetHouseholdCart::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function


        Public Function LoadMembers(ByVal RowID As Long, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT PeopleID, (FirstName + ' ' + LastName) as Name, Birthdate, gender From People "
                sSQL += " Where HouseId = " & dbIntField(0, RowID)
                sSQL += " AND People.CompanyID = " & dbIntField(0, CompanyID)
                sSQL += " order by FirstName"
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsHouseholds:LoadMembers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub UpdMember(ByVal RowId As Long, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "UPDATE People SET "
                sSQL += " HouseID = " & dbIntField(0, HouseId)
                sSQL += " WHERE PeopleID = " & dbIntField(0, RowId)
                sSQL += " AND CompanyID = " & dbIntField(0, CompanyID)
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsHouseholds:UpdMember::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdUser(ByVal RowID As Long, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "UPDATE Users SET "
                sSQL += " HouseID = " & dbIntField(0, HouseId)
                sSQL += " WHERE HouseID = " & dbIntField(0, RowID)
                sSQL += " AND CompanyID = " & dbIntField(0, CompanyID)
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsHouseholds:UpdUser::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub AddEmail(ByVal RowId As Long, ByVal SeasonID As Int32, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "INSERT INTO Emails (HouseID, CompanyID, SeasonID, EmailAddress) VALUES (" & RowId
                sSQL += ", " & dbIntField(0, CompanyID)
                sSQL += ", " & dbStrField("", SeasonID)
                sSQL += ", " & dbStrField("", Email)
                sSQL += ")"
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsHouseholds:AddEmail::" & ex.Message)
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

        Function LoadEmails(iGroupType As Integer, p2 As Object, p3 As Object) As DataTable
            Throw New NotImplementedException
        End Function

    End Class
End Namespace

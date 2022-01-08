Imports System.Security.Cryptography
Namespace CSBC.Components.Security
    Public Class ClsUsers
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

        Public Property TimeZone() As Integer
            Get
                TimeZone = stRowData.TimeZone
            End Get
            Set(ByVal value As Integer)
                stRowData.TimeZone = value
            End Set
        End Property

        Public Property CompanyName() As String
            Get
                CompanyName = stRowData.CompanyName
            End Get
            Set(ByVal value As String)
                stRowData.CompanyName = value
            End Set
        End Property

        Public Property ImageName() As String
            Get
                ImageName = stRowData.ImageName
            End Get
            Set(ByVal value As String)
                stRowData.ImageName = value
            End Set
        End Property

        Public Property SeasonID() As Integer
            Get
                SeasonID = stRowData.SeasonID
            End Get
            Set(ByVal value As Integer)
                stRowData.SeasonID = value
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

        Public Property HouseID() As Integer
            Get
                HouseID = stRowData.HouseID
            End Get
            Set(ByVal value As Integer)
                stRowData.HouseID = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                UserName = stRowData.UserName
            End Get
            Set(ByVal value As String)
                stRowData.UserName = value
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

        Public Property CreatedUser() As String
            Get
                CreatedUser = stRowData.CreatedUser
            End Get
            Set(ByVal value As String)
                stRowData.CreatedUser = value
            End Set
        End Property

        Public Property Usertype() As Integer
            Get
                Usertype = stRowData.Usertype
            End Get
            Set(ByVal value As Integer)
                stRowData.Usertype = value
            End Set
        End Property

        Public Property AccessType() As String
            Get
                AccessType = stRowData.AccessType
            End Get
            Set(ByVal value As String)
                stRowData.AccessType = value
            End Set
        End Property

        Public Property SeasonDesc() As String
            Get
                SeasonDesc = stRowData.SeasonDesc
            End Get
            Set(ByVal value As String)
                stRowData.SeasonDesc = value
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

        Public Property PWord() As String
            Get
                PWord = stRowData.PWord
            End Get
            Set(ByVal value As String)
                stRowData.PWord = value
            End Set
        End Property

        Public Property EmailSender() As String
            Get
                EmailSender = stRowData.EmailSender
            End Get
            Set(ByVal value As String)
                stRowData.EmailSender = value
            End Set
        End Property

        Public Structure RowFields
            Public CompanyID As Integer
            Public CompanyName As String
            Public TimeZone As Integer
            Public ImageName As String
            Public SeasonID As Integer
            Public UserID As Integer
            Public HouseID As Integer
            Public UserName As String
            Public Name As String
            Public CreatedUser As String
            Public Usertype As String
            Public AccessType As String
            Public SeasonDesc As String
            Public Email As String
            Public EmailSender As String
            Public PWord As String
        End Structure

        Public stRowData As RowFields

        Public Sub GetUser(ByVal sUserName As String, ByVal sPwd As String)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try

                sSQL = "EXEC CheckEncryption @UserName = " & sGlobal.Quo(sUserName) 'Check for encryption
                dtResults = DB.ExecuteGetSQL(sSQL)
                If dtResults.Rows.Count > 0 Then
                    If dtResults.Rows(0).Item("PWD").ToString = False Then  'Not encripted
                        sSQL = "EXEC CheckLoginNE @UserName = " & sGlobal.Quo(sUserName) & ", @Pword = " & sGlobal.Quo(sPwd) & ", @PassWord = " & sGlobal.Quo(HashPassword(sPwd)) 'Create encripted password
                        DB.ExecuteUpdSQL(sSQL)
                    End If
                    dtResults.Clear()
                    sSQL = "EXEC CheckLogin @UserName = " & sGlobal.Quo(sUserName) & ", @PassWord = " & sGlobal.Quo(HashPassword(sPwd)) 'Get User information
                    dtResults = DB.ExecuteGetSQL(sSQL)
                    If dtResults.Rows.Count > 0 Then
                        'TODO:: Company
                        'CompanyID = dtResults.Rows(0).Item("CompanyID").ToString
                        'CompanyName = dtResults.Rows(0).Item("CompanyName").ToString
                        'ImageName = dtResults.Rows(0).Item("ImageName").ToString
                        'TimeZone = dtResults.Rows(0).Item("TimeZone").ToString
                        'SeasonID = dtResults.Rows(0).Item("SeasonID").ToString
                        'SeasonDesc = dtResults.Rows(0).Item("Sea_Desc").ToString
                        UserID = dtResults.Rows(0).Item("UserID").ToString
                        HouseID = dtResults.Rows(0).Item("HouseID").ToString
                        UserName = dtResults.Rows(0).Item("UserName").ToString
                        Usertype = dtResults.Rows(0).Item("Usertype").ToString
                        'ADMIN = dtResults.Rows(0).Item("ADMIN").ToString
                    End If
                End If
            Catch ex As Exception
                Throw New Exception("ClsUsers:GetUser::" & ex.Message)
            Finally
                DB = Nothing
                dtResults = Nothing
            End Try

        End Sub
        'TODO:: Company
        'Public Sub GetCompanyInfo(ByVal iUserID As Int32, ByVal SeasonID As Int32)
        '    Dim DB As New ClsDatabase
        '    Dim dtResults As DataTable
        '    Try
        '        sSQL = "EXEC CompanyInfo @UserID = " & sGlobal.Quo(iUserID)
        '        sSQL += ", @SeasonID = " & SeasonID
        '        dtResults = DB.ExecuteGetSQL(sSQL)
        '        CompanyID = dtResults.Rows(0).Item("CompanyID").ToString
        '        CompanyName = dtResults.Rows(0).Item("CompanyName").ToString
        '        ImageName = dtResults.Rows(0).Item("ImageName").ToString
        '        TimeZone = dtResults.Rows(0).Item("TimeZone").ToString
        '        SeasonID = dtResults.Rows(0).Item("SeasonID").ToString
        '        UserName = dtResults.Rows(0).Item("UserName").ToString
        '        SeasonDesc = dtResults.Rows(0).Item("Sea_Desc").ToString
        '    Catch ex As Exception
        '        Throw New Exception("ClsUsers:GetCompanyInfo::" & ex.Message)
        '    Finally
        '        DB = Nothing
        '        dtResults = Nothing
        '    End Try

        'End Sub

        Public Sub GetSeason(ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "SELECT SeasonID, Sea_Desc, FromDate FROM Seasons WHERE Seasons.CurrentSeason=1"
                sSQL += " AND CompanyID = " & sGlobal.Quo(CompanyID)
                'TODO:: Company
                sSQL = "SELECT SeasonID, Sea_Desc, FromDate FROM Seasons WHERE Seasons.CurrentSeason=1"
                dtResults = DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsUsers:GetSeason::" & ex.Message)
            End Try
            DB = Nothing
        End Sub

        Public Sub GetLoginInfo(ByVal UserName As String, ByVal Password As String)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "SELECT SeasonID, Sea_Desc, FromDate FROM vw_CheckLogin WHERE Seasons.CurrentSeason=1"
                sSQL += " AND CompanyID = " & sGlobal.Quo(CompanyID)
                dtResults = DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsUsers:GetSeason::" & ex.Message)
            End Try
            DB = Nothing
        End Sub

        Public Sub DELUserPtn(ByVal HouseId As Long, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "Update USERS set HouseId = " & vbNull
                sSQL += " where HouseId=" & HouseId
                sSQL += " AND CompanyID = " & CompanyID
                'TODO:: Company
                sSQL = "Update USERS set HouseId = " & vbNull
                sSQL += " where HouseId=" & HouseId
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsUsers:DELUserPtn::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Private Function HashPassword(ByVal password As String) As String
            Dim hashedPassword As String
            Dim hashProvider = New SHA256Managed
            Try
                Dim passwordBytes() As Byte
                'Dim hashBytes() As Byte
                passwordBytes = System.Text.Encoding.Unicode.GetBytes(password)
                'hashProvider = New SHA256Managed
                hashProvider.Initialize()
                passwordBytes = hashProvider.ComputeHash(passwordBytes)
                hashedPassword = Convert.ToBase64String(passwordBytes)
            Finally
                If Not hashProvider Is Nothing Then
                    hashProvider.Clear()
                    hashProvider = Nothing
                End If
            End Try
            Return hashedPassword

        End Function

        Public Sub GetAccess(ByVal iUserID As Int32, ByVal sScreen As String, ByVal iCompanyID As Int32, Optional ByVal iSeasonID As Int32 = 0)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "EXEC GetAccess"
                sSQL += " @UserCode = " & iUserID
                sSQL += ", @Screen = " & sGlobal.Quo(sScreen)
                sSQL += ", @SeasonID = " & iSeasonID
                sSQL += ", @CompanyID = " & iCompanyID
                'TODO:: Company
                sSQL = "EXEC GetAccess"
                sSQL += " @UserCode = " & iUserID
                sSQL += ", @Screen = " & sGlobal.Quo(sScreen)
                sSQL += ", @SeasonID = " & iSeasonID
                dtResults = DB.ExecuteGetSQL(sSQL)
                AccessType = dtResults.Rows(0).Item("accesstype").ToString
            Catch ex As Exception
                Throw New Exception("ClsUsers:GetAccess::" & ex.Message)
            Finally
                DB = Nothing
                dtResults = Nothing
            End Try
        End Sub

        Public Sub GetEmail(ByVal CompanyID As Integer, ByVal sUserName As String)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "exec CheckEmail @UName=" & sGlobal.Quotes(sUserName)
                sSQL += ", @CompanyID = " & CompanyID
                'TODO:: Company
                sSQL = "exec CheckEmail @UName=" & sGlobal.Quotes(sUserName)
                dtResults = DB.ExecuteGetSQL(sSQL)
                If dtResults.Rows.Count > 0 Then
                    Email = dtResults.Rows(0).Item("Email").ToString
                    PWord = dtResults.Rows(0).Item("PWord").ToString
                End If
            Catch ex As Exception
                Throw New Exception("ClsUsers:GetEmail::" & ex.Message)
            Finally
                DB = Nothing
                dtResults = Nothing
            End Try
        End Sub

        Public Sub AddUser(ByVal iTimeZone As Int32)
            Dim DB As New ClsDatabase
            Dim dtResults As DataTable
            Try
                sSQL = "EXEC sp_UpdUser "
                sSQL += " @UserId = 0"
                sSQL += ", @UserName = " & dbStrField("", UserName)
                sSQL += ", @Name = " & dbStrField("", Name)
                sSQL += ", @PWord = " & dbStrField("", PWord)
                sSQL += ", @Password = " & dbStrField("", HashPassword(PWord))
                sSQL += ", @UserType = " & dbIntField(0, Usertype)
                sSQL += ", @HouseID = " & dbStrField("", HouseID)
                sSQL += ", @CompanyID = " & dbStrField("", CompanyID)
                sSQL += ", @Roles = " & dbStrField("", Space(1))
                sSQL += ", @CreatedUser = " & dbStrField("", CreatedUser)
                sSQL += ", @CreatedDate = " & sGlobal.Quo(sGlobal.TimeAdjusted(iTimeZone, Now()))

                dtResults = DB.ExecuteGetSQL(sSQL)
                UserID = dtResults.Rows(0).Item("UserID").ToString

            Catch ex As Exception
                Throw New Exception("ClsUsers:AddUser::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdPWD(ByVal CompanyID As Integer, ByVal sUserName As String, ByVal sPWord As String)
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC sp_UpdPWD "
                sSQL += " @UserName = " & dbStrField("", sUserName)
                sSQL += ", @PWord = " & dbStrField("", sPWord)
                sSQL += ", @Password = " & dbStrField("", HashPassword(sPWord))
                sSQL += ", @CompanyID = " & dbStrField("", CompanyID)

                DB.ExecuteGetSQL(sSQL)

            Catch ex As Exception
                Throw New Exception("ClsUsers:UpdPWD::" & ex.Message)
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
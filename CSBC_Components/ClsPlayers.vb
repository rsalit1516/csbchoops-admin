Imports CSBC.Components.Security
Namespace CSBC.Components.Season
    Public Class ClsPlayers
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

        Public Property PlayerId() As Integer
            Get
                PlayerId = stRowData.PlayerId
            End Get
            Set(ByVal value As Integer)
                stRowData.PlayerId = value
            End Set
        End Property

        Public Property SeasonId() As Integer
            Get
                SeasonId = stRowData.SeasonId
            End Get
            Set(ByVal value As Integer)
                stRowData.SeasonId = value
            End Set
        End Property

        Public Property PeopleId() As Integer
            Get
                PeopleId = stRowData.PeopleId
            End Get
            Set(ByVal value As Integer)
                stRowData.PeopleId = value
            End Set
        End Property

        Public Property DivisionId() As Integer
            Get
                DivisionId = stRowData.DivisionId
            End Get
            Set(ByVal value As Integer)
                stRowData.DivisionId = value
            End Set
        End Property

        Public Property TeamId() As Integer
            Get
                TeamId = stRowData.TeamId
            End Get
            Set(ByVal value As Integer)
                stRowData.TeamId = value
            End Set
        End Property

        Public Property DraftId() As String
            Get
                DraftId = stRowData.DraftId
            End Get
            Set(ByVal value As String)
                stRowData.DraftId = value
            End Set
        End Property

        Public Property Rating() As Integer
            Get
                Rating = stRowData.Rating
            End Get
            Set(ByVal value As Integer)
                stRowData.Rating = value
            End Set
        End Property

        Public Property CoachID() As Integer
            Get
                CoachID = stRowData.CoachID
            End Get
            Set(ByVal value As Integer)
                stRowData.CoachID = value
            End Set
        End Property

        Public Property SponsorID() As Integer
            Get
                SponsorID = stRowData.SponsorID
            End Get
            Set(ByVal value As Integer)
                stRowData.SponsorID = value
            End Set
        End Property

        Public Property PaidAmount() As Integer
            Get
                PaidAmount = stRowData.PaidAmount
            End Get
            Set(ByVal value As Integer)
                stRowData.PaidAmount = value
            End Set
        End Property

        Public Property BalanceOwed() As Integer
            Get
                BalanceOwed = stRowData.BalanceOwed
            End Get
            Set(ByVal value As Integer)
                stRowData.BalanceOwed = value
            End Set
        End Property

        Public Property ShoppingCartID() As Integer
            Get
                ShoppingCartID = stRowData.ShoppingCartID
            End Get
            Set(ByVal value As Integer)
                stRowData.ShoppingCartID = value
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

        Public Property PayType() As String
            Get
                PayType = stRowData.PayType
            End Get
            Set(ByVal value As String)
                stRowData.PayType = value
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

        Public Property School() As String
            Get
                School = stRowData.School
            End Get
            Set(ByVal value As String)
                stRowData.School = value
            End Set
        End Property

        Public Property Grade() As String
            Get
                Grade = stRowData.Grade
            End Get
            Set(ByVal value As String)
                stRowData.Grade = value
            End Set
        End Property

        Public Property DraftNotes() As String
            Get
                DraftNotes = stRowData.DraftNotes
            End Get
            Set(ByVal value As String)
                stRowData.DraftNotes = value
            End Set
        End Property

        Public Property CheckMemo() As String
            Get
                CheckMemo = stRowData.CheckMemo
            End Get
            Set(ByVal value As String)
                stRowData.CheckMemo = value
            End Set
        End Property

        Public Property cardType() As String
            Get
                cardType = stRowData.CardType
            End Get
            Set(ByVal value As String)
                stRowData.CardType = value
            End Set
        End Property

        Public Property Scholarship() As Boolean
            Get
                Scholarship = stRowData.Scholarship
            End Get
            Set(ByVal value As Boolean)
                stRowData.Scholarship = value
            End Set
        End Property

        Public Property FamilyDisc() As Boolean
            Get
                FamilyDisc = stRowData.FamilyDisc
            End Get
            Set(ByVal value As Boolean)
                stRowData.FamilyDisc = value
            End Set
        End Property

        Public Property Rollover() As Boolean
            Get
                Rollover = stRowData.Rollover
            End Get
            Set(ByVal value As Boolean)
                stRowData.Rollover = value
            End Set
        End Property

        Public Property OutOfTown() As Boolean
            Get
                OutOfTown = stRowData.OutOfTown
            End Get
            Set(ByVal value As Boolean)
                stRowData.OutOfTown = value
            End Set
        End Property

        Public Property PlaysDown() As Boolean
            Get
                PlaysDown = stRowData.PlaysDown
            End Get
            Set(ByVal value As Boolean)
                stRowData.PlaysDown = value
            End Set
        End Property

        Public Property PaidDate() As Date
            Get
                PaidDate = stRowData.PaidDate
            End Get
            Set(ByVal value As Date)
                stRowData.PaidDate = value
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

        Public Property PayerID() As Integer
            Get
                PayerID = stRowData.PayerID
            End Get
            Set(ByVal value As Integer)
                stRowData.PayerID = value
            End Set
        End Property

        Public Property PP_Fee() As Integer
            Get
                PP_Fee = stRowData.PP_Fee
            End Get
            Set(ByVal value As Integer)
                stRowData.PP_Fee = value
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

        Public Property TrxID() As String
            Get
                TrxID = stRowData.TrxID
            End Get
            Set(ByVal value As String)
                stRowData.TrxID = value
            End Set
        End Property

        Public Property ErrMsg() As String
            Get
                ErrMsg = stRowData.ErrMsg
            End Get
            Set(ByVal value As String)
                stRowData.ErrMsg = value
            End Set
        End Property


        Public Structure RowFields
            Public CompanyId As Integer
            Public PlayerId As Integer
            Public SeasonId As Integer
            Public PeopleId As Integer
            Public DivisionId As Integer
            Public TeamId As Integer
            Public DraftId As String
            Public Notes As String
            Public School As String
            Public Grade As String
            Public DraftNotes As String
            Public CheckMemo As String
            Public Rating As Integer
            Public Coach As Boolean
            Public CoachID As Integer
            Public Sponsor As Boolean
            Public SponsorID As Integer
            Public Scholarship As Boolean
            Public FamilyDisc As Boolean
            Public Rollover As Boolean
            Public OutOfTown As Boolean
            Public RefundBatchID As Integer
            Public PaidDate As Date
            Public PaidAmount As Integer
            Public BalanceOwed As Integer
            Public PayType As String
            Public CardType As String
            Public UserID As String
            Public PlaysDown As Boolean
            Public ShoppingCartID As Integer
            Public HouseID As Integer
            Public PayerID As Integer
            Public Email As String
            Public TrxID As String
            Public PP_Fee As Integer
            Public ErrMsg As String
        End Structure

        Public stRowData As RowFields

        Property PlaysUp As Integer

        Property AthleticDirector As Integer

        Public Function GetCoachKids(ByVal iSeasonID As Int32, ByVal iCoachID As Int32, ByVal iCompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT Players.PeopleID, Players.PlayerID, (People.LastName + ', ' + People.FirstName) as Name "
                sSQL += "FROM People INNER JOIN Players ON People.PeopleID = Players.PeopleID AND People.CompanyID = Players.CompanyID"
                sSQL += " WHERE Players.SeasonID =" & iSeasonID
                sSQL += " AND Players.CoachID=" & iCoachID
                sSQL += " AND People.CompanyID = " & iCompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetCoachKids::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetHousePlayers(ByVal RowId As Int32, ByVal iSeasonID As Int32, ByVal iHouseID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetPlayers @SeasonID = " & iSeasonID & ", @HouseID= " & iHouseID
                sSQL += ", @CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetHousePlayers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetSeasonPlayers(ByVal RowId As Int32, ByVal iSeasonID As Int32, ByVal CompanyID As Int32, Optional ByVal iExcludeAdults As Int32 = 0) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetPlayersList @SeasonID = " & iSeasonID & ", @ExcludeAdults= " & iExcludeAdults
                sSQL += ", @CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetSeasonPlayers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetRegisteredPlayers(ByVal iTransactionID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetRegisteredPlayers @TransactionID = " & iTransactionID
                sSQL += ", @CompanyID = " & CompanyId
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetRegisteredPlayers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetRoster(ByVal iSeasonID As Int32, ByVal iDivisionID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetRoster @SeasonID = " & iSeasonID & ", @DivisionID= " & iDivisionID
                sSQL += ", @CompanyID = " & CompanyId
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetRoster::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetUnpaid(ByVal iSeasonID As Int32, ByVal iDrafted As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetUnpaid @SeasonID = " & iSeasonID & ", @Drafted= " & iDrafted
                sSQL += ", @CompanyID = " & CompanyId
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetUnpaid::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetWaitingList(ByVal iSeasonID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetWaitingList @SeasonID = " & iSeasonID
                sSQL += ", @CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetWaitingList::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetRegistration(ByVal iSeasonID As Int32, ByVal iPeopleID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetRegistration @SeasonID = " & iSeasonID & ", @PeopleID= " & iPeopleID
                sSQL += ", @CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetRegistration::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetRefunds(ByVal iSeasonID As Int32, ByVal iRType As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetRefunds @SeasonID = " & iSeasonID & ", @RType= " & iRType
                sSQL += ", @CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetRefunds::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetRefundPlayers(ByVal iSeasonID As Int32, ByVal iRType As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetRefundPlayers @SeasonID = " & iSeasonID & ", @RType= " & iRType
                sSQL += ", @CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetRefundPlayers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetDraftList(ByVal iDivisionID As Int32, ByVal iSeasonID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetDraftList @Division = " & iDivisionID & ", @Season= " & iSeasonID
                'sSQL += ", @CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetDraftList::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetBatchPlayers(ByVal iBatchID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetBatchPlayers @BatchID = " & iBatchID
                sSQL += ", @CompanyID = " & CompanyID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetBatchPlayers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetPlayers(ByVal SeasonID As Int32, ByVal HouseID As Int32, ByVal CompanyID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = " EXEC GetPlayers @SeasonID = " & SeasonID
                sSQL += ", @HouseID = " & HouseID
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetPlayers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetUndrafted(ByVal DivisionID As Long, ByVal CompanyID As Int32, ByVal SeasonID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT Players.PeopleID, Players.DraftID, (rtrim(People.LastName) + ', ' + People.FirstName) as Name, SpoName "
                sSQL += " FROM People INNER JOIN Players ON People.PeopleID = Players.PeopleID AND People.CompanyID = Players.CompanyID"
                sSQL += " LEFT Join Sponsors ON Players.SponsorID = Sponsors.SponsorID AND Players.CompanyID = Sponsors.CompanyID"
                sSQL += " WHERE Players.SeasonID= " & SeasonID
                sSQL += " AND (Players.TeamID Is Null or Players.TeamID = 0) "
                sSQL += " AND Players.DivisionID=" & DivisionID
                sSQL += " AND Players.CompanyID = " & CompanyID
                sSQL += " order by DraftID"
                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetUndrafted::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetRecords(ByVal PeopleID As Long, ByVal CompanyID As Int32, ByVal SeasonID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try

                sSQL = "SELECT Players.PlayerID, Players.SeasonID, Players.PeopleID, BalanceOwed, "
                sSQL += "Teams.TeamID, Divisions.DivisionID, Divisions.Div_Desc, "
                sSQL += "Teams.TeamNumber, Colors.ColorName as TeamColor, Teams.TeamName "
                sSQL += "FROM  Players LEFT JOIN Teams ON Players.TeamID = Teams.TeamID AND Players.CompanyID = Teams.CompanyID "
                sSQL += "LEFT JOIN Divisions ON Players.DivisionID = Divisions.DivisionID AND Players.CompanyID = Divisions.CompanyID "
                sSQL += "LEFT JOIN Colors ON teams.teamcolorid = Colors.ID AND teams.CompanyID = Colors.CompanyID "
                sSQL += "where Players.PeopleID = " & PeopleID
                sSQL += " AND Players.seasonID = " & SeasonID
                sSQL += " AND Players.CompanyID = " & CompanyID

                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetRecords::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Function GetTeamPlayers(ByVal TeamID As Long, ByVal CompanyID As Int32, ByVal SeasonID As Int32) As DataTable
            Dim DB As New ClsDatabase
            Try
                sSQL = "SELECT Players.DraftID, Players.PeopleID, (FirstName +' '+ LastName) AS Name, People.BirthDate, Households.Phone, People.Gender, Players.PlayerID "
                sSQL += "FROM People "
                sSQL += "INNER JOIN Players ON People.PeopleID = Players.PeopleID AND People.CompanyID = Players.CompanyID "
                sSQL += "INNER JOIN Teams ON Players.TeamID = Teams.TeamID AND Players.CompanyID = Teams.CompanyID "
                sSQL += "INNER JOIN Seasons ON Seasons.SeasonID = Players.SeasonID AND Teams.SeasonID = Seasons.SeasonID AND Seasons.CompanyID = Players.CompanyID "
                sSQL += "INNER JOIN Households ON People.HouseID = Households.HouseID AND People.CompanyID = Households.CompanyID "
                sSQL += " where Teams.TeamID = " & TeamID
                sSQL += " AND Players.CompanyID = " & CompanyID
                sSQL += " order by Players.draftID"

                Return DB.ExecuteGetSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:GetTeamPlayers::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Function

        Public Sub AddNewPlayer()
            Dim DB As New ClsDatabase
            Try
                'Find the next ID
                sSQL = "SELECT isnull(MAX(PlayerID),0) + 1 as PlayerID from Players where CompanyID = " & CompanyId
                PlayerId = DB.ExecuteGetID(sSQL)

                sSQL = "INSERT INTO Players (CompanyID, PlayerID, SeasonID, PeopleID, DraftID, Rating, PayType, Scholarship, Rollover, FamilyDisc, OutOfTown, "
                sSQL += "SponsorID, CoachID, NoteDesc, CheckMemo, PlaysDown, CreatedUser, DraftNotes, PaidDate, PaidAmount, BalanceOwed)"
                sSQL += " VALUES "
                sSQL += "( " & dbIntField(vbNull, CompanyId)
                sSQL += ", " & dbIntField(vbNull, PlayerId)
                sSQL += ", " & dbIntField(vbNull, SeasonId)
                sSQL += ", " & dbIntField(0, PeopleId)
                sSQL += ", " & dbStrField("", DraftId)
                sSQL += ", " & dbIntField(vbNull, Rating)
                sSQL += ", " & dbStrField("Check", PayType)
                sSQL += ", " & dbBoolField(0, Scholarship)
                sSQL += ", " & dbBoolField(0, Rollover)
                sSQL += ", " & dbBoolField(0, FamilyDisc)
                sSQL += ", " & dbBoolField(0, OutOfTown)
                sSQL += ", " & dbIntField(0, SponsorID)
                sSQL += ", " & dbIntField(0, CoachID)
                sSQL += ", " & dbStrField("", Notes)
                sSQL += ", " & dbStrField("", CheckMemo)
                sSQL += ", " & dbBoolField(False, PlaysDown)
                sSQL += ", " & dbStrField("", UserID)
                sSQL += ", " & dbStrField("", DraftNotes)
                sSQL += ", " & dbDateField("NULL", PaidDate)
                sSQL += ", " & dbIntField(0, PaidAmount)
                sSQL += ", " & dbIntField(0, BalanceOwed)
                sSQL += ")"
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:AddNewPlayer::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub DeletePlayer(ByVal PLAYERID As Int32, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Players where PLAYERID=" & PLAYERID & " AND CompanyID=" & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:DeletePlayer::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub DELPlayerByPeople(ByVal PeopleID As Long, ByVal CompanyID As Int32, ByVal SeasonID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "DELETE FROM Players where PeopleId=" & PeopleID
                sSQL += " AND SeasonID = " & SeasonID
                sSQL += " AND CompanyID = " & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:DELPlayerByPeople::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdatePlayer(ByVal PeopleId As Int32, ByVal CompanyID As Int32, ByVal SeasonID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "Update Players "
                If PeopleId > 0 Then
                    sSQL += " set TeamID = " & TeamId
                    sSQL += " where PeopleID = " & PeopleId
                Else
                    sSQL += " set TeamID = 0"
                    sSQL += " where TeamID = " & TeamId
                End If
                sSQL += " AND SeasonID = " & SeasonId
                sSQL += " AND CompanyID = " & CompanyID
                sSQL += " AND RefundBatchID = 0"
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:UpdatePlayer::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub ApplyEdit(ByVal PlayerID As Int32, ByVal CompanyID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "UPDATE Players SET "
                sSQL += "DraftID = " & dbStrField("", DraftId)
                sSQL += ", Rating = " & dbIntField(vbNull, Rating)
                sSQL += ", PayType = " & dbStrField("Check", PayType)
                sSQL += ", Scholarship = " & dbBoolField(0, Scholarship)
                sSQL += ", Rollover = " & dbBoolField(0, Rollover)
                sSQL += ", FamilyDisc = " & dbBoolField(0, FamilyDisc)
                sSQL += ", OutOfTown = " & dbBoolField(0, OutOfTown)
                sSQL += ", SponsorID = " & dbIntField(0, SponsorID)
                sSQL += ", CoachID = " & dbIntField(0, CoachID)
                sSQL += ", NoteDesc = " & dbStrField("", Notes)
                sSQL += ", CheckMemo = " & dbStrField("", CheckMemo)
                sSQL += ", PlaysDown = " & dbBoolField(False, PlaysDown)
                sSQL += ", DraftNotes = " & dbStrField("", DraftNotes)
                sSQL += ", PaidDate = " & dbDateField("NULL", PaidDate)
                sSQL += ", PaidAmount = " & dbIntField(0, PaidAmount)
                sSQL += ", BalanceOwed = " & dbIntField(0, BalanceOwed)
                sSQL += " WHERE PlayerID=" & PlayerID
                sSQL += " AND CompanyID=" & CompanyID
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:ApplyEdit::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub AddRecord()
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC AddPlayer "
                sSQL += " @PeopleID=" & dbIntField(0, PeopleId)
                sSQL += ", @CompanyID=" & dbIntField(0, CompanyId)
                sSQL += ", @DivisionID = " & dbIntField(0, DivisionId)
                sSQL += ", @Notes = " & dbStrField("", Notes)
                sSQL += ", @Amount=" & dbIntField(0, PaidAmount)
                sSQL += ", @CardType = " & dbStrField("", cardType)
                sSQL += ", @UserID = " & dbStrField("", UserID)
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:AddRecord::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub UpdatePayment()
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC UpdatePlayersPayment "
                sSQL += "@HouseID = " & dbIntField(0, HouseID)
                sSQL += ", @CompanyID=" & dbIntField(0, CompanyId)
                sSQL += ", @Payer_ID = " & dbIntField(vbNull, PayerID)
                sSQL += ", @Amount = " & dbIntField(vbNull, PaidAmount)
                sSQL += ", @Payer_Email = " & dbStrField("", Email)
                sSQL += ", @Txn_ID = " & dbStrField("", TrxID)
                sSQL += ", @Payment_Status = " & dbBoolField(0, FamilyDisc)
                sSQL += ", @UserName = " & dbStrField("", UserID)
                sSQL += ", @PP_Fee = " & dbIntField(0, PP_Fee)
                sSQL += ", @ErrorMSG = " & dbStrField("", ErrMsg)
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:UpdatePayment::" & ex.Message)
            Finally
                DB = Nothing
            End Try
        End Sub

        Public Sub SetDivision(ByVal PeopleID As Long, ByVal CompanyID As Int32, ByVal SeasonID As Int32)
            Dim DB As New ClsDatabase
            Try
                sSQL = "EXEC SetDivision "
                sSQL += " @iPeopleID =" & dbIntField(0, PeopleId)
                sSQL += ", @iSeason=" & dbIntField(0, SeasonId)
                sSQL += ", @CompanyID=" & dbIntField(0, CompanyId)
                DB.ExecuteUpdSQL(sSQL)
            Catch ex As Exception
                Throw New Exception("ClsPlayers:SetDivision::" & ex.Message)
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

        Function GetPlayers(p1 As Object) As DataTable
            Throw New NotImplementedException
        End Function

        Function GetPeopleID(p1 As Object) As Object
            Throw New NotImplementedException
        End Function

        Function GetPlayer(p1 As Object, PlayerID As Long, p3 As Object) As DataTable
            Throw New NotImplementedException
        End Function

    End Class
End Namespace

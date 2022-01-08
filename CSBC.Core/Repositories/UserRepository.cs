using CSBC.Core.Data;
using CSBC.Core.Interfaces;
using CSBC.Core.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CSBC.Core.Repositories
{
    public class UserRepository : IRepository<User>
    {

        protected CSBCDbContext DataContext { get; set; }
        protected DbSet<User> DbSet;
        private string sSQL;

        public UserRepository(CSBCDbContext dataContext)
        {
            DataContext = dataContext;
        }

        #region IRepository<T> Members
        public User Insert(User entity)
        {

            entity.UserID = DataContext.Users.Any() ? DataContext.Users.Max(t => t.UserID) + 1 : 1;
            User newUser = DataContext.Users.Add(entity);
            var no = DataContext.SaveChanges();
            return newUser;

        }
        public void Update(User entity)
        {
            var user = GetById(entity.UserID);
            user = entity;
            DataContext.SaveChanges();
        }
        public void Delete(User entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<User> SearchFor(Expression<Func<User, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<User> GetAll()
        {
            return DataContext.Users.Select(s => s);
        }
        public IQueryable<User> GetAll(int companyId)
        {
            return DataContext.Users.Where(s => s.CompanyID == companyId);
        }

        public IQueryable<User> GetByUserType(int userType)
        {
            return DataContext.Users.Where(s => s.UserType == userType);
        }

        public User GetById(int id)
        {
            return DataContext.Users.Find(id);
        }

        #endregion


        void IRepository<User>.Delete(User entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<User> IRepository<User>.GetAll()
        {
            throw new NotImplementedException();
        }

        User IRepository<User>.GetById(int id)
        {
            return DataContext.Users.Find(id);
        }

        public User GetUser(string sUserName, string sPwd)
        {
            try
            {
           
                var user = DataContext.Users.FirstOrDefault(u => u.UserName.ToLower() == sUserName.ToLower());
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsUsers:GetUser::" + ex.Message);
            }

        }

        public Task<User> GetUserAsync(string sUserName, string sPwd)
        {
            // var DB = new CSBC.Core.Data.CSBCDbContext();
           
            try
            {
                //var repo = new UserRepository(DB);
                var user = DataContext.Users.FirstOrDefaultAsync(u => u.Name.ToLower() == sUserName.ToLower());
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsUsers:GetUser::" + ex.Message);
            }

        }
        public String Quo(String InString)
        {
            String newString;
            newString = InString.Replace("'", "''");
            return "'" + newString + "'";
        }
        public String Quotes(String @in)
        {
            String @out;
            @out = @in.Replace("'", "''");
            return "'" + @out.ToUpper() + "'";
        }

        //TODO:: Company
        //Public Sub GetCompanyInfo(ByVal iUserID As Int32, ByVal SeasonID As Int32)
        //    Dim DB As New ClsDatabase
        //    Dim dtResults As DataTable
        //    Try
        //        sSQL = "EXEC CompanyInfo @UserID = " & sGlobal.Quo(iUserID)
        //        sSQL += ", @SeasonID = " & SeasonID
        //        dtResults = DB.ExecuteGetSQL(sSQL)
        //        CompanyID = dtResults.Rows(0).Item("CompanyID").ToString
        //        CompanyName = dtResults.Rows(0).Item("CompanyName").ToString
        //        ImageName = dtResults.Rows(0).Item("ImageName").ToString
        //        TimeZone = dtResults.Rows(0).Item("TimeZone").ToString
        //        SeasonID = dtResults.Rows(0).Item("SeasonID").ToString
        //        UserName = dtResults.Rows(0).Item("UserName").ToString
        //        SeasonDesc = dtResults.Rows(0).Item("Sea_Desc").ToString
        //    Catch ex As Exception
        //        Throw New Exception("ClsUsers:GetCompanyInfo::" & ex.Message)
        //    Finally
        //        DB = Nothing
        //        dtResults = Nothing
        //    End Try

        //End Sub

        public DataTable GetSeason(Int32 CompanyID)
        {
            var DB = new CSBC.Core.Data.CSBCDbContext();
            DataTable dtResults = default(DataTable);
            
            try
            {
                sSQL = "SELECT SeasonID, Sea_Desc, FromDate FROM Seasons WHERE Seasons.CurrentSeason=1";
                sSQL += " AND CompanyID = " + Quo(CompanyID.ToString());
                //TODO:: Company
                sSQL = "SELECT SeasonID, Sea_Desc, FromDate FROM Seasons WHERE Seasons.CurrentSeason=1";
                dtResults = DB.ExecuteGetSQL(sSQL);
                return dtResults;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsUsers:GetSeason::" + ex.Message);
            }
        }

        public User GetLoginInfo(string userName, string password)
        {
            var db = new CSBCDbContext();

            try
            {
                var repo = new UserRepository(db);
                var user = repo.GetUser(userName, password);
                return user;
                // sSQL = "SELECT SeasonID, Sea_Desc, FromDate FROM vw_CheckLogin WHERE Seasons.CurrentSeason=1";
                //sSQL += " AND CompanyID = " + sGlobal.Quo(CompanyID.ToString());
                //dtResults = db.ExecuteGetSQL(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("ClsUsers:GetSeason::" + ex.Message);
            }

        }

        public Task<User> GetLoginInfoAsync(string userName, string password)
        {
            var db = new CSBCDbContext();
           
            
            try
            {
                var repo = new UserRepository(db);
                var user = repo.GetUserAsync(userName, password);
                return user;
                // sSQL = "SELECT SeasonID, Sea_Desc, FromDate FROM vw_CheckLogin WHERE Seasons.CurrentSeason=1";
                //sSQL += " AND CompanyID = " + sGlobal.Quo(CompanyID.ToString());
                //dtResults = db.ExecuteGetSQL(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("ClsUsers:GetSeason::" + ex.Message);
            }
           
        }
        /*
        public void DELUserPtn(long HouseId, Int32 CompanyID)
        {
            var DB = new CSBC.Core.Data.CSBCDbContext();
            DataTable dtResults = default(DataTable);
            var sGlobal = new ClsGlobal();
            try {
                sSQL = "Update USERS set HouseId = " + Constants.vbNull;
                sSQL += " where HouseId=" + HouseId;
                sSQL += " AND CompanyID = " + CompanyID;
                //TODO:: Company
                sSQL = "Update USERS set HouseId = " + Constants.vbNull;
                sSQL += " where HouseId=" + HouseId;
                DB.ExecuteUpdSQL(sSQL);
            } catch (Exception ex) {
                throw new Exception("ClsUsers:DELUserPtn::" + ex.Message);
            } finally {
                DB = null;
            }
        }
        */
        private string HashPassword(string password)
        {
            string hashedPassword = null;
            dynamic hashProvider = new SHA256Managed();
            try
            {
                byte[] passwordBytes = null;
                //Dim hashBytes() As Byte
                passwordBytes = System.Text.Encoding.Unicode.GetBytes(password);
                //hashProvider = New SHA256Managed
                hashProvider.Initialize();
                passwordBytes = hashProvider.ComputeHash(passwordBytes);
                hashedPassword = Convert.ToBase64String(passwordBytes);
            }
            finally
            {
                if ((hashProvider != null))
                {
                    hashProvider.Clear();
                    hashProvider = null;
                }
            }
            return hashedPassword;

        }

        public string GetAccess(Int32 iUserID, string sScreen, Int32 iCompanyID, Int32 iSeasonID = 0)
        {
            var DB = new CSBC.Core.Data.CSBCDbContext();
            DataTable dtResults = default(DataTable);
            var accessType = String.Empty;
            try
            {
                sSQL = "EXEC GetAccess";
                sSQL += " @UserCode = " + iUserID;
                sSQL += ", @Screen = " + Quo(sScreen);
                sSQL += ", @SeasonID = " + iSeasonID;
                sSQL += ", @CompanyID = " + iCompanyID;
                //TODO:: Company
                sSQL = "EXEC GetAccess";
                sSQL += " @UserCode = " + iUserID;
                sSQL += ", @Screen = " + Quo(sScreen);
                sSQL += ", @SeasonID = " + iSeasonID;
                dtResults = DB.ExecuteGetSQL(sSQL);
                accessType = dtResults.Rows[0]["accesstype"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ClsUsers:GetAccess::" + ex.Message);
            }
            finally
            {
                DB = null;
                dtResults = null;
                
            }
            return accessType;
        }

        public void GetEmail(int CompanyID, string sUserName)
        {
            var DB = new CSBC.Core.Data.CSBCDbContext();
            DataTable dtResults = default(DataTable);
            try
            {
                sSQL = "exec CheckEmail @UName=" + Quotes(sUserName);
                sSQL += ", @CompanyID = " + CompanyID;
                //TODO:: Company
                sSQL = "exec CheckEmail @UName=" + Quotes(sUserName);
                dtResults = DB.ExecuteGetSQL(sSQL);
                if (dtResults.Rows.Count > 0)
                {
                    var user = new User
                    {
                        //user.Email = dtResults.Rows[0]["Email"].ToString();
                        PWord = dtResults.Rows[0]["PWord"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ClsUsers:GetEmail::" + ex.Message);
            }
            finally
            {
                DB = null;
                dtResults = null;
            }
        }
        /*
        public void AddUser(User user, Int32 iTimeZone)
        {
            var DB = new CSBC.Core.Data.CSBCDbContext();
            DataTable dtResults = default(DataTable);
            var sGlobal = new ClsGlobal();
            try {
                sSQL = "EXEC sp_UpdUser ";
                sSQL += " @UserId = 0";
                sSQL += ", @UserName = " + user.UserName);
                sSQL += ", @Name = " + user.Name);
                sSQL += ", @PWord = " + user.PWord);
                sSQL += ", @Password = " + dbStrField("", HashPassword(PWord));
                sSQL += ", @UserType = " + dbIntField(0, Usertype);
                sSQL += ", @HouseID = " + dbStrField("", HouseID);
                sSQL += ", @CompanyID = " + dbStrField("", CompanyID);
                sSQL += ", @Roles = " + dbStrField("", Strings.Space(1));
                sSQL += ", @CreatedUser = " + dbStrField("", CreatedUser);
                sSQL += ", @CreatedDate = " + sGlobal.Quo(sGlobal.TimeAdjusted(iTimeZone, Now()));

                dtResults = DB.ExecuteGetSQL(sSQL);
                UserID = Int32.Parse(dtResults.Rows[0]["UserID"].ToString());

            } catch (Exception ex) {
                throw new Exception("ClsUsers:AddUser::" + ex.Message);
            } finally {
                DB = null;
            }
        }
        */
        public void UpdPWD(User user)
        {
            var DB = new CSBC.Core.Data.CSBCDbContext();

            try
            {
                sSQL = "EXEC sp_UpdPWD ";
                sSQL += " @UserName = " + user.UserName;
                sSQL += ", @PWord = " + user.PWord;
                sSQL += ", @Password = " + HashPassword(user.PassWord);
                sSQL += ", @CompanyID = " + user.CompanyID.ToString();

                DB.ExecuteGetSQL(sSQL);

            }
            catch (Exception ex)
            {
                throw new Exception("ClsUsers:UpdPWD::" + ex.Message);
            }
        }
        public User GetUserByHouseId(int houseId)
        {
            var user = DataContext.Users.FirstOrDefault(u => u.HouseID == houseId);
            return user;
        }
    }
}


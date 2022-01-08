using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using CSBC.Core.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Web.Configuration;
using System.Configuration;

namespace CSBC.Core.Data
{
    public class CSBCDbContext : DbContext
    {
        public IDbSet<Company> Companies { get; set; }
        public IDbSet<Person> People { get; set; }
        public IDbSet<Coach> Coaches { get; set; }
        public IDbSet<Player> Players { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<Season> Seasons { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Household> Households { get; set; }
        public IDbSet<Director> Directors { get; set; }
        public IDbSet<Color> Colors { get; set; }
        public IDbSet<Summary> Summaries { get; set; }
        public IDbSet<Division> Divisions { get; set; }
        public IDbSet<Sponsor> Sponsors { get; set; }
        public IDbSet<SponsorProfile> SponsorProfiles { get; set; }
        public IDbSet<SponsorPayment> SponsorPayments { get; set; }
        public IDbSet<ScheduleGame> ScheduleGames { get; set; }
        public IDbSet<SchedulePlayoff> SchedulePlayoffs { get; set; }
        public IDbSet<ScheduleLocation> ScheduleLocations { get; set; }
        public IDbSet<ScheduleDivision> ScheduleDivisions { get; set; }
        public IDbSet<ScheduleDivTeam> ScheduleDivTeams { get; set; }
        public IDbSet<vw_Divisions> vwDivisions { get; set; }
        public IDbSet<vw_Directors> vwDirectors { get; set; }
        public IDbSet<vw_Coaches> vwCoaches { get; set; }
        public IDbSet<Content> Contents { get; set; }
        public IDbSet<WebContentType> WebContentTypes { get; set; }
        public IDbSet<WebContent> WebContents { get; set; }
        public IDbSet<SeasonCount> SeasonCounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            /*modelBuilder
                .Entity<Player>()
                .MapToStoredProcedures(s => s.Insert(a => a.HasName("AddPlayer")
                    .Parameter(p => p.PeopleID, "@PeopleID")
                    .Parameter(p => p.DivisionID, "@DivisionID")
                    .Parameter(p => p.DraftNotes, "@notes")
                    .Parameter(p => p.PaidAmount, "@Amount")
                    .Parameter(p => p.PayType, "@CardType")
                    .Parameter(p => p.CreatedUser, "@UserID")
                    ))
                ;
            modelBuilder
                .Entity<Player>();
                \\.MapToStoredProcedures(s => s.Update(a => a.HasName("sp_UpdPlayer")));
            modelBuilder
                .Entity<Player>()
                .MapToStoredProcedures(s => s.Delete(a => a.HasName("sp_DelPlayer")));
            */
            modelBuilder
             .Entity<Player>()
             .ToTable("Players");

            modelBuilder
                .Entity<Director>()
                .ToTable("Directors");

            modelBuilder
                .Entity<Person>()
                .ToTable("People");

            modelBuilder
                .Entity<Color>()
                .ToTable("Colors");

            modelBuilder
                .Entity<Household>()
                .ToTable("Households");
            //.HasOptional(p => p.People);

            modelBuilder
             .Entity<Division>()
             .ToTable("Divisions");

            modelBuilder
                 .Entity<Team>()
                 .ToTable("Teams");

            modelBuilder
                .Entity<SponsorProfile>()
                .ToTable("SponsorProfile")
                .HasMany(s => s.Sponsors)
                .WithRequired(s => s.SponsorProfile)
                .HasForeignKey(s => s.SponsorProfileID);

            modelBuilder
                .Entity<Sponsor>()
                .ToTable("Sponsors");
                //.HasMany(sponsors => sponsors.SponsorProfiles)
                //.WithRequired(sponsors => sponsors.)
                //.HasOptional<SponsorProfile>(s => s.SponsorProfile)
                //.WithOptionalPrincipal()
                //.Map(k => k.MapKey("SponsorProfileID"));

            modelBuilder
               .Entity<SponsorPayment>()
               .ToTable("SponsorPayments");

            modelBuilder
                .Entity<Coach>()
                .ToTable("Coaches");

            modelBuilder
                .Entity<ScheduleGame>()
                .ToTable("ScheduleGames");

            modelBuilder
                .Entity<SchedulePlayoff>()
                .ToTable("SchedulePlayoffs");

            modelBuilder
                .Entity<ScheduleLocation>()
                .ToTable("ScheduleLocations");

            modelBuilder
                .Entity<User>()
                .ToTable("Users");

            modelBuilder
                .Entity<Role>()
                .ToTable("Rolls");

            modelBuilder
               .Entity<ScheduleDivision>()
               .ToTable("ScheduleDivisions");
            
            modelBuilder
              .Entity<ScheduleDivTeam>()
              .ToTable("ScheduleDivTeams");


        }

        private string sSQL;
        private SqlConnection CN;
        // private CSBC.Components.ClsGlobal sGlobal = new CSBC.Components.ClsGlobal();
        private string CNString = WebConfigurationManager.AppSettings["MyCN"];
        public bool TestMode
        {
            get;
            set;
        }
        public int ServerTimeAdj
        {
            get
            {
                string strServerTime = WebConfigurationManager.AppSettings["ServerTime"];
                return Int32.Parse(strServerTime);
            }
        }
        public string CSDBConnectionString
        {
            get {
                string connectionString;
                if (TestMode)
                {
                    connectionString = "testCN";
                }
                else
                {
                    connectionString = "MyCN";
                }
                return WebConfigurationManager.AppSettings[connectionString]; }
        }

   
        public CSBCDbContext()
        {
            Database.Connection.ConnectionString = CSDBConnectionString;
            string connStr = ConfigurationManager.ConnectionStrings["CSBCDbContext"].ConnectionString;
            Database.Connection.ConnectionString = connStr;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DataTable AccessType(long UserCode, int sSeasonId, string sScreen)
        {
            DataTable dataTable = default(DataTable);
            try
            {
                sSQL = "exec GetAccess @UserCode = " + UserCode;
                sSQL = sSQL + ", @Screen = " + sScreen;
                sSQL = sSQL + ", @SeasonId = " + sSeasonId;

                dataTable = ExecuteGetSQL(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("ClsDatabase:AccessType::" + ex.Message);
            }
            finally
            {
                CN = null;
            }
            return dataTable;
        }

        public Int32 ExecuteGetID(string sSQL)
        {
            dynamic dtResults = new DataTable();
            CN = new SqlConnection();
            CN.ConnectionString = CNString;
            CN.Open();
            dynamic myAdapter = new SqlDataAdapter(sSQL, CN);
            try
            {
                myAdapter.Fill(dtResults);
                myAdapter.Dispose();
                myAdapter = null;
                return dtResults.Rows(0).Item(0);
            }
            catch (Exception ex)
            {
                throw new Exception("ClsDatabase:ExecuteGetID::" + ex.Message);
            }
            finally
            {
                CN.Close();
                CN = null;
            }
        }

        public DataTable ExecuteGetSQL(string sSQL)
        {
            var dtResults = new DataTable();
            CN = new SqlConnection();
            CN.ConnectionString = CNString;
            CN.Open();
            var myAdapter = new SqlDataAdapter(sSQL, CN);
            try
            {
                myAdapter.Fill(dtResults);
                myAdapter.Dispose();
                myAdapter = null;
                return dtResults;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsDatabase:ExecuteGetSQL::" + ex.Message);
            }
        }

        public void ExecuteUpdSQL(string sSQL)
        {
            CN = new SqlConnection();
            CN.ConnectionString = CNString;
            CN.Open();
            SqlCommand selectCMD = new SqlCommand(sSQL, CN);
            try
            {
                selectCMD.ExecuteNonQuery();
                CN.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("ClsDatabase:ExecuteUpdSQL::" + ex.Message);
            }
            finally
            {
                selectCMD = null;
                CN.Close();
                CN = null;
            }
        }
    }

}


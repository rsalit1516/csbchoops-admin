using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;
using CSBC.Core.Models;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace CSBC.Core.Repositories
{
    public class ScheduleGameRepository : EFRepository<ScheduleGame>, IScheduleGameRepository, IDisposable
    {

        
        public ScheduleGameRepository(DbContext context) : base(context) { }

        //protected DbSet<ScheduleGame> DbSet;

        //protected CSBCDbContext DataContext { get; set; }
        #region IRepository<T> Members

        
        public IQueryable<ScheduleGame> GetByDate(DateTime date)
        {
            var games = Context.Set<ScheduleGame>().Where(s => s.GameDate == date);
            return games;
        }

        public ScheduleGame GetByScheduleAndGameNo(ScheduleGame game)
        {
            var result = Context.Set<ScheduleGame>().FirstOrDefault(s => s.ScheduleNumber == game.ScheduleNumber && s.GameNumber == game.GameNumber && s.DivisionId == game.DivisionId && s.SeasonId == game.SeasonId);
            return result;
        }
        public ScheduleGame GetByScheduleGamesId(int scheduleGamesId)
        {
            var result = Context.Set<ScheduleGame>().FirstOrDefault(s => s.ScheduleGamesId == scheduleGamesId);
            return result;
        }
        #endregion


        public override void Delete(ScheduleGame entity)
        {

            // var db = new CSBCDbContext();
            //using (Context)
            //{

            //    using (SqlCommand command = new SqlCommand("delete from ScheduleGames where ScheduleNumber = " + entity.ScheduleNumber.ToString() + " and GameNumber = " + entity.GameNumber.ToString(), connection))
            //    {
            //        command.ExecuteNonQuery();
            //    }

            //}
            var scheduleGame = Context.Set<ScheduleGame>().FirstOrDefault(g => g.ScheduleGamesId == entity.ScheduleGamesId);
            if (scheduleGame != null)
            {
                Context.Set<ScheduleGame>().Remove(scheduleGame);
                Context.SaveChanges();
            }
        }
        
        public override void Update(ScheduleGame scheduleGame)
        {
            if (scheduleGame == null) throw new ArgumentNullException("scheduleGame");
            //var game = GetByScheduleAndGameNo(scheduleGame);
            var game = GetByScheduleGamesId(scheduleGame.ScheduleGamesId);
            //game = scheduleGame;
            Delete(game);
            Insert(scheduleGame);
        }

        public override ScheduleGame Insert(ScheduleGame scheduleGame)
        {
            if (scheduleGame.GameNumber == 0)
                scheduleGame.GameNumber = GetNextGameNo(scheduleGame.ScheduleNumber);
            var game = base.Insert(scheduleGame);
            return game;
        }

        private int GetNextGameNo(int scheduleNumber)
        {
            return Context.Set<ScheduleGame>()
                .Where(g => g.ScheduleNumber == scheduleNumber)
                .Any() 
                ? 
                (Context.Set<ScheduleGame>()
                .Where(g => g.ScheduleNumber == scheduleNumber).Max(g => g.GameNumber) + 1) : 1;
        }

        public DataSet GetGames(int iCompanyID, int iDivisionID, int iTeam, string divisionDescription, string sTeamDesc)
        {
            try
            {
                DataSet retval = new DataSet();
                var sqlConn = Context.Database.Connection as SqlConnection;
                //var sqlConn = entityConn.;
                var cmdReport = new SqlCommand("DivGames", sqlConn);
                var daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(new SqlParameter("@ScheduleNo", iDivisionID));
                    cmdReport.Parameters.Add(new SqlParameter("@Div", divisionDescription));
                    if (iDivisionID > 0)
                    {
                        cmdReport.Parameters.Add(new SqlParameter("@TeamNbr", iTeam));
                    }
                    daReport.Fill(retval);
                    return retval;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ClsSchedules:GetGames::" + ex.Message);
            }
        }

        public IQueryable<ScheduleGame> GetSeasonGames(int divisionId)
        {
            return Context.Set<ScheduleGame>().Where(g => g.DivisionId == divisionId);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        public ScheduleGame GetByScheduleAndGameNo(int scheduleNo, int gameNo)
        {
            return Context.Set<ScheduleGame>().FirstOrDefault(g => g.ScheduleNumber == scheduleNo && g.GameNumber == gameNo);
        }

        int IScheduleGameRepository.Update(ScheduleGame scheduleGame)
        {
            throw new NotImplementedException();
        }
    }
}


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

namespace CSBC.Core.Repositories
{
    public class SchedulePlayoffRepository : EFRepository<SchedulePlayoff>, ISchedulePlayoffRepository
    {

        public SchedulePlayoffRepository(DbContext context) : base(context) { }

        //protected DbSet<ScheduleGame> DbSet;

        //protected CSBCDbContext DataContext { get; set; }

        #region IRepository<T> Members
        public IQueryable<SchedulePlayoff> GetByDate(DateTime date)
        {
            var games = Context.Set<SchedulePlayoff>().Where(s => s.GameDate == date);
            return games;
        }
        public SchedulePlayoff GetByScheduleAndGameNo(int scheduleNo, int gameNo)
        {
            var game = Context.Set<SchedulePlayoff>().FirstOrDefault(s => s.ScheduleNumber == scheduleNo && s.GameNumber == gameNo);
            return game;
        }

        #endregion

        public new void Delete(SchedulePlayoff entity)
        {
           
            var scheduleGame = Context.Set<SchedulePlayoff>().FirstOrDefault(g => g.ScheduleNumber == entity.ScheduleNumber &&
                g.GameNumber == entity.GameNumber);
            if (scheduleGame != null)
            {
                Context.Set<SchedulePlayoff>().Remove(scheduleGame);
                Context.SaveChanges();
            }
        }
        public override SchedulePlayoff Insert(SchedulePlayoff schedulePlayoff)
        {
            if (schedulePlayoff.GameNumber == 0)
                schedulePlayoff.GameNumber = GetNextGameNo(schedulePlayoff.ScheduleNumber);
            var game = base.Insert(schedulePlayoff);
            return game;
        }


        private int GetNextGameNo(int scheduleNumber)
        {
            return Context.Set<SchedulePlayoff>()
                .Where(g => g.ScheduleNumber == scheduleNumber)
                .Any()
                ?
                (Context.Set<SchedulePlayoff>()
                .Where(g => g.ScheduleNumber == scheduleNumber).Max(g => g.GameNumber) + 1) : 1;
        }

        public override void Update(SchedulePlayoff schedulePlayoff)
        {
            if (schedulePlayoff == null) throw new ArgumentNullException("SchedulePlayoff");
            var game = GetByScheduleAndGameNo(schedulePlayoff.ScheduleNumber, schedulePlayoff.GameNumber);
            Delete(game);
            Insert(schedulePlayoff);

        }
    }
}


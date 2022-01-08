using CSBC.Core.Interfaces;
using CSBC.Core.Models;
using System.Data.Entity;
using System.Linq;

namespace CSBC.Core.Repositories
{
    public class ScheduleDivTeamsRepository : EFRepository<ScheduleDivTeam>, IScheduleDivTeamsRepository
    {
        //protected CSBCDbContext DataContext { get; set; }
        //protected DbSet<Household> DbSet;

        public ScheduleDivTeamsRepository(DbContext context) : base(context) { }

        // private CSBC.Components.ClsGlobal sGlobal = new CSBC.Components.ClsGlobal();

        public int GetTeamNo(int scheduleNo, int teamNo)
        {
            var scheduleTeamNo = 0;
            var team = Context.Set<ScheduleDivTeam>().FirstOrDefault(t => t.ScheduleNumber == scheduleNo && t.ScheduleTeamNumber == teamNo);
            if (team != null)
                scheduleTeamNo = team.TeamNumber;
            return scheduleTeamNo;
        }
    }
}
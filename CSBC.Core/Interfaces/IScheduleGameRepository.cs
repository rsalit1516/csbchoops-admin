using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;

namespace CSBC.Core.Interfaces
{
    public interface IScheduleGameRepository : IRepository<ScheduleGame>
    {
        IQueryable<ScheduleGame> GetByDate(DateTime date);
        ScheduleGame GetByScheduleAndGameNo(int scheduleNo, int gameNo);
        new int Update(ScheduleGame scheduleGame);
    }
}

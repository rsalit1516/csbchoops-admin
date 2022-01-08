using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;

namespace CSBC.Core.Interfaces
{
    public interface ISchedulePlayoffRepository : IRepository<SchedulePlayoff>
    {
        IQueryable<SchedulePlayoff> GetByDate(DateTime date);
        SchedulePlayoff GetByScheduleAndGameNo(int scheduleNo, int gameNo);
        new void Delete(SchedulePlayoff entity);
        
    }
}

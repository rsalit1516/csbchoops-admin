using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;

namespace CSBC.Core.Interfaces
{
    public interface IScheduleDivTeamsRepository : IRepository<ScheduleDivTeam>
    {
        int GetTeamNo(int scheduleNo, int teamNo);
    }
}

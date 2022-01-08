using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;
using System.Data;

namespace CSBC.Core.Interfaces
{
    public interface ICoachRepository : IRepository<Coach>
    {
        IQueryable<vw_Coaches> GetSeasonCoaches(int seasonId);
        DataTable GetCoaches(int seasonId);
        vw_Coaches GetCoach(int id);
        IQueryable<vw_Coaches> GetCoachVolunteers(int companyId, int seasonId);
        Coach GetCoachForSeason(int seasonId, int peopleId);
    }
}

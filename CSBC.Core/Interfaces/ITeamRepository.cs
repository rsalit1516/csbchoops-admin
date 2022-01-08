using CSBC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        IQueryable<Team> GetAll(int companyId);
        IQueryable<Team> GetTeams(int divisionId);
        int GetNumberofDivisionTeams(int divisionId);
        bool DeleteById(int id);
        IQueryable<Team> GetSeasonTeams(int seasonId);
        IQueryable<Team> GetDivisionTeams(int divisionId);
    }
}

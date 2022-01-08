using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;

namespace CSBC.Core.Interfaces
{
    public interface IDivisionRepository : IRepository<Division>
    {
        IQueryable<vw_Divisions> LoadDivisions(int seasonId);
        IQueryable<Division> GetDivisions(int seasonId);
        int GetPlayerDivision(int companyId, int seasonId, int peopleId);
    }
}

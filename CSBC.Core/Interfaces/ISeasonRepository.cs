using CSBC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Interfaces
{
    public interface ISeasonRepository : IRepository<Season>
    {
        Season GetSeason(int companyId, int seasonId = 0);
        Season GetCurrentSeason(int companyId);
        int GetSeason(int companyId, string seasonDescription);
        IQueryable<Season> GetSeasons(int companyId);
        List<SponsorFee> GetSeasonFees(int seasonId);
        IQueryable<Season> GetAll(int companyId);
    }
}

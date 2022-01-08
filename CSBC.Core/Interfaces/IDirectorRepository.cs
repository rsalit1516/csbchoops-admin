using CSBC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Interfaces
{
    public interface IDirectorRepository : IRepository<Director>
    {
        IQueryable<vw_Directors> GetAll(int companyId);
        List<vw_Directors> GetDirectorVolunteers(int companyId);
    }
}

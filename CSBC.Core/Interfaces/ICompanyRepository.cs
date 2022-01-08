using CSBC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        int FindCompanyByName(string name);
        bool FindByEmail(string email);
    }
}

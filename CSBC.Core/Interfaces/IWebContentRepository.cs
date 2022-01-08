using CSBC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Interfaces
{
    public interface IWebContentRepository : IRepository<WebContent>
    {
        IQueryable<WebContent> GetActiveWebContent(int companyId);
        IQueryable<WebContent> GetAll(int companyId);
    }
}

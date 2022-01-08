using CSBC.Core.Interfaces;
using CSBC.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CSBC.Core.Repositories
{
    public class WebContentRepository : EFRepository<WebContent>, IWebContentRepository
    {

        public WebContentRepository(DbContext context) : base(context) { }

        public IQueryable<WebContent> GetAll(int companyId)
        {
            return Context.Set<WebContent>()
                .Where(s => s.CompanyId == companyId)
                .OrderBy(s => s.ContentSequence);
        }


        public IQueryable<WebContent> GetActiveWebContent(int companyId)
        {
            return Context.Set<WebContent>()
                .Where(s => s.CompanyId == companyId)
                .Where(w => w.ExpirationDate >= DateTime.Now)
                .OrderBy(s => s.ContentSequence);
        }
    }
}

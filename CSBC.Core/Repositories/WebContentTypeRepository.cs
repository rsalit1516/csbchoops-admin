using CSBC.Core.Interfaces;
using CSBC.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Repositories
{
    public class WebContentTypeRepository: EFRepository<WebContentType>, IWebContentTypeRepository
    {

     public WebContentTypeRepository(DbContext context) : base(context) { }

     public IQueryable<WebContentType> GetAll(int companyId)
     {
            return Context.Set<WebContentType>();
     }


 
    }
}

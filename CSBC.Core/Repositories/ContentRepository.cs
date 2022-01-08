using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;
using CSBC.Core;
using System.Configuration;
using CSBC.Core.Models;

namespace CSBC.Core.Repositories
{
    public class ContentRepository : EFRepository<Content>, IContentRepository
    {

        public ContentRepository(DbContext context) : base(context) { }
    

        
    }
}


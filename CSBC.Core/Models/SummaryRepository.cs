using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using CSBC.Core.Data;

namespace CSBC.Core.Models
{
    public class SummaryRepository
    {   
        protected CSBCDbContext DataContext { get; set; }
        protected DbSet<Summary> DbSet;

        public SummaryRepository(CSBCDbContext dataContext)
        {
            DataContext = dataContext;

        }
        public Summary GetSummary(int companyId, int seasonId)
        {
            Summary sum = new Summary();
            var idParam = new SqlParameter
            {
                ParameterName = "SeasonID",
                Value = seasonId
            };
            var summary = DataContext.Database.SqlQuery<Summary>("exec SeasonCounts @SeasonId", idParam).ToList<Summary>();
            foreach(Summary s in summary)
            {
                sum = s;
            }
            return sum;
        }
    }
}

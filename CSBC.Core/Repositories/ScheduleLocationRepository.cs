using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Data;
using CSBC.Core.Interfaces;
using System.Data.Entity;
using CSBC.Core.Models;

namespace CSBC.Core.Repositories
{
    public class ScheduleLocationRepository : EFRepository<ScheduleLocation>, IScheduleLocationRepository
    {
        
        public ScheduleLocationRepository(DbContext context) : base(context) { }

        public override ScheduleLocation Insert(ScheduleLocation entity)
        {
            if (entity.LocationNumber == 0)
            {
                entity.LocationNumber = Context.Set<ScheduleLocation>().Any() ? (Context.Set<ScheduleLocation>().Max(p => p.LocationNumber) + 1) : 1;
            }
            Context.Set<ScheduleLocation>().Add(entity);
            Context.SaveChanges();
            return entity;
        }

 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;
using CSBC.Core.Models;

namespace CSBC.Core.Repositories
{
    public class ColorRepository : EFRepository<Color>, IColorRepository
    {
        public ColorRepository(DbContext context) : base(context) { }
        //protected CSBCDbContext DataContext { get; set; }
        //protected DbSet<ScheduleGame> DbSet;
 
        public Color GetByName(int companyId, string colorName)
        {
            var color = Context.Set<Color>().FirstOrDefault(c => c.ColorName == colorName && c.CompanyID == companyId);
            return color;
        }

        public IQueryable<Color> GetAll(int companyId)
        {
            var colors = Context.Set<Color>().Where(c => c.CompanyID == companyId);
            return colors.OrderBy(c => c.ColorName);
        }
        public override Color Insert(Color entity)
        {
            if (entity.ID == 0)
                entity.ID = Context.Set<Color>().Any() ? Context.Set<Color>().Max(c => c.ID) + 1 : 1;
            return base.Insert(entity);
        }
    }
}

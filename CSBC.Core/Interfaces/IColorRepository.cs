using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;


namespace CSBC.Core.Interfaces
{
    public interface IColorRepository : IRepository<Color>
    {
        Color GetByName(int companyId, string colorName);
        IQueryable<Color> GetAll(int id);
    }
}

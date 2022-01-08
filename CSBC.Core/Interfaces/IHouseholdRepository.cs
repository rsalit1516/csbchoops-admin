using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;
using System.Data;


namespace CSBC.Core.Interfaces
{
    public interface IHouseholdRepository : IRepository<Household>
    {
        DataTable GetRecords(int RowId, Int32 CompanyId, string sName = "", string sAddress = "", string sPhone = "", string sEmail = "");
        IQueryable<Household> GetRecords(int CompanyId = 1, string name = "", string address = "", string phone = "", string email = "");
        DataTable GetHouseholdCart(int RowID, Int32 SeasonID);
        DataTable LoadMembers(int RowID, Int32 CompanyID);
        IQueryable<Household> GetByName(string name);
        IQueryable<Household> GetAll(int companyId);
    }
}

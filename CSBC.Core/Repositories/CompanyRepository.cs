using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;
using CSBC.Core.Models;
using System.Configuration;

namespace CSBC.Core.Repositories
{
    public class CompanyRepository : EFRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext context) : base(context) { }

        #region IRepository<T> Members

    
        public override void Delete(Company entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<Company> SearchFor(Expression<Func<Company, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        #endregion

        public override Company Insert(Company entity)
        {
            if (entity.CompanyID == 0)
                entity.CompanyID = Context.Set<Company>().Any() ? Context.Set<Company>().Max(c => c.CompanyID) + 1 : 1;
            Context.Set<Company>().Add(entity);
            var no = Context.SaveChanges();
            return entity;
        }

        public int FindCompanyByName(string name)
        {
            int id = 0;
            string companyTableName = Context.Set<Company>().ToString();
            var company = Context.Set<Company>().FirstOrDefault(n => n.CompanyName == name);
            if (company==null)
                id = 0;
            else
                id = company.CompanyID;

            return id;
        }

        public bool FindByEmail(string email)
        {
            var Company = Context.Set<Company>().FirstOrDefault(n => n.EmailSender == email);
            return (Company != null);
        }
   
        public int GetBccList(CSBCDbContext context, string lastName, string firstName)
        {
            int id = 0;
            //Get test community
            //List<Company> Companies = context.Companies.Select.First(n => n.LastName == lastName && n.FirstName == firstName);
            //id = Company.CompanyID;
            return id;
        }

 
    }
}

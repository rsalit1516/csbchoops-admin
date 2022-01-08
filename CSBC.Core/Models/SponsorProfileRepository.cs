using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace CSBC.Core.Models
{
    public class SponsorProfileRepository   : IRepository<SponsorProfile>
    {

        protected CSBCDbContext DataContext { get; set; }
        protected DbSet<SponsorProfile> DbSet;

        public SponsorProfileRepository(CSBCDbContext dataContext)
        {
            DataContext = dataContext;
            
        }

        #region IRepository<T> Members


        public void Delete(SponsorProfile entity)
        {
            DataContext.SponsorProfiles.Remove(entity);
            DataContext.SaveChanges();
        }

        public IQueryable<SponsorProfile> SearchFor(Expression<Func<SponsorProfile, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<SponsorProfile> GetAll()
        {
            return DataContext.SponsorProfiles.Select(s => s);
        }
        public IQueryable<SponsorProfile> GetAll(int companyId)
        {
            return DataContext.SponsorProfiles
                .Where(s => s.CompanyID == companyId)
                .OrderBy(s => s.SpoName);
        }
        public IQueryable<SponsorProfile> GetAll(int companyId, string value)
        {
            return DataContext.SponsorProfiles
                .Where(s => s.CompanyID == companyId && s.SpoName.StartsWith(value))
                .OrderBy(s => s.SpoName);
        }
        public SponsorProfile GetById(int id)
        {
            return DataContext.SponsorProfiles.Find(id);
        }

        #endregion

        public SponsorProfile Insert(SponsorProfile entity)
        {
            if (entity.SponsorProfileID == 0)
            {
                entity.SponsorProfileID = DataContext.SponsorProfiles.Any() ? (DataContext.SponsorProfiles.Max(p => p.SponsorProfileID) + 1) : 1;
            }
            DataContext.SponsorProfiles.AddOrUpdate(entity);
            var no = entity.SponsorProfileID;
            DataContext.SaveChanges();
            return entity;
        }

        void IRepository<SponsorProfile>.Delete(SponsorProfile entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<SponsorProfile> IRepository<SponsorProfile>.GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(SponsorProfile SponsorProfile)
        {
            SponsorProfile newSponsorProfile = DataContext.SponsorProfiles.Add(SponsorProfile);
            DataContext.SaveChanges();
            return newSponsorProfile.SponsorProfileID;

        }
        
        public void Update(SponsorProfile entity)
        {
            var sponsor = GetById(entity.SponsorProfileID);
            sponsor = entity;
            DataContext.SaveChanges();
        }
        public IQueryable<SponsorProfile> GetSponsorsNotInSeason(int companyId, int seasonId)
        {
           var sponsors = from c in DataContext.SponsorProfiles
                where (c.CompanyID == companyId) && 
                !(from o in DataContext.Sponsors  
                  where o.SeasonID == seasonId  
                    select o.SponsorProfileID)   
			    .Contains(c.SponsorProfileID) 
		   select c;
           return sponsors.OrderBy(s => s.SpoName);
        }
        public IQueryable<SponsorProfile> GetSponsorsInSeason(int companyId, int seasonId)
        {
            var sponsors = from c in DataContext.SponsorProfiles
                           where (c.CompanyID == companyId) &&
                           (from o in DataContext.Sponsors
                             where o.SeasonID == seasonId
                             select o.SponsorProfileID)
                           .Contains(c.SponsorProfileID)
                           
                           select c;
            return sponsors.OrderBy(s => s.SpoName);
        }
    }
}

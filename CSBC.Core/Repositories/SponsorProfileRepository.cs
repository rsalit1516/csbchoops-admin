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
using CSBC.Core.Models;

namespace CSBC.Core.Repositories
{
    public class SponsorProfileRepository : EFRepository<SponsorProfile>, ISponsorProfileRepository
    {

        public SponsorProfileRepository(DbContext context): base(context) { }
       

        #region IRepository<T> Members


        public void Delete(SponsorProfile entity)
        {
            Context.Set<SponsorProfile>().Remove(entity);
            Context.SaveChanges();
        }

        public IQueryable<SponsorProfile> SearchFor(Expression<Func<SponsorProfile, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        //public IQueryable<SponsorProfile> GetAll()
        //{
        //    return Context.Set<SponsorProfile>().Select(s => s);
        //}
        public IQueryable<SponsorProfile> GetAll(int companyId)
        {
            return Context.Set<SponsorProfile>()
                .Where(s => s.CompanyID == companyId)
                .OrderBy(s => s.SpoName);
        }
        public IQueryable<SponsorProfile> GetAll(int companyId, string value)
        {
            return Context.Set<SponsorProfile>()
                .Where(s => s.CompanyID == companyId && s.SpoName.StartsWith(value))
                .OrderBy(s => s.SpoName);
        }
        public SponsorProfile GetById(int id)
        {
            return Context.Set<SponsorProfile>().Find(id);
        }

        public IQueryable<SponsorProfile> GetSponsorsThatShowAds()
        {
            return Context.Set<SponsorProfile>()
                .Where(s => s.ShowAd == true)
                .OrderBy(s => s.SpoName);
        }
        #endregion

        public SponsorProfile Insert(SponsorProfile entity)
        {
            if (entity.SponsorProfileID == 0)
            {
                entity.SponsorProfileID = Context.Set<SponsorProfile>().Any() ? (Context.Set<SponsorProfile>().Max(p => p.SponsorProfileID) + 1) : 1;
            }
            Context.Set<SponsorProfile>().AddOrUpdate(entity);
            var no = entity.SponsorProfileID;
            Context.SaveChanges();
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
            SponsorProfile newSponsorProfile = Context.Set<SponsorProfile>().Add(SponsorProfile);
            Context.SaveChanges();
            return newSponsorProfile.SponsorProfileID;

        }
        
        public void Update(SponsorProfile entity)
        {
            var sponsor = GetById(entity.SponsorProfileID);
            sponsor = entity;
            Context.SaveChanges();
        }
        public IQueryable<SponsorProfile> GetSponsorsNotInSeason(int companyId, int seasonId)
        {
            var sponsors = from c in Context.Set<SponsorProfile>()
                where (c.CompanyID == companyId) &&
                !(from o in Context.Set<Sponsor>() 
                  where o.SeasonID == seasonId  
                    select o.SponsorProfileID)   
			    .Contains(c.SponsorProfileID) 
		   select c;
           return sponsors.OrderBy(s => s.SpoName);
        }

        public IQueryable<SponsorProfile> GetSponsorsInSeason(int companyId, int seasonId)
        {
            var sponsors = from c in Context.Set<SponsorProfile>()
                           where (c.CompanyID == companyId) &&
                           (from o in Context.Set<Sponsor>()
                             where o.SeasonID == seasonId
                             select o.SponsorProfileID)
                           .Contains(c.SponsorProfileID)
                           
                           select c;
            return sponsors.OrderBy(s => s.SpoName);
        }
    }
}

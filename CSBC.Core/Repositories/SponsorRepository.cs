using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Runtime.InteropServices;
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
    public class SponsorRepository   : EFRepository<Sponsor>, ISponsorRepository
    {

         public SponsorRepository(DbContext context) : base(context) { }

        #region IRepository<T> Members


        public IQueryable<Sponsor> GetAll(int companyId)
        {
            return Context.Set<Sponsor>().Where(s => s.CompanyID == (int)companyId);
        }

   
        #endregion

        public override Sponsor Insert(Sponsor entity)
        {
            if (entity.SponsorID == 0)
            {
                entity.SponsorID = Context.Set<Sponsor>().Any() ? (Context.Set<Sponsor>().Max(p => p.SponsorID) + 1) : 1;
            }
            Context.Set<Sponsor>().Add(entity);
            var no = Context.SaveChanges();
            return entity;
        }


        public IQueryable<Sponsor> GetSeasonSponsors(int seasonId)
        {
            var sponsorRepository = new SponsorRepository(new CSBCDbContext());
            var sponsors = Context.Set<Sponsor>().Where(s => s.SeasonID == seasonId);
            //var count = sponsors.Count();
            return sponsors;
        }

        public bool IsSeasonSponsor(int seasonId, int sponsorProfileId)
        {
            var sponsorRepository = new SponsorRepository(new CSBCDbContext());
            var sponsors = Context.Set<Sponsor>().Where(s => s.SeasonID == seasonId && s.SponsorProfileID == sponsorProfileId);
            //var count = sponsors.Count();
            return sponsors.Any();
        }

        public decimal GetSponsorBalance(int sponsorProfileId)
        {
            var fees = Context.Set<Sponsor>().Where(f => f.SponsorProfileID == sponsorProfileId).Sum(f => f.FeeID);
            var repPayments = new SponsorPaymentRepository(Context);
            var payments = repPayments.GetTotalPayments(sponsorProfileId);
            return (Convert.ToDecimal(fees) - payments);
        }
    
    }
}

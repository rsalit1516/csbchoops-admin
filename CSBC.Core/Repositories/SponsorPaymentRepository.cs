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
    public class SponsorPaymentRepository : EFRepository<SponsorPayment>, ISponsorPaymentRepository
    {

        public SponsorPaymentRepository(DbContext context) : base(context) { }

  
        public override SponsorPayment Insert(SponsorPayment entity)
        {
            using (Context)
            {
                if (entity.PaymentID == 0)
                {
                    entity.PaymentID = Context.Set<SponsorPayment>().Any() ? (Context.Set<SponsorPayment>().Max(p => p.PaymentID) + 1) : 1;
                    SponsorPayment newSponsorPayment = Context.Set<SponsorPayment>().Add(entity);
                }
                
                Context.SaveChanges();
                return entity;
            }
        }


        public List<SponsorPayment> GetSponsorPayments(int sponsorProfileId)
        {
            using (var context = new CSBCDbContext())
            {
                var sponsorPayments = context.Set<SponsorPayment>().Where<SponsorPayment>(p => p.SponsorProfileID == sponsorProfileId).ToList<SponsorPayment>();
                return sponsorPayments;
            }
            
        }

        public decimal GetTotalPayments(int sponsorProfileId)
        {
            var fees = Context.Set<SponsorPayment>().Where(f => f.SponsorProfileID == sponsorProfileId).Sum(f => f.Amount);
            return fees;
        }
    }
}


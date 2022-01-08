using CSBC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Interfaces
{
    public interface ISponsorProfileRepository : IRepository<SponsorProfile>
    {
        //List<SponsorPayment> GetSponsorPayments(int sponsorProfileId);
        //decimal GetTotalPayments(int sponsorProfileId);
    }
}

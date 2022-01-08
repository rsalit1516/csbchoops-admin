using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSBC.Core.Models;

namespace CSBCHoops.Web.ViewModels
{
    public class SummaryInfo
    {
        public List<Summary> SummaryInfo()
        {
            var info = new List<Summary>
            { 
                new Summary { DivisionName="T2_Coed", Players = 63, Coaches = 1, Sponsors = 0, OnlinePlayers = 2, OnlineCoaches = 1, OnlineSponsors = 1}, 
                new Summary { DivisionName="T3_BOYS", Players = 32, Coaches = 1, Sponsors = 0, OnlinePlayers = 2, OnlineCoaches = 1, OnlineSponsors = 1}, 
                new Summary { DivisionName="T3_GIRLS", Players = 32, Coaches = 1, Sponsors = 0, OnlinePlayers = 2, OnlineCoaches = 1, OnlineSponsors = 1}

                };
            return info;


        }
    }
}

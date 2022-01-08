using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Models
{
    public static class GroupTypes
    {
        public enum GroupType { BoardMember = 0, SeasonCandidateOnly = 1, SeasonPlayers = 2, CoachesSponsors = 3, AllMembers = 4 };
    }
}

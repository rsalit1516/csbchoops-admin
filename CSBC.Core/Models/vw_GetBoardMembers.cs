using System;
using System.Collections.Generic;

namespace CSBC.Core.Models
{
    public partial class vw_GetBoardMembers
    {
        public Nullable<int> Seq { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string PHONE { get; set; }
        public string CELLPHONE { get; set; }
        public string WORKPHONE { get; set; }
        public string Email { get; set; }
        public int CompanyID { get; set; }
    }
}

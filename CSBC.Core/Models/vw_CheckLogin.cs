using System;
using System.Collections.Generic;

namespace CSBC.Core.Models
{
    public partial class vw_CheckLogin
    {
        public int CompanyID { get; set; }
        public int TimeZone { get; set; }
        public string CompanyName { get; set; }
        public string EmailSender { get; set; }
        public string ImageName { get; set; }
        public Nullable<int> SeasonID { get; set; }
        public Nullable<int> SignUpSeasonID { get; set; }
        public string Sea_Desc { get; set; }
        public Nullable<int> HouseID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> UserType { get; set; }
        public string UserName { get; set; }
        public string PWord { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> SignedDate { get; set; }
        public Nullable<System.DateTime> SignedDateEnd { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CSBC.Core.Models
{
    public partial class vw_Calendar
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> dDate { get; set; }
        public string sTitle { get; set; }
        public string sSubTitle { get; set; }
        public Nullable<byte> Display { get; set; }
        public string sDesc1 { get; set; }
        public string sDesc2 { get; set; }
        public string sDesc3 { get; set; }
        public int CompanyID { get; set; }
        public Nullable<int> iMonth { get; set; }
        public Nullable<int> iDay { get; set; }
        public Nullable<int> iYear { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CSBC.Core.Models
{
    public partial class ScheduleGamesStat
    {
        public int RowID { get; set; }
        public int TeamNumber { get; set; }
        public int ScheduleNumber { get; set; }
        public int GameNumber { get; set; }
        public int SeasonID { get; set; }
        public int PeopleID { get; set; }
        public Nullable<int> Points { get; set; }
        public bool DNP { get; set; }
    }
}

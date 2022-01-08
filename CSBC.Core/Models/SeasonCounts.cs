﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Core.Models
{
    public class SeasonCount
    {
        public int DivisionID { get; set; }
        public string Div_Desc { get; set; }
        public int Total { get; set; }
        public int Coaches { get; set; }
        public int Sponsors { get; set; }
        public int TotalOR { get; set; }
        public int CoachesOR { get; set; }
        public int SponsorsOR { get; set; }
    }
}

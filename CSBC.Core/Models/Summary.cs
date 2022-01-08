using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CSBC.Core.Models
{
    public class  Summary
    {
        [Key]
        public int DivisionID { get; set; }
        public string Div_Desc { get; set; }
        //public string DivisionName { get; set; }
        //public int Players { get; set; }
        public int Coaches { get; set; }
        public int Sponsors { get; set; }
        public int TotalOR { get; set; }
        public int CoachesOR { get; set; }
        public int SponsorsOR { get; set; }
        public int Total { get; set; }
        //int Season { get; set; } //need to create a Season class
    }
}

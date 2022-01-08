using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CSBC.Core.Models
{
    public partial class vw_Divisions
    {
        [Key]
        public int DivisionID { get; set; }
        public int CompanyID { get; set; }
        public Object SeasonID { get; set; }
        public string Div_Desc { get; set; }
        public Object Teams { get; set; }
        public string Gender { get; set; }
        public Object MinDate { get; set; }
        public Object MaxDate { get; set; }
        public string Gender2 { get; set; }
        public Object MinDate2 { get; set; }
        public Object MaxDate2 { get; set; }
        public Object AD { get; set; }
        public string HousePhone { get; set; }
        public string Cellphone { get; set; }
        public string DraftVenue { get; set; }
        public Object DraftDate { get; set; }
        public string DraftTime { get; set; }
        public Object DirectorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}

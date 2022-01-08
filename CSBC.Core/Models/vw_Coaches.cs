using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSBC.Core.Models
{
    public partial class vw_Coaches
    {
        [Key]
        public int CoachID { get; set; }
        public int CompanyID { get; set; }
        public Nullable<int> SeasonID { get; set; }
        public string Name { get; set; }
        public string Housephone { get; set; }
        public string Cellphone { get; set; }
        public string ShirtSize { get; set; }
        public Nullable<int> PeopleID { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CoachPhone { get; set; }
    }
}

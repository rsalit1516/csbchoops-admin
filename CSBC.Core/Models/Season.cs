using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.DynamicData;

namespace CSBC.Core.Models
{
    [Table("Seasons")]
    public partial class Season
    {
        [Key]
        public int SeasonID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        [Column("Sea_Desc")]
        public string Description { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        [Display(Name = "Player Fee")]
        public Nullable<decimal> ParticipationFee { get; set; }
        public Nullable<decimal> SponsorFee { get; set; }
        public Nullable<decimal> ConvenienceFee { get; set; }
        public Nullable<bool> CurrentSeason { get; set; }
        public Nullable<bool> CurrentSchedule { get; set; }
        public Nullable<bool> CurrentSignUps { get; set; }
        public Nullable<System.DateTime> SignUpsDate { get; set; }
        public Nullable<System.DateTime> SignUpsEND { get; set; }
        public Nullable<bool> TestSeason { get; set; }
        public Nullable<bool> NewSchoolYear { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        //public decimal PlayerFee { get; set; }
    }
}

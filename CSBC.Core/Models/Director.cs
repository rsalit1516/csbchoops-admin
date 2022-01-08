using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSBC.Core.Models
{
    public partial class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public int PeopleID { get; set; }
        public Nullable<int> Seq { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public string PhonePref { get; set; }
        public Nullable<int> EmailPref { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }

        [ForeignKey("PeopleID")]
        public virtual Person People {get; set;}
    }
}

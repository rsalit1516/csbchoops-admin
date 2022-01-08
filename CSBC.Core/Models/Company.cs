using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSBC.Core.Models
{
    [Table("Companies")]
    public partial class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int TimeZone { get; set; }
        public string ImageName { get; set; }
        public string EmailSender { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
    }
}

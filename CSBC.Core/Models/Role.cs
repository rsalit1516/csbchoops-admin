using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSBC.Core.Models
{
    public partial class Role
    {
        
        [Key]
        [Column("RollsID")]
        public decimal RoleId { get; set; }
        //[ForeignKey("UserID")]
        public decimal UserID { get; set; }
        public string ScreenName { get; set; }
        public string AccessType { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }

        //public virtual User User { get; set; }
    }
}

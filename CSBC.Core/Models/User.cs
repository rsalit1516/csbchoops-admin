using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSBC.Core.Models
{
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PWord { get; set; }
        public string PassWord { get; set; }
        public Nullable<int> UserType { get; set; }
        public Nullable<int> ValidationCode { get; set; }
        public Nullable<int> PeopleID { get; set; }
        //[ForeignKey("HouseID")]
        public int HouseID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }

        //public virtual Household Household { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSBC.Core.Models
{
    public partial class ScheduleLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationNumber { get; set; }
        public string LocationName { get; set; }
        public string Notes { get; set; }
    }
}

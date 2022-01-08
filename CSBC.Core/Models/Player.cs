using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSBC.Core.Models
{
    public partial class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> SeasonID { get; set; }
        public Nullable<int> DivisionID { get; set; }
        public int? TeamID { get; set; }
        public int PeopleID { get; set; }
        public string DraftID { get; set; }
        public string DraftNotes { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<int> Coach { get; set; }
        public int? CoachID { get; set; }
        public int? Sponsor { get; set; }
        public int? SponsorID { get; set; }
        public bool? AD { get; set; }
        public bool? Scholarship { get; set; }
        public bool? FamilyDisc { get; set; }
        public bool? Rollover { get; set; }
        public bool? OutOfTown { get; set; }
        public Nullable<int> RefundBatchID { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> BalanceOwed { get; set; }
        public string PayType { get; set; }
        public string NoteDesc { get; set; }
        public string CheckMemo { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public bool? PlaysDown { get; set; }
        public bool? PlaysUp { get; set; }
        public Nullable<int> ShoppingCartID { get; set; }

        [ForeignKey("PeopleID")]
        public virtual Person Person { get; set; }
        [ForeignKey("DivisionID")]
        public virtual Division Division { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }
        [ForeignKey("SeasonID")]
        public virtual Season Season { get; set; }
    }
    public partial class UndraftedPlayer
    {
        [Key]
        public int PlayerID { get; set; }
        public Nullable<int> PeopleID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public Nullable<int> Sponsor { get; set; }
        public int SponsorID { get; set; }
        public int DivisionID { get; set; }   
        public string DraftID { get; set; }
        public int? Rating { get; set; }
    }
    public partial class SeasonPlayer
    {
        [Key]
        public int PlayerID { get; set; }
        public int PeopleID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public int? DivisionID { get; set; }
        public string Div_Desc { get; set; }
        public string DraftID { get; set; }
        public int? Rating { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Parent1 { get; set; }
        public string Parent2 { get; set; }
        public int Grade { get; set; }
        public decimal Balance { get; set; }
        public string DraftNotes { get; set; }
    }
    
        //public virtual Division Division { get; set; }
  
    
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            // Primary Key
            this.HasKey(t => t.PlayerID);

            // Properties
            this.Property(t => t.DraftID)
                .HasMaxLength(3);

            this.Property(t => t.DraftNotes)
                .HasMaxLength(100);

            this.Property(t => t.PayType)
                .HasMaxLength(5);

            this.Property(t => t.NoteDesc)
                .HasMaxLength(50);

            this.Property(t => t.CheckMemo)
                .HasMaxLength(50);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Players");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.DivisionID).HasColumnName("DivisionID");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.PeopleID).HasColumnName("PeopleID");
            this.Property(t => t.DraftID).HasColumnName("DraftID");
            this.Property(t => t.DraftNotes).HasColumnName("DraftNotes");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.Coach).HasColumnName("Coach");
            this.Property(t => t.CoachID).HasColumnName("CoachID");
            this.Property(t => t.Sponsor).HasColumnName("Sponsor");
            this.Property(t => t.SponsorID).HasColumnName("SponsorID");
            this.Property(t => t.AD).HasColumnName("AD");
            this.Property(t => t.Scholarship).HasColumnName("Scholarship");
            this.Property(t => t.FamilyDisc).HasColumnName("FamilyDisc");
            this.Property(t => t.Rollover).HasColumnName("Rollover");
            this.Property(t => t.OutOfTown).HasColumnName("OutOfTown");
            this.Property(t => t.RefundBatchID).HasColumnName("RefundBatchID");
            this.Property(t => t.PaidDate).HasColumnName("PaidDate");
            this.Property(t => t.PaidAmount).HasColumnName("PaidAmount");
            this.Property(t => t.BalanceOwed).HasColumnName("BalanceOwed");
            this.Property(t => t.PayType).HasColumnName("PayType");
            this.Property(t => t.NoteDesc).HasColumnName("NoteDesc");
            this.Property(t => t.CheckMemo).HasColumnName("CheckMemo");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.PlaysDown).HasColumnName("PlaysDown");
            this.Property(t => t.PlaysUp).HasColumnName("PlaysUp");
            this.Property(t => t.ShoppingCartID).HasColumnName("ShoppingCartID");
        }
    }
}

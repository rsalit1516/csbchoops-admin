using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class SeasonMap : EntityTypeConfiguration<Season>
    {
        public SeasonMap()
        {
            // Primary Key
            this.HasKey(t => t.SeasonID);

            // Properties
            this.Property(t => t.Sea_Desc)
                .HasMaxLength(50);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Seasons");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.Sea_Desc).HasColumnName("Sea_Desc");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.ParticipationFee).HasColumnName("ParticipationFee");
            this.Property(t => t.SponsorFee).HasColumnName("SponsorFee");
            this.Property(t => t.ConvenienceFee).HasColumnName("ConvenienceFee");
            this.Property(t => t.CurrentSeason).HasColumnName("CurrentSeason");
            this.Property(t => t.CurrentSchedule).HasColumnName("CurrentSchedule");
            this.Property(t => t.CurrentSignUps).HasColumnName("CurrentSignUps");
            this.Property(t => t.SignUpsDate).HasColumnName("SignUpsDate");
            this.Property(t => t.SignUpsEND).HasColumnName("SignUpsEND");
            this.Property(t => t.TestSeason).HasColumnName("TestSeason");
            this.Property(t => t.NewSchoolYear).HasColumnName("NewSchoolYear");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

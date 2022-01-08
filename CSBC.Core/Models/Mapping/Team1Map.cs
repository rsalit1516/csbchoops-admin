using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class Team1Map : EntityTypeConfiguration<Team1>
    {
        public Team1Map()
        {
            // Primary Key
            this.HasKey(t => t.TeamID);

            // Properties
            this.Property(t => t.TeamName)
                .HasMaxLength(50);

            this.Property(t => t.TeamColor)
                .HasMaxLength(50);

            this.Property(t => t.TeamNumber)
                .HasMaxLength(2);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Teams");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.DivisionID).HasColumnName("DivisionID");
            this.Property(t => t.CoachID).HasColumnName("CoachID");
            this.Property(t => t.AssCoachID).HasColumnName("AssCoachID");
            this.Property(t => t.SponsorID).HasColumnName("SponsorID");
            this.Property(t => t.TeamName).HasColumnName("TeamName");
            this.Property(t => t.TeamColor).HasColumnName("TeamColor");
            this.Property(t => t.TeamColorID).HasColumnName("TeamColorID");
            this.Property(t => t.TeamNumber).HasColumnName("TeamNumber");
            this.Property(t => t.Round1).HasColumnName("Round1");
            this.Property(t => t.Round2).HasColumnName("Round2");
            this.Property(t => t.Round3).HasColumnName("Round3");
            this.Property(t => t.Round4).HasColumnName("Round4");
            this.Property(t => t.Round5).HasColumnName("Round5");
            this.Property(t => t.Round6).HasColumnName("Round6");
            this.Property(t => t.Round7).HasColumnName("Round7");
            this.Property(t => t.Round8).HasColumnName("Round8");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

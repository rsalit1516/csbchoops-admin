using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ScheduleGamesHMap : EntityTypeConfiguration<ScheduleGamesH>
    {
        public ScheduleGamesHMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ScheduleNumber, t.GameNumber });

            // Properties
            this.Property(t => t.ScheduleNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameTime)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ScheduleGamesHS");
            this.Property(t => t.ScheduleNumber).HasColumnName("ScheduleNumber");
            this.Property(t => t.GameNumber).HasColumnName("GameNumber");
            this.Property(t => t.LocationNumber).HasColumnName("LocationNumber");
            this.Property(t => t.GameDate).HasColumnName("GameDate");
            this.Property(t => t.GameTime).HasColumnName("GameTime");
            this.Property(t => t.VisitingTeamNumber).HasColumnName("VisitingTeamNumber");
            this.Property(t => t.HomeTeamNumber).HasColumnName("HomeTeamNumber");
            this.Property(t => t.VisitingTeamScore).HasColumnName("VisitingTeamScore");
            this.Property(t => t.HomeTeamScore).HasColumnName("HomeTeamScore");
            this.Property(t => t.VisitingForfeited).HasColumnName("VisitingForfeited");
            this.Property(t => t.HomeForfeited).HasColumnName("HomeForfeited");
        }
    }
}

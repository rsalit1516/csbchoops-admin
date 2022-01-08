using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ScheduleGamesSPRING_DUPMap : EntityTypeConfiguration<ScheduleGamesSPRING_DUP>
    {
        public ScheduleGamesSPRING_DUPMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ScheduleNumber, t.GameNumber, t.LocationNumber, t.GameDate, t.GameTime, t.VisitingTeamNumber, t.HomeTeamNumber, t.VisitingTeamScore, t.HomeTeamScore });

            // Properties
            this.Property(t => t.ScheduleNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LocationNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.VisitingTeamNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeTeamNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.VisitingTeamScore)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeTeamScore)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ScheduleGamesSPRING_DUP");
            this.Property(t => t.ScheduleNumber).HasColumnName("ScheduleNumber");
            this.Property(t => t.GameNumber).HasColumnName("GameNumber");
            this.Property(t => t.LocationNumber).HasColumnName("LocationNumber");
            this.Property(t => t.GameDate).HasColumnName("GameDate");
            this.Property(t => t.GameTime).HasColumnName("GameTime");
            this.Property(t => t.VisitingTeamNumber).HasColumnName("VisitingTeamNumber");
            this.Property(t => t.HomeTeamNumber).HasColumnName("HomeTeamNumber");
            this.Property(t => t.VisitingTeamScore).HasColumnName("VisitingTeamScore");
            this.Property(t => t.HomeTeamScore).HasColumnName("HomeTeamScore");
        }
    }
}

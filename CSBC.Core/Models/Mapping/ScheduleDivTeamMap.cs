using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ScheduleDivTeamMap : EntityTypeConfiguration<ScheduleDivTeam>
    {
        public ScheduleDivTeamMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DivisionNumber, t.TeamNumber, t.ScheduleNumber, t.ScheduleTeamNumber, t.HomeLocation });

            // Properties
            this.Property(t => t.DivisionNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ScheduleNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ScheduleTeamNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeLocation)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ScheduleDivTeams");
            this.Property(t => t.DivisionNumber).HasColumnName("DivisionNumber");
            this.Property(t => t.TeamNumber).HasColumnName("TeamNumber");
            this.Property(t => t.ScheduleNumber).HasColumnName("ScheduleNumber");
            this.Property(t => t.ScheduleTeamNumber).HasColumnName("ScheduleTeamNumber");
            this.Property(t => t.HomeLocation).HasColumnName("HomeLocation");
        }
    }
}

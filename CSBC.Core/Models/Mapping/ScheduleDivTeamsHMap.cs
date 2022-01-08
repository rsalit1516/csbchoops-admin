using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ScheduleDivTeamsHMap : EntityTypeConfiguration<ScheduleDivTeamsH>
    {
        public ScheduleDivTeamsHMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DivisionNumber, t.TeamNumber });

            // Properties
            this.Property(t => t.DivisionNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ScheduleDivTeamsHS");
            this.Property(t => t.DivisionNumber).HasColumnName("DivisionNumber");
            this.Property(t => t.TeamNumber).HasColumnName("TeamNumber");
            this.Property(t => t.ScheduleNumber).HasColumnName("ScheduleNumber");
            this.Property(t => t.ScheduleTeamNumber).HasColumnName("ScheduleTeamNumber");
            this.Property(t => t.HomeLocation).HasColumnName("HomeLocation");
        }
    }
}

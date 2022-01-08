using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ScheduleGamesStatMap : EntityTypeConfiguration<ScheduleGamesStat>
    {
        public ScheduleGamesStatMap()
        {
            // Primary Key
            this.HasKey(t => t.RowID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ScheduleGamesStats");
            this.Property(t => t.RowID).HasColumnName("RowID");
            this.Property(t => t.TeamNumber).HasColumnName("TeamNumber");
            this.Property(t => t.ScheduleNumber).HasColumnName("ScheduleNumber");
            this.Property(t => t.GameNumber).HasColumnName("GameNumber");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.PeopleID).HasColumnName("PeopleID");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.DNP).HasColumnName("DNP");
        }
    }
}

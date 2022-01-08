using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ScheduleLocationMap : EntityTypeConfiguration<ScheduleLocation>
    {
        public ScheduleLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.LocationNumber);

            // Properties
            this.Property(t => t.LocationNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LocationName)
                .HasMaxLength(50);

            this.Property(t => t.Notes)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ScheduleLocations");
            this.Property(t => t.LocationNumber).HasColumnName("LocationNumber");
            this.Property(t => t.LocationName).HasColumnName("LocationName");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}

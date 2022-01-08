using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_GamesMap : EntityTypeConfiguration<vw_Games>
    {
        public vw_GamesMap()
        {
            // Primary Key
            this.HasKey(t => t.GameType);

            // Properties
            this.Property(t => t.GameType)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Division)
                .HasMaxLength(50);

            this.Property(t => t.GameDateTime)
                .HasMaxLength(24);

            this.Property(t => t.GameTime)
                .HasMaxLength(8);

            this.Property(t => t.HomeTeam)
                .HasMaxLength(50);

            this.Property(t => t.VisitorTeam)
                .HasMaxLength(50);

            this.Property(t => t.LocationName)
                .HasMaxLength(50);

            this.Property(t => t.Descr)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_Games");
            this.Property(t => t.GameType).HasColumnName("GameType");
            this.Property(t => t.GameDate).HasColumnName("GameDate");
            this.Property(t => t.ScheduleNumber).HasColumnName("ScheduleNumber");
            this.Property(t => t.GameNumber).HasColumnName("GameNumber");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.GameDateTime).HasColumnName("GameDateTime");
            this.Property(t => t.GameTime).HasColumnName("GameTime");
            this.Property(t => t.HomeTeam).HasColumnName("HomeTeam");
            this.Property(t => t.VisitorTeam).HasColumnName("VisitorTeam");
            this.Property(t => t.LocationName).HasColumnName("LocationName");
            this.Property(t => t.LocationNumber).HasColumnName("LocationNumber");
            this.Property(t => t.Descr).HasColumnName("Descr");
        }
    }
}

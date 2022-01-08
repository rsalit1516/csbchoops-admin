using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class CoachMap : EntityTypeConfiguration<Coach>
    {
        public CoachMap()
        {
            // Primary Key
            this.HasKey(t => t.CoachID);

            // Properties
            this.Property(t => t.ShirtSize)
                .HasMaxLength(50);

            this.Property(t => t.CoachPhone)
                .HasMaxLength(25);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Coaches");
            this.Property(t => t.CoachID).HasColumnName("CoachID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.PeopleID).HasColumnName("PeopleID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.ShirtSize).HasColumnName("ShirtSize");
            this.Property(t => t.CoachPhone).HasColumnName("CoachPhone");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

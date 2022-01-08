using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class TeamRosterMap : EntityTypeConfiguration<TeamRoster>
    {
        public TeamRosterMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.Grade)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.UpdateUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TeamRosters");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.Birthdate).HasColumnName("Birthdate");
            this.Property(t => t.Grade).HasColumnName("Grade");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.UpdateUser).HasColumnName("UpdateUser");
        }
    }
}

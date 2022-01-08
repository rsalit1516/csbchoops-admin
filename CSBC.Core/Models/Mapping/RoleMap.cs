using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.ScreenName)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.AccessType)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.CreatedUser)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Rolls");
            this.Property(t => t.RoleId).HasColumnName("RollsID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ScreenName).HasColumnName("ScreenName");
            this.Property(t => t.AccessType).HasColumnName("AccessType");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

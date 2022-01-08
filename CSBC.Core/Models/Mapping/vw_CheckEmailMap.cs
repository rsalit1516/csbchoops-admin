using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_CheckEmailMap : EntityTypeConfiguration<vw_CheckEmail>
    {
        public vw_CheckEmailMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyID);

            // Properties
            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.PWord)
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_CheckEmail");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.PWord).HasColumnName("PWord");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
        }
    }
}

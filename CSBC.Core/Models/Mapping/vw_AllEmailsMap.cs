using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_AllEmailsMap : EntityTypeConfiguration<vw_AllEmails>
    {
        public vw_AllEmailsMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyID);

            // Properties
            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_AllEmails");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
        }
    }
}

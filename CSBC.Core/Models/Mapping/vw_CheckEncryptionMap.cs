using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_CheckEncryptionMap : EntityTypeConfiguration<vw_CheckEncryption>
    {
        public vw_CheckEncryptionMap()
        {
            // Primary Key
            this.HasKey(t => t.PWD);

            // Properties
            this.Property(t => t.PWD)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_CheckEncryption");
            this.Property(t => t.PWD).HasColumnName("PWD");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.SignedDate).HasColumnName("SignedDate");
            this.Property(t => t.SignedDateEnd).HasColumnName("SignedDateEnd");
        }
    }
}

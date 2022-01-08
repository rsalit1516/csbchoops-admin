using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_GetBoardInfMap : EntityTypeConfiguration<vw_GetBoardInf>
    {
        public vw_GetBoardInfMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Phone, t.Email, t.CompanyID });

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(101);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_GetBoardInf");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.Seq).HasColumnName("Seq");
        }
    }
}

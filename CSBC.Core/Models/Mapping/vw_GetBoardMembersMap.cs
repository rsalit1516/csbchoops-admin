using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_GetBoardMembersMap : EntityTypeConfiguration<vw_GetBoardMembers>
    {
        public vw_GetBoardMembersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PHONE, t.CELLPHONE, t.WORKPHONE, t.Email, t.CompanyID });

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(101);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.PHONE)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.CELLPHONE)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.WORKPHONE)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_GetBoardMembers");
            this.Property(t => t.Seq).HasColumnName("Seq");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.PHONE).HasColumnName("PHONE");
            this.Property(t => t.CELLPHONE).HasColumnName("CELLPHONE");
            this.Property(t => t.WORKPHONE).HasColumnName("WORKPHONE");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
        }
    }
}

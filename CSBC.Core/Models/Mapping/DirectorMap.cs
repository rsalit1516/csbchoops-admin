using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class DirectorMap : EntityTypeConfiguration<Director>
    {
        public DirectorMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.PhonePref)
                .HasMaxLength(10);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Directors");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.PeopleID).HasColumnName("PeopleID");
            this.Property(t => t.Seq).HasColumnName("Seq");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.PhonePref).HasColumnName("PhonePref");
            this.Property(t => t.EmailPref).HasColumnName("EmailPref");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

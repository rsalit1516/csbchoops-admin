using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class SponsorProfileMap : EntityTypeConfiguration<SponsorProfile>
    {
        public SponsorProfileMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CompanyID, t.SponsorProfileID });

            // Properties
            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SponsorProfileID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ContactName)
                .HasMaxLength(50);

            this.Property(t => t.SpoName)
                .HasMaxLength(50);

            this.Property(t => t.EMAIL)
                .HasMaxLength(50);

            this.Property(t => t.URL)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(15);

            this.Property(t => t.Phone)
                .HasMaxLength(25);

            this.Property(t => t.TypeOfBuss)
                .HasMaxLength(50);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("SponsorProfile");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SponsorProfileID).HasColumnName("SponsorProfileID");
            this.Property(t => t.HouseID).HasColumnName("HouseID");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.SpoName).HasColumnName("SpoName");
            this.Property(t => t.EMAIL).HasColumnName("EMAIL");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.TypeOfBuss).HasColumnName("TypeOfBuss");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

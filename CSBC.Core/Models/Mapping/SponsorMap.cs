using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class SponsorMap : EntityTypeConfiguration<Sponsor>
    {
        public SponsorMap()
        {
            // Primary Key
            this.HasKey(t => t.SponsorID);

            // Properties
            this.Property(t => t.SponsorID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ContactNameDELETE)
                .HasMaxLength(50);

            this.Property(t => t.SpoNameDELETE)
                .HasMaxLength(150);

            this.Property(t => t.ShirtName)
                .HasMaxLength(50);

            this.Property(t => t.EMAILDELETE)
                .HasMaxLength(50);

            this.Property(t => t.URLDELETE)
                .HasMaxLength(50);

            this.Property(t => t.AddressDELETE)
                .HasMaxLength(100);

            this.Property(t => t.CityDELETE)
                .HasMaxLength(50);

            this.Property(t => t.StateDELETE)
                .HasMaxLength(2);

            this.Property(t => t.ZipDELETE)
                .HasMaxLength(15);

            this.Property(t => t.PhoneDELETE)
                .HasMaxLength(25);

            this.Property(t => t.ShirtSize)
                .HasMaxLength(50);

            this.Property(t => t.TypeOfBussDELETE)
                .HasMaxLength(50);

            this.Property(t => t.Color1)
                .HasMaxLength(50);

            this.Property(t => t.Color2)
                .HasMaxLength(50);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Sponsors");
            this.Property(t => t.SponsorID).HasColumnName("SponsorID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.HouseID).HasColumnName("HouseID");
            this.Property(t => t.ContactNameDELETE).HasColumnName("ContactNameDELETE");
            this.Property(t => t.SpoNameDELETE).HasColumnName("SpoNameDELETE");
            this.Property(t => t.ShirtName).HasColumnName("ShirtName");
            this.Property(t => t.EMAILDELETE).HasColumnName("EMAILDELETE");
            this.Property(t => t.URLDELETE).HasColumnName("URLDELETE");
            this.Property(t => t.AddressDELETE).HasColumnName("AddressDELETE");
            this.Property(t => t.CityDELETE).HasColumnName("CityDELETE");
            this.Property(t => t.StateDELETE).HasColumnName("StateDELETE");
            this.Property(t => t.ZipDELETE).HasColumnName("ZipDELETE");
            this.Property(t => t.PhoneDELETE).HasColumnName("PhoneDELETE");
            this.Property(t => t.ShirtSize).HasColumnName("ShirtSize");
            this.Property(t => t.SpoAmount).HasColumnName("SpoAmount");
            this.Property(t => t.TypeOfBussDELETE).HasColumnName("TypeOfBussDELETE");
            this.Property(t => t.Color1).HasColumnName("Color1");
            this.Property(t => t.Color1ID).HasColumnName("Color1ID");
            this.Property(t => t.Color2).HasColumnName("Color2");
            this.Property(t => t.Color2ID).HasColumnName("Color2ID");
            this.Property(t => t.ShoppingCartID).HasColumnName("ShoppingCartID");
            this.Property(t => t.MailCheck).HasColumnName("MailCheck");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.SponsorProfileID).HasColumnName("SponsorProfileID");
            this.Property(t => t.FeeID).HasColumnName("FeeID");
        }
    }
}

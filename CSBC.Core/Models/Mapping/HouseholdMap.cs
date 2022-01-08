using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class HouseholdMap : EntityTypeConfiguration<Household>
    {
        public HouseholdMap()
        {
            // Primary Key
            this.HasKey(t => t.HouseID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(25);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.SportsCard)
                .HasMaxLength(15);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Households");
            this.Property(t => t.HouseID).HasColumnName("HouseID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EmailList).HasColumnName("EmailList");
            this.Property(t => t.SportsCard).HasColumnName("SportsCard");
            this.Property(t => t.Guardian).HasColumnName("Guardian");
            this.Property(t => t.FeeWaived).HasColumnName("FeeWaived");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.TEMID).HasColumnName("TEMID");
        }
    }
}

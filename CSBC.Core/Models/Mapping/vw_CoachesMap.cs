using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_CoachesMap : EntityTypeConfiguration<vw_Coaches>
    {
        public vw_CoachesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CompanyID, t.CoachID });

            // Properties
            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CoachID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(102);

            this.Property(t => t.Housephone)
                .HasMaxLength(25);

            this.Property(t => t.Cellphone)
                .HasMaxLength(15);

            this.Property(t => t.ShirtSize)
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(20);

            this.Property(t => t.CoachPhone)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("vw_Coaches");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.CoachID).HasColumnName("CoachID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Housephone).HasColumnName("Housephone");
            this.Property(t => t.Cellphone).HasColumnName("Cellphone");
            this.Property(t => t.ShirtSize).HasColumnName("ShirtSize");
            this.Property(t => t.PeopleID).HasColumnName("PeopleID");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.CoachPhone).HasColumnName("CoachPhone");
        }
    }
}

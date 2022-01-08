using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class TeamHMap : EntityTypeConfiguration<TeamH>
    {
        public TeamHMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TeamName, t.ContactFirstName, t.ContactLastName, t.WorkPhone, t.HomePhone, t.CellPhone, t.FaxNumber, t.Address1, t.Address2, t.City, t.State, t.Zip, t.Email, t.Notes });

            // Properties
            this.Property(t => t.TeamName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ContactFirstName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ContactLastName)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.WorkPhone)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.HomePhone)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.CellPhone)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.FaxNumber)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.Address1)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.State)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Zip)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Notes)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TeamHS");
            this.Property(t => t.TeamNumber).HasColumnName("TeamNumber");
            this.Property(t => t.TeamName).HasColumnName("TeamName");
            this.Property(t => t.ContactFirstName).HasColumnName("ContactFirstName");
            this.Property(t => t.ContactLastName).HasColumnName("ContactLastName");
            this.Property(t => t.WorkPhone).HasColumnName("WorkPhone");
            this.Property(t => t.HomePhone).HasColumnName("HomePhone");
            this.Property(t => t.CellPhone).HasColumnName("CellPhone");
            this.Property(t => t.FaxNumber).HasColumnName("FaxNumber");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}

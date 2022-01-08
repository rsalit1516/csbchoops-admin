using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ScheduleTeamMap : EntityTypeConfiguration<ScheduleTeam>
    {
        public ScheduleTeamMap()
        {
            // Primary Key
            this.HasKey(t => t.TeamNumber);

            // Properties
            this.Property(t => t.TeamNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamName)
                .HasMaxLength(50);

            this.Property(t => t.ContactFirstName)
                .HasMaxLength(50);

            this.Property(t => t.ContactLastName)
                .HasMaxLength(50);

            this.Property(t => t.WorkPhone)
                .HasMaxLength(50);

            this.Property(t => t.HomePhone)
                .HasMaxLength(50);

            this.Property(t => t.FaxNumber)
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(50);

            this.Property(t => t.Zip)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ScheduleTeams");
            this.Property(t => t.TeamNumber).HasColumnName("TeamNumber");
            this.Property(t => t.TeamName).HasColumnName("TeamName");
            this.Property(t => t.ContactFirstName).HasColumnName("ContactFirstName");
            this.Property(t => t.ContactLastName).HasColumnName("ContactLastName");
            this.Property(t => t.WorkPhone).HasColumnName("WorkPhone");
            this.Property(t => t.HomePhone).HasColumnName("HomePhone");
            this.Property(t => t.FaxNumber).HasColumnName("FaxNumber");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}

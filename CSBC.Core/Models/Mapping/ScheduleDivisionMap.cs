using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ScheduleDivisionMap : EntityTypeConfiguration<ScheduleDivision>
    {
        public ScheduleDivisionMap()
        {
            // Primary Key
            this.HasKey(t => t.ScheduleNumber);

            // Properties
            this.Property(t => t.ScheduleNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ScheduleName)
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

            this.Property(t => t.Notes)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ScheduleDivisions");
            this.Property(t => t.ScheduleNumber).HasColumnName("ScheduleNumber");
            this.Property(t => t.LeagueNumber).HasColumnName("LeagueNumber");
            this.Property(t => t.ScheduleName).HasColumnName("ScheduleName");
            this.Property(t => t.Computed).HasColumnName("Computed");
            this.Property(t => t.ComputedEndDate).HasColumnName("ComputedEndDate");
            this.Property(t => t.HomeFields).HasColumnName("HomeFields");
            this.Property(t => t.ParameterStartDate).HasColumnName("ParameterStartDate");
            this.Property(t => t.LenghtOfGames).HasColumnName("LenghtOfGames");
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
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}

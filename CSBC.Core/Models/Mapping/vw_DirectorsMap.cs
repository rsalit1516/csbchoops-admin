using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_DirectorsMap : EntityTypeConfiguration<vw_Directors>
    {
        public vw_DirectorsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.CompanyID });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(101);

            this.Property(t => t.Phone)
                .HasMaxLength(25);

            this.Property(t => t.PhoneSelected)
                .HasMaxLength(25);

            this.Property(t => t.CellPhone)
                .HasMaxLength(15);

            this.Property(t => t.WorkPhone)
                .HasMaxLength(25);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(20);

            this.Property(t => t.PhonePref)
                .HasMaxLength(10);

            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_Directors");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Seq).HasColumnName("Seq");
            this.Property(t => t.PhoneSelected).HasColumnName("PhoneSelected");
            this.Property(t => t.CellPhone).HasColumnName("CellPhone");
            this.Property(t => t.WorkPhone).HasColumnName("WorkPhone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.PhonePref).HasColumnName("PhonePref");
            this.Property(t => t.EmailPref).HasColumnName("EmailPref");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
        }
    }
}

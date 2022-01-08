using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_CalendarMap : EntityTypeConfiguration<vw_Calendar>
    {
        public vw_CalendarMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.sSubTitle, t.sDesc1, t.sDesc2, t.sDesc3, t.CompanyID });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.sTitle)
                .HasMaxLength(40);

            this.Property(t => t.sSubTitle)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.sDesc1)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.sDesc2)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.sDesc3)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_Calendar");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.dDate).HasColumnName("dDate");
            this.Property(t => t.sTitle).HasColumnName("sTitle");
            this.Property(t => t.sSubTitle).HasColumnName("sSubTitle");
            this.Property(t => t.Display).HasColumnName("Display");
            this.Property(t => t.sDesc1).HasColumnName("sDesc1");
            this.Property(t => t.sDesc2).HasColumnName("sDesc2");
            this.Property(t => t.sDesc3).HasColumnName("sDesc3");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.iMonth).HasColumnName("iMonth");
            this.Property(t => t.iDay).HasColumnName("iDay");
            this.Property(t => t.iYear).HasColumnName("iYear");
        }
    }
}

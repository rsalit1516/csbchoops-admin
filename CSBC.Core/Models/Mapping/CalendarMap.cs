using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class CalendarMap : EntityTypeConfiguration<Calendar>
    {
        public CalendarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.sTitle)
                .HasMaxLength(40);

            this.Property(t => t.sSubTitle)
                .HasMaxLength(40);

            this.Property(t => t.sDesc1)
                .HasMaxLength(40);

            this.Property(t => t.sDesc2)
                .HasMaxLength(40);

            this.Property(t => t.sDesc3)
                .HasMaxLength(40);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Calendar");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.dDate).HasColumnName("dDate");
            this.Property(t => t.iYear).HasColumnName("iYear");
            this.Property(t => t.iMonth).HasColumnName("iMonth");
            this.Property(t => t.iDay).HasColumnName("iDay");
            this.Property(t => t.sTitle).HasColumnName("sTitle");
            this.Property(t => t.sSubTitle).HasColumnName("sSubTitle");
            this.Property(t => t.sDesc1).HasColumnName("sDesc1");
            this.Property(t => t.sDesc2).HasColumnName("sDesc2");
            this.Property(t => t.sDesc3).HasColumnName("sDesc3");
            this.Property(t => t.Display).HasColumnName("Display");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

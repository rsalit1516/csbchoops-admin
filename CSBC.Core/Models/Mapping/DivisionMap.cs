using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class DivisionMap : EntityTypeConfiguration<Division>
    {
        public DivisionMap()
        {
            // Primary Key
            this.HasKey(t => t.DivisionID);

            // Properties
            this.Property(t => t.Div_Desc)
                .HasMaxLength(50);

            this.Property(t => t.Gender)
                .HasMaxLength(1);

            this.Property(t => t.Gender2)
                .HasMaxLength(1);

            this.Property(t => t.DraftVenue)
                .HasMaxLength(50);

            this.Property(t => t.DraftTime)
                .HasMaxLength(10);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Divisions");
            this.Property(t => t.DivisionID).HasColumnName("DivisionID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.Div_Desc).HasColumnName("Div_Desc");
            this.Property(t => t.DirectorID).HasColumnName("DirectorID");
            this.Property(t => t.CoDirectorID).HasColumnName("CoDirectorID");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.MinDate).HasColumnName("MinDate");
            this.Property(t => t.MaxDate).HasColumnName("MaxDate");
            this.Property(t => t.Gender2).HasColumnName("Gender2");
            this.Property(t => t.MinDate2).HasColumnName("MinDate2");
            this.Property(t => t.MaxDate2).HasColumnName("MaxDate2");
            this.Property(t => t.DraftVenue).HasColumnName("DraftVenue");
            this.Property(t => t.DraftDate).HasColumnName("DraftDate");
            this.Property(t => t.DraftTime).HasColumnName("DraftTime");
            this.Property(t => t.Stats).HasColumnName("Stats");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

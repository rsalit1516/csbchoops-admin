using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_GetContentMap : EntityTypeConfiguration<vw_GetContent>
    {
        public vw_GetContentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Link, t.CompanyID });

            // Properties
            this.Property(t => t.LineText)
                .HasMaxLength(100);

            this.Property(t => t.FontSize)
                .HasMaxLength(10);

            this.Property(t => t.FontColor)
                .HasMaxLength(10);

            this.Property(t => t.Link)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.cntScreen)
                .HasMaxLength(15);

            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_GetContent");
            this.Property(t => t.cntSeq).HasColumnName("cntSeq");
            this.Property(t => t.LineText).HasColumnName("LineText");
            this.Property(t => t.Bold).HasColumnName("Bold");
            this.Property(t => t.UnderLN).HasColumnName("UnderLN");
            this.Property(t => t.Italic).HasColumnName("Italic");
            this.Property(t => t.FontSize).HasColumnName("FontSize");
            this.Property(t => t.FontColor).HasColumnName("FontColor");
            this.Property(t => t.Link).HasColumnName("Link");
            this.Property(t => t.cntScreen).HasColumnName("cntScreen");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
        }
    }
}

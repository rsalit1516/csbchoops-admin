using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ContentMap : EntityTypeConfiguration<Content>
    {
        public ContentMap()
        {
            // Primary Key
            this.HasKey(t => t.cntID);

            // Properties
            this.Property(t => t.cntScreen)
                .HasMaxLength(15);

            this.Property(t => t.LineText)
                .HasMaxLength(100);

            this.Property(t => t.FontSize)
                .HasMaxLength(10);

            this.Property(t => t.FontColor)
                .HasMaxLength(10);

            this.Property(t => t.Link)
                .HasMaxLength(400);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Content");
            this.Property(t => t.cntID).HasColumnName("cntID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.cntScreen).HasColumnName("cntScreen");
            this.Property(t => t.cntSeq).HasColumnName("cntSeq");
            this.Property(t => t.LineText).HasColumnName("LineText");
            this.Property(t => t.Bold).HasColumnName("Bold");
            this.Property(t => t.UnderLn).HasColumnName("UnderLn");
            this.Property(t => t.Italic).HasColumnName("Italic");
            this.Property(t => t.FontSize).HasColumnName("FontSize");
            this.Property(t => t.FontColor).HasColumnName("FontColor");
            this.Property(t => t.Link).HasColumnName("Link");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}

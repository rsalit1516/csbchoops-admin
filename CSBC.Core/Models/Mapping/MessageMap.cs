using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            // Primary Key
            this.HasKey(t => t.MessID);

            // Properties
            this.Property(t => t.MessScreen)
                .HasMaxLength(50);

            this.Property(t => t.MessageText)
                .HasMaxLength(500);

            this.Property(t => t.LineText)
                .HasMaxLength(50);

            this.Property(t => t.FontSize)
                .HasMaxLength(50);

            this.Property(t => t.FontColor)
                .HasMaxLength(10);

            this.Property(t => t.MessageLink)
                .HasMaxLength(100);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Messages");
            this.Property(t => t.MessID).HasColumnName("MessID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.MessScreen).HasColumnName("MessScreen");
            this.Property(t => t.MessSeq).HasColumnName("MessSeq");
            this.Property(t => t.MessageText).HasColumnName("MessageText");
            this.Property(t => t.LineText).HasColumnName("LineText");
            this.Property(t => t.Bold).HasColumnName("Bold");
            this.Property(t => t.UnderLn).HasColumnName("UnderLn");
            this.Property(t => t.Italic).HasColumnName("Italic");
            this.Property(t => t.FontSize).HasColumnName("FontSize");
            this.Property(t => t.FontColor).HasColumnName("FontColor");
            this.Property(t => t.MessageLink).HasColumnName("MessageLink");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}

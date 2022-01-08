using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.CommentID);

            // Properties
            this.Property(t => t.CommentType)
                .HasMaxLength(50);

            this.Property(t => t.CreatedUSer)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Comments");
            this.Property(t => t.CommentID).HasColumnName("CommentID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CommentType).HasColumnName("CommentType");
            this.Property(t => t.LinkID).HasColumnName("LinkID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Comment1).HasColumnName("Comment");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUSer).HasColumnName("CreatedUSer");
        }
    }
}

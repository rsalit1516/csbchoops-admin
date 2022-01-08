using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_CommentsMap : EntityTypeConfiguration<vw_Comments>
    {
        public vw_CommentsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CompanyID, t.CommentID });

            // Properties
            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CommentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CommentType)
                .HasMaxLength(50);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_Comments");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CommentID).HasColumnName("CommentID");
            this.Property(t => t.CommentType).HasColumnName("CommentType");
            this.Property(t => t.LinkID).HasColumnName("LinkID");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

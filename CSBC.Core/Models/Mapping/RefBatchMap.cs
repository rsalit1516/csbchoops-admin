using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class RefBatchMap : EntityTypeConfiguration<RefBatch>
    {
        public RefBatchMap()
        {
            // Primary Key
            this.HasKey(t => t.RefBatchID);

            // Properties
            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RefBatches");
            this.Property(t => t.RefBatchID).HasColumnName("RefBatchID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class ShoppingCartMap : EntityTypeConfiguration<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            // Primary Key
            this.HasKey(t => t.CartID);

            // Properties
            this.Property(t => t.Payer_ID)
                .HasMaxLength(50);

            this.Property(t => t.Payer_Email)
                .HasMaxLength(50);

            this.Property(t => t.Txn_ID)
                .HasMaxLength(50);

            this.Property(t => t.Payment_status)
                .HasMaxLength(50);

            this.Property(t => t.ErrorMessage)
                .HasMaxLength(200);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ShoppingCart");
            this.Property(t => t.CartID).HasColumnName("CartID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.HouseID).HasColumnName("HouseID");
            this.Property(t => t.Payer_ID).HasColumnName("Payer_ID");
            this.Property(t => t.Payment_Gross).HasColumnName("Payment_Gross");
            this.Property(t => t.Payment_Fee).HasColumnName("Payment_Fee");
            this.Property(t => t.Payer_Email).HasColumnName("Payer_Email");
            this.Property(t => t.Txn_ID).HasColumnName("Txn_ID");
            this.Property(t => t.Payment_status).HasColumnName("Payment_status");
            this.Property(t => t.ErrorMessage).HasColumnName("ErrorMessage");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

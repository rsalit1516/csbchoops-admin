using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class SponsorPaymentMap : EntityTypeConfiguration<SponsorPayment>
    {
        public SponsorPaymentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PaymentID, t.SponsorProfileID, t.Amount, t.PaymentType });

            // Properties
            this.Property(t => t.PaymentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SponsorProfileID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Amount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PaymentType)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.TransactionNumber)
                .HasMaxLength(50);

            this.Property(t => t.Memo)
                .HasMaxLength(100);

            this.Property(t => t.ShoppingCartID)
                .HasMaxLength(50);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("SponsorPayments");
            this.Property(t => t.PaymentID).HasColumnName("PaymentID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.SponsorProfileID).HasColumnName("SponsorProfileID");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.PaymentType).HasColumnName("PaymentType");
            this.Property(t => t.TransactionDate).HasColumnName("TransactionDate");
            this.Property(t => t.TransactionNumber).HasColumnName("TransactionNumber");
            this.Property(t => t.Memo).HasColumnName("Memo");
            this.Property(t => t.ShoppingCartID).HasColumnName("ShoppingCartID");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_BatchPlayersMap : EntityTypeConfiguration<vw_BatchPlayers>
    {
        public vw_BatchPlayersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CompanyID, t.PlayerID, t.PeopleID, t.Online });

            // Properties
            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DraftID)
                .HasMaxLength(3);

            this.Property(t => t.PlayerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PeopleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PlayerName)
                .HasMaxLength(102);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(20);

            this.Property(t => t.Online)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.Phone)
                .HasMaxLength(25);

            this.Property(t => t.Mother)
                .HasMaxLength(103);

            this.Property(t => t.Father)
                .HasMaxLength(103);

            this.Property(t => t.Sea_Desc)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_BatchPlayers");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.RefundBatchID).HasColumnName("RefundBatchID");
            this.Property(t => t.DraftID).HasColumnName("DraftID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.HouseID).HasColumnName("HouseID");
            this.Property(t => t.PeopleID).HasColumnName("PeopleID");
            this.Property(t => t.PlayerName).HasColumnName("PlayerName");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.PaidAmount).HasColumnName("PaidAmount");
            this.Property(t => t.Online).HasColumnName("Online");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Mother).HasColumnName("Mother");
            this.Property(t => t.Father).HasColumnName("Father");
            this.Property(t => t.Sea_Desc).HasColumnName("Sea_Desc");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class vw_CheckLoginMap : EntityTypeConfiguration<vw_CheckLogin>
    {
        public vw_CheckLoginMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CompanyID, t.TimeZone, t.UserID });

            // Properties
            this.Property(t => t.CompanyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TimeZone)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CompanyName)
                .HasMaxLength(50);

            this.Property(t => t.EmailSender)
                .HasMaxLength(50);

            this.Property(t => t.ImageName)
                .HasMaxLength(50);

            this.Property(t => t.Sea_Desc)
                .HasMaxLength(50);

            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.PWord)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("vw_CheckLogin");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.TimeZone).HasColumnName("TimeZone");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.EmailSender).HasColumnName("EmailSender");
            this.Property(t => t.ImageName).HasColumnName("ImageName");
            this.Property(t => t.SeasonID).HasColumnName("SeasonID");
            this.Property(t => t.SignUpSeasonID).HasColumnName("SignUpSeasonID");
            this.Property(t => t.Sea_Desc).HasColumnName("Sea_Desc");
            this.Property(t => t.HouseID).HasColumnName("HouseID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserType).HasColumnName("UserType");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.PWord).HasColumnName("PWord");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.SignedDate).HasColumnName("SignedDate");
            this.Property(t => t.SignedDateEnd).HasColumnName("SignedDateEnd");
        }
    }
}

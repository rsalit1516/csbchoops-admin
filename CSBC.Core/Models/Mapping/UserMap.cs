using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CSBC.Core.Models;

namespace CSBC.Core.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.PWord)
                .HasMaxLength(50);

            this.Property(t => t.PassWord)
                .HasMaxLength(300);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PWord).HasColumnName("PWord");
            this.Property(t => t.PassWord).HasColumnName("PassWord");
            this.Property(t => t.UserType).HasColumnName("UserType");
            this.Property(t => t.ValidationCode).HasColumnName("ValidationCode");
            this.Property(t => t.PeopleID).HasColumnName("PeopleID");
            this.Property(t => t.HouseID).HasColumnName("HouseID");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
        }
    }
}

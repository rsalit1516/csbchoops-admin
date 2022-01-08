using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CSBC.Core.Models.Mapping
{
    public class testMap : EntityTypeConfiguration<test>
    {
        public testMap()
        {
            // Primary Key
            this.HasKey(t => t.PeopleID);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.Workphone)
                .HasMaxLength(25);

            this.Property(t => t.Cellphone)
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.LatestSeason)
                .HasMaxLength(15);

            this.Property(t => t.LatestShirtSize)
                .HasMaxLength(20);

            this.Property(t => t.Gender)
                .HasMaxLength(1);

            this.Property(t => t.SchoolName)
                .HasMaxLength(50);

            this.Property(t => t.CreatedUser)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("test");
            this.Property(t => t.PeopleID).HasColumnName("PeopleID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.MainHouseID).HasColumnName("MainHouseID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Workphone).HasColumnName("Workphone");
            this.Property(t => t.Cellphone).HasColumnName("Cellphone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Suspended).HasColumnName("Suspended");
            this.Property(t => t.LatestSeason).HasColumnName("LatestSeason");
            this.Property(t => t.LatestShirtSize).HasColumnName("LatestShirtSize");
            this.Property(t => t.LatestRating).HasColumnName("LatestRating");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.BC).HasColumnName("BC");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.SchoolName).HasColumnName("SchoolName");
            this.Property(t => t.Grade).HasColumnName("Grade");
            this.Property(t => t.GiftedLevelsUP).HasColumnName("GiftedLevelsUP");
            this.Property(t => t.FeeWaived).HasColumnName("FeeWaived");
            this.Property(t => t.Player).HasColumnName("Player");
            this.Property(t => t.Parent).HasColumnName("Parent");
            this.Property(t => t.Coach).HasColumnName("Coach");
            this.Property(t => t.AsstCoach).HasColumnName("AsstCoach");
            this.Property(t => t.BoardOfficer).HasColumnName("BoardOfficer");
            this.Property(t => t.BoardMember).HasColumnName("BoardMember");
            this.Property(t => t.AD).HasColumnName("AD");
            this.Property(t => t.Sponsor).HasColumnName("Sponsor");
            this.Property(t => t.SignUps).HasColumnName("SignUps");
            this.Property(t => t.TryOuts).HasColumnName("TryOuts");
            this.Property(t => t.TeeShirts).HasColumnName("TeeShirts");
            this.Property(t => t.Printing).HasColumnName("Printing");
            this.Property(t => t.Equipment).HasColumnName("Equipment");
            this.Property(t => t.Electrician).HasColumnName("Electrician");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            this.Property(t => t.TEMPID).HasColumnName("TEMPID");
        }
    }
}

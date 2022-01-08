using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;
using CSBC.Core;
using System.Configuration;
using CSBC.Core.Models;

namespace CSBC.Core.Repositories
{
    public class CoachRepository : EFRepository<Coach>, ICoachRepository
    {

        public CoachRepository(DbContext context) : base(context) { }
        //protected CSBCDbContext DataContext { get; set; }
        //protected DbSet<ScheduleGame> DbSet;
      
        public  IQueryable<vw_Coaches> GetSeasonCoaches(int seasonId)
        {           
            List<vw_Coaches> vwCoach = new List<vw_Coaches>();
            foreach (var coach in Context.Set<Coach>().Where(c => c.SeasonID == seasonId).ToList<Coach>())
            {
                var vwPlayer = new vw_Coaches(); 
                vwPlayer.PeopleID = coach.PeopleID;
                if (coach.Person != null)
                    vwPlayer.Name = coach.Person.LastName + ", " + coach.Person.FirstName;
                vwPlayer.CoachPhone = coach.CoachPhone;
                vwPlayer.ShirtSize = coach.ShirtSize;
                vwPlayer.CoachID = coach.CoachID;
                vwCoach.Add(vwPlayer);
            }
            var vwCoaches = vwCoach.AsQueryable<vw_Coaches>().OrderBy(c => c.Name);
            return vwCoaches;
        }

        public DataTable GetCoaches(int seasonId)
        {
            var cn = new SqlConnection((Context as CSBCDbContext).CSDBConnectionString);
            cn.Open();
            var sSQL = "EXEC GetCoaches ";
            sSQL += "@SeasonID = " + seasonId;
            var myAdapter = new SqlDataAdapter(sSQL, cn);
            var dtResults = new DataTable();
            myAdapter.Fill(dtResults);
            myAdapter.Dispose();
            return dtResults;
        }
        public vw_Coaches GetCoach(int id)
        {
            var coach = Context.Set<Coach>().Find(id);

            vw_Coaches vw = new vw_Coaches();
            vw.CompanyID = (int)coach.CompanyID;
            vw.SeasonID = coach.SeasonID;
            vw.CoachID = coach.CoachID;
            vw.Name = (coach.Person.FirstName + " " + coach.Person.LastName);
            vw.Housephone = coach.Person.Household.Phone;
            vw.Cellphone = coach.Person.Cellphone;
            vw.ShirtSize = coach.ShirtSize;
            vw.PeopleID = coach.PeopleID;
            vw.Address1 = coach.Person.Household.Address1;
            vw.City = coach.Person.Household.City;
            vw.State = coach.Person.Household.State;
            vw.Zip = coach.Person.Household.Zip;
            vw.CoachPhone = coach.CoachPhone;     
           
            return vw;

        }
        public Coach GetCoachForSeason(int seasonId, int peopleId)
        {
            return Context.Set<Coach>().FirstOrDefault(c => c.SeasonID == seasonId && c.PeopleID == peopleId);
        }

        public bool DeleteById(int id)
        {
            bool tflag = false;

            var coach = Context.Set<Coach>().Find(id);
            if (coach != null)
            {
                Context.Set<Coach>().Remove(coach);
                Context.SaveChanges();
                tflag = true;
            }
            return tflag;
        }
        public IQueryable<vw_Coaches> GetCoachVolunteers(int companyId, int seasonId)
        {          
            var coaches = from p in Context.Set<Person>()
                                where p.Coach == true
                                orderby p.LastName, p.FirstName
                                select new
                                {
                                    p.PeopleID,
                                    p.LastName,
                                    p.FirstName
                                };

            IQueryable<vw_Coaches> vwCoaches = coaches.Cast<vw_Coaches>();

            var count = coaches.Count();
            var currentCoaches = GetSeasonCoaches(seasonId);
            List<vw_Coaches> vwCoach = new List<vw_Coaches>();
            foreach (var player in coaches)
            {
                if (!currentCoaches.Any<vw_Coaches>(p => p.PeopleID == player.PeopleID))
                {
                var vwPlayer = new vw_Coaches();
  
                vwPlayer.PeopleID = player.PeopleID;
                vwPlayer.Name = player.LastName + ", " + player.FirstName;
                //vwPlayer.CoachPhone = player.
                vwCoach.Add(vwPlayer);
                }
            }
            vwCoaches = vwCoach.AsQueryable<vw_Coaches>();
            return vwCoaches;
        }

        
    }
}


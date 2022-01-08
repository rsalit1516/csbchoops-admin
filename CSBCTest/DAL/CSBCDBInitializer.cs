using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CSBC.Core.Models;
using CSBC.Core.Data;

namespace CSBC.Web.DAL
{

    public class CSBCDbInitializer : CreateDatabaseIfNotExists<CSBCDbContext>
    {
        public const string companyName = "Coral Springs Basketball Club";
        protected override void Seed(CSBCDbContext context)
        {
            CustomSeed(context);
        }
        public void CustomSeed(CSBCDbContext context)
        {
            DeleteTestColors(context);
            InitColors(context);

            /*CreateDummyCompany(context);

            var companyRepository = new CompanyRepository(context);
            int companyId = companyRepository.FindCompanyByName(companyName);

            CreateDummyPeople(context, companyId);

            var seasons = CreateDummySeasons(context);
            var seasonRepository = new SeasonRepository(context);
            var season = seasonRepository.GetCurrentSeason(companyId);

            var coaches = new List<Coach>
            {
                new Coach { CompanyID = companyId, PeopleID = 1, SeasonID = season.SeasonID}
            };
            coaches.ForEach(s => context.Coaches.Add(s));
            context.SaveChanges();

            */
        }


        private void CreateDummyCompany(CSBCDbContext context)
        {
            var company = new List<Company>
            {
                new Company {CompanyName = "Coral Springs Basketball Club", CreatedDate = DateTime.Now, EmailSender = "registration@csbchoops.net"}
            };
            company.ForEach(s => context.Companies.Add(s));
            context.SaveChanges();
        }

        private void CreateDummyPeople(CSBCDbContext context, int companyid)
        {
            var people = new List<Person>
            {
                new Person {CompanyID = companyid, FirstName = "James", LastName = "Chance", Cellphone = "954-321-3214", Email="test@ab.com", Gender="M", Grade=9, Player=true, CreatedDate=DateTime.Now, CreatedUser="Test"},
                new Person {CompanyID = companyid, FirstName = "Peter", LastName = "Afta", Cellphone = "954-321-3214", Email="test1@ab.com", Gender="M", Grade=9, Player=true, CreatedDate=DateTime.Now, CreatedUser="Test"},
            };
            people.ForEach(s => context.People.Add(s));
            context.SaveChanges();
        }

        private static List<Season> CreateDummySeasons(CSBCDbContext context)
        {
            var seasons = new List<Season>
            { 
                new Season { Description = "Winter 2013", FromDate = Convert.ToDateTime("12/1/13"), ToDate = Convert.ToDateTime("2/1/14"),  ParticipationFee = 100.50M, CreatedDate = DateTime.Now, CurrentSchedule = true  }, 
                new Season { Description = "Summer 2013", FromDate = Convert.ToDateTime("8/1/13"), ToDate = Convert.ToDateTime("12/1/13"),  ParticipationFee = 100.50M, CreatedDate = DateTime.Now, CurrentSchedule = false  }, 
                new Season { Description = "Fall 2013", FromDate = Convert.ToDateTime("12/1/13"), ToDate = Convert.ToDateTime("2/1/14"),  ParticipationFee = 100.50M, CreatedDate = DateTime.Now, CurrentSchedule = false  }

            };
            seasons.ForEach(s => context.Seasons.Add(s));
            context.SaveChanges();
            return seasons;
        }

        public List<string> ColorNames = new List<string>(new string[] { "Red", "Blue", "Green", "Yellow", "Black", "White", "Orange", "Heather", "Tan" });
        public void InitColors(CSBCDbContext context)
        {
            var rep = new ColorRepository(context);
            for (int i = 0; i < ColorNames.Count; i++)
            {
                rep.Insert(new Color { ColorName = ColorNames[i], CompanyID = 2 });
            }
            rep.Insert(new Color { ColorName = "Chartreuse", CompanyID = 2, Discontinued = true });
            context.SaveChanges();
        }
        public void DeleteTestColors(CSBCDbContext context)
        {
            var rep = new ColorRepository(context);
            for (int i = 0; i < ColorNames.Count; i++)
            {
                var color = rep.GetByName(1, ColorNames[i]);
                rep.Delete(color);
            }
        }
    }
}
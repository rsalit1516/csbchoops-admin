using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;
using CSBC.Core.Models;
using CSBC.Core.Data;
using CSBC.Core.Repositories;

namespace CSBC.Core.Data
{

    public class CSBCDbInitializer : CreateDatabaseIfNotExists<CSBCDbContext>
    {
        public const string companyName = "Test Basketball Club";
        public int CompanyId = Convert.ToInt32(ConfigurationManager.AppSettings["CompanyId"]);
        public List<string> HouseholdLastNames = new List<string>(new string[] { "Fallon", "Leno", "Obrien", "Letterman", "Morgan", "Johnson", "Smith", "Clapton", "Bruce", "Tweedy", "Franks", "Garcia", "Lesh", "Hart", "Weir", "Kreutzman" });
        public List<string> FirstNames = new List<string>(new string[] { "Mike", "Rich", "Conan", "David", "Fred", "Brenda", "Ann", "Wilbur", "Harry", "Jack", "Jill", "Robert", "William", "Carol", "James", "Harold", "Skye", "Beatrice", "Thomas" });


        public const string Household1 = "Schwartz";
        public const string Household2 = "Smith";
        public const string Household3 = "Jones";
        public const string Household4 = "Lesh";
        public const string Household5 = "Weir";
        public const string Household6 = "Johnson";
        public const string PersonFirstName1 = "John";
        public const string PersonFirstName2 = "Barry";
        public const string PersonFirstName3 = "Edward";
        public const string PersonFirstName4 = "Richard";
        public const string PersonFirstName5 = "Phil";

        public List<string> ColorNames = new List<string>(new string[] { "Red", "Blue", "Green", "Yellow", "Black", "White", "Orange", "Heather", "Tan" });

        public ScheduleGame scheduleGame1 = new ScheduleGame
        {
            ScheduleNumber = 1001,
            GameNumber = 1,
            HomeTeamNumber = 10,
            LocationNumber = 1,
            GameDate = DateTime.Today,
            GameTime = "6:00 PM",
            VisitingTeamNumber = 3
        };

        public Season CurrentSeason
        {
            get
            {
                var rep = new SeasonRepository(new CSBCDbContext());
                return rep.GetCurrentSeason(CompanyId);
            }
        }

        protected override void Seed(CSBCDbContext context)
        {
            CustomSeed(context);
        }
        public void CustomSeed(CSBCDbContext context)
        {
            DeleteTestSponsors();
            DeleteTestCoaches(context);
            DeleteTestColors(context);
            //DeleteTestPlayers(context);
            DeleteTestPeople(context);
            DeleteTestTeams();
            DeleteTestDivisions(context);
            DeleteTestSeasons();
            DeleteTestHouseholds(context);
            InitColors(context);
            InitSeasons(context);
            InitHouseholds(context);
            InitPersonTest(context);
            InitDivision(context);
            InitTeams(context);
            InitDirectorTest();
            InitPlayers(context);
            InitCoaches(context);
            InitSponsors();
        }


        public void InitHouseholds(CSBCDbContext context)
        {
            var rand = new Random();
            int days = 0;
            days = (rand.Next((1), (365 * 18)));
            List<string> StreetNames = new List<string>(new string[] { "Minute Way", "Main Street", "Adams Place", "First Ave", "Second Ave", "123rd Ave", "52nd Way" });
            var streets = (rand.Next((1), (StreetNames.Count)));
            var rep = new HouseholdRepository(context);
            for (int i = 0; i < HouseholdLastNames.Count; i++)
            {
                days = (rand.Next((1), (10000)));
                streets = (rand.Next((0), (StreetNames.Count - 1)));
                rep.Insert(new Household
                {
                    Name = HouseholdLastNames[i],
                    CompanyID = CompanyId,
                    Address1 = days.ToString() + " " + StreetNames[streets],
                    City = "Coral Springs",
                    State = "FL",
                    Email = HouseholdLastNames[1] + "@yahoo.com",
                    Phone = "954-222-2222"
                });
            }
            //rep.Insert(new Household { Name = HouseholdLastNames[0], CompanyID = CompanyId, Address1 = "10 Minute Lane", City = "Plainview", State = "NY", Email = "joe@aol.com", Phone = "516-222-2222" });
            //rep.Insert(new Household { Name = HouseholdLastNames[1], CompanyID = CompanyId, Address1 = "12 Second Street", City = "Keinview", State = "MO", Email = "Smith@aol.com", Phone = "206-222-2222" });
            //rep.Insert(new Household { Name = HouseholdLastNames[2], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "San Martin", State = "CA", Email = Household3 + "@mpgmail.com", Phone = "206-222-2223" });
            //rep.Insert(new Household { Name = HouseholdLastNames[3], CompanyID = CompanyId, Address1 = "Minute Road", City = "Fleping", State = "MO", Email = Household4 + "@gmnoail.com", Phone = "206-222-2224" });
            //rep.Insert(new Household { Name = HouseholdLastNames[4], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[4] + "@npgmail.com", Phone = "206-222-2225" });
            //rep.Insert(new Household { Name = HouseholdLastNames[5], CompanyID = CompanyId, Address1 = "12 Year Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[5] + "@npgmail.com", Phone = "206-222-2225" });
            //rep.Insert(new Household { Name = HouseholdLastNames[6], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[6] + "@npgmail.com", Phone = "206-222-2225" });
            //rep.Insert(new Household { Name = HouseholdLastNames[7], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[7] + "@npgmail.com", Phone = "206-222-2225" });
            //rep.Insert(new Household { Name = HouseholdLastNames[8], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[8] + "@npgmail.com", Phone = "206-222-2225" });
            //rep.Insert(new Household { Name = HouseholdLastNames[9], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[9] + "@npgmail.com", Phone = "206-222-2225" });
            //rep.Insert(new Household { Name = HouseholdLastNames[10], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[10] + "@npgmail.com", Phone = "206-222-2225" });
            //rep.Insert(new Household { Name = HouseholdLastNames[11], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[11] + "@npgmail.com", Phone = "206-222-2225" });
            //rep.Insert(new Household { Name = HouseholdLastNames[12], CompanyID = CompanyId, Address1 = "12 Hour Ave", City = "Keinview", State = "MO", Email = HouseholdLastNames[12] + "@npgmail.com", Phone = "206-222-2225" });

            var no = context.SaveChanges();

        }

        public bool InitPersonTest(CSBCDbContext context)
        {
            Household house;
            IQueryable<Household> houses;
            var rep = new PersonRepository(context);
            Random rnd = new Random();
            Person no;
            var rand = new Random();
            int days = 0;
            days = -(rand.Next((365 * 5), (365 * 18)));
            var repHouse = new HouseholdRepository(context);

            for (int i = 0; i < HouseholdLastNames.Count; i++)
            {
                houses = repHouse.GetByName(HouseholdLastNames[i]);
                house = houses.FirstOrDefault();
                if (house != null)
                {
                    days = -(rand.Next((365 * 5), (365 * 18)));
                    var person = new Person();
                    person.CompanyID = CompanyId;
                    person.FirstName = FirstNames[i];
                    person.LastName = HouseholdLastNames[i];
                    person.HouseID = house.HouseID;
                    person.AD = false;
                    person.Coach = false;
                    person.Parent = false;
                    person.Player = true;
                    person.Gender = "M";
                    person.Sponsor = ((i % 4) == 0);
                    person.BirthDate = DateTime.Today.AddDays(days);

                    no = rep.Insert(person);
                }
            }
            for (int i = 0; i < HouseholdLastNames.Count; i++)
            {
                houses = repHouse.GetByName(HouseholdLastNames[i]);
                house = houses.FirstOrDefault();
                if (house != null)
                {
                    days = -(rand.Next((365 * 18), (365 * 70)));
                    no = rep.Insert(new Person
                    {
                        CompanyID = CompanyId,
                        FirstName = FirstNames[i + 1],
                        LastName = HouseholdLastNames[i],
                        HouseID = house.HouseID,
                        AD = true,
                        Coach = true,
                        Parent = true,
                        Player = false,
                        Gender = "M",
                        BirthDate = DateTime.Today.AddDays(days)
                    });
                }
            }
            context.SaveChanges();
            return (true);  //may want to change this
        }

        public bool InitDirectorTest()
        {
            using (var db = new CSBC.Core.Data.CSBCDbContext())
            {
                var rep = new DirectorRepository(db);
                InitHouseholds(db);
                InitPersonTest(db);
                var personRep = new PersonRepository(db);
                Person person;
                for (int i = 0; i < HouseholdLastNames.Count; i++)
                {
                    person = personRep.FindPersonByLastAndFirstName(HouseholdLastNames[i], FirstNames[i]);
                    rep.Insert(new Director { CompanyID = CompanyId, PeopleID = person.PeopleID, Title = "Assistant" });
                }
                return true;
            }
        }

        public bool InitUser(CSBC.Core.Data.CSBCDbContext context)
        {
            using (var db = new CSBCDbContext())
            {
                var personRep = new PersonRepository(db);
                InitHouseholds(db);
                InitPersonTest(db);
                Person person;
                var rep = new UserRepository(db);

                for (int i = 0; i < HouseholdLastNames.Count; i++)
                {
                    person = personRep.FindPersonByLastAndFirstName(HouseholdLastNames[i], FirstNames[i + 1]); //find adults
                    rep.Insert(new User
                    {
                        HouseID = (int)person.HouseID,
                        UserName = person.LastName + "1",
                        Name = person.FirstName + " " + person.LastName,
                        PWord = person.LastName,
                        PassWord = person.LastName,
                        PeopleID = person.PeopleID,
                        CompanyID = person.CompanyID,
                        UserType = 1,
                        CreatedDate = DateTime.Today,
                        CreatedUser = "Tester"
                    }
                    );

                }

                db.SaveChanges();
            }
            return true;
        }


        public void InitPlayers(CSBCDbContext context)
        {
            context = new CSBCDbContext();
            var currentSeason = CurrentSeason.SeasonID;
            var repPeople = new PersonRepository(new CSBCDbContext());
            var people = repPeople.GetPlayers(CompanyId);

            int division = 0;
            Dictionary<int, int> list = new Dictionary<int, int>();
            var repDivision = new DivisionRepository(new CSBCDbContext());
            var rep = new PlayerRepository(new CSBCDbContext());
            foreach (Person person in people)
            {
                division = repDivision.GetPlayerDivision(CompanyId, currentSeason, person.PeopleID);
                if (division != 0)
                {
                    rep.Insert(
                        new Player
                        {
                            CompanyID = CompanyId,
                            SeasonID = currentSeason,
                            DivisionID = division,
                            PeopleID = person.PeopleID

                        });
                    context.SaveChanges();
                }
            }

        }

        public void InitCoaches(CSBCDbContext context)
        {
            context = new CSBCDbContext();
            var currentSeason = CurrentSeason.SeasonID;
            var repPeople = new PersonRepository(new CSBCDbContext());
            var people = context.People.Where(p => p.Coach == true);

            var rep = new CoachRepository(new CSBCDbContext());
            foreach (Person person in people)
            {
                rep.Insert(
                    new Coach
                    {
                        CompanyID = CompanyId,
                        SeasonID = currentSeason,
                        PeopleID = person.PeopleID,
                    });
                context.SaveChanges();

            }

        }
        public void InitSponsors()
        {
            using (var db = new CSBCDbContext())
            {
                var currentSeason = CurrentSeason.SeasonID;
                var repPeople = new PersonRepository(new CSBCDbContext());
                var people = db.People.Where(p => p.Sponsor == true).ToList();

                var rep = new SponsorRepository(new CSBCDbContext());
                var repColor = new ColorRepository(new CSBCDbContext());
                var color = repColor.GetByName(1, ColorNames[2].ToString());
                var colorId = color == null ? 0 : color.ID;
                var repProfile = new SponsorProfileRepository(new CSBCDbContext());
                var id = new Random();
                foreach (Person person in people)
                {
                    var sponsorProfile = repProfile.Insert(new SponsorProfile
                    {
                        SpoName = person.LastName.Trim() + "Company",
                        SponsorProfileID = 0,
                        CompanyID = CompanyId,
                        HouseID = person.HouseID,
                        State = "FL",
                        City = "Coral Springs",
                        Address = person.Household.Address1,
                        ContactName = person.FirstName.Trim() + " " + person.LastName.Trim()

                    });

                    rep.Insert(
                        new Sponsor
                        {
                            SponsorID = 0,
                            CompanyID = CompanyId,
                            SeasonID = currentSeason,
                            Color1ID = colorId,
                            SponsorProfileID = sponsorProfile.SponsorProfileID
                        });
                    db.SaveChanges();
                }
            }

        }

        public bool InitDivision(CSBCDbContext context)
        {
            var init = new CSBCDbInitializer();
            var divisionRep = new DivisionRepository(context);

            InitPersonTest(new CSBCDbContext());
            init.InitSeasons(new CSBCDbContext());
            var seasonRep = new SeasonRepository(context);
            var season = seasonRep.GetCurrentSeason(CompanyId);

            var repPerson = new PersonRepository(context);
            var today = DateTime.Now;
            var schoolYearStart = DateTime.Parse("09/01/2013");

            var person = repPerson.GetADs(CompanyId);

            divisionRep.Insert(
                    new Division
                    {
                        CompanyID = CompanyId,
                        SeasonID = season.SeasonID,
                        Div_Desc = "T2_Coed",
                        DirectorID = person.FirstOrDefault<Person>().PeopleID,
                        Gender = "M",
                        MinDate = schoolYearStart.AddYears(-6),
                        MaxDate = schoolYearStart.AddYears(-5).AddDays(-1),
                        DraftDate = today.AddDays(12),
                        DraftTime = today.AddDays(12).ToShortTimeString()
                    });

            context.SaveChanges();
            divisionRep.Insert(
                   new Division
                   {
                       CompanyID = CompanyId,
                       SeasonID = season.SeasonID,
                       Div_Desc = "T3_Coed",
                       DirectorID = person.FirstOrDefault<Person>().PeopleID,
                       Gender = "M",
                       MinDate = schoolYearStart.AddYears(-8),
                       MaxDate = schoolYearStart.AddYears(-6).AddDays(-1),
                       DraftDate = today.AddDays(12),
                       DraftTime = today.AddDays(12).ToShortTimeString()
                   });

            context.SaveChanges();
            divisionRep.Insert(
                   new Division
                   {
                       CompanyID = CompanyId,
                       SeasonID = season.SeasonID,
                       Div_Desc = "T4_Coed",
                       DirectorID = person.FirstOrDefault<Person>().PeopleID,
                       Gender = "M",
                       MinDate = schoolYearStart.AddYears(-10),
                       MaxDate = schoolYearStart.AddYears(-8).AddDays(-1),
                       DraftDate = today.AddDays(12),
                       DraftTime = today.AddDays(12).ToShortTimeString()
                   });
            context.SaveChanges();
            divisionRep.Insert(
                   new Division
                   {
                       CompanyID = CompanyId,
                       SeasonID = season.SeasonID,
                       Div_Desc = "SI_Boys",
                       DirectorID = person.FirstOrDefault<Person>().PeopleID,
                       Gender = "M",
                       MinDate = schoolYearStart.AddYears(-12),
                       MaxDate = schoolYearStart.AddYears(-10).AddDays(-1),
                       DraftDate = today.AddDays(12),
                       DraftTime = today.AddDays(12).ToShortTimeString()
                   });
            context.SaveChanges();
            divisionRep.Insert(
                   new Division
                   {
                       CompanyID = CompanyId,
                       SeasonID = season.SeasonID,
                       Div_Desc = "FJV_Boys",
                       DirectorID = person.FirstOrDefault<Person>().PeopleID,
                       Gender = "M",
                       MinDate = schoolYearStart.AddYears(-14),
                       MaxDate = schoolYearStart.AddYears(-12).AddDays(-1),
                       DraftDate = today.AddDays(12),
                       DraftTime = today.AddDays(12).ToShortTimeString()
                   });
            context.SaveChanges();
            divisionRep.Insert(
                   new Division
                   {
                       CompanyID = CompanyId,
                       SeasonID = season.SeasonID,
                       Div_Desc = "SJV_Boys",
                       DirectorID = person.FirstOrDefault<Person>().PeopleID,
                       Gender = "M",
                       MinDate = schoolYearStart.AddYears(-16),
                       MaxDate = schoolYearStart.AddYears(-14).AddDays(-1),
                       DraftDate = today.AddDays(12),
                       DraftTime = today.AddDays(12).ToShortTimeString()
                   });
            context.SaveChanges();
            divisionRep.Insert(
                   new Division
                   {
                       CompanyID = CompanyId,
                       SeasonID = season.SeasonID,
                       Div_Desc = "HS_Boys",
                       DirectorID = person.FirstOrDefault<Person>().PeopleID,
                       Gender = "M",
                       MinDate = schoolYearStart.AddYears(-18),
                       MaxDate = schoolYearStart.AddYears(-16).AddDays(-1),
                       DraftDate = today.AddDays(12),
                       DraftTime = today.AddDays(12).ToShortTimeString()
                   });
            context.SaveChanges();
            divisionRep.Insert(
                    new Division
                    {
                        CompanyID = CompanyId,
                        SeasonID = season.SeasonID,
                        Div_Desc = "JV_Girls",
                        DirectorID = person.FirstOrDefault<Person>().PeopleID,
                        Gender = "F",
                        MinDate = schoolYearStart.AddYears(-17),
                        MaxDate = schoolYearStart.AddYears(-14),
                        DraftDate = today.AddDays(12),
                        DraftTime = today.AddDays(12).ToShortTimeString()
                    });

            context.SaveChanges();
            return true;
        }
        public bool InitSeasons(CSBCDbContext context)
        {
            var rep = new SeasonRepository(context);
            var startDate = DateTime.Now.AddDays(-(365 * 2));
            for (int i = 0; i < 12; i++)
            {
                rep.Insert(new Season
                {
                    CompanyID = CompanyId,
                    Description = convertSeason(getSeason(startDate)) + "-" + startDate.Year.ToString(),
                    FromDate = startDate,
                    ToDate = startDate.AddDays(80),
                    ParticipationFee = 99,
                    SponsorFee = (decimal)112.50,
                    CurrentSeason = ((DateTime.Today > startDate) && (DateTime.Today <= startDate.AddDays(80))) ? true : false

                });
                startDate = startDate.AddDays(90);
            }
            var no = context.SaveChanges();
            return (no > 0);
        }
        private int getSeason(DateTime date)
        {
            float value = (float)date.Month + date.Day / 100;   // <month>.<day(2 digit)>
            if (value < 3.21 || value >= 12.22) return 3;   // Winter
            if (value < 6.21) return 0; // Spring
            if (value < 9.23) return 1; // Summer
            return 2;   // Autumn
        }
        private string convertSeason(int value)
        {
            string season = "Spring";
            if (value == 1) season = "Summer";
            else if (value == 2) season = "Autumn";
            else if (value == 3) season = "Winter";
            return season;
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

        public void InitTeams(CSBCDbContext context)
        {
            using (context)
            {
                var rep = new TeamRepository(context);
                var repSeason = new SeasonRepository(context);
                var season = repSeason.GetCurrentSeason(CompanyId);
                var repDivisions = new DivisionRepository(context);
                var divisions = repDivisions.GetDivisions(season.SeasonID).ToList<Division>();
                var repcolors = new ColorRepository(context);
                foreach (Division division in divisions)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var color = repcolors.GetByName(CompanyId, ColorNames[i]);
                        var team = new Team
                        {
                            DivisionID = division.DivisionID,
                            SeasonID = season.SeasonID,
                            TeamName = "T-" + i.ToString() + "-" + division.Div_Desc.Trim(),
                            CompanyID = CompanyId,
                            TeamNumber = i.ToString(),
                            TeamColor = ColorNames[i],
                            TeamColorID = color.ID
                        };
                        rep.Insert(team);
                    }
                }

            }
        }
        public void InitColors(CSBCDbContext context)
        {
            var rep = new ColorRepository(context);
            for (int i = 0; i < ColorNames.Count; i++)
            {
                rep.Insert(new Color { ColorName = ColorNames[i], CompanyID = CompanyId });
            }
            rep.Insert(new Color { ColorName = "Chartreuse", CompanyID = CompanyId, Discontinued = true });
            context.SaveChanges();
        }

        public void DeleteTestColors(CSBCDbContext context)
        {
            var rep = new ColorRepository(context);
            for (int i = 0; i < ColorNames.Count; i++)
            {
                while (true)
                {
                    var color = rep.GetByName(1, ColorNames[i]);
                    if (color == null)
                    {
                        break;
                    }
                    else
                    {
                        rep.Delete(color);
                    }
                }
            }
        }
        public void DeleteTestHouseholds(CSBCDbContext context)
        {
            using (var db = new CSBCDbContext())
            {
                var rep = new HouseholdRepository(db);
                var people = rep.GetAll(CompanyId).ToList<Household>();
                foreach (Household person in people)
                {
                    rep.Delete(person);
                }
            }
        }
        public void DeleteTestPeople(CSBCDbContext context)
        {
            var rep = new PersonRepository(context);
            var people = rep.GetAll(CompanyId);
            foreach (Person person in people)
            {
                rep.Delete(person);
            }
        }
        public void DeleteTestPlayers(CSBCDbContext context)
        {
            var rep = new PlayerRepository(context);
            var seasonPlayers = rep.GetSeasonPlayers(CurrentSeason.SeasonID).ToList<SeasonPlayer>();
            foreach (SeasonPlayer seasonPlayer in seasonPlayers)
            {
                var player = rep.GetById(seasonPlayer.PlayerID);
                rep.Delete(player);
            }
        }
        public void DeleteTestCoaches(CSBCDbContext context)
        {
            var rep = new CoachRepository(context);
            var coaches = rep.GetAll().ToList<Coach>();
            foreach (Coach coach in coaches)
            {
                rep.Delete(coach);
            }
        }
        public void DeleteTestSponsors()
        {
            using (var db = new CSBCDbContext())
            {
                var rep = new SponsorRepository(db);
                var sponsors = rep.GetAll(CompanyId).ToList<Sponsor>();
                foreach (Sponsor sponsor in sponsors)
                {
                    rep.Delete(sponsor);
                }
            }
        }
        public void DeleteTestTeams()
        {
            using (var db = new CSBCDbContext())
            {
                var rep = new TeamRepository(db);
                foreach (Team team in rep.GetAll(CompanyId))
                {
                    rep.Delete(team);
                }
            }
        }
        public void DeleteTestDivisions(CSBCDbContext context)
        {
            var repSeason = new SeasonRepository(context);
            var season = repSeason.GetCurrentSeason(CompanyId);
            if (season != null)
            {
                var rep = new DivisionRepository(context);
                var divisions = rep.GetDivisions(season.SeasonID).ToList<Division>();
                foreach (Division division in divisions)
                {
                    rep.Delete(division);
                }
            }
        }
        public void DeleteTestSeasons()
        {
            using (var db = new CSBCDbContext())
            {
                var repSeason = new SeasonRepository(db);
                foreach (Season season in repSeason.GetAll(CompanyId).ToList())
                {
                    repSeason.Delete(season);
                }
            }
        }



    }
}
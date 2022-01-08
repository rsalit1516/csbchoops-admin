using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CSBC.Core.Models;
using CSBC.Core.Data;
using CSBC.Core.Interfaces;


namespace CSBC.Core.Repositories
{
    public class PlayerRepository : EFRepository<Player>, IPlayerRepository
    {

        public PlayerRepository(DbContext context) : base(context) { }

        #region IRepository<T> Members

        public IQueryable<Player> SearchFor(Expression<Func<Player, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<Player> GetAll()
        {
            return DbSet;
        }

        public Player GetById(int id)
        {
            return Context.Set<Player>().Find(id);
        }

        #endregion IRepository<T> Members

        //public Player Insert(Player entity)
        //{
        //    if (String.IsNullOrEmpty(entity.DraftID))
        //    {
        //        var draftId = GetNextDraftId((int)entity.CompanyID, (int)entity.SeasonID, (int)entity.DivisionID);
        //        entity.DraftID = draftId;
        //    }
        //    if (entity.PlayerID == 0)
        //    {
        //        entity.PlayerID = DataContext.Set<Player>().Any() ? (DataContext.Set<Player>().Max(p => p.PlayerID) + 1) : 1;
        //    }
        //    DataContext.Set<Player>().Add(entity);
        //    var no = DataContext.SaveChanges();
        //    SetDivision((int)entity.SeasonID, entity.PeopleID, (int)entity.CompanyID);
        //    return entity;
        //}

        public string GetNextDraftId(int companyId, int seasonId, int divisionId)
        {
            var count = Context.Set<Player>().Count(p => p.CompanyID == companyId && p.SeasonID == seasonId && p.DivisionID == divisionId);
            count = count + 1;
            return (count.ToString().PadLeft(3, '0'));
        }

            public int FindPlayerByLastName(int companyId, int seasonId, string lastName)
        {
            int id = 0;
            //need join to get
            //var player = DataContext.Set<Player>().FirstOrDefault(n => n..LastName == name);
            //id = player.PeopleID;

            return id;
        }

        public IEnumerable<SeasonPlayer> GetSeasonPlayers(int seasonId)
        {
            var players = Context.Set<Player>()
                                .Where(p => p.SeasonID == seasonId)
                                .OrderBy(p => p.DraftID);
            var seasonPlayers = ConvertPlayersToSeasonPlayers(players);
            return seasonPlayers;
        }

        public IQueryable<SeasonPlayer> GetDivisionPlayers(int divisionId)
        {
            var teamPlayers = from p in Context.Set<Player>()
                              from d in Context.Set<Division>()
                              from person in Context.Set<Person>()
                              where p.DivisionID == divisionId
                              where p.DivisionID == d.DivisionID
                              where p.PeopleID == person.PeopleID
                              orderby p.DraftID
                              select  new
                                {
                                    p.PeopleID,
                                    p.PlayerID,
                                    p.DivisionID,
                                    p.DraftID,
                                    p.Sponsor,
                                    d.Div_Desc,
                                    p.Person.BirthDate,
                                    p.Person.LastName,
                                    p.Person.FirstName,
                                    p.DraftNotes,
                                    p.BalanceOwed,
                                    person.Household.Phone,
                                    person.Grade
                                };

            IQueryable<SeasonPlayer> vwSeasonPlayers = teamPlayers.Cast<SeasonPlayer>();

            var count = teamPlayers.Count();
            List<SeasonPlayer> vwSeason = new List<SeasonPlayer>();
            foreach (var player in teamPlayers)
            {
                var vwPlayer = new SeasonPlayer();
                vwPlayer.PeopleID = player.PeopleID;
                vwPlayer.FirstName = player.FirstName;
                vwPlayer.LastName = player.LastName;
                vwPlayer.Name = player.LastName + ", " + player.FirstName;
                vwPlayer.PlayerID = player.PlayerID;
                vwPlayer.DraftID = player.DraftID;
                vwPlayer.BirthDate = (DateTime)player.BirthDate;
                vwPlayer.Div_Desc = player.Div_Desc;
                vwPlayer.DraftNotes = player.DraftNotes;
                vwPlayer.Balance = (decimal)player.BalanceOwed;
                vwPlayer.Grade = (int)player.Grade;
                vwPlayer.Phone = player.Phone;
                vwSeason.Add(vwPlayer);
            }
            vwSeasonPlayers = vwSeason.AsQueryable<SeasonPlayer>();
            return vwSeasonPlayers;
        }

        public IQueryable<SeasonPlayer> GetTeamPlayers(int teamId)
        {
            var teamPlayers = Context.Set<Player>()
                                .Where(p => p.TeamID == teamId)
                                .OrderBy(p => p.DraftID)
                                .Select(p => new
                                {
                                    p.PeopleID,
                                    p.PlayerID,
                                    p.DivisionID,
                                    p.DraftID,
                                    p.Sponsor,
                                    p.Person.LastName,
                                    p.Person.FirstName
                                });

            IQueryable<SeasonPlayer> vwSeasonPlayers = teamPlayers.Cast<SeasonPlayer>();

            var count = teamPlayers.Count();
            List<SeasonPlayer> vwSeason = new List<SeasonPlayer>();
            foreach (var player in teamPlayers)
            {
                var vwPlayer = new SeasonPlayer();
                vwPlayer.PeopleID = player.PeopleID;
                vwPlayer.FirstName = player.FirstName;
                vwPlayer.LastName = player.LastName;
                vwPlayer.Name = player.LastName + ", " + player.FirstName;
                vwPlayer.PlayerID = player.PlayerID;
                vwPlayer.DraftID = player.DraftID;
                vwSeason.Add(vwPlayer);
            }
            vwSeasonPlayers = vwSeason.AsQueryable<SeasonPlayer>();
            return vwSeasonPlayers;
        }

        public IQueryable<UndraftedPlayer> GetUndrafterPlayers(int divisionId)
        {
            var undrafted = Context.Set<Player>()
                            .Where(p => p.DivisionID == divisionId)
                            .Where(p => p.TeamID == null || p.TeamID == 0)
                            .Select(p => new
                            {
                                p.PeopleID,
                                p.PlayerID,
                                p.DivisionID,
                                p.DraftID,
                                p.Sponsor,
                                p.Rating,
                                p.Person.LastName,
                                p.Person.FirstName
                            }).OrderBy(p => p.DraftID);
            IQueryable<UndraftedPlayer> vwUndraftedPlayers = undrafted.Cast<UndraftedPlayer>(); ;

            var count = undrafted.Count();
            List<UndraftedPlayer> vwUndrafted = new List<UndraftedPlayer>();
            foreach (var player in undrafted)
            {
                var vwPlayer = new UndraftedPlayer();
                vwPlayer.DivisionID = (int)player.DivisionID;
                vwPlayer.PeopleID = player.PeopleID;
                vwPlayer.FirstName = player.FirstName;
                vwPlayer.LastName = player.LastName;
                vwPlayer.Name = player.FirstName + " " + player.LastName;
                vwPlayer.Sponsor = player.Sponsor;
                vwPlayer.PlayerID = player.PlayerID;
                vwPlayer.DraftID = player.DraftID;
                vwPlayer.Rating = player.Rating;
                vwUndrafted.Add(vwPlayer);
            }
            vwUndraftedPlayers = vwUndrafted.AsQueryable<UndraftedPlayer>();
            return vwUndraftedPlayers;
        }

        public IQueryable<SeasonPlayer> GetPlayers(int seasonId)
        {
            var seasonPlayers = from p in Context.Set<Player>()
                                from e in Context.Set<Person>()
                                from d in Context.Set<Division>()
                                where p.PeopleID == e.PeopleID
                                where p.SeasonID == seasonId
                                where p.DivisionID == d.DivisionID
                                orderby e.LastName, e.FirstName
                                select new
                                {
                                    p.PlayerID,
                                    p.PeopleID,
                                    p.DivisionID,
                                    e.LastName,
                                    e.FirstName,
                                    d.Div_Desc,
                                    p.DraftID
                                };

            IQueryable<SeasonPlayer> vwSeasonPlayers = seasonPlayers.Cast<SeasonPlayer>();

            var count = seasonPlayers.Count();
            List<SeasonPlayer> vwSeason = new List<SeasonPlayer>();
            foreach (var player in seasonPlayers)
            {
                var vwPlayer = new SeasonPlayer();
                vwPlayer.DivisionID = (int)player.DivisionID;
                vwPlayer.PeopleID = player.PeopleID;
                vwPlayer.FirstName = player.FirstName;
                vwPlayer.LastName = player.LastName;
                vwPlayer.Name = player.LastName + ", " + player.FirstName;
                vwPlayer.PlayerID = player.PlayerID;
                vwPlayer.Div_Desc = player.Div_Desc;
                vwPlayer.DraftID = player.DraftID;
                vwSeason.Add(vwPlayer);
            }
            vwSeasonPlayers = vwSeason.AsQueryable<SeasonPlayer>();
            return vwSeasonPlayers;
        }

        public IQueryable<SeasonPlayer> GetPlayers(int seasonId, int coachId)
        {
            var seasonPlayers = from p in Context.Set<Player>()
                                from e in Context.Set <Person>()
                                where p.PeopleID == e.PeopleID
                                where p.SeasonID == seasonId
                                where p.CoachID == coachId
                                orderby e.LastName, e.FirstName
                                select new
                                {
                                    p.PlayerID,
                                    p.PeopleID,
                                    p.DivisionID,
                                    e.LastName,
                                    e.FirstName,
                                    p.DraftID
                                };

            IQueryable<SeasonPlayer> vwSeasonPlayers = seasonPlayers.Cast<SeasonPlayer>();

            var count = seasonPlayers.Count();
            var vwSeason = new List<SeasonPlayer>();
            foreach (var player in seasonPlayers)
            {
                var vwPlayer = new SeasonPlayer();
                vwPlayer.DivisionID = (int)player.DivisionID;
                vwPlayer.PeopleID = player.PeopleID;
                vwPlayer.FirstName = player.FirstName;
                vwPlayer.LastName = player.LastName;
                vwPlayer.Name = player.LastName + ", " + player.FirstName;
                vwPlayer.PlayerID = player.PlayerID;
                vwPlayer.DraftID = player.DraftID;
                vwSeason.Add(vwPlayer);
            }
            vwSeasonPlayers = vwSeason.AsQueryable<SeasonPlayer>();
            return vwSeasonPlayers;
        }

        public IQueryable<SeasonPlayer> GetSponsorPlayers(int seasonId, int sponsorId)
        {
            var sponsorPlayers = Context.Set<Player>().Where(p => p.SeasonID == seasonId && p.SponsorID == sponsorId).ToList();
            var count = sponsorPlayers.Count();

            var vwSeason = ConvertPlayersToSeasonPlayers(sponsorPlayers);
            IQueryable<SeasonPlayer> vwSeasonPlayers = vwSeason.AsQueryable<SeasonPlayer>();
            return vwSeasonPlayers;
        }

        public IQueryable<SeasonPlayer> GetCoachPlayers(int seasonId, int coachId)
        {
            var players = Context.Set<Player>()
                .Where(p => p.SeasonID == seasonId && p.Team.CoachID == coachId).ToList();
            var vwSeason = ConvertPlayersToSeasonPlayers(players);
            IQueryable<SeasonPlayer> vwSeasonPlayers = vwSeason.AsQueryable<SeasonPlayer>();
            return vwSeasonPlayers;
        }

        private static IEnumerable<SeasonPlayer> ConvertPlayersToSeasonPlayers(IEnumerable<Player> players)
        {
            var vwSeason = new List<SeasonPlayer>();
            foreach (var player in players)
            {
                var vwPlayer = new SeasonPlayer();
                if (player.DivisionID.HasValue)
                    vwPlayer.DivisionID = (int)player.DivisionID;
                if (player.Division != null)
                    vwPlayer.Div_Desc = player.Division.Div_Desc;
                vwPlayer.PeopleID = player.PeopleID;
                vwPlayer.PlayerID = player.PlayerID;
                vwPlayer.DraftID = player.DraftID;

                if (player.Person != null)
                {
                    GetPersonInfo(ref vwPlayer, player);
                    if (player.Person.Household != null)
                    {
                        GetHouseholdInfo(player, ref vwPlayer);
                    }
                }
                vwSeason.Add(vwPlayer);
            }
            return vwSeason;
        }

        private static void GetHouseholdInfo(Player player, ref SeasonPlayer vwPlayer)
        {
            var house = player.Person.Household;
            vwPlayer.Address1 = house.Address1;
            vwPlayer.City = house.City;
            vwPlayer.State = house.State;
            vwPlayer.ZipCode = house.Zip;
        }

        private static void GetPersonInfo(ref SeasonPlayer vwPlayer, Player player)
        {
            vwPlayer.FirstName = player.Person.FirstName;
            vwPlayer.LastName = player.Person.LastName;
            vwPlayer.Name = player.Person.LastName + ", " + player.Person.FirstName;
            if (player.Person.BirthDate.HasValue)
                vwPlayer.BirthDate = (DateTime) player.Person.BirthDate;
        }

        public override void Update(Player player)
        {
            var playerold = GetById(player.PlayerID);
            if (playerold != null)
            {
                Context.Entry(playerold).CurrentValues.SetValues(player);
                Context.SaveChanges();
                SetDivision((int)player.SeasonID, player.PeopleID, (int)player.CompanyID);
            }
        }

        public void SetDivision(int seasonId, int personId, int companyId)
        {
            var sql = "Exec sp_SetDivision @iSeason = " +
                      seasonId.ToString() + ", @iPeopleID = " +
                      personId.ToString() + ", @iCompanyID = " + companyId.ToString();
            Context.Database.ExecuteSqlCommand(sql);
        }

        /*public int FindByEmail(string email)
        {
            int id  = 0;
            var Player = DataContext.People.FirstOrDefault(n => n.Email == email);
            if (Player != null)
                id = Player.PeopleID;
            return (id);
        }
        */

     

        public bool DeleteById(int id)
        {
            bool tflag = false;

            var player = Context.Set<Player>().Find(id);
            if (player != null)
            {
                Context.Set<Player>().Remove(player);
                Context.SaveChanges();
                tflag = true;
            }
            return tflag;
        }

        public Player GetByPeopleId(int peopleId)
        {
            var player = new Player();
            var players = Context.Set<Player>().Where(p => p.PeopleID == peopleId);
            if (players.Any())
            {
                var playerId = players.Max(p => p.PlayerID);
                player = GetById(playerId);
            }
            return player;
        }
        public bool WasPlayer(int peopleId)
        {
            var players = Context.Set<Player>().Where(p => p.PeopleID == peopleId);
            return players.Any();
        }

        public Player GetLastSeasonPlayed(int peopleId)
        {
            int? lastSeasonId = Context.Set<Player>().Where(s => s.PeopleID == peopleId).Max(p => p.SeasonID);
            if (lastSeasonId != null)
                return Context.Set<Player>().Find(lastSeasonId);
            else
                return new Player();
        }

        public Player GetPlayerByPersonAndSeasonId(int peopleId, int seasonId)
        {
            var player = Context.Set<Player>().FirstOrDefault(p => p.SeasonID == seasonId && p.PeopleID == peopleId);
            return player;
        }

        public IQueryable<Player> PlayerHistory(int personId)
        {
            var players = Context.Set<Player>().Where(p => p.PeopleID == personId);
            return players;
        }
        public List<PlayerHistory> GetPlayerHistory(int peopleId)
        {
            using (var db = new CSBCDbContext())
            {
                var viewPlayers = new List<PlayerHistory>();
                if (peopleId != 0)
                {
                    var players =
                        db.Set<Player>().Where(p => p.PeopleID == peopleId).OrderByDescending(p => p.Season.FromDate).ToList();

                    foreach (var player in players)
                    {
                        var viewPlayer = new PlayerHistory();
                        viewPlayer.SeasonID = (player.SeasonID == null ? 0 : (int)player.SeasonID);
                        if (player.Season != null)
                            viewPlayer.Season = player.Season.Description;
                        if (player.Team != null)
                            viewPlayer.Team = player.Team.TeamName;
                        viewPlayer.Rating = player.Rating;
                        if ((player.Team != null) && (player.Team.Coach != null) && (player.Team.Coach.Person != null))
                            viewPlayer.Coach = player.Team.Coach.Person.LastName;
                        viewPlayer.BalanceOwed = player.BalanceOwed;
                        viewPlayers.Add(viewPlayer);
                    }
                }
                return viewPlayers;
            }
        }

        public static string ConvertRating(int rating)
        {
            string srating = String.Empty;
            switch (rating)
            {
                case 0:
                    srating = String.Empty;
                    break;
                case 1:
                    srating = "1";
                    break;
                case 2:
                    srating = "1/2";
                    break;

                case 3:
                    srating = "2";
                    break;
                case 4:
                    srating = "2/3";
                    break;
                case 5:
                    srating = "3";
                    break;
                case 6:
                    srating = "3/4";
                    break;
                case 7:
                    srating = "4";
                    break;
                case 8:
                    srating = "4/5";
                    break;
                case 9:
                    srating = "5";
                    break;
                case 10:
                    srating = "5/6";
                    break;
                case 11:
                    srating = "6";
                    break;
                case 12:
                    srating = "6/7";
                    break;
                case 13:
                    srating = "7";
                    break;
                case 14:
                    srating = "7/8";
                    break;
                case 15:
                    srating = "8";
                    break;
                case 16:
                    srating = "C/R";
                    break;
            }
            return srating;
        }
    }
}
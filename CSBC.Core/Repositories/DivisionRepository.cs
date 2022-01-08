using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CSBC.Core.Data;
using CSBC.Core.Repositories;
using CSBC.Core.Interfaces;
using CSBC.Core.Models;

namespace CSBC.Core.Repositories
{
    public class DivisionRepository : EFRepository<Division>, IDivisionRepository
    {

        public DivisionRepository(DbContext context) : base(context) { }

        //public override Division Insert(Division entity)
        //{
        //    entity = DataContext.Set<Division>().Add(entity);

        //    return entity;
        //}

        public IQueryable<vw_Divisions> LoadDivisions(int seasonId)
        {
            try
            {

                var divisions = from d in Context.Set<Division>()
                                where d.SeasonID == seasonId
                                orderby d.Gender descending, d.MinDate descending
                                select new
                                {
                                    d.DivisionID,
                                    d.Div_Desc,
                                    d.Gender,
                                    d.MinDate,
                                    d.MaxDate,
                                    d.Gender2,
                                    d.MinDate2,
                                    d.MaxDate2,
                                    d.DraftVenue,
                                    d.DraftDate,
                                    d.DraftTime,
                                    d.DirectorID,
                                };
                IQueryable<vw_Divisions> vwDiv = divisions.Cast<vw_Divisions>(); ;

                var count = divisions.Count();
                var repTeam = new TeamRepository(Context);
                List<vw_Divisions> vwDivisions = new List<vw_Divisions>();
                foreach (var division in divisions)
                {
                    var div = new vw_Divisions();
                    div.DivisionID = division.DivisionID;
                    div.Div_Desc = division.Div_Desc;
                    div.Gender = division.Gender;
                    div.MinDate = division.MinDate;
                    div.MaxDate = division.MaxDate;
                    div.Gender2 = division.Gender2;
                    div.MinDate2 = division.MinDate2;
                    div.MaxDate2 = division.MaxDate2;
                    div.DraftVenue = division.DraftVenue;
                    div.DraftDate = division.DraftDate;
                    div.DraftTime = division.DraftTime;
                    div.DirectorID = division.DirectorID;
                    vwDivisions.Add(div);
                }

                vwDiv = vwDivisions.AsQueryable<vw_Divisions>();
                return vwDiv;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsDivisions:LoadDivision::" + ex.Message);
            }
        }

        public IQueryable<Division> GetAD(int seasonID, int peopleId)
        {
            return Context.Set<Division>().Where(d => d.SeasonID == seasonID && d.DirectorID == peopleId);
        }

        public IQueryable<Division> GetDivisions(int seasonId)
        {
            var divisions = Context.Set<Division>().Where(h => h.SeasonID == seasonId).OrderByDescending(d => d.MinDate);
            return divisions;
        }



        //public int GetPlayerDivision(int companyId, int seasonId, int peopleId)
        //{
        //    int retval = 0;
        //    var db = new CSBCDbContext();
        //    var cn = new SqlConnection(db.CSDBConnectionString);
        //    var sSQL = "exec GetDivision ";
        //        sSQL += " @iSeason = " + seasonId.ToString();
        //        sSQL += ", @iPeopleID = " + peopleId.ToString();
        //    var myAdapter = new SqlDataAdapter(sSQL, cn);
        //    var dtResults = new DataTable();
        //    try
        //    {
        //        cn.Open();
        //        myAdapter.Fill(dtResults);
        //        myAdapter.Dispose();

        //        var row = dtResults.Rows[0];
        //        var item = row.ItemArray[0];
        //        retval = Convert.ToInt32(item);
        //    }
        //    catch
        //    {
        //        retval = 0;
        //    }
        //    finally
        //    {
        //        dtResults.Dispose();
        //        cn.Close();
        //    }
        //    return retval;
        //}
        public int GetPlayerDivision(int companyId, int seasonId, int peopleId)
        {
            var personRepo = new PersonRepository(Context);
            var person = personRepo.GetById(peopleId);
            var seasonDivisions = GetDivisions(seasonId);
            var division = seasonDivisions
                .FirstOrDefault(GetPlayerDivisionPredicate(person, (DateTime)person.BirthDate));

            var playerRepo = new PlayerRepository(Context);
            var player = playerRepo.GetPlayerByPersonAndSeasonId(peopleId, seasonId);
            if (player != null && (bool)player.PlaysDown)
            {
                var divisionDown = seasonDivisions
                                .FirstOrDefault(GetPlayerDivisionPredicate(person, (DateTime)person.BirthDate.Value.AddYears(1)));
                if (divisionDown == division)
                {
                    divisionDown = seasonDivisions
                                .FirstOrDefault(GetPlayerDivisionPredicate(person, (DateTime)person.BirthDate.Value.AddYears(2)));
                }
                if (divisionDown != null)
                    division = divisionDown;
            }

            if (person.GiftedLevelsUP == 1)
            {
                var divisionUp = seasonDivisions
                               .FirstOrDefault(GetPlayerDivisionPredicate(person, (DateTime)person.BirthDate.Value.AddYears(-1)));
                if (divisionUp == division && person.Gender == "F")
                {
                    divisionUp = seasonDivisions
                                .FirstOrDefault(GetPlayerDivisionPredicate(person, (DateTime)person.BirthDate.Value.AddYears(-2)));
                }
                if (divisionUp != null)
                    division = divisionUp;
            }
            return division.DivisionID;
        }

        private static Expression<Func<Division, bool>> GetPlayerDivisionPredicate(Person person, DateTime birthDate)
        {
            return d => (d.Gender == person.Gender && (d.MinDate <= birthDate && d.MaxDate >= birthDate))
                            || (d.Gender2 == person.Gender && (d.MinDate <= birthDate && d.MaxDate >= birthDate));
        }
    }
}

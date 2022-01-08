using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;
using CSBC.Core.Models;
//using CSBC.Components;
using System.Configuration;

namespace CSBC.Core.Repositories
{
    public class TeamRepository : EFRepository<Team>, ITeamRepository
    {

        public TeamRepository(DbContext context) : base(context) { }

        #region IRepository<T> Members

        public override Team Insert(Team entity)
        {
            int no = 0;
            //entity.TeamID = DataContext.Set<Team>().Any() ? DataContext.Set<Team>().Max(t => t.TeamID) + 1 : 1;
            Context.Set<Team>().Add(entity);
            no = Context.SaveChanges();
            no = entity.TeamID;


            return entity;
        }


        public IQueryable<Team> GetAll(int companyId)
        {
            return Context.Set<Team>().Where(t => t.CompanyID == companyId);
        }


        #endregion


        public IQueryable<Team> GetTeams(int divisionId)
        {
            var teams = Context.Set<Team>().Where(s => s.DivisionID == divisionId);
            return teams;
        }
        public int GetNumberofDivisionTeams(int divisionId)
        {
            return Context.Set<Team>().Where(t => t.DivisionID == divisionId).Count();
        }


        public bool DeleteById(int id)
        {
            bool tflag = false;

            var team = Context.Set<Team>().Find(id);
            if (team != null)
            {
                Context.Set<Team>().Remove(team);
                Context.SaveChanges();
                tflag = true;
            }
            return tflag;
        }

        public IQueryable<Team> GetSeasonTeams(int seasonId)
        {
            var teams = from s in Context.Set<Team>()
                        where s.SeasonID == seasonId
                        select s;
            return teams;
        }

        public IQueryable<Team> GetDivisionTeams(int divisionId)
        {
            var teams = from s in Context.Set<Team>()
                        where s.DivisionID == divisionId
                        select s;
            return teams;
        }
    }
}


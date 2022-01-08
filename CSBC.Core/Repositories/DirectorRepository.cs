using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;
using CSBC.Core.Models;

namespace CSBC.Core.Repositories
{
    public class DirectorRepository : EFRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(CSBCDbContext context) : base(context) { }

        public override Director Insert(Director entity)
        {
            if (entity.ID == 0)
            {
                entity.ID = Context.Set<Director>().Any() ? (Context.Set<Director>().Max(p => p.ID) + 1) : 1; 
            }
            if ((entity.Seq == null) || (entity.Seq == 0))
            {
                entity.Seq = Context.Set<Director>().Any() ? (Context.Set<Director>().Max(c => c.Seq) + 1) : 1;
            }

            Context.Set<Director>().Add(entity);
            var no = Context.SaveChanges();
            return entity;
        }

        public IQueryable<vw_Directors> GetAll(int companyId)
        {
            var directors =
                from p in Context.Set<Person>()
                from d in Context.Set<Director>()
                from h in Context.Set<Household>()
                where p.PeopleID == d.PeopleID
                where p.HouseID == h.HouseID
                where d.CompanyID == companyId
                select new
                {
                    d.ID,
                    d.Title,
                    p.FirstName,
                    p.LastName,
                    h.Phone,
                    p.Workphone,
                    p.Cellphone,
                    p.Email,
                    h.Address1,
                    h.City,
                    h.State,
                    h.Zip,
                    p.CompanyID

                };
            List<vw_Directors> vwDirectors = new List<vw_Directors>();
            foreach (var director in directors)
            {
                var dir = new vw_Directors();
                dir.ID = director.ID;
                dir.Title = director.Title;
                dir.Name = director.FirstName + " " + director.LastName;
                dir.Phone = director.Phone;
                dir.WorkPhone = director.Workphone;
                dir.CellPhone = director.Cellphone;
                dir.Email = director.Email;
                dir.Address1 = director.Address1;
                dir.City = director.City;
                dir.State = director.State;
                dir.Zip = director.Zip;
                dir.CompanyID = (int)director.CompanyID;

                vwDirectors.Add(dir);
            }

            var vwDir = vwDirectors.AsQueryable<vw_Directors>();
            return vwDir;
        }

        public List<vw_Directors> GetDirectorVolunteers(int companyId)
        {
            var directors = from p in Context.Set<Person>()
                            where p.BoardOfficer == true || p.BoardMember == true
                            orderby p.LastName, p.FirstName
                            select new
                            {
                                p.PeopleID,
                                p.LastName,
                                p.FirstName
                            };

            var count = directors.Count();
            List<vw_Directors> vwDirectors = new List<vw_Directors>();
            foreach (var person in directors)
            {
                var vwDirector = new vw_Directors();

                vwDirector.PeopleID = person.PeopleID;
                vwDirector.Name = person.LastName + ", " + person.FirstName;

                vwDirectors.Add(vwDirector);

            }
            return vwDirectors;
        }
    }
}

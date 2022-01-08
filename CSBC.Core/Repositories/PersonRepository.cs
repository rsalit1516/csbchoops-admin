﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;
using CSBC.Core.Models;
using System.Configuration;


namespace CSBC.Core.Repositories
{
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        //protected CSBCDbContext DataContext { get; set; }
        //protected DbSet<Person> DbSet;

        public PersonRepository(DbContext context) : base(context) {}

        #region IRepository<T> Members

        public IQueryable<Person> SearchFor(Expression<Func<Person, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public List<Person> GetAll(int companyId)
        {
            var people = Context.Set<Person>().Where<Person>(p => p.CompanyID == companyId).ToList<Person>();
            return people;
        }
        public List<Person> GetPlayers(int companyId)
        {
            var people = Context.Set<Person>().Where<Person>(p => p.CompanyID == companyId && p.Player == true).ToList<Person>();
            return people;
        }


        #endregion

        public Person Insert(Person entity)
        {
            if (entity.PeopleID == 0)
            {
                //entity.PeopleID = DataContext.People.Any() ? (DataContext.People.Max(p => p.PeopleID) + 1) : 1;
            }
            Context.Set<Person>().Add(entity);
            var no = Context.SaveChanges();
            no = entity.PeopleID;
            return entity;
        }
        public void Update(Person entity)
        {
            try
            {
                var person = GetById(entity.PeopleID);
                person = entity;
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                { }
                throw;
            }
        }

        public bool CanDelete(int personId)
        {
            var playerRep = new PlayerRepository(Context);
            var wasPlayer = playerRep.WasPlayer(personId);
            return !wasPlayer; //can't delete if person has a plyer record
        }
        public void Delete(Person entity)
        {
            if (CanDelete(entity.PeopleID))
                Context.Set<Person>().Remove(entity);
        }


        IQueryable<Person> IRepository<Person>.GetAll()
        {
            throw new NotImplementedException();
        }

        Person IRepository<Person>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public int FindPersonByLastName(string name)
        {
            int id = 0;
            var person = Context.Set<Person>().FirstOrDefault(n => n.LastName == name);
            id = person.PeopleID;

            return id;
        }
        public Person FindPersonByLastAndFirstName(string lastName, string firstName)
        {
            var person = Context.Set<Person>().FirstOrDefault(n => n.LastName == lastName && n.FirstName == firstName);
            return person;
        }
        public IQueryable<Person> FindPeopleByLastAndFirstName(string lastName, string firstName, bool playerOnly)
        {
            IQueryable<Person> person = null;
            if (!String.IsNullOrEmpty(lastName) && (!String.IsNullOrEmpty(firstName)))
            {
                person = Context.Set<Person>().Where(n => n.LastName.StartsWith(lastName) && n.FirstName.StartsWith(firstName));
            }
            else if (!String.IsNullOrEmpty(lastName) && (String.IsNullOrEmpty(firstName)))
            {
                person = Context.Set<Person>().Where(n => n.LastName.StartsWith(lastName));
            }
            if (String.IsNullOrEmpty(lastName) && (!String.IsNullOrEmpty(firstName)))
            {
                person = Context.Set<Person>().Where(n => n.FirstName.StartsWith(firstName));
            }
            if (person != null)
            {
                if (playerOnly)
                {
                    return person.Where(p => p.Player == true).OrderBy(p => p.LastName).ThenBy(e => e.FirstName);
                }
                else
                {
                    return person.OrderBy(p => p.LastName).ThenBy(e => e.FirstName);
                }

            }
            else
            {
                return person;
            }
        }

        public int FindByEmail(string email)
        {
            int id = 0;
            var person = Context.Set<Person>().FirstOrDefault(n => n.Email == email);
            if (person != null)
                id = person.PeopleID;
            return (id);
        }

        public IQueryable<Person> GetByGroup(int companyId, int seasonId, GroupTypes.GroupType group)
        {
            var people = Context.Set<Person>()
                .Where(p => p.CompanyID == companyId);
            switch (group)
            {
                case GroupTypes.GroupType.BoardMember:
                    people = people.Where(p => p.BoardMember == true);
                    break;
                case GroupTypes.GroupType.CoachesSponsors:
                    people = people.Where(p => p.Coach == true || p.Sponsor == true);
                    break;
                case GroupTypes.GroupType.SeasonPlayers:
                    people = people
                        .Join(Context.Set<Player>(), p => p.PeopleID, l => l.PeopleID, (p, l) => new { p, l })
                        .Where(x => x.l.SeasonID == seasonId)
                        .Select(x => x.p) ;
                    break;
                default :
                    break;
            }
            return people;
        }

        
        public int GetBccList( string lastName, string firstName)
        {
            int id = 0;
            //Get test community
            //List<Person> people = context.People.Select.First(n => n.LastName == lastName && n.FirstName == firstName);
            //id = person.PersonID;
            return id;
        }

        public bool DeleteById(int id)
        {
            bool tflag = false;

            var person = Context.Set<Person>().Find(id);
            if (person != null)
            {
                Context.Set<Person>().Remove(person);
                Context.SaveChanges();
                tflag = true;
            }
            return tflag;
        }

        //public List<Person> GetBoardMembers(int companyId)
        //{
        //    return new List<Person>();
        //}

        public IQueryable<Person> GetADs(int companyId)
        {
            var people = Context.Set<Person>().Where(p => p.CompanyID == companyId)
                                .Where(p => p.AD == true);
            return people;
        }

        public void RemoveFromHousehold(int p)
        {
            var person = Context.Set<Person>().Find(p);
            person.HouseID = 0;
            Context.SaveChanges();

        }

        public IQueryable<Person> GetByHousehold(int houseId)
        {
            return Context.Set<Person>().Where(p => p.HouseID == houseId);
        }

        public List<string> GetParents(int personId)
        {
            var child = Context.Set<Person>().Find(personId);
            var parents = Context.Set<Person>()
                            .Where(p => p.HouseID == (child.HouseID) && (p.Parent == true))
                            .Select(person => person.LastName + ", " + person.FirstName).ToList();
            return parents;
            
        }


    }
}
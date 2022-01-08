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

namespace CSBC.Core.Models
{
    public class RoleRepository : IRepository<Role>
    {

        protected CSBCDbContext DataContext { get; set; }
        protected DbSet<Role> DbSet;

        public RoleRepository(CSBCDbContext dataContext)
        {
            DataContext = dataContext;
            //DbSet = dataContext.IDbSet<Role>();
        }

        #region IRepository<T> Members


        public void Delete(Role entity)
        {
            DataContext.Roles.Remove(entity);
            DataContext.SaveChanges();
        }

        public IQueryable<Role> SearchFor(Expression<Func<Role, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<Role> GetAll()
        {
            return DataContext.Roles.Select(s => s);
        }

        public Role GetById(decimal id)
        {
            return DataContext.Roles.Find(id);
        }

        #endregion

        public Role Insert(Role entity)
        {
            if (entity.RoleId == 0)
            {
                entity.RoleId = DataContext.Roles.Any() ? (DataContext.Roles.Max(p => p.RoleId) + 1) : 1;
            }
            entity.CreatedDate = DateTime.Now;
            DataContext.Roles.Add(entity);
            var no = DataContext.SaveChanges();
            return entity;
        }

        void IRepository<Role>.Delete(Role entity)
        {
            throw new NotImplementedException();
        }


        IQueryable<Role> IRepository<Role>.GetAll()
        {
            throw new NotImplementedException();
        }

        Role IRepository<Role>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public decimal Create(Role Role)
        {
            if (Role.RoleId == 0)
            {
                Role.RoleId = DataContext.Roles.Any() ? DataContext.Roles.Max(c => c.RoleId) + 1 : 1;
            }
            Role newRole = DataContext.Roles.Add(Role);
            DataContext.SaveChanges();
            return newRole.RoleId;

        }

        public IQueryable<Role> GetRoles(int userId)
        {
            var roles = DataContext.Roles.Where(r => r.UserID == (decimal)userId);        
            return roles;

        }
        public bool DeleteById(int id)
        {
            bool tflag = false;

            var Role = DataContext.Roles.Find(id);
            if (Role != null)
            {
                DataContext.Roles.Remove(Role);
                DataContext.SaveChanges();
                tflag = true;
            }
            return tflag;
        }
        public void Update(Role Role)
        {
            var old = GetById(Convert.ToDecimal(Role.RoleId));
            old = Role;
            DataContext.SaveChanges();
        
        }

        public void DeleteUserRole(decimal p, string screenName)
        {
            var role = DataContext.Roles.FirstOrDefault(r => r.UserID == p && r.ScreenName == screenName);
            if (role != null)
            {
                DataContext.Roles.Remove(role);
                DataContext.SaveChanges();
            }
        }
        public void AddUserRole(decimal userId, string screenName, string userName)
        {
            var existingRole = DataContext.Roles.FirstOrDefault(r => r.UserID == userId && r.ScreenName == screenName);
            if (existingRole == null)
            {
                var role = new Role();
                role.UserID = userId;
                role.AccessType = "U";
                role.ScreenName = screenName.ToUpper();
                role.CreatedUser = userName;
                Insert(role);
                DataContext.SaveChanges();
            }
        }
    }
}


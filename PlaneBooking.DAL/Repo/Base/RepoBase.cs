using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.DAL.EF;
using PlaneBooking.Models.Entities.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PlaneBooking.DAL.Repo.Base
{
    public abstract class RepoBase<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        #region Member Variables
        protected readonly PlaneBookingDbContext _Context;
        protected DbSet<T> _Table;
        #endregion

        #region Constructor
        protected RepoBase()
        {
            _Context = new PlaneBookingDbContext();
            _Table = _Context.Set<T>();
        }

        protected RepoBase(DbContextOptions<PlaneBookingDbContext> options)
        {
            _Context = new PlaneBookingDbContext(options);
            _Table = _Context.Set<T>();
        }
        #endregion

        #region Methods
        public int Add(T entity, bool persist = true)
        {
            _Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }

        public int Delete(int? id, bool persist = true)
        {
            var entry = _Table.Find(id);
            _Table.Remove(entry);
            return persist ? SaveChanges() : 0;
        }

        public virtual T Find(int? id)
        {
            return _Table.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _Table;
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public int Update(T entity, bool persist = true)
        {
            _Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
        #endregion
    }
}

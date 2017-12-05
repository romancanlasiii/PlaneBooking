using System.Linq;
using PlaneBooking.Models.Entities.Base;

namespace PlaneBooking.DAL.Repo.Base
{
    public interface IRepo<T> where T : EntityBase
    {
        T Find(int? id);

        IQueryable<T> GetAll();

        int Add(T entity, bool persist = true);

        int Update(T entity, bool persist = true);

        int Delete(int? id, bool persist = true);

        int SaveChanges();
    }
}

using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.DAL.EF;
using PlaneBooking.DAL.Repo.Base;
using PlaneBooking.DAL.Repo.Interfaces;
using PlaneBooking.Models.Entities;

namespace PlaneBooking.DAL.Repo
{
    public class PlaneRepo : RepoBase<Plane>, IPlaneRepo
    {
        #region Constructor
        public PlaneRepo(DbContextOptions<PlaneBookingDbContext> options)
            : base(options)
        {
            _Table = _Context.Planes;
        }

        public PlaneRepo() 
            : base()
        {
            _Table = _Context.Planes;
        }
        #endregion

        #region Methods
        public override IQueryable<Plane> GetAll()
        {
            return _Table.Include(t => t.Airport).OrderBy(t => t.BodyNo);
        }

        public override Plane Find(int? id)
        {
            return _Table.Include(t => t.Airport).SingleOrDefault(m => m.Id == id);
        }
        #endregion
    }
}

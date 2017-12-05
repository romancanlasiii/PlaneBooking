using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.DAL.EF;
using PlaneBooking.DAL.Repo.Base;
using PlaneBooking.DAL.Repo.Interfaces;
using PlaneBooking.Models.Entities;

namespace PlaneBooking.DAL.Repo
{
    public class TutorRepo : RepoBase<Tutor>, ITutorRepo
    {
        #region Constructor
        public TutorRepo(DbContextOptions<PlaneBookingDbContext> options)
            : base(options)
        {
            _Table = _Context.Tutors;
        }

        public TutorRepo() 
            : base()
        {
            _Table = _Context.Tutors;
        }
        #endregion

        #region Methods
        public override IQueryable<Tutor> GetAll()
        {
            return _Table.Include(t => t.Airport).OrderBy(t => t.FullName);
        }

        public override Tutor Find(int? id)
        {
            return _Table.Include(t => t.Airport).SingleOrDefault(m => m.Id == id);
        }
        #endregion
    }
}

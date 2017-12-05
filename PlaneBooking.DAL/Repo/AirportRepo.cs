using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.DAL.EF;
using PlaneBooking.DAL.Repo.Base;
using PlaneBooking.DAL.Repo.Interfaces;
using PlaneBooking.Models.Entities;


namespace PlaneBooking.DAL.Repo
{
    public class AirportRepo : RepoBase<Airport>, IAirportRepo
    {
        #region Constructor
        public AirportRepo(DbContextOptions<PlaneBookingDbContext> options)
            : base(options)
        {
            _Table = _Context.Airports;
        }

        public AirportRepo() 
            : base()
        {
            _Table = _Context.Airports;
        }
        #endregion

        #region Methods
        public override IQueryable<Airport> GetAll()
        {
            return _Table.Include(t => t.City).OrderBy(t => t.Name);
        }

        public override Airport Find(int? id)
        {
            return _Table.Include(t => t.City).SingleOrDefault(m => m.Id == id);
        }
        #endregion
    }
}

using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.DAL.EF;
using PlaneBooking.DAL.Repo.Base;
using PlaneBooking.DAL.Repo.Interfaces;
using PlaneBooking.Models.Entities;

namespace PlaneBooking.DAL.Repo
{
    public class CityRepo : RepoBase<City>, ICityRepo
    {
		#region Constructor
		public CityRepo(DbContextOptions<PlaneBookingDbContext> options)
			: base(options)
		{
			_Table = _Context.Cities;
		}

		public CityRepo()
			: base()
		{
			_Table = _Context.Cities;
		}
		#endregion

		#region Methods
		public override IQueryable<City> GetAll()
		{
			return _Table.OrderBy(a => a.Name);
		}
		#endregion
	}
}

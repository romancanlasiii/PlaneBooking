using AutoMapper;
using PlaneBooking.DAL.Repo;
using PlaneBooking.DAL.Repo.Interfaces;
using PlaneBooking.Models.Entities;
using PlaneBooking.Models.Views;
using PlaneBooking.WebService.Services.Base;
using PlaneBooking.WebService.Services.Interface;

namespace PlaneBooking.WebService.Services
{
    public class CityService : CrudServiceBase<City, CityView, ICityRepo>, ICityService
	{
        public CityService(ICityRepo repo, IMapper mapper)
            : base(repo, mapper)
        {
        }
    }
}

using PlaneBooking.DAL.Repo.Interfaces;
using PlaneBooking.Models.Entities;
using PlaneBooking.Models.Views;
using PlaneBooking.WebService.Services.Base;

namespace PlaneBooking.WebService.Services.Interface
{
    public interface IAirportService : ICrudServiceBase<Airport, AirportView, IAirportRepo>
	{
    }
}

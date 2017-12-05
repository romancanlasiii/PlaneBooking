using AutoMapper;
using PlaneBooking.Models.Entities;
using PlaneBooking.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneBooking.WebService.Automapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CityView, City>();
            CreateMap<City, CityView>();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaneBooking.DAL.Repo.Base;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Models.Response;
using PlaneBooking.WebService.Services.Base;
using PlaneBooking.Models.Entities.Base;
using AutoMapper;

namespace PlaneBooking.WebService.Controllers.Base
{
    public abstract class BaseController : Controller
	{
       
	}
}
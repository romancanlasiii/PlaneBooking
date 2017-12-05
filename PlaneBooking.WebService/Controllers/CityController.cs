using Microsoft.AspNetCore.Mvc;
using PlaneBooking.WebService.Controllers.Base;
using PlaneBooking.WebService.Services.Interface;

namespace PlaneBooking.WebService.Controllers
{
    [Route("api/city")]
    public class CityController : BaseController
	{
		#region Member Variables
		private ICityService _Service { get; set; }
		#endregion

		#region Constructor
		public CityController(ICityService service)
		{
			_Service = service;
		}
		#endregion

		#region Methods
		[HttpGet]
        public IActionResult Get()
        {
			var resp = _Service.ReadAll();
			return Ok(resp);
		}

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var resp = _Service.Read(id);
			return Ok(resp);
		}
        #endregion
    }
}
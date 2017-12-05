using Microsoft.AspNetCore.Mvc;
using PlaneBooking.Models.Views;
using PlaneBooking.WebService.Controllers.Base;
using PlaneBooking.WebService.Services.Interface;

namespace PlaneBooking.WebService.Controllers
{
    [Route("api/airport")]
    public class AirportController : BaseController
	{
        #region Member Variables
        private IAirportService _Service { get; set; }
        #endregion

        #region Constructor
        public AirportController(IAirportService service)
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

        [HttpPost]
        public IActionResult Post([FromBody] AirportView item)
        {
            if (item == null || !ModelState.IsValid)
                return BadRequest();

			var resp = _Service.Create(item);
			return Ok(resp);
		}

        [HttpPut]
        public IActionResult Put([FromBody] AirportView item)
        {
            if (item == null || !ModelState.IsValid)
                return BadRequest();

			var resp = _Service.Update(item);
			return Ok(resp);
		}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			var resp = _Service.Delete(id);
			return Ok(resp);
		}
        #endregion
    }
}
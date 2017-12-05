using Microsoft.AspNetCore.Mvc;

using PlaneBooking.Models.Views;
using PlaneBooking.WebService.Controllers.Base;
using PlaneBooking.WebService.Services.Interface;

namespace PlaneBooking.WebService.Controllers
{
    [Route("api/plane")]
    public class PlaneController : BaseController
	{
		#region Member Variables
		private IPlaneService _Service { get; set; }
		#endregion

		#region Constructor
		public PlaneController(IPlaneService service)
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
        public IActionResult Post([FromBody] PlaneView item)
        {
			if (item == null || !ModelState.IsValid)
				return BadRequest();

			var resp = _Service.Create(item);
			return Ok(resp);
		}

        [HttpPut]
        public IActionResult Put([FromBody] PlaneView item)
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
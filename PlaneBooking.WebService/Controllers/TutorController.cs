using Microsoft.AspNetCore.Mvc;

using PlaneBooking.Models.Views;
using PlaneBooking.WebService.Controllers.Base;
using PlaneBooking.WebService.Services.Interface;

namespace PlaneBooking.WebService.Controllers
{
    [Route("api/tutor")]
    public class TutorController : BaseController
	{
		#region Member Variables
		private ITutorService _Service { get; set; }
		#endregion

		#region Constructor
		public TutorController(ITutorService service)
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
        public IActionResult Post([FromBody] TutorView item)
        {
			if (item == null || !ModelState.IsValid)
				return BadRequest();

			var resp = _Service.Create(item);
			return Ok(resp);
		}

        [HttpPut]
        public IActionResult Put([FromBody] TutorView item)
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
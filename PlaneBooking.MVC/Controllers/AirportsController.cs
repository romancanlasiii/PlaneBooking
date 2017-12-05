using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using PlaneBooking.Models.Entities;
using PlaneBooking.MVC.Configuration;
using PlaneBooking.MVC.Controllers.Base;
using PlaneBooking.Http;

namespace PlaneBooking.MVC.Controllers
{
    [Authorize]
    public class AirportsController : BaseController
    {
        #region Constructor
		public AirportsController () 
			: base ()
		{
		}

		public AirportsController(IHttpHandler httpHandler, IWebServiceLocator webServiceLocator)
			: base (httpHandler, webServiceLocator)
        {
        }
        #endregion

        #region Methods
        // GET: Airports
        public IActionResult Index()
        {
			var resp =  _GetAll<List<Airport>>(WebApiType.Airport);
            return View(resp);
        }

        // GET: Airports/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

			var resp = _Get<Airport>(WebApiType.Airport, id);
			if (resp == null)
                return NotFound();

            return View(resp);
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
			var resp = _GetAll<List<City>>(WebApiType.City);
            ViewData["CityId"] = new SelectList(resp, "Id", "Name");
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,CityId,IsForceClose,Id")] Airport airport)
        {
            if(ModelState.IsValid)
            {
				var resp = _Create<Airport, StatusCodeResult>(WebApiType.Airport, airport);
				return RedirectToAction(nameof(Index));
            }

			var cityResp = _GetAll<List<City>>(WebApiType.City);
			ViewData["CityId"] = new SelectList(cityResp, "Id", "Name", airport.CityId);
            return View(airport);
        }

        // GET: Airports/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            _InitAirportHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.GetJson<Airport>(query);
            if (resp == null)
                return NotFound();

            _InitCityHttpUrl();
            var cityResp = _HttpHandler.GetJson<List<Airport>>(string.Empty);

            ViewData["CityId"] = new SelectList(cityResp, "Id", "Name", resp.CityId);
            return View(resp);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,CityId,IsForceClose,Id,DateCreated,DateModified,CreatedBy,ModifiedBy,TimeStamp")] Airport airport)
        {
            if (id != airport.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _InitAirportHttpUrl();
                var resp = _HttpHandler.PutJson<Airport, StatusCodeResult>(airport);
                return RedirectToAction(nameof(Index));
            }

            _InitAirportHttpUrl();
            var cityResp = _HttpHandler.GetJson<List<City>>(string.Empty);

            ViewData["CityId"] = new SelectList(cityResp, "Id", "Name", airport.CityId);
            return View(airport);
        }

        // GET: Airports/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            _InitAirportHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.GetJson<Airport>(query);
            if (resp == null)
                return NotFound();

            return View(resp);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _InitAirportHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.DeleteJson<StatusCodeResult>(query);
            return RedirectToAction(nameof(Index));
        }
    }
    #endregion
}

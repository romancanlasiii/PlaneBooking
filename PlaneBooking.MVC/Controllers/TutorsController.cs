using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using PlaneBooking.Models.Entities;
using PlaneBooking.MVC.Configuration;
using PlaneBooking.Http;
using PlaneBooking.MVC.Controllers.Base;

namespace PlaneBooking.MVC.Controllers
{
    [Authorize]
    public class TutorsController : BaseController
	{
		#region Constructor
		public TutorsController() 
			: base ()
		{
		}

		public TutorsController(IHttpHandler httpHandler, IWebServiceLocator webServiceLocator)
			: base (httpHandler, webServiceLocator)
        {
		}
		#endregion

		#region Methods
		// GET: Tutors
		public IActionResult Index()
        {
            _InitTutorHttpUrl();
            var resp = _HttpHandler.GetJson<List<Tutor>>(string.Empty);
            return View(resp);
        }

        // GET: Tutors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            _InitTutorHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.GetJson<Tutor>(query);
            if (resp == null)
                return NotFound();

            return View(resp);
        }

        // GET: Tutors/Create
        public IActionResult Create()
        {
            _InitAirportHttpUrl();
            var resp = _HttpHandler.GetJson<List<Airport>>(string.Empty);
            ViewData["AirportId"] = new SelectList(resp, "Id", "Name");
            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FullName,LicenseNo,AirportId,Id")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                _InitTutorHttpUrl();
                var resp = _HttpHandler.PostJson<Tutor, StatusCodeResult>(tutor);
                return RedirectToAction(nameof(Index));
            }

            _InitAirportHttpUrl();
            var airportResp = _HttpHandler.GetJson<List<Airport>>(string.Empty);
            ViewData["AirportId"] = new SelectList(airportResp, "Id", "Name", tutor.AirportId);
            return View(tutor);
        }

        // GET: Tutors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            _InitTutorHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.GetJson<Tutor>(query);
            if (resp == null)
                return NotFound();

            _InitAirportHttpUrl();
            var airportResp = _HttpHandler.GetJson<List<Airport>>(string.Empty);

            ViewData["AirportId"] = new SelectList(airportResp, "Id", "Name", resp.AirportId);
            return View(resp);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FullName,LicenseNo,AirportId,Id,DateCreated,DateModified,CreatedBy,ModifiedBy,TimeStamp")] Tutor tutor)
        {
            if (id != tutor.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _InitTutorHttpUrl();
                var resp = _HttpHandler.PutJson<Tutor, StatusCodeResult>(tutor);
                return RedirectToAction(nameof(Index));
            }

            _InitAirportHttpUrl();
            var airportResp = _HttpHandler.GetJson<List<Airport>>(string.Empty);

            ViewData["AirportId"] = new SelectList(airportResp, "Id", "Name", tutor.AirportId);
            return View(tutor);
        }

        // GET: Tutors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            _InitTutorHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.GetJson<Tutor>(query);
            if (resp == null)
                return NotFound();

            return View(resp);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _InitTutorHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.DeleteJson<StatusCodeResult>(query);
            return RedirectToAction(nameof(Index));
        }

        private void _InitTutorHttpUrl ()
        {
            _HttpHandler.InitHttpUrl(
               _WebServiceLocator.ServiceHost,
               _WebServiceLocator.ServicePort,
               _WebServiceLocator.ServiceTutorsPath);
        }

        private void _InitAirportHttpUrl()
        {
            _HttpHandler.InitHttpUrl(
               _WebServiceLocator.ServiceHost,
               _WebServiceLocator.ServicePort,
               _WebServiceLocator.ServiceAirportPath);
        }
        #endregion
    }
}

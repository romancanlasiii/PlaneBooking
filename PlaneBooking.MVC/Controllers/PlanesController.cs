using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using PlaneBooking.Models.Entities;
using PlaneBooking.MVC.Configuration;
using PlaneBooking.Http;

namespace PlaneBooking.MVC.Controllers
{
    [Authorize]
    public class PlanesController : Controller
    {
        #region Member Variables
        private readonly IHttpHandler _HttpHandler;
        private readonly IWebServiceLocator _WebServiceLocator;
        #endregion

        #region Constructor
        public PlanesController(IHttpHandler httpHandler, IWebServiceLocator webServiceLocator)
        {
            _HttpHandler = httpHandler;
            _WebServiceLocator = webServiceLocator;
        }
        #endregion

        #region Methods
        // GET: Planes
        public IActionResult Index()
        {
            _InitPlaneHttpUrl();
            var resp = _HttpHandler.GetJson<List<Plane>>(string.Empty);
            return View(resp);
        }

        // GET: Planes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            _InitPlaneHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.GetJson<Plane>(query);
            if (resp == null)
                return NotFound();

            return View(resp);
        }

        // GET: Planes/Create
        public IActionResult Create()
        {
            _InitAirportHttpUrl();
            var resp = _HttpHandler.GetJson<List<Airport>>(string.Empty);
            ViewData["AirportId"] = new SelectList(resp, "Id", "Name");
            return View();
        }

        // POST: Planes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BodyNo,Model,AirportId,Id")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                _InitPlaneHttpUrl();
                var resp = _HttpHandler.PostJson<Plane, StatusCodeResult>(plane);
                return RedirectToAction(nameof(Index));
            }

            _InitAirportHttpUrl();
            var airportResp = _HttpHandler.GetJson<List<Airport>>(string.Empty);
            ViewData["AirportId"] = new SelectList(airportResp, "Id", "Name", plane.AirportId);
            return View(plane);
        }

        // GET: Planes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            _InitPlaneHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.GetJson<Plane>(query);
            if (resp == null)
                return NotFound();

            _InitAirportHttpUrl();
            var airportResp = _HttpHandler.GetJson<List<Airport>>(string.Empty);

            ViewData["AirportId"] = new SelectList(airportResp, "Id", "Name", resp.AirportId);
            return View(resp);
        }

        // POST: Planes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BodyNo,Model,AirportId,Id,DateCreated,DateModified,CreatedBy,ModifiedBy,TimeStamp")] Plane plane)
        {
            if (id != plane.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _InitPlaneHttpUrl();
                var resp = _HttpHandler.PutJson<Plane, StatusCodeResult>(plane);
                return RedirectToAction(nameof(Index));
            }

            _InitAirportHttpUrl();
            var airportResp = _HttpHandler.GetJson<List<Airport>>(string.Empty);

            ViewData["AirportId"] = new SelectList(airportResp, "Id", "Name", plane.AirportId);
            return View(plane);
        }

        // GET: Planes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            _InitPlaneHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.GetJson<Plane>(query);
            if (resp == null)
                return NotFound();

            return View(resp);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _InitPlaneHttpUrl();
            var query = $"/{id}";
            var resp = _HttpHandler.DeleteJson<StatusCodeResult>(query);
            return RedirectToAction(nameof(Index));
        }

        private void _InitPlaneHttpUrl()
        {
            _HttpHandler.InitHttpUrl(
               _WebServiceLocator.ServiceHost,
               _WebServiceLocator.ServicePort,
               _WebServiceLocator.ServicePlanePath);
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

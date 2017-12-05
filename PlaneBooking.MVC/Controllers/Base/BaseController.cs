using Microsoft.AspNetCore.Mvc;
using PlaneBooking.Http;
using PlaneBooking.MVC.Configuration;

namespace PlaneBooking.MVC.Controllers.Base
{
    public abstract class BaseController : Controller
	{
		#region Constants
		protected enum WebApiType
		{
			City,
			Airport,
			Plane,
			Tutor
		}
		#endregion

		#region Member Variables
		protected readonly IHttpHandler _HttpHandler;
		protected readonly IWebServiceLocator _WebServiceLocator;
		#endregion

		#region Constructor
		public BaseController ()
		{
		}

		public BaseController(IHttpHandler httpHandler, IWebServiceLocator webServiceLocator)
        {
            _HttpHandler = httpHandler;
            _WebServiceLocator = webServiceLocator;
        }
		#endregion

		#region Methods
		#region HTTP Actions
		protected TResponse _Get<TResponse>(WebApiType type, int? id)
		{
			_Init(type);
			var query = $"/{id}";
			var resp = _HttpHandler.GetJson<TResponse>(query);
			return resp;
		}

		protected TResponse _GetAll<TResponse>(WebApiType type)
		{
			_Init(type);
			var resp = _HttpHandler.GetJson<TResponse>(string.Empty);
			return resp;
		}

		protected TResponse _Create<TRequest, TResponse>(WebApiType type, TRequest request)
		{
			_Init(type);
			var resp = _HttpHandler.PostJson<TRequest, TResponse>(request);
			return resp;
		}

		protected TResponse _Update<TRequest, TResponse>(WebApiType type, TRequest request)
		{
			_Init(type);
			var resp = _HttpHandler.PutJson<TRequest, TResponse>(request);
			return resp;
		}

		protected TResponse _Delete<TResponse>(WebApiType type, int id)
		{
			_Init(type);
			var query = $"/{id}";
			var resp = _HttpHandler.DeleteJson<TResponse>(query);
			return resp;
		}
		#endregion

		#region Http Initializer
		protected void _Init(WebApiType type)
		{
			switch (type)
			{
				case WebApiType.City:
					_InitCityHttpUrl();
					break;
				case WebApiType.Airport:
					_InitAirportHttpUrl();
					break;
				case WebApiType.Plane:
					_InitPlaneHttpUrl();
					break;
				case WebApiType.Tutor:
					_InitTutorHttpUrl();
					break;
				default:
					break;
			}
		}

		protected void _InitCityHttpUrl()
		{
			_HttpHandler.InitHttpUrl(
			   _WebServiceLocator.ServiceHost,
			   _WebServiceLocator.ServicePort,
			   _WebServiceLocator.ServiceCityPath);
		}

		protected void _InitAirportHttpUrl()
		{
			_HttpHandler.InitHttpUrl(
			   _WebServiceLocator.ServiceHost,
			   _WebServiceLocator.ServicePort,
			   _WebServiceLocator.ServiceAirportPath);
		}

		protected void _InitPlaneHttpUrl()
		{
			_HttpHandler.InitHttpUrl(
			   _WebServiceLocator.ServiceHost,
			   _WebServiceLocator.ServicePort,
			   _WebServiceLocator.ServicePlanePath);
		}

		protected void _InitTutorHttpUrl()
		{
			_HttpHandler.InitHttpUrl(
			   _WebServiceLocator.ServiceHost,
			   _WebServiceLocator.ServicePort,
			   _WebServiceLocator.ServiceTutorsPath);
		}
		#endregion
		#endregion
	}
}

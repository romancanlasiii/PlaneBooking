using Microsoft.Extensions.Configuration;

namespace PlaneBooking.MVC.Configuration
{
    public class WebServiceLocator : IWebServiceLocator
    {
        public WebServiceLocator(IConfigurationRoot config)
        {
            var customSection = config.GetSection(nameof(WebServiceLocator));
            ServiceHost = customSection?.GetSection(nameof(ServiceHost))?.Value;
            ServiceCityPath = customSection?.GetSection(nameof(ServiceCityPath))?.Value;
            ServiceAirportPath = customSection?.GetSection(nameof(ServiceAirportPath))?.Value;
            ServicePlanePath = customSection?.GetSection(nameof(ServicePlanePath))?.Value;
            ServiceTutorsPath = customSection?.GetSection(nameof(ServiceTutorsPath))?.Value;

            int.TryParse(customSection?.GetSection(nameof(ServicePort))?.Value, out int port);
            ServicePort = port;
        }

        public string ServiceHost { get; }

        public int ServicePort { get; }

        public string ServiceCityPath { get; }

        public string ServiceAirportPath { get; }

        public string ServicePlanePath { get; }

        public string ServiceTutorsPath { get; }
    }
}

namespace PlaneBooking.MVC.Configuration
{
    public interface IWebServiceLocator
    {
        string ServiceHost { get; }

        int ServicePort { get; }

        string ServiceCityPath { get; }

        string ServiceAirportPath { get; }

        string ServicePlanePath { get; }

        string ServiceTutorsPath { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using PlaneBooking.Models.Entities;

namespace PlaneBooking.DAL.Initializers
{
    public static class SampleData
    {
        public static IEnumerable<City> GetCities()
        {
            return new List<City>
            {
                new City {Name= "New York"},
                new City {Name= "Los Angeles"},
            };
        }

        public static IEnumerable<Airport> GetAirports()
        {
            return new List<Airport>
            {
                new Airport {CityId = 1, Name = "John F. Kennedy International Airport", IsForceClose = false},
                new Airport {CityId = 1, Name = "LaGuardia Airport", IsForceClose = false},
                new Airport {CityId = 2, Name = "Apple Valley Airport", IsForceClose = false},
                new Airport {CityId = 2, Name = "El Monte Airport", IsForceClose = false},
            };
        }

        public static IEnumerable<Plane> GetPlanes()
        {
            return new List<Plane>
            {
                new Plane {AirportId = 1, BodyNo= "CSS1-A1", Model = "Cessna A-37 Dragonfly"},
                new Plane {AirportId = 1, BodyNo= "CSS2-A1", Model = "Cessna 140 Light utility aircraft"},
                new Plane {AirportId = 1, BodyNo= "CSS3-A1", Model = "Cessna 150 Multipurpose civil aircraft"},
                new Plane {AirportId = 1, BodyNo= "CSS4-A1", Model = "Cessna 152 Multipurpose civil aircraft"},
                new Plane {AirportId = 1, BodyNo= "CSS5-A1", Model = "Cessna 165 High Wing Single Engine"},
                new Plane {AirportId = 1, BodyNo= "CSS6-A1", Model = "Cessna 170 Light Personal Aircraft"},
                new Plane {AirportId = 1, BodyNo= "CSS7-A1", Model = "Cessna 172 Civil utility aircraft"},
                new Plane {AirportId = 1, BodyNo= "CSS1-A2", Model = "Cessna A-37 Dragonfly"},
                new Plane {AirportId = 2, BodyNo= "CSS2-A2", Model = "Cessna 140 Light utility aircraft"},
                new Plane {AirportId = 2, BodyNo= "CSS3-A2", Model = "Cessna 150 Multipurpose civil aircraft"},
                new Plane {AirportId = 2, BodyNo= "CSS4-A2", Model = "Cessna 152 Multipurpose civil aircraft"},
                new Plane {AirportId = 2, BodyNo= "CSS5-A2", Model = "Cessna 165 High Wing Single Engine"},
                new Plane {AirportId = 2, BodyNo= "CSS6-A2", Model = "Cessna 170 Light Personal Aircraft"},
                new Plane {AirportId = 2, BodyNo= "CSS7-A2", Model = "Cessna 172 Civil utility aircraft"},
                new Plane {AirportId = 3, BodyNo= "CSS1-A3", Model = "Cessna A-37 Dragonfly"},
                new Plane {AirportId = 3, BodyNo= "CSS2-A3", Model = "Cessna 140 Light utility aircraft"},
                new Plane {AirportId = 3, BodyNo= "CSS3-A3", Model = "Cessna 150 Multipurpose civil aircraft"},
                new Plane {AirportId = 3, BodyNo= "CSS4-A3", Model = "Cessna 152 Multipurpose civil aircraft"},
                new Plane {AirportId = 3, BodyNo= "CSS5-A3", Model = "Cessna 165 High Wing Single Engine"},
                new Plane {AirportId = 3, BodyNo= "CSS6-A3", Model = "Cessna 170 Light Personal Aircraft"},
                new Plane {AirportId = 3, BodyNo= "CSS7-A3", Model = "Cessna 172 Civil utility aircraft"},
                new Plane {AirportId = 4, BodyNo= "CSS1-A4", Model = "Cessna A-37 Dragonfly"},
                new Plane {AirportId = 4, BodyNo= "CSS2-A4", Model = "Cessna 140 Light utility aircraft"},
                new Plane {AirportId = 4, BodyNo= "CSS3-A4", Model = "Cessna 150 Multipurpose civil aircraft"},
                new Plane {AirportId = 4, BodyNo= "CSS4-A4", Model = "Cessna 152 Multipurpose civil aircraft"},
                new Plane {AirportId = 4, BodyNo= "CSS5-A4", Model = "Cessna 165 High Wing Single Engine"},
                new Plane {AirportId = 4, BodyNo= "CSS6-A4", Model = "Cessna 170 Light Personal Aircraft"},
                new Plane {AirportId = 4, BodyNo= "CSS7-A4", Model = "Cessna 172 Civil utility aircraft"},
            };
        }

        public static IEnumerable<Tutor> GetTutors()
        {
            return new List<Tutor>
            {
                new Tutor {AirportId = 1, FullName = "John I. Blackwell", LicenseNo = "JBL000001"},
                new Tutor {AirportId = 1, FullName = "Andrew E. Alberts", LicenseNo = "AA000001"},
                new Tutor {AirportId = 2, FullName = "Ryan G. Hebert", LicenseNo = "RH000001"},
                new Tutor {AirportId = 3, FullName = "Jimmie R. Davis", LicenseNo = "JD000001"},
                new Tutor {AirportId = 4, FullName = "Kenneth I. Wike", LicenseNo = "KW000001"},
            };
        }
    }
}

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlaneBooking.DAL.EF;

namespace PlaneBooking.DAL.Initializers
{
    public class DataInitializer
    {
        private static string[] _Tables = new[] {"Airports","Planes", "Tutors", "Cities"};

        public static void InitializeData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<PlaneBookingDbContext>();
            InitializeData(context);
        }
        public static void InitializeData(PlaneBookingDbContext context)
        {
            ClearData(context);
            SeedData(context);
        }
        public static void ClearData(PlaneBookingDbContext context)
        {
            foreach (var itm in _Tables)
            {
                ExecuteDeleteSQL(context, itm);
                ResetIdentity(context, itm);
            }
        }

        public static void ExecuteDeleteSQL(PlaneBookingDbContext context, string tableName)
        {
            try
            {
                context.Database.ExecuteSqlCommand($"Delete from PlaneBooking.{tableName}");
            }
            catch { }
        }

        public static void ResetIdentity(PlaneBookingDbContext context, string tableName)
        {
            try
            {
                context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"PlaneBooking.{tableName}\", RESEED, 0);");
            }
            catch { }
        }

        public static void SeedData(PlaneBookingDbContext context)
        {
            try
            {
                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(SampleData.GetCities());
                    context.SaveChanges();
                }

                if (!context.Airports.Any())
                {
                    context.Airports.AddRange(SampleData.GetAirports());
                    context.SaveChanges();
                }

                if (!context.Planes.Any())
                {
                    context.Planes.AddRange(SampleData.GetPlanes());
                    context.SaveChanges();
                }

                if (!context.Tutors.Any())
                {
                    context.Tutors.AddRange(SampleData.GetTutors());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}


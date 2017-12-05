using System;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Models.Entities;

namespace PlaneBooking.DAL.EF
{
    public class PlaneBookingDbContext : DbContext
    {
        public PlaneBookingDbContext()
        {
        }

        public PlaneBookingDbContext(DbContextOptions options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=PlaneBookingDb;
                    Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<Plane> Planes { get; set; }

        public DbSet<Tutor> Tutors { get; set; }

        public DbSet<City> Cities { get; set; }
    }
}

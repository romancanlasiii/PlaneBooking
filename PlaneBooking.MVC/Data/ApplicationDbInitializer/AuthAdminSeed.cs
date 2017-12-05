using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PlaneBooking.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneBooking.MVC.Data.ApplicationDbInitializer
{
    public class AuthAdminSeed
    {
        private ApplicationDbContext _context;

        public AuthAdminSeed(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void SeedAdminUser()
        {
            var user = new ApplicationUser
            {
                UserName = "admin@planebooking.test",
                NormalizedUserName = "admin@planebooking.test",
                Email = "admin@planebooking.test",
                NormalizedEmail = "admin@planebooking.test",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "admin00");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

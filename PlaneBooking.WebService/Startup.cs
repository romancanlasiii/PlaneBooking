using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.DAL.EF;
using PlaneBooking.DAL.Repo.Interfaces;
using PlaneBooking.DAL.Repo;
using PlaneBooking.DAL.Initializers;
using PlaneBooking.WebService.Filters;
using PlaneBooking.WebService.Services.Interface;
using PlaneBooking.WebService.Services;
using AutoMapper;

namespace PlaneBooking.WebService
{
    public class Startup
    {
        private IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            _env = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(config =>
                config.Filters.Add(new PlaneBookingExceptionFilter(_env.IsDevelopment())))
                .AddJsonFormatters(j =>
                {
                    j.ContractResolver = new DefaultContractResolver();
                    j.Formatting = Formatting.Indented;
                });

            services.AddAutoMapper();

            /// In order for the result not to be truncated
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                });
            });
           
            /// Initialize Database
            services.AddDbContext<PlaneBookingDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("PlaneBooking")));

            /// Initialize Repos
            services.AddScoped<IAirportRepo, AirportRepo>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<IPlaneRepo, PlaneRepo>();
            services.AddScoped<ITutorRepo, TutorRepo>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPlaneService, PlaneService>();
            services.AddScoped<ITutorService, TutorService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
            }

            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    DataInitializer.InitializeData(app.ApplicationServices);
                }
            }

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
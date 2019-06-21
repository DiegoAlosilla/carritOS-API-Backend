using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace carritOSCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnections")));

            services.AddIdentity<AplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            if (!context.BusinessOwners.Any())
            {
                context.BusinessOwners.AddRange(new List<BusinessOwner>()
                {
                    new BusinessOwner()
                    {

                        FirstName = "Diego",
                        LastName = "Alosilla",
                        Dni ="12345678",
                        Email = "deigoalosilla@gmail.com",
                        Movil = "966450252",
                        Password = "1234",
                        City = "Lima",
                        Country = "Peru"
                     },

                    new BusinessOwner()
                    {

                        FirstName = "Giannela",
                        LastName = "Peramas",
                        Dni ="12345678",
                        Email = "deigoalosilla@gmail.com",
                        Movil = "966450252",
                        Password = "1234",
                        City = "Lima",
                        Country = "Peru"
                     }
                });
                context.SaveChanges();
            }


        }
    }
}

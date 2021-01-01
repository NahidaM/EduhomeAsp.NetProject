using HomeEduBackendFinal.DAL;
using HomeEduBackendFinal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEduBackendFinal
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
            services.AddControllersWithViews();
            services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
            {
                identityOptions.Password.RequiredLength = 5;
                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireUppercase = true;
                identityOptions.Password.RequireDigit = true;

                identityOptions.User.RequireUniqueEmail = true;

                identityOptions.Lockout.MaxFailedAccessAttempts = 3; 
                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                identityOptions.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders()/*.AddErrorDescriber<IdentityErrosDescriptionAz>()*/;
           
            //services.AddScoped<IEmailService, EmailService>();
            //services.AddAutoMapper(typeof(MappingProfiles));
            services.AddMvc();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString:Default"]);
            }); 
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles(); 
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "areas",
                    "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}"
                    );
            }); 
        }
    }
}

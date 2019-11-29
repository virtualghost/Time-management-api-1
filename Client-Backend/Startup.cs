using Client_Backend.DataAccess;
<<<<<<< HEAD
=======
using Client_Backend.Helpers;
>>>>>>> 21b1790532b6a17463b00a9800e0534eef52960d
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
<<<<<<< HEAD
using Microsoft.AspNetCore.Identity;
using System;
=======
>>>>>>> 21b1790532b6a17463b00a9800e0534eef52960d

namespace Client_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            ConfigureServicesDependency(services);
<<<<<<< HEAD
            services.AddAuthorization();
            
            //get local database ConnectionString from AppSettings
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.EnableEndpointRouting = false;
            });
=======
            
            
            //get local database ConnectionString from AppSettings
            
>>>>>>> 21b1790532b6a17463b00a9800e0534eef52960d

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddSignInManager()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            //Add automapper
<<<<<<< HEAD
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

=======
            
>>>>>>> 21b1790532b6a17463b00a9800e0534eef52960d
        }

        private void ConfigureServicesDependency(IServiceCollection services)
        {
            
        }

<<<<<<< HEAD
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
=======
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ILoggerFactory loggerFactory)
>>>>>>> 21b1790532b6a17463b00a9800e0534eef52960d
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
<<<<<<< HEAD

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

=======

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            
>>>>>>> 21b1790532b6a17463b00a9800e0534eef52960d
        }
    }
}

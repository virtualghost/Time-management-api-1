using AutoMapper;
using Client_Backend.DataAccess;
using Client_Backend.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            //get local database ConnectionString from AppSettings
            services.AddDbContext<PlayerDbContext>(options => options.UseSqlServer(Configuration["ConnectionString:Develop"]));

            //Add automapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        private void ConfigureServicesDependency(IServiceCollection services)
        {
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                
            }            

            app.UseMvc();
        }
    }
}

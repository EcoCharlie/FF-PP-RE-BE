using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PiensaPeruAPIWeb.Domain.Repositories;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Domain.Repositories.Posts;
using PiensaPeruAPIWeb.Domain.Repositories.Users;
using PiensaPeruAPIWeb.Domain.Services.Contents;
using PiensaPeruAPIWeb.Domain.Services.Posts;
using PiensaPeruAPIWeb.Domain.Services.Users;
using PiensaPeruAPIWeb.Persistence.Contexts;
using PiensaPeruAPIWeb.Persistence.Repositories;
using PiensaPeruAPIWeb.Persistence.Repositories.Contents;
using PiensaPeruAPIWeb.Persistence.Repositories.Posts;
using PiensaPeruAPIWeb.Persistence.Repositories.Users;
using PiensaPeruAPIWeb.Services.Contents;
using PiensaPeruAPIWeb.Services.Posts;
using PiensaPeruAPIWeb.Services.Users;

namespace PiensaPeruAPIWeb
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

            services.AddControllers();

            services.AddRouting(option => option.LowercaseUrls = true);

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseInMemoryDatabase("PiensaPeru-API");
            });
            
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PiensaPeruAPIWeb", Version = "v1" });
            });
            //Global
            services.AddScoped<IUnitOfWork, UnitOfWork>(); 
            
            //Scoped of Content Bounded
            
            //MilitantType
            services.AddScoped<IMilitantTypeService, MilitantTypeService>();
            services.AddScoped<IMilitantTypeRepository, MilitantTypeRepository>();
            
            //Period
            services.AddScoped<IPeriodService,PeriodService>();
            services.AddScoped<IPeriodRepository, PeriodRepository>();
            
            //PoliticalParty
            services.AddScoped<IPoliticalPartyService, PoliticalPartyService>();
            services.AddScoped<IPoliticalPartyRepository, PoliticalPartyRepository>();
            
            //Scoped of User Bounded
            
            //User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            //Plan
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            
            //UserPlan
            services.AddScoped<IUserPlanService, UserPlanService>();
            services.AddScoped<IUserPlanRepository, UserPlanRepository>();
            
            //Mapper
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PiensaPeruAPIWeb v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    
}
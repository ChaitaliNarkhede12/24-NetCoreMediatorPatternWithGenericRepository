using ApplicationLayer.Interfaces;
using ApplicationLayer.Services;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WebAPIInventoryMgt.Handler.InventoryCommand;
using AutoMapper;

namespace WebAPIInventoryMgt
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

            var appSettingSections = Configuration.GetSection("JwtCongifuration");
            services.Configure<AppSettings>(appSettingSections);

            AppSettings appSettings = appSettingSections.Get<AppSettings>();

            var securityKey = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(securityKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            //Retrive connection string from appsettings.json
            services.AddDbContext<InventoryDBContext>(item => item.UseSqlServer
              (Configuration.GetConnectionString("InventoryDBConnection")));

            //Add Cors Policy
            services.AddCors(option => option.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                })
            );

            

            services.AddSwaggerGen();

            //services.AddMediatR(typeof(AddCountryCommandHandler));

            //services.AddMediatR(GetMediatrAssembliesToScan());

            //services.AddMediatR(Assembly.GetAssembly(typeof(AddCountryCommandHandler)));

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            //Inject Dependency Injection
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddTransient<IInventoryAppService, InventoryAppService>();
            services.AddTransient<ILoginAppService, LoginAppService>();

            //services.AddTransient(IMapper, Mapper);

            services.AddAutoMapper(Assembly.GetAssembly(typeof(InventoryModel)));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private Type[] GetMediatrAssembliesToScan()
        {
            var assemblies = Assembly.Load("WebAPIInventoryMgt")
                .GetTypes()
                .ToArray();

            return assemblies;
        }
    }
}

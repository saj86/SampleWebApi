using Application;
using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Contexts;
using Infrastructure.BusinessService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using WebApi.Extensions;
using AutoMapper;
using System;
using MediatR;
using System.Reflection;
using System.IO;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddControllersWithViews()
            .AddNewtonsoftJson();
            services.AddApplicationLayer();
            services.AddPersistenceInfrastructure(_config);
            services.AddSharedInfrastructure(_config);
            services.AddSwaggerExtension();
            services.AddSwaggerGen();
            services.AddControllers();  
            services.AddApiVersioningExtension();
            services.AddHealthChecks();
            //services.AddDbContext<DataBaseContext>(opt=>opt.UseInMemoryDatabase("booktest"));
           
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddOptions();
            

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));





        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
  
                app.UseHsts();
            }
            app.UseCors(builder => builder
            .AllowAnyOrigin()
             .AllowAnyMethod()
           .AllowAnyHeader()
          );
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();
            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });
        }
    }
}

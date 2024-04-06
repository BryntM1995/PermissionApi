using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PermissionManagement.Model.Context;
using PermissionManagement.Model.Entities;
using PermissionManagement.Repository;
using PermissionManagement.Service.DTOs;
using PermissionManagement.Service.FluentValidation;
using PermissionManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermissionManagement.Service.Mapper;
using Microsoft.OpenApi.Models;

namespace PermissionApi
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
            services.AddDbContext<PermissionContext>(options => options.
            UseSqlServer(Configuration.
            GetConnectionString("SQLServerString")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PermissionManagementCRUD", Version = "v1" });
            });
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<PermissionProfile>();
                x.AddProfile<PermissionTypeProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IBaseRepository<Permission>, PermissionRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IValidator<PermissionDto>, PermissionValidation>();

            services.AddScoped<IBaseRepository<PermissionType>, PermissionTypeRepository>();
            services.AddScoped<IBaseService<PermissionTypeDto>, BaseService<PermissionType, PermissionTypeDto>>();
            services.AddScoped<IValidator<PermissionTypeDto>, PermissionTypeValidation>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PermissionManagementCRUD v1"));
            }
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


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

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//Identity (DB)
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

// Uri Service
using Microsoft.AspNetCore.Http;

// Swagger
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

using AutoMapper;
using RealEstateAPI.Services;
using RealEstateAPI.Data;

namespace RealEstateAPI
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
            services.AddControllers();
            //CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
            // AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Setup JwtSettings
            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            // Setup Services
            services.AddScoped<IVGDataService, VGDataService>();
            services.AddScoped<IGNAFService, GNAFService>();
            services.AddSingleton<IUriService, UriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                return new UriService(absoluteUri);
            });

            // DB Setup
            services.AddDbContext<DataContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("WindowsConnection"))
            );

            services.AddDbContext<GNAFContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("GNAFConnection"))
            );

            services.AddDefaultIdentity<IdentityUser>()
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<DataContext>();

            // Swagger Setup
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RealEstateAPI",
                    Version = "1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Ensure DB Is Created
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                context.Database.EnsureCreated();
            };
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();

            // Swagger
            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(opt =>
            {
                opt.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint(swaggerOptions.EndPointRoute, swaggerOptions.Description);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

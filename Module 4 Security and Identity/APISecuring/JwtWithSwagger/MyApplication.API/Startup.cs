using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyApplication.API.Data;
using MyApplication.API.Domain;
using MyApplication.API.Installers;
using MyApplication.API.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MyApplication.API
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
            services.AddDbContext<MyAppDbContxt>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 8;

            }).AddEntityFrameworkStores<MyAppDbContxt>().AddDefaultTokenProviders();
            
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("V1", new OpenApiInfo { Title = "MyApplication", Version = "V1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description="This Appliction needs Authoiazion with Jwt Bearer",
                    Name = "Authorization",
                    In =  ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                   
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type =  ReferenceType.SecurityScheme
                            },
                           
                        }, new string[] { }
                    }
                });
            });
            services.AddControllers();
            services.InstallSecurity(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(options => {
                options.RouteTemplate = swaggerOptions.RouteTemplate;
            });
            app.UseSwaggerUI(options => {
                options.DocumentTitle = "MyApplcation";
                options.SwaggerEndpoint(swaggerOptions.UIEndPoint, swaggerOptions.Description);
                options.DocExpansion(DocExpansion.List);
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

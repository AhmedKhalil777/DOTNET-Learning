using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Graph.API.Installers;
using BookStore.Graph.API.Middlewares;
using BookStore.Graph.API.Schemas;
using BookStore.Graph.Database;
using BookStore.Graph.Database.DataSeeders;
using BookStore.Graph.Database.Domain;
using GraphiQl;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookStore.Graph.API
{
    public class Startup
    {
        public const string GraphQlPath = "/graphql";
        public const string CustomGraphQlPath = "/custom-path";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.InstallServicesInAssemblies(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, BookStoreDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions { GraphQLEndPoint = GraphQlPath, Path ="/GraphQL"});

            ////app.UseGraphQLWebSocket<BookStoreSchema>(new GraphQLWebSocketsOptions());
            ////app.UseGraphQLHttp<BookStoreSchema>(new GraphQLHttpOptions());
            //app.Map("/schema.graphql", config => config.UseMiddleware<SchemaMiddleware>());

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            userManager.SeedData(db);

    

        }
    }
}

using GraphiQl;
using GraphQL.Conventions;
using GraphQL.Conventions.Web;
using Newtonsoft.Json;
using GraphQL.Http;
using GraphQL.Introspection;
using GraphQL.Sample.API.Helpers;
using GraphQL.Sample.API.Mutations;
using GraphQL.Sample.API.Queries;
using GraphQL.Sample.API.Schemas;
using GraphQL.Sample.DataAccess.Repositories;
using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database;
using GraphQL.Sample.Database.DataSeed;
using GraphQL.Sample.Types;
using GraphQL.Sample.Types.Mutations;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;


namespace GraphQL.Sample.API
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

            services.AddMvc().AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
          
            services.AddDbContext<RealEstateDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:RealEstateDb"]));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
       
            services.AddScoped<PropertyQuery>();
            services.AddScoped<PropertyMutation>();
            services.AddScoped<PropertyInputType>();
            services.AddScoped<PropertyQueryType>();
            services.AddScoped<PaymentQueryType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RealEstateSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            // services.AddScoped<ISchema>(x =>new RealEstateSchema(new FuncDependencyResolver(x.GetRequiredService)));
            //services.AddScoped<Schema, RealEstateSchema>();
            //services.AddScoped<ISchema, Schema>();
            // add options configuration
            // services.AddSingleton<GraphiQlMiddleware>();

            services.Configure<GraphQLSettings>(Configuration.GetSection(nameof(GraphQLSettings)));
            services.Configure<GraphQLSettings>(settings => settings.BuildUserContext = ctx => new GraphQLUserContext { User = ctx.User });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,  RealEstateDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


           
            app.UseHttpsRedirection();
            app.UseGraphiQl("/GraphQL");
            db.EnsureDataSeeding();
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

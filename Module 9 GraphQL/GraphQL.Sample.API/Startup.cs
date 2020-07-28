using GraphiQl;
using GraphQL.Sample.API.Mutations;
using GraphQL.Sample.API.Queries;
using GraphQL.Sample.API.Schemas;
using GraphQL.Sample.DataAccess.Repositories;
using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database;
using GraphQL.Sample.Database.DataSeed;
using GraphQL.Sample.Types;
using GraphQL.Sample.Types.Mutations;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GraphQL.Sample.API
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
            
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddControllers();
            services.AddDbContext<RealEstateDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:RealEstateDb"]));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<PropertyQuery>();
            services.AddScoped<PropertyMutation>();
            services.AddScoped<PropertyInputType>();
            services.AddScoped<PropertyQueryType>();
            services.AddScoped<PaymentQueryType>();
            services.AddScoped<ISchema>(x =>new RealEstateSchema(new FuncDependencyResolver(x.GetRequiredService)));
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,  RealEstateDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl("/graphql");
            app.UseHttpsRedirection();

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

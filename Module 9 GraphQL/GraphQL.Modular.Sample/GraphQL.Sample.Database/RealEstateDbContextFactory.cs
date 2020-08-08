using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GraphQL.Sample.Database
{
    // To connect to database using Connection String
    class RealEstateDbContextFactory : IDesignTimeDbContextFactory<RealEstateDbContext>
    {
        public RealEstateDbContext CreateDbContext(string[] args)
        {
            // Get The Configurations 
            var configurations = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RealEstateDbContext>();
            var connectionString = configurations.GetConnectionString("RealEstateDb");
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("GraphQL.Sample.API"));

            return new RealEstateDbContext(builder.Options);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStore.Graph.Database
{
    public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
        public BookStoreDbContext CreateDbContext(string[] args)
        {
            var configurations = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BookStoreDbContext>();
            var connectionString = configurations.GetConnectionString("BookStoreDb");
            builder.UseSqlServer(connectionString , b => b.MigrationsAssembly("BookStore.Graph.API"));

            return new BookStoreDbContext(builder.Options);
        }
    }
}

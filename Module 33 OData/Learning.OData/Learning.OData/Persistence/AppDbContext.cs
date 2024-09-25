using Learning.OData.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.OData.Persistence
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=marketio.db;");
        }
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders  => Set<Order>();
        public DbSet<Catalog> Catalogs  => Set<Catalog>();
        public DbSet<Resource> Resources  => Set<Resource>();

    }
}

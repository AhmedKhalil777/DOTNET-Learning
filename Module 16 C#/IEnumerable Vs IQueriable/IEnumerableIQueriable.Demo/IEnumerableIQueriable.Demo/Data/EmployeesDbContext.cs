using IEnumerableIQueriable.Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEnumerableIQueriable.Demo.Data
{
    public class EmployeesDbContext  : DbContext
    {
        private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(config => config.AddConsole());
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options):
            base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString: "Data Source=DESKTOP-KVVKP5M\\AHMED;Initial Catalog=Employee;Trusted_Connection=True;MultipleActiveResultSets=true");
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "Mona",
                Salary = 7000,
                Department = "Mobile",
                BirthDay = DateTime.UtcNow
            },
            new Employee
            {
                Id =2 ,
                Name = "Ahmed",
                Salary = 50000,
                Department = "Web",
                BirthDay = DateTime.UtcNow
            },
            new Employee
            {
                Id = 3,
                Name = "Khalid",
                Salary = 50000,
                Department = "IOS",
                BirthDay = DateTime.UtcNow
            }); 
        }
    }
}

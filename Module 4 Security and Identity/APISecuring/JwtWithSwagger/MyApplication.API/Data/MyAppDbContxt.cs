using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApplication.API.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.API.Data
{
    public class MyAppDbContxt : IdentityDbContext<AppUser>
    {
        public MyAppDbContxt(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name =  "Admin",  Id = "1" , NormalizedName = "ADMIN" },
                new IdentityRole { Name =  "Customer",  Id = "2" , NormalizedName = "CUSTOMER" },
                new IdentityRole { Name =  "Moderator",  Id = "3" , NormalizedName = "MODERATOR" }
                
                );
        }

    }
}

using BookStore.Graph.Database.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.Graph.Database
{
    public class BookStoreDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole<Guid>>().HasData(new[]  {
                    new IdentityRole<Guid>{Id =  Guid.NewGuid() , Name ="Admin" , NormalizedName ="ADMIN" },
                    new IdentityRole<Guid>{Id =  Guid.NewGuid() , Name ="Author" , NormalizedName ="AUTHOR" },
                    new IdentityRole<Guid>{Id =  Guid.NewGuid(), Name ="Reader" , NormalizedName ="READER" },

                });
            //}
        }
    }
}

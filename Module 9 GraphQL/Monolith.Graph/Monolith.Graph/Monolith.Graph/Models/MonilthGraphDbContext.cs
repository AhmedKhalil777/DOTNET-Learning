using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.Graph.Models
{
    public class MonilthGraphDbContext : DbContext
    {
        public MonilthGraphDbContext(DbContextOptions<MonilthGraphDbContext> options):base(options){}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Post> Comments { get; set; }

    }
}

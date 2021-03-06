﻿using GraphQL.Sample.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sample.Database
{
    public class RealEstateDbContext: DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options )
            :base(options)
        {

        }
    }
}

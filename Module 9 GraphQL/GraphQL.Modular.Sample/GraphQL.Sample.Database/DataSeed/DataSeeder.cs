using GraphQL.Sample.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Sample.Database.DataSeed
{
    public static class DataSeeder
    {
        public static void EnsureDataSeeding(this RealEstateDbContext context)
        {
            if (!context.Properties.Any() || !context.Payments.Any())
            {

                var paymentsFaker = new Faker<Payment>()
                        .RuleFor(x => x.Value, x => x.Random.Decimal(min: 500, max: 10000))
                        .RuleFor(x => x.IssueDate, x => x.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now))
                        .RuleFor(x => x.OverDueDate, x => x.Date.Between(DateTime.Now.AddDays(1), DateTime.Now.AddYears(2)))
                        .RuleFor(x => x.IsPaid, x => x.Random.Bool());

                var properties = new Faker<Property>()
                          .RuleFor(x => x.Name, x => x.Address.FullAddress())
                          .RuleFor(x => x.City, x => x.Address.City())
                          .RuleFor(x => x.Street, x => x.Address.StreetAddress())
                          .RuleFor(x => x.Value, x => x.Random.Decimal(min: 10000, max: 1000000))
                          .RuleFor(x => x.Family, x => x.Name.FullName())
                          .RuleFor(x=>x.Payments , x => paymentsFaker.Generate(x.Random.Int(min: 1 , max:20))).Generate(50);

                context.Properties.AddRange(properties);
                context.SaveChanges();
                
            }
        }
    }
}

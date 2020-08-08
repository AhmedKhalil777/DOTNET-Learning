using Bogus;
using BookStore.Graph.Database.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Graph.Database.DataSeeders
{
    public static class BookStoreDataSeeder
    {
        public static void SeedData(this UserManager<AppUser> userManager, BookStoreDbContext db)
        {
            if(db.Users?.Count()==0 )
            {

                //roleManager.CreateAsync(new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" }).Wait();
                //roleManager.CreateAsync(new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Author", NormalizedName = "AUTHOR" }).Wait();
                //roleManager.CreateAsync(new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Reader", NormalizedName = "READER" }).Wait();

                var appUsers = new Faker<AppUser>()
                    .RuleFor(x => x.Id, x => Guid.NewGuid())
                    .RuleFor(x => x.UserName, x => x.Person.FullName)
                    .RuleFor(x => x.NormalizedUserName, x => x.Person.FullName.ToUpper())
                    .RuleFor(x => x.Email, x => x.Person.Email)
                    .RuleFor(x => x.PhoneNumber, x => x.Phone.PhoneNumber())
                    .RuleFor(x => x.street, x => x.Address.StreetAddress())
                    .RuleFor(x => x.City, x => x.Address.City())
                    .RuleFor(x => x.Image, x => x.Image.LoremPixelUrl())
                    .Generate(60);
                foreach (var user in appUsers)
                {
                    userManager.CreateAsync(user, "Hello@123").Wait();
                    userManager.AddToRoleAsync(user, "Author").Wait();
                    var commentsFaker = new Faker<Comment>()
                                        .RuleFor(x => x.Body, x => x.Lorem.Sentences())
                                        .RuleFor(x => x.Issuer, x => user);

                    var postsFaker = new Faker<Post>()
                        .RuleFor(x => x.Body, x => x.Lorem.Sentences())
                        .RuleFor(x => x.Head, x => x.Lorem.Sentence(7))
                        .RuleFor(x => x.Comments, x => commentsFaker.Generate(3))
                        .RuleFor(x => x.User, x => user)
                        .Generate(4);
                    db.Posts.AddRange(postsFaker);
                }


             
             




             
               db.SaveChanges();
            }

            
        }
    }
}

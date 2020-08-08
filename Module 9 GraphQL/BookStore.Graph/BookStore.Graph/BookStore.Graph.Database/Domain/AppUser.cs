using BookStore.Graph.Database.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace BookStore.Graph.Database.Domain
{
    public class AppUser :IdentityUser<Guid>, IAppUser
    {

        public string City { get; set; }
        public string Image { get; set; }
        public string street { get; set; }
        public ICollection<Post> Posts { get; set; }
        public  AppGraphUser Project()
        {
            return new AppGraphUser {
                Id = Id,
                UserName = UserName,
                City = City,
                Email = Email,
                Image = Image,
                PhoneNumber = PhoneNumber,
                street = street
            };
        }
    }
}

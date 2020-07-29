using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BookStore.Graph.Database.Domain
{
    public class AppUser :IdentityUser<Guid>
    {
        public string City { get; set; }
        public string Image { get; set; }
        public string street { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}

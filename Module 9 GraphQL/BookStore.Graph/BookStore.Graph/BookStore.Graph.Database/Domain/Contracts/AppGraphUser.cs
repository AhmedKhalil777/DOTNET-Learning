using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Graph.Database.Domain.Contracts
{
    public class AppGraphUser 
    {
        public Guid Id { get; set ; }
        public string Email { get ; set ; }
        public string UserName { get ; set  ; }
        public string PhoneNumber { get; set; }
        public string City { get  ; set; }
        public string Image { get  ; set  ; }
        public string street { get  ; set  ; }
    }
}

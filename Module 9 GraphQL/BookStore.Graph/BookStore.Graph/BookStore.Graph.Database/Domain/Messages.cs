using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.Graph.Database.Domain
{
    public class Messages
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public AppUser Sender { get; set; }
        public AppUser Reciever { get; set; }
        public string Body { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    }
}

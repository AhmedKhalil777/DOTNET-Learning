using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.Graph.Database.Domain
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public string Body { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public Guid IssuerId { get; set; }
        public AppUser Issuer { get; set; }
    }

}

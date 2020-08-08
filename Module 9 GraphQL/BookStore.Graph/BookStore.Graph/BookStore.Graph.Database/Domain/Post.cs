using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.Graph.Database.Domain
{
    public  class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public int Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}

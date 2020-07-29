using Monolith.Graph.Queries;
using System;
using System.Collections.Generic;

namespace Monolith.Graph.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public DateTime PostDate { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}

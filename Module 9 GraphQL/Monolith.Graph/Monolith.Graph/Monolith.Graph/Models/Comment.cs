using System;

namespace Monolith.Graph.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int SenderName { get; set; }
        public int Body { get; set; }
        public DateTime CommentDate { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloCrafts.Models
{
    public class Posts
    {
        public int UID { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Posts>(this);
    }
}

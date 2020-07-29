using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.Graph
{
    public class Droid
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

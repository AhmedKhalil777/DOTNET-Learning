using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company1.Contracts.V1.Requests
{
    public class CreateAnEmployee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

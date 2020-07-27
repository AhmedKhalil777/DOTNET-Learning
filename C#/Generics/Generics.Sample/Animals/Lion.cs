using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Sample.Animals
{
    public class Lion : IAnimal
    {
        public string Name { get; set; } = "Lion";
        public int Age { get; set; } = 10;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Sample.Animals
{
    public class Monkey : IAnimal
    {
        public string Name { get; set; } = "Monkey";
        public int Age { get; set; } = 5;
    }
}

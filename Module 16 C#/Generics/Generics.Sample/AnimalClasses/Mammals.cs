using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Sample.AnimalClasses
{
    public class Mammals<TAnimal>: Animal<TAnimal>  where TAnimal : IAnimal
    {
        public string Type { get; set; } = "Mammal";
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Mammals()
        {
            Console.WriteLine(typeof(TAnimal));
        }

    }
}

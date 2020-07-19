using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Sample.AnimalClasses
{
    public class Birds<TAnimal> : Animal<TAnimal> , IAnimal
    {
        public string Type { get; set; } = "Bird";
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Birds()
        {
            Console.WriteLine(typeof(TAnimal));
        }
    }
}

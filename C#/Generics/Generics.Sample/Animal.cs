using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Sample
{
    public class Animal<TAnimal>
    {
        private TAnimal _animal;
        public Animal()
        {
            Console.WriteLine(typeof(TAnimal));
        }

        public Animal(TAnimal animal)
        {
            _animal = animal;

        }

        public void PrintType()
        {
            Console.WriteLine(typeof(TAnimal).ToString());
        }

    }
}

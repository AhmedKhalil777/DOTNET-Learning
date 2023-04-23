using Generics.Sample.AnimalClasses;
using Generics.Sample.Animals;
using System;
using Bogus;

namespace Generics.Sample
{
    class Program
    {

        static void Main(string[] args)
        {
            
            var stuRepo = new StudentRepository();
            var stuPrinter = new PrinterService<Student>(stuRepo);

            stuPrinter.PrintSorted();
           
        }
    }
}

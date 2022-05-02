using myfirst.BusinessLogic;
using System;

namespace myfirst.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var person1 = new Person { Id = 1, Name = "Ahmed" };
            person1.Print();
        }
    }
}

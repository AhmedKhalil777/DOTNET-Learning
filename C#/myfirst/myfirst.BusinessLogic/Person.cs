using System;

namespace myfirst.BusinessLogic
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Print()
        {
            Console.WriteLine($"The per {Id} =  {Name}");
        }
    }
}

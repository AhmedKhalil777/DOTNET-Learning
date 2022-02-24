using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace Ch9
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person("Ahmed", "Khalil");
            var p2 = new Person("Ibrahim", "Hassan");


            var (firstName, lastName) = p1;
            Console.WriteLine(firstName + " "+ lastName);

            var isEqual = p1 == p2;
            Console.WriteLine(isEqual);

        }

        static bool IsInChat(Person p) => p switch
        {
            ("Ahmed",  "Khalil") => true,
            ("Ibrahim" , "Hassan") => false,
            _ => false

        };

        
}

 
 public record Person(string FirstName,  string LastName);

}

namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}

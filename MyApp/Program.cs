using Microsoft.EntityFrameworkCore;
using System;
using MyApp.Models;
using System.Linq;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter the operation character \n 1- C  :  Create "
                                     +"\n 2 - l : List \n  3 - u : Update ");
             
             var c = char.Parse(Console.ReadLine());
            var dbContext = new sakilaContext();
             

            switch (c)
            {
                case 'l' :
                 var actors = dbContext.Actor.ToList();
                 foreach (var item in actors)
                 {
                     System.Console.WriteLine($"  > ID : {item.ActorId} , Name : {item.FirstName +"  "+ item.LastName} "
                                              + $" films : {item.FilmActor.ToList().ToString()}" );
                 }
                break;
               
            }
         
           var records = dbContext.Film.Include(f => f.FilmActor).ThenInclude(r => r.Actor).ToList();
            foreach (var record in records) {
               Console.WriteLine($"Film: {record.Title}");
               var counter = 1;
               foreach (var fa in record.FilmActor) {
               Console.WriteLine($"\tActor {counter++}: {fa.Actor.FirstName} {fa.Actor.LastName}");
            }
}
        }
    }
}

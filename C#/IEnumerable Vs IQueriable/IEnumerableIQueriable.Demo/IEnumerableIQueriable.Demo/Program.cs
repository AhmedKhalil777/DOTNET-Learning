using IEnumerableIQueriable.Demo.Data;
using IEnumerableIQueriable.Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IEnumerableIQueriable.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EmployeesDbContext(new DbContextOptions<EmployeesDbContext>()))
            { 
                // Loading The Item from DB
                IEnumerable<Employee> enumerableEmployess = db.Employees.Take(3);
                // Using Memory to get the data
                enumerableEmployess = enumerableEmployess.Take(2);
                Console.WriteLine(JsonSerializer.Serialize(enumerableEmployess));
            }
            using (var db = new EmployeesDbContext(new DbContextOptions<EmployeesDbContext>()))
            {

                IQueryable<Employee> queryableEmployess = db.Employees.Take(3);
                queryableEmployess = queryableEmployess.Take(2);
                Console.WriteLine(JsonSerializer.Serialize(queryableEmployess));
            }

       }
    }
}

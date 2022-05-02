using System;
using System.ComponentModel.DataAnnotations;

namespace IEnumerableIQueriable.Demo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Salary  { get; set; }
        public DateTime BirthDay  { get; set; }
        public string Department  { get; set; }
    }

}

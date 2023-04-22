using System;
using Bogus;

namespace Generics.Sample
{

    public interface IReepository<T>
    {
        T[] List();
    }


    public class PrinterService<T>
    {

        private IReepository<T> _repository;
        public PrinterService(IReepository<T> reepository)
        {
            _repository = reepository;
        }


        public void Print()
        {
            foreach (var item in _repository.List())
            {
                Console.WriteLine(item);
            }
        }

        public void PrintSorted()
        {
            var items = _repository.List();
            Array.Sort(items);
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }



    public class StudentRepository : IReepository<Student>
    {
        private Student[] _students;
        public StudentRepository()
        {
            var studentFaker = new Faker<Student>()
             .RuleFor(x => x.FirstName, x => x.Person.FirstName)
             .RuleFor(x => x.LastName, x => x.Person.LastName);

            _students = studentFaker.Generate(20).ToArray();
        }


        public Student[] List()
        {
            return _students;
        }
    }
}
public class Student : IComparable<Student>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student()
    {

    }
    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }

    public int CompareTo(Student stu)
    {
        if (stu is null) return 1;
        if (stu.FirstName == FirstName)
        {
            return LastName.CompareTo(stu.LastName);
        }
        return FirstName.CompareTo(stu.FirstName);

    }
}

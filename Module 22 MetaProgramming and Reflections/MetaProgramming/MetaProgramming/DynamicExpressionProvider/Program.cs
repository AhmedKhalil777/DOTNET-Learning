using System.Linq.Expressions;

static Func<T, T, bool> BuildCompariableExpression<T>(string op)
{
    var right = Expression.Parameter(typeof(T), "Right");
    var left = Expression.Parameter(typeof(T), "Left");
    var exp = op switch
    {
        ">" => Expression.Lambda<Func<T,T,bool>>(Expression.GreaterThan(left,right),left,right),
        "<" => Expression.Lambda<Func<T,T,bool>>(Expression.LessThan(left,right),left,right),
        "=" => Expression.Lambda<Func<T,T,bool>>(Expression.Equal(left,right),left,right),
        "<=" => Expression.Lambda<Func<T,T,bool>>(Expression.LessThanOrEqual(left,right),left,right),
        ">=" => Expression.Lambda<Func<T,T,bool>>(Expression.GreaterThanOrEqual(left,right),left,right),
        "!=" => Expression.Lambda<Func<T,T,bool>>(Expression.NotEqual(left,right),left,right),
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
    return exp.Compile();
}


var equalIntFun = BuildCompariableExpression<int>("=");
var greaterThanOrEqualFun = BuildCompariableExpression<decimal>(">=");
var lessThanFun = BuildCompariableExpression<Student>("<");

Console.WriteLine(equalIntFun(1,1));
Console.WriteLine(greaterThanOrEqualFun(1.0001M,1M));

Student student1 = 3;
Student student2 = 4;
Console.WriteLine(lessThanFun(student1,student2));


public class Student : IEquatable<Student>
{
    public double Score { get; set; }
    public static implicit operator Student(double score) => new(){Score = score};
    public static bool operator <(Student student1, Student student2) => student1.Score < student2.Score;
    public static bool operator >(Student student1, Student student2) => student1.Score > student2.Score;

    public bool Equals(Student? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Score.Equals(other.Score);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Student) obj);
    }

    
    public override int GetHashCode()
    {
        return Score.GetHashCode();
    }
}
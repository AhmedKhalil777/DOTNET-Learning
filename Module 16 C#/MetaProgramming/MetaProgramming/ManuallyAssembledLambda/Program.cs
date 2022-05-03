using System;
using System.Linq.Expressions;
class ManuallyAssembledLambda
{
    static Func<int, int, bool> CompileLambda()
    {
        ParameterExpression Left =
            Expression.Parameter(typeof(int), "Left");
        ParameterExpression Right =
            Expression.Parameter(typeof(int), "Right");
        Expression<Func<int, int, bool>> GreaterThanExpr =
            Expression.Lambda<Func<int, int, bool>>
            (
                Expression.GreaterThan(Left, Right),
                Left, Right
            );
        return GreaterThanExpr.Compile();
    }
    static void Main()
    {
        int L = 7, R = 11;
        Console.WriteLine("{0} > {1} is {2}", L, R,
            CompileLambda()(L, R));
    }
}
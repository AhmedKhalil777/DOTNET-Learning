// See https://aka.ms/new-console-template for more information
using SimplifyingReflections;
using System.Reflection;


internal class Program
{
    private static void Main(string[] args)
    {
        var bird = new Bird();
        bird.Name = "Sparrow";       
        InvokeMethodUsingReflection(bird);
        InvokeMethodUsingDynamic(bird);


        System.Console.WriteLine(GetPropertyValueUsingReflection(bird));
        System.Console.WriteLine(GetPropertyValueUsingDynamic(bird));

        static void InvokeMethodUsingReflection(object obj)
        {
            var type = obj.GetType();
            type.InvokeMember("Fly", BindingFlags.InvokeMethod, null, obj, null);
        }

        static void InvokeMethodUsingDynamic(object obj)
        {
            dynamic d = obj;
            d.Fly();
        }

        static object GetPropertyValueUsingReflection(object obj)
        {
            var type = obj.GetType();
            return type.InvokeMember("Name", BindingFlags.GetProperty, null, obj, null);
            //return type.GetProperty("Name").GetValue(obj);
        }

        static object GetPropertyValueUsingDynamic(object obj)
        {
            dynamic d = obj;
            return d.Name;
        }
    }
}
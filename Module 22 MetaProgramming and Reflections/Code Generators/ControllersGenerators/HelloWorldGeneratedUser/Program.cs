// See https://aka.ms/new-console-template for more information

using ControllersGenerators;

namespace ConsoleApp;

partial class Program
{
    static void Main(string[] args)
    {
        HelloFrom("Generated Code");
    }

    static partial void HelloFrom(string name);
}
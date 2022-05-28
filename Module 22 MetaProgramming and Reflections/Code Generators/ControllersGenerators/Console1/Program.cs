// See https://aka.ms/new-console-template for more information

partial class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        HelloFrom("12222");
    }

    static partial void HelloFrom(string name);
}

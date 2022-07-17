// See https://aka.ms/new-console-template for more information
using OpretorInterval.Sample;

Console.WriteLine("Hello, World!");

var intervalInvoker = new IntervalInvoker<string>(10,Process);

intervalInvoker.Invoke();
for (int i = 0; i < 300; i++)
{
    intervalInvoker.List.Add(i + "- Hello i am invoked");
    Thread.Sleep(1000);
}

Console.ReadKey();
static void Process(List<string> data)
{
    foreach (var dataItem in data)
    {
        Console.WriteLine(dataItem);
    }
}
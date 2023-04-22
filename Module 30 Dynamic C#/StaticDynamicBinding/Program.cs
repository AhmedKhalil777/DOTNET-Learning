// See https://aka.ms/new-console-template for more information
using static System.Console;

OutputTimeStaticBinding();
OutputTimeDynamicBinding();
OutputTimeDynamicBindingRuntimeError();



WriteLine("Press any button to Exit !!!");
ReadLine();

void OutputTimeStaticBinding()
{
    DateTime dt = DateTime.Now;
    string time = dt.ToLongTimeString();
    WriteLine(time);
}

void OutputTimeDynamicBinding()
{
    dynamic dt = DateTime.Now;
    string time = dt.ToLongTimeString();
    WriteLine(time);
}

void OutputTimeDynamicBindingRuntimeError()
{
    dynamic dt = DateTime.Now;
    string time = dt.ToLTString();
    WriteLine(time);
}
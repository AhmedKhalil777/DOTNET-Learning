// See https://aka.ms/new-console-template for more information
using static System.Console;

class Program {
static void Main(string[] args){
int i = 23;
PrintK(i);

dynamic d = 22;

PrintK(d);

dynamic dd ;
WriteLine("Choose [i]nt or [d]ouble");

var choice = ReadKey(intercept: true);
if(choice.Key == ConsoleKey.I){
    dd = 33; 
}
else{
    dd = 33.4;
}
PrintK(dd);



ReadKey();

Console.WriteLine("Hello, World!");
}




static void PrintK(int i){
    WriteLine($"Print(int i) is printing {i}");
}

static void PrintK(dynamic i){
    WriteLine($"Print(dynamic i) is printing {i} with type = {i.GetType()}");
}

}

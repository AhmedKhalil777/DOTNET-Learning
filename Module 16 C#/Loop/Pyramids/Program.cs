//C# 10
using static System.Console;

WriteLine("Add Num of lines");
var isParsed = int.TryParse(ReadLine(), out var lines);
if (!isParsed)
{
    WriteLine("please retry to add nums");
}

for (int i = lines; i >= 1; i--)
{
    for (int j = i; j >= 1; j--)
    {
        Write(j);
        Write(" ");
    }
    for (int j = 2; j <= i; j++)
    {
        Write(j);
        Write(" ");

    }
    WriteLine();

}

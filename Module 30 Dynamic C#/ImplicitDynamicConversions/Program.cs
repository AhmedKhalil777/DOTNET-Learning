// See https://aka.ms/new-console-template for more information
using static System.Console;

int i = 3;
dynamic di = i;
int i2 = di;
WriteLine($"i = {i} , di = {di} , i2 = {i2}");

// Throws Runtime Binding error
// string s = "Hello";
// dynamic ds = s;
// int x = ds;
// WriteLine($"s = {s} , ds = {s} , x = {x}");

long l = 334;
dynamic dl = l;
int y = (int)dl;
// the implicit conversion can not be happened between numerics
// But the  explicit conversion can  happened between numerics (Cast)
WriteLine($"l = {l} , dl = {dl} , y = {y}");

WriteLine("Hello, World!");

// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine(JsonSerializer.Serialize(removeDups(new int[] { 1, 5, 1, 0, 2, 5 })));
Console.WriteLine(JsonSerializer.Serialize(removeDups(new string[] { "The", "big", "cat", "big" })));
Console.WriteLine(JsonSerializer.Serialize(removeDups(new string[] { "Sky", "is", "blue" })));
Console.WriteLine(JsonSerializer.Serialize(removeDups(new string[] { "John", "Taylor", "John" })));
//removeDups(new string[] { "The", "big", "cat", "big" });
//removeDups(new string[] { "Sky", "is", "blue" });
//removeDups(new string[] { "John", "Taylor", "John" });
// Create a function that takes an array of items, removes all duplicate items and returns a new array in the same sequential order as the old array (minus duplicates).
// Examples
// removeDups([1, 5, 1, 0, 2, 5]) ➞ [1, 5, 0, 2]
// removeDups(["The", "big", "cat", "big"]) ➞ ["The", "big", "cat"]
// removeDups(["Sky", "is", "blue"]) ➞ ["Sky", "is", "blue"]
// removeDups(["John", "Taylor", "John"]) ➞ ["John", "Taylor"]

 static T[] removeDups<T>(T[] array) 
{
    return array.DistinctBy(x => x.ToString()).ToArray();
}
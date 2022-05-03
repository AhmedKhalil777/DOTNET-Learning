using System;
using System.Collections;
using System.Reflection;

namespace DataSourcesReflections;

public class ListBox
{
    public string DisplayMember { get; set; }
    public string ValueMember { get; set; }
    public IEnumerable DataSource
    {
        set {
            // Get Iterator to Iterate the Enumerable
            var iterator = value.GetEnumerator();
            // represent current Item inside iterator
            object? currentItem;
            // Set Item to next item
            do {
                if (iterator != null && !iterator.MoveNext())
                    return;
                currentItem = iterator?.Current ?? null;
            } while (currentItem == null);
            // Get property info of  to be displayed  to get the iterators data
            var displayMetadata =
                currentItem.GetType().GetProperty(DisplayMember);
            var valueMetadata =
                currentItem.GetType().GetProperty(ValueMember);
            do {
                currentItem = iterator?.Current;
                // get values by reflection of the object with its metadata
                var displayString =
                    displayMetadata?.GetValue(currentItem, null)?.ToString();
                Console.ForegroundColor = (ConsoleColor) new Random().Next(0,15);
                Console.Write($"[ Name :{displayString}, ");
                object? valueObject =
                    valueMetadata?.GetValue(currentItem, null);
                Console.Write($"Value :{valueObject} ]");
                Console.WriteLine();
            } while (iterator != null && iterator.MoveNext());
        }
    }
}
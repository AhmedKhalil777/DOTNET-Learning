// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.Versioning;

internal class Program
{
    [SupportedOSPlatform("windows")]
    private static void Main(string[] args)
    {
        Console.WriteLine("Please Enter a bird name !");
        var name = Console.ReadLine()!;

        Type excelType = Type.GetTypeFromProgID("Excel.Application")!;
        dynamic excel = Activator.CreateInstance(excelType)!;
        excel.Visible = true;
        excel.Workbooks.Add();

        dynamic workSheet = excel.ActiveSheet;
        workSheet.Cells[1, "A"] = "Bird Name";
        workSheet.Columns[1].AutoFit();
        workSheet.Cells[2, "A"] = name;

    }
}
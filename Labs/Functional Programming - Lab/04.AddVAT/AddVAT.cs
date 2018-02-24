using System;
using System.Linq;

class AddVAT
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(n => n * 1.2)
            .ToList();
        foreach (var number in numbers)
        {
            Console.WriteLine($"{number:f2}");
        }
    }
}
using System;
using System.Linq;

class SortEvenNumbers
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .ToArray();
        Console.WriteLine(String.Join(", ", numbers));
    }
}
using System;
using System.Linq;

class SumNumbers
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        Console.WriteLine(numbers.Count);
        Console.WriteLine(numbers.Sum());
    }
}
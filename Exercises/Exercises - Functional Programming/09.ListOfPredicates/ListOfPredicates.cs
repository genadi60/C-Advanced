using System;
using System.Collections.Generic;
using System.Linq;

class ListOfPredicates
{
    static void Main()
    {
        long range = long.Parse(Console.ReadLine());
        var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        var sequence = new List<int>();
        sequence = input
            .Select(int.Parse)
            .Select(x => Math.Abs(x))
            .OrderByDescending(x => x)
            .ToList();
            
        var maxElement = sequence[0];
        sequence.RemoveAt(0);
        long divider = range / maxElement;
        var numbers = new List<long>();
        var counter = 1L;
        while (counter <= divider)
        {
            numbers.Add(counter * maxElement);
            counter++;
        }

        foreach (var item in sequence)
        {
            numbers = numbers
                .Where(n => n % item == 0)
                .ToList();
        }
        
        Console.WriteLine(string.Join(" ", numbers));
    }
}
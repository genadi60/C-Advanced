using System;
using System.Linq;

class CustomComparator
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        var numbers = input
            .Select(int.Parse)
            .OrderBy(x => x % 2 != 0)
            .ThenBy(x => x )
            .ToArray();
        Console.WriteLine(string.Join(" ", numbers));
    }
}

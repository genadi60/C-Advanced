using System;
using System.Linq;

class ReverseAndExclude
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        var divider = int.Parse(Console.ReadLine());
        var result = input
            .Select(int.Parse)
            .Where(x => !CreatePredicate(divider)(x))
            .Reverse()
            .ToList();
        Console.WriteLine(string.Join(" ", result));

    }

    static Predicate<int> CreatePredicate(int divider)
    {
        return x => x % divider == 0;
    }
}
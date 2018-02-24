using System;
using System.Linq;

class TriFunction
{
    static void Main()
    {
        var sum = int.Parse(Console.ReadLine());
        var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        var items = input
            .Select(s => s.ToCharArray())
            .Where(a => a.Select(c => (int)c).Sum() >= sum)
            .ToList();
        if (items.Count > 0)
        {
            Console.WriteLine(string.Join("", items[0]));
        }
    }
}
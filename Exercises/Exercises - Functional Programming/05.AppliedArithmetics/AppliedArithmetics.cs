using System;
using System.Data;
using System.Linq;

class AppliedArithmetics
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        var numbers = input.Select(int.Parse).ToList();
        while (true)
        {
            var command = Console.ReadLine();
            if ("end".Equals(command))
            {
                break;
            }

            if ("print".Equals(command))
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
            else
            {
                for (int counter = 0; counter < numbers.Count; counter++)
                {
                    numbers[counter] = CreateOperation(command)(numbers[counter]);
                }
            }
        }
    }

    static Func<int, int> CreateOperation(string operation)
    {
        switch (operation)
        {
            case "add":
                return x => x + 1;
            case "subtract":
                return x => x - 1;
            case "multiply":
                return x => x * 2;
            default:
                return null;
        }
    }
}
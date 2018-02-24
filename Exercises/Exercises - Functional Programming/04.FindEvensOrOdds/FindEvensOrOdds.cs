using System;

class FindEvensOrOdds
{
    static void Main()
    {
        var range = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        var numberType = Console.ReadLine();
        for (int counter = int.Parse(range[0]); counter <= int.Parse(range[1]); counter++)
        {
            if (FindSelectedTypeOfNumber(numberType)(counter))
            {
                Console.Write(counter + " ");
            }
        }
        Console.WriteLine();
    }

    static Predicate<int> FindSelectedTypeOfNumber(string type)
    {
        switch (type)
        {
            case "odd":
                return x => x % 2 != 0;
            default:
                return x => x % 2 == 0;
        }
    }
}
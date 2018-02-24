using System;

class CustomMinFunction
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        Func<string[], int> minNumber = x =>
        {
            var min = int.MaxValue;
            foreach (var str in x)
            {
                if (min > int.Parse(str))
                {
                    min = int.Parse(str);
                }
            }
            return min;
        };
        Console.WriteLine(minNumber(input));
    }
}
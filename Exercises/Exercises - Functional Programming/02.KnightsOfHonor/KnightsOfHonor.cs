using System;

class KnightsOfHonor
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        Action<string> print = x => Console.WriteLine("Sir " + x);
        foreach (var item in input)
        {
            print(item);
        }
    }
}
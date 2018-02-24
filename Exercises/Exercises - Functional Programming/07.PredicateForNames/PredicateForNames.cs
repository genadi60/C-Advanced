using System;

class PredicateForNames
{
    static void Main()
    {
        var nameLength = int.Parse(Console.ReadLine());
        var input = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        for (int counter = 0; counter < input.Length; counter++)
        {
            if (CreatePredicate(nameLength)(input[counter]))
            {
                Console.WriteLine(input[counter]);
            }
        }
    }

    static Predicate<string> CreatePredicate(int nameLength)
    {
        return x => x.Length <= nameLength;
    }
}
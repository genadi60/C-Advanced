using System;
using System.Collections.Generic;
using System.Linq;

class FilterByAge
{
    static void Main()
    {
        var peopleNumbers = int.Parse(Console.ReadLine());
        var personByAge = new Dictionary<string, int>(peopleNumbers);
        for (int index = 0; index < peopleNumbers; index++)
        {
            var person = Console.ReadLine()
                .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries);
            var name = person[0];
            var age = int.Parse(person[1]);
            personByAge.Add(name, age);
        }
        var condition = Console.ReadLine();
        var limitAge = int.Parse(Console.ReadLine());
        var printProperties = Console.ReadLine();
        var filter = CreateFilter(condition, limitAge);
        var print = PrintResult(printProperties);
        foreach (var keyValuePair in personByAge.Where(filter))
        {
            print(keyValuePair);
        }
    }

    static Func<KeyValuePair<string, int>, bool> CreateFilter(string condition, int limitAge)
    {
        switch (condition)
        {
            case "younger":
                return p => p.Value < limitAge;
            default:
                return p => p.Value >= limitAge;
        }
    }

    static Action<KeyValuePair<string, int>> PrintResult(string printProperties)
    {
        switch (printProperties)
        {
            case "name":
                return p => Console.WriteLine($"{p.Key}");
            case "age":
                return p => Console.WriteLine($"{p.Value}");
            default:
                return p => Console.WriteLine($"{p.Key} - {p.Value}");
        }
    }
}
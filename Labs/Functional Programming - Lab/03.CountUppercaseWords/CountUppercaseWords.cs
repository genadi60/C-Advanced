using System;
using System.Linq;

class CountUppercaseWords
{
    static void Main()
    {
        Func<string, bool> selectedWord = s => Char.IsUpper(s[0]);
        Action<string> print = s => Console.WriteLine(s);
        var input = Console.ReadLine()
            .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
            .Where(selectedWord)
            .ToList();
        foreach (var item in input)
        {
            print(item);
        }
    }
}

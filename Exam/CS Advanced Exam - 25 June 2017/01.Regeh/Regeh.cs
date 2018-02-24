using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Regeh
{
    static void Main()
    {
        var pattern = @"\[[a-zA-Z]+<(?<firstIndex>\d+)REGEH(?<secondIndex>\d+)>[a-zA-Z]+\]";
        Regex regex = new Regex(pattern);
        var input = Console.ReadLine();
        var indexes = new List<int>();
        foreach (Match match in regex.Matches(input))
        {
            indexes.Add(int.Parse(match.Groups["firstIndex"].ToString()));
            indexes.Add(int.Parse(match.Groups["secondIndex"].ToString()));
        }
        var currentIndex = 1;
        foreach (var index in indexes)
        {
            currentIndex += index;
            var letterIndex = currentIndex % (input.Length - 1);
            Console.Write(input[letterIndex]);
        }

        Console.WriteLine();
    }
}
using System;
using System.Collections.Generic;

class MatchingBrackets
{
    static void Main()
    {
        var line = Console.ReadLine();
        var stack = new Stack<int>();

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i].Equals('('))
            {
                stack.Push(i);
            }
            else if (line[i].Equals(')'))
            {
                var firstIndex = stack.Pop();
                var secondIndex = i;
                var output = line.Substring(firstIndex, secondIndex - firstIndex + 1);
                Console.WriteLine(output);
            }
        }
    }
}
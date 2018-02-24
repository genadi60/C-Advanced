using System;
using System.Collections.Generic;

class ReverseNumbers
{
    static void Main()
    {
        var line = Console.ReadLine().Split(' ');
        var stack = new Stack<int>();

        for (int i = 0; i < line.Length; i++)
        {
            var result = 0;
            if (int.TryParse(line[i], out result))
            {
                stack.Push(result);
            }
        }

        for (int i = 0; i < line.Length; i++)
        {
            if (i != 0)
            {
                Console.Write(" ");
            }

            if (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }

        Console.WriteLine();
    }
}
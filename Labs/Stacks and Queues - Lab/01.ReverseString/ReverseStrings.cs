using System;
using System.Collections.Generic;

class ReverseStrings
{
    static void Main()
    {
        string line = Console.ReadLine(); 
        var stack = new Stack<char>();

        for (int i = 0; i < line.Length; i++)
        {
            stack.Push(line[i]);
        }

        for (int i = 0; i < line.Length; i++)
        {
            Console.Write(stack.Pop());
        }

        Console.WriteLine();
    }
}
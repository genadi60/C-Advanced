using System;
using System.Collections.Generic;

class StackFibonacci
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine(GetFibonacci(n));
    }

    private static long GetFibonacci(int n)
    {
        var stack = new Stack<long>();
        for (int i = 1; i <= n; i++)
        {
            if (i == 1 || i == 2)
            {
                stack.Push(1);
            }
            else
            {
                var temp = stack.Pop();
                var sum = temp + stack.Pop();
                stack.Push(temp);
                stack.Push(sum);
            }
        }
        return stack.Pop();
    }
}
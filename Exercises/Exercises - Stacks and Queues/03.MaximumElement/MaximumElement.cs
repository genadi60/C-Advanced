using System;
using System.Collections.Generic;

class MaximumElement
{
    static void Main()
    {
        var queriesNumber = int.Parse(Console.ReadLine());
        var stack = new Stack<int>();
        var maxValue = new Stack<int>();
        var max = int.MinValue;
        for (int i = 0; i < queriesNumber; i++)
        {
            var queries = Console.ReadLine().Split(' ');
            if ("1".Equals(queries[0]))
            {
                int value = int.Parse(queries[1]);
                stack.Push(value);
                if (max < value)
                {
                    max = value;
                    maxValue.Push(max);
                }
            }
            else if ("2".Equals(queries[0]))
            {
                if (stack.Count > 0)
                {
                    if (max == stack.Pop())
                    {
                        maxValue.Pop();
                        max = maxValue.Count != 0 ? maxValue.Peek() : int.MinValue;
                    }
                }
            }
            else
            {
                Console.WriteLine(max);
            }
        }
    }
}
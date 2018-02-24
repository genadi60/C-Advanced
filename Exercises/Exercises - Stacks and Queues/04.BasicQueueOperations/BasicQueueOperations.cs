using System;
using System.Collections.Generic;
using System.Linq;

class BasicQueueOperations
{
    static void Main()
    {
        var operands = Console.ReadLine()
            .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var min = int.MaxValue;
        var exist = false;
        var queue = new Queue<int>();
        var numbers = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        for (int i = operands[1]; i < operands[0]; i++)
        {
            var value = numbers[i];
            queue.Enqueue(value);
            if (operands[2] == value)
            {
                exist = true;
            }

            if (min > value)
            {
                min = value;
            }
        }

        Console.WriteLine(exist ? "true" : queue.Count == 0 ? "0" : min.ToString());
    }
}
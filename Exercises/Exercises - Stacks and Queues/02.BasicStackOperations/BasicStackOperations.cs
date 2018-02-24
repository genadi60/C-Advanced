using System;
using System.Collections.Generic;
using System.Linq;

class BasicStackOperations
{
    static void Main()
    {
        var operands = Console.ReadLine().Split(' ');
        var elementsToPush = int.Parse(operands[0]);
        var elementsToPop = int.Parse(operands[1]);
        var targetElement = int.Parse(operands[2]);

        var elements = Console.ReadLine().Split(' ');
        var stack = new Stack<int>();
        var result = 0;
        for (int i = 0; i < (elementsToPush <= elements.Length ? elementsToPush: elements.Length); i++)
        {
            if (int.TryParse(elements[i], out result))
            {
                stack.Push(result);
            }
        }

        var stackSize = stack.Count;
        for (var i = 0; i < (elementsToPop <= stackSize ? elementsToPop : stackSize); i++)
        {
            stack.Pop();
        }

        if (stack.Contains(targetElement))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(stack.Count == 0 ? 0 : stack.Min());
        }
    }
}
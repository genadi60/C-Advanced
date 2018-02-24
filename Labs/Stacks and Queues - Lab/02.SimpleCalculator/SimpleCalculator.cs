using System;
using System.Collections.Generic;
using System.Linq;

class SimpleCalculator
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] tokens = line.Split(' ');
        var stack = new Stack<string>(tokens.Reverse());

        while (stack.Count > 1)
        {
            int firstOperator = int.Parse(stack.Pop());
            string operation = stack.Pop();
            int secondOperator = int.Parse(stack.Pop());

            if (operation.Equals("+"))
            {
                stack.Push((firstOperator + secondOperator).ToString());
            }
            else
            {
                stack.Push((firstOperator - secondOperator).ToString());
            }
        }

        Console.WriteLine(stack.Pop());
    }
}
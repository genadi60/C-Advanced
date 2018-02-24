using System;
using System.Collections.Generic;

class BalancedParenthesis
{
    static void Main()
    {
        var sequenceOfParanteses = Console.ReadLine();
        List<char> openParanteses = new List<char>{ '{', '[', '('};
        List<char> closeParanteses = new List<char>{'}', ']', ')'};
        var stack = new Stack<char>();
        bool isBalanced = true;
        bool containParantese = false;
        if (sequenceOfParanteses.Length == 0)
        {
            isBalanced = false;
        }
        else
        {
            foreach (char parantese in sequenceOfParanteses)
            {
                if (!openParanteses.Contains(parantese) && !closeParanteses.Contains(parantese))
                {
                    continue;
                }
                if (openParanteses.Contains(parantese))
                {
                    var index = openParanteses.IndexOf(parantese);
                    stack.Push(closeParanteses[index]);
                }

                if (closeParanteses.Contains(parantese))
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    if (!parantese.Equals(stack.Peek()))
                    {
                        isBalanced = false;
                        break;
                    }
                    stack.Pop();
                    containParantese = true;
                }
            }
        }

        if (!containParantese)
        {
            isBalanced = false;
        }
        Console.WriteLine(isBalanced && stack.Count == 0 ? "YES" : "NO");
    }
}
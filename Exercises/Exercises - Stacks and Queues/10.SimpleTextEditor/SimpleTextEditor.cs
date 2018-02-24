using System;
using System.Collections.Generic;
using System.Linq;

class SimpleTextEditor
{
    static void Main()
    {
        var text = "";
        var stack = new Stack<string>();
        stack.Push(text);
        var numberOfCommands = int.Parse(Console.ReadLine());
        while (numberOfCommands > 0)
        {
            var commandsData = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var command = commandsData[0];
            switch (command)
            {
                case "1":
                    text += commandsData[1];
                    stack.Push(text);
                    break;
                case "2":
                    text = text.Substring(0, text.Length - int.Parse(commandsData[1]));
                    stack.Push(text);
                    break;
                case "3":
                    Console.WriteLine(text[int.Parse(commandsData[1]) - 1]);
                    break;
                case "4":
                    stack.Pop();
                    text = stack.Peek();
                    break;
            }
            numberOfCommands--;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        var numberOfRows = int.Parse(Console.ReadLine());
        int[][] firstJagged = new int[numberOfRows][];
        int[][] secondJagged = new int[numberOfRows][];
        var cels = 0;
        for (int i = 0; i < numberOfRows; i++)
        {
            firstJagged[i] = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            cels += firstJagged[i].Length;
        }

        for (int i = 0; i < numberOfRows; i++)
        {
            secondJagged[i] = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            cels += secondJagged[i].Length;
        }

        bool isEqual = true;
        for (int i = 0; i < numberOfRows - 1; i++)
        {
            if ((firstJagged[i].Length + secondJagged[i].Length) != (firstJagged[i + 1].Length + secondJagged[i + 1].Length))
            {
                isEqual = false;
            }
        }

        if (!isEqual)
        {
            Console.WriteLine($"The total number of cells is: {cels}");
        }
        else
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                List<int> list = new List<int>();
                list.AddRange(secondJagged[i]);
                list.Reverse();
                Console.WriteLine("[" + String.Join(", ",firstJagged[i]) + ", " + String.Join(", ", list) + "]");
            }
        }
    }
}
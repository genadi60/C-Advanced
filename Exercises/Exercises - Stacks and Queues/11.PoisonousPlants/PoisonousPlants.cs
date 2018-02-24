using System;
using System.Collections.Generic;
using System.Linq;

class PoisonousPlants
{
    static void Main()
    {
        
        var numberOfPlants = int.Parse(Console.ReadLine());
        var plants = Console.ReadLine()
            .Split(new[] {' '})
            .Select(int.Parse)
            .ToArray();
        var plantsDieDays = new int[numberOfPlants];
        var previousPlants = new Stack<int>();
        previousPlants.Push(0);

        for (int i = 1; i < numberOfPlants; i++)
        {
            var lastDay = 0;
            while (previousPlants.Count > 0 && plants[previousPlants.Peek()] >= plants[i])
            {
                lastDay = Math.Max(lastDay, plantsDieDays[previousPlants.Pop()]);
            }

            if (previousPlants.Count > 0)
            {
                plantsDieDays[i] = lastDay + 1;
            }
            previousPlants.Push(i);
        }

        Console.WriteLine(plantsDieDays.Max());
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {

        var numberOfPlants = int.Parse(Console.ReadLine());
        var plants = Console.ReadLine()
            .Split(new[] { ' ' })
            .Select(int.Parse)
            .ToArray();
        var count = 0;
        var maxDays = 0;
        bool increace = false;
        var previousPlants = new Stack<int>();
        previousPlants.Push(plants[0]);

        for (int i = 1; i < numberOfPlants; i++)
        {
            if (plants[i] > plants[i - 1])
            {
                if (!increace)
                {
                    count = 1;
                }
                
            }
            else
            {
                var temp = previousPlants.Peek();
                if (plants[i] > temp)
                {
                    count++;
                    increace = true;
                }
                else
                {
                    previousPlants.Push(plants[i]);
                    count = 0;
                    increace = false;
                }
            }
            if (maxDays < count)
            {
                maxDays = count;
            }
        }

        Console.WriteLine(maxDays);
    }
}
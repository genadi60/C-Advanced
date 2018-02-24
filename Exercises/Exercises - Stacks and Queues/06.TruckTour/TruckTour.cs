using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main()
    {
        var numberOfStations = int.Parse(Console.ReadLine());
        var petrol = new Queue<int>();
        var distances = new Queue<int>();

        for (int i = 0; i < numberOfStations; i++)
        {
            var tokens = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            petrol.Enqueue(tokens[0]);
            distances.Enqueue(tokens[1]);
        }

        var remainderOfPetrol = 0;

        for (int i = 0; i < numberOfStations; i++)
        {
            bool isEnough = true;
            
            for (int j = 0; j < numberOfStations; j++)
            {
                if (!(distances.Peek() <= petrol.Peek() + remainderOfPetrol))
                {
                    isEnough = false;
                    remainderOfPetrol = 0;
                    i += j;
                    j = numberOfStations;
                }
                else
                {
                    remainderOfPetrol += petrol.Peek() - distances.Peek();
                }
                petrol.Enqueue(petrol.Dequeue());
                distances.Enqueue(distances.Dequeue());
            }

            if (isEnough)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}
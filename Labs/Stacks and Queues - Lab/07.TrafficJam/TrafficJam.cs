using System;
using System.Collections.Generic;

class TrafficJam
{
    static void Main()
    {
	    var queueOfCars = new Queue<string>();
	    var carNumbers = int.Parse(Console.ReadLine());
	    var passedCars = 0;
	    while (true)
	    {
			var line = Console.ReadLine();
		    if ("end".Equals(line))
		    {
			    break;
		    }

		    if ("green".Equals(line))
		    {
			    var loopNumber = Math.Min(carNumbers, queueOfCars.Count);
			    for (int i = 0; i < loopNumber; i++)
			    {
				    Console.WriteLine(queueOfCars.Dequeue() + " passed!");
				}
			    passedCars += loopNumber;
			}
		    else
		    {
				queueOfCars.Enqueue(line);
			}
		}

	    Console.WriteLine($"{passedCars} cars passed the crossroads.");
    }
}
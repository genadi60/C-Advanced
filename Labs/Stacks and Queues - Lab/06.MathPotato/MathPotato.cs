using System;
using System.Collections.Generic;

class MathPotato
{
    static void Main()
    {
        var line = Console.ReadLine();
        var step = int.Parse(Console.ReadLine());
        var tokens = line.Split(' ');
        var queue = new Queue<string>(tokens);
        var count = 1;
        while (queue.Count > 1)
        {
            var isPrime = true;
            for (var i = 0; i < (step - 1) % queue.Count; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            if (count == 1)
            {
                Console.WriteLine("Removed " + queue.Dequeue());
                isPrime = false;
            }
            for (var i = 2; i <= Math.Sqrt(count); i++)
            {
                if (count % i == 0 )
                {
                    Console.WriteLine("Removed " + queue.Dequeue());
                    isPrime = false;
                }
                if (!isPrime)
                {
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine("Prime " + queue.Peek());
            }

            count++;
        }

        Console.WriteLine("Last is " + queue.Dequeue());
    }
}
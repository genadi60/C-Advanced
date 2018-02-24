using System;
using System.Collections.Generic;

class HotPotato
{
    static void Main()
    {
        var line = Console.ReadLine();
        var step = int.Parse(Console.ReadLine());    
        var tokens = line.Split(' ');
        var queue = new Queue<string>(tokens);

        while (queue.Count > 1)
        {
            for (int i = 0; i < (step - 1) % queue.Count; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine("Removed " + queue.Dequeue());
        }

        Console.WriteLine("Last is " + queue.Dequeue());
    }
}
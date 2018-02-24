using System;
using System.Collections.Generic;

class SequenceWithQueue
{
    static void Main()
    {
        var queue = new Queue<double>();
        var tempQueue = new Queue<double>();
        var number = 0.0;
        if (double.TryParse(Console.ReadLine(), out number))
        {
            queue.Enqueue(number);
            tempQueue.Enqueue(number);
            var addValue = 1;
            while (queue.Count < 49)
            {
                var element = tempQueue.Dequeue();
                var sum = element + addValue;
                queue.Enqueue(sum);
                tempQueue.Enqueue(sum);
                queue.Enqueue(sum + element);
                tempQueue.Enqueue(sum + element);
                queue.Enqueue(sum + addValue);
                tempQueue.Enqueue(sum + addValue);
            }
            queue.Enqueue(tempQueue.Dequeue() + addValue);
        }

        if (queue.Count > 0)
        {
            Console.WriteLine(string.Join(" ", queue));
        }  
    }
}